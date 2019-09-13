using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_General
{
    public class Modulo
    {
        public int Id_Modulo { get; set; }
        public string Modulos { get; set; }
        public string Url { get; set; }
        public int NodoPadre { get; set; }
        public int Pagina { get; set; }
        public int Nivel { get; set; }
        public DateTime F_Registro { get; set; }
        public string Estado { get; set; }
    }
}
