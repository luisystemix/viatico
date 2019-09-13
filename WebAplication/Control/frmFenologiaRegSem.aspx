<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFenologiaRegSem.aspx.cs" Inherits="WebAplication.Control.frmFenologiaRegSem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo2">
        SEGUIMIENTOS SEMANALES DEL ESTADO FENOLÓGICO DEL CULTIVO ENVIADOS</div>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
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
            <asp:BoundField DataField="Id_Envio_FenologiaSemanal" HeaderText="Id" Visible="False" />
            <asp:BoundField DataField="Id_Campanhia" HeaderText="Id_Campanhia" Visible="False" />
            <asp:BoundField DataField="Id_Regional" HeaderText="Id_Regional" Visible="False" />
            <asp:ButtonField CommandName="imprimir" Text="Imprimir">
            <ItemStyle Width="45px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
