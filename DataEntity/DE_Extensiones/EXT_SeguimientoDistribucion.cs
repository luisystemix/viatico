using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_SeguimientoDistribucion
    {
        public int Id_Seg_Distribucion { get; set; }
        public int Id_Seguimiento { get; set; }
        public string Programa { get; set; }
        public string Nom_Proveedor { get; set; }
        public string Lugar_Distribucion { get; set; }
        public DateTime Fecha_Sis { get; set; }
        public DateTime Fecha_Distribucion { get; set; }
        public string Tipo_Insumo { get; set; }
        public string Observacion { get; set; }
        public int Num_Boleta { get; set; }
    }
}
