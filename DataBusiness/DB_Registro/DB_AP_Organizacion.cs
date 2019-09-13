using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Registro;
using DataEntity.DE_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_Organizacion
    {
        #region REGISTRAR LA ORGANIZACION
        public void DB_Registrar_ORG(AP_Organizacion o)
        {
            DA_AP_Organizacion Ins = new DA_AP_Organizacion();
            Ins.DA_Registrar_ORG(o);
        }
        #endregion
        #region REGISTRAR LA INSCRIPCION DE UNA ORGANIZACION
        public void DB_Registrar_INSCRIP_ORG(AP_InscripcionOrg io)
        {
            DA_AP_Organizacion InsO = new DA_AP_Organizacion();
            InsO.DA_Registrar_INSCRIP_ORG(io);
        }
        #endregion  
        #region BUSCAR LA INSCRIPCION DE ORGANIZACION POR EL ID DE INSCRIPCION
        public AP_InscripcionOrg DB_Buscar_INSCRPCION_ORG(int id)
        {
            DA_AP_Organizacion data = new DA_AP_Organizacion();
            DataTable dt = new DataTable();
            dt = data.DA_Buscar_INSCRPCION_ORG(id);
            AP_InscripcionOrg io = new AP_InscripcionOrg();
            io.Id_InscripcionOrg = Convert.ToInt32(dt.Rows[0][0]);
            io.Id_Organizacion = Convert.ToInt32(dt.Rows[0][1]);
            io.Id_Campanhia = Convert.ToInt32(dt.Rows[0][2]);
            io.Id_Regional = Convert.ToInt32(dt.Rows[0][3]);
            io.Programa = dt.Rows[0][4].ToString();
            io.Fecha_Registro = Convert.ToDateTime(dt.Rows[0][5].ToString());
            io.Tipo_Produccion = dt.Rows[0][6].ToString();
            io.Estado = dt.Rows[0][7].ToString();
            return io;
        }
        #endregion  
        #region REGISTRAR AL REPRESENTANTE LEGAL DE UNA ORGANIZACION
        public void DB_Registrar_REPRESENT_LEGAL(AP_RepresentLegal rl)
        {
            DA_AP_Organizacion InRL = new DA_AP_Organizacion();
            InRL.DA_Registrar_REPRESENT_LEGAL(rl);
        }
        #endregion
        #region BUSCAR ORGANIZACION POR EL ID DE LAORGANIZACION
        public AP_Organizacion DB_Buscar_ORG(int id)
        {
            DA_AP_Organizacion data = new DA_AP_Organizacion();
            DataTable dt = new DataTable();
            dt = data.DA_Buscar_ORG(id);
            AP_Organizacion o = new AP_Organizacion();
            o.Id_Organizacion = Convert.ToInt32(dt.Rows[0][0]);
            o.Personeria_Juridica = dt.Rows[0][1].ToString();
            o.Sigla = dt.Rows[0][2].ToString();
            o.Departamento = dt.Rows[0][3].ToString();
            o.Resolucion_Prefect = dt.Rows[0][4].ToString();
            o.Fecha_Creacion = Convert.ToDateTime(dt.Rows[0][5].ToString());
            o.Tipo = dt.Rows[0][6].ToString();
            o.DomicilioOrg = dt.Rows[0][7].ToString();
            return o;
        }
        #endregion
        #region MODIFICAR LA ORGANIZACIONES
        public void DB_Modificar_ORG(AP_Organizacion o)
        {
            DA_AP_Organizacion dato = new DA_AP_Organizacion();
            dato.DA_Modificar_ORG(o);
        }
        #endregion
        #region MODIFICAR LA INSCRIPCION DE UNA ORGANIZACION
        public void DB_Modificar_INSCRIP_ORG(AP_InscripcionOrg io)
        {
            DA_AP_Organizacion dato = new DA_AP_Organizacion();
            dato.DA_Modificar_INSCRIP_ORG(io);
        }
        #endregion
        #region MODIFICAR DATOS DEL REPRESENTANTE LEGAL DE UNA ORGANIZACION
        public void DB_Modificar_REPRESENT_LEGAL(AP_RepresentLegal rl)
        {
            DA_AP_Organizacion dato = new DA_AP_Organizacion();
            dato.DA_Modificar_REPRESENT_LEGAL(rl);
        }
        #endregion       
        #region BUSCAR AL REPRESENTANTE LEGAL DE UNA ORGANIZACION POR EL ID DE INSCRIPCION
        public AP_RepresentLegal DB_Buscar_REPRESENT_LEGAL(int id)
        {
            DA_AP_Organizacion data = new DA_AP_Organizacion();
            DataTable dt = new DataTable();
            dt = data.DA_Buscar_REPRESENT_LEGAL(id);
            AP_RepresentLegal rl = new AP_RepresentLegal();
            rl.Id_Persona = dt.Rows[0][0].ToString();
            rl.Id_InscripcionOrg = Convert.ToInt32(dt.Rows[0][1].ToString());
            rl.Tipo_Poder = dt.Rows[0][2].ToString();
            rl.Nun_Testimonio = dt.Rows[0][3].ToString();
            rl.Domicilio = dt.Rows[0][4].ToString();
            rl.Fecha = Convert.ToDateTime(dt.Rows[0][5].ToString());
            rl.Num_Notaria = dt.Rows[0][6].ToString();
            rl.Distrito_Judicial = dt.Rows[0][7].ToString();
            rl.Abg_A_Cargo = dt.Rows[0][8].ToString();
            return rl;
        }
        #endregion
        #region REGISTRAR LOS DOCUMENTOS SOLICITADOS POR CAMPAÑA
        public void DB_Registrar_DOC_PRESENTADO(int Id_InsOrg, int Id_Campanhia, string Region)
        {
            DA_AP_Organizacion Ins = new DA_AP_Organizacion();
            Ins.DA_Registrar_DOC_PRESENTADO(Id_InsOrg, Id_Campanhia, Region);
        }
        #endregion
        /**************************************************************/
        #region REGISTRAR LA COMUNIDAD/ORGANIZACION
        public void DB_Registrar_COMU_ORG(AP_Comunidad_Org co)
        {
            DA_AP_Organizacion Ins = new DA_AP_Organizacion();
            Ins.DA_Registrar_COMU_ORG(co);
        }
        #endregion

    }
}
