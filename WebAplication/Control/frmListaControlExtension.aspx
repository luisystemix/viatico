<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaControlExtension.aspx.cs" Inherits="WebAplication.Control.frmListaControlExtension" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        FASE FENOLÓGICA</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Region:</td>
            <td>
                <asp:DropDownList ID="DDLRegion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegion_SelectedIndexChanged">
                    <asp:ListItem>OCCIDENTE</asp:ListItem>
                    <asp:ListItem>ORIENTE</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="57">Campaña:</td>
            <td width="120">
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLProg" runat="server" OnSelectedIndexChanged="DDLProg_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="LblRegion" runat="server" style="font-weight: 700"></asp:Label>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
                </td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                </td>
            <td>
                <asp:Label ID="LblFecha" runat="server"></asp:Label>
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
    <table class="TableBorder">
        <tr>
            <td>
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVFenologias" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVFenologias_RowCommand" OnRowDataBound="GVFenologias_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Id_Regional" HeaderText="Id_Regional" />
            <asp:BoundField DataField="Id_Campanhia" HeaderText="Id_Campanhia" Visible="False" />
            <asp:BoundField DataField="Nombre" HeaderText="Regional" />
            <asp:BoundField DataField="Region" HeaderText="Región" Visible="False" />
            <asp:TemplateField HeaderText="N° Boletas">
                <ItemTemplate>
                    <asp:Label ID="blNumBoletas" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N° Productores">
                <ItemTemplate>
                    <asp:Label ID="LblProdVig" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Superficie Actual">
                <ItemTemplate>
                    <asp:Label ID="LblSupAct" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField Text="Ver Fenologia" CommandName="VerFenologia">
            <ItemStyle Width="75px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Costos" Text="Costos de Produccion" Visible="False">
            <HeaderStyle Width="100px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
   
    </asp:Content>
