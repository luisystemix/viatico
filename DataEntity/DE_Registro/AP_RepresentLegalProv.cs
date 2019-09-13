using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_RepresentLegalProv
    {
        public int Id_InscripcionProv { get; set; }
        public string Id_Persona { get; set; }
        public string Tipo_Poder { get; set; }
        public string Num_Testimonio { get; set; }
        public string Domicilio { get; set; }
        public DateTime Fecha { get; set; }

    }
}
