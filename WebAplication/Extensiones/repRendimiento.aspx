<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repRendimiento.aspx.cs" Inherits="WebAplication.Extensiones.repRendimiento" %>

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
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ 303 R09</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">REPORTE DEL RENDIMIENTO DEL GRANO DE
                    <asp:Label ID="LblProg" runat="server" Text="TRIGO"></asp:Label>
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
                <td width="70">&nbsp;</td>
                <td width="200"><asp:Label ID="LblIdInsOrg" runat="server" Visible="False"></asp:Label>
                </td>
                <td width="70">&nbsp;</td>
                <td>
                <asp:Label ID="LblIdUsuario" runat="server" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>CAMPAÑA:</td>
                <td>
                    <asp:Label ID="LblCamp" runat="server"></asp:Label>
                </td>
                <td>REGIONAL:</td>
                <td>
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <asp:GridView ID="GVListRendimiento" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
            <Columns>
                <asp:BoundField DataField="Personeria_Juridica" HeaderText="ORGANIZACIÓN" />
                <asp:BoundField DataField="Productor" HeaderText="BENEFICIACIO" />
                <asp:BoundField DataField="Variedad_Semilla" HeaderText="Variedad_Semilla" />
                <asp:BoundField DataField="Fech_Inspeccion" HeaderText="Fech_Inspeccion" />
                <asp:BoundField DataField="Face_Fenologia" HeaderText="Face_Fenologia" />
                <asp:BoundField DataField="Valor1" HeaderText="N° de Espigas por m2" />
                <asp:BoundField DataField="valor2" HeaderText="N° de Granos por Espiga" />
                <asp:BoundField DataField="Valor5" HeaderText="Peso de 1.000 Granos (gr.)" />
                <asp:BoundField DataField="Valor6" HeaderText="% de Humedad" />
                <asp:BoundField DataField="Valor7" HeaderText="Kg/Ha" />
                <asp:BoundField DataField="Valor8" HeaderText="(t/ha)" />
            </Columns>
        </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td width="150">&nbsp;</td>
                <td width="300">&nbsp;</td>
                <td width="60">&nbsp;</td>
                <td width="100">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td width="150">&nbsp;</td>
                <td width="300">&nbsp;</td>
                <td width="60">&nbsp;</td>
                <td width="100">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>TÉCNICO ENCARGADO:</td>
                <td><hr></td>
                <td><div style="text-align: right">Vo. Bo.</div></td>
                <td><hr></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Nombre y cargo</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
