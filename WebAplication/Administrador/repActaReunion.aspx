<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repActaReunion.aspx.cs" Inherits="WebAplication.Administrador.repActaReunion" %>

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
                <td rowspan="3" width="200">
                    <asp:Image ID="Image1" runat="server" Height="70px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td>ACTA<asp:Label ID="LblIdReunion" runat="server"></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblTipoReunion" runat="server"></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td width="70">Campaña:</td>
                <td>
                    <asp:Label ID="LblCamp" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td width="100">&nbsp;</td>
            </tr>
            <tr>
                <td>Lugar:</td>
                <td>
                    <asp:Label ID="LblLugar" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td width="50">Fecha:</td>
                <td>
                    <asp:Label ID="LblFecha" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="TableBorder">
            <tr>
                <td>En Oficinas de la
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
&nbsp;se llevó a cabo el 
                    <asp:Label ID="LblTipoReunion1" runat="server" Text="Label"></asp:Label>
                    , con organizaciones de la Campaña Agricola de:&nbsp;
                    <asp:Label ID="LblCamp1" runat="server"></asp:Label>
                    &nbsp;en los talleres se tocaron los siguientes temas:</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div style="font-size: 8pt">
        <asp:GridView ID="GVAsistencia" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="ci" HeaderText="ci" />
                        <asp:BoundField DataField="Comunidad" HeaderText="Comunidad" />
                        <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
                        <asp:BoundField DataField="Representante" HeaderText="Representa a" />
                        <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                    </Columns>
                    </asp:GridView>
        </div>
                    <table class="TableBorder">
                        <tr>
                            <td class="auto-style2">Los participantes al taller conocen y comprenden todos los requisitos necesarios en la campaña agricola y están de acuerdo con la modalidad de intervención y cronograma planeado.<br />
                    Asistieron a la reunión:</td>
                        </tr>
                        <tr>
                            <td class="auto-style2"></td>
                        </tr>
        </table><div style="font-size: 8pt">
                    <asp:GridView ID="GVTarea" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
                        <Columns>
                            <asp:BoundField DataField="Criterios" HeaderText="Temas tratados" />
                        </Columns>
                    </asp:GridView>
               </div>
        <table class="TableBorder">
            <tr>
                <td width="80">Conclución:</td>
                <td>
                    <asp:Label ID="LblConclu" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
