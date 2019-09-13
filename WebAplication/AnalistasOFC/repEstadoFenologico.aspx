<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repEstadoFenologico.aspx.cs" Inherits="WebAplication.AnalistasOFC.repEstadoFenologico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="../css/EmapaStyele.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table class="TableBorder">
            <tr>
                <td width="200" rowspan="3">
                    <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td><div style="text-align: center">REGISTRO</div></td>
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ 303 R05</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">SEGUIMIENTO DEL CULTIVO
                    <asp:Label ID="LblPrograma" runat="server"></asp:Label>
                    ,&nbsp;SEGÚN FASE FENOLÓGICA</div></td>
                <td>
                    <div style="text-align: center">Versión 1</div></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td width="70">&nbsp;</td>
                <td width="70">&nbsp;</td>
                <td width="200"><asp:Label ID="LblIdInsOrg" runat="server" Visible="False"></asp:Label>
                </td>
                <td width="70">&nbsp;</td>
                <td>
                <asp:Label ID="LblIdUsuario" runat="server" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>CAMPAÑA:</td>
                <td>
                    <asp:Label ID="LblCamp" runat="server"></asp:Label>
                    <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                </td>
                <td>REGIONAL:</td>
                <td>
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
                    <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblNumSegCult" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="LblTipo" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    <asp:GridView ID="GVEnvioSem" runat="server" AutoGenerateColumns="False" CssClass="TableBorder2">
        <Columns>
            <asp:BoundField HeaderText="Periodo" DataField="Fecha_Semana" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" />
            <asp:BoundField DataField="Num_Prod_Vigente" HeaderText="Num_Prod_Vigente" />
            <asp:BoundField DataField="Sup_Sembrada" HeaderText="Sup_Sembrada" />
            <asp:BoundField DataField="Avance_Siembra" HeaderText="Avance_Siembra" />
            <asp:BoundField DataField="Germinacion" HeaderText="Germinacion" />
            <asp:BoundField DataField="Plantula" HeaderText="Plantula" />
            <asp:BoundField DataField="Macollamiento" HeaderText="Macollamiento" />
            <asp:BoundField DataField="Embuche" HeaderText="Embuche" />
            <asp:BoundField DataField="Espigazon" HeaderText="Espigazon" />
            <asp:BoundField DataField="Floracion" HeaderText="Floracion" />
            <asp:BoundField DataField="Llenado_Grano" HeaderText="Llenado_Grano" />
            <asp:BoundField DataField="Maduracion" HeaderText="Maduracion" />
            <asp:BoundField DataField="Avance_cosecha" HeaderText="Avance_cosecha" />
            <asp:BoundField DataField="Rendimiento" HeaderText="Rendimiento" />
            <asp:BoundField DataField="Hasta" HeaderText="Hasta" Visible="False" />
        </Columns>
    </asp:GridView>
    
    </div>
    </form>
</body>
</html>
