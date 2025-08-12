using LPR_Intercon.Shared.DTOs;
using LPR_Intercon.Shared.Models.Sqlite;

namespace LPR_Intercon.Server.Extensions;

public static class SyncDtoExtensions
{
    public static Condominio ToSqliteModel(this CondominioSyncDto dto)
    {
        return new Condominio
        {
            Id = Guid.Parse(dto.Id),
            Nome = dto.Nome,
            Cnpj = dto.Cnpj,
            Ip = dto.Ip,
            Telefone = dto.Telefone,
            Cep = dto.Cep,
            Endereco = dto.Endereco,
            Numero = dto.Numero,
            Uf = dto.Uf
        };
    }
}
