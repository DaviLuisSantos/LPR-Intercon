using LPR_Intercon.Client.Extensions;
using LPR_Intercon.Client.Services.Interfaces;
using LPR_Intercon.Shared.Data;
using LPR_Intercon.Shared.DTOs;
using LPR_Intercon.Shared.Models.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace LPR_Intercon.Client.Services;

public class UnidadeSyncService(
    FirebirdDbContext firebirdContext,
    SqliteDbContext sqliteContext,
    IHttpClientFactory httpClientFactory,
    IConfiguration config,
    ILogger<CondominioSyncService> logger)
{
    public async Task SyncUnidadesAsync()
    {
        try
        {
            // 1. Ler dados do Firebird
            var firebirdUnidades = await firebirdContext.Unidade
                .AsNoTracking()
                .ToListAsync();

            // 2. Obter Ids do Firebird já existentes no SQLite
            var existingFirebirdIds = await sqliteContext.Unidade
                .AsNoTracking()
                .Select(u => u.IdFirebird)
                .ToListAsync();

            // 3. Converter e filtrar apenas novos registros
            var novosRegistros = firebirdUnidades
                .Where(f => !existingFirebirdIds.Contains(f.Id))
                .Select(f => new Unidade
                {
                    Id = Guid.NewGuid(),
                    Nome = f.Nome,
                    Vagas = f.NumVagas ?? 0,
                    IdFirebird = f.Id,
                    CondominioId = ObterCondominioLocalId(),
                    Sincronizado = false
                }).ToList();

            if (novosRegistros.Count > 0)
            {
                await sqliteContext.Unidade.AddRangeAsync(novosRegistros);
                await sqliteContext.SaveChangesAsync();
            }

            // 4. Buscar unidades ainda não sincronizadas
            var unidadesNaoSincronizadas = await sqliteContext.Unidade
                .Where(u => !u.Sincronizado)
                .ToListAsync();

            if (unidadesNaoSincronizadas.Count > 0)
            {
                // Montar DTOs
                var dtos = unidadesNaoSincronizadas.Select(e => new UnidadeSyncDto
                {
                    Id = e.Id,
                    IdFirebird = e.IdFirebird,
                    CondominioIdLocal = e.CondominioId,
                    Nome = e.Nome,
                    Vagas = e.Vagas,
                    AndarQuadra = firebirdUnidades.First(f => f.Id == e.IdFirebird).AndarQuadra,
                    AptoLote = firebirdUnidades.First(f => f.Id == e.IdFirebird).AptoLote,
                    Bloco = firebirdUnidades.First(f => f.Id == e.IdFirebird).Bloco,
                    DataHoraCadastro = firebirdUnidades.First(f => f.Id == e.IdFirebird).DataHoraCadastro
                }).ToList();

                // Enviar para servidor central
                var httpClient = httpClientFactory.CreateClient();
                var centralUrl = config["CentralApi:BaseUrl"] + "/api/sync/unidades";

                var response = await httpClient.PostAsJsonAsync(centralUrl, dtos);
                response.EnsureSuccessStatusCode();

                // 5. Marcar como sincronizadas
                foreach (var unidade in unidadesNaoSincronizadas)
                    unidade.Sincronizado = true;

                await sqliteContext.SaveChangesAsync();
            }

            logger.LogInformation($"Sincronização de unidades concluída: {unidadesNaoSincronizadas.Count} registros enviados");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Falha na sincronização de unidades");
            throw;
        }
    }

    private Guid ObterCondominioLocalId()
    {
        return sqliteContext.Condominio.First().Id;
    }

}
