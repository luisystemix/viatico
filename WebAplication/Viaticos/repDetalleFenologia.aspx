<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="repDetalleFenologia.aspx.cs" Inherits="WebAplication.Viaticos.repDetalleFenologia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/canvasjs.min.js"></script>
    <script type='text/javascript'>
       
    </script>
    <title>Reporte Semanal Estado Fenológico</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="TableBorder">        
        <tr>
            <%--<td width="135">Seleccionar la Campaña:</td>
            
            <td>&nbsp;</td>--%>
            <td width="70px">Regional:</td>
            <td >
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged" Width="160px">
                </asp:DropDownList>
            </td>
            <td style="width: 30px">               
               
            </td>
             <%--<asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>--%>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Usuario | Regional | Programa | Fase | Valor | FechaReg(Ini) | FechaReg(Fin)"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Semanas"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged" Width="160px">
                    <asp:ListItem Value="0">Seleccione Programa</asp:ListItem>
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                </td>
            <td></td>            
            <td>
                <asp:DropDownList ID="ddlDatosGrafica" runat="server" AutoPostBack="False" Width="450px" Font-Size="X-Small">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlSemanas" runat="server" AutoPostBack="True" Width="250px" OnSelectedIndexChanged="ddlSemanas_SelectedIndexChanged" Font-Size="X-Small">
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Label ID="LblIdUsuario" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
            </td>
        </tr>
    </table>
    <iframe id="iframe1" runat="server" width=1100 height=500 frameborder="1"/>  
</asp:Content>
