<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEstadoFenologico.aspx.cs" Inherits="WebAplication.AnalistasOFC.frmEstadoFenologico" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
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
                <div style="text-align: right; width: 154px;"></div>
                </td>
        </tr>
        </table>

    <asp:GridView ID="GVEnvioSem" runat="server" AutoGenerateColumns="False" CssClass="TableBorder2" OnRowCommand="GVEnvioSem_RowCommand">
        <Columns>
            <asp:BoundField DataField="Fecha" HeaderText="Fecha Envio" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" />
            <asp:BoundField DataField="Num_Prod_Vigente" HeaderText="Num_Prod_Vigente" />
            <asp:BoundField DataField="Sup_Sembrada" HeaderText="Sup_Sembrada" />
            <asp:BoundField DataField="Avance_Siembra" HeaderText="Avance_Siembra" />
            <asp:BoundField DataField="Germinacion" HeaderText="Germinacion" />
            <asp:BoundField DataField="Plantula" HeaderText="Plantula" />
            <asp:BoundField DataField="Macollamiento" HeaderText="Macollamiento" />
            <asp:BoundField DataField="Embuche" HeaderText="Embuche" />
            <asp:BoundField DataField="Espigazon" HeaderText="Espigazon" />
            <asp:BoundField DataField="Floracion" HeaderText="Floracion" />
            <asp:BoundField DataField="Llenado_Grano" HeaderText="Llenado_Grano" />
            <asp:BoundField DataField="Maduracion" HeaderText="Maduracion" />
            <asp:BoundField DataField="Avance_cosecha" HeaderText="Avance_cosecha" />
            <asp:BoundField DataField="Rendimiento" HeaderText="Rendimiento" />
            <asp:BoundField DataField="Hasta" HeaderText="Hasta" Visible="False" />
            <asp:ButtonField CommandName="Ver" Text="Grafica" />
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td width="100">&nbsp;</td>
            <td>Periodo de verificación, desde: <asp:Label ID="LblFechaI" runat="server" style="font-weight: 700"></asp:Label>
&nbsp;hasta:
                <asp:Label ID="LblFechaF" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
    <asp:Chart ID="Chart1" runat="server">
        <Series>
            <asp:Series Name="Series1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
