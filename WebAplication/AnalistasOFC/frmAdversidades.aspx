<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAdversidades.aspx.cs" Inherits="WebAplication.AnalistasOFC.frmAdversidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        APOYO A LA PRODUCCIÓN DE EMAPA</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Programa:</td>
            <td>
                <asp:DropDownList ID="DDLProg" runat="server" OnSelectedIndexChanged="DDLProg_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
            <td width="60">Campaña:</td>
            <td width="120">
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td>Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            &nbsp;<asp:Label ID="LblIdReg" runat="server"></asp:Label>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <div style="text-align: right">
                <asp:ImageButton ID="ImgBtnPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" OnClick="ImgBtnPrint_Click" Visible="False" />
               </div>
            </td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="50">&nbsp;</td>
            <td width="100">&nbsp;</td>
            <td width="30">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Periodo:</td>
            <td>
                <asp:DropDownList ID="DDLYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLYear_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>mes:</td>
            <td>
                <asp:DropDownList ID="DDLMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLMonth_SelectedIndexChanged">
                    <asp:ListItem Value="1">Enero</asp:ListItem>
                    <asp:ListItem Value="2">Febreo</asp:ListItem>
                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                    <asp:ListItem Value="4">Abril</asp:ListItem>
                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                    <asp:ListItem Value="6">Junio</asp:ListItem>
                    <asp:ListItem Value="7">Julio</asp:ListItem>
                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVAdversidades" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
        <Columns>
            <asp:BoundField DataField="Sigla" HeaderText="Sigla" />
            <asp:BoundField DataField="Productor" HeaderText="Productor" />
            <asp:BoundField DataField="Adversidad" HeaderText="Adversidad" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            <asp:BoundField DataField="Intencidad" HeaderText="Intencidad" />
            <asp:BoundField DataField="Porcentage" HeaderText="Porcentage" />
            <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" />
            <asp:BoundField DataField="Fecha_Seg" HeaderText="Fecha_Seg" />
        </Columns>
    </asp:GridView>
</asp:Content>
