using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataEntity.DE_Registro;

namespace DataAccess.DA_Registro
{
    public class DA_AP_DocVerificado
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region OBTENER DATOS DE LA TABLA VERIFICACION DE DOCUMENTOS PRESENTADO
        public DataTable DA_Desplegar_DOC_VERIF(int Id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_DOC_VERIFICADO_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", Id);
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
        #region FUNCION PARA REGISTRAR A LA TABLA DE DOCUMENTOS SOLICITADOS VERIFICACION DE DOCUMENTOS
        public void DA_Registrar_DOC_VERIFICADO(AP_DocVerificado dv)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_DOC_VERIFICADO_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_VerificarDoc", dv.Id_VerificarDoc);
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", dv.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@NumProductores", dv.NumProductores);
                    cmd.Parameters.AddWithValue("@SuperficieTotal", dv.SuperficieTotal);
                    cmd.Parameters.AddWithValue("@Ci_Revisor", dv.Ci_Revisor);
                    cmd.Parameters.AddWithValue("@Observacion", dv.Observacion);
                    cmd.Parameters.AddWithValue("@Fecha", dv.Fecha);
                    cmd.Parameters.AddWithValue("@Estado", dv.Estado);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        #region MODIFICAR DATOS DE LA TABLA DOCUMENTO VERIFICADO
        public void DA_Modificar_DOC_VERIF(AP_DocVerificado dv)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_DOC_VERIFICADO_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", dv.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@NumProductores", dv.NumProductores);
                    cmd.Parameters.AddWithValue("@SuperficieTotal", dv.SuperficieTotal);
                    cmd.Parameters.AddWithValue("@Observacion", dv.Observacion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
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
