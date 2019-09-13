using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Viaticos
{
    public class VT_InformeActividad
    {
        public int Id_Informe { get; set; }
        public DateTime Fecha { get; set; }
        public string Actividad { get; set; }
        public int Cont { get; set; }
    }
}
