<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaCronogramas.aspx.cs" Inherits="WebAplication.Registro.frmListaCronogramas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 0px" class="SubTitulo">PLANIFICACIÓN DE LA CAMPAÑA AGRÍCOLA </div><table class="TableBorder">
        <tr>
            <td width="70">&nbsp;</td>
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
            <td>Campaña:</td>
            <td>
                <asp:DropDownList ID="DDLCamp" runat="server" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Label ID="LblEstado" runat="server"></asp:Label>
            </td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLProg" runat="server">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <div style="text-align: right"><asp:LinkButton ID="LnkCronograma" runat="server" OnClick="LnkCronograma_Click">Definir Cronograma</asp:LinkButton></div>
            </td>
        </tr>
        <tr>
            <td colspan="5"><div style="text-align: center; color: #CC0000; font-weight: 700">
                <asp:Label ID="LblMsj" runat="server" style="text-align: center"></asp:Label>
                </div></td>
        </tr>
    </table>
    <div class="SubTitulo2">LISTA DE CRONOGRAMAS DE LA CAMPAÑA AGRÍCOLA</div>
    <asp:GridView ID="GVCronogramas" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVCronogramas_RowCommand">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Programa" HeaderText="Programa" />
            <asp:BoundField DataField="FechaEnviado" HeaderText="Fecha Enviado" />
            <asp:BoundField DataField="EstadoCapanhia" HeaderText="Estado de Capaña" />
            <asp:BoundField DataField="EstadoCronograma" HeaderText="Estado de Cronograma" />
            <asp:BoundField DataField="Id_Cronograma" HeaderText="Id_Cronograma" Visible="False" />
            <asp:ButtonField CommandName="Seguimiento" Text="Seguimiento al cronograma">
            <ItemStyle Width="150px" />
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" CommandName="imprimir" ImageUrl="~/images/printmgr.png" Text="Button">
            <ControlStyle Height="20px" Width="20px" />
            <ItemStyle Height="25px" Width="25px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
