using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaMI.Models
{
    [Table("TB_GS_USUARIO")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string nmUsuario { get; set; }

        [Required]
        [StringLength(15)]
        public string nrRG { get; set; }

        [Required]
        [StringLength(15)]
        public string nrCpf { get; set; }

        [Required]
        [StringLength(50)]
        public string dsNacionalidade { get; set; }

        [Required]
        [StringLength(15)]
        public string nrTelefone { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime dtNascimento { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime dtCadastro { get; set; } = DateTime.Now;

        public ICollection<Login> Logins { get; set; }
        public ICollection<AmostraAgua> AmostrasAgua { get; set; }
        public ICollection<Relatorio> Relatorios { get; set; }
    }
}
