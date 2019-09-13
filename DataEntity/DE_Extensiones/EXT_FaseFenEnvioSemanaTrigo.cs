using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_FaseFenEnvioSemanaTrigo
    {
        public int Id_Envio_FenologiaSemanal { get; set; }
        public int Num_Prod_Vigente { get; set; }
        public decimal Sup_Sembrada { get; set; }
        public decimal Avance_Siembra { get; set; }
        public decimal Germinacion { get; set; }
        public decimal Plantula { get; set; }
        public decimal Macollamiento { get; set; }
        public decimal Embuche { get; set; }
        public decimal Espigazon { get; set; }
        public decimal Floracion { get; set; }
        public decimal Llenado_Grano { get; set; }
        public decimal Maduracion { get; set; }
        public decimal Avance_cosecha { get; set; }
        public decimal Rendimiento { get; set; }
    }
}
