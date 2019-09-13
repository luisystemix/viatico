<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmControlDocProv.aspx.cs" Inherits="WebAplication.Insumos.frmControlDocProv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        CONTROL DE DOCUMENTACIÓN</div>
    <table class="TableBorder">
        <tr>
            <td width="70">Empresa:</td>
            <td>
                <asp:Label ID="LblEmpresa" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsEmp" runat="server" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="130">
                <asp:Label ID="LblCamp" runat="server" CssClass="textoFondoIzq"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Insumo:</td>
            <td>
                <asp:Label ID="LblInsumo" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
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
            <td rowspan="2">
                <asp:ImageButton ID="ImgPrint" runat="server" Height="30px" ImageUrl="~/images/AQUA ICONS SYSTEM PRINTER.png" OnClick="ImgPrint_Click" Width="30px" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVInsProvDocPres" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVInsProvDocPres_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Documento" HeaderText="Documento Solicitado por EMAPA" />
            <asp:BoundField DataField="Id_Documento" HeaderText="Id_Documento" Visible="False" />
            <asp:BoundField DataField="Id_VerificarDocProv" HeaderText="Id_VerificarDocProv" Visible="False" />
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:CheckBox ID="CbxEstado" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Observación">
                <ItemTemplate>
                    <asp:TextBox ID="TxtObser" runat="server" Width="300px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="300px" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            Documento
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrar_Click" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" />
</asp:Content>
