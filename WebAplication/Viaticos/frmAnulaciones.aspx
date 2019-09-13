<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAnulaciones.aspx.cs" Inherits="WebAplication.Viaticos.frmAnulaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../js/validar.js" type="text/ecmascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <link href="../Css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" type="text/css" />
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
            $("[id*=GVListSolAnulados] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
          function Confirmacion() {
              var seleccion = confirm("Está seguro de que quiere anular la solicitud de viaje...?");
              return seleccion;
          }
  </script> 
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="SubTitulo">FORMULARIO DE ANULACIÓN</div>
    <table class="TableBorder">
        <tr>
            <td width="100">&nbsp;</td>
            <td width="160">&nbsp;</td>
            <td width="200">&nbsp;</td>
            <td width="20">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Código de solicitud a Anular:</td>
            <td>
                <asp:TextBox ID="TxtCodigo" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:ImageButton ID="ImgBtnBuscar" runat="server" ImageUrl="~/images/icono_buscar.gif" OnClick="ImgBtnBuscar_Click" />
            </td>
            <td>&nbsp;</td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblEstado" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
            <asp:GridView ID="GVListSolicitud" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id_Solicitud" HeaderText="Codigo" Visible="False" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="ci" HeaderText="ci" Visible="False" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="Motivo_Viaje" HeaderText="Motivo" />
            <asp:BoundField DataField="Fecha_Solicitud" HeaderText="Enviado" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
        </Columns>
    </asp:GridView>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <table class="TableBorder">
                            <tr>
                                <td>&nbsp;</td>
                                <td><div style="text-align: center; font-weight: 700; font-size: 12pt">MOTIVO DE ANULACIÓN PARA LA SOLICITUD</div></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <div style="text-align: center">
                                        <asp:TextBox ID="TxtObsser" runat="server" Height="100px" style="text-align: left" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                    </div>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <div style="text-align: center">
                                        <asp:Button ID="BtnAceptar" runat="server" OnClientClick ="return Confirmacion()" Text="Anular" OnClick="BtnAceptar_Click" />
                                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
                                    </div>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
    </asp:Panel>
<div class="SubTitulo">&nbsp;SOLICITUDES ANULADAS</div>
    <asp:GridView ID="GVListSolAnulados" runat="server" CssClass="TableBorder" AutoGenerateColumns="False"
        AllowPaging="True" PageSize="25" OnPageIndexChanging="GVListSolAnulados_PageIndexChanging"
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
            <asp:BoundField DataField="Descrip_Motivo" HeaderText="Motivo de anulación" />
            <asp:ButtonField CommandName="Solicitud" Text="Solicitud" Visible="False">
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
