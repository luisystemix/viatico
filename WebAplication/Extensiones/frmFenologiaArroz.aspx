<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFenologiaArroz.aspx.cs" Inherits="WebAplication.Extensiones.frmFenologiaArroz" %>
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
                height: "220", // height not including margins, borders or padding
                controls:     // controls to add to the toolbar
                "bold italic underline strikethrough subscript superscript | font size " +
                "style | color highlight removeformat | bullets numbering | outdent " +
                "indent | alignleft center alignright justify | undo redo | " +
                "rule image link unlink",
            });
            //debugger;
            var $inputs1 = $(".textoFondoDer");
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">SEGUIMIENTO DEL CULTIVO DE ARROZ FASE FENOLÓGICA</div>
    <table class="TableBorder">
        <tr>
            <td width="60">&nbsp;</td>
            <td>&nbsp;</td>
            <td width="60">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblProg" runat="server">ARROZ</asp:Label>
                </td>
            <td>Campaña:</td>
            <td>
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Regional:</td>
            <td>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td>Reporte al:</td>
            <td>
                <asp:Label ID="LblFechaRep" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="140">Organizacion:</td>
            <td colspan="3">
                <asp:Label ID="LblOrg" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsOrg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <div style="text-align: right">N° Seguimiento:</div></td>
            <td>
                <asp:DropDownList ID="DDLNumSeg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLNumSeg_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="LblNumSeg" runat="server" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>N° Boletas de Inspección:</td>
            <td>
                <asp:TextBox ID="TxtNumBoletas" runat="server" Width="30px" Enabled="False" CssClass="textoFondoCen"></asp:TextBox>
            </td>
            <td width="115">Hubo charla técnica:</td>
            <td width="80">
                <asp:DropDownList ID="DDLHuboCharla" runat="server">
                    <asp:ListItem>SI</asp:ListItem>
                    <asp:ListItem>NO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="10">&nbsp;</td>
            <td width="110">&nbsp;</td>
            <td width="40">&nbsp;</td>
            <td width="10">&nbsp;</td>
            <td width="110">&nbsp;</td>
            <td width="110">Desde:&nbsp;
                <asp:TextBox ID="TxtFechaIni" runat="server" CssClass="myDatePickerClass1" Width="70px"></asp:TextBox>
                <asp:Label ID="LblFechaFin" runat="server" style="font-weight: 700; color: #003366"></asp:Label>
&nbsp;- Hasta:&nbsp;
                </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>N° Beneficiarios Vigentes:</td>
            <td>
                <asp:TextBox ID="TxtNumBenefVig" runat="server" Width="30px" Enabled="False" CssClass="textoFondoCen"></asp:TextBox>
            </td>
            <td>Superficie Inscrita:</td>
            <td>
                <asp:TextBox ID="TxtSupAct" runat="server" Width="50px" Enabled="False" CssClass="textoFondoCen">0</asp:TextBox>
                (ha)</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>Superficie Apoyada:</td>
            <td>
                <asp:TextBox ID="TxtSupApo" runat="server" Width="50px" Enabled="False" CssClass="textoFondoCen">0</asp:TextBox>
                (ha)</td>
            <td>&nbsp;</td>
            <td>Pp semanal en mm:</td>
            <td>
                <asp:TextBox ID="TxtPPmm" onkeypress="return NumCheck(event, this)" runat="server" Width="30px" CssClass="textoFondoCen"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                Variedad de semilla:</td>
            <td>
                <asp:TextBox ID="TxtVariedadSem" runat="server" Width="250px" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="13"><div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="color: #CC0000; font-weight: 700"></asp:Label></div></td>
        </tr>
    </table>
   
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td colspan="4"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Fecha y Avance de Siembra</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Germinacion Emergencia 
                <br />
                (S3-V1)</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Plantula 
                <br />
                (V2-V5)</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Macollamiento (V6-V13)</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Panicula<br />
                (R0-R3)</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Floracion<br />
                (R4-R5)</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Grano Lechoso<br />
                (R6-R7)</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Maduracion<br />
                (R8-R9)</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Cosecha y acopio</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Fecha cosecha probable</div></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="45">&nbsp;</td>
            <td width="55"><div style="font-size: 6pt; text-align: center;">F inicial</div></td>
            <td width="55"><div style="font-size: 6pt; text-align: center;">F final</div></td>
            <td width="35"><div style="font-size: 6pt; text-align: center">%Avance</div></td>
            <td width="40"><div style="font-size: 6pt; text-align: center;">Sup. (ha) sembrada</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Inicial %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Final %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Inicial %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Final %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Inicial %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Final %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Inicial %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Final %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Inicial %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Final %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Inicial %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Final %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Inicial %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Final %</div></td>
            <td width="30"><div style="font-size: 6pt; text-align: center;">Avance%</div></td>
            <td width="35"><div style="font-size: 6pt; text-align: center;">Rnd fn/ha</div></td>
            <td width="55"><div style="font-size: 6pt; text-align: center;">F Inicial</div></td>
            <td width="55"><div style="font-size: 6pt; text-align: center;">F Final</div></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><div style="font-size: xx-small">
                <strong>Muestra:</strong></div></td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblFIniSiem" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblFFinSiem" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblAvnSiem" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblSupSem" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblGer1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblGer2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblPlant1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblPlant2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblMacolla1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblMacolla2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblPanicula1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblPanicula2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblFlora1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblFlora2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblGrano1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblGrano2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblMadura1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblMadura2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblCosAco1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblCosAco2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblFcosechaIni" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblFcosechaFin" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><div style="font-size: xx-small; font-weight: 700">
                <strong>Global:</strong></div></td>
            <td>
                <asp:TextBox ID="TxtFIniSiem" runat="server" CssClass="textoFondoDer" Width="55px" Font-Size="Smaller">No definido</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtFFinSiem" runat="server" CssClass="textoFondoDer" Width="55px" Font-Size="Smaller">No definido</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtAvnSiem" runat="server" Width="30px" CssClass="textoFondoCen" Font-Size="Smaller" AutoPostBack="True" OnTextChanged="TxtAvnSiem_TextChanged">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtSupSem" runat="server" Width="35px" CssClass="textoFondoCen" Font-Size="Smaller" Enabled="False">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtGer1" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtGer2" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtPlant1" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtPlant2" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TxtMacolla1" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtMacolla2" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtPanicula1" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtPanicula2" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtFlora1" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtFlora2" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtGrano1" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtGrano2" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="TxtMadura1" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtMadura2" runat="server" Width="30px" style="background-color: #FFFFCC" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtCosAco1" runat="server" Width="30px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtCosAco2" runat="server" Width="35px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtFcosechaIni" runat="server" CssClass="textoFondoDer" Width="55px" Font-Size="Smaller">No definido</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtFcosechaFin" runat="server" CssClass="textoFondoDer" Width="55px" Font-Size="Smaller">No definido</asp:TextBox>
            </td>
            <td></td>
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
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
   
    <table class="TableBorder">
        <tr>
            <td>Observaciones: (Estado del cultivo, siembra, precencia de plagas, uso de insumio, cosecha, acopio , etc..)</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TxtObserv" runat="server" CssClass="cleditorToolbar" TextMode="MultiLine" Height="80px" Width="99.5%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="text-align: center"><asp:Button ID="BtnEnviar" runat="server" OnClientClick ="return Confirmacion()" Text="Enviar Reporte de la Face Fenologica" OnClick="BtnEnviar_Click" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" /></div>
</asp:Content>
