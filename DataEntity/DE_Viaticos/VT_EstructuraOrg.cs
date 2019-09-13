using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Viaticos
{
    public class VT_EstructuraOrg
    {
        public int Id_Estructura { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public string CI_Responsable { get; set; }
        public string Estado { get; set; }
    }
}
