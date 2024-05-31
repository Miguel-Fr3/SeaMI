using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeaMI.Models
{
    [Table("T_GS_SENSORES")]
    public class Sensores
    {
        public Sensores(){}

        public Sensores(int cdSensor, int cdUsuario, string nmTecnologia, string dsSensor, DateTime dtImplementacao)
        {
            this.cdSensor = cdSensor;
            this.cdUsuario = cdUsuario;
            this.nmTecnologia = nmTecnologia;
            this.dsSensor = dsSensor;
            this.dtImplementacao = dtImplementacao;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdSensor { get; set; }

        [ForeignKey("Usuario")]
        public int cdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string nmTecnologia { get; set; }

        [Required]
        [StringLength(250)]
        public string dsSensor { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime dtImplementacao { get; set; }
    }
}
