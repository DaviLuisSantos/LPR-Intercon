using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LPR_Intercon.Shared.Models.Sqlite;

public class Visitante : BaseEntity
{
    [Key]
    public Guid Id { get; set; } = new Guid();
    public int? IdFirebird { get; set; }
    public string Nome { get; set; }
    public string? Celular { get; set; }
    public string? Cpf { get; set; }
    public byte[]? Foto { get; set; }
    public string? Documento { get; set; }
    public string? Empresa { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Placa { get; set; }
    public string? CarroCor { get; set; }
    public string? CarroMarca { get; set; }
    public string? Observacao { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }

    [ForeignKey("Morador")]
    public Guid? IdMorador { get; set; }
    public Morador Morador { get; set; }
    public StatusVisitante Status { get; set; }
    public enum StatusVisitante
    {
        Cliente,
        Servidor
    }
}
