using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaMI.Models
{
    [Table("TB_GS_AMOSTRA_AGUA")]
    public class AmostraAgua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdAmostra { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime dtColeta { get; set; }

        [StringLength(10)]
        public string dsPH { get; set; }

        [StringLength(15)]
        public string dsPoluentesQuimicos { get; set; }

        [StringLength(15)]
        public string dsNutrientes { get; set; }

        [StringLength(15)]
        public string dsConcentracaoPlastico { get; set; }

        [StringLength(15)]
        public string dsOxigenioDissolvido { get; set; }

        [StringLength(15)]
        public string dsTemperatura { get; set; }

        [StringLength(15)]
        public string dsTurbidez { get; set; }

        [ForeignKey("Usuario")]
        public int cdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<RelatorioAmostra> RelatoriosAmostra { get; set; }
    }
}
