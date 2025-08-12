using LPR_Intercon.Shared.DTOs;
using LPR_Intercon.Shared.Models.Sqlite;
using System.Reflection;

namespace LPR_Intercon.Client.Extensions;

public static class FirebirdExtensions
{
    public static Condominio ToSqliteModel(this Shared.Models.Firebird.Condominio fb)
    {
        return new Condominio
        {
            Id = Guid.NewGuid(),
            Nome = fb.Nome,
            Cnpj = fb.Cnpj,
            Ip = "0.0.0.0", // Valor padrão ou lógica específica
            Telefone = fb.Telefone,
            Cep = fb.Cep,
            Endereco = fb.Endereco,
            Numero = fb.End_num,
            Uf = fb.End_uf,
            // Mapear campos adicionais conforme necessário
        };
    }

    public static CondominioSyncDto ToSyncDto(this Condominio sqlite)
    {
        return new CondominioSyncDto
        {
            Id = sqlite.Id.ToString(),
            Nome = sqlite.Nome,
            Cnpj = sqlite.Cnpj,
            Ip = sqlite.Ip,
            Telefone = sqlite.Telefone,
            Cep = sqlite.Cep,
            Endereco = sqlite.Endereco,
            Numero = sqlite.Numero,
            Uf = sqlite.Uf,
            // Campos adicionais do Firebird
            Fantasia = "", // Não disponível no SQLite
            Email = "",    // Não disponível no SQLite
            DataCadastro = DateTime.UtcNow
        };
    }
}