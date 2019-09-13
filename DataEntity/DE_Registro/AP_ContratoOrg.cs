using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_ContratoOrg
    {
        public int Id_InscripcionOrg { get; set; }
        public string Num_Contrato { get; set; }
        public string Ci_RepLegalEmapa { get; set; }
        public string ResolucionAdmin { get; set; }
        public DateTime FechaResAdmin { get; set; }
        public string Domicilio { get; set; }
        public string Estado { get; set; }
    }
}
