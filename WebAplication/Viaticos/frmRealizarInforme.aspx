<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRealizarInforme.aspx.cs" Inherits="WebAplication.Viaticos.frmRealizarInforme" ValidateRequest="false" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../AcopioSilos/jquery.cleditor.js" type="text/javascript"></script>
    <link href="../AcopioSilos/jquery.cleditor.css" rel="stylesheet" />    
    <script type="text/javascript">
        //$.cleditor.defaultOptions.width = '100%';
        //$.cleditor.defaultOptions.height = 100;
        $(document).ready(
            function ()
            {
             var $inputs = $(".myDatePickerClass");
             $inputs.cleditor({
                 width: "95%", // width not including margins, borders or padding
                 height: "130", // height not including margins, borders or padding
                 controls:     // controls to add to the toolbar
                 "bold italic underline strikethrough subscript superscript | font size " +
                 "style | color highlight removeformat | bullets numbering | outdent " +
                 "indent | alignleft center alignright justify | undo redo | " +
                 "rule image link unlink",
             });
             $("#MainContent_TxtConclucion,#MainContent_TxtObjetivo,#MainContent_TxtRecomendacion,#MainContent_TxtObservacion").cleditor({
                 width: "80%", // width not including margins, borders or padding
                 height: "100", // height not including margins, borders or padding
             });
            });

        function Confirmacion() {

            var seleccion = confirm("Está seguro de Guardar datos del Informe...?");

            return seleccion;
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 40px;
        }
        .auto-style2 {
            font-size: 17px;
            font-weight: bold;
            color: #666;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="auto-style2">
        INFORME DE VIAJE</div>
    <table class="TableBorder">
        <tr>
            <td width="85"><strong>Fecha Salida:</strong></td>
            <td width="150">
                <asp:Label ID="LblFechaSalida" runat="server"></asp:Label>
            </td>
            <td width="80">&nbsp;</td>
            <td class="resaltaValor">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
            <td width="60"><strong>Solicitud:</strong></td>
            <td width="140" style="width: 190px">
                <asp:Label ID="LblIdSolicitud" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Fecha Retorno:</strong></td>
            <td>
                <asp:Label ID="LblFechaRetorno" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="LblDirigidoA" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblIdInf" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblEstadoInf" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td class="SubTitulo2">OBJETIVO DE VIAJE:</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TxtObjetivo" runat="server" TextMode="MultiLine"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td class="SubTitulo2">
                ACTIVIDADES REALIZADAS:</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" CssClass="TableBorder">
                    <ItemTemplate>
                        <strong>FechaDia:</strong>
                        <asp:Label ID="FechaDiaLabel" runat="server" Text='<%# Eval("FechaDia") %>' />
                        <br />
                        <asp:TextBox ID="TxtObjetivos" CssClass="myDatePickerClass" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EMAPAConnectionString %>" SelectCommand="SELECT     VIAT_PLANILLA_DIA.Cont, CONVERT(char(10),VIAT_PLANILLA_DIA.FechaDia,103) AS 'FechaDia', CONVERT(char(10),VIAT_PLANILLA_DIA.FechaDia,108) AS 'Hora', VIAT_PLANILLA_DIA.Area, 
                      VIAT_PLANILLA_DIA.Destino, VIAT_PLANILLA_DIA.Num_Dias, VIAT_PLANILLA_DIA.Monto, VIAT_PLANILLA_DIA.Observacion
FROM         VIAT_PLANILLA INNER JOIN
                      VIAT_PLANILLA_DIA ON VIAT_PLANILLA.Id_Planilla = VIAT_PLANILLA_DIA.Id_Planilla
WHERE VIAT_PLANILLA.Id_Solicitud = @Id_Solicitud ORDER BY VIAT_PLANILLA_DIA.FechaDia">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="LblIdSolicitud" Name="Id_Solicitud" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td><div class="SubTitulo2">CONCLUSIÓN</div></td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td>
                <asp:TextBox ID="TxtConclucion" runat="server" TextMode="MultiLine"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td class="SubTitulo2">
                RECOMENDACIÓN</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:TextBox ID="TxtRecomendacion" runat="server" TextMode="MultiLine"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <div style="text-align: center"><asp:Button ID="BtnRegistrar" runat="server" OnClientClick="Confirmacion()" OnClick="BtnRegistrar_Click" Text="Guardar  Informe" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" /></div>
    </asp:Content>
