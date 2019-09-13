using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Insumos
{
    public class INS_DistribucionDetalle
    {
        public int Id_Distribucion { get; set; }
        public int Num_Bol_Cartera { get; set; }
        public string Id_Productor { get; set; }
        public string Id_Persona { get; set; }
        public int Id_Tipo_Insumo { get; set; }
        public string Nombre_Insumo { get; set; }
        public string Unidad { get; set; }
        public decimal CantidadDosis { get; set; }
        public decimal Precio { get; set; }
    }
}
