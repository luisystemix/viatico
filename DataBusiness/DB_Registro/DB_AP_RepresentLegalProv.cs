using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataEntity.DE_Registro;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_RepresentLegalProv
    {
        #region REGISTRAR AL REPRESENTANTE LEGAL DE UN PROVEEDOR
        public void DB_Registrar_REPRESENT_LEGAL_PROV(AP_RepresentLegalProv rl)
        {
            DA_AP_RepresentLegalProv InRL = new DA_AP_RepresentLegalProv();
            InRL.DA_Registrar_REPRESENT_LEGAL_PROV(rl);
        }
        #endregion
        #region BUSCAR AL REPRESENTANTE LEGAL DE UNA EMPRESA PROVEEDORA POR EL ID DE INSCRIPCION
        public AP_RepresentLegalProv DB_Buscar_REPRESENT_LEGAL_PROV(int id)
        {
            DA_AP_RepresentLegalProv data = new DA_AP_RepresentLegalProv();
            DataTable dt = new DataTable();
            dt = data.DA_Buscar_REPRESENT_LEGAL_PROV(id);
            AP_RepresentLegalProv rl = new AP_RepresentLegalProv();
            rl.Id_InscripcionProv = Convert.ToInt32(dt.Rows[0][0].ToString());
            rl.Id_Persona = dt.Rows[0][1].ToString();
            rl.Tipo_Poder = dt.Rows[0][2].ToString();
            rl.Num_Testimonio = dt.Rows[0][3].ToString();
            rl.Domicilio = dt.Rows[0][4].ToString();
            rl.Fecha = Convert.ToDateTime(dt.Rows[0][5].ToString());
            return rl;
        }
        #endregion
        #region FUNCION PARA MODIFICAR AL REPRESNTANTE LEGAL DE LA EMPRESA PROVEEDORA
        public void DB_Modificar_REPRESENT_LEGAL_PROV(AP_RepresentLegalProv rlp)
        { 
            DA_AP_RepresentLegalProv dato = new DA_AP_RepresentLegalProv();
            dato.DA_Modificar_REPRESENT_LEGAL_PROV(rlp);
        }
        #endregion
    }
}
