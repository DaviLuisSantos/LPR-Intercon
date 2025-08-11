using LPR_Intercon.Server.Data;
using Microsoft.EntityFrameworkCore;
namespace LPR_Intercon.Server.Services;

public class Unidade(FirebirdDbContext context)
{
    public async Task<bool> MigrarUnidades()
    {
        var unidades = await context.Unidade.ToListAsync();
        return true;
    }
}
