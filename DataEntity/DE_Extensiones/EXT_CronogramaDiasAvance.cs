using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    [Serializable]
    public class EXT_CronogramaDiasAvance
    {
        public int Id_CronogramaAvance { get; set; }
        public int Id_Cronograma { get; set; }
        public string FechaDia { get; set; }
        public string TareaDia { get; set; }
        public decimal PorcentajeAvance { get; set; }
        public string ObservacionAvance { get; set; }
        public string Dia { get; set; }
        public string FuenteVerificacion { get; set; }
        public string Observaciones { get; set; }
        //public string FechaMartes { get; set; }
        //public string Martes { get; set; }
        //public decimal Porcentaje_Martes { get; set; }
        //public string Observacion_Martes { get; set; }
        //public string FechaMiercoles { get; set; }
        //public string Miercoles { get; set; }
        //public decimal Porcentaje_Miercoles { get; set; }
        //public string Observacion_Miercoles { get; set; }
        //public string FechaJueves { get; set; }
        //public string Jueves { get; set; }
        //public decimal Porcentaje_Jueves { get; set; }
        //public string Observacion_Jueves { get; set; }
        //public string FechaViernes { get; set; }
        //public string Viernes { get; set; }
        //public decimal Porcentaje_Viernes { get; set; }
        //public string Observacion_Viernes { get; set; }
        //public string FechaSabado { get; set; }
        //public string Sabado { get; set; }
        //public decimal Porcentaje_Sabado { get; set; }
        //public string Observacion_Sabado { get; set; }
        //public string FechaDomingo { get; set; }
        //public string Domingo { get; set; }
        //public decimal Porcentaje_Domingo { get; set; }
        //public string Observacion_Domingo { get; set; }
    }
}
