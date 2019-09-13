<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repPlanillaProductores.aspx.cs" Inherits="WebAplication.Registro.repPlanillaProductores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/EmapaStyele.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 10pt">
        <table class="TableBorder">
            <tr>
                <td rowspan="3" width="200">
                    <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td class="auto-style3"></td>
                <td width="200" class="auto-style3"><div style="text-align: center">E-EMP/GP/P301 R01</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">REGISTRO</div>
                <td><div style="text-align: center">Versión N°2</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">PLANILLA DE PRODUCTORES</div>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td width="85">Departamento:</td>
                <td>
                    <asp:Label ID="LblDepartamento" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td width="160">Campaña:</td>
                <td class="auto-style1" width="300">
                    <asp:Label ID="LblCampanhia" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>Nombre de la Organización:</td>
                <td class="auto-style1">
                    <asp:Label ID="LblNombreOrg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Sigla</td>
                <td>
                    <asp:Label ID="LblSiglaOrg" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>Programa:</td>
                <td class="auto-style1">
                    <asp:Label ID="LblProg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
        <div style="font-size: 8pt">
        <asp:GridView ID="GVListaProd" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
            <Columns>
                <asp:BoundField DataField="NUM" HeaderText="N°">
                <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                <asp:BoundField DataField="Primer_ap" HeaderText="Paterno" />
                <asp:BoundField DataField="Segundo_ap" HeaderText="Materno" />
                <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                <asp:BoundField DataField="Has_Inscrito" HeaderText="Has_Inscrito" />
                <asp:BoundField DataField="Comunidad" HeaderText="Comunidad" />
                <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
                <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                <asp:TemplateField HeaderText="      Firma       ">
                    <ItemTemplate>
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Huella Digital"></asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
