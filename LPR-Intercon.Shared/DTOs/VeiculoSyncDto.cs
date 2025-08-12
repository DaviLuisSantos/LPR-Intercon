using System;
using System.Collections.Generic;
using System.Text;

namespace LPR_Intercon.Shared.DTOs;

public class VeiculoSyncDto
{
    // ID no SQLite (GUID)
    public Guid Id { get; set; }

    // ID no Firebird (int)
    public int FirebirdId { get; set; }

    // Informações do veículo
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }

    // Unidade
    public Guid UnidadeId { get; set; } // Relacionamento com SQLite
    public string UnidadeCodigoFirebird { get; set; } // Relacionamento com Firebird (campo "UNIDADE")

    // Status
    public bool VeiculoDentro { get; set; }
    public bool Sincronizado { get; set; }

    // Informações de último acesso
    public string IpCamUltAcesso { get; set; }
    public DateTime? DataHoraUltAcesso { get; set; }

    // Rota
    public int? IdRota { get; set; }
}

