<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaDistribAgroquimico.aspx.cs" Inherits="WebAplication.Extensiones.frmListaDistribAgroquimico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        LISTA DEL SEGUIMIENTOS A LA DISTRIBUCIÓN DE SEMILLA</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Agricultor:</td>
            <td width="250">
                <asp:Label ID="LblProductor" runat="server"></asp:Label>
                </td>
            <td width="80">Organización:</td>
            <td>
                <asp:Label ID="LblOrg" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsOrg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="55">Campaña:</td>
            <td width="120">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblProg" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsProd" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td width="120">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:LinkButton ID="LnkBtnSegDistSem" runat="server" OnClick="LnkBtnSegDistSem_Click">Realizar Seguimiento</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVDistribAgroQuim" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Num_Boleta" HeaderText="N° Boleta" />
            <asp:BoundField DataField="Lugar_Distribucion" HeaderText="Lugar de Distribución" />
            <asp:BoundField DataField="Fecha_Distribucion" HeaderText="Fecha de Distribución" />
            <asp:BoundField DataField="Fecha_Sis" HeaderText="Fecha SPIA" />
            <asp:BoundField DataField="Observacion" HeaderText="Observación" />
            <asp:ButtonField Text="Ver Reporte">
            <ItemStyle Width="65px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
