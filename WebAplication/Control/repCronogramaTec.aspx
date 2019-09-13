<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repCronogramaTec.aspx.cs" Inherits="WebAplication.Control.repCronogramaTec" %>

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
                <td width="200"><div style="text-align: center">E-EMP/GP/P/X </div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">PROGRAMACIÓN DE ACTIVIDADES SEMANAL </div></td>
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
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td width="50">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td width="60">Programa:</td>
                <td>
                    <asp:Label ID="LblPrograma" runat="server"></asp:Label>
                    <asp:Label ID="LblIdCrono" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Campaña:</td>
                <td class="auto-style2">
                    <asp:Label ID="LblCamp" runat="server"></asp:Label>
                    <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                </td>
                <td class="auto-style2"></td>
                <td class="auto-style2">Regional:</td>
                <td class="auto-style3">
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
                    <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    <asp:GridView ID="GVCronogramas" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVCronogramas_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Tarea" HeaderText="Tarea" />
            <asp:BoundField DataField="Gestion" HeaderText="Gestion" />
            <asp:TemplateField HeaderText="Enero">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Febrero">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado2" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Marzo">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado3" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Abril">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado4" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mayo">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado5" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Junio">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado6" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Julio">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado7" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Agosto">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado8" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Septiembre">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado9" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Octubre">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado10" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Noviembre">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado11" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Diciembre">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado12" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    </div>
    </form>
</body>
</html>
