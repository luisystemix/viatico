using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_FaseFenEnvioSem
    {
        public int Id_Envio_FenologiaSemanal { get; set; }
        public int Id_Campanhia { get; set; }
        public int Id_Regional { get; set; }
        public string Programa { get; set; }
        public DateTime Fecha_Envio { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha_Semana { get; set; }
    }
}
