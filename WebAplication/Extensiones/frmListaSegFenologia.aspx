<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaSegFenologia.aspx.cs" Inherits="WebAplication.Extensiones.frmListaSegFenologia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        LISTA DE LOS SEGUIMIENTOS POR FASE FENOLÓGICA DEL CULTIVO</div>
    <table class="TableBorder">
        <tr>
            <td width="75">Regional:</td>
            <td>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server" Visible="False"></asp:Label>
            </td>
            <td></td>
            <td width="60">Campaña:</td>
            <td width="140">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa</td>
            <td>
                <asp:Label ID="LblPrograma" runat="server"></asp:Label>
            </td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Organización:</td>
            <td>
                <asp:Label ID="LblOrg" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsOrg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td rowspan="2">
                <div style="text-align: right">&nbsp;<asp:ImageButton ID="ImgPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" OnClick="ImgPrint_Click" /></div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">
                <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
            </td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="130" rowspan="2">Seguimientos enviados:</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td width="185">&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:LinkButton ID="LnkBtnEnviar" runat="server" OnClick="LnkBtnEnviar_Click">Enviar Resultados del seguimiento</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVFaseFenologica" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVFaseFenologica_RowCommand">
        <Columns>
            <asp:BoundField DataField="Num_Seg_Cultivo" HeaderText="N°" />
            <asp:BoundField DataField="Fecha_Registro" HeaderText="Fecha Registro" />
            <asp:BoundField DataField="Num_Boletas_Inspec" HeaderText="N° Boletas Inspección" />
            <asp:BoundField DataField="Charla_Tecnica" HeaderText="Charla Tecnica?" />
            <asp:BoundField DataField="Num_Prod_Vigentes" HeaderText="N° Productores" />
            <asp:BoundField DataField="Sup_Actual" HeaderText="Sup. Actual" />
            <asp:ButtonField Text="Reporte" CommandName="Reporte">
            <ItemStyle Width="35px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    </asp:Content>
