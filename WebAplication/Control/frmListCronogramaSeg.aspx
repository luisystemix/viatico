<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListCronogramaSeg.aspx.cs" Inherits="WebAplication.Control.frmListCronogramaSeg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">LISTA DE CRONOGRAMAS PRESENTADOS</div>&nbsp;<table class="TableBorder">
        <tr>
            <td width="70">
                <asp:Label ID="LblIdUser" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="50">Regional:</td>
            <td width="130">
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td></td>
            <td></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <div style="text-align: right"><asp:LinkButton ID="LnkCronograma" runat="server" OnClick="LnkCronograma_Click">Definir Cronograma</asp:LinkButton></div>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVCronogramas" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVCronogramas_RowCommand" OnRowDataBound="GVCronogramas_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Id_Cronograma" HeaderText="Codigo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" />
            <asp:BoundField DataField="Cronograma" HeaderText="Cronograma" />
            <asp:BoundField DataField="Fecha_Envio" HeaderText="Fecha_Envio" Visible="False" />
            <asp:BoundField DataField="Mes" HeaderText="Mes" />
            <asp:BoundField DataField="Semana" HeaderText="Semana" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:ButtonField ButtonType="Image" CommandName="imprimir" ImageUrl="~/images/printmgr.png" Text="Button">
            <ControlStyle Height="20px" Width="20px" />
            <ItemStyle Height="25px" Width="25px" />
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" CommandName="seguimiento" ImageUrl="~/images/lists.png" Text="Button">
            <ControlStyle Height="20px" Width="20px" />
            <ItemStyle Height="25px" Width="25px" />
            </asp:ButtonField>
             <asp:ButtonField ButtonType="Image" CommandName="editar" ImageUrl="~/images/edit.png" Text="Button">
            <ControlStyle Height="20px" Width="20px" />
            <ItemStyle Height="25px" Width="25px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
