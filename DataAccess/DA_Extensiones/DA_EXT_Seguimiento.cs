using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataEntity.DE_Extensiones;

namespace DataAccess.DA_Extensiones
{
    public class DA_EXT_Seguimiento
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR SEGUIMIENTO 
        public void DA_Registrar_SEGUIMIENTO(EXT_Seguimiento seg)
        {
            try
            {
               using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", seg.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@Id_Usuario", seg.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Id_Productor", seg.Id_Productor);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", seg.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Regional", seg.Id_Regional);
                    cmd.Parameters.AddWithValue("@Programa", seg.Programa);
                    cmd.Parameters.AddWithValue("@Etapa", seg.Etapa);
                    cmd.Parameters.AddWithValue("@Num_Seg_Cultivo", seg.Num_Seg_Cultivo);
                    cmd.Parameters.AddWithValue("@Estado", seg.Estado);
                    cmd.Parameters.AddWithValue("@Fecha_Envio", seg.Fecha_Envio);
                    cmd.Parameters.AddWithValue("@Tipo_Seguimiento", seg.Tipo_Seguimiento);
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
        #region REGISTRAR SEGUIMIENTO PARCELA
        public void DA_Registrar_SEGUIMIENTO_PARCELA(EXT_SeguimientoParcela segParc)
        {
            try
            {
               using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_PARCELA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento", segParc.Id_Seguimiento);
                    cmd.Parameters.AddWithValue("@Boleta_Numero", segParc.Boleta_Numero);
                    cmd.Parameters.AddWithValue("@Fecha_Seg", segParc.Fecha_Seg);
                    cmd.Parameters.AddWithValue("@Hora_Seg", segParc.Hora_Seg);
                    cmd.Parameters.AddWithValue("@Fecha_Sis", segParc.Fecha_Sis);
                    cmd.Parameters.AddWithValue("@Observacion", segParc.Observacion);
                    cmd.Parameters.AddWithValue("@Recomendacion", segParc.Recomendacion);
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

        public void DA_Registrar_SEGUIMIENTO_PARCELA_UPDATE(EXT_SeguimientoParcela segParc)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_PARCELA_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento", segParc.Id_Seguimiento);
                    //cmd.Parameters.AddWithValue("@Boleta_Numero", segParc.Boleta_Numero);
                    //cmd.Parameters.AddWithValue("@Fecha_Seg", segParc.Fecha_Seg);
                    //cmd.Parameters.AddWithValue("@Hora_Seg", segParc.Hora_Seg);
                    //cmd.Parameters.AddWithValue("@Fecha_Sis", segParc.Fecha_Sis);
                    cmd.Parameters.AddWithValue("@Observacion", segParc.Observacion);
                    cmd.Parameters.AddWithValue("@Recomendacion", segParc.Recomendacion);
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
        #region REGISTRAR SEGUIMIENTO SIEMBRA
        public void DA_Registrar_SEGUIMIENTO_SIEMBRA(EXT_SeguimientoSiembra segS)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_SIEMBRA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento_Parcela", segS.Id_Seguimiento_Parcela);
                    cmd.Parameters.AddWithValue("@Fecha_SiembraINI", segS.Fecha_SiembraINI);
                    cmd.Parameters.AddWithValue("@Fecha_SiembraFIN", segS.Fecha_SiembraFIN);
                    cmd.Parameters.AddWithValue("@Sistema_Siembra", segS.Sistema_Siembra);
                    cmd.Parameters.AddWithValue("@Cultivo_Anterior", segS.Cultivo_Anterior);
                    cmd.Parameters.AddWithValue("@Variedad_Semilla", segS.Variedad_Semilla);
                    cmd.Parameters.AddWithValue("@Avance_Siembra", segS.Avance_Siembra);
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
        public void DA_SEGUIMIENTO_SIEMBRA_DELETE(int Id_Seguimiento_Parcela)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_SIEMBRA_DELETE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento_Parcela", Id_Seguimiento_Parcela);
                    //cmd.Parameters.AddWithValue("@CoordenadaX", segC.CoordenadaX);
                    //cmd.Parameters.AddWithValue("@CoordenadaY", segC.CoordenadaY);
                    //cmd.Parameters.AddWithValue("@Num_Parcela", segC.Num_Parcela);
                    //cmd.Parameters.AddWithValue("@Id_Productor", segC.Id_Productor);
                    //cmd.Parameters.AddWithValue("@Num_Punto", segC.Num_Punto);
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
        #region REGISTRAR SEGUIMIENTO COORDENADAS
        public void DA_Registrar_SEGUIMIENTO_COORDENADA(EXT_SeguimientoCoordenadas segC)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_COORDENADA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento_Parcela", segC.Id_Seguimiento_Parcela);
                    cmd.Parameters.AddWithValue("@CoordenadaX", segC.CoordenadaX);
                    cmd.Parameters.AddWithValue("@CoordenadaY", segC.CoordenadaY);
                    cmd.Parameters.AddWithValue("@Num_Parcela", segC.Num_Parcela);
                    cmd.Parameters.AddWithValue("@Id_Productor", segC.Id_Productor);
                    cmd.Parameters.AddWithValue("@Num_Punto", segC.Num_Punto);
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
        public void DA_Registrar_SEGUIMIENTO_COORDENADA_DELETE(int Id_Seguimiento_Parcela)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_COORDENADA_DELETE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento_Parcela", Id_Seguimiento_Parcela);
                    //cmd.Parameters.AddWithValue("@CoordenadaX", segC.CoordenadaX);
                    //cmd.Parameters.AddWithValue("@CoordenadaY", segC.CoordenadaY);
                    //cmd.Parameters.AddWithValue("@Num_Parcela", segC.Num_Parcela);
                    //cmd.Parameters.AddWithValue("@Id_Productor", segC.Id_Productor);
                    //cmd.Parameters.AddWithValue("@Num_Punto", segC.Num_Punto);
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
        #region REGISTRAR SEGUIMIENTO AL CULTIVO
        public void DA_Registrar_SEGUIMIENTO_CULTIVO(EXT_SeguimientoCultivo segC)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_CULTIVO_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento_Parcela", segC.Id_Seguimiento_Parcela);
                    cmd.Parameters.AddWithValue("@Id_Fenologia", segC.Id_Fenologia);
                    cmd.Parameters.AddWithValue("@Estado", segC.Estado);
                    cmd.Parameters.AddWithValue("@Porcentaje_FF", segC.Porcentaje_FF);
                    cmd.Parameters.AddWithValue("@Fecha_Cosecha", segC.Fecha_Cosecha);
                    //cmd.Parameters.AddWithValue("@Elemento", segC.Elemento);
                    //cmd.Parameters.AddWithValue("@Nombre_Elemento", segC.Nombre_Elemento);
                    //cmd.Parameters.AddWithValue("@Intencidad", segC.Intencidad);
                    //cmd.Parameters.AddWithValue("@Tratamiento", segC.Tratamiento);

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
        public void DA_SEGUIMIENTO_CULTIVO_DELETE(int Id_Seguimiento_Parcela)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_CULTIVO_DELETE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento_Parcela", Id_Seguimiento_Parcela);
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
        #region REGISTRAR ADVERSIDAD PRESENTADA EN EL CULTIVO
        public void DA_Registrar_ADVESIDAD(EXT_AdversidadPresentada advert)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_ADVERSIDAD_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento_Parcela", advert.Id_Seguimiento_Parcela);
                    cmd.Parameters.AddWithValue("@Adversidad", advert.Adversidad);
                    cmd.Parameters.AddWithValue("@Descripcion", advert.Descripcion);
                    cmd.Parameters.AddWithValue("@Intencidad", advert.Intencidad);
                    cmd.Parameters.AddWithValue("@Porcentage", advert.Porcentage);
                    cmd.Parameters.AddWithValue("@Tratamiento", advert.Tratamiento);
                    cmd.Parameters.AddWithValue("@Fecha_Ocurrencia", advert.Fecha_Ocurrencia);
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
        public void DA_ADVESIDAD_DELETE(int Id_Seguimiento_Parcela)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_ADVERSIDAD_PRESENTADA_DELETE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento_Parcela", Id_Seguimiento_Parcela);                    
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
        public DataTable DA_ADVESIDAD_GET(int Aux, int Id_Seguimiento)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();                    
                    SqlCommand cmd = new SqlCommand("EXT_ADVERSIDAD_PRESENTADA_GET", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento", Id_Seguimiento);
                    cmd.Parameters.AddWithValue("@Aux", Aux); 
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
        /// <summary>
        /// Agregar adversidad Plaga, Maleza, Enfermedad
        /// </summary>
        /// <param name="advert"></param>
        public void DA_Registrar_ADVESIDAD_PME(EXT_AdversidadPresentada advert)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_ADVERSIDAD_PME_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento_Parcela", advert.Id_Seguimiento_Parcela);
                    cmd.Parameters.AddWithValue("@Adversidad", advert.Adversidad);
                    cmd.Parameters.AddWithValue("@Descripcion", advert.Descripcion);
                    cmd.Parameters.AddWithValue("@Intencidad", advert.Intencidad);
                    cmd.Parameters.AddWithValue("@Porcentage", advert.Porcentage);
                    cmd.Parameters.AddWithValue("@Tratamiento", advert.Tratamiento);
                    cmd.Parameters.AddWithValue("@Fecha_Ocurrencia", advert.Fecha_Ocurrencia);
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
        public void DA_ADVESIDAD_PME_DELETE(int Id_Seguimiento_Parcela)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_ADVERSIDAD_PRESENTADA_PME_DELETE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento_Parcela", Id_Seguimiento_Parcela);
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
        #region Verificacion Siembra Cueltivo
        public DataTable DA_CONSULTAR_EXT_SEGUIMIENTO_PARCELA(int Etapa, int IdInsOrg)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_CONSULTAR_SEGUIMIENTO_PARCELA", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInsOrg ", IdInsOrg);
                    cmd.Parameters.AddWithValue("@Etapa ", Etapa);                
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
        public DataTable DA_CONSULTAR_EXT_SEGUIMIENTO_SIEMBRA(int Etapa, int IdInsOrg, string IdUsuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_CONSULTAR_SEGUIMIENTO_SIEMBRA", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInsOrg ", IdInsOrg);
                    cmd.Parameters.AddWithValue("@Etapa ", Etapa);
                    cmd.Parameters.AddWithValue("@IdUsuario ", IdUsuario);
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
        public DataTable DA_EXT_CONSULTAR_NOMBRE_MUNICIPIO(int IdInsOrg)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_CONSULTAR_NOMBRE_MUNICIPIO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInsOrg ", IdInsOrg);                    
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
        public DataTable DA_CONSULTAR_EXT_SEGUIMIENTO_CULTIVO(int IdInsOrg, string IdUsuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_CONSULTAR_SEGUIMIENTO_CULTIVO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInsOrg ", IdInsOrg);                    
                    cmd.Parameters.AddWithValue("@IdUsuario ", IdUsuario);
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
        public DataTable DA_CONSULTAR_EXT_ADVERSIDAD_PRESENTADA(int Etapa, int IdInsOrg, string IdUsuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_CONSULTAR_ADVERSIDAD_PRESENTADA", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInsOrg ", IdInsOrg);
                    cmd.Parameters.AddWithValue("@Etapa ", Etapa);
                    cmd.Parameters.AddWithValue("@IdUsuario ", IdUsuario);
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
        public DataTable DA_CONSULTAR_EXT_ADVERSIDAD_PRESENTADA_PME(int Etapa, int IdInsOrg, string IdUsuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_CONSULTAR_ADVERSIDAD_PRESENTADA_PME", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInsOrg ", IdInsOrg);
                    cmd.Parameters.AddWithValue("@Etapa ", Etapa);
                    cmd.Parameters.AddWithValue("@IdUsuario ", IdUsuario);
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
        #region REGISTRAR SEGUIMIENTO DISTRIBUCION SEMILLA Y AGROQUIMICO
        public void DA_Registrar_SEGUIMIENTO_DISTRIBUCION(EXT_SeguimientoDistribucion segDist)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_DISTRIBUCION_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento", segDist.Id_Seguimiento);
                    cmd.Parameters.AddWithValue("@Programa", segDist.Programa);
                    cmd.Parameters.AddWithValue("@Nom_Proveedor", segDist.Nom_Proveedor);
                    cmd.Parameters.AddWithValue("@Lugar_Distribucion", segDist.Lugar_Distribucion);
                    cmd.Parameters.AddWithValue("@Fecha_Sis", segDist.Fecha_Sis);
                    cmd.Parameters.AddWithValue("@Fecha_Distribucion", segDist.Fecha_Distribucion);
                    cmd.Parameters.AddWithValue("@Tipo_Insumo", segDist.Tipo_Insumo);
                    cmd.Parameters.AddWithValue("@Observacion", segDist.Observacion);
                    cmd.Parameters.AddWithValue("@Num_Boleta", segDist.Num_Boleta);
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
        #region REGISTRAR SEGUIMIENTO DISTRIBUCION SEMILLA Y AGROQUIMICO DETALLE
        public void DA_Registrar_DISTRIBUCION_DETALLE(EXT_SeguimientoDistribDetalle segDistDet)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_DISTRIBUCION_DETALLE_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seg_Distribucion", segDistDet.Id_Seg_Distribucion);
                    cmd.Parameters.AddWithValue("@Valor1", segDistDet.Valor1);
                    cmd.Parameters.AddWithValue("@Valor2", segDistDet.Valor2);
                    cmd.Parameters.AddWithValue("@Valor3", segDistDet.Valor3);
                    cmd.Parameters.AddWithValue("@Fecha_Caducidad", segDistDet.Fecha_Caducidad);
                    cmd.Parameters.AddWithValue("@Unidad", segDistDet.Unidad);
                    cmd.Parameters.AddWithValue("@Cantidad", segDistDet.Cantidad);
                    cmd.Parameters.AddWithValue("@Valor4", segDistDet.Valor4);
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
        #region REGISTRAR RENDIMIENTOS
        public void DA_Registrar_RENDIMIENTO(EXT_Rendimiento rd)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_RENDIMIENTO_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento", rd.Id_Seguimiento);
                    cmd.Parameters.AddWithValue("@Fecha_Sis", rd.Fecha_Sis);
                    cmd.Parameters.AddWithValue("@Fech_Inspeccion", rd.Fech_Inspeccion);
                    cmd.Parameters.AddWithValue("@Variedad_Semilla", rd.Variedad_Semilla);
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
        #region REGISTRAR RENDIMIENTOS DETALLE
        public void DA_Registrar_RENDIMIENTO_DETALLE(EXT_RendimientoDetalle rdd)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_RENDIMIENTO_DETALLE_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Rendimiento", rdd.Id_Rendimiento);
                    cmd.Parameters.AddWithValue("@Id_Fenologia", rdd.Id_Fenologia);
                    cmd.Parameters.AddWithValue("@Face_Fenologia", rdd.Face_Fenologia);
                    cmd.Parameters.AddWithValue("@Valor1", rdd.Valor1);
                    cmd.Parameters.AddWithValue("@Valor2", rdd.Valor2);
                    cmd.Parameters.AddWithValue("@Valor3", rdd.Valor3);
                    cmd.Parameters.AddWithValue("@Valor4", rdd.Valor4);
                    cmd.Parameters.AddWithValue("@Valor5", rdd.Valor5);
                    cmd.Parameters.AddWithValue("@Valor6", rdd.Valor6);
                    cmd.Parameters.AddWithValue("@Valor7", rdd.Valor7);
                    cmd.Parameters.AddWithValue("@Valor8", rdd.Valor8);
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
        #region REGISTRAR COSTOS
        public void DA_Registrar_COSTOS(EXT_Costos c)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_COSTOS_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tipo_Siembra", c.Tipo_Siembra);
                    cmd.Parameters.AddWithValue("@Superficie", c.Superficie);
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", c.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@Id_Productor", c.Id_Productor);
                    cmd.Parameters.AddWithValue("@Id_Seguimiento", c.Id_Seguimiento);
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
        #region REGISTRAR COSTOS DETALLE
        public void DA_Registrar_COSTOS_DETALLE(EXT_CostosDetalle cd)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_COSTOS_DETALLE_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Costos", cd.Id_Costos);
                    cmd.Parameters.AddWithValue("@Etapa_Cultivo", cd.Etapa_Cultivo);
                    cmd.Parameters.AddWithValue("@Insumo", cd.Insumo);
                    cmd.Parameters.AddWithValue("@Tipo_Recurso", cd.Tipo_Recurso);
                    cmd.Parameters.AddWithValue("@Producto", cd.Producto);
                    cmd.Parameters.AddWithValue("@Unidad", cd.Unidad);
                    cmd.Parameters.AddWithValue("@Cantidad", cd.Cantidad);
                    cmd.Parameters.AddWithValue("@Num_Apli", cd.Num_Apli);
                    cmd.Parameters.AddWithValue("@Precio_Unidad", cd.Precio_Unidad);
                    cmd.Parameters.AddWithValue("@Tipo_Adquicicion", cd.Tipo_Adquicicion);
                    cmd.Parameters.AddWithValue("@Costo_Total_Bs", cd.Costo_Total_Bs);
                    cmd.Parameters.AddWithValue("@Costo_Total_Sus", cd.Costo_Total_Sus);
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
        #region REGISTRAR COSTOS
        public void DA_Registrar_FECHA_SEG_COST(EXT_FechaSegCost fsc)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_FECH_SEG_COST_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento", fsc.Id_Seguimiento);
                    cmd.Parameters.AddWithValue("@Id_Costos", fsc.Id_Costos);
                    cmd.Parameters.AddWithValue("@Fecha_Seguimiento", fsc.Fecha_Seguimiento);
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
        #region REGISTRAR DATOS COSECHA
        public void DA_Registrar_DATOS_COSECHA(EXT_SeguimientoCosecha cos)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_COSECHA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento_Parcela", cos.Id_Seguimiento_Parcela);
                    cmd.Parameters.AddWithValue("@Rendimiento", cos.Rendimiento);
                    cmd.Parameters.AddWithValue("@Sup_Sembrada", cos.Sup_Sembrada);
                    cmd.Parameters.AddWithValue("@Peso_Aproximado", cos.Peso_Aproximado);
                    cmd.Parameters.AddWithValue("@Fecha_Siembra", cos.Fecha_Siembra);
                    cmd.Parameters.AddWithValue("@Placa_Camion", cos.Placa_Camion);
                    cmd.Parameters.AddWithValue("@Nom_Chofer", cos.Nom_Chofer);
                    cmd.Parameters.AddWithValue("@Centro_Acopio", cos.Centro_Acopio);
                    cmd.Parameters.AddWithValue("@Region", cos.Region);
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
        /***** LISTAS *****/
        #region SELECCIONAR SEGUIMIENTO REALIZADOS POR PRDUCTOR
        public DataTable DA_Desplegar_SEGUIMIENTOS_PROD(int IdInsOrg, string IdProductor, string Insumo,string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInscripcionOrg", IdInsOrg);
                    cmd.Parameters.AddWithValue("@Id_Productor", IdProductor);
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
        /// <summary>
        /// Recupera datos de registro de cultivo por productor
        /// </summary>
        /// <param name="IdProductor"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public DataTable DA_RECUPERAR_REGISTRO_CULTIVO(string IdProductor, string Etapa)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_MONITOREO_CULTIVO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    cmd.Parameters.AddWithValue("@Id_Productor", IdProductor);
                    cmd.Parameters.AddWithValue("@Etapa", Etapa);                   
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
        /// <summary>
        /// Obtiene listado, seguimiento pendientes ACTIVOS
        /// </summary>
        /// <returns></returns>
        public DataTable DA_Desplegar_SEGUIMIENTOS_PENDIENTE()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTOS_PENDIENTE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;                   
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
        /********** REPORTES ***********/
        #region SELECCIONAR LA DISTRIBUCION DE INSUMOS SEMILLA Y QUIMICO
        public DataTable DA_Reporte_DISTRIBUCION_DETALLE(int IdInsOrg, string Insumo, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_DISTRIBUCION_REPORTE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", IdInsOrg);
                    cmd.Parameters.AddWithValue("@Insumo", Insumo);
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
        #region SELECCIONAR LA DISTRIBUCION DE INSUMOS SEMILLA Y QUIMICO
        public DataTable DA_Reporte_SEGUIMIENTOS(int IdSeguimiento, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_REPORTES_SEGUIMIENTO_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento", IdSeguimiento);
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
        /*************************************** SEGUIMIENTO A LOS TECNICOS *********************************************/
        #region SELECCIONAR SEGUIMIENTO REALIZADOS POR PRDUCTOR
        public DataTable DA_Desplegar_SEGUIMIENTO_A_TECNICOS(string IdUsuario, string Programa, int IdCampanhia, int IdRegional, string Parametro)
        {
              try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_TEC_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario",  IdUsuario);
                    cmd.Parameters.AddWithValue("@Programa", Programa);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", IdCampanhia);
                    cmd.Parameters.AddWithValue("@Id_Regional", IdRegional);
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
        public DateTime DA_ObtenerFechaServer()
        {
            string queryString = "SELECT GETDATE()";
            using (SqlConnection connection = new SqlConnection(conexionString))
            {
                SqlCommand rep = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader myReader = rep.ExecuteReader();
                DateTime fechasever = new DateTime();
                if (myReader.Read())
                {
                    fechasever = Convert.ToDateTime(myReader[0].ToString());
                }
                connection.Close();
                return fechasever;
            }
        }
        /*****************/
        #region CAMBIAR EL ESTADO DE LA SOLICITUD DE VIAJE
        public void DA_Cambiar_ESTADO_SEGUIMIENTO(string IdSeguimiento, string estado)
        {
            try
            {
                string queryString = "UPDATE EXT_SEGUIMIENTO SET Estado = '" + estado + "' WHERE Id_Seguimiento = " + IdSeguimiento + " ";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.Close();
                    //return dt;
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion

        #region SELECCIONAR EL NUMERO DE BOLETA DE SEGUIMIENTO REALIZADO
        public DataTable DA_Seleccionar_NUM_BOLETA_SEG(int IdSeguimiento, string etapa)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_NUM_BOLETA_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Seguimiento", IdSeguimiento);
                    cmd.Parameters.AddWithValue("@Etapa", etapa);
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

        #region SEGUIMIENTO DE CULTIVO SEGUN FASE FENOLOGICA
        /// <summary>
        /// Registra seguimiento de fase fenologica segun fase fenologica
        /// </summary>
        /// <param name="ObjFaseF"></param>
        /// <returns></returns>
        public void DA_INSERT_SEG_CULTIVO_FASE_FENOLOGIA(List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColFaseF)
        {
            try
            {
                foreach(EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ObjFaseF in ColFaseF)
                {
                    using (SqlConnection conexion = new SqlConnection(conexionString))
                    {
                        SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_CULTIVO_SEGUN_FASE_FENOLOGICA_INSERT", conexion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Reporte_Fecha_Inicio", ObjFaseF.Reporte_Fecha_Inicio);
                        cmd.Parameters.AddWithValue("@Reporte_Fecha_Fin", ObjFaseF.Reporte_Fecha_Fin);
                        cmd.Parameters.AddWithValue("@Campania", ObjFaseF.Campania);
                        cmd.Parameters.AddWithValue("@Id_Regional", ObjFaseF.Id_Regional);
                        cmd.Parameters.AddWithValue("@Zona", ObjFaseF.Zona);
                        cmd.Parameters.AddWithValue("@Organizacion", ObjFaseF.Organizacion);
                        cmd.Parameters.AddWithValue("@Ppsemanal", ObjFaseF.Ppsemanal);
                        cmd.Parameters.AddWithValue("@FechaSiembraInicio", ObjFaseF.FechaSiembraInicio);
                        cmd.Parameters.AddWithValue("@FechaSiembraFinal", ObjFaseF.FechaSiembraFinal);
                        cmd.Parameters.AddWithValue("@AvanceSiembra", ObjFaseF.AvanceSiembra);
                        cmd.Parameters.AddWithValue("@Germinacion", ObjFaseF.Germinacion);
                        cmd.Parameters.AddWithValue("@Plantula", ObjFaseF.Plantula);
                        cmd.Parameters.AddWithValue("@Macollamiento", ObjFaseF.Macollamiento);
                        cmd.Parameters.AddWithValue("@Embuche", ObjFaseF.Embuche);
                        cmd.Parameters.AddWithValue("@Espigazon", ObjFaseF.Espigazon);
                        cmd.Parameters.AddWithValue("@Floracion", ObjFaseF.Floracion);
                        cmd.Parameters.AddWithValue("@Grano", ObjFaseF.Grano);
                        cmd.Parameters.AddWithValue("@Maduracion", ObjFaseF.Maduracion);
                        cmd.Parameters.AddWithValue("@AvanceCosecha", ObjFaseF.AvanceCosecha);
                        cmd.Parameters.AddWithValue("@Rend", ObjFaseF.Rend);
                        cmd.Parameters.AddWithValue("@FechaCosechaInicial", ObjFaseF.FechaCosechaInicial);
                        cmd.Parameters.AddWithValue("@FechaCosechaFinal", ObjFaseF.FechaCosechaFinal);
                        cmd.Parameters.AddWithValue("@Observaciones", ObjFaseF.Observaciones);
                        cmd.Parameters.AddWithValue("@PromedioAvanceSiembra", ObjFaseF.PromedioAvanceSiembra);
                        cmd.Parameters.AddWithValue("@PromedioAvanceCosecha", ObjFaseF.PromedioAvanceCosecha);
                        cmd.Parameters.AddWithValue("@PromedioRend", ObjFaseF.PromedioRend);
                        cmd.Parameters.AddWithValue("@Elaboradopor", ObjFaseF.Elaboradopor);
                        cmd.Parameters.AddWithValue("@VoBo", ObjFaseF.VoBo);
                        cmd.Parameters.AddWithValue("@Id_Usuario", ObjFaseF.Id_Usuario);
                        cmd.Parameters.AddWithValue("@Programa", ObjFaseF.Programa);//@Programa
                        
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }

        public void DA_DELETE_SEG_CULTIVO_FASE_FENOLOGIA(string Id_Usuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {       
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_CULTIVO_SEGUN_FASE_FENOLOGICA_DELETE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);                    
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
        /// <summary>
        /// Obtiene todos los datos de la fase fenologica
        /// </summary>
        /// <returns></returns>
        public DataTable DA_GET_SEG_CULTIVO_FASE_FENOLOGIA()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_GET_CULTIVO_FASE_FENOLOGICA", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@IdRegional", idreg);
                    //cmd.Parameters.AddWithValue("@IdCampanhia", idcamp);
                    //cmd.Parameters.AddWithValue("@Programa", programa);
                    //cmd.Parameters.AddWithValue("@Year", year);
                    //cmd.Parameters.AddWithValue("@Month", month);
                    //cmd.Parameters.AddWithValue("@Parametro", parametro);
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
        /// <summary>
        /// Obtiene  total de promedios segun registro seguimiento_fase_fenologica
        /// </summary>
        /// <returns></returns>
        public DataTable DA_GET_REP_EST_FENOLOGICO()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_GET_REP_ESTADO_FENOLOGICO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;                   
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
        /// <summary>
        /// Obtiene etapas seguimiento_fase_fenologica (Germinacion,Plantula, etc)
        /// </summary>
        /// <returns></returns>
        public DataTable DA_GET_ETAPAS_FASE_FENOLOGICA()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_SEGUIMIENTO_GET_ETAPAS_FASE_FENOLOGICA_DETALLE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
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
