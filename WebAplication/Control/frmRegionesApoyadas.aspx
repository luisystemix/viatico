<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegionesApoyadas.aspx.cs" Inherits="WebAplication.Control.frmRegionesApoyadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">CAMPAÑAS AGRICOLAS EMAPA</div>
    <table class="TableBorder">
        <tr>
            <td width="45">Region:</td>
            <td class="auto-style1">
                <asp:DropDownList ID="DDLRegion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegion_SelectedIndexChanged">
                    <asp:ListItem>ORIENTE</asp:ListItem>
                    <asp:ListItem>OCCIDENTE</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td width="60">
                Campaña:</td>
            <td width="120">
                <asp:DropDownList ID="DDLCamp" runat="server" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td> </td>
            <td colspan="3">
                <div style="text-align: center; font-weight: 700; color: #CC0000"><asp:Label ID="LblMsj" runat="server"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: right">
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVCampEmapa" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVCampEmapa_RowDataBound" OnRowCommand="GVCampEmapa_RowCommand">
        <Columns>
            <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
            <asp:BoundField DataField="Programa" HeaderText="Programa" />
            <asp:BoundField DataField="Id_Campanhia" HeaderText="Id_Campanhia" Visible="False" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" Visible="False" />
            <asp:BoundField DataField="Region" HeaderText="Region" Visible="False" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" />
            <asp:BoundField DataField="Id_Regional" HeaderText="Id_Regional" Visible="False" />
            <asp:TemplateField HeaderText="N° de Orgs">
                <ItemTemplate>
                    <asp:Label ID="LblNumOrg" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N° de Benefs">
                <ItemTemplate>
                    <asp:Label ID="LblNumProd" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sup Inscrita">
                <ItemTemplate>
                    <asp:Label ID="LblSupInscrita" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sup Apoyada" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="LblSupApoyada" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N° Depurados">
                <ItemTemplate>
                    <asp:Label ID="LblNumDepurados" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Designacion" Text="Designación Tec.">
            <ItemStyle Width="90px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Cronograna" Text="Cronograna Tec.">
            <ItemStyle Width="90px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>
    <div style="text-align: center"><asp:ImageButton ID="ImbBtnPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" OnClick="ImbBtnPrint_Click" Width="30px" /></div>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
