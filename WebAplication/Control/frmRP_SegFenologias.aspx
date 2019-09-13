<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRP_SegFenologias.aspx.cs" Inherits="WebAplication.Control.frmRP_SegFenologias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        LISTA DE FASE FENOLÓGICA ENVIADA POR LOS TÉCNICOS</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Programa:</td>
            <td>
                <asp:DropDownList ID="DDLProg" runat="server" OnSelectedIndexChanged="DDLProg_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="120">
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="60">Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="120">
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="60">&nbsp;</td>
            <td colspan="3">
                <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></td>
            </div>
            <td width="60">
                &nbsp;</td>
        </tr>
        </table>
    <asp:GridView ID="GVEnviadosSemana" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVEnviadosSemana_RowCommand" OnRowCreated="GVEnviadosSemana_RowCreated">
        <Columns>
            <asp:BoundField DataField="NUM" HeaderText="N°" />
            <asp:BoundField DataField="Nombre" HeaderText="Campaña" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" />
            <asp:BoundField DataField="Programa" HeaderText="Programa" />
            <asp:BoundField DataField="Fecha_Envio" HeaderText="Fecha Enviado" />
            <asp:BoundField DataField="Desde" HeaderText="Desde" />
            <asp:BoundField DataField="Hasta" HeaderText="Hasta" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_Envio_FenologiaSemanal" HeaderText="Id_Envio_FenologiaSemanal" Visible="False" />
            <asp:BoundField DataField="Id_Campanhia" HeaderText="Id_Campanhia" Visible="False" />
            <asp:BoundField DataField="Id_Regional" HeaderText="Id_Regional" Visible="False" />
            <asp:ButtonField CommandName="imprimir" Text="Imprimir">
            <ItemStyle Width="45px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
