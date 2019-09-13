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
    public class DA_AP_Plano_Ubicacion
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR LOS DATOS DE UNA PERSONA
        public void DA_Registrar_AP_PLANO_UBICACION(AP_PlanoUbicacion p)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO AP_PLANO_UBICACION(Id_Plano,Id_Productor,Comunidad,Numero_Parcela,Superficie_Doc,Superficie_Mensura,Observacion) Values (@Id_Plano,@Id_Productor,@Comunidad,@Numero_Parcela,@Superficie_Doc,@Superficie_Mensura,@Observacion)", conexion);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id_Plano", p.Id_Plano);
                    cmd.Parameters.AddWithValue("@Id_Productor", p.Id_Productor);
                    cmd.Parameters.AddWithValue("@Comunidad", p.Comunidad);
                    cmd.Parameters.AddWithValue("@Numero_Parcela", p.Numero_Parcela);
                    cmd.Parameters.AddWithValue("@Superficie_Doc", p.Superficie_Doc);
                    cmd.Parameters.AddWithValue("@Superficie_Mensura", p.Superficie_Mensura);
                    cmd.Parameters.AddWithValue("@Observacion", p.Observacion);
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
        #region VERIFICAR EL PLANO DE UBICACION
        public Boolean DA_Verificar_AP_PLANO_UBICACION(String id_Productor)
        {
            Boolean Resp = false;
            SqlConnection CN = new SqlConnection(conexionString);
            SqlCommand query = new SqlCommand("SELECT Id_Productor FROM  AP_PLANO_UBICACION WHERE (Id_Productor = '" + id_Productor + "')", CN);
            SqlDataReader Reader;
            query.Connection.Open();
            Reader = query.ExecuteReader();
            if (Reader.Read())
            {
                Resp = true;
            }
            query.Connection.Close();
            return Resp;
        }
        #endregion
        #region SELECCIONA EL MAXIMO CODIGO
        public Int32 DA_SELCCIONA_MAX_CODIGO()
        {
            Int32 Cod = 0;
            SqlConnection CN = new SqlConnection(conexionString);
            SqlCommand query = new SqlCommand("SELECT MAX(Id_Plano) As idd FROM  AP_PLANO_UBICACION", CN);
            SqlDataReader Reader;
            query.Connection.Open();
            Reader = query.ExecuteReader();
            if (Reader.Read())
            {
                try
                {
                    Cod = Reader.GetInt32(0) + 1;
                }
                catch { Cod = 1; }
            }
            query.Connection.Close();
            return Cod;
        }
        #endregion 
    }
}
