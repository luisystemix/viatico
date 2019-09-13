using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_CronogramaCamp
    {
        public int Id_Cronograma { get; set; }
        public int Id_Campanhia { get; set; }
        public int Id_Regional { get; set; }
        public string Programa { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
