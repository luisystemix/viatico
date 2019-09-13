using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Registro;
using DataEntity.DE_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_Campanhia
    {
        #region DESPLEGAR TODAS LA CAMPAÑIAS
        public List<AP_Campanhia> DB_Desplegar_CAMPANHIA()
        {
            DA_AP_Campanhia data = new DA_AP_Campanhia();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_CAMPANHIA();
            List<AP_Campanhia> listCamp = new List<AP_Campanhia>();
            foreach (DataRow fila in dt.Rows)
            {
                AP_Campanhia ca = new AP_Campanhia();
                ca.Nombre = fila[0].ToString();
                ca.Fecha_Inicio = Convert.ToDateTime(fila[1]);
                ca.Fecha_Final = Convert.ToDateTime(fila[2]);
                ca.Region = fila[3].ToString();
                ca.Estado = fila[4].ToString();
                ca.Id_Campanhia = Convert.ToInt32(fila[5]);
                listCamp.Add(ca);
            }
            return listCamp;
        }
        #endregion
        #region DESPLEGAR TODAS LA CAMPAÑIAS POR REGION
        public DataTable DB_Desplegar_CAMPANHIA_DT()
        {
            DA_AP_Campanhia data = new DA_AP_Campanhia();
            DataTable dt = new DataTable();
            return data.DA_Desplegar_CAMPANHIA();
        }
        #endregion
        #region DESPLEGAR TODAS LA CAMPAÑIAS POR REGION
        public DataTable DB_Desplegar_CAMPANHIA_REGION(string Region)
        {
            DA_AP_Campanhia data = new DA_AP_Campanhia();
            return data.DA_Desplegar_CAMPANHIA_REGION(Region);
        }
        #endregion
        #region REGISTRAR NUEVA CAMPAÑA
        public void DA_Registrar_CAMPANHIA(AP_Campanhia c)
        {
            DA_AP_Campanhia Ins = new DA_AP_Campanhia();
            Ins.DA_Registrar_CAMPANHIA(c);
        }
        #endregion
        #region OBTENER LA LISTA DE LAS TABLAS CAMPANHIA => INSCRIPCION_ORG => ORGANIZACION
        public void ExtraerCapanhiaID_INORG(int IdCamp, int IdOrg, ref String nombreOrg, ref String NomPrograma, ref String nombreCamp)
        {
            DA_AP_Campanhia camp = new DA_AP_Campanhia();
            camp.ExtraerCapanhiaID_INORG(IdCamp, IdOrg, ref nombreOrg, ref NomPrograma, ref nombreCamp);
        }
        #endregion 
        #region BUSCAR CAMPAÑA POR EL ID DE LA CAMPAÑA
        public AP_Campanhia DB_Buscar_CAMPANHIA(int id)
        {
            DA_AP_Campanhia data = new DA_AP_Campanhia();
            DataTable dt = new DataTable();
            dt = data.DA_Buscar_CAMPANHIA(id);
            AP_Campanhia c = new AP_Campanhia();
            c.Id_Campanhia = Convert.ToInt32(dt.Rows[0][0]);
            c.Nombre = dt.Rows[0][1].ToString();
            c.Fecha_Inicio = Convert.ToDateTime(dt.Rows[0][2].ToString());
            c.Fecha_Final = Convert.ToDateTime(dt.Rows[0][3].ToString());
            c.Region = dt.Rows[0][4].ToString();
            c.Estado = dt.Rows[0][5].ToString();
            return c;
        }
        #endregion
        #region BUSCAR CAMPAÑA POR LA REGION
        public DataTable DB_Seleccionar_CAMPANHIA_REG_NOFIN(string region)
        {
            DA_AP_Campanhia data = new DA_AP_Campanhia();
            return data.DA_Seleccionar_CAMPANHIA_REG_NOFIN(region);
        }
        #endregion
        #region BUSCAR CAMPAÑA POR LA REGION Y EL ESTADO
        public DataTable DB_Seleccionar_CAMPANHIA_REG(string region, string estado)
        {
            DA_AP_Campanhia data = new DA_AP_Campanhia();
            return data.DA_Seleccionar_CAMPANHIA_REG(region, estado);
        }
        #endregion
        #region DESPLEGAR TODOS LOS PROGRAMAS DE LA CAMPAÑIAS POR EL ID DEL USUARIO
        public List<AP_Campanhia> DB_Desplegar_PROGRAMA_REGION()
        {
            DA_AP_Campanhia data = new DA_AP_Campanhia();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_CAMPANHIA();
            List<AP_Campanhia> listCamp = new List<AP_Campanhia>();
            foreach (DataRow fila in dt.Rows)
            {
                AP_Campanhia ca = new AP_Campanhia();
                ca.Nombre = fila[0].ToString();
                ca.Fecha_Inicio = Convert.ToDateTime(fila[1]);
                ca.Fecha_Final = Convert.ToDateTime(fila[2]);
                ca.Region = fila[3].ToString();
                ca.Estado = fila[4].ToString();
                ca.Id_Campanhia = Convert.ToInt32(fila[5]);
                listCamp.Add(ca);
            }
            return listCamp;
        }
        #endregion 
        #region SELECCIONAR LA CAMPAÑA SEGUN SU PROGRAMA PARA VER SI EXISTE Y ESTA ACTIVA
        public DataTable DB_Seleccionar_CAMPANHIA_PROG(int IdCamp, int IdReg, string Programa, string Parametro)
        {
            DA_AP_Campanhia data = new DA_AP_Campanhia();
            return data.DA_Seleccionar_CAMPANHIA_PROG(IdCamp, IdReg, Programa, Parametro);
        }
        #endregion
        #region DESPLEGAR LOS PARAMETROS DE LA CAMPAÑA SELECCIONADA POR ID
        public DataTable DB_Buscar_PARAMETROS_CAMPANHIA(int IdCamp)
        {
            DA_AP_Campanhia data = new DA_AP_Campanhia();
            return data.DA_Buscar_PARAMETROS_CAMPANHIA(IdCamp);
        }
        #endregion

    }
}
