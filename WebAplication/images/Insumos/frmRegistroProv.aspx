<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistroProv.aspx.cs" Inherits="WebAplication.Insumos.frmRegistroProv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        PROVEEDORES REGISTRDOS</div>
    <table class="TableBorder">
        <tr>
            <td  width="70">Regional:</td>
            <td  width="200">
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server" Visible="False"></asp:Label>
            </td>
            <td></td>
            <td width="60">Campaña:</td>
            <td width="130">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Programa:</td>
            <td class="auto-style1">
                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Insumo:</td>
            <td class="auto-style1">
                <asp:DropDownList ID="DDLInsumo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLInsumo_SelectedIndexChanged">
                    <asp:ListItem>AGROQUIMICO</asp:ListItem>
                    <asp:ListItem>SEMILLA</asp:ListItem>
                    <asp:ListItem>COMBUSTIBLE</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="textoDerecha">
                <asp:LinkButton ID="LnkNuevoProv" runat="server" OnClick="LnkNuevoProv_Click">[ Nuevo ]</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="130" class="auto-style2">Buscar Proveedor:</td>
            <td width="205" class="auto-style2">
                <asp:TextBox ID="TxtBuscarProv" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td rowspan="2" width="50">
                <asp:ImageButton ID="ImgBuscar" runat="server" Height="40px" ImageUrl="~/images/kghostview.png" Width="40px" OnClick="ImgBuscar_Click" />
            </td>
            <td class="auto-style2"></td>
            <td width="60" class="auto-style2"></td>
        </tr>
        <tr>
            <td></td>
            <td style="font-size: 8pt">Por: (Razon Social, NIT)</td>
            <td></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVProvInsDoc" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVProvInsDoc_RowCommand">
        <Columns>
            <asp:BoundField DataField="Razon_Social" HeaderText="Razon_Social" />
            <asp:BoundField DataField="NIT" HeaderText="NIT" />
            <asp:BoundField DataField="Representante Legal" HeaderText="Representante Legal" />
            <asp:BoundField DataField="Estado" HeaderText="Requisitos" />
            <asp:BoundField DataField="Id_InscripcionProv" HeaderText="Id_InscripcionProv" Visible="False" />
            <asp:ButtonField Text="Revisar-Doc" CommandName="Revisar-Doc" />
            <asp:ButtonField CommandName="Modificar" Text="Modificar" />
        </Columns>
    </asp:GridView>
    </asp:Content>
