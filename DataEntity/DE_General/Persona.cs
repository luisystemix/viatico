using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_General
{
    public class Persona
    {
        public string Id_Persona { get; set; }
        public string ci { get; set; }
        public string ext { get; set; }
        public string Nombres { get; set; }
        public string Primer_ap { get; set; }
        public string Segundo_ap { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public Boolean Sexo { get; set; }
        public string Telef_fijo { get; set; }
        public string Telef_cel { get; set; }
        public DateTime Fecha_registro { get; set; }
        public string Estado { get; set; }
    }
}
