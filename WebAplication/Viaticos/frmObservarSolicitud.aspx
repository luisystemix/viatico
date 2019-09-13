<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmObservarSolicitud.aspx.cs" Inherits="WebAplication.Viaticos.frmObservarSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo" style="font-size: large; font-weight: 700">
        FORMULARIO PARA ENVIAR OBSERVACIONES A LA SOLICITUD DE VIAJE</div>
    <table class="TableBorder">
        <tr>
            <td width="60">N°</td>
            <td>
                <asp:Label ID="LblIdSolicitud" runat="server"></asp:Label>
            </td>
            <td width="50">&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Nombrre:</td>
            <td>
                <asp:Label ID="LblNombre" runat="server"></asp:Label>
            </td>
            <td>Destino:</td>
            <td>
                <asp:Label ID="LblDestino" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Notivo:</td>
            <td>
                <asp:Label ID="LblMotivo" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="80">Observación</td>
            <td rowspan="2">
                <asp:TextBox ID="TxtObs" runat="server" Height="60px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnEnviar" runat="server" OnClick="BtnEnviar_Click" Text="Enviar" />
                <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
