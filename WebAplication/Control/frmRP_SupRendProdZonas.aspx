<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRP_SupRendProdZonas.aspx.cs" Inherits="WebAplication.Control.frmRP_SupRendProdZonas" %>
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
            <td width="60">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="120">
                <div style="text-align: right; width: 154px;"><asp:ImageButton ID="ImgBtnPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" OnClick="ImgBtnPrint_Click" /></div>
                </td>
        </tr>
        </table>
    <asp:GridView ID="GVPRodDep" runat="server" CssClass="TableBorder2" AutoGenerateColumns="False" OnRowDataBound="GVPRodDep_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Municipio" HeaderText="Zona" />
            <asp:BoundField DataField="Sigla" HeaderText="Organización" />
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" />
            <asp:BoundField DataField="Id_Municipio" HeaderText="Id_Municipio" Visible="False" />
            <asp:TemplateField HeaderText="N° Productores">
                <ItemTemplate>
                     <div style="text-align: right"><asp:Label ID="LblNumP" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sup. Inscrita (ha)">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblSupIns" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sup. Apoyada (ha)">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblSupApo" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rendimiento (fn/ha)">
                <ItemTemplate>
                    <div style="text-align: right"><asp:Label ID="LblRendFnha" runat="server"></asp:Label></div>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acopio (fn) est.">
                <ItemTemplate>
                    <asp:Label ID="LblAcopEstim" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acopio (fn)">
                <ItemTemplate>
                    <asp:Label ID="LblAcopFn" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Avance de cosecha (%)">
                <ItemTemplate>
                    <asp:Label ID="LblAvanceCosecha" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Diferencia (fn)">
                <ItemTemplate>
                    <asp:Label ID="LblDiferencia" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><div style="font-weight: 700; text-align: right">TOTAL:</div></td>
            <td width="60">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotNumProd" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="62">
                 <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotSupInsHa" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="64">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotSupApo" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="62">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotRendFnHa" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="60">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotProdfn" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="60">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotProdfn0" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="60">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotProdfn1" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
            <td width="58">
                <div style="font-weight: 700; text-align: right"><asp:Label ID="LblTotProdfn2" runat="server" Text="0" style="font-size: xx-small"></asp:Label></div>
            </td>
        </tr>
    </table>
    </asp:Content>
