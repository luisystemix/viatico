using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Registro
{
    public class AP_InscripcionProd
    {
        public string Id_Productor { get; set; }
        public string Id_Persona { get; set; }
        public int Id_Comunidad { get; set; }
        public int Id_InscripcionOrg { get; set; }
        public int Id_Campanhia { get; set; }
        public string Programa { get; set; }
        public string Tipo_Inscripcion { get; set; }
        public string Tipo_Produccion { get; set; }
        public decimal Has_Inscrito { get; set; }
        public decimal Has_Ejecutado { get; set; }
        public decimal Has_Propio { get; set; }
        public int Rau { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
    }
}
