<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmHistorialGAF.aspx.cs" Inherits="WebAplication.Viaticos.frmHistorialGAF" %>
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
            $("[id*=GVListSolicitudObs] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
        $(function () {
            $('input#MainContent_TxtBuscar').quicksearch('table#MainContent_GVListSolicitud tbody tr');
        });
        $(function () {
            $('input#MainContent_TxtBuscar').quicksearch('table#MainContent_GVListSolicitudObs tbody tr');
        });
    </script>
    <%--GRIDVIEW MAKEOVER--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">PROCESO DE SOLICITUDES FINALIZADAS (HISTORIAL) </div>
    <table class="TableBorder">
        <tr>
            <td  width="130"></td>
            <td></td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Desplegar por Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="100">Buscar Solicitud:</td>
            <td width="100">
                <asp:TextBox ID="TxtBuscar" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td rowspan="2" class="auto-style1" width="35">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/buscar.png" Height="35px" Width="35px" OnClick="ImageButton1_Click" Visible="False" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="LblMsg" runat="server" style="color: #CC0000; font-weight: 700"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <%--<div style="font-size: 8pt">
                    Ejm: Codigo</div>--%>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVListSolicitud" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" 
        OnRowCommand="GVListSolicitud_RowCommand" DataKeyNames="Id_Solicitud"
        OnRowDataBound="GVListSolicitud_RowDataBound"
        AllowPaging="true" PageSize="25"
        OnPageIndexChanging="GVListSolicitud_PageIndexChanging"
        OnPreRender="GVListSolicitud_PreRender">

         <PagerSettings FirstPageText="&#1055;&#1077;&#1088;&#1074;&#1072;&#1103;" 
            LastPageText="&#1055;&#1086;&#1089;&#1083;&#1077;&#1076;&#1085;&#1103;&#1103;" 
            PageButtonCount="15" position="Bottom" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle CssClass="pagination gridViewPaginacion a" HorizontalAlign="Center"
                VerticalAlign="Middle" 
            Font-Size="11pt" Wrap="True" BackColor="#a8daf7" />
        <Columns>
                            <asp:TemplateField>
                    <HeaderTemplate>
                        N°  
                    </HeaderTemplate>
                    <ItemTemplate>
                      <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>

            <asp:BoundField DataField="Id_Solicitud" HeaderText="Codigo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="ci" HeaderText="ci" Visible="False" />
            <asp:BoundField DataField="Motivo_Viaje" HeaderText="Motivo" Visible="False" />
            <asp:BoundField DataField="Fecha" HeaderText="Enviado" />
            <asp:BoundField DataField="Tipo_Viaje" HeaderText="Tipo" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" />
            <%--<asp:BoundField DataField="Estado" HeaderText="Estado" />--%>
            <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:DropDownList ID="DDLEstado" runat="server">
                            <asp:ListItem Value="FINALIZADO">FINALIZADO</asp:ListItem>
                            <asp:ListItem Value="INF-APROBADO">INF-APROBADO</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
            <asp:BoundField DataField="Id_Usuario" HeaderText="Id_Usuario" Visible="False" />
            <asp:BoundField DataField="EstadoInf" HeaderText="Informe" Visible="False" />
            <asp:ButtonField CommandName="Solicitud" Text="Solicitud">
            <ItemStyle Width="45px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Memo" Text="Memo">
            <ItemStyle Width="20px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Planilla" CommandName="Planilla">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Informe" CommandName="Informe">
            <ItemStyle Width="20px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Aprobar" Text="Cambiar Estado">
             <ControlStyle ForeColor="#0033CC" Font-Bold="True" />
             <ItemStyle Width="40px" />
             </asp:ButtonField>
        </Columns>
    </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
    </table>
    <div class="SubTitulo2">Observados</div>
    <asp:GridView ID="GVListSolicitudObs" runat="server" CssClass="TableBorder" AutoGenerateColumns="False"
        OnRowCommand="GVListSolicitudObs_RowCommand" AllowPaging="True" PageSize="25" 
        OnPageIndexChanging="GVListSolicitudObs_PageIndexChanging" DataKeyNames="Id_Solicitud"
        OnPreRender="GVListSolicitudObs_PreRender">
        <PagerSettings FirstPageText="&#1055;&#1077;&#1088;&#1074;&#1072;&#1103;" 
            LastPageText="&#1055;&#1086;&#1089;&#1083;&#1077;&#1076;&#1085;&#1103;&#1103;" 
            PageButtonCount="15" position="Bottom" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle CssClass="pagination gridViewPaginacion a" HorizontalAlign="Center"
                VerticalAlign="Middle" 
            Font-Size="11pt" Wrap="True" BackColor="#a8daf7" />
        <Columns>
              <%--  <asp:TemplateField>
                    <HeaderTemplate>
                        N°  
                    </HeaderTemplate>
                    <ItemTemplate>
                      <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>--%>
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
            <asp:BoundField DataField="EstadoInf" HeaderText="Informe" Visible="False" />
            <asp:ButtonField CommandName="Solicitud" Text="Solicitud">
            <ItemStyle Width="45px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Memo" Text="Memo" Visible="False">
            <ItemStyle Width="20px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Planilla" CommandName="Planilla" Visible="False">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Informe" CommandName="Informe" Visible="False">
            <ItemStyle Width="20px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
        </asp:Content>
