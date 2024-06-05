using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaMI.Models
{
    [Table("TB_GS_RELATORIO")]
    public class Relatorio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdRelatorio { get; set; }

        [Required]
        [StringLength(100)]
        public string nmRelatorio { get; set; }

        [StringLength(200)]
        public string dsRelatorio { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime dtRelatorio { get; set; }

        [ForeignKey("Usuario")]
        public int cdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<RelatorioAmostra> RelatoriosAmostra { get; set; }
    }
}
