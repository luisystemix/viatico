<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaRegistroDitrib.aspx.cs" Inherits="WebAplication.Insumos.frmListaRegistroDitrib" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        LISTA DE REGISTROS DE IMPORTACION DE DISTRIBUCIÓN</div>
    <table class="TableBorder">
        <tr>
            <td width="65">Regional:</td>
            <td width="100">
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td width="60" >Campaña:</td>
            <td width="130">
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
        <tr>
            <td>Insumo:</td>
            <td>
                <asp:DropDownList ID="DDLInsumo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLInsumo_SelectedIndexChanged">
                    <asp:ListItem Value="1">SEMILLA</asp:ListItem>
                    <asp:ListItem Value="2">AGROQUIMICO</asp:ListItem>
                    <asp:ListItem Value="3">COMBUSTIBLE</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <div style="text-align: right"><asp:LinkButton ID="LnkInportar" runat="server" OnClick="LnkInportar_Click">Importar Registro</asp:LinkButton></div>
                </td>
        </tr>
    </table>
    <asp:GridView ID="GVListDistribIns" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NUM" HeaderText="N°">
            <ItemStyle Width="20px" />
            </asp:BoundField>
            <asp:BoundField DataField="Razon_Social" HeaderText="Proveedor" />
            <asp:BoundField DataField="Insumo" HeaderText="Insumo" />
            <asp:BoundField DataField="Programa" HeaderText="Programa" />
            <asp:BoundField DataField="Sigla" HeaderText="Sigla" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" />
            <asp:BoundField DataField="Fecha_Registro" HeaderText="Fecha_Registro" />
            <asp:BoundField DataField="Id_Distribucion" HeaderText="Id_Distribucion" Visible="False" />
            <asp:ButtonField CommandName="Importacion" Text="Detalle de Importacion">
            <ItemStyle Width="125px" Wrap="True" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    </asp:Content>
