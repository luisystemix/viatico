using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_ParametrosCamp
    {
        public int Id_Campanhia { get; set; }
        public string Tipo_Produccion { get; set; }
        public decimal Has_Min { get; set; }
        public decimal Has_Max { get; set; }
        public string Programa { get; set; }
        public string Estado { get; set; }
    }
}
