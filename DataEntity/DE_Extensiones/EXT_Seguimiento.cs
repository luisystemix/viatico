using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_Seguimiento
    {
        public int Id_Seguimiento { get; set; }
        public int Id_InscripcionOrg { get; set; }
        public string Id_Usuario { get; set; }
        public string Id_Productor { get; set; }
        public int Id_Campanhia { get; set; }
        public int Id_Regional { get; set; }
        public string Programa { get; set; }
        public string Etapa { get; set; }
        public int Num_Seg_Cultivo { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha_Envio { get; set; }
        public int Tipo_Seguimiento { get; set; }
    }
}
