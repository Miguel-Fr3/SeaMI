using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaMI.Models
{
    [Table("TB_GS_LOGIN")]
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdLogin { get; set; }

        [Required]
        [StringLength(50)]
        public string dsEmail { get; set; }

        [Required]
        [StringLength(15)]
        public string dsSenha { get; set; }

        [ForeignKey("Usuario")]
        public int cdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
