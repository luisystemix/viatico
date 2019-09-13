<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repSeguimientoCultivo.aspx.cs" Inherits="WebAplication.Extensiones.repSeguimientoCultivo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reporte Seguimiento Cultivo</title>
<script src="../js/validar.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <link href="../css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" />
    <script src="../AcopioSilos/jquery.cleditor.js" type="text/javascript"></script>
    <link href="../AcopioSilos/jquery.cleditor.css" rel="stylesheet" />
<link href="../css/EmapaStyele.css" rel="stylesheet" />
<style type="text/css">        
    size {
    font-size:small;
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
            if (charCode < 48 || charCode > 57) {
                alert("Por favor teclee solo números en este campo!");
                return false
            }
            else {
                return true                
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
        function Confirmacion() {
            var seleccion = confirm("Está seguro de enviar la información registrada…?");
            return seleccion;
        }
        function check_cantidad(element) {
            var cant = element.value;
            //alert(cant);
            if (cant > 100) {
                alert('Valor introducido es mayor a 100%');
                document.getElementById(element.id).value = "0";
            }
            else {
                
            }
        }
        function Calcular() {            
            var boton = document.getElementById('<%=btCalcularPromedio.ClientID%>');
            boton.click();
        }
        var objBoton = '<%=btCalcularPromedio.ClientID%>'
        function darClick() {
            alert("doing...!!!");
            var objO = document.getElementByid(objBoton);
            objO.click();

        }
        function ConfirmSave() {
            var seleccion = confirm("Está seguro de enviar la información registrada…?");
            return seleccion;
        }
        function ConfirmExport() {
            alert('LUEGO DE LA EXPORTAR, GUARDE LOS DATOS REGISTRADOS');            
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <table class="TableBorder">
            <tr>
                <td width="200" rowspan="3">
                    <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td><div style="text-align: center">REGISTRO</div></td>
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ 303 R07</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">SEGUIMIENTO DEL CULTIVO DE TRIGO SEGÚN FASE FELONOGICA
                    </div></td>
                <td>
                    <div style="text-align: center">Versión 2</div></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
        </table>
    
        <%--<table class="TableBorder">
            <tr>
                <td>Fecha:</td>
                <td>
                    <asp:Label ID="LblFechaSeg" runat="server"></asp:Label>
                &nbsp;
                </td>
                <td width="70">Hora:</td>
                <td>
                    <asp:Label ID="LblHoraSeg" runat="server"></asp:Label>
                </td>
                <td width="55">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td width="80"><div style="text-align: right">N°</div></td>
                <td>
                    <asp:Label ID="LblNum" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Nombre del agricultor:</td>
                <td class="auto-style1">
                    <asp:Label ID="LblProductor" runat="server"></asp:Label>
                    , CI:
                    <asp:Label ID="LblCedula" runat="server"></asp:Label>
                </td>
                <td class="auto-style1">Organización:</td>
                <td class="auto-style1">
                    <asp:Label ID="LblOrg" runat="server"></asp:Label>
                </td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style2">Comunidad:</td>
                <td class="auto-style2">
                    <asp:Label ID="LblComunidad" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">Municipio:</td>
                <td class="auto-style2">
                    <asp:Label ID="LblMunicipio" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">Provincia:</td>
                <td class="auto-style2">
                    <asp:Label ID="LblProvincia" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">Departamento:</td>
                <td class="auto-style2">
                    <asp:Label ID="LblDep" runat="server"></asp:Label>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>Nombre del Tecnico:</td>
                <td>
                    <asp:Label ID="LblTecnico" runat="server"></asp:Label>
                    <asp:Label ID="LblIdUser" runat="server" Visible="False"></asp:Label>
                </td>
                <td>Programa:</td>
                
                <td>Campaña:</td>
                <td>
                    
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Regional:</td>
                <td>
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="LblEtapa" runat="server" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                
            </tr>
        </table>--%>
        <table class="TableBorder">
            <tr>
                <td>
                    <asp:Label ID="LblIdInsOrg" runat="server" ForeColor="#6600CC" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblIdInsProd" runat="server" ForeColor="#6600CC" Visible="False"></asp:Label>
                </td>
                <td>
                    
                </td>
                <td>
                    <asp:Label ID="LblIdReg" runat="server" ForeColor="#6600CC" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblIdUsuario" runat="server" ForeColor="#6600CC" Visible="False"></asp:Label>
                </td>
                <td>
                    
                </td>
                <td>
                    <asp:Label ID="LblIdCamp" runat="server" ForeColor="#6600CC" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblPrograma" runat="server" ForeColor="#6600CC" Visible="False"></asp:Label>
                </td>
                <td>
                <div style="text-align: right">
                    <asp:ImageButton ID="ImgSave" runat="server" Height="40px" ImageUrl="~/images/floppy drive 3 1'2.png" Width="40px" ToolTip="Guardar" OnClientClick="return ConfirmSave();" OnClick="ImgSave_Click"/>                    
                     <asp:ImageButton ID="ImgPrint" runat="server" Height="40px" ImageUrl="~/images/excel7.png" Width="40px" OnClientClick="ConfirmExport();" OnClick="ImgPrint_Click" ToolTip="Exportar" />
                </div>
            </td>
            </tr>
        </table>
        <table class="TableBorder">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" ForeColor="#6600CC" Text="REPORTE DEL(Lunes):"></asp:Label>
                    <asp:TextBox ID="TxtFecha1" onkeyUp="return validaFechaDDMMAAAA(this);" CssClass="myDatePickerClass1" runat="server"  ValidationGroup="Formulario" Width="80px"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" ForeColor="#6600CC" Text="AL(Domingo):"></asp:Label>
                    <asp:TextBox ID="TxtFecha2" onkeyUp="return validaFechaDDMMAAAA(this);" CssClass="myDatePickerClass1" runat="server"  ValidationGroup="Formulario" Width="80px"></asp:TextBox>
                    <asp:Button ID="btnGenerar" runat="server" Text="Generar" Height="20px" Width="80px" OnClick="btnGenerar_Click" Visible="False" />
                    <asp:Button ID="btCalcularPromedio" runat="server" Text="Calcular" Height="20px" Width="80px" OnClick="btCalcularPromedio_Click" />
                    <asp:Button ID="btnAux" runat="server" Text="Button" Height="20px" OnClienClick="darclick();" Visible="False" OnClick="btnAux_Click" />
                    <asp:Label ID="lblmensaje" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" ForeColor="#6600CC" Text="CAMPAÑA:"></asp:Label>
                    <asp:Label ID="LblCamp" runat="server" ForeColor="#6600CC"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" ForeColor="#6600CC" Text="REGIONAL:"></asp:Label>
                    <asp:Label ID="LblReg" runat="server" ForeColor="#6600CC"></asp:Label>
                </td>
                
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server" Visible="True">
            <div class="SubTitulo2">
                Seguimiento del Cultivo:</div>
            <asp:GridView ID="GVSeguimientoCultivo" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVSeguimientoCultivo_RowDataBound">
                <Columns>                    
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblZona" runat="server" Text="Municipio/Zona"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtZona" runat="server" Width="80px" Font-Size="Smaller"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Organizacion" HeaderText="Organización" >
                    <ItemStyle Width="150px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblppsemanal" runat="server" Text="Pp Semanal mm"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtPpsemanal" onchange="check_cantidad(this);" onkeypress="return onKeyDecimal(event,this);" runat="server" Width="50px" Font-Size="Smaller"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblFechaSiembraInicio"  runat="server" Text="Fecha Siembra Inicio"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtFechaSiembraInicio" onkeyUp="return validaFechaDDMMAAAA(this);" CssClass="myDatePickerClass1" runat="server" Width="80px" Font-Size="Smaller"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="65px" />
                        <ItemStyle Width="65px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblFechaSiembraFinal" runat="server" Text="Fecha Siembra Final"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtFechaSiembraFinal" onkeyUp="return validaFechaDDMMAAAA(this);" CssClass="myDatePickerClass1" runat="server" Width="80px" Font-Size="Smaller"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="65px" />
                        <ItemStyle Width="65px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                                        
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblAvanceSiembra" runat="server" Text="Avance Siembra %"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtAvanceSiembra" onKeyPress="return esInteger(event)" onchange="check_cantidad(this);" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="40px" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblGerminacion" runat="server" Text="Germinación"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtGerminacion" onKeyPress="return esInteger(event)" onchange="check_cantidad(this);" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblPlantula" runat="server" Text="Plántula"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtPlantula" onKeyPress="return esInteger(event)" onchange="check_cantidad(this);" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblMacollamiento" runat="server" Text="Macollamiento"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtMacollamiento" onKeyPress="return esInteger(event)" onchange="check_cantidad(this);" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblEmbuche" runat="server" Text="Embuche"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtEmbuche" onKeyPress="return esInteger(event)" onchange="check_cantidad(this);" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblEspigazon" runat="server" Text="Espigazón"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtEspigazon" onKeyPress="return esInteger(event)" onchange="check_cantidad(this);" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblFloracion" runat="server" Text="Floración"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtFloracion" onKeyPress="return esInteger(event)" onchange="check_cantidad(this);" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblGrano" runat="server" Text="Llenado de Grano"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtGrano" onKeyPress="return esInteger(event)" onchange="check_cantidad(this);" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblMaduracion" runat="server" Text="Maduración"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtMaduracion" onKeyPress="return esInteger(event)" onchange="check_cantidad(this);" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblAvanceCosecha" runat="server" Text="Avance Cosecha %"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtAvanceCosecha" onKeyPress="return esInteger(event)" onchange="check_cantidad(this);" runat="server" Width="80px"> </asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="40px" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblRend" runat="server" Text="Rend t/ha"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtRend" onchange="check_cantidad(this);" onkeypress="return onKeyDecimal(event,this);" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblFechaCosechaInicial" runat="server" Text="Fecha Cosecha Inicial"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtFechaCosechaInicial" onkeyUp="return validaFechaDDMMAAAA(this);" CssClass="myDatePickerClass1" runat="server" Width="80px" Font-Size="Smaller"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblFechaCosechaFinal" runat="server" Text="Fecha Cosecha Final"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtFechaCosechaFinal" onkeyUp="return validaFechaDDMMAAAA(this);" CssClass="myDatePickerClass1" runat="server" Width="80px" Font-Size="Smaller"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones(Estado del Cultivo, Siembra, Presencia de Plagas, Uso de Insumos, Cosecha, Acopio, etc)"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtObservaciones" runat="server" Width="80px" Font-Size="Smaller"></asp:TextBox>                           
                        </ItemTemplate>
                        <ControlStyle Width="150px" Font-Size="Smaller"/>
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table>
                <tr>
                    <td style="width: 100px"></td>
                    <td style="width: 180px"></td>
                    <td style="width: 50px"></td>
                    <td style="width: 40px"></td>
                    <td style="width: 40px"><asp:Label ID="lblpromedio" runat="server" Text="Promedio:" Font-Bold="True"></asp:Label></td>
                    <td><asp:TextBox ID="txtPromedioSiembra" runat="server" Width="50px" Text="0" Enabled="False"></asp:TextBox> </td>
                    <td style="width: 60px"></td>
                    <td style="width: 60px"></td>
                    <td style="width: 60px"></td>
                    <td style="width: 60px"></td>
                    <td style="width: 60px"></td>
                    <td style="width: 60px"></td>
                    <td style="width: 55px"></td>
                    <td style="width: 50px"></td>                    
                    <td><asp:TextBox ID="txtPromedioCosecha" runat="server" Width="50px" Text="0" Enabled="False"></asp:TextBox> </td>
                    <td><asp:TextBox ID="txtPromedioRend" runat="server" Width="50px" Text="0" Enabled="False"></asp:TextBox> </td>


                </tr>
            </table>
            <table >
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td width="50">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td >
                        <asp:Label ID="Label5" runat="server" Text="Elaborador por: "></asp:Label>
                        <asp:TextBox ID="txtNombreUsuario" runat="server" Width="280px" Font-Size="Smaller"></asp:TextBox>
                        
                    </td>                                        
                    <td colspan="2">
                        <asp:Label ID="Label6" runat="server" Text="VoBo:"></asp:Label>
                        <asp:TextBox ID="txtvobo" runat="server" Width="280px" Font-Size="Smaller"></asp:TextBox>
                    </td>                    
                </tr>    
                <tr>
                    <td></td>
                    <td style="text-align: center">
                        <%--<asp:Label ID="Label8" runat="server" Text="Elaborador por:" Visible="False"></asp:Label>--%> 
                        <asp:Label ID="Label7" runat="server" Text="Nombre y Cargo"></asp:Label>                       
                    </td>                    
                    <td colspan="2">
                        
                    </td>                    
                </tr>               
            </table>            
        
        

        </asp:Panel>  
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <asp:Label ID="lbllogo" runat="server" Text="" Visible="False"></asp:Label>
            <asp:Label ID="lblCabecera" runat="server" Text="" Visible="False"></asp:Label>
            <asp:Label ID="lblCabecera2" runat="server" Text="" Visible="False"></asp:Label>
            <asp:Label ID="lblPromedioAvances" runat="server" Text="" Visible="False"></asp:Label>
            <asp:Label ID="lblFirma" runat="server" Text="" Visible="False"></asp:Label>
            

        <asp:GridView ID="GVforexcel" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" Visible="True">
                <Columns>                                        
                    <asp:BoundField DataField="Zona" HeaderText="Municipio/Zona" >
                    <ItemStyle Width="100px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Organizacion" HeaderText="Organización" >
                    <ItemStyle Width="180px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ppsemanal" HeaderText="Pp Semanal mm" >
                    <ItemStyle Width="50px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FechaSiembraInicio" HeaderText="Fecha Siembra Inicial" >
                    <ItemStyle Width="70px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FechaSiembraFinal" HeaderText="Fecha Siemba Final" >
                    <ItemStyle Width="70px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AvanceSiembra" HeaderText="Avance Siembra %" >
                    <ItemStyle Width="50px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Germinacion" HeaderText="Germinación" >
                    <ItemStyle Width="50px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Plantula" HeaderText="Plantula" >
                    <ItemStyle Width="50px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Macollamiento" HeaderText="Macollamiento" >
                    <ItemStyle Width="50px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Embuche" HeaderText="Embuche" >
                    <ItemStyle Width="50px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Espigazon" HeaderText="Espigazón" >
                    <ItemStyle Width="50px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Floracion" HeaderText="Floración" >
                    <ItemStyle Width="50px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Grano" HeaderText="Llenado de Grano" >
                    <ItemStyle Width="50px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Maduracion" HeaderText="Maduración" >
                    <ItemStyle Width="50px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AvanceCosecha" HeaderText="Avance Cosecha %" >
                    <ItemStyle Width="50px" Font-Size="Smaller" />
                    </asp:BoundField>                    
                    <asp:BoundField DataField="Rend" HeaderText="Rend t/ha" >
                    <ItemStyle Width="50px" Font-Size="Smaller" />
                    </asp:BoundField> 
                    <asp:BoundField DataField="FechaCosechaInicial" HeaderText="Fecha Cosecha Inicial" >
                    <ItemStyle Width="70px" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FechaCosechaFinal" HeaderText="Fecha Cosecha Final" >
                    <ItemStyle Width="70px" Font-Size="Smaller" />
                    </asp:BoundField>                  
                    <asp:BoundField DataField="Observaciones" HeaderText="Observaciones(Estado del Cultivo, Siembra, Presencia de Plagas, Uso de Insumos, Cosecha, Acopio, etc)" >
                    <ItemStyle Width="150px" Font-Size="Smaller" />
                    </asp:BoundField>                     
                </Columns>
            </asp:GridView>
            </asp:Panel>  
        </div>
    </form>
</body>
</html>
