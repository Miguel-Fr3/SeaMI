using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaMI.Models
{
    [Table("T_GS_LOGIN")]
    public class Login
    {

        public Login() { }

        public Login(int cdLogin, string dsEmail, string dsSenha, int fgAtivo)
        { 
            this.cdLogin = cdLogin;
            this.dsEmail = dsEmail;
            this.dsSenha = dsSenha;
            this.fgAtivo = fgAtivo;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdLogin { get; set; }
        [Required]
        [StringLength(50)]
        public string dsEmail { get; set;}
        [Required]
        [StringLength(50)]
        public string dsSenha{ get; set;}
        [Required]
        public int fgAtivo { get; set;}
    }
}
