using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess.DA_Registro
{
    public class DA_AP_Inscripcion_Prod_Update
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion

        #region OBTENER LA LISTA DE LAS TABLAS INCRIPCION_PROD => PERSONA => INSCRIPCION_ORG
        public DataTable DA_Desplegar_INCRIPCIONPROD_PER_INSORG(int IdCamp, int IdReg, string ci, string nombre, string apellidoP, string apellidoM)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_INCRIPCIONPROD_PERSONA_INSCRIPCIONORG", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCAMP", IdCamp);
                    cmd.Parameters.AddWithValue("@IDORG", IdReg);
                    cmd.Parameters.AddWithValue("@CI", "%" + ci + "%");
                    cmd.Parameters.AddWithValue("@NOMBRE", "%" + nombre + "%");
                    cmd.Parameters.AddWithValue("@APELLIDOP", "%" + apellidoP + "%");
                    cmd.Parameters.AddWithValue("@APELLIDOM", "%" + apellidoM + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //cmd.ExecuteNonQuery();
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
        #region OBTENER EL DEPARTAMENTO POR MEDIO DE LA RELACION REGIONAL => AP_INSCRIPCION_ORG
        public String DA_Desplegar_REGIONAL_AP_INSCRIPCION_ORG(Int32 id_InscripcionOrg)
        {
            String Dep = "";
            SqlConnection CN = new SqlConnection(conexionString);
            SqlCommand query = new SqlCommand("SELECT REGIONAL.Departamento FROM  REGIONAL INNER JOIN AP_INSCRIPCION_ORG ON REGIONAL.Id_Regional = AP_INSCRIPCION_ORG.Id_Regional WHERE (AP_INSCRIPCION_ORG.Id_InscripcionOrg = " + id_InscripcionOrg + ")", CN);
            SqlDataReader Reader;
            query.Connection.Open();
            Reader = query.ExecuteReader();
            if (Reader.Read())
            {
                Dep = Reader.GetString(0);
            }
            query.Connection.Close();
            return Dep;
        }
        #endregion
        #region OBETENER EL PROGRAMA Y LA REGIONAL CORRESPONDIENTE
        public void DA_Extraer_AP_INSCRIPCION_ORG_REGIONAL(Int32 id_InscripcionOrg, ref String Prog, ref String Reg)
        {
            SqlConnection CN = new SqlConnection(conexionString);
            SqlCommand query = new SqlCommand("SELECT AP_INSCRIPCION_ORG.Programa, REGIONAL.Nombre, AP_INSCRIPCION_ORG.Id_InscripcionOrg FROM REGIONAL INNER JOIN AP_INSCRIPCION_ORG ON REGIONAL.Id_Regional = AP_INSCRIPCION_ORG.Id_Regional WHERE (AP_INSCRIPCION_ORG.Id_InscripcionOrg = " + id_InscripcionOrg + ")", CN);
            SqlDataReader Reader;
            query.Connection.Open();
            Reader = query.ExecuteReader();
            if (Reader.Read())
            {
                Prog = Reader.GetString(0);
                Reg = Reader.GetString(1);
            }
            query.Connection.Close();
        }
        #endregion
        #region OBTENER LA DATOS DE LAS TABLAS AP_INCRIPCION_PROD => PERSONA
        public DataTable DA_BUSCAR_AP_INCRIPCION_PROD_PERSONA(String IdProd, String IdPerCi)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_INSCRIPCION_PROD_PERSONA", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDP", IdProd);
                    cmd.Parameters.AddWithValue("@CI", IdPerCi);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //cmd.ExecuteNonQuery();
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
        #region OBTENER LA DATOS DE LAS TABLAS COMUNIDAD=>MUNICIPIO=>PROVINCIA
        public DataTable DA_BUSCAR_COMUNIDAD_MUNICIPIO_PROVINCIA(Int32 IdCom)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_INSCRIPCION_COMUNIDAD_MUNICIPO_PROVINCIA", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_COMUNIDAD", IdCom);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //cmd.ExecuteNonQuery();
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
