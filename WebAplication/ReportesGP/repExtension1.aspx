<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repExtension1.aspx.cs" Inherits="WebAplication.ReportesGP.repExtension1" %>

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
                <td><div style="font-weight: 700; text-align: center; font-size: x-large">VARIABLES PARA LOS REPORTES SPIA</div></td>
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ 303 R0?</div></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
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
                <td>&nbsp;</td>
                <td><div style="text-align: center">&nbsp;</div></td>
                <td width="50">Programa:</td>
                <td>
                    <asp:Label ID="LblPrograma" runat="server" style="font-weight: 700"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>1.	Superficie, rendimiento y Producción por departamento, por campaña.</td>
                <td>Campaña:</td>
                <td>
                    <asp:Label ID="LblCamp" runat="server" style="font-weight: 700"></asp:Label>
                    <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    <asp:GridView ID="GVPRodDep" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVPRodDep_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Departamento" HeaderText="Zonas" />
            <asp:BoundField DataField="Id_Campanhia" HeaderText="Id_Campanhia" Visible="False" />
            <asp:BoundField DataField="Id_Regional" HeaderText="Id_Regional" Visible="False" />
            <asp:TemplateField HeaderText="Sup. Inscrita (ha)">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblSupApo" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sup. Apoyada (ha)">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblSupSem" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rend (fn/ha)">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblRend" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Producción (fn)">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblProdFan" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Producción (t)">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblProdTon" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><div style="text-align: right; font-weight: 700">TOTAL:</div></td>
            <td width="119">
                <div style="text-align: right; font-weight: 700"><asp:Label ID="LblTotSupIns" runat="server" Text="0"></asp:Label></div>
            </td>
            <td width="118">
                <div style="text-align: right"><asp:Label ID="LblTotSupApo" runat="server" style="font-weight: 700" Text="0"></asp:Label></div>
            </td>
            <td width="119">
                <div style="text-align: right"><asp:Label ID="LblTotRedFn" runat="server" style="font-weight: 700" Text="0"></asp:Label></div>
            </td>
            <td width="119">
                <div style="text-align: right"><asp:Label ID="LblTotProdFn" runat="server" style="font-weight: 700" Text="0"></asp:Label></div>
            </td>
            <td width="116">
                <div style="text-align: right"><asp:Label ID="LblTotProdTon" runat="server" style="font-weight: 700" Text="0"></asp:Label></div>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
