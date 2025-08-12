using LPR_Intercon.Client.Extensions;
using LPR_Intercon.Client.Services.Interfaces;
using LPR_Intercon.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LPR_Intercon.Client.Services;
public class CondominioSyncService(
    FirebirdDbContext firebirdContext,
    SqliteDbContext sqliteContext,
    IHttpClientFactory httpClientFactory,
    IConfiguration config,
    ILogger<CondominioSyncService> logger) : ICondominioSyncService
{
    public async Task SyncCondominiosAsync()
    {
        try
        {
            // 1. Ler dados do Firebird
            var firebirdCondominios = await firebirdContext.Condominio
                .AsNoTracking()
                .ToListAsync();

            // 2. Obter CNPJs já existentes no SQLite
            var existingCnpjs = await sqliteContext.Condominio
                .AsNoTracking()
                .Select(c => c.Cnpj) // string ou long, depende do modelo
                .ToListAsync();

            // 3. Converter e filtrar apenas novos registros
            var novosRegistros = firebirdCondominios
                .Where(f => !existingCnpjs.Contains(f.Cnpj))
                .Select(f => f.ToSqliteModel())
                .ToList();

            if (novosRegistros.Count > 0)
            {
                // Salvar no SQLite
                await sqliteContext.Condominio.AddRangeAsync(novosRegistros);
                await sqliteContext.SaveChangesAsync();

                // 4. Enviar para servidor central apenas os novos
                var httpClient = httpClientFactory.CreateClient();
                var centralUrl = config["CentralApi:BaseUrl"] + "/api/sync/condominios";

                var response = await httpClient.PostAsJsonAsync(
                    centralUrl,
                    novosRegistros.Select(e => e.ToSyncDto()));

                response.EnsureSuccessStatusCode();
            }

            logger.LogInformation($"Sincronização concluída: {novosRegistros.Count} registros enviados");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Falha na sincronização");
            throw;
        }
    }

}
