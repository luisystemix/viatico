<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmModificarSolicitud.aspx.cs" Inherits="WebAplication.Viaticos.frmModificarSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.24.custom.min.js"></script>
    <link href="../css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" />

    <script type="text/javascript">
        $(function () {
            var $gv = $("table[id$=GVActividades]");
            var $rows = $("> tbody > tr:not(:has(th, table))", $gv);
            var $inputs = $(".myDatePickerClass");

            //$rows.css("background-color", "yellow");

            $inputs.datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: false,
                changeYear: false,
                nextText: 'Siguiente Mes',
                prevText: 'Mes Anterior',
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                montNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic']
            }
                );
        });
        $(document).ready(function () {
            $('.solo-numero').keyup(function () {
                this.value = (this.value + '').replace(/[^0-9]/g, '');
            });
        });
        if (history.forward(1)) {
            location.replace(history.forward(1));
        }
</script>


   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        FORMULARIO PARA MODIFICAR LA SOLICITUD DE VIAJE</div>
    <table class="TableBorder">
        <tr>
            <td width="60">&nbsp;</td>
            <td width="110">&nbsp;</td>
            <td>
                <asp:Label ID="LblEstado" runat="server"></asp:Label>
            </td>
            <td width="85">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Codigo Solicitud:</td>
            <td><asp:Label ID="LblIdSolicitud" runat="server"></asp:Label>
            </td>
            <td>Fecha Enviado: </td>
            <td>
                <asp:Label ID="LblFechaEnvio" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Tipo:</td>
            <td>
                <asp:DropDownList ID="DDLTipViaje" runat="server">
                    <asp:ListItem Value="POA">PROGRAMADO EN EL POA</asp:ListItem>
                    <asp:ListItem Value="EMERGENCIA">DE EMERGENCIA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Motivo del Viaje:</td>
            <td rowspan="2">
                    <asp:TextBox ID="TxtMotiv" runat="server" Width="600px" TextMode="MultiLine"></asp:TextBox>
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
    <asp:GridView ID="GVSolicitud" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" 
        OnRowDataBound="GVSolicitud_RowDataBound" DataKeyNames="Cont" 
        OnRowCommand="GVSolicitud_RowCommand" 
        OnRowDeleting="GVSolicitud_RowDeleting">
        <Columns>

            <asp:TemplateField HeaderText="N°" ItemStyle-Width="20px" >
                <ItemTemplate>
            <span>
         <%#Container.DataItemIndex + 1%>
            </span>
                </ItemTemplate>
         </asp:TemplateField>

           <asp:BoundField DataField="Cont" HeaderText="N°" Visible="false">
            <ItemStyle Width="20px" />
            </asp:BoundField>
            <asp:BoundField DataField="Tramo" HeaderText="Tramo" />
            <asp:TemplateField HeaderText="Zona">
                <ItemTemplate>
                    <asp:DropDownList ID="DDLZona" runat="server">
                        <asp:ListItem>Interdepartamental</asp:ListItem>
                        <asp:ListItem>Al interior del Departamento</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Destino">
                <ItemTemplate>
                    <asp:DropDownList ID="DDLDestino" runat="server">
                        <asp:ListItem Value="LA PAZ">LA PAZ</asp:ListItem>
                        <asp:ListItem Value="SANTA CRUZ">SANTA CRUZ</asp:ListItem>
                        <asp:ListItem Value="COCHABAMBA">COCHABAMBA</asp:ListItem>
                        <asp:ListItem Value="BENI">BENI</asp:ListItem>
                        <asp:ListItem Value="TARIJA">TARIJA</asp:ListItem>
                        <asp:ListItem Value="POTOSI">POTOSI</asp:ListItem>
                        <asp:ListItem Value="CHUQUISACA">CHUQUISACA</asp:ListItem>
                        <asp:ListItem Value="ORURO">ORURO</asp:ListItem>
                        <asp:ListItem Value="PANDO">PANDO</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Lugar">
                <ItemTemplate>
                    <asp:TextBox ID="TxtMotivo" runat="server" Width="100px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Objetivo" Visible="False">
                <ItemTemplate>
                    <asp:TextBox ID="TxtObjetivo" runat="server" Width="97%"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="100%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha">
                <ItemTemplate>
                    <asp:TextBox ID="TxtFecha" runat="server" CssClass="myDatePickerClass" Width="70px" AutoPostBack="True" OnTextChanged="TxtFecha_TextChanged"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hra">
                <ItemTemplate>
                    <asp:DropDownList ID="DDLHora" runat="server">
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="35px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Min">
                <ItemTemplate>
                    <asp:DropDownList ID="DDLMinuto" runat="server">
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="35px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Via Trans">
                <ItemTemplate>
                    <asp:DropDownList ID="DDLViaTrans" runat="server">
                        <asp:ListItem>Aerea</asp:ListItem>
                        <asp:ListItem>Terrestre</asp:ListItem>
                        <asp:ListItem>Otros</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo Trans">
                <ItemTemplate>
                    <asp:DropDownList ID="DDLTipoTrans" runat="server">
                        <asp:ListItem>Particular</asp:ListItem>
                        <asp:ListItem>Emapa</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NomTrans">
                <ItemTemplate>
                    <asp:TextBox ID="TxtNomTrans" runat="server" Width="110px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="110px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Identificador">
                <ItemTemplate>
                    <asp:TextBox ID="TxtIdentifi" runat="server" Width="80px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
        <%--   <asp:ButtonField CommandName="Delete" Text="Eliminar" >
            <ItemStyle Width="52px" />
            </asp:ButtonField>--%>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkEliminar" CommandName="Delete" Text="Eliminar" CommandArgument='<%# Container.DataItemIndex %>'> </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnModificar" runat="server" OnClick="BtnModificar_Click" Text="Modificar" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" Visible="False" />
    <asp:Button ID="BtnNuevaFila" runat="server" Text="Agregar" OnClick="BtnNuevaFila_Click" />
</asp:Content>
