<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFenologiaMaiz.aspx.cs" Inherits="WebAplication.Extensiones.frmFenologiaMaiz" %>
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
    <style type="text/css">
        .auto-style1 {
            width: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        SEGUIMIENTO DEL CULTIVO DE MAIZ FASE FENOLÓGICA</div>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td width="60">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="60">Programa:</td>
            <td>
                <asp:Label ID="LblProg" runat="server"></asp:Label>
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
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
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
            <td>
                <asp:Label ID="LblNumSeg" runat="server"></asp:Label>
            </td>
            <td>
                <div style="text-align: right">N° Seguimiento:</div>
            </td>
            <td>
                <asp:DropDownList ID="DDLNumSeg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLNumSeg_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="LblNumSeg0" runat="server" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>N° Boletas de Inspección:</td>
            <td>
                <asp:TextBox ID="TxtNumBoletas" runat="server" Width="30px" CssClass="textoFondoCen"></asp:TextBox>
            </td>
            <td width="160">Hubo charla técnica:</td>
            <td width="80">
                <asp:DropDownList ID="DDLHuboCharla" runat="server">
                    <asp:ListItem>NO</asp:ListItem>
                    <asp:ListItem>SI</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="110">&nbsp;</td>
            <td width="40">&nbsp;</td>
            <td width="110">&nbsp;</td>
            <td>Desde:&nbsp;
                <asp:TextBox ID="TxtFechaIni" runat="server" CssClass="myDatePickerClass1" Width="70px" AutoPostBack="True" OnTextChanged="TxtFechaIni_TextChanged"></asp:TextBox>
                <asp:Label ID="LblFechaFin" runat="server" style="font-weight: 700; color: #003366"></asp:Label>
&nbsp;- Hasta:&nbsp;
                </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>N° Beneficiarios Vigentes:</td>
            <td>
                <asp:TextBox ID="TxtNumBenefVig" runat="server" Width="30px" CssClass="textoFondoCen"></asp:TextBox>
            </td>
            <td>Superficie Actual de Siembra:</td>
            <td>
                <asp:TextBox ID="TxtSupAct" runat="server" Width="50px" CssClass="textoFondoCen">0</asp:TextBox>
                (ha)</td>
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
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="TxtSupApo" runat="server" Width="50px" Enabled="False" CssClass="textoFondoCen">0</asp:TextBox>
                (ha)</td>
            <td>Pp semanal en mm:</td>
            <td>
                <asp:TextBox ID="TxtPPmm" runat="server" Width="30px" CssClass="textoFondoCen"></asp:TextBox>
            </td>
            <td>Variedad de semilla:</td>
            <td>
                <asp:TextBox ID="TxtVariedadSem" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="10"><asp:Label ID="LblMsj" runat="server" style="color: #CC0000; font-weight: 700"></asp:Label></td>
        </tr>
    </table>
   
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td colspan="3"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Fecha y Avance de Siembra</div></td>
            <td width="50">&nbsp;</td>
            <td width="50"><div style="font-size: xx-small; font-weight: 700; text-align: center;">VE</div></td>
            <td><div style="font-size: xx-small; font-weight: 700; text-align: center;">(V1-V2)</div></td>
            <td><div style="font-size: xx-small; font-weight: 700; text-align: center;">(V3-V4)</div></td>
            <td><div style="font-size: xx-small; font-weight: 700; text-align: center;">(V5-V6)</div></td>
            <td><div style="font-size: xx-small; font-weight: 700; text-align: center;">(V7-V8)</div></td>
            <td><div style="font-size: xx-small; font-weight: 700; text-align: center;">(V9-V10)</div></td>
            <td><div style="font-size: xx-small; font-weight: 700; text-align: center;">(Vn)</div></td>
            <td><div style="font-size: xx-small; font-weight: 700; text-align: center;">(VT-R0)</div></td>
            <td><div style="font-size: xx-small; font-weight: 700; text-align: center;">(R1-R2)</div></td>
            <td><div style="font-size: xx-small; font-weight: 700; text-align: center;">(R3-R4)</div></td>
            <td><div style="font-size: xx-small; font-weight: 700; text-align: center;">(R5-R6)</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Cosecha y acopio</div></td>
            <td colspan="2"><div style="font-size: xx-small; font-weight: 700; text-align: center;">Fecha cosecha probable</div></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="70">&nbsp;</td>
            <td width="70"><div style="font-size: xx-small; text-align: center;">F inicial</div></td>
            <td width="70"><div style="font-size: xx-small; text-align: center;">F final</div></td>
            <td class="auto-style1"><div style="font-size: xx-small; text-align: center;">%Avance</div></td>
            <td width="50"><div style="font-size: 6pt; text-align: center;">Sup. (ha) sembrada</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">Emergencia (5 dias) %</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">1 y 2 hojas Despleg. (12 dias) %</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">3 y 4 hojas Despleg. %</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">5 y 6 hojas Despleg. %</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">7 y 8 hojas Despleg. %</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">9 y 10 hojas Despleg. %</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">11 o más hojas Despleg %</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">Floración Maculina y Polinización %</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">Estigmas Visibles y Ampolla %</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">Grano Lechoso y Masoso %</div></td>
            <td width="60"><div style="font-size: xx-small; text-align: center;">Etapa Dentada y Madurez Ficiologica %</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">Avance%</div></td>
            <td width="50"><div style="font-size: xx-small; text-align: center;">Rnd fn/ha</div></td>
            <td width="75"><div style="font-size: xx-small; text-align: center;">F Inicial</div></td>
            <td width="75"><div style="font-size: xx-small; text-align: center;">F Final</div></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="70"><div style="font-size: xx-small">
                <strong>Muestra:</strong></div></td>
            <td width="70">
                <div style="text-align: center"><asp:Label ID="LblFIniSiem" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div>
            </td>
            <td width="70">
                <div style="text-align: center"><asp:Label ID="LblFFinSiem" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: center"><asp:Label ID="LblAvnSiem" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="LblSupSem" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="LblEmerg" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="Lbl1y2Hojas" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="Lbl3y4Hojas" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="Lbl5y6Hojas" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="Lbl7y8Hojas" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="Lbl9y10Hojas" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="Lbl11oMasHojas" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="LblFloracion" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="LblEstigmas" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="LblGranoLechoso" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="60">
                <div style="text-align: center"><asp:Label ID="LblDentadayMadurez" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="LblCosAco1" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="50">
                <div style="text-align: center"><asp:Label ID="LblCosAco2" runat="server" style="font-size: xx-small" Text="0"></asp:Label></div>
            </td>
            <td width="75">
                <div style="text-align: center"><asp:Label ID="LblFcosechaIni" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div>
            </td>
            <td width="75">
                <div style="text-align: center"><asp:Label ID="LblFcosechaFin" runat="server" style="font-size: xx-small" Text="No definido"></asp:Label></div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <div style="font-size: xx-small; font-weight: 700">
                <strong>Global:</strong></div>
            </td>
            <td>
                <asp:TextBox ID="TxtFIniSiem" runat="server" CssClass="textoFondoDer" Width="55px" Font-Size="Smaller">No definido</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtFFinSiem" runat="server" CssClass="textoFondoDer" Width="55px" Font-Size="Smaller">No definido</asp:TextBox>
            </td>
            <td class="auto-style1">
                <div style="font-size: small"><asp:TextBox ID="TxtAvnSiem" runat="server" Width="40px" CssClass="textoFondoCen" Font-Size="Smaller" OnTextChanged="TxtAvnSiem_TextChanged">0</asp:TextBox></div>
            </td>
            <td>
                <asp:TextBox ID="TxtSupSem" runat="server" Width="35px" CssClass="textoFondoCen" Font-Size="Smaller" Enabled="False">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtEmerg" runat="server" Width="40px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="Txt1y2Hojas" runat="server" Width="40px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="Txt3y4Hojas" runat="server" Width="40px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="Txt5y6Hojas" runat="server" Width="40px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="Txt7y8Hojas" runat="server" Width="40px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="Txt9y10Hojas" runat="server" Width="40px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="Txt11oMasHojas" runat="server" Width="40px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtFloracion" runat="server" Width="43px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtEstigmas" runat="server" Width="40px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtGranoLechoso" runat="server" Width="40px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtDentadayMadurez" runat="server" Width="50px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtCosAco1" runat="server" Width="40px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtCosAco2" runat="server" Width="40px" CssClass="textoFondoCen" Font-Size="Smaller">0</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtFcosechaIni" runat="server" CssClass="textoFondoDer" Width="70px" Font-Size="Smaller">No definido</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TxtFcosechaFin" runat="server" CssClass="textoFondoDer" Width="70px" Font-Size="Smaller">No definido</asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
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
    <asp:Button ID="BtnEnviar" runat="server" Text="Enviar Reporte de la Face Fenologica" OnClick="BtnEnviar_Click" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" />
    </asp:Content>
