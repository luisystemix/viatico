using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_FechaSegCost
    {
        public int Id_Seguimiento { get; set; }
        public int Id_Costos { get; set; }
        public DateTime Fecha_Seguimiento { get; set; }
    }
}
