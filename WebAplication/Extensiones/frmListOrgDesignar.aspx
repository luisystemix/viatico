<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListOrgDesignar.aspx.cs" Inherits="WebAplication.Extensiones.frmListOrgDesignar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        FORMULARIO DE SELECCION DE ORGANIZACIONES</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Regional:</td>
            <td>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="150">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </asp:Content>
