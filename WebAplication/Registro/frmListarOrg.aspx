<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListarOrg.aspx.cs" Inherits="WebAplication.Registro.frmListarOrg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        LISTA DE ORGANIZACIONES</div>
    <table class="TableBorder">
        <tr>
            <td width="65">Regional:</td>
            <td width="100">
                <asp:Label ID="LblRegional" runat="server" CssClass="textoFondoIzq"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td></td>
            <td width="60">Campaña:</td>
            <td width="130">
                <asp:Label ID="LblCampanhia" runat="server" CssClass="textoFondoIzq"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
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
                <asp:Label ID="LblIdRol" runat="server"></asp:Label>
            </td>
            <td></td>
            <td></td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="130">Buscar Organización:</td>
            <td width="205">
                <asp:TextBox ID="TxtBuscarOrg" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td rowspan="2" width="50">
                <asp:ImageButton ID="ImgBuscar" runat="server" Height="25px" ImageUrl="~/images/kghostview.png" OnClick="ImgBuscar_Click" Width="25px" />
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
                <asp:Label ID="LblMsj1" runat="server" style="color: #FF0000; font-weight: 700"></asp:Label>
            </td>
            <td></td>
        </tr>
    </table>
    <asp:GridView ID="GVOrgInsDoc" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" DataKeyNames="Id_InscripcionOrg" OnRowCommand="GVOrgInsDoc_RowCommand">
        <Columns>
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
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" />
            <asp:ButtonField CommandName="Productor" Text="Productores" >
            <ItemStyle Width="60px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Planilla" Text="Planilla" >
            <ItemStyle Width="40px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
