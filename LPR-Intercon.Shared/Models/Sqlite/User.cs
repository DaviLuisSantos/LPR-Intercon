using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MemoryPack;

namespace LPR_Intercon.Shared.Models.Sqlite;

[MemoryPackable]
public partial class User : BaseEntity
{

    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public Guid MoradorId { get; set; }
    public Morador Morador { get; set; }

    [MemoryPackConstructor]
    public User() { }

}