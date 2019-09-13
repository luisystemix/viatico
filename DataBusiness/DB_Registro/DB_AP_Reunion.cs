using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataEntity.DE_Registro;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_Reunion
    {
        #region REGISTRAR EL ACTA DE REUNIONES
        public void DB_Registrar_REUNION(AP_Reunion r)
        {
            DA_AP_Reunion Inscripcion = new DA_AP_Reunion();
            Inscripcion.DA_Registrar_REUNION(r);
        }
        #endregion
        #region REGISTRAR LOS PARTICIPANTES DE LA REUNION
        public void DB_Registrar_ASISTENCIA(AP_ReunionAsistencia ar)
        {
            DA_AP_Reunion Inscripcion = new DA_AP_Reunion();
            Inscripcion.DA_Registrar_ASISTENCIA(ar);
        }
        #endregion
        #region REGISTRAR LOS TEMAR QUE SE TRATARON EN LA REUNION
        public void DB_Registrar_TEMAS(AP_ReunionTareas tr)
        {
            DA_AP_Reunion Inscripcion = new DA_AP_Reunion();
            Inscripcion.DA_Registrar_TEMAS(tr);
        }
        #endregion

        #region DESPLEGAR TODAS LAS REUNIONES DE LA CAMPAÑA
        public DataTable DB_Reporte_REUNIONES(int idreunion, int idcamp, string consult)
        {
            DA_AP_Reunion data = new DA_AP_Reunion();
            return data.DA_Reporte_REUNIONES(idreunion,idcamp,consult);
        }
        #endregion
    }
}
