<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contEncabezado2.ascx.cs" Inherits="WebAplication.Registro.contEncabezado2" %>
<link href="../css/EmapaStyele.css" rel="stylesheet" />

<table class="TableBorder">
    <tr>
        <td width="90">Organización:</td>
        <td width="250">
            <asp:Label ID="LblOrganizacion" runat="server" CssClass="textoFondoIzq"></asp:Label>
            <asp:Label ID="LblId_Org" runat="server"></asp:Label>
        </td>
        <td></td>
        <td width="70">Campaña:</td>
        <td width="130">
            <asp:Label ID="LblCampanhia" runat="server" CssClass="textoFondoIzq"></asp:Label>
            <asp:Label ID="LbLIdCamp" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Programa:</td>
        <td>
            <asp:Label ID="LblPrograma" runat="server" CssClass="textoFondoIzq"></asp:Label>
        </td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
</table>