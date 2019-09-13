<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAvanceCosecha.aspx.cs" Inherits="WebAplication.AnalistasOFC.frmAvanceCosecha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        AVANCE DE COSECHA Y ACOPIO POR ORGANIZACIÓN</div>
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
            <td width="60">
                &nbsp;</td>
            <td width="160">
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
            <td>
                Campaña:</td>
            <td width="120">
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td width="60">Unidades:</td>
            <td>
                <asp:DropDownList ID="DDLUnidades" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLUnidades_SelectedIndexChanged" Width="70px">
                    <asp:ListItem Value="1">kg</asp:ListItem>
                    <asp:ListItem Value="2">Tonelada</asp:ListItem>
                    <asp:ListItem Value="3">Fanega</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="120">
                <div style="text-align: right; width: 154px;"></div>
                </td>
        </tr>
        </table>

    <asp:GridView ID="GVOrgSup" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVOrgSup_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" />
            <asp:BoundField DataField="Sigla" HeaderText="Sigla" />
            <asp:BoundField DataField="SumaHas" HeaderText="SumaHas" />
            <asp:TemplateField HeaderText="Cupo">
                <ItemTemplate>
                    <asp:TextBox ID="TxtCupo" runat="server" Width="60px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unidad (Estimada)">
                <ItemTemplate>
                    <asp:Label ID="LblFanegasEstim" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unidad (Real)">
                <ItemTemplate>
                    <asp:Label ID="LblFanegasReal" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acopio">
                <ItemTemplate>
                    <asp:Label ID="LblAcopio" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sup Cosechada">
                <ItemTemplate>
                    <asp:Label ID="LblSupCos" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
