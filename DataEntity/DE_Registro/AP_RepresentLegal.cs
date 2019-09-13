using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_RepresentLegal
    {
        public string Id_Persona { get; set; }
        public int Id_InscripcionOrg { get; set; }
        public string Tipo_Poder { get; set; }
        public string Nun_Testimonio { get; set; }
        public string Domicilio { get; set; }
        public DateTime Fecha { get; set; }
        public string Num_Notaria { get; set; }
        public string Distrito_Judicial { get; set; }
        public string Abg_A_Cargo { get; set; }
    }
}
