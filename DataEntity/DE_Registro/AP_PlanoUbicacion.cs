using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_PlanoUbicacion
    {
        public int Id_Plano { get; set; }
        public string Id_Productor { get; set; }
        public int Comunidad { get; set; }
        public int Numero_Parcela { get; set; }
        public decimal Superficie_Doc { get; set; }
        public decimal Superficie_Mensura { get; set; }
        public string Observacion { get; set; }
    }
}
