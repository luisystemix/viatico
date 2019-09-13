<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaSolicitUs.aspx.cs" Inherits="WebAplication.Viaticos.frmListaSolicitUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        LISTA DE
        SOLICITUDES REALIZADAS</div>
    <table class="TableBorder">
        <tr>
            <td width="100">&nbsp;</td>
            <td width="200">
                &nbsp;</td>
            <td rowspan="2" width="35">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="45">&nbsp;</td>
            <td rowspan="2" width="55" class="auto-style1">
                <asp:LinkButton ID="LnkNuevo" runat="server" OnClick="LnkNuevo_Click">[ Nuevo ]</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblIdUser" runat="server" Visible="False"></asp:Label>
            </td>
            <td><div style="font-size: 8pt"></div></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVListSolicitud" runat="server" 
        CssClass="TableBorder" DataKeyNames="Id_Solicitud" 
        AutoGenerateColumns="False" AllowPaging="true" PageSize="25"
         OnPageIndexChanging="GVListSolicitud_PageIndexChanging"
        OnRowCommand="GVListSolicitud_RowCommand" 
        OnRowDataBound="GVListSolicitud_RowDataBound">
        <Columns>
             
            <asp:BoundField DataField="Id_Solicitud" HeaderText="Código" />
            <asp:BoundField DataField="Motivo_Viaje" HeaderText="Motivo" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha de Envió" />
            <asp:BoundField DataField="Tipo_Salida" HeaderText="Salida" />
            <asp:BoundField DataField="Tipo_Viaje" HeaderText="Tipo de Viaje" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:TemplateField HeaderText="Observación">
                <ItemTemplate>
                    <asp:Label ID="LblObs" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Solicitud" Text="Solicitud" >
            <ItemStyle Width="40px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Memo" Text="Memo">
            <ItemStyle Width="35px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Editar" Text="Modificar" >
            <ItemStyle Width="52px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
</asp:Content>
