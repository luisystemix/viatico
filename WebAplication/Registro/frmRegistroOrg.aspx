<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistroOrg.aspx.cs" Inherits="WebAplication.Registro.frmRegistroOrg1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">ORGANIZACIONES REGISTRADAS</div>
    <table class="TableBorder">
        <tr>
            <td width="65" class="auto-style2">Regional:</td>
            <td width="100" class="auto-style2">
                <asp:Label ID="LblRegional" runat="server" CssClass="textoFondoIzq"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td></td>
            <td width="60" class="auto-style2">Campaña:</td>
            <td width="130" class="auto-style2">
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                    <asp:ListItem>Seleccionar Programa</asp:ListItem>
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblEstadoCamp" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="130" class="auto-style2">Buscar Organización:</td>
            <td width="205" class="auto-style2">
                <asp:TextBox ID="TxtBuscarOrg" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td rowspan="2" width="50">
                <asp:ImageButton ID="ImgBuscar" runat="server" OnClick="ImgBuscar_Click" Height="40px" ImageUrl="~/images/kghostview.png" Width="40px" />
            </td>
            <td class="auto-style2"></td>
            <td width="60" class="auto-style2"></td>
        </tr>
        <tr>
            <td></td>
            <td><div style="font-size: 8pt">Por: (Nombre, sigla, departamento)</div></td>
            <td>
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="LnkNuevaOrg" runat="server" OnClick="LnkNuevaOrg_Click" Visible="False">[ Nuevo ]</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVOrgInsDoc" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" DataKeyNames="Id_InscripcionOrg" OnRowCommand="GVOrgInsDoc_RowCommand">
        <Columns>
            <asp:BoundField DataField="Sigla" HeaderText="Organizacion" />
            <asp:BoundField DataField="Personeria_Juridica" HeaderText="Personalidad Jurídica" />
            <asp:BoundField DataField="Fecha_Registro" HeaderText="Fecha registro" />
            <asp:BoundField DataField="Departamento" HeaderText="Depratamento" />
            <asp:BoundField DataField="Documentos" HeaderText="Documentos" />
            <asp:BoundField DataField="Estado" HeaderText="Estado Org." />
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" />
            <asp:ButtonField Text="Modificar" CommandName="Modificar" >
            <ItemStyle Width="60px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Revisar-Doc" CommandName="Revisar-Doc" >
            <ItemStyle Width="75px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
