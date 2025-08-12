using LPR_Intercon.Shared.Data;
using LPR_Intercon.Shared.DTOs;
using LPR_Intercon.Shared.Models.Sqlite;
using LPR_Intercon.Shared.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace LPR_Intercon.Server.Services;

public class UnidadeSyncService(
    SqliteDbContext sqliteContext,
    FirebirdDbContext firebirdContext,
    ICondominioMappingService mappingService,
    ILogger<UnidadeSyncService> logger)
{
    public async Task<SyncResult> SyncUnidadesAsync(List<UnidadeSyncDto> dtos)
    {
        var result = new SyncResult
        {
            ReceivedCount = dtos.Count,
            Success = false
        };

        try
        {
            var sqliteEntities = new List<Unidade>();
            var idMapping = new Dictionary<Guid, int>(); // Mapeamento: ID SQLite Local → ID Firebird

            var condominio = await mappingService.GetCentralCondominioId(dtos[0].CondominioIdLocal);
            // 1. Salvar unidades no Firebird uma por uma para obter IDs sequenciais
            foreach (var dto in dtos)
            {
                try
                {
                    // Criar entidade Firebird (sem ID definido)
                    var firebirdEntity = new Shared.Models.Firebird.Unidade
                    {
                        Nome = dto.Nome + " " + condominio.Nome.Split(' ')[0],
                        NumVagas = dto.Vagas,
                        AndarQuadra = dto.AndarQuadra,
                        AptoLote = dto.AptoLote,
                        Bloco = dto.Bloco,
                        DataHoraCadastro = dto.DataHoraCadastro ?? DateTime.Now
                    };

                    // Adicionar e salvar imediatamente para obter o ID gerado
                    await firebirdContext.Unidade.AddAsync(firebirdEntity);
                    await firebirdContext.SaveChangesAsync();

                    // Armazenar mapeamento de IDs
                    idMapping[dto.Id] = firebirdEntity.Id;

                    // Registrar sucesso
                    result.FirebirdSavedCount++;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"Erro ao salvar unidade no Firebird: {dto.Nome} (ID: {dto.Id})");
                }
            }

            // 2. Salvar unidades no SQLite central com os IDs do Firebird
            foreach (var dto in dtos)
            {
                try
                {
                    // Obter ID Firebird gerado
                    if (!idMapping.TryGetValue(dto.Id, out var firebirdId))
                    {
                        logger.LogWarning($"ID Firebird não encontrado para unidade {dto.Nome} (ID: {dto.Id})");
                        continue;
                    }

                    sqliteEntities.Add(new Unidade
                    {
                        Id = dto.Id,
                        Nome = dto.Nome,
                        Vagas = dto.Vagas,
                        IdFirebird = firebirdId,
                        CondominioId = condominio.Id,
                        AndarQuadra = dto.AndarQuadra,
                        AptoLote = dto.AptoLote,
                        Bloco = dto.Bloco,
                    });
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"Erro ao processar unidade para SQLite: {dto.Nome} (ID: {dto.Id})");
                }
            }

            // Salvar em lote no SQLite
            await sqliteContext.Unidade.AddRangeAsync(sqliteEntities);
            await sqliteContext.SaveChangesAsync();
            result.SqliteSavedCount = sqliteEntities.Count;

            result.Success = true;
            return result;
        }
        catch (DbUpdateException dbEx)
        {
            logger.LogError(dbEx, "Erro de banco de dados ao sincronizar unidades");
            result.ErrorMessage = "Erro de banco de dados. Verifique os logs para detalhes.";
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Falha crítica ao sincronizar unidades");
            result.ErrorMessage = "Erro interno no servidor.";
            return result;
        }
    }
}
