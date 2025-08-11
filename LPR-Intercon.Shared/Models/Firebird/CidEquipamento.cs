using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSharedProject.Models.Firebird;

[Table("CID_EQUIPAMENTOS")]
public class CidEquipamento
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }
    [Column("MODELO")]
    public string Modelo { get; set; }
    [Column("LOCAL")]
    public string Local { get; set; }
    [Column("IP")]
    public string Ip { get; set; }
    [Column("PORTA")]
    public int Porta { get; set; }
    [Column("USUARIO")]
    public string Usuario { get; set; }
    [Column("SENHA")]
    public string Senha { get; set; }
    [Column("SENTIDO")]
    public string Sentido { get; set; }
    [Column("VISITANTE")]
    public bool Visitante { get; set; }
}
