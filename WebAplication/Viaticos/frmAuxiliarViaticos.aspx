<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAuxiliarViaticos.aspx.cs" Inherits="WebAplication.Viaticos.frmAuxiliarViaticos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        SOLICITUDES RECOGIDAS PARA PROCESAR SU PLANILLA</div>
    <table class="TableBorder">
        <tr>
            <td width="135">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Desplegar por Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <div class="SubTitulo2">SOLICITUDES RECIBIDAS</div></td>
        </tr>
        </table>
                <div style="text-align: center"><asp:Label ID="LblMsg" runat="server" style="color: #CC0000; font-weight: 700"></asp:Label></div>
            <asp:GridView ID="GVListSolicitud" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVListSolicitud_RowCommand" OnRowDataBound="GVListSolicitud_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Id_Solicitud" HeaderText="Codigo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="ci" HeaderText="ci" Visible="False" />
            <asp:BoundField DataField="Motivo_Viaje" HeaderText="Motivo" Visible="False" />
            <asp:BoundField DataField="Fecha" HeaderText="Enviado" />
            <asp:BoundField DataField="Tipo_Viaje" HeaderText="Tipo" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="False" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_Usuario" HeaderText="Id_Usuario" Visible="False" />
            <asp:TemplateField HeaderText="Observación" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="LblObs" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Solicitud" Text="Solicitud">
            <ItemStyle Width="45px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Memo" Text="Memo">
            <ItemStyle Width="35px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Informe" Text="Informe">
            <ItemStyle Width="43px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Ver" CommandName="Ver" Visible="False">
            <ItemStyle Width="20px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
                </asp:Content>
