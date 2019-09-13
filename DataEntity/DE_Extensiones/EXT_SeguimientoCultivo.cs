using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    [Serializable]
    public class EXT_SeguimientoCultivo
    {
        public int Id_Seguimiento_Parcela { get; set; }
        public int Id_Fenologia { get; set; }
        public string Estado { get; set; }
        public int Porcentaje_FF { get; set; }
        public DateTime Fecha_Cosecha { get; set; }
        //public string Elemento { get; set; }
        //public string Nombre_Elemento { get; set; }
        //public int Intencidad { get; set; }
        //public string Tratamiento { get; set; }
    }
}
