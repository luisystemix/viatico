<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRendimientoArroz.aspx.cs" Inherits="WebAplication.Extensiones.frmRendimientoArroz" %>
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
    <div class="SubTitulo">
        RENDIMIENTO DE GRANO DE ARROZ</div>
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
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
        <div class="SubTitulo2">DATOS PARA CALCULAR EL RENDIMIENTO</div>
    <table class="TableBorder">
        <tr>
            <td width="105">Nombre Productor:</td>
            <td width="300">
                <asp:Label ID="LblProductor" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsProd" runat="server"></asp:Label>
            </td>
            <td width="110">Fecha de Inspeción:</td>
            <td>
                <asp:TextBox ID="TxtFechaInspeccion"  CssClass="myDatePickerClass1" runat="server" Width="70px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Variedad:</td>
            <td>
                <asp:Label ID="LblVariedad" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
    <table class="TableBorder">
        <tr>
            <td width="40">&nbsp;</td>
            <td width="125">
                Fase Fenologica:</td>
            <td width="40" colspan="6">
                <asp:DropDownList ID="DDLFaceFenologica" runat="server">
                </asp:DropDownList>
            </td>
            <td width="40">&nbsp;</td>
            <td width="80">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>N° de Panojas por m2:</td>
            <td width="50">
                <asp:TextBox ID="TxtNumPanoja" onKeyPress='return esInteger(event)' runat="server" Width="40px">0</asp:TextBox>
            </td>
            <td width="20">&nbsp;</td>
            <td width="150">N° de Espigillas por Panoja:</td>
            <td width="50">
                <asp:TextBox ID="TxtNumExpigillas" onKeyPress='return esInteger(event)' runat="server" Width="40px">1</asp:TextBox>
            </td>
            <td width="20">&nbsp;</td>
            <td width="185">N° de Espigillas por Panoja, vanos:</td>
            <td>
                <asp:TextBox ID="TxtNumEspiguillasPanojaVano" onKeyPress='return esInteger(event)' runat="server" Width="40px">0</asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>% de Espiguillas Llenas:</td>
            <td>
                <asp:TextBox ID="TxtPorcentEspiguillasLlenas" onKeyPress='return esInteger(event)' runat="server" Width="40px" Enabled="False" style="font-weight: 700; background-color: #FFFFCC">0</asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>Peso de 1000 Granos (gr.):</td>
            <td>
                <asp:TextBox ID="TxtPesoMilGranos" onKeyPress='return esInteger(event)' runat="server" Width="40px">0</asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td><div style="text-align: right">% de Humedad:</div></td>
            <td>
                <asp:TextBox ID="TxtPorcentHumedad" onKeyPress='return esInteger(event)' runat="server" Width="40px">0</asp:TextBox>
            </td>
            <td>(Fanega/ha) = </td>
            <td>
                <asp:Label ID="LblFanHect" runat="server" style="font-weight: 700; font-size: medium">0</asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
               <div style="text-align: right"><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TxtPorcentEspiguillasLlenas" ErrorMessage="ERROR rango 0 al 100" MaximumValue="100" MinimumValue="0" style="font-weight: 700; color: #CC0000" Type="Double"></asp:RangeValidator></div>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="2">
                <div style="text-align: right"><asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TxtPorcentHumedad" ErrorMessage="ERROR rango 0 al 100" MaximumValue="100" MinimumValue="0" style="color: #CC0000; font-weight: 700" Type="Double"></asp:RangeValidator></div>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="LnkRendimiento" runat="server" OnClick="LnkRendimiento_Click">Calcular Rendimiento</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="12">
                <div style="text-align: center"><asp:Label ID="LblMsj1" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
            </td>
        </tr>
    </table>
    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar Rendimiento &gt;&gt;" OnClick="BtnRegistrar_Click" Enabled="False" />
    <asp:GridView ID="GVRendArroz" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Valor1" HeaderText="N° Panojas m2" />
            <asp:BoundField DataField="Valor2" HeaderText="N° Espiguillas Panoja" />
            <asp:BoundField DataField="Valor3" HeaderText="N° Espiguillas Panoja, vanos" />
            <asp:BoundField DataField="Valor4" HeaderText="% Espiguillas llenas" />
            <asp:BoundField DataField="Valor5" HeaderText="Peso de 1000 granos" />
            <asp:BoundField DataField="Valor6" HeaderText="% Humedad" />
            <asp:BoundField DataField="Valor7" HeaderText="Fanega/Ha" />
        </Columns>
    </asp:GridView>
    <div style="text-align: center"><asp:Button ID="BtnEnviar" runat="server" OnClientClick ="return Confirmacion()" Text="Enviar Rendimiento" OnClick="BtnEnviar_Click" Visible="False" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" Visible="False" OnClick="BtnCancelar_Click" /></div>
</asp:Content>
