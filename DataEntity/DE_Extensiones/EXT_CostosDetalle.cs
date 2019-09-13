using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_CostosDetalle
    {
        public int Id_Costos { get; set; }
        public int Etapa_Cultivo { get; set; }
        public int Insumo { get; set; }
        public int Tipo_Recurso { get; set; }
        public string Producto { get; set; }
        public string Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public int Num_Apli { get; set; }
        public decimal Precio_Unidad { get; set; }
        public string Tipo_Adquicicion { get; set; }
        public decimal Costo_Total_Bs { get; set; }
        public decimal Costo_Total_Sus { get; set; }
    }
}
