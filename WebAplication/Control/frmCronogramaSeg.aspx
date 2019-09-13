<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCronogramaSeg.aspx.cs" Inherits="WebAplication.Control.frmCronogramaSeg" %>
<%@ Register assembly="DataCalendar" namespace="DataControls" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../js/validar.js" type="text/ecmascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <link href="../Css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript">


          $(document).ready(function () {
              //debugger;
              $('#MainContent_TxtFecha').datepicker({
                  dateFormat: 'dd/mm/yy',
                  changeMonth: false,
                  changeYear: false,
                  nextText: 'Siguiente Mes',
                  prevText: 'Mes Anterior',
                  dayNames: ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'],
                  dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                  monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                  montNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic']
              });
          });

          function Confirmacion() {
              var seleccion = confirm("Está seguro de enviar la información registrada…?");
              return seleccion;
          }
          
          function fechas()
          {
              //alert("doing....!!!");
              var lunes = document.getElementById('<%=LblFLunes.ClientID%>').innerText
              var fecha = document.getElementById('<%=TxtFecha.ClientID%>').value
              //var lunes1 = document.getElementById("LblFLunes").value; 
              //alert("fecha;" + fecha + "|" + "lunes:" + lunes);
              if (String(lunes) != "" )
              {                   
                  if (lunes != fecha) {
                      var answer = confirm("¿Se volvera a generear las fechas de la Planificación.?")
                      if (answer) {
                          //alert("Bye bye!")
                          return true;
                      }
                      else {
                          //alert("Cancelado!")
                          return false;
                      }                     
                  }
                  //else {
                  //    //alert("Fechas de Planificación ya Generadas")
                  //    return false
                  //}
              }
              else
              {
                  //alert("LblFlunes vacio");
                  return true
              }              
          }          

  </script> 
    <style type="text/css">
        .auto-style1 {
            width: 45px;
        }
        .auto-style2 {
            height: 30px;
        }       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">FORMULARIO DE PLANIFICACIÓN SEMANAL</div>
    <table class="TableBorder">
        <tr>
            <td width="80">Regional:</td>
            <td>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="150">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td rowspan="2">
               <div style="text-align: right"> <asp:ImageButton ID="ImgBtnPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" /></div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="3">
                <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000; text-align: center;"></asp:Label></div>
            </td>
        </tr>
        </table>
    <table class="TableBorder">
        <tr>
            <td width="150">
                Definir Fecha de Inicio:</td>
            <td width="400">
                <asp:TextBox ID="TxtFecha" CssClass="myDatePickerClass" runat="server" Width="80px"></asp:TextBox>
                <asp:LinkButton ID="LnkAceptar" runat="server" OnClientClick ="return fechas()" OnClick="LnkAceptar_Click">[ Aceptar ]</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Nombre de la planificacion:</td>
            <td>
                <asp:TextBox ID="TxtNombre" runat="server" ></asp:TextBox>
            </td>
            <td width="60">
                Semana:</td>
            <td>
                <asp:DropDownList ID="DDLSemana" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <asp:Panel ID="Panel1" runat="server" style="margin-top: 0px" Enabled="False">
        <table class="TableBorder">
            <tr>
                <td class="auto-style3">Oficina:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DDLActividadesOficina" runat="server" Width="400px">
                    </asp:DropDownList>
                    <asp:Button ID="BtnOrgInsert0" runat="server" OnClick="BtnOrgInsert0_Click" Text="&gt;&gt;" Width="30px" />
                    <br />
                    <asp:TextBox ID="txtDDLActividadesOficina" runat="server" Width="350px"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Colocación cartera:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DDLActividadesApoyoProduccion" runat="server" Width="400px">
                    </asp:DropDownList>
                    <asp:Button ID="BtnOrgInsert1" runat="server" Text="&gt;&gt;" Width="30px" OnClick="BtnOrgInsert1_Click" />
                    <br />
                    <asp:TextBox ID="txtDDLActividadesApoyoProduccion" runat="server" Width="350px"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Empresas elegibles:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DDLActividadesEmpresasProveedoras" runat="server" Width="400px">
                    </asp:DropDownList>
                    <asp:Button ID="BtnOrgInsert2" runat="server" Text="&gt;&gt;" Width="30px" OnClick="BtnOrgInsert2_Click" />
                    <br />
                    <asp:TextBox ID="txtDDLActividadesEmpresasProveedoras" runat="server" Width="350px"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Extensión Agricola:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DDLActividadesExtensionAgricola" runat="server" Width="400px">
                    </asp:DropDownList>
                    <asp:Button ID="BtnOrgInsert3" runat="server" Text="&gt;&gt;" Width="30px" OnClick="BtnOrgInsert3_Click" />
                    <br />
                    <asp:TextBox ID="txtDDLActividadesExtensionAgricola" runat="server" Width="350px"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Fortalecimiento:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DDLActividadesFortalecimiento" runat="server" Width="400px">
                    </asp:DropDownList>
                    <asp:Button ID="BtnOrgInsert4" runat="server" Text="&gt;&gt;" Width="30px" OnClick="BtnOrgInsert4_Click" />
                    <br />
                    <asp:TextBox ID="txtDDLActividadesFortalecimiento" runat="server" Width="350px"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Monitoreo:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DDLActividadesMonitoreo" runat="server" Width="550px">
                    </asp:DropDownList>
                    <asp:Button ID="BtnOrgInsert5" runat="server" Text="&gt;&gt;" Width="30px" OnClick="BtnOrgInsert5_Click" />
                    <br />
                    <asp:TextBox ID="txtDDLActividadesMonitoreo" runat="server" Width="517px"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Reprogramación:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DDLActividadesReprogramacionDeuda" runat="server" Width="650px">
                    </asp:DropDownList>
                    <asp:Button ID="BtnOrgInsert6" runat="server" Text="&gt;&gt;" Width="30px" OnClick="BtnOrgInsert6_Click" />
                    <br />
                    <asp:TextBox ID="txtDDLActividadesReprogramacionDeuda" runat="server" Width="613px"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Otras actividades:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DDLActividadesOtros" runat="server" Width="400px">
                    </asp:DropDownList>
                    <asp:Button ID="BtnOrgInsert7" runat="server" Text="&gt;&gt;" Width="30px" OnClick="BtnOrgInsert7_Click" />
                    <br />
                    <asp:TextBox ID="txtDDLActividadesOtros" runat="server" Width="350px"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Organizaciones(ORG):</td>
                <td>
                    <asp:DropDownList ID="DDLOrgAsig" runat="server" Width="400px">
                    </asp:DropDownList>
                    <asp:Button ID="BtnOrgInsert" runat="server" Text="&gt;&gt;" Width="30px" OnClick="BtnOrgInsert_Click" />
                    <br />
                    <asp:TextBox ID="txtDDLOrgAsig" runat="server" Width="350px"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td >Movilidad utilizada(MOV):</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DDLVehiculos" runat="server" Width="400px">
                    </asp:DropDownList>
                    <asp:Button ID="BtnVehiculo" runat="server" OnClick="BtnVehiculo_Click" Text="&gt;&gt;" />
                    <br />
                    <asp:TextBox ID="txtDDLVehiculos" runat="server" Width="350px"></asp:TextBox>
                </td>
                <td></td>
            </tr>
        </table>
        <table class="TableBorder">
            <tr>
                <td width="140">
                    <asp:RadioButton ID="RdbLunes" runat="server" AutoPostBack="True" Checked="True" GroupName="dia" OnCheckedChanged="RdbLunes_CheckedChanged" Text="LUNES" />
                </td>
                <td width="140">
                    <asp:RadioButton ID="RdbMartes" runat="server" AutoPostBack="True" GroupName="dia" OnCheckedChanged="RdbMartes_CheckedChanged" Text="MARTES" />
                </td>
                <td width="140">
                    <asp:RadioButton ID="RdbMiercoles" runat="server" AutoPostBack="True" GroupName="dia" OnCheckedChanged="RdbMiercoles_CheckedChanged" Text="MIERCOLES" />
                </td>
                <td width="140">
                    <asp:RadioButton ID="RdbJueves" runat="server" AutoPostBack="True" GroupName="dia" OnCheckedChanged="RdbJueves_CheckedChanged" Text="JUEVES" />
                </td>
                <td width="140">
                    <asp:RadioButton ID="RdbViernes" runat="server" AutoPostBack="True" GroupName="dia" OnCheckedChanged="RdbViernes_CheckedChanged" Text="VIERNES" />
                </td>
                <td width="140">
                    <asp:RadioButton ID="RdbSabado" runat="server" AutoPostBack="True" GroupName="dia" OnCheckedChanged="RdbSabado_CheckedChanged" Text="SABADO" />
                </td>
                <td width="140">
                    <asp:RadioButton ID="RdbDomingo" runat="server" AutoPostBack="True" GroupName="dia" OnCheckedChanged="RdbDomingo_CheckedChanged" Text="DOMINGO" />
                </td>
                <td>
                    <asp:Label ID="LblAux" runat="server" Text="LUNES" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="text-align: center"><asp:Label ID="LblFLunes" runat="server"></asp:Label></div>
                </td>
                <td>
                    <div style="text-align: center"><asp:Label ID="LblFMartes" runat="server"></asp:Label></div>
                </td>
                <td>
                    <div style="text-align: center"><asp:Label ID="LblFMiercoles" runat="server"></asp:Label></div>
                </td>
                <td>
                    <div style="text-align: center"><asp:Label ID="LblFJueves" runat="server"></asp:Label></div>
                </td>
                <td>
                    <div style="text-align: center"><asp:Label ID="LblFViernes" runat="server"></asp:Label></div>
                </td>
                <td>
                    <div style="text-align: center"><asp:Label ID="LblFSabado" runat="server"></asp:Label></div>
                </td>
                <td>
                    <div style="text-align: center"><asp:Label ID="LblFDomingo" runat="server"></asp:Label></div>
                </td>
                <td>
                    <asp:ImageButton ID="ImgBtnElininar" runat="server" ImageUrl="~/images/img-0.png" OnClick="ImgBtnElininar_Click" Width="16px" ToolTip="Selecciones Dato y Eliminar" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="LstLunes" runat="server" Height="150px" Width="140px"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="LstMartes" runat="server" Height="150px" Width="140px"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="LstMiercoles" runat="server" Height="150px" Width="140px"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="LstJueves" runat="server" Height="150px" Width="140px"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="LstViernes" runat="server" Height="150px" Width="140px"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="LstSabado" runat="server" Height="150px" Width="140px"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="LstDomingo" runat="server" Height="150px" Width="140px"></asp:ListBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <div style="text-align: center"><asp:Button ID="BtnEnviar" runat="server" OnClientClick ="return Confirmacion()" Text="Enviar Planificación" OnClick="BtnEnviar_Click" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" /></div>
    </asp:Panel>
    </asp:Content>
