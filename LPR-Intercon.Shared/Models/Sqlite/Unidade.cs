using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MemoryPack;

namespace LPR_Intercon.Shared.Models.Sqlite;

[MemoryPackable]
public partial class Unidade : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("Condominio")]
    public Guid CondominioId { get; set; }
    public Condominio Condominio { get; set; }
    public string Nome { get; set; }
    public int Vagas { get; set; }
    public int IdFirebird { get; set; }
    public StatusUnidade Status { get; set; }

    [MemoryPackConstructor]
    public Unidade() { }
    public enum StatusUnidade
    {
        Cliente,
        Servidor
    }
}
