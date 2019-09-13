using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_DocVerificado
    {
        public int Id_VerificarDoc { get; set; }
        public int Id_InscripcionOrg { get; set; }
        public int NumProductores { get; set; }
        public decimal SuperficieTotal { get; set; }
        public string Ci_Revisor { get; set; }
        public string Observacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
