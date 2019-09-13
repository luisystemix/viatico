<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repCronogramaSeg.aspx.cs" Inherits="WebAplication.Control.repCronogramaSeg" %>

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
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ </div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">CAMPAÑA AGRICOLA</div></td>
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
                    <asp:Label ID="LblIdCrono" runat="server"></asp:Label>
                </td>
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
                <td class="auto-style2">Personal:</td>
                <td class="auto-style2">
                    <asp:Label ID="LblPersonal" runat="server"></asp:Label>
                </td>
                <td class="auto-style2"></td>
                <td class="auto-style2">Regional:</td>
                <td class="auto-style3">
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    <asp:GridView ID="GVCronogramas" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCreated="GVCronogramas_RowCreated" OnRowDataBound="GVCronogramas_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Semana" HeaderText="Semana" />
            <asp:BoundField DataField="Id_Cronograma" HeaderText="Id_Cronograma" Visible="False" />
            <asp:BoundField DataField="FechaLunes" HeaderText="Fecha" Visible="False" />
            <asp:BoundField DataField="Lunes" HeaderText="Tarea" />
            <asp:BoundField DataField="FechaMartes" HeaderText="Fecha" Visible="False" />
            <asp:BoundField DataField="Martes" HeaderText="Tarea" />
            <asp:BoundField DataField="FechaMiercoles" HeaderText="Fecha" Visible="False" />
            <asp:BoundField DataField="Miercoles" HeaderText="Tarea" />
            <asp:BoundField DataField="FechaJueves" HeaderText="Fecha" Visible="False" />
            <asp:BoundField DataField="Jueves" HeaderText="Tarea" />
            <asp:BoundField DataField="FechaViernes" HeaderText="Fecha" Visible="False" />
            <asp:BoundField DataField="Viernes" HeaderText="Tarea" />
            <asp:BoundField DataField="FechaSabado" HeaderText="Fecha" Visible="False" />
            <asp:BoundField DataField="Sabado" HeaderText="Tarea" />
            <asp:BoundField DataField="FechaDomingo" HeaderText="Fecha"  Visible="False"/>
            <asp:BoundField DataField="Domingo" HeaderText="Tarea" />
            <asp:BoundField DataField="Personal" HeaderText="Personal" Visible="False" />
            <asp:BoundField DataField="Cedula" HeaderText="Cedula" Visible="False" />
            <asp:BoundField DataField="Mes" HeaderText="Mes" Visible="False" />
        </Columns>
    </asp:GridView>
    
    </div>
    </form>
</body>
</html>
