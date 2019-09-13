using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    [Serializable]
    public class EXT_DesignacionProd
    {
        public string Id_Usuario { get; set; }
        public string Id_Productor { get; set; }
        public string Etapa { get; set; }
        public Boolean Estado { get; set; }
    }
}
