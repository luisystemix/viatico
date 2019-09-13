<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="repCronogramaRegIni.aspx.cs" Inherits="WebAplication.Registro.repCronogramaRegIni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table class="TableBorder">
        <tr>
            <td rowspan="2" width="200">&nbsp;</td>
            <td><div style="text-align: center">REGISTRO</div></td>
            <td width="200">&nbsp;</td>
        </tr>
        <tr>
            <td><div style="text-align: center">CRONOGRAMA CAMPAÑA AGRÍCOLA</div></td>
            <td>&nbsp;</td>
        </tr>
    </table>

    <table class="TableBorder">
        <tr>
            <td width="70">Campaña:</td>
            <td>
                <asp:Label ID="LblCampanhia" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Regional;</td>
            <td>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblPrograma" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    <asp:GridView ID="GVConograma" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Numero" HeaderText="N°" />
            <asp:BoundField DataField="Actividad" HeaderText="Actividad Planificada" />
            <asp:BoundField DataField="Inicio" HeaderText="Fecha Inicio" />
            <asp:BoundField DataField="Final" HeaderText="Fecha Final" />
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td width="80">Cronograma:</td>
            <td>
                <asp:Label ID="LblCronograma" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="60">Fecha:</td>
            <td width="200">
                <asp:Label ID="LblFecha" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Responsable:</td>
            <td>
                <asp:Label ID="LblNombre" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
