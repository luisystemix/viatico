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
    public class DA_AP_RepresentLegalProv
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR AL REPRESENTANTE LEGAL DE UN PROVEEDOR
        public void DA_Registrar_REPRESENT_LEGAL_PROV(AP_RepresentLegalProv rlp)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_REPRESENTANTE_LEGAL_PROV_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionProv", rlp.Id_InscripcionProv);
                    cmd.Parameters.AddWithValue("@Id_Persona", rlp.Id_Persona);
                    cmd.Parameters.AddWithValue("@Tipo_Poder", rlp.Tipo_Poder);
                    cmd.Parameters.AddWithValue("@Num_Testimonio", rlp.Num_Testimonio);
                    cmd.Parameters.AddWithValue("@Domicilio", rlp.Domicilio);
                    cmd.Parameters.AddWithValue("@Fecha", rlp.Fecha);
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
        #region BUSCAR AL REPRESENTANTE LEGAL DE UNA EMPRESA PROVEEDORA POR EL ID DE INSCRIPCION
        public DataTable DA_Buscar_REPRESENT_LEGAL_PROV(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_REPRESENTANTE_LEGAL_PROV_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionProv", id);
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
        #region FUNCION PARA MODIFICAR AL REPRESNTANTE LEGAL DE LA EMPRESA PROVEEDORA
        public void DA_Modificar_REPRESENT_LEGAL_PROV(AP_RepresentLegalProv rlp)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_REPRESENTANTE_LEGAL_PROV_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionProv", rlp.Id_InscripcionProv);
                    cmd.Parameters.AddWithValue("@Tipo_Poder", rlp.Tipo_Poder);
                    cmd.Parameters.AddWithValue("@Num_Testimonio", rlp.Num_Testimonio);
                    cmd.Parameters.AddWithValue("@Fecha", rlp.Fecha);
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
