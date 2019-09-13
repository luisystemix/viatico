using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Viaticos
{
    public class VT_PlanillaDia
    {
        public int Id_Planilla { get; set; }
        public int Cont { get; set; }
        public decimal Num_Dias { get; set; }
        public string Area { get; set; }
        public string Destino { get; set; }
        public decimal Monto { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaDia { get; set; }
    }
}
