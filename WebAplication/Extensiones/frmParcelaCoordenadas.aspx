﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmParcelaCoordenadas.aspx.cs" Inherits="WebAplication.Extensiones.frmParcelaCoordenadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../js/validar.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <link href="../css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" />
    <script src="../AcopioSilos/jquery.cleditor.js" type="text/javascript"></script>
    <link href="../AcopioSilos/jquery.cleditor.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            var $inputs = $(".myDatePickerClass");
            $inputs.cleditor({
                width: "100%", // width not including margins, borders or padding
                height: "80", // height not including margins, borders or padding
                controls:     // controls to add to the toolbar
                "bold italic underline strikethrough subscript superscript | font size " +
                "style | color highlight removeformat | bullets numbering | outdent " +
                "indent | alignleft center alignright justify | undo redo | " +
                "rule image link unlink",
            });
            //debugger;
            var $inputs1 = $(".myDatePickerClass1");
            $inputs1.datepicker({
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

        function esInteger(e) {
            var charCode
            if (navigator.appName == "Netscape") {
                charCode = e.which
            }
            else {
                charCode = e.keyCode
            }
            if (charCode == 8)
            { } else
            {
                if ((charCode < 47) || (charCode > 58)) {
                    alert("Por favor teclee solo números en este campo!");
                    return false
                }
                else {
                    return true
                }
            }
        }

        function Confirmacion() {
            var seleccion = confirm("Está seguro de enviar la información registrada…?");
            return seleccion;
        }

</script>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        SEGUIMIENTO Y CONTROL DE LA PARCELA</div>
    <table class="TableBorder">
        <tr>
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
            </td>
            <td></td>
            <td></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div class="SubTitulo2">DATOS DEL PRODUCTOR</div><table class="TableBorder">
        <tr>
            <td width="125">Nombre del Agricultor:</td>
            <td>
                <asp:Label ID="LblProductor" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsProd" runat="server"></asp:Label>
            </td>
            <td width="60">Superficie:</td>
            <td>
                <asp:Label ID="LblSup" runat="server"></asp:Label>
            </td>
            <td width="55">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="80">
                &nbsp;</td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Comunidad:</td>
            <td>
                <asp:Label ID="LblComunidad" runat="server"></asp:Label>
            </td>
            <td>Municipio:</td>
            <td>
                <asp:Label ID="LblMunicipio" runat="server"></asp:Label>
            </td>
            <td>
                Provincia:</td>
            <td>
                <asp:Label ID="LblProvincia" runat="server"></asp:Label>
            </td>
            <td>
                Departamento:</td>
            <td>
                <asp:Label ID="LblDepart" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Tipo de inspección:</td>
            <td>
                <asp:DropDownList ID="DDLTipoSeg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoSeg_SelectedIndexChanged" CssClass="textoFondoDer">
                    <asp:ListItem Value="0">En Campo</asp:ListItem>
                    <asp:ListItem Value="1">Sin Boleta</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
    <div class="SubTitulo2">DATOS DEL SEGUIMIENTO TÉCNICO REALIZADO</div><table class="TableBorder">
        <tr>
            <td width="50">&nbsp;</td>
            <td><div style="text-align: right">Etapa:</div></td>
            <td colspan ="5"><asp:Label ID="LblEtapa" runat="server" Font-Bold="True"></asp:Label></td>
            <td>&nbsp;</td>            
            <td><asp:Label ID="LblId_Etapa" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td width="50" class="auto-style1"></td>
            
            <td width="155" class="auto-style1"><div style="text-align: right">                
                <asp:Label ID="LblNumBoleta" runat="server" Text="N° Boleta de Inspección:"></asp:Label>
                </div></td>
            <td width="80" class="auto-style1">
                <asp:TextBox ID="TxtNumBoleta" onKeyPress='return esInteger(event)' runat="server" onblur="javascript:ValidarTextBox();" Width="50px" style="background-color: #FFFFCC; text-align: center;"></asp:TextBox>
            </td>
            <td colspan="5" class="auto-style1">
                </td>
            <td width="120" class="auto-style1">               
                
                    </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td width="155"><div style="text-align: right"> Fecha Inspección:</div></td>
            <td>
                <asp:TextBox ID="TxtFecha" onkeyUp="return validaFechaDDMMAAAA(this);" CssClass="myDatePickerClass1" runat="server"  ValidationGroup="Formulario" Width="70px"></asp:TextBox>
            </td>
            <%--<td width="30">&nbsp;Hora:</td>
            <td width="45">
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
                </td>
            <td width="30">
                    Min:</td>
            <td width="45">
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
                    </td>--%>
            <td>
                   <div style="text-align: left"> (Dato no obligatorio)&nbsp; <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtFecha" ErrorMessage="Error Formato de Fecha" style="color: #CC0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
                   </div>
            </td>
            <td>
                    <asp:Label ID="LblEstado" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                   &nbsp;</td>
            <td colspan="8">
                   <div style="text-align: center"><asp:Label ID="LblMsj1" runat="server" style="color: #CC0000; font-weight: 700;"></asp:Label></div>
            </td>
        </tr>
        </table>
    <asp:Panel ID="PnlDatsCoord" runat="server">
        <div class="SubTitulo2">
            Coordenadas de Verificacion: </div>
        <table class="TableBorder">
            <tr>
                <td width="60"></td>
                <td width="50">Parcela:</td>
                <td width="40">
                    <asp:DropDownList ID="DDLNumParcela" runat="server" Width="40px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td width="120">Coordenada X</td>
                <td width="80">
                    <asp:TextBox ID="TxtCoordX" onKeyPress='return esInteger(event)' runat="server" Width="70px"></asp:TextBox>
                </td>
                <td width="80">
                    <asp:Button ID="BtnInsertar" runat="server" OnClick="BtnInsertar_Click" Text="Agregar Punto &gt;&gt;" />
                </td>
                <td>
                    &nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td width="60">&nbsp;</td>
                <td width="50">&nbsp;</td>
                <td width="40">&nbsp;</td>
                <td width="120">Coordenada Y</td>
                <td width="80">
                    <asp:TextBox ID="TxtCoordY" runat="server" onKeyPress="return esInteger(event)" Width="70px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td width="60" class="auto-style1"></td>
                <td width="50" class="auto-style1"></td>
                <td width="40" class="auto-style1"></td>
                <td width="120" class="auto-style1">Registrar Punto</td>
                <td width="80" class="auto-style1">
                    <asp:TextBox ID="txtPunto" runat="server" onKeyPress="return esInteger(event)" Width="70px"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td colspan="4">
                    <div>
                    <asp:GridView ID="GVCoord" runat="server" AutoGenerateColumns="False" OnRowCommand="GVCoord_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Num_Parcela" HeaderText="N° Parcela" />
                            <asp:BoundField DataField="Num_Punto" HeaderText="N° Punto" />
                            <asp:BoundField DataField="CoordX" HeaderText="Coordena &quot;X&quot;" />
                            <asp:BoundField DataField="CoordY" HeaderText="Coordenada &quot;Y&quot;" />
                            <asp:ButtonField ButtonType="Image" ImageUrl="~/images/img-0.png" Text="Button" />
                        </Columns>
                    </asp:GridView>
                    </div>
                </td>
                <td>NOTA: Solamente registre un punto de referencia por cada parcela declarada, para su verificación.</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div style="text-align: center"><asp:Label ID="LblMsj2" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
    </asp:Panel>
    <table class="TableBorder">
            <tr>
                <td width="150">&nbsp;</td>
                <td>
                    <div style="font-weight: 700">
                        Adversidad Presentada:
                        <asp:RadioButton ID="RdbAdeversidadSI" runat="server" AutoPostBack="True" GroupName="Adversidad" OnCheckedChanged="RdbAdeversidadSI_CheckedChanged" Text="SI" />
                        <asp:RadioButton ID="RdbAdeversidadNO" runat="server" AutoPostBack="True" Checked="True" GroupName="Adversidad" OnCheckedChanged="RdbAdeversidadNO_CheckedChanged" Text="NO" />
                    </div>
                </td>
                <td width="150">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;</td>
                <td>
                    <asp:Panel ID="PnlAdversidad" runat="server" Visible="False">
                        <table class="TableBorder">
                            <tr>
                                <td class="auto-style9" width="150">Evento Agroclimatico Adverso:</td>
                                <td class="auto-style9" width="210">
                                    <asp:DropDownList ID="DDLAdversidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLAdversidad_SelectedIndexChanged">
                                        <asp:ListItem>SEQUIA</asp:ListItem>
                                        <asp:ListItem>HELADA</asp:ListItem>
                                        <asp:ListItem>INUNDACIÓN</asp:ListItem>
                                        <asp:ListItem>GRANIZADA</asp:ListItem>
                                        <asp:ListItem>NEVADA</asp:ListItem>
                                        <asp:ListItem>MAZAMORRA</asp:ListItem>
                                        <asp:ListItem>VIENTO FUERTE</asp:ListItem>
                                        <asp:ListItem>TEMPERATURAS BAJAS</asp:ListItem>
                                        <asp:ListItem>TEMPERATURAS ALTAS</asp:ListItem>
                                        <asp:ListItem>OTRO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style9" width="65">&nbsp;</td>
                                <td class="auto-style9">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style9">
                                    Intensidad:</td>
                                <td class="auto-style9">
                                    <asp:DropDownList ID="DDLIntensidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLIntensidad_SelectedIndexChanged">
                                        <asp:ListItem Value="1">LEVE</asp:ListItem>
                                        <asp:ListItem Value="2">MODERADO</asp:ListItem>
                                        <asp:ListItem Value="3">FUERTE</asp:ListItem>
                                        <asp:ListItem Value="4">MUY FUERTE</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="TxtIntencidad" runat="server" onKeyPress="return esInteger(event)" Width="30px">0</asp:TextBox>
                                </td>
                                <td class="auto-style9">
                                    <asp:Label ID="LblIntencidad" runat="server" style="font-weight: 700" Text="(0)%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Fecha Ocurrencia:</td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txt_fecha_adversidad" runat="server" Width="100px" Enabled="False"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/reg.jpg" OnClick="ImageButton1_Click" ToolTip="Agregar Fecha" />
                                    
                                </td>
                                <td class="auto-style9" colspan="2">
                                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False" Width="200px">
                                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                        <NextPrevStyle VerticalAlign="Bottom" />
                                        <OtherMonthDayStyle ForeColor="#808080" />
                                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                        <SelectorStyle BackColor="#CCCCCC" />
                                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <WeekendDayStyle BackColor="#FFFFCC" />
                                    </asp:Calendar>
                                </td>
                                <td class="auto-style9">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Observación y/o Recomendación:</td>
                                <td class="auto-style9" colspan="3">
                                    <asp:TextBox ID="txt_Observacion" runat="server" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">&nbsp;</td>
                                <td class="auto-style9" colspan="3">
                                    <asp:Button ID="BtnInsertAdversidad" runat="server" OnClick="BtnInsertAdversidad_Click" Text="Agregar Adversidad &gt;&gt;" Height="20px" />
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="GVAdversidad" runat="server" AutoGenerateColumns="False" OnRowDataBound="GVAdversidad_RowDataBound" OnRowDeleting="GVAdversidad_RowDeleting">
                            <Columns>                                
                                <asp:BoundField DataField="Adversidad" HeaderText="Evento Adverso" />                                
                                <asp:BoundField DataField="Intensidad" HeaderText="Intensidad" />
                                <asp:BoundField DataField="Porcentaje" HeaderText="%" />
                                <asp:BoundField DataField="Fecha_Ocurrencia" HeaderText="Fecha Ocurrencia" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Observación y/o Recomendación" />
                                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <div style="text-align: center; font-weight: 700">
                    <table>
                        <tr>
                            <td>Plaga-Maleza-Enfermedad:                   <td>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" style="font-weight: 700" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem>SI</asp:ListItem>
                                <asp:ListItem Selected="True">NO</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table> 
                    </div>
                    <asp:Panel ID="pnlPlaga" runat="server" Visible="False">
                        <table class="TableBorder">
                            <tr>
                                <td class="auto-style9" width="130">Plagas:</td>
                                <td class="auto-style9" width="210">
                                    <asp:TextBox ID="txt_Plagas" runat="server"></asp:TextBox>
                                </td>
                                <td class="auto-style9" width="65">Intensidad:</td>
                                <td class="auto-style9">
                                    <asp:DropDownList ID="DDLIntensidad_Plaga" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLIntensidad_Plaga_SelectedIndexChanged">
                                        <asp:ListItem>AUSENTE</asp:ListItem>
                                        <asp:ListItem Value="1">LEVE</asp:ListItem>
                                        <asp:ListItem Value="2">MODERADO</asp:ListItem>
                                        <asp:ListItem Value="3">FUERTE</asp:ListItem>
                                        <asp:ListItem Value="4">MUY FUERTE</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Tratamiento:</td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txt_Tratamiento_Plagas" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td class="auto-style9">&nbsp;</td>
                                <td class="auto-style9">
                                    <asp:Button ID="BtnAgregarPlaga" runat="server" OnClick="BtnAgregarPlaga_Click" Text="Agregar_Plaga" Height="20px" Width="130px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Malezas:</td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txt_Malezas" runat="server"></asp:TextBox>
                                </td>
                                <td class="auto-style9">Intensidad:</td>
                                <td class="auto-style9">
                                    <asp:DropDownList ID="DDLIntensidad_Maleza" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLIntensidad_Maleza_SelectedIndexChanged">
                                        <asp:ListItem>AUSENTE</asp:ListItem>
                                        <asp:ListItem Value="1">LEVE</asp:ListItem>
                                        <asp:ListItem Value="2">MODERADO</asp:ListItem>
                                        <asp:ListItem Value="3">FUERTE</asp:ListItem>
                                        <asp:ListItem Value="4">MUY FUERTE</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Tratamiento:</td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txt_Tratamiento_Malezas" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td class="auto-style9">&nbsp;</td>
                                <td class="auto-style9">
                                    <asp:Button ID="BtnInsert_Malezas" runat="server" OnClick="BtnInsert_Malezas_Click" Text="Agregar_Maleza" Height="20px" Width="130px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Enfermedades;:</td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txt_Enfermedades" runat="server"></asp:TextBox>
                                </td>
                                <td class="auto-style9">Intensidad:</td>
                                <td class="auto-style9">
                                    <asp:DropDownList ID="DDLIntensidad_Enfermedad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLIntensidad_Enfermedad_SelectedIndexChanged">
                                        <asp:ListItem>AUSENTE</asp:ListItem>
                                        <asp:ListItem Value="1">LEVE</asp:ListItem>
                                        <asp:ListItem Value="2">MODERADO</asp:ListItem>
                                        <asp:ListItem Value="3">FUERTE</asp:ListItem>
                                        <asp:ListItem Value="4">MUY FUERTE</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Tratamiento:</td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="txt_Tratamiento_Enfermedades" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td class="auto-style9">&nbsp;</td>
                                <td class="auto-style9">
                                    <asp:Button ID="BtnInsert_Enfermedad" runat="server" OnClick="BtnInsert_Enfermedad_Click" Text="Agregar_Enfermedad" Height="20px" Width="130px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">&nbsp;</td>
                                <td class="auto-style9" colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style9" colspan="4">
                                    <asp:GridView ID="GV_PlagaMaEnf" runat="server" AutoGenerateColumns="False" OnRowDataBound="GV_PlagaMaEnf_RowDataBound" OnRowDeleting="GV_PlagaMaEnf_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="PME" HeaderText="" />
                                            <asp:BoundField DataField="Detalle" HeaderText="Detalle" />
                                            <asp:BoundField DataField="Intensidad" HeaderText="Intensidad" />
                                            <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" />
                                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                        &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <asp:Panel ID="PnlOBsRec" runat="server" Visible="False">
        <table class="TableBorder">
            <tr>
                <td>
                    <div class="SubTitulo2">
                        Observaciones:</div>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TxtObser" runat="server" CssClass="cleditorToolbar"  TextMode="MultiLine" Height="50px" Width="99.5%"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table class="TableBorder">
            <tr>
                <td>
                    <div class="SubTitulo2">
                        Recomendaciones:</div>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TxtRecomen" runat="server" CssClass="cleditorToolbar" TextMode="MultiLine" Height="50px" Width="99.5%"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div style="text-align: center"><asp:Button ID="BtnEnviar" runat="server" OnClientClick ="return Confirmacion()" Text="Enviar Seguimiento" OnClick="BtnEnviar_Click" Enabled="False" />
        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" /></div>
    </asp:Panel>
</asp:Content>
