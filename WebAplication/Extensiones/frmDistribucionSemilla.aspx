<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDistribucionSemilla.aspx.cs" Inherits="WebAplication.Extensiones.frmDistribucionSemilla" %>
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
                height: "100", // height not including margins, borders or padding
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
            key = e.keyCode ? e.keyCode : e.which;
            if (key === 8)
                return true;
            if (field.value !== "") {
                if ((field.value.indexOf(",")) > 0) {
                    if (key > 47 && key < 58) {
                        if (field.value === "")
                            return true;
                        regexp = /[0-9]{1,10}[,][0-9]{1,3}$/;
                        regexp = /[0-9]{2}$/;
                        return !(regexp.test(field.value))
                    }
                }
            }
            if (key > 47 && key < 58) {
                if (field.value === "")
                    return true;
                regexp = /[0-9]{10}/;
                return !(regexp.test(field.value));
            }
            if (key === 44) {
                if (field.value === "")
                    return false;
                regexp = /^[0-9]+$/;
                return regexp.test(field.value);

            }

            return false;
        }

     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">SEGUIMIENTO A LA DISTRIBUCIÓN DE SEMILLA</div><table class="TableBorder">
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
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblEtapa" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
        <div class="SubTitulo2">DATOS DEL SEGUIMIENTO TÉCNICO REALIZADO</div><table class="TableBorder">
        <tr>
            <td width="125">Nombre del Agricultor:</td>
            <td width="250">
                <asp:Label ID="LblProductor" runat="server"></asp:Label>
            </td>
            <td width="120">
                <asp:Label ID="LblIdInsProd" runat="server"></asp:Label>
            </td>
            <td width="200">
                &nbsp;</td>
            <td width="105">
                &nbsp;</td>
            <td colspan="2">
                
                <div style="text-align: right"><asp:Label ID="LblIdUsuario" runat="server"></asp:Label></div></td>
        </tr>
        <tr>
            <td>Empresa Proveedora:</td>
            <td>
                <asp:DropDownList ID="DDLProveedor" runat="server" OnSelectedIndexChanged="DDLProveedor_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>Lugar de Distribución:</td>
            <td>
                <asp:TextBox ID="TxtLugarDistrib" runat="server" onKeyUp="toUpper(this)" Width="250px"></asp:TextBox>
            </td>
            <td>
                Fecha Distribución:</td>
            <td>
                <asp:TextBox ID="TxtFechaDistrib" CssClass="myDatePickerClass1" runat="server" Width="70px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
        <div style="text-align: center"><asp:Label ID="LblMsj1" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
        <table class="TableBorder">
            <tr>
                <td width="125">N° Boleta Distribucion:</td>
                <td width="150">
                    <asp:TextBox ID="TxtNumBoleta" onKeyPress='return esInteger(event)' runat="server" Width="40px" style="background-color: #FFFFCC"></asp:TextBox>
                </td>
                <td width="10">&nbsp;</td>
                <td width="120">
                    &nbsp;</td>
                <td width="105">&nbsp;</td>
                <td width="60">
                    &nbsp;</td>
                <td width="65">&nbsp;</td>
                <td width="40">&nbsp;</td>
                <td width="50">&nbsp;</td>
                <td width="100">&nbsp;</td>
                <td width="45">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Insumo:</td>
                <td>
                    <asp:DropDownList ID="DDLInsumo" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="1">SEMILLA</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Tipo:</td>
                <td>
                    <asp:DropDownList ID="DDLProducto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLProducto_SelectedIndexChanged">
                        <asp:ListItem Value="1">CONVENCIONAL</asp:ListItem>
                        <asp:ListItem Value="2">HIBRIDO</asp:ListItem>
                        <asp:ListItem Value="3">TRANSGENICO</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td></td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Variedad:</td>
                <td colspan="2">
                    <asp:DropDownList ID="DDLNomComer" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLNomComer_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtVariedad" runat="server" Width="150px" onKeyUp="toUpper(this)" Visible="False"></asp:TextBox>
                </td>
                <td>
                    Categoria:</td>
                <td>
                    <asp:TextBox ID="TxtCategoria" runat="server" Width="100px" onKeyUp="toUpper(this)"></asp:TextBox>
                    </td>
                <td>
                    <asp:LinkButton ID="LnkNuevo" runat="server" OnClick="LnkNuevo_Click">[ Nuevo ]</asp:LinkButton>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>N° de Lote:</td>
                <td colspan="2">
                    <asp:TextBox ID="TxtLote" runat="server" Width="60px"></asp:TextBox>
                </td>
                <td>
                    Fecha de Caducidad:</td>
                <td>
                    <asp:TextBox ID="TxtFechaCaducidad" CssClass="myDatePickerClass1" runat="server" Width="70px"></asp:TextBox>
                </td>
                <td>
                    Cantidad:</td>
                <td>
                    <asp:TextBox ID="TxtCantidad" onkeypress="return NumCheck(event,this)" runat="server" Width="50px"></asp:TextBox>
                </td>
                <td>
                    Unidad:</td>
                <td>
                    <asp:DropDownList ID="DDLUnidad" runat="server">
                        <asp:ListItem>kg</asp:ListItem>
                        <asp:ListItem>lt</asp:ListItem>
                        <asp:ListItem>t</asp:ListItem>
                        <asp:ListItem Value="bolsa">bolsa</asp:ListItem>
                        <asp:ListItem>@</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    % de Germinación:</td>
                <td>
                    <asp:TextBox ID="TxtPorcentGermi" onKeyPress='return esInteger(event)' runat="server" Width="30px"></asp:TextBox>
                </td>
                <td class="auto-style1"><asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TxtPorcentGermi" ErrorMessage="ERROR el rango es de 0 a 100" MaximumValue="100" MinimumValue="0" Type="Integer" style="font-weight: 700; color: #CC0000"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td colspan="11">
                    <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar &gt;&gt;" OnClick="BtnRegistrar_Click" />
        <asp:GridView ID="GVDistribSemilla" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="NumBoleta" HeaderText="NumBoleta" />
                <asp:BoundField DataField="Variedad" HeaderText="Variedad" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="Lote" HeaderText="Lote" />
                <asp:BoundField DataField="Germinacion" HeaderText="% Germinacion" />
                <asp:BoundField DataField="FechCaducidad" HeaderText="FechCaducidad" />
                <asp:BoundField DataField="Unidad" HeaderText="Unidad" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            </Columns>
        </asp:GridView>
    <div style="text-align: center"><asp:Label ID="LblMsj2" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
    <table class="TableBorder">
        <tr>
            <td><div class="SubTitulo2">Observaciones:</div></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="TxtObser" runat="server" CssClass="cleditorToolbar"  TextMode="MultiLine" Height="80px" Width="98%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="text-align: center"><asp:Button ID="BtnEnviar" runat="server" OnClientClick ="return Confirmacion()" Text="Enviar Seguimiento" OnClick="BtnEnviar_Click" Enabled="False" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" /></div>
</asp:Content>
