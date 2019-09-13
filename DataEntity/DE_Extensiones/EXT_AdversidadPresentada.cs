using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_AdversidadPresentada
    {
        public int Id_Seguimiento_Parcela { get; set; }
        public string Adversidad { get; set; }
        /// <summary>
        /// Observación y/o Recomendación
        /// </summary>
        public string Descripcion { get; set; }
        public string Intencidad { get; set; }
        public decimal Porcentage { get; set; }
        public string Tratamiento { get; set; }
        public DateTime Fecha_Ocurrencia { get; set; }
    }
}
