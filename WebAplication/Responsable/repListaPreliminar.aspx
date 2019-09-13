<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repListaPreliminar.aspx.cs" Inherits="WebAplication.Responsable.repListaPreliminar" %>

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
                <td rowspan="3" width="200">
                    <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td class="auto-style3"></td>
                <td width="200" class="auto-style3"><div style="text-align: center">E-EMP/GP/ P /301 R03</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">REGISTRO</div>
                <td><div style="text-align: center">Versión N°2</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">LISTA PRELIMINAR DE BENEFICIARIOS</div>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td width="100">PROGRAMA:</td>
                <td>
                    <asp:Label ID="LblPrograma" runat="server"></asp:Label>
                    <asp:Label ID="LblIdInsOrg" runat="server" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td width="80">CAMPAÑA:</td>
                <td>
                    <asp:Label ID="LblCampanhia" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>REGIONAL:</td>
                <td>
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    <div style="font-size: 8pt">
        <asp:GridView ID="GVListOfi" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
            <Columns>
                <asp:BoundField DataField="NUM" HeaderText="N°" />
                <asp:BoundField HeaderText="ID CRED" Visible="False" />
                <asp:BoundField DataField="Nombres" HeaderText="NOMBRES" />
                <asp:BoundField DataField="Primer_ap" HeaderText="PRIMER APELLIDO" />
                <asp:BoundField DataField="Segundo_ap" HeaderText="SEGUNDO APELLIDO" />
                <asp:BoundField DataField="Cedula" HeaderText="CI" />
                <asp:BoundField DataField="Municipio" HeaderText="MUNICIPIO" />
                <asp:BoundField DataField="Personeria_Juridica" HeaderText="ORGANIZACIÓN" />
                <asp:BoundField DataField="Comunidad" HeaderText="COMUNIDAD" />
                <asp:BoundField DataField="Has_Inscrito" HeaderText="SUP INSCRITA ha" />
                <asp:BoundField DataField="Departamento" HeaderText="DEPARTAMENTO" Visible="False" />
                <asp:BoundField DataField="Provincia" HeaderText="PROVINCIA" Visible="False" />
                <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
            </Columns>
        </asp:GridView>
        </div>
        <table class="TableBorder">
            <tr>
                <td width="100">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td width="100">&nbsp;</td>
                <td>Fecha.........................................................................................VoBo del técnico o analista de cartera: </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
