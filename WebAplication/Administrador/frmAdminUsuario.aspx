<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAdminUsuario.aspx.cs" Inherits="WebAplication.Administrador.frmAdminUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<link href="../css/EmapaStyele.css" rel="stylesheet" />--%>
    <script type="text/javascript" src="../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js/jquery.quicksearch.js"></script>
    <script type="text/javascript">
        $(function () {
            $('input#MainContent_TextBoxBuscarOrg').quicksearch('table#MainContent_GVListaUser tbody tr');
        });
    </script>
    <%--GRIDVIEW MAKEOVER--%>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        td
        {
            cursor: pointer;
        }
        .hover_row
        {
            background-color: #c5bfb7/*#A1DCF2*/;
        }
    </style>    
    <script type="text/javascript">
        $(function () {
            $("[id*=GVListaUser] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>
    <%--GRIDVIEW MAKEOVER--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        ADMINISTRACIÓN DE USUARIO</div>
    <table class="TableBorder">
        <tr>
            <td width="95">Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
    <table class="TableBorder">
        <tr>
            <td width="95">Buscar Usuario:</td>
            <td width="180">
                <asp:TextBox ID="TextBoxBuscarOrg" runat="server" Width="180
                 px"></asp:TextBox>
            </td>
            <td rowspan="2" width="50">
                <asp:ImageButton ID="ImgBuscar" runat="server" OnClick="ImgBuscar_Click" Height="35px" ImageUrl="~/images/kghostview.png" Width="35px" Visible="False" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td width="60">&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td><div style="font-size: 8pt">por: (Nombre, Apellido o Cargo)</div></td>
            <td></td>
            <td>&nbsp;</td>
            <td>
                <asp:LinkButton ID="LnkNuevo" runat="server" OnClick="LnkNuevo_Click">[ Nuevo ]</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Label ID="LblMensaje" runat="server" Text="" ForeColor="#CC0000" Font-Bold="True"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVListaUser" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVListaUser_RowCommand" OnPreRender="GVListaUser_PreRender">
        <Columns>
            <asp:BoundField DataField="Id_Usuario" HeaderText="Codigo" />
            <asp:BoundField DataField="Persona" HeaderText="Servidor Público" />
            <asp:BoundField DataField="ci" HeaderText="Cedula" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="Nombre" HeaderText="Regional" Visible="False" />
            <asp:BoundField DataField="Nombre_Rol" HeaderText="Rol" />
            <asp:BoundField DataField="Id_Rol" HeaderText="Cod-Rol" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:ButtonField Text="Actualizar" CommandName="Editar">
            <ItemStyle Width="52px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="inhabilitar" Text="Dar de Baja">
            <ItemStyle Width="62px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Resert" Text="Reiniciar Contraseña">
            <ItemStyle Width="62px" />
            </asp:ButtonField>
        </Columns>
        <RowStyle CssClass="rowHover" />
    </asp:GridView>
</asp:Content>
