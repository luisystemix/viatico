<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repRegionesApoyadas.aspx.cs" Inherits="WebAplication.Control.repRegionesApoyadas" %>

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
                <td class="auto-style1"><div style="text-align: center">REGISTRO</div></td>
                <td width="200" class="auto-style1"><div style="text-align: center">E-EMP/GP/P/ </div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">CAMPAÑA AGRICOLA
                    <asp:Label ID="LblCamp" runat="server"></asp:Label>
                    <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                    </div></td>
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
                <td width="45">&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td width="45"></td>
                <td width="150"></td>
            </tr>
            <tr>
                <td>Región:</td>
                <td>
                    <asp:Label ID="LblRegion" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>Fecha:</td>
                <td>
                    <asp:Label ID="LblFecha" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    <asp:GridView ID="GVCampEmapa" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVCampEmapa_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
            <asp:BoundField DataField="Programa" HeaderText="Programa" />
            <asp:BoundField DataField="Id_Campanhia" HeaderText="Id_Campanhia" Visible="False" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" Visible="False" />
            <asp:BoundField DataField="Region" HeaderText="Region" Visible="False" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" />
            <asp:BoundField DataField="Id_Regional" HeaderText="Id_Regional" Visible="False" />
            <asp:TemplateField HeaderText="N° de Orgs">
                <ItemTemplate>
                    <asp:Label ID="LblNumOrg" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N° de Benefs">
                <ItemTemplate>
                    <asp:Label ID="LblNumProd" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sup Inscrita">
                <ItemTemplate>
                    <asp:Label ID="LblSupInscrita" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sup Apoyada">
                <ItemTemplate>
                    <asp:Label ID="LblSupApoyada" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N° Depurados">
                <ItemTemplate>
                    <asp:Label ID="LblNumDepurados" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td width="140"></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Total Organizaciones:</td>
                <td>
                    <asp:Label ID="LblTotOrg" runat="server" style="font-weight: 700">0</asp:Label>
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Total N° de Beneficiarios:</td>
                <td>
                    <asp:Label ID="LblTotNumBenef" runat="server" style="font-weight: 700">0</asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Total Superficie Inscrita:</td>
                <td>
                    <asp:Label ID="LblTotSupIns" runat="server" style="font-weight: 700">0</asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Total Supewrficie Apoyada:</td>
                <td>
                    <asp:Label ID="LblTotSupApo" runat="server" style="font-weight: 700">0</asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Total N° de Depurados:</td>
                <td>
                    <asp:Label ID="LblTotNumDep" runat="server" style="font-weight: 700">0</asp:Label>
                </td>
                <td>&nbsp;</td>
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
