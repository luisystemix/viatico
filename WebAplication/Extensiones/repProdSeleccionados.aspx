<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repProdSeleccionados.aspx.cs" Inherits="WebAplication.Extensiones.repProdSeleccionados" %>

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
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ XYZ</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">
                    LISTA DE DE PRODUCTORES SELEECIONADOS POR EL TÉCNICO  DE CAMPO, PROGRAMA:
                    <asp:Label ID="LblPrograma" runat="server"></asp:Label>
                    </div></td>
                <td>
                    <div style="text-align: center">Versión ?</div></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                </td>
                <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
        <asp:GridView ID="GVDesignado" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
            <Columns>
                <asp:BoundField DataField="Personeria_Juridica" HeaderText="Personeria_Juridica" />
                <asp:BoundField DataField="Productor" HeaderText="Productor" />
                <asp:BoundField DataField="ci" HeaderText="ci" />
                <asp:BoundField DataField="Comunidad" HeaderText="Comunidad" />
                <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
                <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                <asp:BoundField DataField="Tipo_Produccion" HeaderText="Tipo_Produccion" />
                <asp:BoundField DataField="Has_Inscrito" HeaderText="Has_Inscrito" />
            </Columns>
        </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Personal EMAPA:</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
