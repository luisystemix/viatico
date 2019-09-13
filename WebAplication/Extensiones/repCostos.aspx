<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repCostos.aspx.cs" Inherits="WebAplication.Extensiones.repCostos" %>

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
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ 303 R12</div></td>
            </tr>
            <tr>
                <td class="auto-style5"><div style="text-align: center">PLANILLA DE COSTOS DE PRODUCCIÓN</div></td>
                <td class="auto-style5">
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
                <td class="auto-style4">&nbsp;</td>
                <td width="20">&nbsp;</td>
                <td width="105">&nbsp;</td>
                <td>&nbsp;</td>
                <td width="20">&nbsp;</td>
                <td width="70">&nbsp;</td>
                <td>&nbsp;</td>
                <td width="20">&nbsp;</td>
                <td width="70">&nbsp;</td>
                <td width="100">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>PROGRAMA:</td>
                <td class="auto-style4">
                    <asp:Label ID="LblProg" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>ORGANIZACIÓN:</td>
                <td>
                    <asp:Label ID="LblOrg" runat="server"></asp:Label>
                    <asp:Label ID="LblIdInsOrg" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>CAMPAÑA:</td>
                <td>
                    <asp:Label ID="LblCamp" runat="server"></asp:Label>
                    <asp:Label ID="LblTipoSiembra" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>REGIONAL:</td>
                <td>
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>SUP. PROMEDIO:</td>
                <td>
                    <asp:Label ID="LblSupPromedio" runat="server"></asp:Label>
                    (ha)</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td width="20"><div style="text-align: center; font-weight: 700">N°</div></td>
                <td><div style="text-align: center; font-weight: 700">ITEM</div></td>
                <td width="120"><div style="text-align: center; font-weight: 700">COSTO TOTAL (Bs/Ha)</div></td>
                <td width="120"><div style="text-align: center; font-weight: 700">COSTO TOTAL&nbsp; ($us/Ha)</div></td>
            </tr>
            </table>
    
        <table class="TableBorder">
            <tr>
                <td>I. DESECACION:</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <asp:GridView ID="GVDesecacion" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVDesecacion_RowDataBound">
            <Columns>
                <asp:BoundField>
                <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="Etapa_Cultivo" Visible="False" />
                <asp:BoundField DataField="Insumo" Visible="False" />
                <asp:BoundField DataField="Tipo_Recurso" />
                <asp:BoundField>
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField>
                <ItemStyle Width="100px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td width="75">SUB TOTAL: </td>
                <td width="100">
                    <asp:Label ID="LblIBs" runat="server"></asp:Label>
                </td>
                <td width="100">
                    <asp:Label ID="LblISus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>II. PREPARACION DE SUELO Y SIEMBRA:</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <asp:GridView ID="GVPrepSueloSiem" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVPrepSueloSiem_RowDataBound">
            <Columns>
                <asp:BoundField>
                <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="Etapa_Cultivo" Visible="False" />
                <asp:BoundField DataField="Insumo" Visible="False" />
                <asp:BoundField DataField="Tipo_Recurso" />
                <asp:BoundField>
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField>
                <ItemStyle Width="100px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td width="75">SUB TOTAL: </td>
                <td width="100">
                    <asp:Label ID="LblIIBs" runat="server"></asp:Label>
                </td>
                <td width="100">
                    <asp:Label ID="LblIISus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>III. INSUMOS</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <asp:GridView ID="GVInsumos" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVInsumos_RowDataBound">
            <Columns>
                <asp:BoundField>
                <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="Etapa_Cultivo" Visible="False" />
                <asp:BoundField DataField="Insumo" Visible="False" />
                <asp:BoundField DataField="Tipo_Recurso"></asp:BoundField>
                <asp:BoundField>
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField>
                <ItemStyle Width="100px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td width="75">SUB TOTAL: </td>
                <td width="100">
                    <asp:Label ID="LblIIIBs" runat="server"></asp:Label>
                </td>
                <td width="100">
                    <asp:Label ID="LblIIISus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>IV. SERVICIOS CULTURALES:</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <asp:GridView ID="GVServisCultural" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVServisCultural_RowDataBound">
            <Columns>
                <asp:BoundField>
                <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="Etapa_Cultivo" Visible="False" />
                <asp:BoundField DataField="Insumo" Visible="False" />
                <asp:BoundField DataField="Tipo_Recurso" />
                <asp:BoundField>
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField>
                <ItemStyle Width="100px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td width="75">SUB TOTAL: </td>
                <td width="100">
                    <asp:Label ID="LblIVBs" runat="server"></asp:Label>
                </td>
                <td width="100">
                    <asp:Label ID="LblIVSus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>V. COSECHA Y TRANSPORTE:</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <asp:GridView ID="GVCosechaTrans" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVCosechaTrans_RowDataBound">
            <Columns>
                <asp:BoundField>
                <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="Etapa_Cultivo" Visible="False" />
                <asp:BoundField DataField="Insumo" Visible="False" />
                <asp:BoundField DataField="Tipo_Recurso" />
                <asp:BoundField>
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField>
                <ItemStyle Width="100px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td width="75">SUB TOTAL: </td>
                <td width="100">
                    <asp:Label ID="LblVBs" runat="server"></asp:Label>
                </td>
                <td class="auto-style1" width="100">
                    <asp:Label ID="LblVSus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td width="185">TOTAL COSTO DE PODUCCIÓN:</td>
                <td width="100">
                    <asp:Label ID="LblTotBs" runat="server"></asp:Label>
                </td>
                <td width="100">
                    <asp:Label ID="LblTotSus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
