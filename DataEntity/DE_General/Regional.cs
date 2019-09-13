using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_General
{
    public class Regional
    {
        public int Id_Regional { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string Ci_Responsable { get; set; }
        public string Direccion { get; set; }
        public string Telef_Fijo { get; set; }
        public string Telef_Movil { get; set; }
        public string Region { get; set; }
        public string Estado { get; set; }
        public int IdRegional_Padre { get; set; }
    }
}
