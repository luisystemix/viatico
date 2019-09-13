using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_SeguimientoCoordenadas
    {
        public int Id_Seguimiento_Parcela { get; set; }
        public string CoordenadaX { get; set; }
        public string CoordenadaY { get; set; }
        public int Num_Parcela { get; set; }
        public string Id_Productor { get; set; }
        public int Num_Punto { get; set; }
    }
}
