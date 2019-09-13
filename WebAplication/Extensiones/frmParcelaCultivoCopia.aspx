<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmParcelaCultivoCopia.aspx.cs" Inherits="WebAplication.Extensiones.frmParcelaCultivoCopia" %>
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
            if (charCode < 48 || charCode > 57) {
                alert("Por favor teclee solo números en este campo!");
                return false
            }
            else {
                return true
            }
        }

        function Confirmacion() {
            var seleccion = confirm("Está seguro de enviar la información registrada…?");
            return seleccion;
        }

</script>
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
    <div class="SubTitulo2">DATOS DEL PRODUCTOR</div>
            <table class="TableBorder">
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
                    <asp:ListItem Value="1">Por Monitoreo</asp:ListItem>
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
    <div class="SubTitulo2">
        DATOS DEL SEGUIMIENTO TÉCNICO</div>
        <table class="TableBorder">
        <tr>
            <td width="100">&nbsp;</td>
            <td width="155"><div style="text-align: right">
                <asp:Label ID="LblNumBoleta" runat="server" Text="N° Boleta de Inspección:"></asp:Label>
                </div></td>
            <td width="80">
                <asp:TextBox ID="TxtNumBoleta" onKeyPress='return esInteger(event)' runat="server" onblur="javascript:ValidarTextBox();" Width="50px" style="background-color: #FFFFCC; text-align: center;"></asp:TextBox>
            </td>
            <td colspan="2">
                <div style="text-align: right">Etapa:</div></td>
            <td width="120">
                <asp:Label ID="LblEtapa" runat="server"></asp:Label>
                    </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><div style="text-align: right"> Fecha Inspección:</div></td>
            <td>
                <asp:TextBox ID="TxtFecha" onkeyUp="return validaFechaDDMMAAAA(this);" CssClass="myDatePickerClass1" runat="server"  ValidationGroup="Formulario" Width="70px"></asp:TextBox>
            </td>
            <td width="30">&nbsp;</td>
            <td>
                   <div style="text-align: left"> &nbsp; <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtFecha" ErrorMessage="Error en Formato de Fecha" style="color: #CC0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
                   </div>
            </td>
            <td>
                    <asp:Label ID="LblEstado" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                   &nbsp;</td>
            <td colspan="5">
                   <div style="text-align: center"><asp:Label ID="LblMsj1" runat="server" style="color: #CC0000; font-weight: 700;"></asp:Label></div>
            </td>
        </tr>
        </table>
        <div class="SubTitulo2">
            Datos del Cultivo:</div>
        <table class="TableBorder">
            <tr>
                <td width="100">&nbsp;</td>
                <td width="110">Fase Fenologica:</td>
                <td width="200">
                    <asp:DropDownList ID="DDLFenologia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLFenologia_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td width="35">
                    <div style="text-align: right">
                        <asp:Label ID="LblFechaFase" runat="server" Text="Fecha: "></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:DropDownList ID="DDLEstadoFF" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLEstadoFF_SelectedIndexChanged">
                        <asp:ListItem>Avance</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtFechaFase" runat="server" CssClass="myDatePickerClass1" Visible="False" Width="70px"></asp:TextBox>
                    <asp:TextBox ID="TxtPorcentaje" runat="server" AutoPostBack="True" onKeyPress="return esInteger(event)" OnTextChanged="TxtPorcentaje_TextChanged" Width="30px"></asp:TextBox>
                    <asp:Label ID="LblValor1" runat="server" Text="%"></asp:Label>
                    &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TxtPorcentaje" ErrorMessage="ERROR el rango es de 0 a 100 " MaximumValue="100" MinimumValue="0" style="color: #CC0000; font-weight: 700" Type="Integer"></asp:RangeValidator>
                </td>
                <td>
                    <div style="text-align: right">
                        Inspeccion Anterior:</div>
                </td>
                <td>
                    <asp:Label ID="LblPorcentaje" runat="server" style="font-weight: 700">0</asp:Label>
                </td>
                <td>%</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>N° de Seguimiento:</td>
                <td>
                    <asp:Label ID="LblNumSegCult" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td colspan="2">
                    <div style="text-align: right">
                        Avance de siembra actual:</div>
                </td>
                <td>
                    <asp:Label ID="LblAvanSiem" runat="server">0</asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblCont" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            </table>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <table class="TableBorder">
                <tr>
                    <td width="100">&nbsp;</td>
                    <td width="110">Rendimeinto (t/ha):</td>
                    <td width="100">
                        <asp:TextBox ID="TxtRedimiento" runat="server" Width="30px" Enabled="False"></asp:TextBox>
                    </td>
                    <td width="140">Superficie Sembrada (ha):</td>
                    <td>
                        <asp:TextBox ID="TxtSupSiem" runat="server" Width="30px" Enabled="False"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Peso Aproximado(t)</td>
                    <td>
                        <asp:TextBox ID="TxtPesoApro" runat="server" Width="60px" Enabled="False"></asp:TextBox>
                    </td>
                    <td>Fecha de siembra:</td>
                    <td>
                        <asp:TextBox ID="TxtFechSiem" onkeyUp="return validaFechaDDMMAAAA(this);" CssClass="myDatePickerClass1" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td>Placa Camion</td>
                    <td>
                        <asp:TextBox ID="TxtPlacaCam" runat="server" Width="60px"></asp:TextBox>
                    </td>
                    <td>Nombre Chofer:</td>
                    <td>
                        <asp:TextBox ID="TxtNomChofer" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Centro de Acopio:</td>
                    <td>
                        <asp:TextBox ID="TxtCentroAco" runat="server" Width="100px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
    </asp:Panel>
        <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar &gt;&gt;" OnClick="BtnRegistrar_Click" />
        <asp:GridView ID="GVSegCultivo" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVSegCultivo_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id_Fenologia" HeaderText="Id_Fenologia" />
                <asp:BoundField DataField="FaceFenologica" HeaderText="Fase Fenologica" />
                <asp:BoundField DataField="EstadoFF" HeaderText="Estado de Fase" />
                <asp:BoundField DataField="Porcentaje" HeaderText="%" />
                <asp:BoundField DataField="Fecha_Cosecha" HeaderText="Fecha Cosecha" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" Visible="False" />
                <asp:BoundField DataField="Estado" HeaderText="Nombre" Visible="False" />
                <asp:BoundField DataField="Intencidad" HeaderText="Intencidad" Visible="False" />
                <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" Visible="False" />
                <asp:ButtonField ButtonType="Image" CommandName="Eliminar" ImageUrl="~/images/img-0.png" Text="Button">
                <ItemStyle Width="20px" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td width="150">&nbsp;</td>
                <td>
                    <div style="text-align: center; font-weight: 700">
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
                                <td class="auto-style9" width="130">Adversidad presentada:</td>
                                <td class="auto-style9" width="210">
                                    <asp:DropDownList ID="DDLAdversidad" runat="server" AutoPostBack="True">
                                        <asp:ListItem>MALEZA </asp:ListItem>
                                        <asp:ListItem>PLAGA</asp:ListItem>
                                        <asp:ListItem>ENFERMEDAD</asp:ListItem>
                                        <asp:ListItem>SEQUIA</asp:ListItem>
                                        <asp:ListItem>INUNDACIÓN</asp:ListItem>
                                        <asp:ListItem>HELADA</asp:ListItem>
                                        <asp:ListItem>GRANIZADA</asp:ListItem>
                                        <asp:ListItem>MAZAMORRA</asp:ListItem>
                                        <asp:ListItem>NEVADA</asp:ListItem>
                                        <asp:ListItem>OTRO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style9" width="65">&nbsp;</td>
                                <td class="auto-style9">
                                    <div style="text-align: center"><asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="TxtIntencidad" ErrorMessage="ERROR el rango es de 0 a 100 " MaximumValue="100" MinimumValue="0" style="color: #CC0000; font-weight: 700" Type="Integer"></asp:RangeValidator></div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">
                                    <div style="text-align: left">
                                        <asp:Label ID="LblNomAdve0" runat="server" Text="Nombre o Descripción:"></asp:Label>
                                    </div>
                                </td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="TxtDescripAdversidad" runat="server" onKeyUp="toUpper(this)" Width="200px"></asp:TextBox>
                                </td>
                                <td class="auto-style9">Intencidad:</td>
                                <td class="auto-style9">
                                    <asp:DropDownList ID="DDLIntensidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLIntensidad_SelectedIndexChanged">
                                        <asp:ListItem Value="0">AUSENTE</asp:ListItem>
                                        <asp:ListItem Value="1">LEVE</asp:ListItem>
                                        <asp:ListItem Value="2">MODERADO</asp:ListItem>
                                        <asp:ListItem Value="3">INTENSO</asp:ListItem>
                                        <asp:ListItem Value="4">MUY INTENSO</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="TxtIntencidad" runat="server" onKeyPress="return esInteger(event)" Width="30px">0</asp:TextBox>
                                    <asp:Label ID="LblIntencidad" runat="server" style="font-weight: 700" Text="(0)%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Tratamiento a aplicar:</td>
                                <td class="auto-style9" colspan="3">
                                    <asp:TextBox ID="TxtTratamiento" runat="server" Width="250px"></asp:TextBox>
                                    <asp:Button ID="BtnInsertAdversidad" runat="server" OnClick="BtnInsertAdversidad_Click" Text="Agregar Adversidad &gt;&gt;" />
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="GVAdversidad" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
                            <Columns>
                                <asp:BoundField DataField="Adversidad" HeaderText="Adversidad" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción o Nombre" />
                                <asp:BoundField DataField="Intencidad" HeaderText="Intensidad" />
                                <asp:BoundField DataField="Porcentaje" HeaderText="%" />
                                <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento a Aplicar" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div style="text-align: center"><asp:Label ID="LblMsj5" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
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
