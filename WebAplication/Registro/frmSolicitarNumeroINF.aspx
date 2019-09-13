<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSolicitarNumeroINF.aspx.cs" Inherits="WebAplication.Registro.frmSolicitarNumeroINF" %>
<%@ Register src="contEncabezado1.ascx" tagname="contEncabezado1" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
  </script>  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        FORMULARIO PARA SOLICITAR NÚMERO DE INFORME</div>
        <uc1:contEncabezado1 ID="contEncabezado11" runat="server" />
    <div class="SubTitulo2">SOLICITAR NUMERACION</div><table class="TableBorder">
        <tr>
            <td width="120" class="auto-style2">Tipo Informe:</td>
            <td class="auto-style2">
                <asp:DropDownList ID="DDLTipoInf" runat="server">
                    <asp:ListItem Value="1">INFORME TÉCNICO PROVISIÓN</asp:ListItem>
                    <asp:ListItem Value="2">INFORME TÉCNICO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td width="120" class="auto-style2">Fecha para informe:</td>
            <td class="auto-style2">
                <asp:TextBox ID="TxtFecha" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td width="120">Referencia:</td>
            <td rowspan="2">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="400px" Height="50px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="120">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnSolicitNum" runat="server" Text="Solicitar Número de Informe" OnClick="BtnSolicitNum_Click" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <strong>DATOS OBLIGATORIOS PARA INFORME TÉCNICO</strong><table class="TableBorder">
        <tr>
            <td width="60">&nbsp;</td>
            <td width="120">Codigo y Numero:</td>
            <td>
                <asp:Label ID="LblNumero" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Fecha Informe:</td>
            <td>
                <asp:Label ID="LblFechaInf" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">Responsable:</td>
            <td class="auto-style1">
                <asp:Label ID="LblResponsable" runat="server"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">Cargo:</td>
            <td class="auto-style1">
                <asp:Label ID="LblCargo" runat="server"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Referencia:</td>
            <td>
                <asp:Label ID="LblRef" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblPrograma" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
