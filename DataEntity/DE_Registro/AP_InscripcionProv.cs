using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_InscripcionProv
    {
        public int Id_InscripcionProv { get; set; }
        public int Id_Campanhia { get; set; }
        public int Id_Proveedor { get; set; }
        public int Id_Regional { get; set; }
        public string Insumo { get; set; }
        public string Programa { get; set; }
        public string Matricula_Comercio { get; set; }
        public string Domicilio { get; set; }
        public string Estado { get; set; }
    }
}
