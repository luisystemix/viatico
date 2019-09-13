using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_FaceFenologiaMaiz
    {
        public int Id_Face_Feonologica { get; set; }
        public string FechaAvnSiemIni { get; set; }
        public string FechaAvnSiemFin { get; set; }
        public decimal FechaAvnSiemAvan { get; set; }
        public decimal Emergencia5dias { get; set; }
        public decimal HojasDesplegadas1y2 { get; set; }
        public decimal HojasDesplegadas3y4 { get; set; }
        public decimal HojasDesplegadas5y6 { get; set; }
        public decimal HojasDesplegadas7y8 { get; set; }
        public decimal HojasDesplegadas9y10 { get; set; }
        public decimal HojasDesplegadas11oMas { get; set; }
        public decimal FloracionyPolinizacion { get; set; }
        public decimal EstigmasVisiblesyAmpolla { get; set; }
        public decimal GranoLechosoyMasoso { get; set; }
        public decimal EtapaDentadayMadurez { get; set; }
        public decimal CosechaAcopioAvan { get; set; }
        public decimal CosechaAcopioRend { get; set; }
        public string FechaCosechaIni { get; set; }
        public string FechaCosechaFin { get; set; }
        public string Tipo { get; set; }
        public decimal SupSem { get; set; }
    }
}
