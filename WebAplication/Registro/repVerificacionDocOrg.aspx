<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repVerificacionDocOrg.aspx.cs" Inherits="WebAplication.Registro.repVerificacionDocOrg1" %>

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
            <td width="200" rowspan="3">
                <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="131px" />
            </td>
            <td>&nbsp;</td>
            <td width="200"></td>
        </tr>
        <tr>
            <td class="textoCentro">REGISTRO</td>
            <td><div style="text-align: center">E-EMP/GP/ P /301 R02</div></td>
        </tr>
        <tr>
            <td><div class="textoCentro">VERIFICACIÓN DE DOCUMENTACIÓN DE PRODUCTORES</div></td>
            <td><div style="text-align: center">Verción N° 4</div></td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="170">CAMPAÑA AGRÍCOLA:</td>
            <td>
                <asp:Label ID="LblCampanhia" runat="server"></asp:Label>
                <asp:Label ID="LblIdIsnOrg" runat="server" Text="1"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="200" colspan="2">REGIONAL:
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">ORGANIZACIÓN:</td>
            <td class="auto-style1" colspan="3">
                <asp:Label ID="LblOrganizacion" runat="server"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>N° DE PRODUCTORES:</td>
            <td>
                <asp:Label ID="LblNumProd" runat="server" CssClass="textoFondoIzq"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1">PROGRAMA:</td>
            <td class="auto-style1">
                <asp:Label ID="LblPrograma" runat="server"></asp:Label>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1" colspan="2">SUPERFICIE TOTAL (ha):
                <asp:Label ID="LblSuperficie" runat="server" CssClass="textoFondoIzq"></asp:Label>
            </td>
        </tr>
    </table>
        <div>
    <asp:GridView ID="GVInsOrgDocPres" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVInsOrgDocPres_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Documento" HeaderText="Documento solicitado" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" />
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="40px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </div>
    <table class="TableBorder">
        <tr>
            <td width="90">Observación:</td>
            <td rowspan="2">
                <asp:Label ID="LblObservacion" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="160" class="auto-style1">Responsable de Revisión:</td>
            <td class="auto-style1">
                <asp:Label ID="LblResponsable" runat="server"></asp:Label>
            </td>
            <td width="50" class="auto-style1">&nbsp;</td>
            <td class="auto-style1" rowspan="2" width="200"></td>
        </tr>
        <tr>
            <td width="160" class="auto-style1">&nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
            <td width="50" class="auto-style1">Firma:</td>
        </tr>
        <tr>
            <td class="auto-style1">Fecha de revisión:</td>
            <td class="auto-style1">
                <asp:Label ID="LblFecha" runat="server"></asp:Label>
            </td>
            <td class="auto-style1">CI:</td>
            <td class="auto-style1">
                <asp:Label ID="LblCi" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
