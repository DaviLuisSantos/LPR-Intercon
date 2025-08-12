using LPR_Intercon.Shared.Data;
using LPR_Intercon.Shared.DTOs;
using LPR_Intercon.Shared.Models.Sqlite;
using Microsoft.AspNetCore.Mvc;

namespace LPR_Intercon.Server.Controllers;

[ApiController]
[Route("api/condominios")]
public class CondominioController : Controller
{
    private readonly SqliteDbContext _context;
    private readonly ILogger<CondominioController> _logger;

    public CondominioController(
        SqliteDbContext context,
        ILogger<CondominioController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost("sync")]
    public async Task<IActionResult> SyncCondominios([FromBody] List<CondominioSyncDto> dtos)
    {
        try
        {
            // 1. Mapear para modelo SQLite central
            var entities = dtos.Select(dto => new Condominio
            {
                Id = Guid.Parse(dto.Id),
                Nome = dto.Nome,
                Cnpj = dto.Cnpj,
                Telefone = dto.Telefone,
                Cep = dto.Cep,
                Endereco = dto.Endereco,
                Numero = dto.Numero,
                Uf = dto.Uf,
                Ip = dto.Ip,
            }).ToList();

            // 2. Salvar apenas no SQLite central
            await _context.Condominio.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            return Ok(new { Received = dtos.Count, Saved = entities.Count });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao sincronizar condomínios");
            return StatusCode(500, new { Error = "Erro interno no servidor" });
        }
    }
}
