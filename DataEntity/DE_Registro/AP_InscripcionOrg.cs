using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_InscripcionOrg
    {
        public int Id_InscripcionOrg { get; set; }
        public int Id_Organizacion { get; set; }
        public int Id_Campanhia { get; set; }
        public int Id_Regional { get; set; }
        public string Programa { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public string Tipo_Produccion { get; set; }
        public string Estado { get; set; }
    }
}
