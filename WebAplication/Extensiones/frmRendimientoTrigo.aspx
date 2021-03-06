﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRendimientoTrigo.aspx.cs" Inherits="WebAplication.Extensiones.frmRendimientoTrigo" %>
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

     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        RENDIMIENTO DE GRANO DE TRIGO</div>
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
                <asp:Label ID="LblEtapa" runat="server"></asp:Label>
            </td>
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
                <asp:TextBox ID="TxtFechaInspeccion" CssClass="myDatePickerClass1" runat="server" Width="70px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Variedad:</td>
            <td>
                <asp:TextBox ID="TxtVariedad" runat="server" Width="250px"></asp:TextBox>
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
            <td width="145">
                Fase Fenologica:</td>
            <td colspan="3">
                <asp:DropDownList ID="DDLFaceFenologica" runat="server">
                </asp:DropDownList>
            </td>
            <td width="40">&nbsp;</td>
            <td width="80">&nbsp;</td>
            <td width="30">&nbsp;</td>
            <td width="80">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>N° de Espigas por m2:</td>
            <td width="100">
                <asp:TextBox ID="TxtNumEspigas" runat="server" Width="40px" OnTextChanged="TxtNumEspigas_TextChanged" AutoPostBack="True">0</asp:TextBox>
            </td>
            <td width="50">&nbsp;</td>
            <td width="135">N° de Granos por Espiga:</td>
            <td>
                <asp:TextBox ID="TxtNumGranoEspigas" runat="server" Width="40px" OnTextChanged="TxtNumGranoEspigas_TextChanged" AutoPostBack="True">0</asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Peso de 1000 Granos (gr.):</td>
            <td>
                <asp:TextBox ID="TxtPesoMilGranos" runat="server" Width="40px" OnTextChanged="TxtPesoMilGranos_TextChanged" AutoPostBack="True">0</asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>% de Humedad:</td>
            <td>
                <asp:TextBox ID="TxtPorcentHumedad" runat="server" Width="40px">0</asp:TextBox>
            </td>
            <td><div style="text-align: right; font-weight: 700">(Kg/ha):</div></td>
            <td>
                <asp:Label ID="LblKgHect" runat="server">0</asp:Label>
            </td>
            <td><div style="text-align: right; font-weight: 700">(Ton/ha):</div></td>
            <td>
                <asp:Label ID="LblTonHect" runat="server">0</asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="11">
                <div style="text-align: center"><asp:Label ID="LblMsj1" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
            </td>
        </tr>
    </table>
    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar &gt;&gt;" OnClick="BtnRegistrar_Click" />
    <asp:GridView ID="GVRendTrigo" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id_Fenologia" HeaderText="Id_Fenologia" />
            <asp:BoundField DataField="Face_Fenologia" HeaderText="Fase Fenologica" />
            <asp:BoundField DataField="Valor1" HeaderText="N° de Espigas por m2" />
            <asp:BoundField DataField="Valor2" HeaderText="N° de Granos por Espiga" />
            <asp:BoundField DataField="Valor5" HeaderText="Peso de 1000 Granos (gr.)" />
            <asp:BoundField DataField="Valor6" HeaderText="% de Humedad" />
            <asp:BoundField DataField="Valor7" HeaderText="Kg/ha" />
            <asp:BoundField DataField="Valor8" HeaderText="Ton/ha" />
            <asp:ButtonField CommandName="eliminar" Text="eliminar" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnEnviar" runat="server" Text="Enviar Rendimiento" OnClick="BtnEnviar_Click" Visible="False" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" Visible="False" OnClick="BtnCancelar_Click" />
</asp:Content>
