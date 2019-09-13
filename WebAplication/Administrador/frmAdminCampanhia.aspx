<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAdminCampanhia.aspx.cs" Inherits="WebAplication.Administrador.frmAdminCampanhia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">SEGUIMIENTO A LAS CAMPAÑAS</div>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td width="120">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">[ Nueva Campaña ]</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVListCamp" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVListCamp_RowCommand">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Fecha_Inicio" HeaderText="Fecha_Inicio" />
            <asp:BoundField DataField="Fecha_Final" HeaderText="Fecha_Final" />
            <asp:BoundField DataField="Region" HeaderText="Region" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_Campanhia" HeaderText="Id_Campanhia" Visible="False" />
            <asp:ButtonField CommandName="Reuniones" Text="Reuniones">
            <ItemStyle Width="60px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Informes" CommandName="Informes">
            <ItemStyle Width="50px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Programa" Text="Ver Programas">
            <ItemStyle Width="80px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
