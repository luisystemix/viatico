using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Insumos
{
    public class INS_Distribucion
    {
        public int Id_Distribucion { get; set; }
        public int Id_Campanhia { get; set; }
        public int Id_InscripcionOrg { get; set; }
        public int Id_InscripcionProv { get; set; }
        public int Id_Regional { get; set; }
        public string Programa { get; set; }
        public string Insumo { get; set; }
        public DateTime Fecha_Registro { get; set; }
    }
}
