using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Viaticos
{
    [Serializable]
    public class VT_Feriados
    {
        public int Id_Feriado {get; set;}
        public int Id_Regional { get; set; }
        public DateTime Fecha_Feriado { get; set; }
        public string Descripcion { get; set; }
        public bool Feriado_Nacional { get; set; }
        public bool Feriado_Departamental { get; set; }
        public bool Estado { get; set; }
    }
}
