using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_Rendimiento
    {
        public int Id_Rendimiento { get; set; }
        public int Id_Seguimiento { get; set; }
        public DateTime Fecha_Sis { get; set; }
        public DateTime Fech_Inspeccion { get; set; }
        public string Variedad_Semilla { get; set; }
    }
}
