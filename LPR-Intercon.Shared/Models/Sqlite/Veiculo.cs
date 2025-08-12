using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LPR_Intercon.Shared.Models.Sqlite;

public class Veiculo
{
    [Key]
    public Guid Id { get; set; }
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }
    [ForeignKey("Unidade")]
    public Guid UnidadeId { get; set; }
    public Unidade Unidade { get; set; }
    public int FirebirdId { get; set; }
    public bool Sincronizado { get; set; }
}
