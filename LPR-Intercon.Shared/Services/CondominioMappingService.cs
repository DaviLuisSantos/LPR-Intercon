using LPR_Intercon.Shared.Data;
using LPR_Intercon.Shared.Models.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LPR_Intercon.Shared.Services;

public interface ICondominioMappingService
{
    Task<Condominio> GetCentralCondominioId(Guid localCondominioId);
}

public class CondominioMappingService : ICondominioMappingService
{
    private readonly SqliteDbContext _context;
    private readonly ILogger<CondominioMappingService> _logger;

    public CondominioMappingService(
        SqliteDbContext context,
        ILogger<CondominioMappingService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Condominio> GetCentralCondominioId(Guid localCondominioId)
    {
        // Buscar mapeamento na tabela de correspondência
        var mapping = await _context.Condominio
            .FirstOrDefaultAsync(m => m.Id == localCondominioId);

        if (mapping != null)
        {
            return mapping;
        }

        // Lógica de fallback (ex: condomínio padrão)
        _logger.LogWarning($"Mapeamento não encontrado para condomínio local: {localCondominioId}");
        return _context.Condominio.First();
    }
}
