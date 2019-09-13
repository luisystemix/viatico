using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class INS_ContratoInsumo
    {
        public int Id_Contrato_Insumo { get; set; }
        public int Id_InscripcionProv { get; set; }
        public int Id_Campanhia { get; set; }
        public int Id_Regional { get; set; }
        public string Insumo { get; set; }
        public string Programa { get; set; }
        public decimal MontoTotal { get; set; }
    }
}
