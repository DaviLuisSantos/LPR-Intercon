using System.ComponentModel.DataAnnotations;
using LPR_Intercon.Shared;
using MemoryPack;

namespace LPR_Intercon.Shared.Models.Sqlite;

[MemoryPackable]
public partial class Condominio : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Cnpj { get; set; }
    [Required]
    [StringLength(15)]
    public string Ip { get; set; }
    public string? Telefone { get; set; }
    public string Cep { get; set; }
    public string Endereco { get; set; }
    public string Numero { get; set; }
    public string Uf { get; set; }

    [MemoryPackConstructor]
    public Condominio() { }

}
