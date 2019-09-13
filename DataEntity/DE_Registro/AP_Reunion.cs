using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_Reunion
    {
        public int Id_Reunion { get; set; }
        public int Id_Campanhia { get; set; }
        public int Id_Regional { get; set; }
        public string Tipo_Reunion { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }
        public string Conclusion { get; set; }
    }
}
