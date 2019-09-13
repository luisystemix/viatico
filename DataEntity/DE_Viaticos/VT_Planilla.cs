using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Viaticos
{
    public class VT_Planilla
    {
        public int Id_Planilla { get; set; }
        public string Id_Solicitud { get; set; }
        public decimal Tot_Num_Dias { get; set; }
        public decimal Tot_Num_Dias15 { get; set; }
        public decimal Pago_Total { get; set; }
        public decimal Pago_Total15 { get; set; }
        public decimal Rc_Iva { get; set; }
        public decimal Liquido_Pagable { get; set; }
        public string Num_Cheque { get; set; }
        public decimal Tasa_Cambio { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Fecha_Atendido { get; set; }
        public decimal MontoPorDia { get; set; }

    }
}
