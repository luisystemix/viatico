<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repDistribAgroQuimOrg.aspx.cs" Inherits="WebAplication.Extensiones.repDistribAgroQuimOrg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
               <link href="../css/EmapaStyele.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: xx-small">
    
        <table class="TableBorder">
            <tr>
                <td width="200" rowspan="3">
                    <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td><div style="text-align: center">REGISTRO</div></td>
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ 303 R04</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">SEGUIMIENTO A LA DISTRIBUCIÓN DE AGROQUIMICOS/FERTILIZANTES</div></td>
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
                <td>
                    <asp:Label ID="LblAux" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <asp:GridView ID="GVListDistQuim" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVListDistQuim_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Productor" HeaderText="NOMBRE DEL BENEFICIARIO" />
                <asp:BoundField DataField="Id_Productor" HeaderText="Id_Productor" Visible="False" />
                <asp:TemplateField HeaderText="N° DE BOLETA">
                    <ItemTemplate>
                        <asp:DataList ID="DTLNumBolet" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="Num_BoletaLabel" runat="server" Text='<%# Eval("Num_Boleta") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FECHA DISTRIBUCION">
                    <ItemTemplate>
                        <asp:DataList ID="DTLFechaDistrib" runat="server" Width="119px">
                            <ItemTemplate>
                                <asp:Label ID="Num_BoletaLabel" runat="server" Text='<%# Eval("Fecha_Distribucion") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PRODUCTO">
                    <ItemTemplate>
                        <asp:DataList ID="DTLProducto" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="Num_BoletaLabel" runat="server" Text='<%# Eval("Valor1") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NOMBRE COMERCIAL">
                    <ItemTemplate>
                        <asp:DataList ID="DTLNomComer" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="Num_BoletaLabel" runat="server" Text='<%# Eval("Valor3") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FECHA DE CADUCIDAD">
                    <ItemTemplate>
                        <asp:DataList ID="DTLFechCaducid" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="Num_BoletaLabel" runat="server" Text='<%# Eval("Fecha_Caducidad") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UNIDAD">
                    <ItemTemplate>
                        <asp:DataList ID="DTLUnidad" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="Num_BoletaLabel" runat="server" Text='<%# Eval("Unidad") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CANTIDAD">
                    <ItemTemplate>
                        <asp:DataList ID="DTLCantidad" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="Num_BoletaLabel" runat="server" Text='<%# Eval("Cantidad") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="RECIBI CONFORME" />
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
                <td colspan="5">
                    &nbsp;</td>
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
