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
    public class DA_AP_DocPresentadoProv
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR LOS DOCUMENTOS SOLICITADOS POR CAMPAÑA A LOS PROVEEDORES
        public void DA_Registrar_DOC_PRESENTADO_PROV(int Id_InsProv, int Id_Campanhia, int tipo)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_DOC_PRESENTADO_PROV_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionProv", Id_InsProv);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Tipo", tipo);
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
        #region MODIFICAR EL ESTADO DE LOS DOCUMENTOS PRESENTADOS POR EL PROVEEDOR y SU OBSERVACION
        public void DA_Modificar_ESTADO(AP_DocPresentadoProv dpv)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_DOCUMENTO_PRESENTADO_PROV_ESTADO_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_VerificarDocProv", dpv.Id_VerificarDoc);
                    cmd.Parameters.AddWithValue("@Id_Documento", dpv.Id_Documento);
                    cmd.Parameters.AddWithValue("@Observacion", dpv.Observacion);
                    cmd.Parameters.AddWithValue("@Estado", dpv.Estado);
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
