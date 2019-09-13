using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_Organizacion
    {
        public int Id_Organizacion { get; set; }
        public string Personeria_Juridica { get; set; }
        public string Sigla { get; set; }
        public string Departamento { get; set; }
        public string Resolucion_Prefect { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Tipo { get; set; }
        public string DomicilioOrg { get; set; }
    }
}
