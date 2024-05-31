using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaMI.Models
{
    [Table("T_GS_AMOSTRA_USUARIO")]
    public class AmostraUsuario
    {
        public AmostraUsuario() {}
        public AmostraUsuario(int cdAmostraUser, int cdUsuario, int cdAmostra, string dsAmostra, DateTime dtAmostra)
        {
            this.cdAmostraUser = cdAmostraUser;
            this.cdUsuario = cdUsuario;
            this.cdAmostra = cdAmostra;
            this.dsAmostra = dsAmostra;
            this.dtAmostra = dtAmostra;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdAmostraUser { get; set; }

        [ForeignKey("Usuario")]
        public int cdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("AmostraAgua")]
        public int cdAmostra { get; set; }
        public AmostraAgua AmostraAgua { get; set; }

        [Required]
        [StringLength(250)]
        public string dsAmostra { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime dtAmostra { get; set; }

    }
}
