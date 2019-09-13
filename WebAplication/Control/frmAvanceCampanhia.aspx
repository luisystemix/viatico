<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAvanceCampanhia.aspx.cs" Inherits="WebAplication.Control.frmAvanceCampanhia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        AVANCE  LA CAMPAÑA</div>
    <table class="TableBorder">
        <tr>
            <td class="auto-style1" width="65">Programa:</td>
            <td>
                <asp:DropDownList ID="DDLProg" runat="server" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style1">Campaña:</td>
            <td width="120">
                <asp:DropDownList ID="DDLCamp" runat="server" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" width="65">Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td width="120">
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td></td>
            <td class="auto-style1">&nbsp;</td>
            <td rowspan="2">
                <div style="text-align: right"><asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" OnClick="ImageButton1_Click" Width="30px" /></div>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVAvances" runat="server" AutoGenerateColumns="False" CssClass="TableBorder2" OnRowDataBound="GVAvances_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
            <asp:BoundField DataField="Sigla" HeaderText="Sigla" />
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" />
            <asp:BoundField DataField="Id_Municipio" HeaderText="Id_Municipio" Visible="False" />
            <asp:TemplateField HeaderText="N° Benef Ins." Visible="False">
                <ItemTemplate>
                    <asp:Label ID="LblNumBenefIns" runat="server">0</asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N° Benef Aprob.">
                <ItemTemplate>
                    <asp:Label ID="LblNumBenefVig" runat="server">0</asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sup. Ap.(ha)">
                <ItemTemplate>
                    <asp:Label ID="LblSupApoyada" runat="server">0</asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rendimiento">
                <ItemTemplate>
                    <asp:Label ID="LblRendimiento" runat="server">0</asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Produccion Estimada (Fan)">
                <ItemTemplate>
                    <asp:Label ID="LblProdEstim" runat="server">0</asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acopio Estimado">
                <ItemTemplate>
                    <asp:Label ID="LblAcoEstim" runat="server">0</asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acopio (Fan)">
                <ItemTemplate>
                    <asp:Label ID="LblAcoFan" runat="server" Text="0"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Avance de cosecha">
                <ItemTemplate>
                    <asp:Label ID="LblAvanceSiem" runat="server" Text="0"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Superficie Cosechada">
                <ItemTemplate>
                    <asp:Label ID="LblSupCosech" runat="server" Text="0"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Diferencia(Fanegas)">
                <ItemTemplate>
                    <asp:Label ID="LblDifFan" runat="server" Text="0"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
