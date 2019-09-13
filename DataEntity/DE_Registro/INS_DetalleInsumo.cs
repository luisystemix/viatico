using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class INS_DetalleInsumo
    {
        public int Id_Contrato_Insumo { get; set; }
        public int Id_Tipo_Insumo { get; set; }
        public string Nombre_Insumo { get; set; }
        public string Caracteristica { get; set; }
        public string Unidad { get; set; }
        public decimal CantidadDosis { get; set; }
        public int Num_apli { get; set; }
        public decimal Precio { get; set; }
    }
}
