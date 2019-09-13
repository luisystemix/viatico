<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmControlDocOrg.aspx.cs" Inherits="WebAplication.Registro.frmControlDocOrg" %>
<%@ Register src="contEncabezado1.ascx" tagname="contEncabezado1" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript">
        //    funcion java script
        function SelectAllCheckboxes(ListaCheckBox) {
            var oItem = ListaCheckBox.children;
            var theBox = (ListaCheckBox.type == "checkbox") ? ListaCheckBox : ListaCheckBox.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;
            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    //elm[i].click();
                    if (elm[i].checked != xState)
                        elm[i].click();
                    //elm[i].checked=xState;
                }
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">CONTROL DE DOCUMENTACIÓN</div>
    <uc1:contEncabezado1 ID="contEncabezado11" runat="server" />
    <div class="SubTitulo2">ORGANIZACIÓN:&nbsp;
        <asp:Label ID="LblOrganizacion" runat="server"></asp:Label>
        <asp:Label ID="LblIdIsnOrg" runat="server" Visible="False"></asp:Label>
    </div>
    <table class="TableBorder">
        <tr>
            <td width="150">Numero de Productores:</td>
            <td width="60">
                <asp:TextBox ID="TxtNumProd" runat="server" Width="40px" CssClass="Input"></asp:TextBox>
            </td>
            <td width="210">Superficie Total de la Organizacion:</td>
            <td width="40">
                <asp:TextBox ID="TxtSupTot" runat="server" CssClass="Input" Width="40px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
            <td rowspan="2" width="30" height="30">
                <asp:ImageButton ID="ImgPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" OnClick="ImgPrint_Click" Width="30px" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="LblMsj" runat="server" style="color: #CC0000; font-weight: 700"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVInsOrgDocPres" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVInsOrgDocPres_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Documento" HeaderText="Documento solicitado" />
            <asp:BoundField DataField="Id_Documento" HeaderText="Id_Documento" Visible="False" >
            <ItemStyle Width="0px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:CheckBox ID="CbxEstado" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td width="100">Observación:</td>
            <td rowspan="3">
                <asp:TextBox ID="TxtObservacion" runat="server" Height="100px" TextMode="MultiLine" Width="600px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
        </tr>
    </table>
    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrar_Click" />
    <asp:Button ID="Button2" runat="server" Text="Cancelar" style="height: 26px" />
    <br />
</asp:Content>
