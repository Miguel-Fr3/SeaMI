using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeaMI.Models
{
    [Table("T_GS_MONITORAMENTO_AGUA")]
    public class MonitoramentoAgua
    {
        public MonitoramentoAgua() { }
        public MonitoramentoAgua(int cdMonitoramentoAgua, int cdSensor, int cdAmostra, string dsMonitoramento)
        {
            this.cdMonitoramentoAgua = cdMonitoramentoAgua;
            this.cdSensor = cdSensor;
            this.cdAmostra = cdAmostra;
            this.dsMonitoramento = dsMonitoramento;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdMonitoramentoAgua { get; set; }

        [ForeignKey("Sensores")]
        public int cdSensor { get; set; }
        public Sensores Sensores { get; set; }

        [ForeignKey("AmostraAgua")]
        public int cdAmostra { get; set; }
        public AmostraAgua AmostraAgua { get; set; }

        [Required]
        [StringLength(250)]
        public string dsMonitoramento { get; set; }


    }
}
