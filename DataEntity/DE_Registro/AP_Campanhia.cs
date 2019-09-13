using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_Campanhia
    {
        public int Id_Campanhia { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Final { get; set; }
        public string Region { get; set; }
        public string Estado { get; set; }
    }
}
