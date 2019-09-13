using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Viaticos
{
    public class VT_SolicitudDestino
    {
        public string Id_Solicitud { get; set; }
        public int Cont { get; set; }
        public string Tramo { get; set; }
        public string Zona { get; set; }
        public string Destino { get; set; }
        public string Lugar { get; set; }
        public string Objetivo { get; set; }
        public DateTime Fecha_Salida { get; set; }
        public string Via_Transporte { get; set; }
        public string Tipo_Transporte { get; set; }
        public string Nombre_Transporte { get; set; }
        public string Identificador_Trasporte { get; set; }
    }
}
