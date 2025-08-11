using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LPR_Intercon.Shared.Models.Sqlite;

public class Visita : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("Visitante")]
    public Guid VisitanteId { get; set; }
    public Visitante Visitante { get; set; }
    [ForeignKey("Morador")]
    public Guid MoradorId { get; set; }
    public Morador Morador { get; set; }
    public DateTime DataHoraVisita { get; set; }
}
