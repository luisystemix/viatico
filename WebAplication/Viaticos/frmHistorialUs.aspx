<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmHistorialUs.aspx.cs" Inherits="WebAplication.Viaticos.frmHistorialUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../js/validar.js" type="text/ecmascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js/jquery.quicksearch.js"></script>
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
    <script type="text/javascript">
        $(function () {
            $("[id*=GVListSolicitud] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
        $(function () {
            $("[id*=GVListSolicit] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
        $(function () {
            $('input#MainContent_TxtBuscar').quicksearch('table#MainContent_GVListSolicitud tbody tr');
        });
    </script>
    <%--GRIDVIEW MAKEOVER--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        HISTORIAL DE SOLICITUDES DE VIAJE REALIZADO</div>
    <table class="TableBorder">
        <tr>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="100">Buscar Solicitud:</td>
            <td width="200">
                <asp:TextBox ID="TxtBuscar" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td rowspan="2" width="35">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/kghostview.png" Height="35px" Width="35px" Visible="false" />
                </td>
            <td>
                <asp:Label ID="LblIdUser" runat="server" Visible="False"></asp:Label>
            </td>
            <td width="45">&nbsp;</td>
            <td rowspan="2" width="55" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><div style="font-size: 8pt">Ejm: Codigo y Fecha</div></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVListSolicitud" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVListSolicitud_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id_Solicitud" HeaderText="Codigo" >
            <ItemStyle Width="200px" />
            </asp:BoundField>
            <%--<asp:BoundField DataField="Motivo_Viaje" HeaderText="Motivo" />
            <asp:BoundField DataField="Fecha" HeaderText="Enviado" />
            <asp:BoundField DataField="Tipo_Salida" HeaderText="Salida" />
            <asp:BoundField DataField="Tipo_Viaje" HeaderText="Tipo de Viaje" />--%>
            <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="False" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" >
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Descrip_Motivo" HeaderText="Descripción" />
            <asp:ButtonField CommandName="Solicitud" Text="Solicitud" >
            <ItemStyle Width="20px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Informe" Text="Informe" >
            <ItemStyle Width="40px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Memo" CommandName="Memo">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
