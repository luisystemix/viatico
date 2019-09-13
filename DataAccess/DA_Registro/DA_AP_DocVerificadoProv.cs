using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataEntity.DE_Registro;

namespace DataAccess.DA_Registro
{
    public class DA_AP_DocVerificadoProv
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region FUNCION PARA REGISTRAR A LA TABLA DE DOCUMENTOS SOLICITADOS VERIFICACION DE DOCUMENTOS DE LOS PROVEEDORES
        public void DA_Registrar_DOC_VERIFICADO_PROV(AP_DocVerificadoProv dv)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_DOC_VERIFICADO_PROV_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_VerificarDocProv", dv.Id_VerificarDocProv);
                    cmd.Parameters.AddWithValue("@Id_InscripcionProv", dv.Id_InscripcionProv);
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
    }
}
