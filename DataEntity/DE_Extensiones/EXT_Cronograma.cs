using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    [Serializable]
    public class EXT_Cronograma
    {
        public int Id_Cronograma { get; set; }
        public int Id_Campanhia { get; set; }
        public string Id_Usuario { get; set; }
        public int Id_Regional { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_Envio { get; set; }
        public string Mes { get; set; }
        public string Semana { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
    }
}
