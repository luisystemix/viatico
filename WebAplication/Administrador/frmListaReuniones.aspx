<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaReuniones.aspx.cs" Inherits="WebAplication.Administrador.frmListaReuniones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">REUNIONES REALIZADAS EN LA CAMPAÑA
        </div>
    <table class="TableBorder">
        <tr>
            <td width="60">
                Campaña:</td>
            <td>
        <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td width="110">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                <asp:LinkButton ID="LnkReunion" runat="server" OnClick="LnkReunion_Click">[ Nueva Reunión ]</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVListaReunion" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVListaReunion_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id_Reunion" HeaderText="Id_Reunion" Visible="False" />
            <asp:BoundField DataField="Id_Regional" HeaderText="Id_Regional" Visible="False" />
            <asp:BoundField DataField="Tipo_Reunion" HeaderText="Tipo Reunion" />
            <asp:BoundField DataField="Region" HeaderText="Region" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" />
            <asp:BoundField DataField="Lugar" HeaderText="Lugar" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
            <asp:BoundField DataField="Estado" HeaderText="Estado Camp." />
            <asp:ButtonField Text="Ver" CommandName="Ver" />
        </Columns>
    </asp:GridView>
</asp:Content>
