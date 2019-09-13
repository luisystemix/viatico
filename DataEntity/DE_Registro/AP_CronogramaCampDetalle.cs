using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_CronogramaCampDetalle
    {
        public int Id_Cronograma { get; set; }
        public int Id_Actividad { get; set; }
        public int Numero { get; set; }
        public DateTime Inicio_Planificado { get; set; }
        public DateTime Final_Planificado { get; set; }
        public DateTime Inicio_Ejecutado { get; set; }
        public DateTime Final_Ejecutado { get; set; }
        public string Observacion { get; set; }
    }
}
