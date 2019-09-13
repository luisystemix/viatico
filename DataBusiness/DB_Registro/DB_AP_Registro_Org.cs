using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataAccess.DA_Registro;
using DataEntity.DE_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_Registro_Org
    {
        #region OBTENER LA LISTA DE LAS TABLAS ORGANIZACION => INSCRIPCION_ORG => DOCUMENTO_PRESENTADO
        public DataTable DB_Desplegar_ORG_INS_DOC(int IdCamp, int IdReg, string Programa, string Parametro)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DA_Desplegar_ORG_INS_DOC(IdCamp, IdReg, Programa, Parametro);
        }
        #endregion
        #region OBTENER LA LISTA DE ORGANIZACIONES PARA GENERAR LISTAS OFICIALES APROBADOS POR JURIDICA
        public DataTable DB_Desplegar_ORG_LIST_OFI(int IdCamp, int IdReg, string Programa, string Parametro)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DA_Desplegar_ORG_LIST_OFI(IdCamp, IdReg, Programa, Parametro);
        }
        #endregion
        #region LISTAR ORGANIZACIONES POR DEPARTAMENTO
        public List<AP_Organizacion> DB_Desplegar_ORG_DEP(string departamento)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_ORG_DEP(departamento);
            List<AP_Organizacion> listOrg = new List<AP_Organizacion>();
            foreach (DataRow fila in dt.Rows)
            {
                AP_Organizacion org = new AP_Organizacion();
                org.Id_Organizacion = Convert.ToInt32(fila[0]);
                org.Sigla = Convert.ToString(fila[1]);
                listOrg.Add(org);
            }
            return listOrg;
        }
        #endregion
        #region DEVOLVER EL MAYOR ID DE CUALQUIER TABLA
        public string DB_MaxId(string tabla, string id)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            string al = data.DA_MaxId(tabla, id);
            return al;
        }
        #endregion
        #region OBTENER LA LISTA DE LAS TABLAS INSCRIPCION_ORG => DOCUMENTO_PRESENTADO => DOCUMENTO_SOLICITADO
        public DataTable DB_Desplegar_INS_ORG_DOC_PRESENT(int Id)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DA_Desplegar_INS_ORG_DOC_PRESENT(Id);
        }
        #endregion
        #region MODIFICAR EL ESTADO DE LA TABLA DOCUMENTO VERIFICADO
        public void DB_Modificar_ESTADO_DOC_VERIF(AP_DocVerificado dv)
        {
            DA_AP_Registro_Org dato = new DA_AP_Registro_Org();
            dato.DA_Modificar_ESTADO_DOC_VERIF(dv);
        }
        #endregion
        #region FUNCION PARA EXTRAER LOS DATOS PARA EL REPORTE DE REGISTRO DE VERIFICACION DE DOCUMENTOS POR EL ID DE LAINSCRIPCION DE LA ORG
        public string[] DB_Desplegar_DOC_VERIF_REPORTE(int Id)
        {
            string[] DatsRep = new string[10];
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_DOC_VERIF_REPORTE(Id);
            AP_DocVerificado dv = new AP_DocVerificado();
            DatsRep[0] = dt.Rows[0][0].ToString();
            DatsRep[1] = dt.Rows[0][1].ToString();
            DatsRep[2] = dt.Rows[0][2].ToString();
            DatsRep[3] = dt.Rows[0][3].ToString();
            DatsRep[4] = dt.Rows[0][4].ToString();
            DatsRep[5] = dt.Rows[0][5].ToString();
            DatsRep[6] = dt.Rows[0][6].ToString();
            DatsRep[7] = dt.Rows[0][7].ToString();
            DatsRep[8] = dt.Rows[0][8].ToString();
            DatsRep[9] = dt.Rows[0][9].ToString();
            return DatsRep;
        }
        #endregion
        #region DESPLEGAR TODAS LA CAMPAÑIAS
        public DataTable DA_Desplegar_CAMPANHIA_PARAMETROS(int IdCamp)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DA_Desplegar_CAMPANHIA_PARAMETROS(IdCamp);
        }
        #endregion
        #region OBTENER LA LISTA DE LAS TABLAS AP_PROVEEDOR => INSCRIPCION_PROV => DOCUMENTO_PRESENTADO_PROV => REPRESENTANTELEGAL => PERSONA
        public DataTable DB_Desplegar_PROV_INS_DOC(int IdCamp, int IdReg, string Programa, string Insumo,string Parametro)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DA_Desplegar_PROV_INS_DOC(IdCamp, IdReg, Programa, Insumo, Parametro);
        }
        #endregion
        #region OBTENER DATOS DE LA ORGANIZACION PARA SU ENCABEZADO
        public DataTable DB_Desplegar_ENCABEZADO_ORG(int IdInsOrg)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DB_Desplegar_ENCABEZADO_ORG(IdInsOrg);
        }
        #endregion
        /******************************* FUNCIONES DE PROVEEDORES *****************************************/
        #region OBTENER LA LISTA DE LAS TABLAS INSCRIPCION_PROVEEDOR => DOCUMENTO_PRESENTADO => DOCUMENTO_SOLICITADO
        public DataTable DB_Desplegar_INS_PROV_DOC_PRESENT(int Id)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DA_Desplegar_INS_PROV_DOC_PRESENT(Id);
        }
        #endregion
        #region OBTENER DATOS DEL PROVEEDOR PARA SU ENCABEZADO
        public DataTable DB_Desplegar_ENCAVEZADO_PROV(int IdInsProv)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DA_Desplegar_ENCAVEZADO_PROV(IdInsProv);
        }
        #endregion
        #region OBTENER LA LISTA DE LAS TABLAS INSCRIPCION_PROVEEDOR => DOCUMENTO_PRESENTADO => DOCUMENTO_SOLICITADO
        public DataTable DB_Reporte_DOC_PROV_PRESENT(int Id)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DA_Reporte_DOC_PROV_PRESENT(Id);
        }
        #endregion
        /******************************* FUNCIONES DE PRODUCTOR ******************************************/
        #region OBTENER LA LISTA DE LAS TABLAS PRODUCTOR => INSCRIPCION_PROD => PERSONA
        public DataTable DB_Desplegar_PRODUCTOR_INS(int IdInsOrg, string Parametro)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DA_Desplegar_PRODUCTOR_INS(IdInsOrg, Parametro);
        }
        #endregion
        /******************************* FUNCIONES DE USIARIOS ******************************************/
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        public DataTable DB_Desplegar_USUARIO(string IdUser)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DA_Desplegar_USUARIO(IdUser);
        }
        #endregion
        /******************************* FUNCIONES DE RESPONSABLE REGIONAL ******************************************/
        #region REPORTE DEL CRONOGRAMA DE LA REGIONAL 
        public DataTable DB_Reporte_CRONOGRAMA_REGIONAL(int IdCamp,int IdReg)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DA_Reporte_CRONOGRAMA_REGIONAL(IdCamp,IdReg);
        }
        #endregion
        #region FUNCION ECTRAER LA ID_CAMPANHIA DE LA TABLA AP_INSCRIPCION_ORG
        public Int32 DB_EXTRAE_COMPANHIA_DE_AP_INCRIPCION_ORG(Int32 IdUser)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DA_EXTRAE_COMPANHIA_DE_AP_INCRIPCION_ORG(IdUser);
        }
        #endregion
    }
}
