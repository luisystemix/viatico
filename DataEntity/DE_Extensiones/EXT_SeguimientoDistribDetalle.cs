using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_SeguimientoDistribDetalle
    {
        public int Id_Seg_Distribucion { get; set; }
        public int Num_Boleta { get; set; }
        public string Valor1 { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }
        public DateTime Fecha_Caducidad { get; set; }
        public string Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public int Valor4 { get; set; }
    }
}
