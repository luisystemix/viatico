<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistroProveedor.aspx.cs" Inherits="WebAplication.Insumos.frmRegistroProveedor" %>
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
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="TableBorder">
        <tr>
            <td width="115">Regional:</td>
            <td>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td></td>
            <td width="60">Campaña:</td>
            <td width="140">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa</td>
            <td>
                <asp:Label ID="LblPrograma" runat="server"></asp:Label>
            </td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
    <div class="SubTitulo2">REGISTRAR PROVEEDOR</div>
    <table class="TableBorder">
        <tr>
            <td width="90">Razón social:</td>
            <td width="350">
                <asp:TextBox ID="TxtProveedor" runat="server" Width="350px" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="DDLProveedor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLProveedor_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="LblIdProveedor" runat="server"></asp:Label>
            </td>
            <td width="100">
                <asp:LinkButton ID="LnkNuevo" runat="server" OnClick="LnkNuevo_Click">[ Nuevo ]</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
            <td>
                </td>
            <td></td>
        </tr>
        <tr>
            <td width="70">NIT:</td>
            <td width="250">
                <asp:TextBox ID="TxtNIT" runat="server"></asp:TextBox>
            </td>
            <td>N° Test. Creación:</td>
            <td>
                <asp:TextBox ID="TxtNumTesTim" runat="server" Width="70px">0</asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td class="espacio">&nbsp;</td>
        </tr>
        <tr>
            <td width="70"></td>
            <td width="250">
            </td>
            <td><div style="text-align: right">Fecha:</div></td>
            <td>
                <asp:TextBox ID="TxtFechaTestim" CssClass="myDatePickerClass1" runat="server" Width="70"></asp:TextBox>
                </td>
            <td>
                </td>
            <td></td>
        </tr>
        <tr>
            <td>Departamento:</td>
            <td>
                <asp:DropDownList ID="DDLDepartamento" runat="server">
                    <asp:ListItem>LA PAZ</asp:ListItem>
                    <asp:ListItem>SANTA CRUZ</asp:ListItem>
                    <asp:ListItem>BENI</asp:ListItem>
                    <asp:ListItem>COCHABAMBA</asp:ListItem>
                    <asp:ListItem>TARIJA</asp:ListItem>
                    <asp:ListItem>POTOSI</asp:ListItem>
                    <asp:ListItem>CHUQUISACA</asp:ListItem>
                    <asp:ListItem>ORURO</asp:ListItem>
                    <asp:ListItem>PANDO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td></td>
            <td class="espacio"></td>
        </tr>
        <tr>
            <td>Domicilio:</td>
            <td>
                <asp:TextBox ID="TxtDomicilio" runat="server" Width="350px"></asp:TextBox>
                </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="espacio">&nbsp;</td>
        </tr>
        <tr>
            <td>Telefono de Ref.</td>
            <td>
                <asp:TextBox ID="TxtFono" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td><div style="text-align: right">Correo:</div></td>
            <td>
                <asp:TextBox ID="TxtCorreo" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td class="espacio">&nbsp;</td>
        </tr>
        <tr>
            <td>Insumo:</td>
            <td colspan="4">
                <asp:DropDownList ID="DDLInsumo" runat="server">
                    <asp:ListItem>SEMILLA</asp:ListItem>
                    <asp:ListItem>AGROQUIMICO</asp:ListItem>
                    <asp:ListItem>COMBUSTIBLE</asp:ListItem>
                    <asp:ListItem>MAQUINARIA</asp:ListItem>
                    <asp:ListItem>SERVICIOS</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="4">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="BtnRegistrar" runat="server" OnClick="BtnRegistrar_Click" Text="Registrar" />
                <asp:Button ID="BtnCancel" runat="server" Text="Cancelar" />
            </td>
            <td></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="espacio"></td>
        </tr>
    </table>
        </asp:Content>
