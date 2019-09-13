using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_SeguimientoParcela
    {
        public int Id_Seguimiento_Parcela { get; set; }
        public int Id_Seguimiento { get; set; }
        public int Boleta_Numero { get; set; }
        public DateTime Fecha_Seg { get; set; }
        public string Hora_Seg { get; set; }
        public DateTime Fecha_Sis { get; set; }
        public string Observacion { get; set; }
        public string Recomendacion { get; set; }
    }
}
