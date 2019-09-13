<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repExtension3.aspx.cs" Inherits="WebAplication.ReportesGP.repExtension3" %>

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
                <td width="50">Regional: &nbsp;</td>
                <td><div style="text-align: left">
                    <asp:Label ID="LblReg" runat="server" style="font-weight: 700"></asp:Label>
                    <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                    </div></td>
                <td width="50">Programa:</td>
                <td>
                    <asp:Label ID="LblPrograma" runat="server" style="font-weight: 700"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">4. avance de la cosecha y acopio de la producción de arroz en la regional santa cruz por organización.</td>
                <td>Campaña:</td>
                <td>
                    <asp:Label ID="LblCamp" runat="server" style="font-weight: 700"></asp:Label>
                    <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    <asp:GridView ID="GVPRodDep" runat="server" CssClass="TableBorder2" AutoGenerateColumns="False" OnRowDataBound="GVPRodDep_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Municipio" HeaderText="Zona" />
            <asp:BoundField DataField="Sigla" HeaderText="Organización" />
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" />
            <asp:BoundField DataField="Id_Municipio" HeaderText="Id_Municipio" Visible="False" />
            <asp:TemplateField HeaderText="N° Productores">
                <ItemTemplate>
                     <div style="text-align: right"><asp:Label ID="LblNumP" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sup. Inscrita (ha)">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblSupIns" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sup. Apoyada (ha)">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblSupApo" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rendimiento (fn/ha)">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblRendFnha" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acopio (fn) est.">
                <ItemTemplate>
                    <asp:Label ID="LblAcopEstim" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acopio (fn)">
                <ItemTemplate>
                    <asp:Label ID="LblAcopFn" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Avance de cosecha (%)">
                <ItemTemplate>
                    <asp:Label ID="LblAvanceCosecha" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Diferencia (fn)">
                <ItemTemplate>
                    <asp:Label ID="LblDiferencia" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><div style="font-weight: 700; text-align: right">TOTAL:</div></td>
            <td width="60">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotNumProd" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="62">
                 <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotSupInsHa" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="64">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotSupApo" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="62">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotRendFnHa" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="60">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotProdfn" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="60">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotProdfn0" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="60">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotProdfn1" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="58">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotProdfn2" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>Elaborado en base a información del sistema SPIA y reportes técnicos semanales</td>
            <td width="60">
                &nbsp;</td>
            <td width="62">
                 &nbsp;</td>
            <td width="64">
                &nbsp;</td>
            <td width="62">
                &nbsp;</td>
            <td width="60">
                &nbsp;</td>
            <td width="60">
                &nbsp;</td>
            <td width="60">
                &nbsp;</td>
            <td width="58">
                &nbsp;</td>
        </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
