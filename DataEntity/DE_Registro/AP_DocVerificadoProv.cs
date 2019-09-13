using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_DocVerificadoProv
    {
        public int Id_VerificarDocProv { get; set; }
        public int Id_InscripcionProv { get; set; }
        public string Ci_Revisor { get; set; }
        public string Observacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
