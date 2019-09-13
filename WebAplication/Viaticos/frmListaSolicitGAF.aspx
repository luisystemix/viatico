<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaSolicitGAF.aspx.cs" Inherits="WebAplication.Viaticos.frmListaSolicitGAF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../js/validar.js" type="text/ecmascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js/jquery.quicksearch.js"></script>
    <%--GRIDVIEW MAKEOVER--%>
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        td {
            cursor: pointer;
        }

        .hover_row {
            background-color: #c5bfb7 /*#A1DCF2*/;
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
            $('input#MainContent_txt_Buscar_Solicitud').quicksearch('table#MainContent_GVListSolicitud tbody tr');
        });
    </script>
    <%--GRIDVIEW MAKEOVER--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        SOLICITUDES RECOGIDAS PARA PROCESAR SU PLANILLA
    </div>
    <table class="TableBorder">
        <tr>
            <td width="135">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <div class="SubTitulo2">SOLICITUDES RECIBIDAS
                    <asp:TextBox ID="txt_Buscar_Solicitud" runat="server" Width="150px"></asp:TextBox></div>

            </td>

        </tr>
    </table>
    <div style="font-size: 9pt">
        <div style="text-align: center">
            <asp:Label ID="LblMsg" runat="server" Style="color: #CC0000; font-weight: 700"></asp:Label></div>
        <span style="width:80%
">
        <asp:GridView ID="GVListSolicitud" runat="server" CssClass="TableBorder"
            AutoGenerateColumns="False" OnRowCommand="GVListSolicitud_RowCommand"
            OnRowDataBound="GVListSolicitud_RowDataBound" DataKeyNames="Id_Solicitud"
            OnPageIndexChanging="GVListSolicitud_PageIndexChanging"
            PageSize="25" AllowPaging="True"
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
                <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="False" />
                <%--<asp:BoundField DataField="Estado" HeaderText="Estado" />--%>
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:DropDownList ID="DDLEstado" runat="server">
                            <asp:ListItem>ENVIADO</asp:ListItem>
                            <asp:ListItem>PROCESADO</asp:ListItem>
                            <asp:ListItem>ANULADO</asp:ListItem>
                            <asp:ListItem>FINALIZADO</asp:ListItem>
                            <asp:ListItem>APROBADO</asp:ListItem>
                            <asp:ListItem>OBSERVADO</asp:ListItem>
                            <asp:ListItem>HABILITADO</asp:ListItem>
                            <asp:ListItem>INF-ENVIADO</asp:ListItem>
                            <asp:ListItem>INF-APROBADO</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Id_Usuario" HeaderText="Id_Usuario" Visible="true" />
                <asp:TemplateField HeaderText="Observación" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="LblObs" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField CommandName="Solicitud" Text="Solicitud">
                    <ItemStyle Width="45px" />
                </asp:ButtonField>

              <%--    <asp:TemplateField>
                    <ItemTemplate>
                     <asp:Button runat="server" ID="btnSolicitud" CommandName="Solicitud" Text="Solicitud" 
                         ToolTip='<%# "Ver Solicitud:" + Eval("Id_Solicitud")%>'  BackColor="#e5f688" 
                         CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                    </ItemTemplate>

                </asp:TemplateField>--%>


                <asp:ButtonField CommandName="Memo" Text="Memo">
                    <ItemStyle Width="35px" />
                </asp:ButtonField>

               <%--   <asp:TemplateField>
                    <ItemTemplate>
                     <asp:Button runat="server" ID="btnMemo" CommandName="Memo" Text="Memo" 
                         ToolTip='<%# "Ver Memo:" + Eval("Id_Solicitud")%>'  BackColor="#c4f899" 
                         CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                    </ItemTemplate>

                </asp:TemplateField>--%>

                <asp:ButtonField CommandName="Informe" Text="Informe">
                    <ItemStyle Width="43px" />
                </asp:ButtonField>

               <%--   <asp:TemplateField>
                    <ItemTemplate>
                     <asp:Button runat="server" ID="btnInforme" CommandName="Informe" Text="Informe" 
                         ToolTip='<%# "Ver Informe:" + Eval("Id_Solicitud")%>'  BackColor="#82d1f4" 
                         CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                    </ItemTemplate>

                </asp:TemplateField>--%>

                <asp:ButtonField Text="Ver" CommandName="Ver" Visible="False">
                    <ItemStyle Width="20px" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="Aprobar" Text="Cambiar Estado">
                    <ControlStyle ForeColor="#0033CC" Font-Bold="True" />
                    <ItemStyle Width="40px" />
                </asp:ButtonField>

               <%--  <asp:TemplateField>
                    <ItemTemplate>
                     <asp:Button runat="server" ID="btnAprobar" CommandName="Aprobar" Text="Cambiar Estado" 
                         ToolTip='<%# "Cambio de la Solicitud:" + Eval("Id_Solicitud")%>'  BackColor="#f6845f" 
                         CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                    </ItemTemplate>

                </asp:TemplateField>--%>



              <%--  <asp:ButtonField Text="Procesar Planilla"  CommandName="Procesar">
            <ItemStyle Width="86px" />
            </asp:ButtonField>--%>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkProcesar" CommandName="Procesar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>">
                     <em class="fa fa-times">&nbsp;&nbsp;&nbsp;</em>
                      Procesar Planilla
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--   <asp:TemplateField>
                    <ItemTemplate>
                     <asp:Button runat="server" ID="btnProcesar" CommandName="Procesar" Text="Procesar Planilla" 
                         ToolTip='<%# "Generar Planilla para solicitud:" + Eval("Id_Solicitud")%>'  BackColor="#d4d3d9" 
                         CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                    </ItemTemplate>

                </asp:TemplateField>--%>



                <asp:ButtonField CommandName="Observar" Text="Observar" Visible="False">
                    <ItemStyle Width="20px" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
            </span>
        <table class="TableBorder">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div class="SubTitulo2">SOLICITUDES PROCESADAS (FINALIZAR EL PROCESO)</div>
        <asp:GridView ID="GVListSolicit" runat="server" CssClass="TableBorder"
            AutoGenerateColumns="False" PageSize="20" AllowPaging="True"
            OnPageIndexChanging="GVListSolicit_PageIndexChanging"
            OnRowCommand="GVListSolicit_RowCommand" DataKeyNames="Id_Solicitud"
            OnRowDataBound="GVListSolicit_RowDataBound">
            <Columns>
<%--                  <asp:TemplateField>
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
                <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="False" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="Id_Usuario" HeaderText="Id_Usuario" Visible="False" />
                <asp:TemplateField HeaderText="Observación" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="LblObs" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField CommandName="Solicitud" Text="Solicitud">
                    <ItemStyle Width="45px" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="Memo" Text="Memo">
                    <ItemStyle Width="35px" />
                </asp:ButtonField>
                <asp:ButtonField Text="Ver" CommandName="Ver" Visible="False">
                    <ItemStyle Width="20px" />
                </asp:ButtonField>
                <asp:ButtonField Text="Planilla" CommandName="Planilla">
                    <ItemStyle Width="35px" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="Informe" Text="Informe">
                    <ItemStyle Width="43px" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="Finalizar" Text="Finalizar Proceso">
                    <ItemStyle Width="90px" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
