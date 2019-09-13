<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaCostos.aspx.cs" Inherits="WebAplication.Extensiones.frmListaCostos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        LISTA DEL SEGUIMIENTOS A LA DISTRIBUCIÓN DE SEMILLA</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Agricultor:</td>
            <td width="250">
                <asp:Label ID="LblProductor" runat="server"></asp:Label>
                </td>
            <td width="80">Organización:</td>
            <td>
                <asp:Label ID="LblOrg" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsOrg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="55">Campaña:</td>
            <td width="120">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblProg" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsProd" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td width="120">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:LinkButton ID="LnkBtnSegDistSem" runat="server" OnClick="LnkBtnSegDistSem_Click">Registrar costo &gt;&gt;</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVListCostos" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVListCostos_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id_Seguimiento" HeaderText="Codigo" />
            <asp:BoundField DataField="Fecha_Envio" HeaderText="Fecha Envio" />
            <asp:BoundField DataField="Fecha_Seguimiento" HeaderText="Inspección" />
            <asp:BoundField DataField="Tipo_Siembra" HeaderText="Tipo de Siembra" />
            <asp:BoundField DataField="Superficie" HeaderText="Superficie (ha)" />
            <asp:BoundField DataField="Nombre" HeaderText="Regional" />
            <asp:BoundField DataField="Id_Productor" HeaderText="Id_Productor" Visible="False" />
            <asp:ButtonField Text="Ver Reporte" ButtonType="Image" CommandName="Reporte" ImageUrl="~/images/printmgr.png" Visible="False">
            <ControlStyle Width="20px" />
            <ItemStyle Width="20px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td>
               <div style="text-align: center"> <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/printmgr.png" Width="30px" OnClick="ImageButton1_Click" /></div>
            </td>
        </tr>
    </table>
</asp:Content>
