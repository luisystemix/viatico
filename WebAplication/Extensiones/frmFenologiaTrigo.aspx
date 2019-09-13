 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFenologiaTrigo.aspx.cs" Inherits="WebAplication.Extensiones.frmFenologiaTrigo" ValidateRequest="false"%>
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
     </script>

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
            <td width="145">Organizacion:</td>
            <td colspan="4">
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
            <td>N° Boletas de Inspección:</td>
            <td>
                <asp:TextBox ID="TxtNumBoletas" runat="server" Width="30px" CssClass="textoFondoCen"></asp:TextBox>
            </td>
            <td width="120">Hubo charla técnica:</td>
            <td width="80">
                <asp:DropDownList ID="DDLHuboCharla" runat="server" CssClass="textoFondoCen">
                    <asp:ListItem>NO</asp:ListItem>
                    <asp:ListItem>SI</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="110">&nbsp;</td>
            <td width="40">&nbsp;</td>
            <td width="110"></td>
            <td>Del:&nbsp;
                <asp:TextBox ID="TxtFechaIni" runat="server" CssClass="myDatePickerClass1" Width="70px" AutoPostBack="True" OnTextChanged="TxtFechaIni_TextChanged"></asp:TextBox>
&nbsp;- al:&nbsp;
                <asp:Label ID="LblFechaFin" runat="server" style="font-weight: 700; color: #003366"></asp:Label>
                </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>N° Boletas por Monitoreo:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textoFondoCen" Width="30px"></asp:TextBox>
            </td>
            <td>Superficie Inscrita:</td>
            <td>
                <asp:TextBox ID="TxtSupAct" runat="server" Width="50px" CssClass="textoFondoCen">0</asp:TextBox>
                ha</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
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
            <td colspan="12">
                <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="color: #CC0000; font-weight: 700"></asp:Label></div>
            </td>
        </tr>
    </table>
   
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td colspan="3"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Fecha y Avance de Siembra</div></td>
            <td>&nbsp;</td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Germinacion Emergencia</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Plantula</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Macollamiento</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Embuche</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Espigazón</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Floración</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Llenado Grano</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Maduración</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Cosecha y acopio</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Fecha cosecha probable</div></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td width="70"><div style="font-size: xx-small; text-align: center;">F inicial</div></td>
            <td width="70"><div style="font-size: xx-small; text-align: center;">F final</div></td>
            <td width="45"><div style="font-size: xx-small; text-align: center;">%Avance</div></td>
            <td width="40"><div style="font-size: 6pt; text-align: center;">Sup. (ha) sembrada</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Inicial %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Final %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Inicial %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Final %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Inicial %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Final %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Inicial %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Final %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Inicial %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Final %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Inicial %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Final %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Inicial %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Final %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Inicial %</div></td>
            <td width="35"><div style="font-size: xx-small; text-align: center;">Final %</div></td>
            <td width="40"><div style="font-size: xx-small; text-align: center;">Avance%</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">Rnd fn/ha</div></td>
            <td width="70"><div style="font-size: xx-small; text-align: center;">F Inicial</div></td>
            <td width="70"><div style="font-size: xx-small; text-align: center;">F Final</div></td>
            <td></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td width="70"><asp:Label ID="LblFIniSiem" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></td>
            <td width="70"><asp:Label ID="LblFFinSiem" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></td>
            <td width="45">
                <div style="text-align: center"><asp:Label ID="LblAvnSiem" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblSupSem" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblGer1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblGer2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblPlant1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblPlant2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblMacolla1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblMacolla2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblEmbu1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblEmbu2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblEspi1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblEspi2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblFlora1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblFlora2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblGrano1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblGrano2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblMadura1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="35">
                <div style="text-align: center"><asp:Label ID="LblMadura2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="40">
                <div style="text-align: center"><asp:Label ID="LblCosAco1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="LblCosAco2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="70">
                <div style="text-align: center"><asp:Label ID="LblFcosechaIni" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div>
            </td>
            <td width="70">
                <div style="text-align: center"><asp:Label ID="LblFcosechaFin" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div>
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td></td>
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
    <div style="text-align: center"><asp:Button ID="BtnEnviar" runat="server" Text="Enviar Reporte de la Fase Fenologica" OnClick="BtnEnviar_Click" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" /></div>
</asp:Content>
