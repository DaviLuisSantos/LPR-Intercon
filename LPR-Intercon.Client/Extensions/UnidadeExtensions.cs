using LPR_Intercon.Shared.Models.Sqlite;

namespace LPR_Intercon.Client.Extensions;

public static class UnidadeExtensions
{
    public static Unidade ToSqliteModel(this Shared.Models.Firebird.Unidade fb, Guid condominioId)
    {
        return new Unidade
        {
            Id = Guid.NewGuid(),
            CondominioId = condominioId,
            Nome = fb.Nome,
            Vagas = fb.NumVagas ?? 0, // Tratar nulos
            IdFirebird = fb.Id
        };
    }
}
