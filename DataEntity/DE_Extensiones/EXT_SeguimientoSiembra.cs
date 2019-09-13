using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_SeguimientoSiembra
    {
        public int Id_Seguimiento_Parcela { get; set; }
        public DateTime Fecha_SiembraINI { get; set; }
        public DateTime Fecha_SiembraFIN { get; set; }
        public string Sistema_Siembra { get; set; }
        public string Cultivo_Anterior { get; set; }
        public string Variedad_Semilla { get; set; }
        public int Avance_Siembra { get; set; }
    }
}
