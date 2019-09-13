using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_DocPresentadoProv
    {
        public int Id_VerificarDoc { get; set; }
        public int Id_Documento { get; set; }
        public string Observacion { get; set; }
        public Boolean Estado { get; set; }
    }
}
