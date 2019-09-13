<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaINF.aspx.cs" Inherits="WebAplication.Registro.frmListaINF" %>
<%@ Register src="contEncabezado2.ascx" tagname="contEncabezado2" tagprefix="uc1" %>
<%@ Register src="contEncabezado1.ascx" tagname="contEncabezado1" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        REGISTRO DE INFORMES REALIZADOS
    </div>
    <table class="TableBorder">
        <tr>
            <td width="70" class="auto-style1">Regional:</td>
            <td class="auto-style1">
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1" width="70">Campaña:</td>
            <td width="120" class="auto-style1">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLPrograma" runat="server" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
            <td></td>
            <td class="auto-style1"></td>
            <td>
                <asp:LinkButton ID="LnkNuevoInf" runat="server" OnClick="LnkNuevoInf_Click">[ Nuevo Informe ]</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" CssClass="TableBorder">
    </asp:GridView>
</asp:Content>
