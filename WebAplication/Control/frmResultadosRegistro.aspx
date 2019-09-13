<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmResultadosRegistro.aspx.cs" Inherits="WebAplication.Control.frmResultadosRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        RESÚMENES Y RESULTADOS DEL PROCESO DE REGISTRO</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="150">
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
                    <asp:ListItem>SOJA</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
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
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVListaOrg" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVListaOrg_RowCommand">
        <Columns>
            <asp:BoundField DataField="Num" HeaderText="N°" />
            <asp:BoundField DataField="Sigla" HeaderText="Sigla" />
            <asp:BoundField DataField="Personeria_Juridica" HeaderText="Personalidad Juridica" />
            <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" />
            <asp:ButtonField CommandName="ListOfi" Text="Lista Oficial">
            <ItemStyle Width="62px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="ListDepu" Text="Lista Depurados">
            <ItemStyle Width="85px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="ResumOrg" Text="Resumen Org">
            <ItemStyle Width="73px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="ResumDocLeg" Text="Resumen Doc Legal">
            <ItemStyle Width="105px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
