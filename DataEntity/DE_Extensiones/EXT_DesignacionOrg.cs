using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_DesignacionOrg
    {
        public string Id_Usuario { get; set; }
        public int Id_InscripcionOrg { get; set; }
        public Decimal Superficie { get; set; }
        public int Num_Productores { get; set; }
        public string Estado { get; set; }
    }
}
