<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repInforme.aspx.cs" Inherits="WebAplication.Viaticos.repInforme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
            <link href="../css/EmapaStyele.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: small">
    
        <table class="TableBorder">
            <tr>
                <td width="150" rowspan="3">
                    <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td>&nbsp;</td>
                <td width="150"><div style="text-align: center">REGISTRO EUF/04 V2</div></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td><div style="text-align: center; font-size: medium">Empresa de Apoyo a la Producción de Alimentos</div></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td>
                    <asp:Label ID="LblIdSolicit" runat="server"></asp:Label>
                </td>
                <td>
                    <div style="text-align: right"><asp:Label ID="LblFecha" runat="server"></asp:Label></div>
                </td>
            </tr>
        </table>
        <table class="TableBorder">
            <tr>
                <td><div style="text-align: center"; class="SubTitulo">INFORME DE VIAJE</div></td>
            </tr>
        </table>
        <table class="TableBorder">
            <tr>
                <td class="auto-style1">De: <asp:Label ID="LblPersonal" runat="server"></asp:Label>
                </td>
                <td class="auto-style1">A:
                    <asp:Label ID="LblDirigidoA" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblCargo" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblCargoA" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="TableBorder">
            <tr>
                <td><strong>Día y Hora de Salida:</strong></td>
                <td>&nbsp;</td>
                <td><strong>Fecha y Hora de Retorno</strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblFechaSalida" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="LblFechaRetorno" runat="server"></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
        </table>
        <table class="TableBorder">
            <tr>
                <td>Por instrucciones superiores, me constituí a
                    <asp:Label ID="LblDestino" runat="server"></asp:Label>
                    , a objeto de realizar las siguientes actividades:</td>
            </tr>
            <tr>
                <td style="font-weight: 700">Objetivo del Viaje:</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblObjetivo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Actividades Realizadas:</strong></td>
            </tr>
            </table>
        <asp:DataList ID="DataList1" runat="server" CssClass="TableBorder" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <strong>Fecha:</strong>
                <asp:Label ID="FechaLabel" runat="server" Text='<%# Eval("Fecha") %>' />
                <br />
                Actividad:
                <asp:Label ID="ActividadLabel" runat="server" Text='<%# Eval("Actividad") %>' />
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EMAPAConnectionString %>" SelectCommand="SELECT     CONVERT(char(10),VIAT_INFORME_ACTIVIDAD.Fecha,103) As Fecha, VIAT_INFORME_ACTIVIDAD.Actividad 
FROM         VIAT_INFORME_ACTIVIDAD INNER JOIN
                      VIAT_INFORME ON VIAT_INFORME_ACTIVIDAD.Id_Informe = VIAT_INFORME.Id_Informe
WHERE     (VIAT_INFORME.Id_Solicitud = @IdSolicitud)  ORDER BY VIAT_INFORME_ACTIVIDAD.Fecha">
            <SelectParameters>
                <asp:ControlParameter ControlID="LblIdSolicit" Name="IdSolicitud" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <table class="TableBorder">
            <tr>
                <td><div style="font-weight: 700">Conclusión:</div></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblConclucion" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="font-weight: 700">
                    Recomendacion:</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRecomendacion" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="TableBorder">
                        <tr>
                            <%--<td height="50" width="200">&nbsp;</td>
                            <td width="200">&nbsp;</td>
                            <td>&nbsp;</td>--%>
                            <td style="text-align: center; width: 33%;">&nbsp;</td>
                            <td style="text-align: center; width: 33%;">&nbsp;</td>
                            <td style="text-align: center; width: 33%;">&nbsp;</td>
                        </tr>
                        <tr>                            
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>                            
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>                            
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <div style="text-align: center"><asp:Label ID="LblUsuario" runat="server"></asp:Label></div>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <div style="text-align: center"><asp:Label ID="LblCargo1" runat="server" Font-Bold="True"></asp:Label></div>
                            </td>
                            <td><div style="text-align: center">INMEDIATO SUPERIOR</div></td>
                            <td><div style="text-align: center">APROBADO G.A.F.</div></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
