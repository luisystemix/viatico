<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRP_ApoyoEmapa.aspx.cs" Inherits="WebAplication.Control.frmRP_ApoyoEmapa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        RESUMEN DE APOYO A LA PRODUCCIÓN DE EMAPA</div>
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
                &nbsp;</td>
            <td width="120">
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="60">Campaña:</td>
            <td>
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="60" rowspan="2">
                <div style="width: 120px; text-align: right"><asp:ImageButton ID="ImgBtnPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" OnClick="ImgBtnPrint_Click" />
                </div></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVPRodDep" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVPRodDep_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
            <asp:BoundField DataField="Id_Campanhia" HeaderText="Id_Campanhia" Visible="False" />
            <asp:BoundField DataField="Id_Regional" HeaderText="Id_Regional" Visible="False" />
            <asp:TemplateField HeaderText="N° Municipios">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LbNumlMuni" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N° Organizaciones">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblNumOrg" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N° Productores">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblNumProd" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sup. Apoyada (ha)">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblNumSup" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><div style="font-weight: 700; text-align: right">TOTAL:</div></td>
            <td width="119">
                <div style="text-align: right"><asp:Label ID="LblTotNumMuni" runat="server" Text="0" style="font-weight: 700"></asp:Label></div>
            </td>
            <td width="118">
                <div style="text-align: right"><asp:Label ID="LblTotNumOrgs" runat="server" Text="0" style="font-weight: 700"></asp:Label></div>
            </td>
            <td width="119">
                <div style="text-align: right"><asp:Label ID="LblTotNumProd" runat="server" Text="0" style="font-weight: 700"></asp:Label></div>
            </td>
            <td width="117">
                <div style="text-align: right"><asp:Label ID="LblTotSupApo" runat="server" Text="0" style="font-weight: 700"></asp:Label></div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </asp:Content>
