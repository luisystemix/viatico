<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistroProductorOrg.aspx.cs" Inherits="WebAplication.Registro.frmRegistroProductorOrg" %>
<%@ Register src="contEncabezado2.ascx" tagname="contEncabezado2" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        REGISTRO DE PRODUCTOR A ORGANIZACIÓN</div>
    <uc1:contEncabezado2 ID="contEncabezado21" runat="server" />
    <table class="TableBorder">
        <tr>
            <td width="110">Buscar Productor:</td>
            <td width="180">
                <asp:TextBox ID="TextBoxBuscarOrg" runat="server" Width="180
                 px"></asp:TextBox>
            </td>
            <td rowspan="2" width="50">
                <asp:ImageButton ID="ImgBuscar" runat="server" OnClick="ImgBuscar_Click" Height="50px" ImageUrl="~/images/kghostview.png" Width="50px" />
            </td>
            <td>&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td width="60">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                <asp:LinkButton ID="LnkNuevo" runat="server" OnClick="LnkNuevo_Click">[ Nuevo ]</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVINSPROPERINSORG" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" DataKeyNames="ID_PRO,CI,COMUNIDAD" onrowcommand="GVINSPROPERINSORG_RowCommand">
        <Columns>
            <asp:BoundField DataField="NOMBRES" HeaderText="NOMBRES" />
            <asp:BoundField DataField="PATERNO" HeaderText="PATERNO" />
            <asp:BoundField DataField="MATERNO" HeaderText="MATERNO" />
            <asp:BoundField DataField="CI" HeaderText="CI" />
            <asp:BoundField DataField="EXT" HeaderText="EXT" />
            <asp:BoundField DataField="TIPOINS" HeaderText="TIPO" />
            <asp:BoundField DataField="TIPO_PROD" HeaderText="TIPO_PRODUCCION" />
            <asp:BoundField DataField="Id_Organizacion" HeaderText="ID_ORG" ReadOnly="True" Visible="False" />
            <asp:BoundField DataField="ID_PRO" HeaderText="ID_PRO" Visible="False" />
            <asp:BoundField DataField="HASINS" HeaderText="HAS_INS" />
            <asp:BoundField DataField="Has_Ejecutado" HeaderText="HAS_EJECUTADO" Visible="False" />
            <asp:BoundField DataField="HASPROPIO" HeaderText="HAS_PROPIO" Visible="False" />
            <asp:BoundField DataField="RAU" HeaderText="RAU" Visible="False" />
            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
            <asp:BoundField DataField="Programa" HeaderText="PROGRAMA" Visible="False" />
            <asp:BoundField DataField="COMUNIDAD" HeaderText="COMUNIDAD" Visible="False" />
            <asp:TemplateField HeaderText="Geo_Ref">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument="<%#Container.DataItemIndex %>" CommandName="Ir" Text="Ir"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Modificar">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandArgument="<%#Container.DataItemIndex %>" CommandName="Editar" Text="Editar"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="HiddenFieldInsOrg" runat="server" />
    <asp:HiddenField ID="HiddenFieldCampanhia" runat="server" />
</asp:Content>
