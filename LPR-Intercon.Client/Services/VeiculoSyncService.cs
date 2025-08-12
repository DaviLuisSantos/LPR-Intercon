using LPR_Intercon.Shared.Models.Sqlite;
using LPR_Intercon.Shared.Models.Firebird;
using LPR_Intercon.Shared.DTOs; // Supondo que tenha um DTO de sync para Veículo
using Microsoft.EntityFrameworkCore;
using LPR_Intercon.Shared.Data;

namespace LPR_Intercon.Client.Services;

public class VeiculoSyncService(
    FirebirdDbContext firebirdContext,
    SqliteDbContext sqliteContext,
    IHttpClientFactory httpClientFactory,
    IConfiguration config,
    ILogger<VeiculoSyncService> logger)
{
    public async Task SyncVeiculosAsync()
    {
        try
        {
            // 1. Ler dados do Firebird
            var firebirdVeiculos = await firebirdContext.Veiculo
                .AsNoTracking()
                .ToListAsync();

            // 2. Obter FirebirdIds já existentes no SQLite
            var existingFirebirdIds = await sqliteContext.Veiculo
                .AsNoTracking()
                .Select(v => v.FirebirdId)
                .ToListAsync();

            // 3. Converter e filtrar apenas novos
            var novosRegistros = firebirdVeiculos
                .Where(f => !existingFirebirdIds.Contains(f.Id))
                .Select(f => new LPR_Intercon.Shared.Models.Sqlite.Veiculo
                {
                    Id = Guid.NewGuid(),
                    Placa = f.Placa,
                    Marca = f.Marca,
                    Modelo = f.Modelo,
                    Cor = f.Cor,
                    UnidadeId = ObterUnidadeLocalId(f.Unidade), // Implementar mapeamento
                    FirebirdId = f.Id,
                    Sincronizado = false
                }).ToList();

            if (novosRegistros.Count > 0)
            {
                await sqliteContext.Veiculo.AddRangeAsync(novosRegistros);
                await sqliteContext.SaveChangesAsync();
            }

            // 4. Buscar veículos não sincronizados
            var veiculosNaoSincronizados = await sqliteContext.Veiculo
                .Where(v => !v.Sincronizado)
                .ToListAsync();

            if (veiculosNaoSincronizados.Count > 0)
            {
                // Montar DTOs
                var dtos = veiculosNaoSincronizados.Select(v => new VeiculoSyncDto
                {
                    Id = v.Id,
                    FirebirdId = v.FirebirdId,
                    Placa = v.Placa,
                    Marca = v.Marca,
                    Modelo = v.Modelo,
                    Cor = v.Cor,
                    UnidadeId = v.UnidadeId
                }).ToList();

                // Enviar para servidor central
                var httpClient = httpClientFactory.CreateClient();
                var centralUrl = config["CentralApi:BaseUrl"] + "/api/sync/veiculos";

                var response = await httpClient.PostAsJsonAsync(centralUrl, dtos);
                response.EnsureSuccessStatusCode();

                // 5. Marcar como sincronizados
                foreach (var veiculo in veiculosNaoSincronizados)
                    veiculo.Sincronizado = true;

                await sqliteContext.SaveChangesAsync();
            }

            logger.LogInformation($"Sincronização de veículos concluída: {veiculosNaoSincronizados.Count} registros enviados");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Falha na sincronização de veículos");
            throw;
        }
    }

    private Guid ObterUnidadeLocalId(string unidadeCodigoFirebird)
    {
        // Mapeia a unidade do Firebird para o Id local no SQLite
        return sqliteContext.Unidade
            .FirstOrDefault(u => u.IdFirebird.ToString() == unidadeCodigoFirebird)?.Id
            ?? throw new Exception($"Unidade {unidadeCodigoFirebird} não encontrada no SQLite");
    }
}
