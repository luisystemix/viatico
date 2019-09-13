<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repDistribSemillaOrg.aspx.cs" Inherits="WebAplication.Extensiones.repDistribSemillaOrg" %>

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
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ 303 R01</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">SEGUIMIENTO A LA DISTRIBUCIÓN DE SEMILLA</div></td>
                <td>
                    <div style="text-align: center">Versión 2</div></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td width="100">&nbsp;</td>
                <td width="300">&nbsp;</td>
                <td width="155">&nbsp;</td>
                <td width="200">&nbsp;</td>
                <td width="145">&nbsp;</td>
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
                <td>PROGRAMA:</td>
                <td>
                    <asp:Label ID="LblProg" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>ORGANIZACIÓN:<asp:Label ID="LblIdInsOrg" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblOrg" runat="server"></asp:Label>
                </td>
                <td>LUGAR DE DISTRIBUCIÓN:</td>
                <td>
                    <asp:Label ID="LblLugDistrib" runat="server"></asp:Label>
                </td>
                <td>EMPRESA PROVEEDORA:</td>
                <td>
                    <asp:Label ID="LblEmpresaProb" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <asp:GridView ID="GVListaSemilla" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
            <Columns>
                <asp:BoundField DataField="Productor" HeaderText="NONBRE DEL BENEFICIARIO"></asp:BoundField>
                <asp:BoundField DataField="Num_Boleta" HeaderText="N° BOLETA"></asp:BoundField>
                <asp:BoundField DataField="Cantidad" HeaderText="CANTIDAD"></asp:BoundField>
                <asp:BoundField DataField="Unidad" HeaderText="UNIDAD"></asp:BoundField>
                <asp:BoundField DataField="Valor1" HeaderText="VARIEDAD"></asp:BoundField>
                <asp:BoundField DataField="Valor3" HeaderText="N° DE LOTE"></asp:BoundField>
                <asp:BoundField DataField="Valor2" HeaderText="CATEGORIA"></asp:BoundField>
                <asp:BoundField DataField="Valor4" HeaderText="% GERMINACION"></asp:BoundField>
                <asp:BoundField DataField="Fecha_Caducidad" HeaderText="FCHA DE VENCIMIENTO"></asp:BoundField>
                <asp:BoundField HeaderText="RECIBI CONFORME"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td width="105">&nbsp;</td>
                <td>&nbsp;</td>
                <td width="270">&nbsp;</td>
                <td width="45">&nbsp;</td>
                <td width="100">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>FECHA:</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>OBSERVACIONES:</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5" class="auto-style1"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td><hr>Firma y nombre del técnico que verifico la distribución</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
