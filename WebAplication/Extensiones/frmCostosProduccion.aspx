<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCostosProduccion.aspx.cs" Inherits="WebAplication.Extensiones.frmCostosProduccion" %>
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


        function NumCheck(e, field) {
            key = e.keyCode ? e.keyCode : e.which
            // backspace
            if (key == 8) return true
            // 0-9
            if (key > 47 && key < 58) {
                if (field.value == "") return true
                regexp = /.[0-9]{2}$/
                return !(regexp.test(field.value))
            }
            // .
            if (key == 46) {
                if (field.value == "") return false
                regexp = /^[0-9]+$/
                return regexp.test(field.value)
            }
            // other key
            return false

        }


     </script>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">COSTOS DE PRODUCCIÓN</div>
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
                <asp:Label ID="LblEtapa" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
        <table class="TableBorder">
            <tr>
                <td width="115">Nombre Productor:</td>
                <td width="300">
                <asp:Label ID="LblProductor" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsProd" runat="server" Visible="False"></asp:Label>
                </td>
                <td width="120">Superficie ejectutada:</td>
                <td>
                    <asp:Label ID="LblSupProd" runat="server"></asp:Label>
                    (ha)</td>
                <td width="115">
                    &nbsp;</td>
                <td width="60">
                <asp:Label ID="LblIdUsuario" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Fecha de Costo:</td>
                <td>                <asp:TextBox ID="TxtFechaInspeccion"  CssClass="myDatePickerClass1" onkeyUp="return validaFechaDDMMAAAA(this);" runat="server" Width="70px"></asp:TextBox>
                
                    </td>
                <td></td>
                <td>&nbsp;</td>
                <td>Tasa de Cambio $us:</td>
                <td>
                    <asp:TextBox ID="TxtDollar" runat="server" Width="40px">6.69</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Sistema de Siembra:</td>
                <td>
                    <asp:DropDownList ID="DDLTipoSiembra" runat="server">
                        <asp:ListItem>Mecanizado</asp:ListItem>
                        <asp:ListItem>Semi-Mecanizado</asp:ListItem>
                        <asp:ListItem>Tradicional</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                </td>
            </tr>
            </table>
        <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
        <table class="TableBorder">
            <tr>
                <td width="40">&nbsp;</td>
                <td width="110">Etapa de cultivo:</td>
                <td width="230">
                    <asp:DropDownList ID="DDLEtapa" runat="server" Width="215px">
                        <asp:ListItem Value="1">I DESECACIÓN</asp:ListItem>
                        <asp:ListItem Value="2">II PREPARACIÓN DE SUELO Y SIEMBRA</asp:ListItem>
                        <asp:ListItem Value="3">III INSUMO</asp:ListItem>
                        <asp:ListItem Value="4">IV SERVICIOS CULTURALES</asp:ListItem>
                        <asp:ListItem Value="5">V COSECHA Y TRANSPORTE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td width="20">&nbsp;</td>
                <td width="150">Elemento/Insumo utilizado:</td>
                <td width="160">
                    <asp:DropDownList ID="DDLInsumo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLInsumo_SelectedIndexChanged">
                        <asp:ListItem Value="1">SEMILLA</asp:ListItem>
                        <asp:ListItem Value="2">AGROQUIMICO</asp:ListItem>
                        <asp:ListItem Value="3">COMBUSTIBLE</asp:ListItem>
                        <asp:ListItem Value="4">MAQUINARIA</asp:ListItem>
                        <asp:ListItem Value="5">MANO DE OBRA</asp:ListItem>
                        <asp:ListItem Value="6">TRACCIÓN  ANIMAL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td width="40" class="auto-style1"></td>
                <td class="auto-style1">Recurso/Tipo:</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DDLProducto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLProducto_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td width="150" class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td width="40">&nbsp;</td>
                <td>Producto/Tarea:</td>
                <td colspan="4">
                    <asp:DropDownList ID="DDLItemProd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLItemProd_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtItemProd" runat="server" Width="300px" onKeyUp="toUpper(this)" Visible="False"></asp:TextBox>
                    <asp:LinkButton ID="LnkOtros" runat="server" OnClick="LnkOtros_Click">[ Otros ]</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
        <table class="TableBorder">
            <tr>
                <td width="40">&nbsp;</td>
                <td width="110">Dosis/Cantidad:</td>
                <td width="150">
                    <asp:TextBox ID="TxtCantidad" runat="server" onkeypress="return NumCheck(event, this)" Width="40px" AutoPostBack="True" OnTextChanged="TxtCantidad_TextChanged">0</asp:TextBox>
                </td>
                <td width="20">&nbsp;</td>
                <td width="125">Unidad:</td>
                <td width="80">
                    <asp:DropDownList ID="DDLUnidad" runat="server">
                        <asp:ListItem>kg</asp:ListItem>
                        <asp:ListItem>lt</asp:ListItem>
                        <asp:ListItem>t</asp:ListItem>
                        <asp:ListItem>bolsa</asp:ListItem>
                        <asp:ListItem>@</asp:ListItem>
                        <asp:ListItem>Jornal</asp:ListItem>
                        <asp:ListItem>qq</asp:ListItem>
                        <asp:ListItem>hs</asp:ListItem>
                        <asp:ListItem>Dia/Yunta</asp:ListItem>
                        <asp:ListItem>Dia/Burro</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td width="20">&nbsp;</td>
                <td width="125">Aplicaciones/Dias:</td>
                <td>
                    <asp:DropDownList ID="DDLNumApli" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLNumApli_SelectedIndexChanged">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Adquisición:</td>
                <td>
                    <asp:DropDownList ID="DDLTipoAdquisicion" runat="server">
                        <asp:ListItem>Empresa Proveedora</asp:ListItem>
                        <asp:ListItem>Compra Adicional</asp:ListItem>
                        <asp:ListItem>Contrato particular</asp:ListItem>
                        <asp:ListItem>Flete</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>Precio unitario(Bs/Ha):</td>
                <td>
                    <asp:TextBox ID="TxtPrecio" runat="server" onkeypress="return NumCheck(event, this)" Width="40px" AutoPostBack="True" OnTextChanged="TxtPrecio_TextChanged" style="background-color: #FFFFCC">0</asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>Costo TOTAL(Bs/Ha):</td>
                <td>
                    <asp:TextBox ID="TxtCostoBsHa" runat="server" Width="60px" Enabled="False">0</asp:TextBox>
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
                <td>CostoTOTAL($us/Ha):</td>
                <td>
                    <asp:TextBox ID="TxtCostoSusHa" runat="server" Width="60px" Enabled="False">0</asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="10">
                    <div style="text-align: center"><asp:Label ID="LblMsj1" runat="server" style="color: #CC0000; font-weight: 700"></asp:Label></div>
                </td>
            </tr>
    </table>
        <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar &gt;&gt;" OnClick="BtnRegistrar_Click" />
    <asp:GridView ID="GVCostos" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVCostos_RowCommand">
        <Columns>
            <asp:BoundField DataField="valor1" HeaderText="Etapa de cultivo" />
            <asp:BoundField DataField="valor2" HeaderText="IDEtapaCult" Visible="False" />
            <asp:BoundField DataField="valor3" HeaderText="Insumo/Elemento" />
            <asp:BoundField DataField="valor4" HeaderText="IDInsumo" Visible="False" />
            <asp:BoundField DataField="valor5" HeaderText="Recurso/Tipo" />
<asp:BoundField DataField="valor6" HeaderText="IDRecurso/Tipo" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="valor7" HeaderText="Producto/Tarea" />
            <asp:BoundField DataField="valor8" HeaderText="Unidad" />
            <asp:BoundField DataField="valor9" HeaderText="Cantidad/Dosis" />
            <asp:BoundField DataField="valor10" HeaderText="N° Aplicaciones:" />
            <asp:BoundField DataField="valor11" HeaderText="Precio unitario(Bs/Ha)" />
            <asp:BoundField DataField="valor12" HeaderText="Adquisición" />
            <asp:BoundField DataField="valor13" HeaderText="Costo TOTAL(Bs/Ha)" />
            <asp:BoundField DataField="valor14" HeaderText="CostoTOTAL($us/Ha)" />
            <asp:ButtonField ButtonType="Image" CommandName="Eliminar" ImageUrl="~/images/img-0.png" Text="Button" />
        </Columns>
    </asp:GridView>
    <div style="text-align: center"><asp:Button ID="BtnEnviar" runat="server" OnClientClick ="return Confirmacion()" Text="Enviar Analisis de Costos" OnClick="BtnEnviar_Click" Visible="False" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" Visible="False" OnClick="BtnCancelar_Click" /></div>
        </asp:Content>
