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
    public class DA_AP_Registro_Org
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region OBTENER LA LISTA DE LAS TABLAS ORGANIZACION => INSCRIPCION_ORG => DOCUMENTO_PRESENTADO
        public DataTable DA_Desplegar_ORG_INS_DOC(int IdCamp, int IdReg, string Programa, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_ORGANIZACION_INS_DOC", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCAMPANHIA", IdCamp);
                    cmd.Parameters.AddWithValue("@IDREGIONAL", IdReg);
                    cmd.Parameters.AddWithValue("@PROGRAMA", Programa);
                    cmd.Parameters.AddWithValue("@PARAMETRO", Parametro);
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
        #region OBTENER LA LISTA DE ORGANIZACIONES PARA GENERAR LISTAS OFICIALES APROBADOS POR JURIDICA
        public DataTable DA_Desplegar_ORG_LIST_OFI(int IdCamp, int IdReg, string Programa, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_ORGANIZACION_LISTA_OFICIAL", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCAMPANHIA", IdCamp);
                    cmd.Parameters.AddWithValue("@IDREGIONAL", IdReg);
                    cmd.Parameters.AddWithValue("@PROGRAMA", Programa);
                    cmd.Parameters.AddWithValue("@PARAMETRO", Parametro);
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
        #region LISTAR ORGANIZACIONES POR DEPARTAMENTO
        public DataTable DA_Desplegar_ORG_DEP(string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_ORGANIZACION_DEP", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PARAMETRO", Parametro);
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
        #region DEVOLVER EL MAYOR ID DE CUALQUIER TABLA
        public string DA_MaxId(string tabla, string Id)
        {
            string queryString = "SELECT MAX(" + Id + ") FROM " + tabla + "";
            using (SqlConnection connection = new SqlConnection(conexionString))
            {
                SqlCommand rep = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader myReader = rep.ExecuteReader();
                string IdAsociacion = "0";
                if (myReader.Read())
                {
                    IdAsociacion = myReader[0].ToString();
                }
                connection.Close();
                return IdAsociacion;
            }
        }
        #endregion
        #region OBTENER LA LISTA DE LAS TABLAS INSCRIPCION_ORG => DOCUMENTO_PRESENTADO => DOCUMENTO_SOLICITADO
        public DataTable DA_Desplegar_INS_ORG_DOC_PRESENT(int Id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_INSCRIPCION_ORG_DOC_PRESENT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", Id);
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
        #region MODIFICAR EL ESTADO DE LA TABLA DOCUMENTO VERIFICADO
        public void DA_Modificar_ESTADO_DOC_VERIF(AP_DocVerificado dv)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_DOC_VERIFICADO_MODIFICAR_ESTADO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", dv.Id_InscripcionOrg);
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
        #region FUNCION PARA EXTRAER LOS DATOS PARA EL REPORTE DE REGISTRO DE VERIFICACION DE DOCUMENTOS POR EL ID DE LAINSCRIPCION DE LA ORG
        public DataTable DA_Desplegar_DOC_VERIF_REPORTE(int Id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_REPORTE_VERIFICAION_DOC_ORG", conexion);
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
        #region DESPLEGAR TODAS LA CAMPAÑIAS Y SUS PARAMETROS
        public DataTable DA_Desplegar_CAMPANHIA_PARAMETROS(int IdCamp)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_CAMPANHIA_PARAMETROS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", IdCamp);
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
        #region OBTENER LA LISTA DE LAS TABLAS AP_PROVEEDOR => INSCRIPCION_PROV => DOCUMENTO_PRESENTADO_PROV => REPRESENTANTELEGAL => PERSONA
        public DataTable DA_Desplegar_PROV_INS_DOC(int IdCamp, int IdReg, string Programa, string Insumo, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_PROVEEDOR_INS_DOC", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", IdCamp);
                    cmd.Parameters.AddWithValue("@Id_Regional", IdReg);
                    cmd.Parameters.AddWithValue("@Programa", Programa);
                    cmd.Parameters.AddWithValue("@Insumo", Insumo);
                    cmd.Parameters.AddWithValue("@Parametro", Parametro);
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
        #region OBTENER DATOS DE LA ORGANIZACION PARA SU ENCABEZADO
        public DataTable DB_Desplegar_ENCABEZADO_ORG(int IdInsOrg)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_ENCABEZADO_ORG_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", IdInsOrg);
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
        /******************************* FUNCIONES DE PROVEEDORES *****************************************/
        #region OBTENER LA LISTA DE LAS TABLAS INSCRIPCION_PROVEEDOR => DOCUMENTO_PRESENTADO => DOCUMENTO_SOLICITADO
        public DataTable DA_Desplegar_INS_PROV_DOC_PRESENT(int Id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_INSCRIPCION_PROV_DOC_PRESENT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_VerificarDocProv", Id);
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
        # region SELECCIONA EL PROGRAMA DE LA TABLA AP_INSCRIPCION_ORG
        public void Seleccionar_Prog_DA_AP_INCRIPCION_ORG(Int32 id_Inscripcion_Org, ref String Prog, ref String tipo_P)
        {
            SqlConnection CN = new SqlConnection(conexionString);
            SqlCommand query = new SqlCommand("SELECT Programa,Tipo_Produccion FROM AP_INSCRIPCION_ORG WHERE (Id_InscripcionOrg = " + id_Inscripcion_Org + ")", CN);
            SqlDataReader Reader;
            query.Connection.Open();
            Reader = query.ExecuteReader();
            if (Reader.Read())
            {
                Prog = Reader.GetString(0);
                tipo_P = Reader.GetString(1);
            }
            query.Connection.Close();
        }
        #endregion
        #region OBTENER LA LISTA DE LAS TABLAS INSCRIPCION_PROVEEDOR => DOCUMENTO_PRESENTADO => DOCUMENTO_SOLICITADO
        public DataTable DA_Reporte_DOC_PROV_PRESENT(int Id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_REPORTE_VERIFICAION_DOC_PROV", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionProv", Id);
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
        /******************************* FUNCIONES DE PRODUCTOR ******************************************/
        #region OBTENER LA LISTA DE LAS TABLAS ORGANIZACION => INSCRIPCION_ORG => DOCUMENTO_PRESENTADO
        public DataTable DA_Desplegar_PRODUCTOR_INS(int IdInsOrg, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_PRODUCTOR_INS_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", IdInsOrg);
                    cmd.Parameters.AddWithValue("@Parametro", Parametro);
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
        #region OBTENER DATOS DEL PROVEEDOR PARA SU ENCABEZADO
        public DataTable DA_Desplegar_ENCAVEZADO_PROV(int IdInsProv)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_ENCABEZADO_PROD_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionProv", IdInsProv);
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
        /******************************* FUNCIONES DE USIARIOS ******************************************/
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        public DataTable DA_Desplegar_USUARIO(string IdUser)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_USUARIO_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUser", IdUser);
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
        #region EXTRE LA CAMPANHIA DE LA TABLA AP_INCRIPCION_ORG
        public Int32 DA_EXTRAE_COMPANHIA_DE_AP_INCRIPCION_ORG(Int32 id_InscripOrg)
        {
            Int32 Campanhia = -1;
            SqlConnection CN = new SqlConnection(conexionString);
            SqlCommand query = new SqlCommand("SELECT Id_Campanhia FROM  AP_INSCRIPCION_ORG WHERE (Id_InscripcionOrg = " + id_InscripOrg + ")", CN);
            SqlDataReader Reader;
            query.Connection.Open();
            Reader = query.ExecuteReader();
            if (Reader.Read())
            {
                Campanhia = Reader.GetInt32(0); ;
            }
            query.Connection.Close();
            return Campanhia;
        }
        #endregion 
        /******************************* FUNCIONES DE RESPONSABLE REGIONAL ******************************************/
        #region REPORTE DEL CRONOGRAMA DE LA REGIONAL 
        public DataTable DA_Reporte_CRONOGRAMA_REGIONAL(int IdCamp, int IdReg)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_REPORTE_CRONOGRAMAINI_REG", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Regional", IdReg);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", IdCamp);
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
