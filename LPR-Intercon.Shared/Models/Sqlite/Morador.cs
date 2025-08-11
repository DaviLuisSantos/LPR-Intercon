using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MemoryPack;

namespace LPR_Intercon.Shared.Models.Sqlite;

[MemoryPackable]
public partial class Morador : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Nome { get; set; }
    public byte[] Foto { get; set; }
    [ForeignKey("Unidade")]
    public Guid UnidadeId { get; set; }
    public Unidade Unidade { get; set; }
    public int IdFirebird { get; set; }
    public string? Email { get; set; }
    public string? Cpf { get; set; }
    public string? Celular { get; set; }
    public bool Admin { get; set; }
    public StatusMorador Status { get; set; }
    public bool Arquivamento { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    [MemoryPackIgnore]
    public User User { get; set; }

    [MemoryPackConstructor]
    public Morador() { }


    public enum StatusMorador
    {
        Cliente,
        Servidor,
        Novo
    }
}