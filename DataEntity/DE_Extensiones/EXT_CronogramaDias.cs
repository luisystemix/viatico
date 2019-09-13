using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    [Serializable]
    public class EXT_CronogramaDias
    {
        public int Id_Cronograma { get; set; }
        public string FechaLunes { get; set; }
        public string Lunes { get; set; }
        public string FechaMartes { get; set; }
        public string Martes { get; set; }
        public string FechaMiercoles { get; set; }
        public string Miercoles { get; set; }
        public string FechaJueves { get; set; }
        public string Jueves { get; set; }
        public string FechaViernes { get; set; }
        public string Viernes { get; set; }
        public string FechaSabado { get; set; }
        public string Sabado { get; set; }
        public string FechaDomingo { get; set; }
        public string Domingo { get; set; }
    }
}
