using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    [Serializable]
    public class EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica
    {
        public int Id_Seguimiento_Cultivo_Fase { get; set; }
        public DateTime Reporte_Fecha_Inicio { get; set; }
        public DateTime Reporte_Fecha_Fin { get; set; }
        public string Campania { get; set; }
        public int Id_Regional { get; set; }
        public string Zona { get; set; }
        public string Organizacion { get; set; }
        public decimal Ppsemanal { get; set; }
        public DateTime FechaSiembraInicio { get; set; }
        public DateTime FechaSiembraFinal { get; set; }
        public decimal AvanceSiembra { get; set; }
        public decimal Germinacion { get; set; }
        public decimal Plantula { get; set; }
        public decimal Macollamiento { get; set; }
        public decimal Embuche { get; set; }
        public decimal Espigazon { get; set; }
        public decimal Floracion { get; set; }
        public decimal Grano { get; set; }
        public decimal Maduracion { get; set; }
        public decimal AvanceCosecha { get; set; }
        public decimal Rend { get; set; }
        public DateTime FechaCosechaInicial { get; set; }
        public DateTime FechaCosechaFinal { get; set; }
        public string Observaciones { get; set; }
        public decimal PromedioAvanceSiembra { get; set; }
        public decimal PromedioAvanceCosecha { get; set; }
        public decimal PromedioRend { get; set; }
        public string Elaboradopor { get; set; }
        public string VoBo { get; set; }
        public string Id_Usuario { get; set; }
        public string Programa { get; set; }

       
    }
}
