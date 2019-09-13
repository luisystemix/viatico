<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repCostosProductor.aspx.cs" Inherits="WebAplication.Extensiones.repCostosProductor" %>

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
                <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td width="80">PROGRAMA:</td>
                <td>
                    <asp:Label ID="LblProg" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td  width="105">ORGANIZACIÓN:</td>
                <td>
                    <asp:Label ID="LblOrg" runat="server"></asp:Label>
                    <asp:Label ID="LblIdInsOrg" runat="server" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td width="90">CAMPAÑA:</td>
                <td>
                    <asp:Label ID="LblCamp" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td width="75">REGIONAL:</td>
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
                <td class="auto-style1">PRODUCTOR:</td>
                <td>
                    <asp:Label ID="LblProd" runat="server"></asp:Label>
                    <asp:Label ID="LblIdInsProd" runat="server" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>TIPO SIEMBRA:</td>
                <td>
                    <asp:Label ID="LblTipoSiembra" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>SUPERFICIE:</td>
                <td>
                    <asp:Label ID="LblSupProd" runat="server"></asp:Label>
                    (ha)</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td width="20"><div style="text-align: center; font-weight: 700">N°</div></td>
                <td><div style="text-align: center; font-weight: 700">ITEM</div></td>
                <td width="60"><div style="text-align: center; font-weight: 700">Unidad</div></td>
                <td width="60"><div style="text-align: center; font-weight: 700">Cantidad o Dosis</div></td>
                <td width="60"><div style="text-align: center; font-weight: 700">Aplicaciones<br />
                    o Días</div></td>
                <td width="60"><div style="text-align: center; font-weight: 700">Precio Unitario&nbsp; (Bs/Ha)</div></td>
                <td width="60"><div style="text-align: center; font-weight: 700">COSTO TOTAL (Bs/Ha)</div></td>
                <td width="60"><div style="text-align: center; font-weight: 700">COSTO TOTAL&nbsp; ($us/Ha)</div></td>
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
    
        <asp:GridView ID="GVDesecacion" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField >
                <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="Insumo" Visible="False" >
                <ItemStyle Width="220px" />
                </asp:BoundField>
                <asp:BoundField DataField="Producto" >
                </asp:BoundField>
                <asp:BoundField DataField="Unidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Cantidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Num_Apli" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Precio_Unidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Costo_Total_Bs" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Costo_Total_Sus" >
                <ItemStyle Width="60px" />
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
                <td width="60">
                    <asp:Label ID="LblIBs" runat="server"></asp:Label>
                </td>
                <td width="60">
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
    
        <asp:GridView ID="GVPrepSueloSiem" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField>
                <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="Insumo" Visible="False" />
                <asp:BoundField DataField="Producto" />
                <asp:BoundField DataField="Unidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Cantidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Num_Apli" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Precio_Unidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Costo_Total_Bs" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Costo_Total_Sus" >
                <ItemStyle Width="60px" />
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
                <td width="60">
                    <asp:Label ID="LblIIBs" runat="server"></asp:Label>
                </td>
                <td width="60">
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
    
        <asp:GridView ID="GVInsumos" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField >
                <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="Insumo" Visible="False" />
                <asp:BoundField DataField="Producto" />
                <asp:BoundField DataField="Unidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Cantidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Num_Apli" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Precio_Unidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Costo_Total_Bs" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Costo_Total_Sus" >
                <ItemStyle Width="60px" />
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
                <td width="60">
                    <asp:Label ID="LblIIIBs" runat="server"></asp:Label>
                </td>
                <td width="60">
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
    
        <asp:GridView ID="GVServisCultural" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField >
                <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="Insumo" Visible="False" />
                <asp:BoundField DataField="Producto" />
                <asp:BoundField DataField="Unidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Cantidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Num_Apli" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Precio_Unidad" >
                <ItemStyle Width="60px" Wrap="True" />
                </asp:BoundField>
                <asp:BoundField DataField="Costo_Total_Bs" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Costo_Total_Sus" >
                <ItemStyle Width="60px" />
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
                <td width="60">
                    <asp:Label ID="LblIVBs" runat="server"></asp:Label>
                </td>
                <td width="60">
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
    
        <asp:GridView ID="GVCosechaTrans" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField >
                <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="Insumo" Visible="False" />
                <asp:BoundField DataField="Producto" />
                <asp:BoundField DataField="Unidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Cantidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Num_Apli" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Precio_Unidad" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Costo_Total_Bs" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Costo_Total_Sus" >
                <ItemStyle Width="60px" />
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
                <td width="60">
                    <asp:Label ID="LblVBs" runat="server"></asp:Label>
                </td>
                <td class="auto-style1" width="60">
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
                <td width="60">
                    <asp:Label ID="LblTotSus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
