using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeaMI.Models
{
    [Table("T_GS_APROVACAO_RELATORIO")]
    public class AprovacaoRelatorio
    {
        public AprovacaoRelatorio(){}
        public AprovacaoRelatorio(int cdAprovacao, int cdUsuario, int fgAprovado, string dsComentario, DateTime dtAprovacao) {
            this.cdAprovacao = cdAprovacao;
            this.cdUsuario = cdUsuario;
            this.fgAprovado = fgAprovado;
            this.dsComentario = dsComentario;
            this.dtAprovacao = dtAprovacao;
        
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdAprovacao { get; set; }

        [ForeignKey("Usuario")]
        public int cdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public int fgAprovado { get; set; }

        [Required]
        [StringLength(250)]
        public string dsComentario { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime dtAprovacao { get; set; }
    }
}
