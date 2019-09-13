<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaProductorPre.aspx.cs" Inherits="WebAplication.Responsable.frmListaProductorPre" %>
<%@ Register src="../Registro/contEncabezado2.ascx" tagname="contEncabezado2" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="SubTitulo">
            DEPURAR LISTA PRELIMINAR</div>
    <uc1:contEncabezado2 ID="contEncabezado21" runat="server" />
        
    <table class="TableBorder">
        <tr>
            <td width="110" class="auto-style1">Buscar Productor:</td>
            <td width="180" class="auto-style1">
                <asp:TextBox ID="TextBoxBuscarOrg" runat="server" Width="180
                 px"></asp:TextBox>
            </td>
            <td rowspan="2" width="50">
                <asp:ImageButton ID="ImgBuscar" runat="server" OnClick="ImgBuscar_Click" Height="35px" ImageUrl="~/images/kghostview.png" Width="35px" />
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1" rowspan="2" width="35">
                <asp:ImageButton ID="ImgPrintListOfi" runat="server" Height="35px" ImageUrl="~/images/printmgr.png" Width="35px" OnClick="ImgPrintListOfi_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2">
                &nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVProdIns" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVProdIns_RowDataBound" OnRowCommand="GVProdIns_RowCommand">
        <Columns>
            <asp:BoundField DataField="Productor" HeaderText="Productor" />
            <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
            <asp:BoundField DataField="Tipo_Produccion" HeaderText="Tipo-Producción" />
            <asp:BoundField DataField="Tipo_Inscripcion" HeaderText="Tipo" />
            <asp:BoundField DataField="Has_Inscrito" HeaderText="Ha Inscrito" />
            <asp:BoundField DataField="Nombre" HeaderText="Comunidad" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_Productor" HeaderText="Id_Productor" Visible="False" />

            <asp:TemplateField HeaderText="Observación">
                <ItemTemplate>
                    <asp:TextBox ID="TxtObser" runat="server" Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>

            <asp:ButtonField CommandName="Historial" Text="Historial">
            <ItemStyle Width="45px" />
            </asp:ButtonField>

        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrar_Click" />
    <asp:Button ID="Button2" runat="server" Text="Cancelar" />
    <asp:HiddenField ID="HiddenFieldInsOrg" runat="server" />
</asp:Content>
