<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFenologiaRegional.aspx.cs" Inherits="WebAplication.Extensiones.frmFenologiaRegional" %>
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
  </script> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        LISTA DE LA FASE FENOLÓGICA DEL CULTIVO POR ORGANIZACION.</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Regional:</td>
            <td>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="LblRegion" runat="server"></asp:Label>
            </td>
            <td></td>
            <td width="60">Campaña:</td>
            <td width="140">
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLProg" runat="server" OnSelectedIndexChanged="DDLProg_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Desde:</td>
            <td>
                <asp:Label ID="LblFechaIni" runat="server"></asp:Label>
                , Hasta
                <asp:DropDownList ID="DDLSemanaEnvio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLSemanaEnvio_SelectedIndexChanged" Width="95px">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">
                <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
            </td>
        </tr>
    </table>
        <asp:GridView ID="GVDetalleFenologiaTrigo" runat="server" AutoGenerateColumns="False" style="font-size: xx-small" OnRowCreated="GVDetalleFenologiaTrigo_RowCreated" Visible="False" CssClass="TableBorder2">
            <Columns>
                <asp:BoundField DataField="Id_Face_Feonologica" HeaderText="Id" Visible="False" />
                <asp:BoundField DataField="Sigla" HeaderText="Organizaciones" >
                <ItemStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField DataField="Num_Boletas_Inspec" HeaderText="N° Bol" >
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Charla_Tecnica" HeaderText="Ch. Tec." Visible="False" >
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Num_Prod_Vigentes" HeaderText="N° B.Vig." >
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Sup_Actual" HeaderText="Sup sem. (ha)" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Variedad_Semilla" HeaderText="Varied" >
                <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaAvnSiemIni" HeaderText="F Inicial" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaAvnSiemFin" HeaderText="F Final" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaAvnSiemAvan" HeaderText="Avance %" >
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="GerminacionIni" HeaderText="Germinación emergencia" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="PlantulaIni" HeaderText="Plántula" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="MacollamientoIni" HeaderText="Macollamiento" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="EmbucheIni" HeaderText="Embuche" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="EspigazonIni" HeaderText="Espigazon" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="FloracionIni" HeaderText="Floración" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="LlenadoGranoIni" HeaderText="Llenado grano" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="MaduracionIni" HeaderText="Maduración" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="CosechaAcopioAvan" HeaderText="Avance %" >
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="CosechaAcopioRend" HeaderText="Rend" >
                <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaCosechaIni" HeaderText="Cosecha Ini" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaCosechaFin" HeaderText="Cosecha Fin" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Observacion" HeaderText="Obs." >
                <ItemStyle Width="150px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <table class="TableBorder2">
            <tr>
                <td width="100"><div style="text-align: right; font-weight: 700">TOTALES:</div></td>
                <td width="40">&nbsp;</td>
                <td width="40">
                    <asp:Label ID="LblTotNumBenef" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotSupSem" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="80"></td>
                <td width="50"></td>
                <td width="50"></td>
                <td width="50">
                    <asp:Label ID="LblTotAvSiem" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotGerm" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotPlant" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotMacolla" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotEmbu" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotEspi" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotFlora" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotLlenGran" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotMadura" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="40">
                    <asp:Label ID="LblTotAvCos" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="30">
                    <asp:Label ID="LblTotRend" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50"></td>
                <td width="50"></td>
                <td width="150"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
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
        <table class="TableBorder">
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1">
                    <div style="text-align: center"><asp:Button ID="BtnEnviarSeg" runat="server" OnClientClick ="return Confirmacion()" Text="Enviar Seguimiento Semanal" OnClick="BtnEnviarSeg_Click" /></div>
                </td>
                <td class="auto-style1"></td>
            </tr>
            </table>
               <div class="SubTitulo2">SEGUIMIENTOS SEMANALES DEL ESTADO FENOLÓGICO DEL CULTIVO ENVIADOS</div>
    <asp:GridView ID="GVEnviadosSemana" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVEnviadosSemana_RowCommand" OnRowCreated="GVEnviadosSemana_RowCreated">
        <Columns>
            <asp:BoundField DataField="NUM" HeaderText="N°" />
            <asp:BoundField DataField="Nombre" HeaderText="Campaña" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" />
            <asp:BoundField DataField="Programa" HeaderText="Programa" />
            <asp:BoundField DataField="Fecha_Envio" HeaderText="Fecha Enviado" />
            <asp:BoundField DataField="Desde" HeaderText="Desde" />
            <asp:BoundField DataField="Hasta" HeaderText="Hasta" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_Envio_FenologiaSemanal" HeaderText="Id_Envio_FenologiaSemanal" Visible="False" />
            <asp:BoundField DataField="Id_Campanhia" HeaderText="Id_Campanhia" Visible="False" />
            <asp:BoundField DataField="Id_Regional" HeaderText="Id_Regional" Visible="False" />
            <asp:ButtonField CommandName="imprimir" Text="Imprimir">
            <ItemStyle Width="45px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
