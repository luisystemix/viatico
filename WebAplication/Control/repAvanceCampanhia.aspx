<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repAvanceCampanhia.aspx.cs" Inherits="WebAplication.Control.repAvanceCampanhia" %>

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
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ </div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">AVANCE DE LA COSECHA</div></td>
                <td>
                    <div style="text-align: center">Versión 1</div></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblPrograma" runat="server"></asp:Label>
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr>
        </table>
        <asp:GridView ID="GVAvances" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVAvances_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
                <asp:BoundField DataField="Sigla" HeaderText="Sigla" />
                <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" />
                <asp:TemplateField HeaderText="N° Beneficiarios">
                    <ItemTemplate>
                        <asp:Label ID="LblNumBenefVig" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sup. Apoyada">
                    <ItemTemplate>
                        <asp:Label ID="LblSupApoyada" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rendimiento">
                    <ItemTemplate>
                        <asp:Label ID="LblRendimiento" runat="server">0</asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Produccion Estimada (Fan)">
                    <ItemTemplate>
                        <asp:Label ID="LblProdEstim" runat="server">0</asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Acopio Estimado">
                    <ItemTemplate>
                        <asp:Label ID="LblAcoEstim" runat="server">0</asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Acopio (Fan)">
                    <ItemTemplate>
                        <asp:Label ID="LblAcoFan" runat="server" Text="0"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Avance de cosecha">
                    <ItemTemplate>
                        <asp:Label ID="LblAvanceSiem" runat="server" Text="0"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Superficie Cosechada">
                    <ItemTemplate>
                        <asp:Label ID="LblSupCosech" runat="server" Text="0"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Diferencia(Fanegas)">
                    <ItemTemplate>
                        <asp:Label ID="LblDifFan" runat="server" Text="0"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
