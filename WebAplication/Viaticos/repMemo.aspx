<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repMemo.aspx.cs" Inherits="WebAplication.Viaticos.repMemo" %>

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
                <td width="200" rowspan="3">
                    <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td>&nbsp;</td>
                <td width="200"><div style="text-align: center">REGISTRO EUF/02 V2</div></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <div style="text-align: center"><asp:Label ID="LblIdSolicit" runat="server"></asp:Label></div></td>
            </tr>
            <tr>
                <td>
                    <div style="font-size: xx-large; text-align: center">
                    MEMORANDUM
                        </div>
        </td>
                <td></td>
            </tr>
        </table>

        <table class="TableBorder">
            <tr>
                <td>
                    <table class="TableBorder">
                        <tr>
                            <td width="60">&nbsp;</td>
                            <td width="240">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td><div style="text-align: right">La Paz,</div></td>
                            <td>
                                <asp:Label ID="LblFecha" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTest" runat="server" Text="Label" Visible="false"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table class="TableBorder">
                        <tr>
                            <td width="50">&nbsp;</td>
                            <td>
                                <div style="text-align: right"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>Para:</td>
                            <td>
                                <asp:Label ID="LblPersonal" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Label ID="LblCargo" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>De:</td>
                            <td>
                                <asp:Label ID="LblGaf" runat="server"></asp:Label>
                                </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                    <asp:Label ID="LblCargoA" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Ref.:</td>
                            <td>AUTORIZACION VIAJE</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td class="auto-style1">
                    <p/>
                    <br />
                    De mi consideración:</td>
            </tr>
            <tr>
                <td class="auto-style1">Por disposición de esta Gerencia, y en atención a la solicitud de viaje
                    <asp:Label ID="LblIdSolicitud" runat="server"></asp:Label>
                    &nbsp;, deberá constituirse en
                    <asp:Label ID="LblValor1" runat="server"></asp:Label>
                     a partir del
                    <asp:Label ID="LblValor2" runat="server"></asp:Label>
                    &nbsp;al
                    <asp:Label ID="LblValor5" runat="server"></asp:Label>
                    ,&nbsp; a objeto de realizar la siguiente actividad:</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong> - <asp:Label ID="LblActividad" runat="server"></asp:Label>
                    <p/>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style2">Para el efecto, la Unidad Financiera proporcionará
                    <asp:Label ID="LblValor3" runat="server"></asp:Label>
&nbsp;para su traslado via
                    <asp:Label ID="LblValor4" runat="server"></asp:Label>
&nbsp;y viaticos para su estadia durante el periodo antes mencionado.</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <br />
                    A su retorno, deberá remitir el Informe de Viaje correspondiente en el plazo de 8 días habiles, de acuerdo a normas vigentes.</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Atentamente,</td>
            </tr>
            <tr>
                <td class="auto-style1" height="120">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">c.c. RRHH<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Arch. SPIA</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
