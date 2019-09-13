<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repListaControlSegTec.aspx.cs" Inherits="WebAplication.Control.repListaControlSegTec" %>

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
    margin-left: 0px;
}
        .auto-style1 {
            width: 70px;
        }

a:link, a:visited
{
    color:  #034af3;
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
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ 303 R05</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">SEGUIMIENTO AL REGISTRO DE BOLETAS DEL PROGRAMA
                    <asp:Label ID="LblPrograma" runat="server"></asp:Label>
                    </div></td>
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
                <td class="auto-style1">&nbsp;</td>
                <td width="70">&nbsp;</td>
                <td width="70">&nbsp;</td>
                <td width="200">&nbsp;</td>
                <td width="70">&nbsp;</td>
                <td>
                <asp:Label ID="LblIdUsuario" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>CAMPAÑA:</td>
                <td>
                    <asp:Label ID="LblCamp" runat="server"></asp:Label>
                    <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>REGIONAL:</td>
                <td>
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
                    <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    PROGRAMA:</td>
                <td>
                    <asp:Label ID="LblProg" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    
    <asp:GridView ID="GVSegTec" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVSegTec_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Tecnico" HeaderText="Personal Tecnico" />
            <asp:TemplateField HeaderText="N° Boleta">
                <ItemTemplate>
                    <asp:Label ID="LblNumBolet" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Etapa" HeaderText="Tipo Seguimirnto" />
            <asp:BoundField DataField="Productor" HeaderText="Productor" />
            <asp:BoundField DataField="Fecha_Envio" HeaderText="Fecha Envio " />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_Seguimiento" HeaderText="Id_Seguimiento" Visible="False" />
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" />
            <asp:BoundField DataField="Tipo_Seguimiento" HeaderText="Seguimiento" />
        </Columns>
    </asp:GridView>
   
    </div>
    </form>
</body>
</html>
