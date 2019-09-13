<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmParcelaModificar.aspx.cs" Inherits="WebAplication.Extensiones.frmParcelaModificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../js/validar.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <link href="../css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" />
    <script src="../AcopioSilos/jquery.cleditor.js" type="text/javascript"></script>
    <%--<link href="../AcopioSilos/jquery.cleditor.css" rel="stylesheet" />--%>
<%--<link href="../css/EmapaStyele.css" rel="stylesheet" />--%>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            height: 19px;
        }
    </style>
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

        function onKeyDecimal(e, thix) {
            var keynum = window.event ? window.event.keyCode : e.which;
            if (document.getElementById(thix.id).value.indexOf('.') != -1 && keynum == 46)
                return false;
            if ((keynum == 8 || keynum == 48 || keynum == 46))
                return true;
            if (keynum <= 47 || keynum >= 58) return false;
            return /\d/.test(String.fromCharCode(keynum));
        }
        
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="TableBorder">
        <tr>
            <td width="115">&nbsp;</td>
            <td>
                &nbsp;
                </td>
            <td width="70">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="55">&nbsp;</td>
            <td>&nbsp;</td>
            <td width="80">
                Codigo Seg.</td>
            <td>
                <asp:Label ID="LblNum" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Nombre del agricultor:</td>
            <td>
                <asp:Label ID="LblProductor" runat="server"></asp:Label>
                    , CI:
                    <asp:Label ID="LblCedula" runat="server"></asp:Label>
            </td>
            <td>Organización:</td>
            <td>
                <asp:Label ID="LblOrg" runat="server"></asp:Label>
            </td>
            <td><asp:Label ID="Label1" runat="server" Text="Id_Productor: "></asp:Label></td>
            <td><asp:Label ID="lblId_Productor" runat="server" Text="Id_Productor" Font-Bold="True"></asp:Label></td>
            <td></td>
            <td>&nbsp;</td>
            <td></td>
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
            <td>Provincia:</td>
            <td>
                <asp:Label ID="LblProvincia" runat="server"></asp:Label>
            </td>
            <td>Departamento:</td>
            <td>
                <asp:Label ID="LblDep" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Nombre del Tecnico:</td>
            <td>
                <asp:Label ID="LblTecnico" runat="server"></asp:Label>
                <asp:Label ID="LblIdUser" runat="server" Visible="False"></asp:Label>
            </td>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblPrograma" runat="server"></asp:Label>
            </td>
            <td>Campaña:</td>
            <td>
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Regional:</td>
            <td class="auto-style2">
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
            </td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"><asp:Label ID="lblId_Fenologia" runat="server" Width="50px" Enabled="False"></asp:Label></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td colspan="5"><asp:Label ID="LblEtapa" runat="server"></asp:Label></td>            
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
           
        </tr>
    </table>
    
        <table class="TableBorder">
            <tr>
                <td width="60">N° Boleta:</td>
                <td width="80">
                    <asp:TextBox ID="TxtnumBol" runat="server" Width="60px" Enabled="False"></asp:TextBox>
                </td>
                <td width="50">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Fecha Seg.:</td>
                <td>
                <asp:Label ID="LblFechaSeg" runat="server"></asp:Label>
                </td>
                <td> Hora:</td>
                <td>
                <asp:Label ID="LblHoraSeg" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1">
                    <asp:Label ID="LblIdSegParcela" runat="server"></asp:Label>
                </td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td align="right" class="auto-style1">
                    <asp:Button ID="btn_AddCoordenada" runat="server" Text="Nueva_Coordenada" OnClick="btn_AddCoordenada_Click" Visible="False" /></td>
            </tr>
    </table>
    
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <div class="SubTitulo2">
                Coordenadas de Verificacion:</div>
            <asp:GridView ID="GVCoordenadas" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVCoordenadas_RowDataBound" OnRowCommand="GVCoordenadas_RowCommand" OnRowDeleting="GVCoordenadas_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="CoordX">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtCoordX" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CoordY">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtCoordY" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Num_Parcela">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtNum_Parcela" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id_Productor" HeaderText="Id_Productor" />
                    <asp:TemplateField HeaderText="Num_Punto">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtNum_Punto" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" DeleteText="Eliminar">
                     <ControlStyle BackColor="White" BorderColor="White" BorderStyle="Solid" Font-Underline="True" ForeColor="Blue" />
                    </asp:CommandField>
                     <%--<asp:ButtonField Text="Eliminar" CommandName="Delete" Visible="True"  >
                        <ItemStyle Width="40px" />
                    </asp:ButtonField>--%>
                </Columns>
            </asp:GridView>
            <table class="TableBorder">
                <tr>
                    <td width="50">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td width="100">Observación:</td>
                    <td rowspan="2">                        
                        <asp:TextBox ID="txtObservacionCoordenadas" runat="server" CssClass="cleditorToolbar"  TextMode="MultiLine" Height="50px" Width="99.5%"></asp:TextBox>
                        <%--<asp:Label ID="LblObsParcela" runat="server"></asp:Label>--%>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Recomendación:</td>
                    <td rowspan="2">
                        <asp:TextBox ID="txtRecomendacionCoordenadas" runat="server" CssClass="cleditorToolbar"  TextMode="MultiLine" Height="50px" Width="99.5%"></asp:TextBox>                        
                        <%--<asp:Label ID="LblRecomParcela" runat="server"></asp:Label>--%>
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
    
        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <div class="SubTitulo2">
                Datos Siembra:</div>            
            <%--<asp:GridView ID="GVSiembra" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
                <Columns>
                    <asp:BoundField DataField="Boleta_Numero" HeaderText="N° Boleta" />
                    <asp:BoundField DataField="Fecha_SiembraINI" HeaderText="Fecha inicial de siembra" />
                    <asp:BoundField DataField="Fecha_SiembraFIN" HeaderText="Fecha final de siembra" />
                    <asp:BoundField DataField="Sistema_Siembra" HeaderText="Sistema siembra" />
                    <asp:BoundField DataField="Cultivo_Anterior" HeaderText="Cultivo anterior" />
                    <asp:BoundField DataField="Variedad_Semilla" HeaderText="Variedad de semilla" />
                    <asp:BoundField DataField="Avance_Siembra" HeaderText="% Avance de siembra" />
                </Columns>
            </asp:GridView>--%>
            <asp:GridView ID="GVSiembra" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVSiembra_RowDataBound" OnLoad="GVSiembra_Load" OnPreRender="GVSiembra_PreRender">
                <Columns>
                    <asp:BoundField DataField="Id_Seguimiento_Parcela" HeaderText="Id Seguimiento Parcela" >
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Fecha Siembra Inicio">
                        <ItemTemplate>
                           <asp:TextBox ID="txtFechaINI" onkeyUp="return validaFechaDDMMAAAA(this);" CssClass="myDatePickerClass1" runat="server" Width="100px"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="85px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Siembra Fin">
                        <ItemTemplate>
                           <asp:TextBox ID="txtFechaFIN" onkeyUp="return validaFechaDDMMAAAA(this);" CssClass="myDatePickerClass1" runat="server" Width="100px"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="85px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Avance Siembra">
                        <ItemTemplate>
                            <asp:TextBox ID="txtAvanceSiembra" onchange="check_cantidad(this);" onkeypress="return onKeyDecimal(event,this);" runat="server" Width="70px" ToolTip="Utilice Punto(.) para Decimales" MaxLength="5"></asp:TextBox>                            
                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtAvanceSiembra" ErrorMessage="El rango es de 0 a 100 " MaximumValue="100" MinimumValue="0" style="color: #CC0000; font-weight: 700" Type="Double"></asp:RangeValidator>
                        </ItemTemplate>
                        <ItemStyle Width="75px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cultivo Anterior">
                        <ItemTemplate>
                           <asp:TextBox ID="txtCultivoAnterior" runat="server" Width="100px"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="105px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sistema Siembra">
                        <ItemTemplate>
                            <asp:DropDownList ID="DDLSistemaSiembra" runat="server">
                                <asp:ListItem>Tradicional</asp:ListItem>
                                <asp:ListItem>Semi-Mecanizado</asp:ListItem>
                                <asp:ListItem>Mecanizado</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle Width="155px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Variedad Semilla">
                        <ItemTemplate>
                            <asp:TextBox ID="txtVariedadSemilla" runat="server" Width="100px"></asp:TextBox>                            
                        </ItemTemplate>
                        <ItemStyle Width="105px" />
                    </asp:TemplateField>       
                    <%--<asp:CommandField ButtonType="Button" ShowDeleteButton="True" DeleteText="Eliminar">
                     <ControlStyle BackColor="White" BorderColor="White" BorderStyle="Solid" Font-Underline="True" ForeColor="Blue" />
                    <ItemStyle Width="80px" />
                    </asp:CommandField> --%>                   
                </Columns>
            </asp:GridView>

            <table class="TableBorder">
                <tr>
                    <td width="50">&nbsp;</td>
                    <td colspan="2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td width="100">Observación:</td>
                    <td>
                        <asp:TextBox ID="txtObsParcela" runat="server" CssClass="cleditorToolbar"  TextMode="MultiLine" Height="50px" Width="99.5%"></asp:TextBox>
                        <%--<asp:Label ID="LblObsParcela0" runat="server"></asp:Label>--%>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Recomendación:</td>
                    <td>
                        <asp:TextBox ID="txtRecParcela" runat="server" CssClass="cleditorToolbar"  TextMode="MultiLine" Height="50px" Width="99.5%"></asp:TextBox>
                        <%--<asp:Label ID="LblRecomParcela0" runat="server"></asp:Label>--%>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    
        <asp:Panel ID="Panel3" runat="server" Visible="False">
            <div class="SubTitulo2">
                Datos del Cultivo:</div>
            <%--<asp:GridView ID="GVCultivo" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
                <Columns>
                    <asp:BoundField DataField="Boleta_Numero" HeaderText="N° Boleta" />
                    <asp:BoundField DataField="Estado" HeaderText="Etapa" />
                    <asp:BoundField DataField="Nom_Fenologia" HeaderText="Estado Fenologico" />
                    <asp:BoundField DataField="Porcentaje_FF" HeaderText="%" />
                    <asp:BoundField DataField="Elemento" HeaderText="Adversidades Ocurridas" />
                    <asp:BoundField DataField="Nombre_Elemento" HeaderText="Nombre adversidad" />
                    <asp:BoundField DataField="Intencidad" HeaderText="Intencidad" />
                    <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento Recomendado" />
                </Columns>
            </asp:GridView>--%>
            <asp:GridView ID="GVCultivo" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVCultivo_RowDataBound" OnLoad="GVCultivo_Load">
                <Columns>
                    <asp:BoundField DataField="Id_Seguimiento_Parcela" HeaderText="Id Seguimiento Parcela" >
                    <ItemStyle Width="100px" />
                    </asp:BoundField>                    
                    <asp:TemplateField HeaderText="Fase Fenologica">
                        <ItemTemplate>
                            <asp:DropDownList ID="DDLFaseFenoligia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLFaseFenoligia_SelectedIndexChanged">
                                <%--<asp:ListItem Value="26">GERMINACION EMERGENCIA</asp:ListItem>
                                <asp:ListItem Value="27">PLANTULA</asp:ListItem>
                                <asp:ListItem Value="28">MACOLLAMIENTO</asp:ListItem>
                                <asp:ListItem Value="29">EMBUCHE</asp:ListItem>
                                <asp:ListItem Value="30">ESPIGAZON</asp:ListItem>
                                <asp:ListItem Value="31">FLORACION</asp:ListItem>
                                <asp:ListItem Value="32">LLENADO GRANO</asp:ListItem>
                                <asp:ListItem Value="33">MADURACION</asp:ListItem>--%>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle Width="155px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Estado" HeaderText="Estado de Fase" >
                         <ItemStyle Width="100px" />
                    </asp:BoundField> 
                    <asp:BoundField DataField="Porcentaje_FF" HeaderText=" % " >
                         <ItemStyle Width="100px" />
                    </asp:BoundField>                                       
                </Columns>
            </asp:GridView>
            <table class="TableBorder">
                <tr>
                    <td width="50">&nbsp;</td>
                    <td colspan="3">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td width="100">Observación:</td>
                    <td>
                        <asp:TextBox ID="txtObsParcela1" runat="server" CssClass="cleditorToolbar"  TextMode="MultiLine" Height="50px" Width="99.5%"></asp:TextBox> 
                        
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Recomendación:</td>
                    <td>
                        <asp:TextBox ID="txtRecomParcela1" runat="server" CssClass="cleditorToolbar"  TextMode="MultiLine" Height="50px" Width="99.5%"></asp:TextBox>                        
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    
    <table width="99%"><tr style="width: 99%">
                    <td style="width: 60%" align="left">
                        <div class="SubTitulo2">
                             <asp:Label ID="Label2" runat="server" Text="ADVERSIDAD PRESENTADA - EVENTO AGROCLIMATICO ADVERSO"></asp:Label>
                        </div>
                       </td>
                    
                    <td align="right"><asp:Button ID="btnAdd_Adversidad" runat="server" Text="Nueva_Adversidad" Visible="True" OnClick="btnAdd_Adversidad_Click" /></td>
           </tr></table>
    <asp:GridView ID="GCAdversidad" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GCAdversidad_RowDataBound" OnRowDeleting="GCAdversidad_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Id_Seguimiento_Parcela" HeaderText="Id_Seguimiento_Parcela" >
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Evento Agroclimatico Adverso">
                        <ItemTemplate>
                            <asp:DropDownList ID="DDLAdversidad" runat="server" Width="120px">
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
                        </ItemTemplate>
                        <ItemStyle Width="125px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Intensidad">
                        <ItemTemplate>
                            <asp:DropDownList ID="DDLIntensidad" runat="server" Width="150px">
                                        <asp:ListItem Value="1">LEVE(0-25)</asp:ListItem>
                                        <asp:ListItem Value="2">MODERADO(26-50)</asp:ListItem>
                                        <asp:ListItem Value="3">FUERTE(51-75)</asp:ListItem>
                                        <asp:ListItem Value="4">MUY FUERTE(76-100)</asp:ListItem>
                                    </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle Width="155px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Porcentaje Intensidad">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtPorcentajeIntensidad" onchange="check_cantidad(this);" onkeypress="return onKeyDecimal(event,this);" runat="server" Width="70px" ToolTip="Utilice Punto(.) para Decimales" MaxLength="5"></asp:TextBox>                            
                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="TxtPorcentajeIntensidad" ErrorMessage="El rango es de 0 a 100 " MaximumValue="100" MinimumValue="0" style="color: #CC0000; font-weight: 700" Type="Double"></asp:RangeValidator>
                        </ItemTemplate>
                        <ItemStyle Width="75px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Fecha Ocurrencia">
                        <ItemTemplate>
                           <asp:TextBox ID="txtFechaOcurrencia" onkeyUp="return validaFechaDDMMAAAA(this);" CssClass="myDatePickerClass1" runat="server" Width="100px"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="85px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Observación y/o Recomendación">
                        <ItemTemplate>
                            <asp:TextBox ID="txtObs_Rec" runat="server" CssClass="cleditorToolbar"  TextMode="MultiLine" Height="40px" Width="98%"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" DeleteText="Eliminar">
                     <ControlStyle BackColor="White" BorderColor="White" BorderStyle="Solid" Font-Underline="True" ForeColor="Blue" />
                    <ItemStyle Width="80px" />
                    </asp:CommandField>
                     <%--<asp:ButtonField Text="Eliminar" CommandName="Delete" Visible="True"  >
                        <ItemStyle Width="40px" />
                    </asp:ButtonField>--%>
                </Columns>
            </asp:GridView>

    <br />
    <br />
    <table width="99%"><tr style="width: 99%">
                    <td style="width: 60%" align="left">
                        <div class="SubTitulo2">
                            <asp:Label ID="Label3" runat="server" Text="ADVERSIDAD PRESENTADA - PLAGAA, MALEZAS, ENFERMEDADES"></asp:Label>
                        </div>
                    </td>
                    
                    <td align="right"><asp:Button ID="btnAdd_AdversidadPME" runat="server" Text="Nueva_Adversidad" Visible="True" OnClick="btnAdd_AdversidadPME_Click"/></td>
           </tr></table>
    <asp:GridView ID="GVAdversidadPME" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVAdversidadPME_RowDataBound" OnRowDeleting="GVAdversidadPME_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Id_Seguimiento_Parcela" HeaderText="Id_Seguimiento_Parcela" >
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Adversidad">
                        <ItemTemplate>
                            <asp:DropDownList ID="DDLAdversidad" runat="server" Width="120px">
                                        <asp:ListItem Value="PLAGA">PLAGA</asp:ListItem>
                                        <asp:ListItem Value="MALEZA">MALEZA</asp:ListItem>
                                        <asp:ListItem Value="ENFERMEDAD">ENFERMEDAD</asp:ListItem>                                        
                                    </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle Width="125px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripción">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="cleditorToolbar"  TextMode="MultiLine" Height="40px" Width="95%"></asp:TextBox>                   
                        </ItemTemplate>
                        <%--<ItemStyle Width="75px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Intensidad">
                        <ItemTemplate>
                            <asp:DropDownList ID="DDLIntensidad" runat="server">
                                        <asp:ListItem>AUSENTE</asp:ListItem>
                                        <asp:ListItem Value="1">LEVE</asp:ListItem>
                                        <asp:ListItem Value="2">MODERADO</asp:ListItem>
                                        <asp:ListItem Value="3">FUERTE</asp:ListItem>
                                        <asp:ListItem Value="4">MUY FUERTE</asp:ListItem>
                                    </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle Width="155px" />
                    </asp:TemplateField>                   

                    <asp:TemplateField HeaderText="Tratamiento">
                        <ItemTemplate>
                            <asp:TextBox ID="txtTratamiento" runat="server" CssClass="cleditorToolbar"  TextMode="MultiLine" Height="40px" Width="95%"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" DeleteText="Eliminar">
                     <ControlStyle BackColor="White" BorderColor="White" BorderStyle="Solid" Font-Underline="True" ForeColor="Blue" />
                    <ItemStyle Width="80px" />
                    </asp:CommandField>
                     <%--<asp:ButtonField Text="Eliminar" CommandName="Delete" Visible="True"  >
                        <ItemStyle Width="40px" />
                    </asp:ButtonField>--%>
                </Columns>
            </asp:GridView>
    <br />
    <br />
    <table style="width: 98%">
        <tr style="text-align: center">
            <td>
                
            </td>
            <td align="center">
                <table>
                    <tr>
                        <td><asp:Button ID="BtnEnviar" runat="server" Text="Modificar" OnClick="BtnEnviar_Click" /></td>
                        <td>&nbsp;</td>
                        <td><asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" /></td>
                    </tr>
                </table>
            </td>
            <td>
                
            </td>
        </tr>
    </table>       
   
    </asp:Content>
