using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_SeguimientoCosecha
    {
        public int Id_Seguimiento_Parcela { get; set; }
        public decimal Rendimiento { get; set; }
        public decimal Sup_Sembrada { get; set; }
        public decimal Peso_Aproximado { get; set; }
        public DateTime Fecha_Siembra { get; set; }
        public string Placa_Camion { get; set; }
        public string Nom_Chofer { get; set; }
        public string Centro_Acopio { get; set; }
        public string Region { get; set; }
    }
}
