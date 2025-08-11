using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSharedProject.Models.Firebird;

[Table("CAD_VISITA")]
public class Visitante
{
    [Key]
    [Column("IDVISITA")]
    public int Id { get; set; }

    [Column("NOME")]
    public string Nome { get; set; }

    [Column("DOCUMENTO")]
    public string? Documento { get; set; }

    [Column("EMPRESA")]
    public string? Empresa { get; set; }

    [Column("ENDERECO")]
    public string? Endereco { get; set; }

    [Column("TELEFONE")]
    public string? Telefone { get; set; }

    [Column("EMAIL")]
    public string? Email { get; set; }

    [Column("PLACA")]
    public string? Placa { get; set; }

    [Column("CARRO_COR")]
    public string? CarroCor { get; set; }

    [Column("CARRO_MARCA")]
    public string? CarroMarca { get; set; }

    [Column("FOTO1")]
    public string? Foto1 { get; set; }

    [Column("FOTO2")]
    public string? Foto2 { get; set; }

    [Column("FOTO3")]
    public string? Foto3 { get; set; }

    [Column("FOTO4")]
    public string? Foto4 { get; set; }

    [Column("OPERADOR_CAD")]
    public string OperadorCadastro { get; set; }

    [Column("PRIMEIRA_VISITA")]
    public DateTime? PrimeiraVisita { get; set; }

    [Column("ULTIMA_VISITA")]
    public DateTime? UltimaVisita { get; set; }

    [Column("CORCARROVISITA")]
    public string? CorCarroVisita { get; set; }

    [Column("OBS")]
    public string? Observacao { get; set; }

    [Column("ULTIMA_UNIDADE_VISITADA")]
    public string? UltimaUnidadeVisitada { get; set; }

    [Column("CELULAR")]
    public string? Celular { get; set; }

    [Column("CPF")]
    public string? Cpf { get; set; }

    [Column("DATA_CADASTRO")]
    public DateTime? DataCadastro { get; set; }

    [Column("TIPOVISITANTE")]
    public string TipoVisitante { get; set; }

    [Column("ULTIMO_ACESSO")]
    public DateTime? UltimoAcesso { get; set; }
}
