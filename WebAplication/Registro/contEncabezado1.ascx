<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contEncabezado1.ascx.cs" Inherits="WebAplication.Registro.contEncabezado1" %>

<link href="../css/EmapaStyele.css" rel="stylesheet" />

<table class="TableBorder">
    <tr>
        <td width="80">REGIONAL:</td>
        <td width="200">
            <asp:Label ID="LblRegional" runat="server" CssClass="textoFondoIzq"></asp:Label>
            <asp:Label ID="LblIdRegional" runat="server" CssClass="textoFondoIzq"></asp:Label>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td width="80">CAMPAÑA:</td>
        <td class="auto-style1" width="150">
            <asp:Label ID="LblCampanhia" runat="server" CssClass="textoFondoIzq"></asp:Label>
            <asp:Label ID="LblIdCampanhia" runat="server" CssClass="textoFondoIzq"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>PROGRAMA:</td>
        <td>
            <asp:Label ID="LblPrograma" runat="server" CssClass="textoFondoIzq"></asp:Label>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td></td>
    </tr>
</table>

