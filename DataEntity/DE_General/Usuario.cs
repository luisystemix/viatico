using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_General
{
    [Serializable]
    public class Usuario
    {
        public string Id_Usuario { get; set; }
        public string Id_Persona { get; set; }
        public int Id_Regional { get; set; }
        public int Id_Rol { get; set; }
        public int Id_Categoria { get; set; }
        public string Cargo { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }
    }
}
