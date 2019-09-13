<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmControlCronogramaSeg.aspx.cs" Inherits="WebAplication.Control.frmControlCronogramaSeg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        LISTA DE CRONOGRAMAS SEMANALES ENVIADOS</div>
        <table class="TableBorder">
            <tr>
                <td width="60">Regional:</td>
                <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td width="60">Campaña:</td>
                <td width="120">
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Técnico:</td>
                <td>
                    <asp:DropDownList ID="DDLTecnicos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTecnicos_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
                </td>
                <td rowspan="2"> 
                    <div style="text-align: right"><asp:ImageButton ID="ImgPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" /></div></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="5">
                    <div style="font-weight: 700; color: #FF0000; text-align: center"><asp:Label ID="LblMsj" runat="server"></asp:Label></div>
                </td>
            </tr>
        </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id_Cronograma" HeaderText="Codigo" />
            <asp:BoundField DataField="Cronograma" HeaderText="Nombre cronograma" />
            <asp:BoundField DataField="Fecha_Envio" HeaderText="Fecha Enviado" />
            <asp:BoundField DataField="Mes" HeaderText="Mes" />
            <asp:BoundField DataField="Semana" HeaderText="Semana" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:ButtonField ButtonType="Image" CommandName="imprimir" ImageUrl="~/images/printmgr.png" Text="Button">
            <ControlStyle Height="20px" Width="20px" />
            <ItemStyle Height="25px" Width="25px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
