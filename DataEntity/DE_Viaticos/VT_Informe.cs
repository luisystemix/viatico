using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Viaticos
{
    public class VT_Informe
    {
        public int Id_Informe { get; set; }
        public string Id_Solicitud { get; set; }
        public string Dirigido_A { get; set; }
        public DateTime Fecha_Informe { get; set; }
        public DateTime Fecha_Aprobacion { get; set; }
        public string Conclusion { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public string Objetivo { get; set; }
        public string Recomendacion { get; set; }
        
        

    }
}
