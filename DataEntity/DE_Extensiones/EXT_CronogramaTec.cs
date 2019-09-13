using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_CronogramaTec
    {
        public int Id_Cronograma_Tec { get; set; }
        public int Id_Campanhia { get; set; }
        public int Id_Regional { get; set; }
        public string Id_Usuario { get; set; }
        public string Programa { get; set; }
        public DateTime Fecha_Envio { get; set; }
        public string Estado { get; set; }
    }
}
