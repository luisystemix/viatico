using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_ReunionAsistencia
    {
        public int Id_Reunion { get; set; }
        public string ci { get; set; }
        public string Nombre { get; set; }
        public string Comunidad { get; set; }
        public string Municipio { get; set; }
        public string Representante { get; set; }
        public string Cargo { get; set; }
    }
}
