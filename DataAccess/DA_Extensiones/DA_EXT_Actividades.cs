using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataAccess.DA_Extensiones
{
    public class DA_EXT_Actividades
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion

        #region SELECCIONA LAS ACTIVIDADES DEACUERDO A LA CATEGORIA
        /// <summary>
        /// Metodo que conecta a la base de datos para recuperar las actividades registradas en la abase de datos para las actividades para el cronograma semanal del rol tecnico de extension
        /// </summary>
        /// <param name="Categoria">Codigo de la categoria buscada</param>
        /// <returns>Tabala de datos con las actividades registradas para el rol tecnico de extension a nivel nacional</returns>
        public DataTable DA_Seleccionar_ActividadesCronogramaSemanal(string Categoria)
        {
            try
            {
                string queryString = "select IdExtActividades, Codigo, '('+Codigo+') '+ Actividad as Actividad from dbo.EXT_ACTIVIDADES where Categoria ='" + Categoria + "' and IdEstado=1";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.Close();
                    return dt;
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion

    }
}
