<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repPlanillaPago.aspx.cs" Inherits="WebAplication.Viaticos.repPlanillaPago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
       <link href="../css/EmapaStyele.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style1 {
            width: 74px;
        }
    </style>

    </head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 9pt">
    
        <table class="TableBorder">
            <tr>
                <td width="200" rowspan="3">
                    <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td>&nbsp;</td>
                <td width="200"><div style="text-align: center">REGISTRO EUF/03 V2</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">CALCULO DE COMISIÓN Y PAGO DE VIÁTICOS</div></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td>Fecha Elaboración:
                <asp:Label ID="LblFechaActual" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    <table class="TableBorder">
        <tr>
            <td width="60">Nombre:</td>
            <td>
                <asp:Label ID="LblNombre" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <%--<td width="70">Meno N°:</td>--%>
            <td width="70">C.I.:</td>
            <td>
                <asp:Label ID="LblCI" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td width="80">&nbsp;</td>
            <td>
                <asp:Label ID="LblIdSolicitud" runat="server" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Cargo:</td>
            <td>
                <asp:Label ID="LblCargo" runat="server"></asp:Label>
            </td>
            <td></td>
            <td>Fecha Salida:</td>
            <td>
                <asp:Label ID="LblFechaSalida" runat="server"></asp:Label>
            </td>
            <td>Fecha Retorno:</td>
            <td>
                <asp:Label ID="LblFechaRetorno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Destino:</td>
            <td>
                <asp:Label ID="LblDestino" runat="server"></asp:Label>
            </td>
            <td></td>
            <td>Categoria:</td>
            <td>
                <asp:Label ID="LblCategoria" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
        <table class="TableBorder">
            <tr>
                <td>
                    <div style="font-weight: 700; background-color:#e1e3df; text-align:center">
                        DETALLE DE DIAS EN COMISIÓN
                        </div>
                        </td>                                   
            </tr>
        </table>
    <asp:GridView ID="GVDetallePlanilla" runat="server" AutoGenerateColumns="False" CssClass="TableBorder"
        OnRowDataBound="GVDetallePlanilla_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="N°" DataField="Cont" />
            <asp:BoundField HeaderText="Fecha" DataField="FechaDia" />
<asp:BoundField HeaderText="Hora" DataField="Hora"></asp:BoundField>
            <asp:BoundField HeaderText="Área" DataField="Area" />
            <asp:BoundField HeaderText="Destino" DataField="Destino" Visible="False" />
            <asp:BoundField HeaderText="N° Dias" DataField="Num_Dias" />
            <asp:BoundField HeaderText="Monto" DataField="Monto" />
            <asp:BoundField DataField="Observacion" HeaderText="Observación" />
        </Columns>
    </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td>
                    <div style="font-weight: 700; background-color:#e1e3df; text-align:center">
                    DETALLE DE PAGO POR VIATICO
                        </div>
                </td>
            </tr>
        </table>
    <table class="TableBorder">
        <tr>
            <td width="35">&nbsp;</td>
            <td>Monto</td>
            <td>Dias de Comisión:</td>
            <td>Total Viaticos</td>
            <td class="auto-style1">&nbsp;</td>
            <td>Liquido Pagable</td>
            <td>N° Cuenta o cheque</td>
            <td>Firma</td>
        </tr>
        <tr>
            <td>
                100%</td>
            <td>
                <asp:Label ID="Lbl100" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblDiasCom" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblTotalMonto" runat="server">0</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Label ID="LblConIVA" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblLiquidoTotal" runat="server"></asp:Label>
            </td>
            <td rowspan="2">
                <div style="text-align: center"><asp:Label ID="LblNumCuenta" runat="server"></asp:Label></div>
            </td>
            <td rowspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                70%</td>
            <td>
                <asp:Label ID="Lbl70" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblDiasCom10" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblTotalMonto10" runat="server"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Label ID="LblConIVA10" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblLiquidoTotal10" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>Total a pagar:
                <asp:Label ID="LblTotalPago" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>Beneficiario</td>
        </tr>
    </table>
        <table class="TableBorder">
            <tr>
                <td class="AnchoColumnas" style="text-align:center">Elaborado por:</td>
                <td class="AnchoColumnas" style="text-align:center">Vo Bo Finanzas</td>
                <td class="AnchoColumnas" style="text-align:center">Aprobado G.A.F.</td>
            </tr>
            <tr>
                <td class="AnchoColumnas" style="text-align:center">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
                <td class="AnchoColumnas" style="text-align:center">&nbsp;</td>
                <td class="AnchoColumnas" style="text-align:center">&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
