using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_General;
using DataEntity.DE_General;

namespace DataBusiness.DB_General
{
    public class DB_Persona
    {
        #region BUSCAR UNA PERSONA POR EL NUMERO DE CEDULA DE IDENTIDAD
        public Persona DB_Buscar_PERSONA(string id)
        {
            DA_Persona data = new DA_Persona();
            DataTable dt = new DataTable();
            dt = data.DA_Buscar_PERSONA(id);
            Persona al = new Persona();
            if (dt.Rows.Count != 0)
            {
                al.Id_Persona = dt.Rows[0][0].ToString();
                al.ci = dt.Rows[0][1].ToString();
                al.ext = dt.Rows[0][2].ToString();
                al.Nombres = dt.Rows[0][3].ToString();
                al.Primer_ap = dt.Rows[0][4].ToString();
                al.Segundo_ap = dt.Rows[0][5].ToString();
                al.Fecha_nacimiento = Convert.ToDateTime(dt.Rows[0][6].ToString());
                al.Sexo = Convert.ToBoolean(dt.Rows[0][7].ToString());
                al.Telef_fijo = dt.Rows[0][8].ToString();
                al.Telef_cel = dt.Rows[0][9].ToString();
                al.Fecha_registro = Convert.ToDateTime(dt.Rows[0][10].ToString());
                al.Estado = dt.Rows[0][11].ToString();

            }
            return al;
        }
        #endregion
        #region REGISTRAR LOS DATOS DE UNA PERSONA
        public void DB_Registrar_PERSONA(Persona p)
        {
            DA_Persona Ins = new DA_Persona();
            Ins.DA_Registrar_PERSONA(p);
        }
        #endregion
        #region MODIFICAR LOS DATOS DE UNA PERSONA
        public void DB_Modificar_PERSONA(Persona p)
        {
            DA_Persona dato = new DA_Persona();
            dato.DA_Modificar_PERSONA(p);
        }
        #endregion
        #region VERIFICAR SI EXISTE UNA PERSONA
        public Boolean DB_Existe_PERSONA(string id)
        {
            Boolean resp = false;
            DA_Persona data = new DA_Persona();
            DataTable dt = new DataTable();
            dt = data.DA_Buscar_PERSONA(id);
            if (dt.Rows.Count != 0)
            {
                resp = true;
            }
            return resp;
        }
        #endregion
    }
}
