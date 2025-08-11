using System.ComponentModel.DataAnnotations.Schema;

namespace LPR_Intercon.Shared.Models.Firebird
{
    [Table("UNIDADE")]
    public class Unidade
    {

        [Column("IDUNIDADE")]
        public int Id { get; set; }

        [Column("NUMVAGAS")]
        public int? NumVagas { get; set; }

        [Column("DATAHORACADASTRO")]
        public DateTime? DataHoraCadastro { get; set; }
        [Column("UNIDADE")]
        public string Nome { get; set; }

        [Column("ANDAR_QUADRA")]
        public int? AndarQuadra { get; set; }

        [Column("APTO_LOTE")]
        public int? AptoLote { get; set; }

        [Column("BLOCO")]
        public string? Bloco { get; set; }

        /*
        [Column("VAGAS_OCUPADAS")]
        public string? VagasOcupadas { get; set; }
        */
    }
}