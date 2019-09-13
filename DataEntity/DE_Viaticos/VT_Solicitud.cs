using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Viaticos
{
    public class VT_Solicitud
    {
        public string Id_Solicitud { get; set; }
        public int Id_Regional { get; set; }
        public string Id_Usuario { get; set; }
        public string Tipo_Salida { get; set; }
        public string Tipo_Solicitud { get; set; }
        public string Dep_Salida { get; set; }
        public string Cargo { get; set; }
        public string ci_Aprobador { get; set; }
        public string Cargo_Aprobador { get; set; }
        public DateTime Fecha_Solicitud { get; set; }
        public DateTime Fecha_Aprob { get; set; }
        public string Motivo_Viaje { get; set; }
        public string Descrip_Motivo { get; set; }
        public string Tipo_Viaje { get; set; }
        public string Estado { get; set; }
    }
}
