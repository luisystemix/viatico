<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmModificarInforme.aspx.cs" Inherits="WebAplication.Viaticos.frmModificarInforme" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../AcopioSilos/jquery.cleditor.js" type="text/javascript"></script>
    <link href="../AcopioSilos/jquery.cleditor.css" rel="stylesheet" />
    <script type="text/javascript">
        //$.cleditor.defaultOptions.width = '100%';
        //$.cleditor.defaultOptions.height = 100;
        $(document).ready(
            function () {
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
    </script>

        <style type="text/css">
            .auto-style1 {
                font-size: 17px;
                font-weight: bold;
                color: #666;
                text-align: center;
            }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="auto-style1">
        MODIFICAR
        INFORME DE VIAJE</div>
    <table class="TableBorder">
        <tr>
            <td width="85"><strong>Fecha Salida:</strong></td>
            <td width="150">
                <asp:Label ID="LblFechaSalida" runat="server"></asp:Label>
            </td>
            <td width="80">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="50"><strong>Solicitud:</strong></td>
            <td width="100" style="width: 180px">
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
                &nbsp;</td>
            <td>
                <asp:Label ID="LblEstadoInf" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
                
                <table class="TableBorder">
                    <tr>
                        <td class="SubTitulo2">
                            OBJETIVO DEL VIAJE:</td>
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
                        <td>
                            <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" CssClass="TableBorder" DataKeyField="Id_Informe" OnItemDataBound="DataList1_ItemDataBound">
                                <ItemTemplate>
                                    <strong>Fecha:</strong>
                                    <asp:Label ID="FechaLabel" runat="server" Text='<%# Eval("Fecha") %>' />
                                    <br />
                                    <asp:TextBox ID="TxtActividad" CssClass="myDatePickerClass" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <br />
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                    <tr>
                        <td><div class="SubTitulo2">CONCLUSIÓN</div></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TxtConclucion" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubTitulo2">
                            RECOMENDACIÓN:</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TxtRecomendacion" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
    </table>
    <asp:Button ID="BtnRegistrar" runat="server" OnClick="BtnRegistrar_Click" Text="Modificar  Informe" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EMAPAConnectionString %>" SelectCommand="SELECT     VIAT_INFORME.Id_Informe, VIAT_INFORME.Id_Solicitud, Convert(char(12),VIAT_INFORME_ACTIVIDAD.Fecha,103) AS Fecha, VIAT_INFORME_ACTIVIDAD.Actividad, 
                      VIAT_INFORME_ACTIVIDAD.Cont
FROM         VIAT_INFORME INNER JOIN
                      VIAT_INFORME_ACTIVIDAD ON VIAT_INFORME.Id_Informe = VIAT_INFORME_ACTIVIDAD.Id_Informe
WHERE (VIAT_INFORME.Id_Solicitud = @IdSolicitud) ORDER BY VIAT_INFORME_ACTIVIDAD.Fecha">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="LblIdSolicitud" Name="IdSolicitud" PropertyName="Text" />
                    </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
