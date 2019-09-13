<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaRendimiento.aspx.cs" Inherits="WebAplication.Extensiones.frmListaRendimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        LISTA DE RENDIMIENTOS
    </div>
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
    <asp:GridView ID="GVListRendi" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVListRendi_RowDataBound" OnRowCommand="GVListRendi_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id_Rendimiento" HeaderText="Id_Rendimiento" />
            <asp:BoundField DataField="Num_Seg_Cultivo" HeaderText="N° de Veces que se visito el Cultivo" Visible="False" />
            <asp:BoundField DataField="Fech_Inspeccion" HeaderText="Fech de Inspección" />
            <asp:BoundField DataField="Fecha_Sis" HeaderText="Fecha registro SPIA" />
            <asp:BoundField DataField="Variedad_Semilla" HeaderText="Variedad de Semilla Utilizada" />
            <asp:TemplateField HeaderText="Fanega/ha">
                <ItemTemplate>
                    <asp:Label ID="LblFanHect" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField Text="Ver Reporte">
            <ItemStyle Width="65px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
