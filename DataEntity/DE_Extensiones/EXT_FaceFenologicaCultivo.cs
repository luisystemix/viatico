using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_FaceFenologicaCultivo
    {
        public int Id_Face_Feonologica { get; set; }
        public int Id_Campanhia { get; set; }
        public int Id_Regional { get; set; }
        public int Id_InscripcionOrg { get; set; }
        public string Id_Usuario { get; set; }
        public string Programa { get; set; } 
        public DateTime Fecha_Registro { get; set; }
        public int Num_Boletas_Inspec { get; set; }
        public string Charla_Tecnica { get; set; }
        public int Num_Prod_Vigentes { get; set; }
        public decimal Sup_Actual { get; set; }
        public string Variedad_Semilla { get; set; }
        public string Observacion { get; set; }
        public int Num_Seg_Cultivo { get; set; }
        public int Num_Boletas_Monitoreo { get; set; }
        public int Precipitacion_Pluvial { get; set; }
        public DateTime Fecha_Semana_Envio { get; set; }
    }
}
