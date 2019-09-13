<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repDesignacionOrgTPE.aspx.cs" Inherits="WebAplication.Extensiones.repDesignacionOrgTPE" %>

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
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ XYZ</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">
                    LISTA DE DESIGNACIÓN DE ORGANIZACIONES A LOS TÉCNICOS  DE CAMPO, PROGRAMA:
                    <asp:Label ID="LblPrograma" runat="server"></asp:Label>
                    </div></td>
                <td>
                    <div style="text-align: center">Versión ?</div></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td width="50">Regional:</td>
                <td>
                    <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                    </td>
                <td width="50">Campaña:</td>
                <td>
                    <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    <asp:GridView ID="GVDesignado" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Nombres" HeaderText="Tecnico designado" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="ci" HeaderText="ci" Visible="False" />
            <asp:BoundField DataField="Personeria_Juridica" HeaderText="Organización" />
            <asp:BoundField DataField="Sigla" HeaderText="Sigla" Visible="False" />
            <asp:BoundField DataField="Programa" HeaderText="Programa" Visible="False" />
            <asp:BoundField DataField="Nombre" HeaderText="Campaña" Visible="False" />
            <asp:BoundField DataField="Superficie" HeaderText="Sup. (ha)" />
            <asp:BoundField DataField="Num_Productores" HeaderText="N° Prod." Visible="False" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" />
        </Columns>
    </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Elaborado por:</td>
                <td>&nbsp;</td>
                <td>VoBo</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1">Nombre y Cargo</td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
