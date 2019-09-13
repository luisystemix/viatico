<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFaseFenTrigo.aspx.cs" Inherits="WebAplication.Extensiones.frmFaseFenTrigo" %>
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
                height: "180", // height not including margins, borders or padding
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
<style type="text/css">
    .auto-style1 {
        height: 27px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        SEGUIMIENTO DEL CULTIVO DE TRIGO FASE FENOLÓGICA</div>
    <table class="TableBorder">
        <tr>
            <td width="60">&nbsp;</td>
            <td>&nbsp;</td>
            <td width="60">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblProg" runat="server">TRIGO</asp:Label>
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="140">Organizacion:</td>
            <td colspan="5">
                <asp:Label ID="LblOrg" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsOrg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <div style="text-align: right">N° Seguimiento:</div>
            </td>
            <td>
                <asp:DropDownList ID="DDLNumSeg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLNumSeg_SelectedIndexChanged" Enabled="False">
                </asp:DropDownList>
                <asp:Label ID="LblNumSeg" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">N° Boletas de Inspección:</td>
            <td class="auto-style1">
                <asp:TextBox ID="TxtBoletasFisicas" runat="server" Width="30px" CssClass="textoFondoCen"></asp:TextBox>
            </td>
            <td width="20" class="auto-style1"></td>
            <td width="120" class="auto-style1">Hubo charla técnica:</td>
            <td width="80" class="auto-style1">
                <asp:DropDownList ID="DDLHuboCharla" runat="server" CssClass="textoFondoCen">
                    <asp:ListItem>NO</asp:ListItem>
                    <asp:ListItem>SI</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="110" class="auto-style1"></td>
            <td width="40" class="auto-style1"></td>
            <td width="110" class="auto-style1"></td>
            <td class="auto-style1">Del:&nbsp;
                <asp:TextBox ID="TxtFechaIni" runat="server" CssClass="myDatePickerClass1" Width="70px" AutoPostBack="True" OnTextChanged="TxtFechaIni_TextChanged"></asp:TextBox>
&nbsp;- al:&nbsp;
                <asp:Label ID="LblFechaFin" runat="server" style="font-weight: 700; color: #003366"></asp:Label>
                </td>
            <td class="auto-style1">(Por semana)</td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>N° Boletas por Monitoreo:</td>
            <td>
                <asp:TextBox ID="TxtBoletasMonitoreo" runat="server" CssClass="textoFondoCen" Width="30px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>Superficie Inscrita:</td>
            <td>
                <asp:TextBox ID="TxtSupAct" runat="server" Width="50px" CssClass="textoFondoCen">0</asp:TextBox>
                ha</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblFechaAUX" runat="server" style="font-weight: 700; color: #000066; font-size: small"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblSuma" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>N° Beneficiarios Vigentes:</td>
            <td>
                <asp:TextBox ID="TxtNumBenefVig" runat="server" Width="30px" CssClass="textoFondoCen"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>Superficie Apoyada:</td>
            <td>
                <asp:TextBox ID="TxtSupApo" runat="server" Width="50px" Enabled="False" CssClass="textoFondoCen">0</asp:TextBox>
                </td>
            <td>Pp semanal en mm:</td>
            <td>
                <asp:TextBox ID="TxtPPmm" runat="server" Width="30px" CssClass="textoFondoCen"></asp:TextBox>
            </td>
            <td>Variedad de semilla:</td>
            <td>
                <asp:TextBox ID="TxtVariedadSem" runat="server" Width="250px" CssClass="textoFondoIzq"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="13">
                <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="color: #CC0000; font-weight: 700"></asp:Label></div>
            </td>
        </tr>
    </table>
   
    <table class="TableBorder">
        <tr>
            <td colspan="4"><div style="font-size: xx-small; font-weight: 700; text-align: center;">FECHA Y AVANCE DE SIEMBRA</div></td>
            <td colspan="8"><div style="text-align: center; font-weight: 700; font-size: xx-small;">ETAPA FENOLOGOCA EN %</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">COSECHA Y ACOPIO</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">FECHA COSECHA PROBABLE</div></td>
        </tr>
        <tr>
            <td width="70"><div style="font-size: xx-small; text-align: center;">F inicial</div></td>
            <td width="70"><div style="font-size: xx-small; text-align: center;">F final</div></td>
            <td width="45"><div style="font-size: xx-small; text-align: center;">%Avance</div></td>
            <td width="60"><div style="font-size: xx-small; text-align: center;">Sup. (ha) sembrada</div></td>
            <td width="40" style="width: 80px"><div style="font-size: xx-small; text-align: center;">Germinacion Emergencia</div></td>
            <td width="40" style="width: 80px"><div style="font-size: xx-small; text-align: center;">Plantula</div></td>
            <td width="40" style="width: 80px"><div style="font-size: xx-small; text-align: center;">Macollamiento</div></td>
            <td width="40" style="width: 80px"><div style="font-size: xx-small; text-align: center;">Embuche</div></td>
            <td width="40" style="width: 80px"><div style="font-size: xx-small; text-align: center;">Espigazón</div></td>
            <td width="40" style="width: 80px"><div style="font-size: xx-small; text-align: center;">Floración</div></td>
            <td width="40" style="width: 80px"><div style="font-size: xx-small; text-align: center;">Llenado Grano</div></td>
            <td width="40" style="width: 75px"><div style="font-size: xx-small; text-align: center;">Maduración</div></td>
            <td width="45"><div style="font-size: xx-small; text-align: center;">Avance%</div></td>
            <td class="auto-style1" width="50"><div style="font-size: xx-small; text-align: center;">Rnd fn/ha</div></td>
            <td class="auto-style2"><div style="font-size: xx-small; text-align: center;">F Inicial</div></td>
            <td width="70"><div style="font-size: xx-small; text-align: center;">F Final</div></td>
        </tr>
        <tr>
            <td width="70"><div style="text-align: center"><asp:Label ID="LblFIniSiem" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div></td>
            <td width="70"><div style="text-align: center"><asp:Label ID="LblFFinSiem" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div></td>
            <td width="45">
                <div style="text-align: center"><asp:Label ID="LblAvnSiem" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblSupSem" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40" style="width: 80px">
                <div style="text-align: center"><asp:Label ID="LblGer1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40" style="width: 80px">
                <div style="text-align: center"><asp:Label ID="LblPlant1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40" style="width: 80px">
                <div style="text-align: center"><asp:Label ID="LblMacolla1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40" style="width: 80px">
                <div style="text-align: center"><asp:Label ID="LblEmbu1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40" style="width: 80px">
                <div style="text-align: center"><asp:Label ID="LblEspi1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40" style="width: 80px">
                <div style="text-align: center"><asp:Label ID="LblFlora1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40" style="width: 80px">
                <div style="text-align: center"><asp:Label ID="LblGrano1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40" style="width: 75px">
                <div style="text-align: center"><asp:Label ID="LblMadura1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblCosAco1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblCosAco2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td class="auto-style2">
                <div style="text-align: center"><asp:Label ID="LblFcosechaIni" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div>
            </td>
            <td width="70">
                <div style="text-align: center"><asp:Label ID="LblFcosechaFin" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div>
            </td>
        </tr>
        <tr>
            <td width="70">&nbsp;</td>
            <td width="70">&nbsp;</td>
            <td width="45">
                &nbsp;</td>
            <td width="40">
                &nbsp;</td>
            <td width="40" style="width: 80px">
                &nbsp;</td>
            <td width="40" style="width: 80px">
                &nbsp;</td>
            <td width="40" style="width: 80px">
                &nbsp;</td>
            <td width="40" style="width: 80px">
                &nbsp;</td>
            <td width="40" style="width: 80px">
                &nbsp;</td>
            <td width="40" style="width: 80px">
                &nbsp;</td>
            <td width="40" style="width: 80px">
                &nbsp;</td>
            <td width="40" style="width: 75px">
                &nbsp;</td>
            <td width="40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td width="70">
                &nbsp;</td>
        </tr>
        </table>
   
    <table class="TableBorder">
        <tr>
            <td>Observaciones: (Estado del cultivo, siembra, precencia de plagas, uso de insumio, cosecha, acopio , etc..)</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TxtObserv" runat="server" TextMode="MultiLine" CssClass="cleditorToolbar" Height="80px" Width="99.5%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="text-align: center"><asp:Button ID="BtnEnviar" runat="server" OnClientClick ="return Confirmacion()" Text="Enviar Reporte de la Fase Fenologica" OnClick="BtnEnviar_Click" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" /></div>
</asp:Content>
