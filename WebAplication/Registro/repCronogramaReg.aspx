<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repCronogramaReg.aspx.cs" Inherits="WebAplication.Registro.repCronogramaReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

 .TableBorder
 {
    border: 1px solid #BBB;
    width: 100%;
    margin-bottom: 0px;
    margin-top: 0px;
    font-size: 9pt;
}
 </style>
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
                <td width="200"><div style="text-align: center">E-EMP/GP/P/301 R07</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">CRONOGRAMA PLANIFICADO DE LA CAMPAÑA AGRÍCOLA</div></td>
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
            <td width="70">Campaña:</td>
            <td>
                <asp:Label ID="LblCampanhia" runat="server"></asp:Label>
            &nbsp;(Programa:
                <asp:Label ID="LblPrograma" runat="server"></asp:Label>
                )</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Regional;</td>
            <td>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdCrono" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>

    <asp:GridView ID="GVConograma" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Numero" HeaderText="N°" />
            <asp:BoundField DataField="Actividad" HeaderText="Actividad Planificada" />
            <asp:BoundField DataField="Inicio_Ejecutado" HeaderText="Fecha Inicio" />
            <asp:BoundField DataField="Final_Ejecutado" HeaderText="Fecha Final" />
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td width="80">Cronograma:</td>
            <td>
                <asp:Label ID="LblCronograma" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="60">Fecha:</td>
            <td width="200">
                <asp:Label ID="LblFecha" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Responsable:</td>
            <td>
                <asp:Label ID="LblNombre" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    </div>
    </form>
</body>
</html>
