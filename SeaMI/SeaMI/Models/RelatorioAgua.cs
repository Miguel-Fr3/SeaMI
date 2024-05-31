using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaMI.Models
{
    [Table("T_GS_RELATORIO_AGUA")]
    public class RelatorioAgua
    {
        public RelatorioAgua(){}

        public RelatorioAgua(int cdRelatorio, int cdUsuario, int cdAprovacao, DateTime dtRelatorio, string dsRelatorio)
        {
            this.cdRelatorio = cdRelatorio;
            this.cdUsuario = cdUsuario;
            this.cdAprovacao = cdAprovacao;
            this.dtRelatorio = dtRelatorio;
            this.dsRelatorio = dsRelatorio;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdRelatorio { get; set; }

        [ForeignKey("Usuario")]
        public int cdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("AprovacaoRelatorio")]
        public int cdAprovacao { get; set; }
        public AprovacaoRelatorio AprovacaoRelatorio { get; set; }


        [Required]
        [Column(TypeName = "DATE")]
        public DateTime dtRelatorio { get; set; }

        [Required]
        [StringLength(500)]
        public string dsRelatorio { get; set; }
    }
}
