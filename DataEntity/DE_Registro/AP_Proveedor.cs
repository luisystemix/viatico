using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_Proveedor
    {
        public int Id_Proveedor { get; set; }
        public string Razon_Social { get; set; }
        public string NIT { get; set; }
        public string Num_Testimonio { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Departamento { get; set; }
        public string Domicilio { get; set; }
        public string Telefono_Ref { get; set; }
        public string Correo { get; set; }
    }
}
