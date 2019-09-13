<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmHistorial.aspx.cs" Inherits="WebAplication.Responsable.frmHistorial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../css/EmapaStyele.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 4px;
        }
        .auto-style2 {
            height: 19px;
        }
        .auto-style3 {
            width: 4px;
            height: 19px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="TableBorder">
            <tr>
                <td width="60">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td width="80">SPIA-EMAPA</td>
            </tr>
            <tr>
                <td>Persona:</td>
                <td>
                    <asp:Label ID="LblProductor" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Ci:</td>
                <td>
                    <asp:Label ID="LblCi" runat="server"></asp:Label>
                    <asp:Label ID="LblExt" runat="server"></asp:Label>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td>Deudas contraídas con EMAPA</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
        </table>
    
        <asp:GridView ID="GVDeuda" runat="server" style="font-size: 8pt" AutoGenerateColumns="False" CssClass="TableBorder">
            <Columns>
                <asp:BoundField DataField="P_JURIDICA" HeaderText="Personalidad juridica" />
                <asp:BoundField DataField="CAMPANHIA" HeaderText="Campaña" />
                <asp:BoundField DataField="PROGRAMA" HeaderText="Programa" />
                <asp:BoundField DataField="SUP_HAS" HeaderText="Sup(ha)" />
                <asp:BoundField DataField="COMUNIDAD" HeaderText="Comunidad" />
                <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" />
                <asp:BoundField DataField="PROVINCIA" HeaderText="Provincia" />
                <asp:BoundField DataField="DEPARTAMENTO" HeaderText="Departamento" />
                <asp:BoundField DataField="ID_CREDITO" HeaderText="Cred Cart." />
                <asp:BoundField DataField="MORA" HeaderText="MORA" />
            </Columns>
        </asp:GridView>
    
        <table class="TableBorder">
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td>Dependencia con EMAPA</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
        </table>
        <asp:GridView ID="GVDependencia" runat="server" CssClass="TableBorder">
        </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>Participación con EMAPA</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:GridView ID="GVParticipacion" runat="server" CssClass="TableBorder">
        </asp:GridView>
        </div>
    </form>
</body>
</html>
 