using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaMI.Models
{
    [Table("TB_GS_RELATORIO_AMOSTRA")]
    public class RelatorioAmostra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdRelatorioAmostra { get; set; }

        [StringLength(200)]
        public string dsRelatorioAmostra { get; set; }

        [ForeignKey("AmostraAgua")]
        public int cdAmostra { get; set; }
        public AmostraAgua AmostraAgua { get; set; }

        [ForeignKey("Relatorio")]
        public int cdRelatorio { get; set; }
        public Relatorio Relatorio { get; set; }
    }
}
