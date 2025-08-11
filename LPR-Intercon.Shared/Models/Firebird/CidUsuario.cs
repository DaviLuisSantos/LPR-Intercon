using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LPR_Intercon.Shared.Models.Firebird;

[Table("CID_USUARIOS")]
public class CidUsuario
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }
    [ForeignKey("Morador")]
    [Column("ID_USUARIO")]
    public int? IdUsuario { get; set; }
    public Morador Morador { get; set; }
    [Column("TIPO_CAD")]
    public string? TipoCadastro { get; set; }
    [Column("DATA_CAD")]
    public DateTime? DataCadastro { get; set; }
    [Column("CARTAO")]
    public string? Cartao { get; set; }
    [Column("CARTAO_HEXA")]
    public string? CartaoHexa { get; set; }
    [Column("ENVIADO_STATUS")]
    public string? EnviadoStatus { get; set; }
    [Column("ENVIADO_DATA")]
    public DateTime? EnviadoData { get; set; }
    [Column("CADASTRADO_POR")]
    public string? CadastradoPor { get; set; }

    public CidUsuario() { }

    public CidUsuario(Morador morador)
    {
        TipoCadastro = "FACIAL";
        IdUsuario = morador.Id;
        DataCadastro = DateTime.Now;
        CadastradoPor = "MORADOR";
    }
}
