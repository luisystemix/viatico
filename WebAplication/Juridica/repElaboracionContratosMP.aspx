<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repElaboracionContratosMP.aspx.cs" Inherits="WebAplication.Juridica.repElaboracionContratosMP" %>

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
                    <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td><div style="text-align: center">REGISTRO</div></td>
                <td class="auto-style1">E-EMP/GP/P/301-12</td>
            </tr>
            <tr>
                <td><div style="text-align: center">PARA LA ELABORACIÓN DE CONTRATOS DE PROVISIÓN DE MATERIA PRIMA</div></td>
                <td class="auto-style1">Versión 1</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
        </table>
    </div><div style="font-size: 8pt">
        <asp:GridView ID="GVContrato" runat="server" CssClass="TableBorder" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Campaña" />
                <asp:BoundField DataField="Programa" HeaderText="Programa" />
                <asp:BoundField DataField="Personeria_Juridica" HeaderText="Organización" />
                <asp:BoundField DataField="Resolucion_Prefect" HeaderText="Resolucion N°" />
                <asp:BoundField DataField="Fecha_Creacion" HeaderText="Fecha Resolución" />
                <asp:BoundField DataField="DomicilioOrg" HeaderText="Domicilio Localidad/Comunidad" />
                <asp:BoundField HeaderText="Municipio" />
                <asp:BoundField HeaderText="Provincia" />
                <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                <asp:BoundField DataField="Rep_Legal" HeaderText="Rep. Legal" />
                <asp:BoundField DataField="Cedula" HeaderText="Ci Rep. Leg." />
                <asp:BoundField DataField="Nun_Testimonio" HeaderText="N° Testimonio" />
                <asp:BoundField DataField="Num_Notaria" HeaderText="N° Notaria" />
                <asp:BoundField DataField="Abg_A_Cargo" HeaderText="Abg. A Cargo" />
                <asp:BoundField DataField="Distrito_Judicial" HeaderText="Distrito Judicial" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha Testimonio" />
            </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
