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
    public class DA_AP_ContratoOrg
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR NUEVO CONTRATO
        public void DA_Registrar_CONTRATO_ORG(AP_ContratoOrg c)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_CONTRATO_ORG_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", c.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@Num_Contrato", c.Num_Contrato);
                    cmd.Parameters.AddWithValue("@Ci_RepLegalEmapa", c.Ci_RepLegalEmapa);
                    cmd.Parameters.AddWithValue("@ResolucionAdmin", c.ResolucionAdmin);
                    cmd.Parameters.AddWithValue("@FechaResAdmin", c.FechaResAdmin);
                    cmd.Parameters.AddWithValue("@Domicilio", c.Domicilio);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);
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
