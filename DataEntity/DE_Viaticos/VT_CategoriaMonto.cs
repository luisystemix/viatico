using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Viaticos
{
    public class VT_CategoriaMonto
    {
        public int Id_Categoria { get; set; }
        public string Tipo { get; set; }
        public decimal Monto_Urbano { get; set; }
        public decimal Monto_Rural { get; set; }
        public string Moneda { get; set; }
    }
}
