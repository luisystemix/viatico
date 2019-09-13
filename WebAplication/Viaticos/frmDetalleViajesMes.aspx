<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDetalleViajesMes.aspx.cs" Inherits="WebAplication.Viaticos.frmDetalleViajesMes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../js/validar.js" type="text/ecmascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <link href="../Css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        td
        {
            cursor: pointer;
        }
        .hover_row
        {
            background-color: #c5bfb7/*#A1DCF2*/;
        }
    </style>    
    <script type="text/javascript">
          $(document).ready(function () {
              //debugger;
              $('#MainContent_TxtFechIni,#MainContent_TxtFechFin').datepicker({
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
          $(function () {
              $("[id*=GVListaViajes] td").hover(function () {
                  $("td", $(this).closest("tr")).addClass("hover_row");
              }, function () {
                  $("td", $(this).closest("tr")).removeClass("hover_row");
              });
          });
  </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        DETALLE DE VIAJES REALIZADOS EN EL MES</div>
    <table class="TableBorder">
        <tr>
            <td class="auto-style1" width="130"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="#CC0000" Visible="False"></asp:Label>
            </td>            
        </tr>
        <tr>
            <td>Desplegar por Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
    <table class="TableBorder">
        <tr>
            <td width="120">Intervalo de Fecha:</td>
            <td width="80">&nbsp;</td>
            <td width="50">&nbsp;</td>
            <td width="80">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="120"><div style="text-align: right">Desde:</div></div></td>
            <td><asp:TextBox ID="TxtFechIni" runat="server" Width="80px" ></asp:TextBox>
            </td>
            <td><div style="text-align: right">Hasta:</div></td>
            <td><asp:TextBox ID="TxtFechFin" runat="server" Width="80px" ></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="BtnCalcular" runat="server" Text="Procesar fechas &gt;&gt;" OnClick="BtnCalcular_Click" />&nbsp;</td>
            <td>&nbsp;</td>
            <td style="width: 45px; height: 45px">
                <asp:ImageButton ID="ImgPrint" runat="server" Height="40px" ImageUrl="~/images/excel7.png" Width="40px" OnClientClick="ConfirmExport();" ToolTip="Exportar" OnClick="ImgPrint_Click" />
            </td>
        </tr>
        </table>
    <asp:GridView ID="GVListaViajes" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVListaViajes_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Id_Solicitud" HeaderText="Id_Solicitud" />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
            <asp:BoundField DataField="ci" HeaderText="ci" />
            <asp:BoundField DataField="Fecha_Salida" HeaderText="Fecha_Salida" />
            <asp:TemplateField HeaderText="Fecha Retorno">
                <ItemTemplate>
                    <asp:Label ID="LblFechRetorno" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dias de Comision" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="LblDias" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
