<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRevisarInformes.aspx.cs" Inherits="WebAplication.Viaticos.frmRevisarInformes" %>
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
            $("[id*=GVListSolicit] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>
    <%--GRIDVIEW MAKEOVER--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">FORMULARIO DE REVISIÓN DE DOCUMENTOS E INFORMES DE VIAJE</div><table class="TableBorder">
        <tr>
            <td width="130">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Desplegar por regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label></div>
    <div class="SubTitulo2">ESTADO DE LAS SOLICITUDES CON RESPECTO AL ENVIO DE INFORMES</div>
    <asp:GridView ID="GVListSolicitud" runat="server" CssClass="TableBorder"  DataKeyNames="Id_Solicitud"
        AutoGenerateColumns="False" OnRowCommand="GVListSolicitud_RowCommand" 
        OnRowDataBound="GVListSolicitud_RowDataBound"
        AllowPaging="True" PageSize="25" OnPageIndexChanging="GVListSolicitud_PageIndexChanging"
        >
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
            <asp:BoundField DataField="Motivo_Viaje" HeaderText="Motivo" Visible="False" />
            <asp:BoundField DataField="Fecha" HeaderText="Enviado" />
            <asp:BoundField DataField="Tipo_Viaje" HeaderText="Tipo" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_Usuario" HeaderText="Id_Usuario" Visible="False" />
            <asp:BoundField DataField="EstadoInf" HeaderText="Estado Inf." Visible="False" />
            <asp:ButtonField CommandName="Solicitud" Text="Solicitud">
            <ItemStyle Width="45px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Memo" Text="Memo" Visible="False">
            <ItemStyle Width="20px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Planilla" CommandName="Planilla" Visible="False">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Informe" CommandName="Informe">
            <ItemStyle Width="20px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Finalizar" Text="FINALIZAR" Visible="False">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Rechazar" Text="RECHAZAR" Visible="False">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
    <div class="SubTitulo2">SOLICITUDES OBSERVADAS Y SOLICITUDES QUE NO PRESENTARON INFORME EN EL PLAZO DE 8 DÍAS</div>
    <asp:GridView ID="GVListSolicit" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" 
        OnRowCommand="GVListSolicit_RowCommand" DataKeyNames="Id_Solicitud"
        OnRowDataBound="GVListSolicit_RowDataBound"
        AllowPaging="True" PageSize="25" OnPageIndexChanging="GVListSolicit_PageIndexChanging"
        >
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
            <asp:BoundField DataField="Motivo_Viaje" HeaderText="Motivo" Visible="False" />
            <asp:BoundField DataField="Fecha" HeaderText="Enviado" />
            <asp:BoundField DataField="Tipo_Viaje" HeaderText="Tipo" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_Usuario" HeaderText="Id_Usuario" Visible="False" />
            <asp:TemplateField HeaderText="Observación">
                <ItemTemplate>
                    <asp:Label ID="LblObs" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Rehabilitar" Text="Rehabilitar">
            <ItemStyle Width="40px" BorderStyle="None" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    </asp:Content>
