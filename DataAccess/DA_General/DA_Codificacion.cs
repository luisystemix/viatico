using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess.DA_General
{
    public class DA_Codificacion
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region GENERAR CODIGO
        public DataTable GetCodigo(int idReg, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("CODIGO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Regional", idReg);
                    cmd.Parameters.AddWithValue("@Parametro", parametro);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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
        #region  INCREMENTAR EL CONTADOR DEL CODIGO 
        public void Contador(int Cod, string doc)
        {
            try
            {
                string queryString = "UPDATE EMAPA_CODIGO_CONTADOR set Contador = Contador + 1  WHERE  Id_Codigo = " + Cod + " AND Documento='" + doc + "'";
                using (SqlConnection connection = new SqlConnection(conexionString))
                {
                    SqlCommand rep = new SqlCommand(queryString, connection);
                    connection.Open();
                    rep.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        #region ES CONTADOR DEL CODIGO
        public int ContadorCod(string Cod, string doc)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("CODIGO_VIAT_CONT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD", Cod);
                    cmd.Parameters.AddWithValue("@DOC", doc);
                    SqlParameter IdParametro = new SqlParameter("@IDCOD", 0);
                    IdParametro.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(IdParametro);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    int idcod = Int32.Parse(cmd.Parameters["@IDCOD"].Value.ToString());
                    conexion.Close();
                    return idcod;
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        #region BUSCAR CODIGO DE CONTRATO PRINCIPAL
        public DataTable DA_Codigo_INFORME()
        {
            try
            {
                string queryString = "SELECT EMAPA_CODIGO.Id_Codigo, EMAPA_CODIGO_CONTADOR.Contador, EMAPA_CODIGO_CONTADOR.Documento";
                queryString += " FROM EMAPA_CODIGO INNER JOIN EMAPA_CODIGO_CONTADOR ON EMAPA_CODIGO.Id_Codigo = EMAPA_CODIGO_CONTADOR.Id_Codigo WHERE EMAPA_CODIGO_CONTADOR.Documento='CONTRATO PRINCIPAL'";
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
