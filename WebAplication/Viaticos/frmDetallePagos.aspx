<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDetallePagos.aspx.cs" Inherits="WebAplication.Viaticos.frmDetallePagos" %>
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
        DETALLE DE VIAJES PAGADOS </div>
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
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
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
            <td width="120"><div style="text-align: right">Desde Fecha:</div></div></td>
            <td><asp:TextBox ID="TxtFechIni" runat="server" Width="80px" ></asp:TextBox>
            </td>
            <td><div style="text-align: right"></div></td>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnCalcular" runat="server" Text="Mostrar Reporte &gt;&gt;" OnClick="BtnCalcular_Click" />&nbsp;</td>
            <td>&nbsp;</td>
            <td style="width: 45px; height: 45px">
                <asp:ImageButton ID="ImgPrint" runat="server" Height="40px" ImageUrl="~/images/excel7.png" Width="40px" OnClientClick="ConfirmExport();" ToolTip="Exportar" OnClick="ImgPrint_Click" />
            </td>
        </tr>
        </table>
    <asp:GridView ID="GVListaViajes" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVListaViajes_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Id_Solicitud" HeaderText="Id_Solicitud" />
            <asp:BoundField DataField="ci" HeaderText="CI" />
            <asp:BoundField DataField="ext" HeaderText="EXT" />
<asp:BoundField DataField="Nombres" HeaderText="NOMBRES"></asp:BoundField>
            <asp:BoundField DataField="Primer_ap" HeaderText="PATERNO" />
            <asp:BoundField DataField="Segundo_ap" HeaderText="MATERNO" />
            <asp:BoundField DataField="Pago_Total" HeaderText="PAGO 100%" >
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Pago_Total15" HeaderText="PAGO 70%" >
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Total" HeaderText="PAGO TOTAL" >
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="FECHA_SALIDA" HeaderText="FECHA SALIDA" DataFormatString="{0:dd/MM/yyyy HH:mm}" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="FECHA_RETORNO" HeaderText="FECHA RETORNO" DataFormatString="{0:dd/MM/yyyy HH:mm}" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="DIAS">
                <ItemTemplate>
                    <asp:Label ID="LblFechRetorno" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
