<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmControlRegional.aspx.cs" Inherits="WebAplication.Responsable.frmControlRegional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        SEGUIMIENTO A REGIONALES</div>
    <table class="TableBorder">
        <tr>
            <td width="70">Campaña:</td>
            <td>
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLProg" runat="server">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVRegional" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVRegional_RowCommand">
        <Columns>
            <asp:BoundField DataField="Nombre_Oficina" HeaderText="Nombre_Oficina" />
            <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
            <asp:BoundField DataField="Responsable" HeaderText="Responsable" />
            <asp:BoundField DataField="CI" HeaderText="CI" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="Telef_Fijo" HeaderText="Telef_Fijo" />
            <asp:BoundField DataField="Telef_Movil" HeaderText="Telef_Movil" />
            <asp:BoundField DataField="Region" HeaderText="Region" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_Regional" HeaderText="Id_Regional" Visible="False" />
            <asp:ButtonField CommandName="Cronograma" Text="Campaña" HeaderText="Cronograma" />
            <asp:ButtonField HeaderText="Cronograma" Text="Técnicos" CommandName="CronoTec" />
        </Columns>
    </asp:GridView>
</asp:Content>
