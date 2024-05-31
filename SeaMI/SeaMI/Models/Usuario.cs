using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeaMI.Models
{
    [Table("T_GS_USUARIO")]
    public class Usuario
    {

        public Usuario() { }

        public Usuario(int cdUsuario, int cdLogin, string nmUsuario, string nrDocumento, string nrTelefone, string dsArea, string dsNacionalidade, DateTime dtNascimento, DateTime dtCadastro)
        {
            this.cdUsuario = cdUsuario;
            this.nmUsuario = nmUsuario;
            this.nrDocumento = nrDocumento;
            this.nrTelefone = nrTelefone;
            this.dsArea = dsArea;
            this.dsNacionalidade = dsNacionalidade;
            this.dtNascimento = dtNascimento;
            this.dtCadastro = dtCadastro;
            this.cdLogin = cdLogin;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdUsuario { get; set; }

        [ForeignKey("Login")]
        public int cdLogin { get; set; }
        public Login Login { get; set; }

        [Required]
        [StringLength(100)]
        public string nmUsuario { get; set; }

        [Required]
        [StringLength(15)]
        public string nrDocumento { get; set; }

        [Required]
        [StringLength(14)]
        public string nrTelefone { get; set; }

        [Required]
        [StringLength(50)]
        public string dsArea { get; set; }

        [Required]
        [StringLength(50)]
        public string dsNacionalidade { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime dtNascimento { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime dtCadastro { get; set; } = DateTime.Now;
    }
}
