using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataEntity.DE_Registro;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_InscripcionProv
    {
        #region REGISTRAR NUEVA INSCRIPCION DE PROVEEDOR
        public void DB_Registrar_INSCRIP_PROVEEDOR(AP_InscripcionProv ip)
        {
            DA_AP_InscripcionProv Ins = new DA_AP_InscripcionProv();
            Ins.DA_Registrar_INSCRIP_PROVEEDOR(ip);
        }
        #endregion
        #region BUSCAR LA INSCRIPCION DE PROVEEDOR POR EL ID DE INSCRIPCION
        public AP_InscripcionProv DB_Buscar_INSCRPCION_PROV(int id)
        {
            DA_AP_InscripcionProv data = new DA_AP_InscripcionProv();
            DataTable dt = new DataTable();
            dt = data.DA_Buscar_INSCRPCION_PROV(id);
            AP_InscripcionProv ip = new AP_InscripcionProv();       
            ip.Id_InscripcionProv = Convert.ToInt32(dt.Rows[0][0]);
            ip.Id_Campanhia = Convert.ToInt32(dt.Rows[0][1]);
            ip.Id_Proveedor = Convert.ToInt32(dt.Rows[0][2]);
            ip.Id_Regional = Convert.ToInt32(dt.Rows[0][3]);
            ip.Insumo = dt.Rows[0][4].ToString();
            ip.Programa = dt.Rows[0][5].ToString();
            ip.Matricula_Comercio = dt.Rows[0][6].ToString();
            ip.Domicilio = dt.Rows[0][7].ToString();
            ip.Estado = dt.Rows[0][8].ToString();
            return ip;
        }
        #endregion  
        #region MODIFICAR LA TABLA INSCRIPCION PROVEEDOR
        public void DB_Modificar_INSCRIP_PROVEEDOR(AP_InscripcionProv ip)
        {
            DA_AP_InscripcionProv dato = new DA_AP_InscripcionProv();
            dato.DA_Modificar_INSCRIP_PROVEEDOR(ip);
        }
        #endregion

        #region REGISTRAR CONTRATO DE INSUMOS
        public void DB_Registrar_CONTRATO_INSUMO(INS_ContratoInsumo ci)
        {
            DA_AP_InscripcionProv ip = new DA_AP_InscripcionProv();
            ip.DA_Registrar_CONTRATO_INSUMO(ci);
        }
        #endregion
        #region REGISTRAR CONTRATO DETALLE DE INSUMOS
        public void DB_Registrar_CONTRATO_INSUMO_DETALLE(INS_DetalleInsumo di)
        {
            DA_AP_InscripcionProv Ins = new DA_AP_InscripcionProv();
            Ins.DA_Registrar_CONTRATO_INSUMO_DETALLE(di);
        }
        #endregion

        #region SELECCIONAR EL CONTRATO DE INSUMO POR EL PRODUTO O INSUMO 
        public DataTable DB_Seleccionar_CONTRATO_PROV(int contador, int idinsProv, int tipoinsumo, string Parametro)
        {
            DA_AP_InscripcionProv data = new DA_AP_InscripcionProv(); 
            return data.DA_Seleccionar_CONTRATO_PROV( contador, idinsProv, tipoinsumo, Parametro);
        }
        #endregion
    }
}
