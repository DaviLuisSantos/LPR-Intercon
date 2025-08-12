using LPR_Intercon.Server.Services;
using LPR_Intercon.Shared.Data;
using LPR_Intercon.Shared.DTOs;
using LPR_Intercon.Shared.Models.Sqlite;
using LPR_Intercon.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LPR_Intercon.Server.Controllers;

[ApiController]
[Route("api/unidades")]
public class UnidadeController(
    UnidadeSyncService syncService,
    ILogger<UnidadeController> logger) : Controller
{
    [HttpPost("sync")]
    public async Task<IActionResult> SyncUnidades([FromBody] List<UnidadeSyncDto> dtos)
    {
        if (dtos == null || !dtos.Any())
        {
            logger.LogWarning("Tentativa de sincronização sem dados");
            return BadRequest("Nenhum dado recebido para sincronização");
        }

        var result = await syncService.SyncUnidadesAsync(dtos);

        if (result.Success)
        {
            return Ok(new
            {
                Success = true,
                result.ReceivedCount,
                result.SqliteSavedCount,
                result.FirebirdSavedCount,
                Message = "Unidades sincronizadas com sucesso"
            });
        }

        return StatusCode(500, new
        {
            Success = false,
            Error = result.ErrorMessage,
            result.ReceivedCount,
            result.SqliteSavedCount,
            result.FirebirdSavedCount
        });
    }
}