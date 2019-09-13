<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repCronogramaReg.aspx.cs" Inherits="WebAplication.Control.repCronogramaReg" %>

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
                <td width="200"><div style="text-align: center">E-EMP/GP/P/X </div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">PROGRAMACIÓN DE ACTIVIDADES SEMANAL</div></td>
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
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td width="50">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td width="60">Para el mes: </td>
                <td>
                    <asp:Label ID="LblMes" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Campaña:</td>
                <td class="auto-style2">
                    <asp:Label ID="LblCamp" runat="server"></asp:Label>
                    <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                </td>
                <td class="auto-style2"></td>
                <td class="auto-style2">Regional:</td>
                <td class="auto-style3">
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
                    <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:GridView ID="GVCronogramas" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCreated="GVCronogramas_RowCreated">
            <Columns>
                <asp:BoundField DataField="Semana" HeaderText="Semana" />
                <asp:BoundField DataField="Personal" HeaderText="Personal" />
                <asp:BoundField DataField="FechaLunes" HeaderText="Fecha" />
                <asp:BoundField DataField="Lunes" HeaderText="Tarea" />
                <asp:BoundField DataField="FechaMartes" HeaderText="Fecha" />
                <asp:BoundField DataField="Martes" HeaderText="Tarea" />
                <asp:BoundField DataField="FechaMiercoles" HeaderText="Fecha" />
                <asp:BoundField DataField="Miercoles" HeaderText="Tarea" />
                <asp:BoundField DataField="FechaJueves" HeaderText="Fecha" />
                <asp:BoundField DataField="Jueves" HeaderText="Tarea" />
                <asp:BoundField DataField="FechaViernes" HeaderText="Fecha" />
                <asp:BoundField DataField="Viernes" HeaderText="Tarea" />
                <asp:BoundField DataField="FechaSabado" HeaderText="Fecha" />
                <asp:BoundField DataField="Sabado" HeaderText="Tarea" />
                <asp:BoundField DataField="FechaDomingo" HeaderText="Fecha" />
                <asp:BoundField DataField="Domingo" HeaderText="Tarea" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
