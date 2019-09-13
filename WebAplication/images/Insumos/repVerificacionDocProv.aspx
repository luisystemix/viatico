<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repVerificacionDocProv.aspx.cs" Inherits="WebAplication.Insumos.repVerificacionDocProv" %>

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
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo1.jpg" Width="100px" />
                </td>
                <td>&nbsp;</td>
                <td width="200">&nbsp;</td>
            </tr>
            <tr>
                <td>GERENCIA DE PRODUCCIÓN</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>ADQUISICIÓN DE INSUMOS - MODALIDAD DIRECTA</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td width="190">Proceso de contratación N°:</td>
                <td>
                    <asp:Label ID="LblNumProsContrat" runat="server" Text="67"></asp:Label>
                </td>
                <td width="60">&nbsp;</td>
                <td width="130">&nbsp;</td>
            </tr>
            <tr>
                <td>Proveedor:</td>
                <td>
                    <asp:Label ID="LblProveedor" runat="server"></asp:Label>
                    <asp:Label ID="LblIdIsnProv" runat="server"></asp:Label>
                </td>
                <td>Insumo:</td>
                <td>
                    <asp:Label ID="LblInsumo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>Programa:</td>
                <td>
                    <asp:Label ID="LblPrograma" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
        <asp:GridView ID="GVDocVerfProv" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVDocVerfProv_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Documento" HeaderText="Documento" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
