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
    public class DA_EXT_Fenologia
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region DESPLEGAR EL CICLO FENOLOGICO SEGUN PROGRAMA
        public DataTable DA_Desplegar_FENOLOGIA(string programa, string idprod)
        {
            try
            {
                string queryString = "SELECT Id_Fenologia, Nom_Fenologia, Programa  FROM EXT_FENOLOGIA WHERE Programa ='" + programa + "' AND Id_Fenologia > =  (SELECT     MAX(EXT_SEGUIMIENTO_CULTIVO.Id_Fenologia) ";
                queryString += "FROM EXT_SEGUIMIENTO INNER JOIN EXT_SEGUIMIENTO_PARCELA ON EXT_SEGUIMIENTO.Id_Seguimiento = EXT_SEGUIMIENTO_PARCELA.Id_Seguimiento INNER JOIN ";
                queryString += "EXT_SEGUIMIENTO_CULTIVO ON EXT_SEGUIMIENTO_PARCELA.Id_Seguimiento_Parcela = EXT_SEGUIMIENTO_CULTIVO.Id_Seguimiento_Parcela INNER JOIN ";
                queryString += "EXT_FENOLOGIA ON EXT_SEGUIMIENTO_CULTIVO.Id_Fenologia = EXT_FENOLOGIA.Id_Fenologia ";
                queryString += "WHERE EXT_SEGUIMIENTO.Id_Productor='" + idprod + "' AND (EXT_FENOLOGIA.Nom_Fenologia <> 'FECHA COSECHA PROBABLE'))";
                                      using (SqlConnection conexion = new SqlConnection(conexionString))
                                      {
                                          conexion.Open();
                                          SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                                          DataTable dt = new DataTable();
                                          da.Fill(dt);
                                          conexion.Close();
                                          if (dt.Rows.Count > 0)
                                          {
                                              return dt;
                                          }
                                          else
                                          {
                                              queryString = "SELECT Id_Fenologia, Nom_Fenologia, Programa FROM EXT_FENOLOGIA WHERE Programa ='" + programa + "'";
                                              using (SqlConnection conexion1 = new SqlConnection(conexionString))
                                              {
                                                  conexion.Open();
                                                  da = new SqlDataAdapter(queryString, conexion1);
                                                  dt = new DataTable();
                                                  da.Fill(dt);
                                                  conexion.Close();
                                                  return dt;
                                              }
                                          }
                                      }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        #region DESPLEGAR FASES FENOLOGICAS SEGUN PROGRAMA
        public DataTable DA_get_fases_fenologicas(string programa)
        {
            try
            {
                string queryString = "SELECT * FROM EXT_FASES_FENOLOGICAS WHERE PROGRAMA LIKE '%" + programa + "%'";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
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
        #region DESPLEGAR EL CICLO FENOLOGICO SEGUN PROGRAMA Y PRODUCTOR
        public DataTable DA_Desplegar_FENOLOGIA_PRODUCTOR(string programa, string IdProductor)
        {
            try
            {
                //string queryString = "SELECT DISTINCT EXT_SEGUIMIENTO_CULTIVO.Id_Fenologia, EXT_FENOLOGIA.Nom_Fenologia FROM EXT_SEGUIMIENTO_CULTIVO INNER JOIN ";
                //       queryString += "EXT_SEGUIMIENTO_PARCELA ON EXT_SEGUIMIENTO_CULTIVO.Id_Seguimiento_Parcela = EXT_SEGUIMIENTO_PARCELA.Id_Seguimiento_Parcela INNER JOIN ";
                //       queryString += "EXT_SEGUIMIENTO ON EXT_SEGUIMIENTO_PARCELA.Id_Seguimiento = EXT_SEGUIMIENTO.Id_Seguimiento INNER JOIN ";
                //       queryString += "EXT_FENOLOGIA ON EXT_SEGUIMIENTO_CULTIVO.Id_Fenologia = EXT_FENOLOGIA.Id_Fenologia WHERE EXT_SEGUIMIENTO.Id_Productor='" + IdProductor + "' AND EXT_SEGUIMIENTO.Programa ='" + programa + "'";
                string queryString = "SELECT DISTINCT Id_Fenologia, Nom_Fenologia FROM EXT_FENOLOGIA WHERE Programa = '" + programa + "' AND Id_Fenologia <> 25 AND Id_Fenologia <> 34 AND Id_Fenologia <> 35 ";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
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
        #region OBTENER DATOS DE EL NUMERO DE BOLETAS DEL SEGUIMIENTO AL CULTIVO 
        public DataTable DA_Datos_FACE_FENOLOGICA(int IdInscripcionOrg, int idCamp, int IdFenologia, int idReg, string Programa, string estado, int numseg, DateTime fecha, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_FENOLOGIA_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInscripcionOrg", IdInscripcionOrg);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", idCamp);
                    cmd.Parameters.AddWithValue("@IdFenologia", IdFenologia);
                    cmd.Parameters.AddWithValue("@Id_Regional", idReg);
                    cmd.Parameters.AddWithValue("@Programa", Programa);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.Parameters.AddWithValue("@NuSeg", numseg);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
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
        #region OBTENER DATOS DE EL NUMERO DE BOLETAS DEL SEGUIMIENTO A LA SIEMBRA
        public DataTable DA_Datos_SIEMBRA(int IdInscripcionOrg, string Programa, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_SIEMBRA_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInscripcionOrg", IdInscripcionOrg);
                    cmd.Parameters.AddWithValue("@Programa", Programa);
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

        #region REGISTRAR FACE FENOLOGIA DEL CULTIVO EN GENERAL
        public void DA_Registrar_FACE_FENOLOGICA_CULTIVO(EXT_FaceFenologicaCultivo ffcultivo)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_FACE_FENOLOGICA_CULTIVO_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", ffcultivo.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Regional", ffcultivo.Id_Regional);
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", ffcultivo.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@Id_Usuario", ffcultivo.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Programa", ffcultivo.Programa);
                    cmd.Parameters.AddWithValue("@Fecha_Registro", ffcultivo.Fecha_Registro);
                    cmd.Parameters.AddWithValue("@Num_Boletas_Inspec", ffcultivo.Num_Boletas_Inspec);
                    cmd.Parameters.AddWithValue("@Charla_Tecnica", ffcultivo.Charla_Tecnica);
                    cmd.Parameters.AddWithValue("@Num_Prod_Vigentes", ffcultivo.Num_Prod_Vigentes);
                    cmd.Parameters.AddWithValue("@Sup_Actual", ffcultivo.Sup_Actual);
                    cmd.Parameters.AddWithValue("@Variedad_Semilla", ffcultivo.Variedad_Semilla);
                    cmd.Parameters.AddWithValue("@Observacion", ffcultivo.Observacion);
                    cmd.Parameters.AddWithValue("@Num_Seg_Cultivo", ffcultivo.Num_Seg_Cultivo);
                    cmd.Parameters.AddWithValue("@Num_Boletas_Monitoreo", ffcultivo.Num_Boletas_Monitoreo);
                    cmd.Parameters.AddWithValue("@Precipitacion_Pluvial", ffcultivo.Precipitacion_Pluvial);
                    cmd.Parameters.AddWithValue("@Fecha_Semana_Envio", ffcultivo.Fecha_Semana_Envio);
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
        #region REGISTRAR FACE FENOLOGIA TRIGO
        public void DA_Registrar_FACE_FENOLOGICA_TRIGO(EXT_FaceFenologiaTrigo fftrigo)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_FACE_FENOLOGICA_TRIGO_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Face_Feonologica", fftrigo.Id_Face_Feonologica);
                    cmd.Parameters.AddWithValue("@FechaAvnSiemIni", fftrigo.FechaAvnSiemIni);
                    cmd.Parameters.AddWithValue("@FechaAvnSiemFin", fftrigo.FechaAvnSiemFin);
                    cmd.Parameters.AddWithValue("@FechaAvnSiemAvan", fftrigo.FechaAvnSiemAvan);
                    cmd.Parameters.AddWithValue("@GerminacionIni", fftrigo.GerminacionIni);
                    cmd.Parameters.AddWithValue("@GerminacionFin", fftrigo.GerminacionFin);
                    cmd.Parameters.AddWithValue("@PlantulaIni", fftrigo.PlantulaIni);
                    cmd.Parameters.AddWithValue("@PlantulaFin", fftrigo.PlantulaFin);
                    cmd.Parameters.AddWithValue("@MacollamientoIni", fftrigo.MacollamientoIni);
                    cmd.Parameters.AddWithValue("@MacollamientoFin", fftrigo.MacollamientoFin);
                    cmd.Parameters.AddWithValue("@EmbucheIni", fftrigo.EmbucheIni);
                    cmd.Parameters.AddWithValue("@EmbucheFin", fftrigo.EmbucheFin);
                    cmd.Parameters.AddWithValue("@EspigazonIni", fftrigo.EspigazonIni);
                    cmd.Parameters.AddWithValue("@EspigazonFin", fftrigo.EspigazonFin);
                    cmd.Parameters.AddWithValue("@FloracionIni", fftrigo.FloracionIni);
                    cmd.Parameters.AddWithValue("@FloracionFin", fftrigo.FloracionFin);
                    cmd.Parameters.AddWithValue("@LlenadoGranoIni", fftrigo.LlenadoGranoIni);
                    cmd.Parameters.AddWithValue("@LlenadoGranoFin", fftrigo.LlenadoGranoFin);
                    cmd.Parameters.AddWithValue("@MaduracionIni", fftrigo.MaduracionIni);
                    cmd.Parameters.AddWithValue("@MaduracionFin", fftrigo.MaduracionFin);
                    cmd.Parameters.AddWithValue("@CosechaAcopioAvan", fftrigo.CosechaAcopioAvan);
                    cmd.Parameters.AddWithValue("@CosechaAcopioRend", fftrigo.CosechaAcopioRend);
                    cmd.Parameters.AddWithValue("@FechaCosechaIni", fftrigo.FechaCosechaIni);
                    cmd.Parameters.AddWithValue("@FechaCosechaFin", fftrigo.FechaCosechaFin);
                    cmd.Parameters.AddWithValue("@Tipo", fftrigo.Tipo);
                    cmd.Parameters.AddWithValue("@SupSem", fftrigo.SupSem);
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
        #region REGISTRAR FACE FENOLOGIA MAIZ
        public void DA_Registrar_FACE_FENOLOGICA_MAIZ(EXT_FaceFenologiaMaiz ffMaiz)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_FACE_FENOLOGICA_MAIZ_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Face_Feonologica", ffMaiz.Id_Face_Feonologica);
                    cmd.Parameters.AddWithValue("@FechaAvnSiemIni", ffMaiz.FechaAvnSiemIni);
                    cmd.Parameters.AddWithValue("@FechaAvnSiemFin", ffMaiz.FechaAvnSiemFin);
                    cmd.Parameters.AddWithValue("@FechaAvnSiemAvan", ffMaiz.FechaAvnSiemAvan);
                    cmd.Parameters.AddWithValue("@Emergencia5dias", ffMaiz.Emergencia5dias);
                    cmd.Parameters.AddWithValue("@HojasDesplegadas1y2", ffMaiz.HojasDesplegadas1y2);
                    cmd.Parameters.AddWithValue("@HojasDesplegadas3y4", ffMaiz.HojasDesplegadas3y4);
                    cmd.Parameters.AddWithValue("@HojasDesplegadas5y6", ffMaiz.HojasDesplegadas5y6);
                    cmd.Parameters.AddWithValue("@HojasDesplegadas7y8", ffMaiz.HojasDesplegadas7y8);
                    cmd.Parameters.AddWithValue("@HojasDesplegadas9y10", ffMaiz.HojasDesplegadas9y10);
                    cmd.Parameters.AddWithValue("@HojasDesplegadas11oMas", ffMaiz.HojasDesplegadas11oMas);
                    cmd.Parameters.AddWithValue("@FloracionyPolinizacion", ffMaiz.FloracionyPolinizacion);
                    cmd.Parameters.AddWithValue("@EstigmasVisiblesyAmpolla", ffMaiz.EstigmasVisiblesyAmpolla);
                    cmd.Parameters.AddWithValue("@GranoLechosoyMasoso", ffMaiz.GranoLechosoyMasoso);
                    cmd.Parameters.AddWithValue("@EtapaDentadayMadurez", ffMaiz.EtapaDentadayMadurez);
                    cmd.Parameters.AddWithValue("@CosechaAcopioAvan", ffMaiz.CosechaAcopioAvan);
                    cmd.Parameters.AddWithValue("@CosechaAcopioRend", ffMaiz.CosechaAcopioRend);
                    cmd.Parameters.AddWithValue("@FechaCosechaIni", ffMaiz.FechaCosechaIni);
                    cmd.Parameters.AddWithValue("@FechaCosechaFin", ffMaiz.FechaCosechaFin);
                    cmd.Parameters.AddWithValue("@Tipo", ffMaiz.Tipo);
                    cmd.Parameters.AddWithValue("@SupSem", ffMaiz.SupSem);
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
        #region REGISTRAR FACE FENOLOGIA ARROZ
        public void DA_Registrar_FACE_FENOLOGICA_ARROZ(EXT_FaceFenologiaArroz ffArroz)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_FACE_FENOLOGICA_ARROZ_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Face_Feonologica", ffArroz.Id_Face_Feonologica);
                    cmd.Parameters.AddWithValue("@FechaAvnSiemIni", ffArroz.FechaAvnSiemIni);
                    cmd.Parameters.AddWithValue("@FechaAvnSiemFin", ffArroz.FechaAvnSiemFin);
                    cmd.Parameters.AddWithValue("@FechaAvnSiemAvan", ffArroz.FechaAvnSiemAvan);
                    cmd.Parameters.AddWithValue("@GerminacionIni", ffArroz.GerminacionIni);
                    cmd.Parameters.AddWithValue("@GerminacionFin", ffArroz.GerminacionFin);
                    cmd.Parameters.AddWithValue("@PlantulaIni", ffArroz.PlantulaIni);
                    cmd.Parameters.AddWithValue("@PlantulaFin", ffArroz.PlantulaFin);
                    cmd.Parameters.AddWithValue("@MacollamientoIni", ffArroz.MacollamientoIni);
                    cmd.Parameters.AddWithValue("@MacollamientoFin", ffArroz.MacollamientoFin);
                    cmd.Parameters.AddWithValue("@PaniculaIni", ffArroz.PaniculaIni);
                    cmd.Parameters.AddWithValue("@PaniculaFin", ffArroz.PaniculaFin);
                    cmd.Parameters.AddWithValue("@FloracionIni", ffArroz.FloracionIni);
                    cmd.Parameters.AddWithValue("@FloracionFin", ffArroz.FloracionFin);
                    cmd.Parameters.AddWithValue("@GranoLechosoIni", ffArroz.GranoLechosoIni);
                    cmd.Parameters.AddWithValue("@GranoLechosoFin", ffArroz.GranoLechosoFin);
                    cmd.Parameters.AddWithValue("@MaduracionIni", ffArroz.MaduracionIni);
                    cmd.Parameters.AddWithValue("@MaduracionFin", ffArroz.MaduracionFin);
                    cmd.Parameters.AddWithValue("@CosechaAcopioAvan", ffArroz.CosechaAcopioAvan);
                    cmd.Parameters.AddWithValue("@CosechaAcopioRend", ffArroz.CosechaAcopioRend);
                    cmd.Parameters.AddWithValue("@FechaCosechaIni", ffArroz.FechaCosechaIni);
                    cmd.Parameters.AddWithValue("@FechaCosechaFin", ffArroz.FechaCosechaFin);
                    cmd.Parameters.AddWithValue("@Tipo", ffArroz.Tipo);
                    cmd.Parameters.AddWithValue("@SupSem", ffArroz.SupSem);
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
        #region REGISTRAR FACE FENOLOGIA DEL CULTIVO EN GENERAL
        public void DA_Registrar_FACE_FENOLOGICA_SEMANAL(EXT_FaseFenEnvioSem ffsem)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_FASE_FENOLOGICA_SEMANAL_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", ffsem.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Regional", ffsem.Id_Regional);
                    cmd.Parameters.AddWithValue("@Programa", ffsem.Programa);
                    cmd.Parameters.AddWithValue("@Fecha_Envio", ffsem.Fecha_Envio);
                    cmd.Parameters.AddWithValue("@Estado", ffsem.Estado);
                    cmd.Parameters.AddWithValue("@Fecha_Semana", ffsem.Fecha_Semana);
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
        #region REGISTRAR FACE FENOLOGIA REPORTE DE ENVIO POR SEMANA LOS TOTALES DE LA SEMANA
        public void DA_Registrar_FACE_FENOLOGICA_SEMANAL_ENVIO_TRIGO(EXT_FaseFenEnvioSemanaTrigo ffsem)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_FENOLOGICA_SEM_ENVIO_TRIGO_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Envio_FenologiaSemanal", ffsem.Id_Envio_FenologiaSemanal);
                    cmd.Parameters.AddWithValue("@Num_Prod_Vigente", ffsem.Num_Prod_Vigente);
                    cmd.Parameters.AddWithValue("@Sup_Sembrada", ffsem.Sup_Sembrada);
                    cmd.Parameters.AddWithValue("@Avance_Siembra", ffsem.Avance_Siembra);
                    cmd.Parameters.AddWithValue("@Germinacion", ffsem.Germinacion);
                    cmd.Parameters.AddWithValue("@Plantula", ffsem.Plantula);
                    cmd.Parameters.AddWithValue("@Macollamiento", ffsem.Macollamiento);
                    cmd.Parameters.AddWithValue("@Embuche", ffsem.Embuche);
                    cmd.Parameters.AddWithValue("@Espigazon", ffsem.Espigazon);
                    cmd.Parameters.AddWithValue("@Floracion", ffsem.Floracion);
                    cmd.Parameters.AddWithValue("@Llenado_Grano", ffsem.Llenado_Grano);
                    cmd.Parameters.AddWithValue("@Maduracion", ffsem.Maduracion);
                    cmd.Parameters.AddWithValue("@Avance_cosecha", ffsem.Avance_cosecha);
                    cmd.Parameters.AddWithValue("@Rendimiento", ffsem.Rendimiento);
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

        #region MODIFICAR VALOR DE ENVIO POR SEMANA DE LA FASE FENOLOGICA
        public void DA_Indexar_FACE_FENOLOGICA_SEMANAL(int valor, int IdEnvFenSem)
        {
            try
            {
                string queryString = "UPDATE EXT_FACE_FENOLOGICA_CULTIVO SET Num_Seg_Cultivo = " + valor + " WHERE Id_Face_Feonologica = " + IdEnvFenSem + "";
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

        #region DESPLEGAR LOS VALORES DEL MUNERO DE PRODUCTORES ACTIVOS Y LA CANTIDAD EN SUPERFICIE DE CULTIVO EN HECTAREAS OJOJOJOJOJOJOJOJOJOJOJOJOJOOJOJOJOJO
        public DataTable DA_Seleccionar_ENVIOS_SEMANA(int IdReg)
        {
            try
            {
                string queryString = "SELECT RANK() OVER(ORDER BY EXT_FASE_FEN_ENVIO_SEM.Id_Envio_FenologiaSemanal)as NUM, AP_CAMPANHIA.Nombre, REGIONAL.Nombre AS Regional, EXT_FASE_FEN_ENVIO_SEM.Programa,";
                       queryString += " EXT_FASE_FEN_ENVIO_SEM.Fecha_Envio, CONVERT(char(10), DATEADD(DD, - 7, EXT_FASE_FEN_ENVIO_SEM.Fecha_Semana), 103) AS Desde, CONVERT(char(10), EXT_FASE_FEN_ENVIO_SEM.Fecha_Semana, 103) AS Hasta,";
                       queryString += " EXT_FASE_FEN_ENVIO_SEM.Estado, EXT_FASE_FEN_ENVIO_SEM.Id_Envio_FenologiaSemanal, EXT_FASE_FEN_ENVIO_SEM.Id_Campanhia, EXT_FASE_FEN_ENVIO_SEM.Id_Regional FROM  EXT_FASE_FEN_ENVIO_SEM INNER JOIN AP_CAMPANHIA ON EXT_FASE_FEN_ENVIO_SEM.Id_Campanhia = AP_CAMPANHIA.Id_Campanhia INNER JOIN";
                       queryString += " REGIONAL ON EXT_FASE_FEN_ENVIO_SEM.Id_Regional = REGIONAL.Id_Regional WHERE EXT_FASE_FEN_ENVIO_SEM.Id_Regional=" + IdReg + " ORDER BY EXT_FASE_FEN_ENVIO_SEM.Fecha_Envio";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
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

        #region DESPLEGAR LOS VALORES DEL MUNERO DE PRODUCTORES ACTIVOS Y LA CANTIDAD EN SUPERFICIE DE CULTIVO EN HECTAREAS OJOJOJOJOJOJOJOJOJOJOJOJOJOOJOJOJOJO
        public DataTable DA_Seleccionar_ENVIOS_SEMANA_FENOLOGIA(string estado)
        {
            try
            {
                string queryString = "SELECT RANK() OVER(ORDER BY EXT_FASE_FEN_ENVIO_SEM.Id_Envio_FenologiaSemanal)as NUM, AP_CAMPANHIA.Nombre, REGIONAL.Nombre AS Regional, EXT_FASE_FEN_ENVIO_SEM.Programa, ";
                       queryString += "EXT_FASE_FEN_ENVIO_SEM.Fecha_Envio, CONVERT(char(10), DATEADD(DD, - 7, GETDATE()), 103) AS Desde, CONVERT(char(10), GETDATE(), 103) AS Hasta, ";
                       queryString += "EXT_FASE_FEN_ENVIO_SEM.Estado, EXT_FASE_FEN_ENVIO_SEM.Id_Envio_FenologiaSemanal, EXT_FASE_FEN_ENVIO_SEM.Id_Campanhia, EXT_FASE_FEN_ENVIO_SEM.Id_Regional ";
                       queryString += "FROM  EXT_FASE_FEN_ENVIO_SEM INNER JOIN AP_CAMPANHIA ON EXT_FASE_FEN_ENVIO_SEM.Id_Campanhia = AP_CAMPANHIA.Id_Campanhia INNER JOIN ";
                       queryString += "REGIONAL ON EXT_FASE_FEN_ENVIO_SEM.Id_Regional = REGIONAL.Id_Regional WHERE EXT_FASE_FEN_ENVIO_SEM.Estado='"+ estado +"' ORDER BY EXT_FASE_FEN_ENVIO_SEM.Fecha_Envio"; 
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
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
        public int DA_MaxNumSeg(int IdInsOrg)
        {
            string queryString = "SELECT MAX(Num_Seg_Cultivo) FROM EXT_SEGUIMIENTO WHERE Id_InscripcionOrg="+ IdInsOrg +" AND Etapa='VERIFICACION_CULTIVO'";
                
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

                  if(IdAsociacion!="")
                    {
                        return Convert.ToInt32(IdAsociacion);
                    }
                    else
                    {
                     return 0;
                    }             
                }
        }
        #endregion

        #region DESPLEGAR LOS VALORES DEL MUNERO DE PRODUCTORES ACTIVOS Y LA CANTIDAD EN SUPERFICIE DE CULTIVO EN HECTAREAS
        public DataTable DA_Seleccionar_NUMPROD_TOTSUP(int IdInsOrg, int IdComunidad)
        {
            try
            {
                string queryString = "SELECT COUNT(AP_INSCRIPCION_PROD.Id_Productor), SUM(AP_INSCRIPCION_PROD.Has_Inscrito) FROM  AP_INSCRIPCION_PROD INNER JOIN ";
                       queryString += "AP_INSCRIPCION_ORG ON AP_INSCRIPCION_PROD.Id_InscripcionOrg = AP_INSCRIPCION_ORG.Id_InscripcionOrg INNER JOIN ";
                       queryString += "AP_COMUNIDAD ON AP_INSCRIPCION_PROD.Id_Comunidad = AP_COMUNIDAD.Id_Comunidad WHERE (AP_INSCRIPCION_ORG.Id_InscripcionOrg = " + IdInsOrg + ") AND (AP_INSCRIPCION_PROD.Estado = 'APROBADO') AND (AP_COMUNIDAD.Id_Municipio=" + IdComunidad + ")";
                       //queryString += "AP_COMUNIDAD ON AP_INSCRIPCION_PROD.Id_Comunidad = AP_COMUNIDAD.Id_Comunidad WHERE (AP_INSCRIPCION_ORG.Id_InscripcionOrg = " + IdInsOrg + ") AND (AP_INSCRIPCION_PROD.Estado = 'APROBADO')";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
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
        #region DESPLEGAR LOS VALORES DEL MUNERO DE PRODUCTORES ACTIVOS Y LA CANTIDAD EN SUPERFICIE DE CULTIVO EN HECTAREAS
        public DataTable DA_Seleccionar_NUMPROD_TOTSUP_ORG(int IdInsOrg)
        {
            try
            {
                string queryString = "SELECT COUNT(AP_INSCRIPCION_PROD.Id_Productor), SUM(AP_INSCRIPCION_PROD.Has_Inscrito), SUM(AP_INSCRIPCION_PROD.Has_Ejecutado) FROM  AP_INSCRIPCION_PROD INNER JOIN ";
                queryString += "AP_INSCRIPCION_ORG ON AP_INSCRIPCION_PROD.Id_InscripcionOrg = AP_INSCRIPCION_ORG.Id_InscripcionOrg INNER JOIN ";
                queryString += "AP_COMUNIDAD ON AP_INSCRIPCION_PROD.Id_Comunidad = AP_COMUNIDAD.Id_Comunidad WHERE (AP_INSCRIPCION_ORG.Id_InscripcionOrg = " + IdInsOrg + ") AND (AP_INSCRIPCION_PROD.Estado = 'APROBADO')";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
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

        #region SELECCIONAR EL SEGUIMIENTO FENOLOGICO PARA EL REPORTE
        public DataTable DA_Reporte_FENOLOGIA_DETALLE(int IdInsOrg, string Programa, int IdCamp, int IdReg, int NuSeg, string Tipo, DateTime fecha, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_FENOLOGIA_REPORTE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInsOrg", IdInsOrg);
                    cmd.Parameters.AddWithValue("@Programa", Programa);
                    cmd.Parameters.AddWithValue("@IdCamp", IdCamp);
                    cmd.Parameters.AddWithValue("@Id_Regional", IdReg);
                    cmd.Parameters.AddWithValue("@NuSeg", NuSeg);
                    cmd.Parameters.AddWithValue("@Tipo", Tipo);
                    cmd.Parameters.AddWithValue("@FechaEnvio", fecha);
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

        /**************************************************/
        #region OBTENER DATOS DE EL NUMERO DE BOLETAS DEL SEGUIMIENTO AL CULTIVO
        public DataTable DA_FACE_FENOLOGICA(int IdInscripcionOrg, int idCamp, int IdFenologia, int idReg, string Programa, string IdUsuario, string Tipo, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_FACE_FENOLOGICA_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInscripcionOrg", IdInscripcionOrg);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", idCamp);
                    cmd.Parameters.AddWithValue("@IdFenologia", IdFenologia);
                    cmd.Parameters.AddWithValue("@Id_Regional", idReg);
                    cmd.Parameters.AddWithValue("@Programa", Programa);
                    cmd.Parameters.AddWithValue("@Id_Usuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@Tipo", Tipo);
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
    }
}
