using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSharedProject.Models.Firebird;

[Table("VISITANTES")]
public class Visita
{
    [Key]
    [Column("IDVISITA")]
    public int Id { get; set; }

    [Column("ID_CAD_VISITA")]
    public int? IdCadVisita { get; set; }

    [Column("UNIDADEDESTINO")]
    public string UnidadeDestino { get; set; }

    [Column("CARTAOVISITA")]
    public string CartaoVisita { get; set; }

    [Column("PLACAVISITANTE")]
    public string PlacaVisitante { get; set; }

    [Column("MARCACARROVISITA")]
    public string MarcaCarroVisita { get; set; }

    [Column("MODELOCARROVISITA")]
    public string ModeloCarroVisita { get; set; }

    [Column("CORCARROVISITA")]
    public string CorCarroVisita { get; set; }

    [Column("TIPOVISITANTE")]
    public string TipoVisitante { get; set; }

    [Column("FOTO1")]
    public string Foto1 { get; set; }

    [Column("FOTO2")]
    public string Foto2 { get; set; }

    [Column("FOTO3")]
    public string Foto3 { get; set; }

    [Column("FOTO4")]
    public string Foto4 { get; set; }

    [Column("FOTO_SAIDA_1")]
    public string FotoSaida1 { get; set; }

    [Column("FOTO_SAIDA_2")]
    public string FotoSaida2 { get; set; }

    [Column("FOTO_SAIDA_3")]
    public string FotoSaida3 { get; set; }

    [Column("FOTO_SAIDA_4")]
    public string FotoSaida4 { get; set; }

    [Column("ACOMPANHANTES")]
    public int? Acompanhantes { get; set; }

    [Column("PORTEIROENTRADA")]
    public string PorteiroEntrada { get; set; }

    [Column("PORTEIROPRORROGOU")]
    public string PorteiroProrrogou { get; set; }

    [Column("PORTEIROSAIDA")]
    public string PorteiroSaida { get; set; }

    [Column("NOMEVISITANTE")]
    public string NomeVisitante { get; set; }

    [Column("DOCUMENTOVISITA")]
    public string DocumentoVisita { get; set; }

    [Column("EMPRESAVISITANTE")]
    public string EmpresaVisitante { get; set; }

    [Column("DATAHORAPREVISAOSAIDA")]
    public DateTime? DataHoraPrevisaoSaida { get; set; }

    [Column("DATAHORASAIDA")]
    public DateTime? DataHoraSaida { get; set; }

    [Column("DATAHORAENTRADA")]
    public DateTime? DataHoraEntrada { get; set; }

    [Column("TEMPOPERMANENCIA")]
    public int? TempoPermanencia { get; set; }

    [Column("TEMPO_PRORROGACAO")]
    public int? TempoProrrogacao { get; set; }

    [Column("AUTORIZADOPOR")]
    public string AutorizadoPor { get; set; }

    [Column("NOME_ACOMP1")]
    public string NomeAcomp1 { get; set; }

    [Column("NOME_ACOMP2")]
    public string NomeAcomp2 { get; set; }

    [Column("NOME_ACOMP3")]
    public string NomeAcomp3 { get; set; }

    [Column("NOME_ACOMP4")]
    public string NomeAcomp4 { get; set; }

    [Column("NOME_ACOMP5")]
    public string NomeAcomp5 { get; set; }

    [Column("DOC_ACOMP1")]
    public string DocAcomp1 { get; set; }

    [Column("DOC_ACOMP2")]
    public string DocAcomp2 { get; set; }

    [Column("DOC_ACOMP3")]
    public string DocAcomp3 { get; set; }

    [Column("DOC_ACOMP4")]
    public string DocAcomp4 { get; set; }

    [Column("DOC_ACOMP5")]
    public string DocAcomp5 { get; set; }

    [Column("OBS")]
    public string Observacao { get; set; }

    [Column("AGENDADO_POR")]
    public string AgendadoPor { get; set; }

    [Column("DATA_CAD_AGENDAMENTO")]
    public DateTime? DataCadastroAgendamento { get; set; }

    [Column("DATA_VISITA_AGENDADA")]
    public DateTime? DataVisitaAgendada { get; set; }

    [Column("ANUNCIO_VISITA_AGENDADA")]
    public string AnuncioVisitaAgendada { get; set; }

    [Column("HORA_VISITA_AGENDADA")]
    public TimeSpan? HoraVisitaAgendada { get; set; }

    [Column("TELEFONE")]
    public string Telefone { get; set; }

    [Column("EMAIL")]
    public string Email { get; set; }

    [Column("ENDERECO")]
    public string Endereco { get; set; }

    [Column("ID_FIXO")]
    public int? IdFixo { get; set; }

    [Column("VAGA_OCUPADA")]
    public string VagaOcupada { get; set; }

    [Column("FLAG_CID")]
    public int? FlagCid { get; set; }

    [Column("IDVISITA_ANTIGO")]
    public int? IdVisitaAntigo { get; set; }

    [Column("DENTRO_FORA")]
    public string DentroFora { get; set; }

    [Column("CPF")]
    public string Cpf { get; set; }

    [Column("MT_ITEM_ID")]
    public string MtItemId { get; set; }

    [Column("MT_ENVIADO_STATUS")]
    public string MtEnviadoStatus { get; set; }

    [Column("MT_DESC_ERRO")]
    public string MtDescErro { get; set; }

    [Column("MT_GRUPO_NOME")]
    public string MtGrupoNome { get; set; }

    [Column("MT_GRUPO_ID")]
    public string MtGrupoId { get; set; }

    [Column("DATA_HORA_ACESSO_ENTRADA")]
    public DateTime? DataHoraAcessoEntrada { get; set; }

    [Column("PRISMA")]
    public string Prisma { get; set; }
}
