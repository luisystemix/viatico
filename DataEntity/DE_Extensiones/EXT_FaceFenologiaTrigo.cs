﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.DE_Extensiones
{
    public class EXT_FaceFenologiaTrigo
    {
        public int Id_Face_Feonologica { get; set; }
        public string FechaAvnSiemIni { get; set; }
        public string FechaAvnSiemFin { get; set; }
        public decimal FechaAvnSiemAvan { get; set; }
        public decimal GerminacionIni { get; set; }
        public decimal GerminacionFin { get; set; }
        public decimal PlantulaIni { get; set; }
        public decimal PlantulaFin { get; set; }
        public decimal MacollamientoIni { get; set; }
        public decimal MacollamientoFin { get; set; }
        public decimal EmbucheIni { get; set; }
        public decimal EmbucheFin { get; set; }
        public decimal EspigazonIni { get; set; }
        public decimal EspigazonFin { get; set; }
        public decimal FloracionIni { get; set; }
        public decimal FloracionFin { get; set; }
        public decimal LlenadoGranoIni { get; set; }
        public decimal LlenadoGranoFin { get; set; }
        public decimal MaduracionIni { get; set; }
        public decimal MaduracionFin { get; set; }
        public decimal CosechaAcopioAvan { get; set; }
        public decimal CosechaAcopioRend { get; set; }
        public string FechaCosechaIni { get; set; }
        public string FechaCosechaFin { get; set; }
        public string Tipo { get; set; }
        public decimal SupSem { get; set; }
    }
}
