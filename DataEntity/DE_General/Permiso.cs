using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_General
{
    public class Permiso
    {
        public int Id_Rol { get; set; }
        public int Id_Modulo { get; set; }
        public Boolean Vista { get; set; }
        public Boolean Editar { get; set; }
        public DateTime F_Registro { get; set; }
    }
}
