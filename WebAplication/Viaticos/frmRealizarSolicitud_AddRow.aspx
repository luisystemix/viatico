<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRealizarSolicitud_AddRow.aspx.cs" Inherits="WebAplication.Viaticos.frmRealizarSolicitud_AddRow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../js/validar.js" type="text/ecmascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>    
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <link href="../Css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript">
          $(document).ready(function () {
              //debugger;
              $('#MainContent_TxtFecha').datepicker({
                  dateFormat: 'dd/mm/yy',
                  changeMonth: false,
                  changeYear: false,
                  nextText: 'Siguiente Mes',
                  prevText: 'Mes Anterior',
                  dayNames: ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'],
                  dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                  monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                  montNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic']
              });
          });

          function Confirmacion() {
              var seleccion = confirm("Está seguro de enviar la información registrada…?");
              return seleccion;
          }
  </script> 

    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
    <title>Solicitud Agregar Fila</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        FORMULARIO PARA ADICIONAR SOLICITUD
    </div>
    <table class="TableBorder" style="width: 100%">
        <tr>
            <td class="auto-style2">
                <asp:DropDownList ID="DDLTipSol" runat="server" Enabled="False">
                    <asp:ListItem>DESEMBOLSO</asp:ListItem>
                    <asp:ListItem>REEMBOLSO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style2"></td>
            <td width="90" class="auto-style2">Tipo de Salida:</td>
            <td width="150" class="auto-style2">
                <asp:DropDownList ID="DDLTipSalid" runat="server" OnSelectedIndexChanged="DDLTipSalid_SelectedIndexChanged">
                    <asp:ListItem Value="INTERIOR">INTERIOR DEL PAÍS</asp:ListItem>
                    <asp:ListItem Value="EXTERIOR">EXTERIOR DEL PAÍS</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="DDLTipViaje" runat="server">
                    <asp:ListItem Value="POA">PROGRAMADO EN EL POA</asp:ListItem>
                    <asp:ListItem Value="EMERGENCIA">DE EMERGENCIA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUser" runat="server" Visible="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="DDLDepart" runat="server" OnSelectedIndexChanged="DDLDepart_SelectedIndexChanged">
                    <asp:ListItem>LA PAZ</asp:ListItem>
                    <asp:ListItem>SANTA CRUZ</asp:ListItem>
                    <asp:ListItem>BENI</asp:ListItem>
                    <asp:ListItem>COCHABAMBA</asp:ListItem>
                    <asp:ListItem>TARIJA</asp:ListItem>
                    <asp:ListItem>POTOSI</asp:ListItem>
                    <asp:ListItem>CHUQUISACA</asp:ListItem>
                    <asp:ListItem>ORURO</asp:ListItem>
                    <asp:ListItem Value="YACUIBA">YACUIBA</asp:ListItem>
                    <asp:ListItem Value="4 CAÑADAS">4 CAÑADAS</asp:ListItem>
                    <asp:ListItem Value="SAN PEDRO">SAN PEDRO</asp:ListItem>
                    <asp:ListItem Value="MONTERO">MONTERO</asp:ListItem>
                    <asp:ListItem Value="YAPACANI">YAPACANI</asp:ListItem>
                    <asp:ListItem Value="CHAPARE">CHAPARE</asp:ListItem>
                    <asp:ListItem>PANDO</asp:ListItem>
                </asp:DropDownList>
                <asp:LinkButton ID="LnkPlanViaje" runat="server" onclick="LnkPlanViaje_Click"> Planificar viaje</asp:LinkButton>
                <asp:Button ID="BtnSalida" runat="server" onclick="BtnSalida_Click" Text="Salida &gt;&gt;" Visible="False" />
                <asp:Button ID="BtnRetorno" runat="server" Enabled="False" Text="Retorno &gt;&gt;" Visible="False" OnClick="BtnRetorno_Click" />
                <asp:Label ID="LblMsj1" runat="server" style="color: #CC0000; font-weight: 700"></asp:Label>
                    <asp:Label ID="LblAux" runat="server" Visible="False"></asp:Label>
            </td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdSolicitud" runat="server" Visible="true"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <div class="SubTitulo2">
            PLANIFICAR
            <asp:Label ID="LblTipo" runat="server"></asp:Label>
        </div>
        <table class="TableBorder"  style="width: 100%">
            <tr>
                <td width="80">&nbsp;</td>
                <td width="150">Saldre de&nbsp;
                    <asp:Label ID="LblOrigen" runat="server" style="font-weight: 700"></asp:Label>
                </td>
                <td colspan="2">en fecha:
                    <asp:TextBox ID="TxtFecha" runat="server" ValidationGroup="Formulario" Width="80px" OnTextChanged="TxtFecha_TextChanged" AutoPostBack="True"></asp:TextBox>
                    <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/reg.jpg" ToolTip="Agregar Fecha" OnClick="ImageButton1_Click" />--%>                   
                    a hrs:                    
                    <asp:DropDownList ID="DDLHora" runat="server">
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
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
                    </asp:DropDownList>&nbsp;
                    min:
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
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtFecha" ErrorMessage="Error Fecha" style="color: #CC0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
                    &nbsp;</td>
                <td>
                    <asp:DropDownList ID="DDLFeriados" runat="server" Width="400px" Visible="false">
                    </asp:DropDownList>
                </td>
                <td class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <%--<td><asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Visible="False" Width="200px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar></td>--%>
                <td></td>
                <td></td>
                <td></td>                
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Viaje:</td>
                <td width="150">
                    <asp:RadioButton ID="RDBUrbana" runat="server" AutoPostBack="True" Checked="True" GroupName="Zona" Text="Interdepartamental" OnCheckedChanged="RDBUrbana_CheckedChanged" Width="150px" />
                </td>
                <td width="200">
                    <asp:RadioButton ID="RDBRural" runat="server" AutoPostBack="True" GroupName="Zona" Text="Al interior del Departamento" OnCheckedChanged="RDBRural_CheckedChanged" Width="250px" />
                </td>
                <td>
                    <asp:Label ID="LblZona" runat="server" Visible="False">Interdepartamental</asp:Label>
                    <asp:RadioButton ID="RBExterior" runat="server" AutoPostBack="True" GroupName="Zona" OnCheckedChanged="RBExterior_CheckedChanged" Text="Al Exterior" Enabled="False" Visible="False" />
                </td>
                <td class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="LblTexto1" runat="server" Text="Destino:"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="DDLDestino" runat="server" OnSelectedIndexChanged="DDLDestino_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Label ID="LblTexto2" runat="server" Text="Lugar:" Visible="False"></asp:Label>
                    &nbsp;<asp:TextBox ID="TxtLugar" runat="server" Visible="False" onKeyUp="toUpper(this)" Width="230px"></asp:TextBox>
                </td>
                <td></td>
            </tr>
        </table>
        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <table class="TableBorder"  style="width: 100%">
                <tr>
                    <td width="80">&nbsp;</td>
                    <td width="150">Con el Objetivo de:</td>
                    <td width="300">
                        <asp:TextBox ID="TxtObjetiv" runat="server" Width="300px" onKeyUp="toUpper(this)"></asp:TextBox>
                    </td>
                    <td>(Campo NO obligatorio)</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <table class="TableBorder"  style="width: 100%">
            <tr>
                <td width="80">&nbsp;</td>
                <td width="150">Medio de transporte:</td>
                <td width="100">
                    <asp:RadioButton ID="RDBAereo" runat="server" AutoPostBack="True" Checked="True" GroupName="Transporte" Text="Aerea" OnCheckedChanged="RDBAereo_CheckedChanged" />
                </td>
                <td width="100">
                    <asp:RadioButton ID="RDBTerrestre" runat="server" AutoPostBack="True" GroupName="Transporte" Text="Terrestre" OnCheckedChanged="RDBTerrestre_CheckedChanged" />
                </td>
                <td width="60">
                    <asp:RadioButton ID="RDBOtros" runat="server" AutoPostBack="True" GroupName="Transporte" Text="Otros" OnCheckedChanged="RDBOtros_CheckedChanged" />
                </td>
                <td width="180">
                    <asp:Label ID="LblMedioTrans" runat="server" Visible="False">Aerea</asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Tipo de transporte:</td>
                <td>
                    <asp:RadioButton ID="RDBParticular" runat="server" AutoPostBack="True" Checked="True" GroupName="TipTransporte" Text="Particular" OnCheckedChanged="RDBParticular_CheckedChanged" />
                </td>
                <td>
                    <asp:RadioButton ID="RDBEmapa" runat="server" AutoPostBack="True" Enabled="False" GroupName="TipTransporte" Text="Emapa" OnCheckedChanged="RDBEmapa_CheckedChanged" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="LblTipoTrans" runat="server" Visible="False">Particular</asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="LblTexto3" runat="server" Text="Empresa de Transporte:" Width="200px"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TxtNomTransporte" runat="server" Width="200px" onKeyUp="toUpper(this)"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;</td>
                <td>
                    <asp:Label ID="LblTexto4" runat="server" Text="Placa:" Visible="False"></asp:Label>
                    &nbsp;&nbsp;<asp:TextBox ID="TxtIdentif" runat="server" Visible="False" Width="100px" onKeyUp="toUpper(this)"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="6">
                    <asp:Button ID="BTNRegisDestin" runat="server" Text="Registrar Destino &gt;&gt;" OnClick="BTNRegisDestin_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" Width="100%">
        <Columns>
            <asp:BoundField DataField="Tramo" HeaderText="Tramo" />
            <asp:BoundField DataField="Zona" HeaderText="Zona" />
            <asp:BoundField DataField="Destino" HeaderText="Destino" />
            <asp:BoundField DataField="Lugar" HeaderText="Lugar" />
            <asp:BoundField DataField="Objetivo" HeaderText="Objetivo" Visible="False" />
            <asp:BoundField DataField="Fecha_Salida" HeaderText="Fecha Salida" />
            <asp:BoundField DataField="Via_Transporte" HeaderText="Via" />
            <asp:BoundField DataField="Tipo_Transporte" HeaderText="Tipo" />
            <asp:BoundField DataField="Nombre_Transporte" HeaderText="Nombre" />
            <asp:BoundField DataField="Identificador_Trasporte" HeaderText="IdenTifi" />
            <asp:CommandField ShowDeleteButton="True" Visible="False" />
            <asp:BoundField DataField="Cont" HeaderText="">
            <ItemStyle ForeColor="#6600FF" Width="15px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:Panel ID="Panel3" runat="server" Enabled="False" Visible="False">
        <table class="TableBorder">
            <tr>
                <td width="150"> <asp:Label ID="lblMotivoGral_Viaje" runat="server" Text="Motivo general del viaje:" Visible="False"></asp:Label></td>
                <td rowspan="2">
                    <asp:TextBox ID="TxtMotiv" runat="server" Width="600px" onKeyUp="toUpper(this)" TextMode="MultiLine" Visible="False"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" class="auto-style1">
                    <asp:Button ID="BtnGuardar" runat="server" OnClientClick ="return Confirmacion()" Text="Guardar Solicitud" OnClick="BtnGuardar_Click" />
                    <asp:Button ID="BtnCancel" runat="server" Text="Cancelar" OnClick="BtnCancel_Click" Visible="False" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

