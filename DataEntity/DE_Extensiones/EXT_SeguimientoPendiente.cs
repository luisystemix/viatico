using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_SeguimientoPendiente
    {
        public int Id_Seguimiento_pendiente { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public string Nombre_Anterior { get; set; }
    }
}
