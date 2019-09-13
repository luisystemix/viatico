<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRP_SegDocumentos.aspx.cs" Inherits="WebAplication.Control.frmRP_SegDocumentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        DOCUMENTACIÓN DEL SEGUIMIENTO</div>
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
            <td>&nbsp;</td>
            <td width="120">
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="60">Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td width="120">&nbsp;</td>
        </tr>
        <tr>
            <td width="60">Campaña:</td>
            <td>
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td width="60" rowspan="2">
                <asp:ImageButton ID="ImgBtnPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" Visible="False" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVLisOrg" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVLisOrg_RowCommand" OnRowDataBound="GVLisOrg_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="Organización" DataField="Personeria_Juridica" />
            <asp:TemplateField HeaderText="N° Productores">
                <ItemTemplate>
                    <asp:Label ID="LblNumProd" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="Superficie(ha)" DataField="Superficie" >
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Estado" DataField="Estado" >
            <ItemStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" />
            <asp:ButtonField Text="Seguimiento" CommandName="Seguimiento" Visible="False">
            <ItemStyle Width="65px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Fase Fenológica" CommandName="Fenologia">
            <ItemStyle Width="85px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Semilla" Text="Distrib Sem">
            <ItemStyle Width="62px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Distrib AgroQuim" CommandName="Quimicos">
            <ItemStyle Width="95px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Rendimiento" CommandName="Rendimiento">
            <ItemStyle Width="70px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Costos" CommandName="Costos">
            <ItemStyle Width="35px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    </asp:Content>
