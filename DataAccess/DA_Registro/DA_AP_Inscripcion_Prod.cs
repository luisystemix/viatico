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
    public class DA_AP_Inscripcion_Prod
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR LOS DATOS DE UNA PERSONA
        public void DA_Registrar_AP_INSCRIPCION_PROD(AP_Productor p)
        {
            try
            {
                //using (SqlConnection conexion = new SqlConnection(conexionString))
                //{
                //    SqlCommand cmd = new SqlCommand("INSERT INTO AP_INSCRIPCION_PROD(Id_Productor,Id_Persona,Id_Comunidad,Id_InscripcionOrg,Id_Campanhia,Programa,Tipo_Inscripcion,Tipo_Produccion,Has_Inscrito,Has_Ejecutado,Has_Propio,Rau,Estado,Observacion) Values (@Id_Productor,@Id_Persona,@Id_Comunidad,@Id_InscripcionOrg,@Id_Campanhia,@Programa,@Tipo_Inscripcion,@Tipo_Produccion,@Has_Inscrito,@Has_Ejecutado,@Has_Propio,@Rau,@Estado,@Observacion)", conexion);
                //    cmd.CommandType = System.Data.CommandType.Text;
                //    cmd.Parameters.AddWithValue("@Id_Productor", p.Id_Productor);
                //    cmd.Parameters.AddWithValue("@Id_Persona", p.Id_Persona);
                //    cmd.Parameters.AddWithValue("@Id_Comunidad", p.Id_Comunidad);
                //    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", p.Id_InscripcionOrg);
                //    cmd.Parameters.AddWithValue("@Id_Campanhia", p.Id_Campanhia);
                //    cmd.Parameters.AddWithValue("@Programa", p.Programa);
                //    cmd.Parameters.AddWithValue("@Tipo_Inscripcion", p.Tipo_Inscripcion);
                //    cmd.Parameters.AddWithValue("@Tipo_Produccion", p.Tipo_Produccion);
                //    cmd.Parameters.AddWithValue("@Has_Inscrito", p.Has_Inscrito);
                //    cmd.Parameters.AddWithValue("@Has_Ejecutado", p.Has_Ejecutado);
                //    cmd.Parameters.AddWithValue("@Has_Propio", p.Has_Propio);
                //    cmd.Parameters.AddWithValue("@Rau", p.Rau);
                //    cmd.Parameters.AddWithValue("@Estado", p.Estado);
                //    cmd.Parameters.AddWithValue("@Observacion", p.Observacion);
                //    conexion.Open();
                //    cmd.ExecuteNonQuery();
                //    conexion.Close();
                //}
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_INSCRIPCION_PROD_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Productor", p.Id_Productor);
                    cmd.Parameters.AddWithValue("@Id_Persona", p.Id_Persona);
                    cmd.Parameters.AddWithValue("@Id_Comunidad", p.Id_Comunidad);
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", p.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", p.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Programa", p.Programa);
                    cmd.Parameters.AddWithValue("@Tipo_Inscripcion", p.Tipo_Inscripcion);
                    cmd.Parameters.AddWithValue("@Tipo_Produccion", p.Tipo_Produccion);
                    cmd.Parameters.AddWithValue("@Has_Inscrito", p.Has_Inscrito);
                    cmd.Parameters.AddWithValue("@Has_Ejecutado", p.Has_Ejecutado);
                    cmd.Parameters.AddWithValue("@Has_Propio", p.Has_Propio);
                    cmd.Parameters.AddWithValue("@Rau", p.Rau);
                    cmd.Parameters.AddWithValue("@Estado", p.Estado);
                    cmd.Parameters.AddWithValue("@Observacion", p.Observacion);
                    //**new
                    cmd.Parameters.AddWithValue("@Departamento", p.Departamento);
                    cmd.Parameters.AddWithValue("@Id_Provincia", p.Id_Provincia);
                    cmd.Parameters.AddWithValue("@Id_Municipio", p.Id_Municipio);
                    cmd.Parameters.AddWithValue("@Id_Organizacion", p.Id_Organizacion);
                    cmd.Parameters.AddWithValue("@Id_Credito", p.Id_Credito);
                    //**
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
        #region SELECCIONAR EL MAXIMO CODIGO POR CAMPANHIA
        public Int32 DA_SELEC_MAX_COD_AP_INSCIPCION_PROD(Int32 idReg, Int32 id_Campanihia, String Programa)
        {
            Int32 cod = 0;
            String cod2;
            SqlConnection CN = new SqlConnection(conexionString);
            SqlCommand query = new SqlCommand("SELECT MAX(AP_INSCRIPCION_PROD.Id_Productor) AS codmax FROM AP_INSCRIPCION_PROD INNER JOIN AP_INSCRIPCION_ORG ON AP_INSCRIPCION_PROD.Id_InscripcionOrg = AP_INSCRIPCION_ORG.Id_InscripcionOrg WHERE (AP_INSCRIPCION_PROD.Programa = '"+ Programa +"') AND (AP_INSCRIPCION_PROD.Id_Campanhia = "+ id_Campanihia +") AND (AP_INSCRIPCION_ORG.Id_Regional = "+ idReg +")", CN);
            SqlDataReader Reader;
            query.Connection.Open();
            Reader = query.ExecuteReader();
            if (Reader.Read())
            {
                try
                {
                    cod2 = Reader.GetString(0);
                    Char[] x = { '-' };
                    String[] arr = cod2.Split(x);
                    cod = Convert.ToInt32(arr[1]);
                    cod = cod + 1;
                }
                catch
                { cod = 1; }
            }
            query.Connection.Close();
            return cod;
        }
        #endregion
        #region ACTUALIZAR LOS DATOS DE UNA PERSONA
        public void DA_Actualizar_AP_INSCRIPCION_PROD(AP_Productor p)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE AP_INSCRIPCION_PROD set Id_Comunidad=@Id_Comunidad, Id_InscripcionOrg=@Id_InscripcionOrg, Id_Campanhia=@Id_Campanhia, Programa=@Programa, Tipo_Inscripcion=@Tipo_Inscripcion, Tipo_Produccion=@Tipo_Produccion, Has_Inscrito=@Has_Inscrito, @Has_Ejecutado=Has_Ejecutado, Has_Propio=@Has_Propio, Rau=@Rau, Estado=@Estado where Id_Productor = @Id_Productor", conexion);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id_Productor", p.Id_Productor);
                    cmd.Parameters.AddWithValue("@Id_Persona", p.Id_Persona);
                    cmd.Parameters.AddWithValue("@Id_Comunidad", p.Id_Comunidad);
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", p.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", p.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Programa", p.Programa);
                    cmd.Parameters.AddWithValue("@Tipo_Inscripcion", p.Tipo_Inscripcion);
                    cmd.Parameters.AddWithValue("@Tipo_Produccion", p.Tipo_Produccion);
                    cmd.Parameters.AddWithValue("@Has_Inscrito", p.Has_Inscrito);
                    cmd.Parameters.AddWithValue("@Has_Ejecutado", p.Has_Ejecutado);
                    cmd.Parameters.AddWithValue("@Has_Propio", p.Has_Propio);
                    cmd.Parameters.AddWithValue("@Rau", p.Rau);
                    cmd.Parameters.AddWithValue("@Estado", p.Estado);
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
        #region MODIFICAR LOS EL ESTADO DE LA TABLA INSCRIOCION PRODUCTOR
        public void DA_Modificar_ESTADO(AP_InscripcionProd ip)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_INSCRIPCION_PROD_ESTADO_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Productor", ip.Id_Productor);
                    cmd.Parameters.AddWithValue("@Estado", ip.Estado);
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

        #region ACTUALIZAR LOS DATOS DE UNA PERSONA
        public void DA_Modificar_SUPEFICIE(AP_Productor p)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("INS_DISTRIBUCION_SUPPROD_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Productor", p.Id_Productor);
                    cmd.Parameters.AddWithValue("@Has_Ejecutado", p.Has_Ejecutado);
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
