<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCrearListaOficial.aspx.cs" Inherits="WebAplication.Responsable.frmCrearListaOficial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">ORGANIZACIONES HABILITADAS</div>
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
            <td></td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="130">Buscar Organización:</td>
            <td width="205">
                <asp:TextBox ID="TxtBuscarOrg" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td rowspan="2" width="50">
                <asp:ImageButton ID="ImgBuscar" runat="server" Height="40px" ImageUrl="~/images/kghostview.png" OnClick="ImgBuscar_Click" Width="40px" />
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <div style="font-size: 8pt">
                    Por: (Nombre, sigla, departamento)</div>
            </td>
            <td>
                <asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVOrgInsDoc" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" DataKeyNames="Id_InscripcionOrg" OnRowCommand="GVOrgInsDoc_RowCommand">
        <Columns>
            <asp:BoundField DataField="Num" HeaderText="N°">
            <ItemStyle Width="30px" />
            </asp:BoundField>
            <asp:BoundField DataField="Sigla" HeaderText="Organizacion" />
            <asp:BoundField DataField="Personeria_Juridica" HeaderText="Personeria Jurudica" />
            <asp:BoundField DataField="Fecha_Registro" HeaderText="Fecha registro" />
            <asp:BoundField DataField="Departamento" HeaderText="Depratamento" />
            <asp:BoundField DataField="Documentos" HeaderText="Documentos" >
            <ItemStyle Width="110px" />
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderText="Estado Org.">
            <ItemStyle Width="110px" />
            </asp:BoundField>
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" />
            <asp:ButtonField CommandName="ListaPreliminar" Text="Lista Preliminar">
            <ItemStyle Width="90px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="ListaOficial" Text="Lista Oficial" >
            <ItemStyle Width="70px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>