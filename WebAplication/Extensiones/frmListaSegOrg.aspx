<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaSegOrg.aspx.cs" Inherits="WebAplication.Extensiones.frmListaSegOrg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--GRIDVIEW MAKEOVER--%>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        td
        {
            cursor: pointer;
        }
        .hover_row
        {
            background-color: #c5bfb7/*#A1DCF2*/;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=GVLisOrg] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>
    <%--GRIDVIEW MAKEOVER--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">FORMULARIO DE SEGUIMIENTO TÉCNICO</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Regional:</td>
            <td>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="150">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
        </tr>
    </table>
    <div class="SubTitulo2">LISTA DE ORGANIZACIONES ASIGNADAS</div>
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
            <asp:ButtonField Text="Seguimiento" CommandName="Seguimiento">
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
    <%--<div>LISTA DE ORGANIZACIONES NO ASIGNADAS PARA APOYO ENTRE TÉCNICOS</div>--%>
</asp:Content>
