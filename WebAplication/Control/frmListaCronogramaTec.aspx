<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaCronogramaTec.aspx.cs" Inherits="WebAplication.Control.frmListaCronogramaTec" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        CRONOGRAMA DE ACTIVIDADES POR TÉCNICO DE EXTENSIÓN</div>
    <table class="TableBorder">
        <tr>
            <td class="auto-style1" width="60">Programa:</td>
            <td>
                <asp:DropDownList ID="DDLProg" runat="server" AutoPostBack="True">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="120">
                <asp:DropDownList ID="DDLCamp" runat="server" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td width="60">&nbsp;</td>
            <td width="120">
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td width="60">&nbsp;</td>
            <td width="120">
                <asp:LinkButton ID="LnkNuevo" runat="server" OnClick="LnkNuevo_Click">[ Definir Cronograma ]</asp:LinkButton>
            </td>
        </tr>
        </table>
    CRONOGRAMAS REALIZADOS<asp:GridView ID="GVCronogramas" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVCronogramas_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id_Cronograma_Tec" HeaderText="Codigo" />
                <asp:BoundField DataField="Regional" HeaderText="Regional" />
                <asp:BoundField DataField="Campanhia" HeaderText="Campaña" />
                <asp:BoundField DataField="Programa" HeaderText="Programa" />
                <asp:BoundField DataField="FechaEnvio" HeaderText="FechaEnvio" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:ButtonField CommandName="Cronograma" Text="Ver Cronograma">
                <ItemStyle Width="90px" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
</asp:Content>
