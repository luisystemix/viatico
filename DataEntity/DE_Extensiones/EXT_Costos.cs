using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_Costos
    {
        public int Id_Costos { get; set; }
        public string Tipo_Siembra { get; set; }
        public decimal Superficie { get; set; }
        public int Id_InscripcionOrg { get; set; }
        public string Id_Productor { get; set; }
        public int Id_Seguimiento { get; set; }
    }
}
