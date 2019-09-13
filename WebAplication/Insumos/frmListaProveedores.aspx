<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaProveedores.aspx.cs" Inherits="WebAplication.Insumos.frmListaProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        REGISTRO DE PROVEEDORES DE INSUMO</div>
    <table class="TableBorder">
        <tr>
            <td width="65" class="auto-style3">Regional:</td>
            <td width="100" class="auto-style3">
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td width="60" class="auto-style3">Campaña:</td>
            <td width="130" class="auto-style3">
                <asp:DropDownList ID="DDLCamp" runat="server" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="LblIdRol" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <div style="text-align: right"><asp:LinkButton ID="LnkNuevo" runat="server" OnClick="LnkNuevo_Click">[ Nuevo ]</asp:LinkButton></div>
            </td>
        </tr>
    </table>
    <div class="SubTitulo2">LISTA DE PROVEEDORES REGISTRADOS</div><asp:GridView ID="GVProveedores" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVProveedores_RowCommand" OnSelectedIndexChanged="GVProveedores_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="Razon_Social" HeaderText="Proveedor" />
        <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" Visible="False" />
        <asp:BoundField DataField="Insumo" HeaderText="Insumo" />
        <asp:BoundField DataField="Estado" HeaderText="Estado" />
        <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" />
        <asp:BoundField DataField="Telefono_Ref" HeaderText="Telefono(s)" />
        <asp:BoundField DataField="Correo" HeaderText="Correo" />
        <asp:BoundField DataField="Id_InscripcionProv" HeaderText="Id_InscripcionProv" Visible="False" />
        <asp:ButtonField CommandName="Propuesta" Text="Registrar Paquete" >
        <ItemStyle Width="95px" />
        </asp:ButtonField>
    </Columns>
    </asp:GridView>
</asp:Content>
