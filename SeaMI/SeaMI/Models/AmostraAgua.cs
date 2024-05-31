using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeaMI.Models
{
    [Table("T_GS_AMOSTRA_AGUA")]
    public class AmostraAgua
    {
        public AmostraAgua() { }

        public AmostraAgua(int cdAmostra, DateTime dtColeta, string dsPH, string dsPoluentesQuimicos, string dsNutrientes,
            string dsConcentracaoPlastico, string dsOxigenioDissolvido, string dsTemperatura, string dsTurbidez)
        {
            this.cdAmostra = cdAmostra;
            this.dtColeta = dtColeta;
            this.dsPH = dsPH;
            this.dsPoluentesQuimicos = dsPoluentesQuimicos;
            this.dsNutrientes = dsNutrientes;
            this.dsConcentracaoPlastico = dsConcentracaoPlastico;
            this.dsOxigenioDissolvido = dsOxigenioDissolvido;
            this.dsTemperatura = dsTemperatura;
            this.dsTurbidez = dsTurbidez;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdAmostra { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime dtColeta { get; set; }

        [Required]
        [StringLength(15)]
        public string dsPH { get; set; }

        [Required]
        [StringLength(15)]
        public string dsPoluentesQuimicos { get; set; }

        [Required]
        [StringLength(15)]
        public string dsNutrientes { get; set; }

        [Required]
        [StringLength(15)]
        public string dsConcentracaoPlastico { get; set; }

        [Required]
        [StringLength(15)]
        public string dsOxigenioDissolvido { get; set; }

        [Required]
        [StringLength(15)]
        public string dsTemperatura { get; set; }

        [Required]
        [StringLength(15)]
        public string dsTurbidez { get; set; }




    }
}
