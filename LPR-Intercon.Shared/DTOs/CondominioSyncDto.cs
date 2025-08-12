using System;
using System.Collections.Generic;
using System.Text;

namespace LPR_Intercon.Shared.DTOs;

public class CondominioSyncDto
{
    public string Id { get; set; } // ID do registro no bloco
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Ip { get; set; }
    public string Telefone { get; set; }
    public string Cep { get; set; }
    public string Endereco { get; set; }
    public string Numero { get; set; }
    public string Uf { get; set; }

    // Campos específicos do Firebird
    public string? Fantasia { get; set; }
    public string? Email { get; set; }
    public DateTime? DataCadastro { get; set; }
}
