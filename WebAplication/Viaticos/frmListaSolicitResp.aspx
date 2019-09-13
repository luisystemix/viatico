<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaSolicitResp.aspx.cs" Inherits="WebAplication.Viaticos.frmListaSolicitResp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../js/validar.js" type="text/ecmascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
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
            $("[id*=GVListSegSolicit] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>
    <%--GRIDVIEW MAKEOVER--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        <asp:Label ID="Label1" runat="server" Text="SOLICITUDES ENVIADAS" Font-Bold="True"></asp:Label>
        </div>
    <table class="TableBorder">        
        <tr>
            <td>
                <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label></div>
            </td>
        </tr>
        </table>
    <asp:GridView ID="GVListSolicitud" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVListSolicitud_RowCommand" AllowPaging="true" OnPageIndexChanging="GVListSolicitud_PageIndexChanging" Font-Size="Smaller">
        <Columns>
            <asp:BoundField DataField="Id_Solicitud" HeaderText="Codigo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="ci" HeaderText="ci" Visible="False" />
            <asp:BoundField DataField="Motivo_Viaje" HeaderText="Motivo" />
            <asp:BoundField DataField="Fecha" HeaderText="Enviado" />
            <asp:BoundField DataField="Tipo_Viaje" HeaderText="Tipo de Viaje" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="False" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_Usuario" HeaderText="Id_Usuario" />
            <asp:ButtonField CommandName="DarCurso" Text="Dar-Curso">
            <ItemStyle Width="75px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Ver" Text="Solicitud">
            <ItemStyle Width="45px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    <div class="SubTitulo2">INFORMES ENVIADOS</div>
    <asp:GridView ID="GVListSegSolicit" runat="server" CssClass="TableBorder" 
        AutoGenerateColumns="False" 
        OnRowCommand="GVListSegSolicit_RowCommand" 
        AllowPaging="true" 
        OnPageIndexChanging="GVListSegSolicit_PageIndexChanging" Font-Size="Smaller">
         <PagerSettings FirstPageText="&#1055;&#1077;&#1088;&#1074;&#1072;&#1103;" 
            LastPageText="&#1055;&#1086;&#1089;&#1083;&#1077;&#1076;&#1085;&#1103;&#1103;" 
            PageButtonCount="15" position="Bottom" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle CssClass="pagination gridViewPaginacion a" HorizontalAlign="Center"
                VerticalAlign="Middle" 
            Font-Size="11pt" Wrap="True" BackColor="#a8daf7" />
        <Columns>
            <asp:BoundField DataField="Id_Solicitud" HeaderText="Codigo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="ci" HeaderText="ci" Visible="False" />
            <asp:BoundField DataField="Motivo_Viaje" HeaderText="Motivo" />
            <asp:BoundField DataField="Fecha" HeaderText="Enviado" />
            <asp:BoundField DataField="Tipo_Viaje" HeaderText="Tipo de Viaje" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="False" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:ButtonField CommandName="Solicitud" Text="Solicitud">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Informe" Text="Informe">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Aprobar" Text="Aprobar-Inf">
            <ItemStyle Width="63px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    <div class="SubTitulo2">SOLICITUDES FINALIZADAS</div>
    <asp:GridView ID="GVListSegSolicitFin" runat="server" CssClass="TableBorder2" 
        AutoGenerateColumns="False" OnRowCommand="GVListSegSolicitFin_RowCommand" 
        OnPageIndexChanging="GVListSegSolicitFin_PageIndexChanging" 
        AllowPaging="true" Font-Size="Smaller">
          <PagerSettings FirstPageText="&#1055;&#1077;&#1088;&#1074;&#1072;&#1103;" 
            LastPageText="&#1055;&#1086;&#1089;&#1083;&#1077;&#1076;&#1085;&#1103;&#1103;" 
            PageButtonCount="15" position="Bottom" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle CssClass="pagination gridViewPaginacion a" HorizontalAlign="Center"
                VerticalAlign="Middle" 
            Font-Size="11pt" Wrap="True" BackColor="#a8daf7" />
        <Columns>
            <asp:BoundField DataField="Id_Solicitud" HeaderText="Codigo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="ci" HeaderText="ci" Visible="False" />
            <asp:BoundField DataField="Motivo_Viaje" HeaderText="Motivo" />
            <asp:BoundField DataField="Fecha" HeaderText="Enviado" />
            <asp:BoundField DataField="Tipo_Viaje" HeaderText="Tipo de Viaje" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="False" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:ButtonField CommandName="Solicitud" Text="Solicitud">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Informe" Text="Informe">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    </asp:Content>
