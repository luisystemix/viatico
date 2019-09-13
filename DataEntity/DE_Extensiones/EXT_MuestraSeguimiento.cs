using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_MuestraSeguimiento
    {
        public int Id_Muestra { get; set; }
        public int Id_Campanhia { get; set; }
        public int Id_Regional { get; set; }
        public string Programa { get; set; }
        public int Num_Org { get; set; }
        public int Num_Prod { get; set; }
        public int Num_Muestra { get; set; }
        public int Num_Tecnicos { get; set; }
    }
}
