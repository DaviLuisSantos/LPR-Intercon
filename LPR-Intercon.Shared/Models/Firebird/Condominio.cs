using MemoryPack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LPR_Intercon.Shared.Models.Firebird;

[MemoryPackable]
[Table("DADOS_CLIENTE")]
public partial class Condominio
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }
    [Column("NOME")]
    public string? Nome { get; set; }
    [Column("FANTASIA")]
    public string? Fantasia { get; set; }
    [Column("CNPJ")]
    public string? Cnpj { get; set; }
    [Column("ENDERECO")]
    public string? Endereco { get; set; }
    [Column("END_NUM")]
    public string? End_num { get; set; }
    [Column("END_COMPL")]
    public string? End_complemento { get; set; }
    [Column("END_BAIRRO")]
    public string? End_bairro { get; set; }
    [Column("END_MUNICIPIO")]
    public string? End_municipio { get; set; }
    [Column("END_UF")]
    public string? End_uf { get; set; }
    [Column("CEP")]
    public string? Cep { get; set; }
    [Column("EMAIL1")]
    public string? Email { get; set; }
    [Column("TEL1")]
    public string? Telefone { get; set; }
    [Column("DATA_CADASTRO")]
    public DateTime? Data_Cadastro { get; set; }
    [Column("OPERADOR_CADASTRO")]
    public string? Operador_cadastro { get; set; }
    [Column("DATA_ALTERACAO")]
    public DateTime? Data_alteracao { get; set; }
    [Column("OPERADOR_ALTERACAO")]
    public string? Operador_alteracao { get; set; }
}
