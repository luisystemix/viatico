<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaInformesUs.aspx.cs" Inherits="WebAplication.Viaticos.frmListaInformesUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function getIndex(index) {
            alert(index);
            alert('Link');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        INFORMES PENDIENTES</div>
    <table class="TableBorder">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td width="100"><asp:Label ID="LblIdUser" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label></div>
            </td>
        </tr>
        </table>
    <asp:GridView ID="GVListSolicitud" runat="server" CssClass="TableBorder" 
                AutoGenerateColumns="False" DataKeyNames="Id_Solicitud" 
                OnRowCommand="GVListSolicitud_RowCommand" 
                AllowPaging="true"
                PageSize="25" OnPageIndexChanging="GVListSolicitud_PageIndexChanging"
                OnRowDataBound="GVListSolicitud_RowDataBound">
        <Columns>
            

            <asp:BoundField DataField="Id_Solicitud" HeaderText="Codigo" />
            <asp:BoundField DataField="Motivo_Viaje" HeaderText="Motivo" />
            <asp:BoundField DataField="Fecha" HeaderText="Enviado" />
            <asp:BoundField DataField="Tipo_Salida" HeaderText="Salida" />
            <asp:BoundField DataField="Tipo_Viaje" HeaderText="Tipo de Viaje" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="EstadoInf" HeaderText="Estado Inf" Visible="False" >
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Observación">
                <ItemTemplate>
                    <asp:Label ID="LblObs" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Solicitud" Text="Ver-Sol">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Ver" Text="Ver-Inf" >
            <ItemStyle Width="38px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Realizar" Text="Realizar-Inf">
            <ItemStyle Width="60px"/>
            </asp:ButtonField>
            <asp:ButtonField CommandName="Modificar" Text="Modificar"  >
            <ItemStyle Width="50px" />
            </asp:ButtonField>           
        </Columns>
    </asp:GridView>
</asp:Content>
