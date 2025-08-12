using System;
using System.Collections.Generic;
using System.Text;

namespace LPR_Intercon.Shared.DTOs;

public class UnidadeSyncDto
{
    public Guid Id { get; set; } // ID no SQLite do bloco
    public int IdFirebird { get; set; } // ID original no Firebird
    public Guid CondominioIdLocal { get; set; } // ID do condomínio no SQLite local
    public string Nome { get; set; }
    public int Vagas { get; set; }

    // Campos específicos do Firebird
    public int? AndarQuadra { get; set; }
    public int? AptoLote { get; set; }
    public string? Bloco { get; set; }
    public DateTime? DataHoraCadastro { get; set; }
}
