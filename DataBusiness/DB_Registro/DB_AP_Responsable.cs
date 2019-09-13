using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_Responsable
    {
        #region OBTENER LA LISTA DE LAS LAS ORGANIZACIONES LISTAS PARA SU GENERACION DE CONTRATOS
        public DataTable DB_Desplegar_REGISTRO_CONTRATOS_ORG(int IdCamp, int IdReg, string Programa)
        {
            DA_AP_Responsable data = new DA_AP_Responsable();
            return data.DA_Desplegar_REGISTRO_CONTRATOS_ORG(IdCamp, IdReg, Programa);
        }
        #endregion
        #region SELECCIONAR LA ORGANIZACION PARA REVISAR  SUS DATOS PARA GENERACION DE CONTRATOS
        public DataTable DB_Seleccionar_CONTRATOS_ORG(int IdInsOrg, string Parametro)
        {
            DA_AP_Responsable data = new DA_AP_Responsable();
            return data.DA_Seleccionar_CONTRATOS_ORG(IdInsOrg,Parametro);
        }
        #endregion
    }
}
