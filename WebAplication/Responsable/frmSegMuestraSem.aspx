<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSegMuestraSem.aspx.cs" Inherits="WebAplication.Responsable.frmSegMuestraSem" %>
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
        DOCUMENTOS DEL PROCESO DE VIÁTICOS</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Programa:</td>
            <td>
                <asp:DropDownList ID="DDLProg" runat="server" OnSelectedIndexChanged="DDLProg_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td>&nbsp;</td>
            <td width="60">
                Campaña:</td>
            <td width="160">
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged" style="margin-top: 0px">
                </asp:DropDownList>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="60">Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="120">
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
                </td>
        </tr>
        </table>

    <table class="TableBorder">
        <tr>
            <td width="145">Periodo de evaluacion Del:</td>
            <td>
                <asp:TextBox ID="TxtFechaIni" runat="server" CssClass="myDatePickerClass1" Width="70px" AutoPostBack="True" OnTextChanged="TxtFechaIni_TextChanged"></asp:TextBox>
&nbsp;- al:
                <asp:Label ID="LblFechaFin" runat="server" style="font-weight: 700; color: #003366"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
    <asp:GridView ID="GVSegTec" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVSegTec_RowDataBound">
        <Columns>
            <asp:BoundField DataField="N" HeaderText="N°">
            <ItemStyle Width="20px" />
            </asp:BoundField>
            <asp:BoundField DataField="Id_Usuario" HeaderText="Id_Usuario" Visible="False" />
            <asp:BoundField DataField="Tecnico" HeaderText="Tecnico" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="Muestra" HeaderText="Muestra seleccionada" />
            <asp:ButtonField Text="Button" Visible="False" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Chart ID="Chart1" runat="server" CssClass="TableBorder2" BorderlineDashStyle="DashDot" ClientIDMode="AutoID">
                        <Series>
                            <asp:Series Name="Series1" ChartArea="ChartArea1">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <Position Height="100" Width="100" />
                            </asp:ChartArea>
                        </ChartAreas>
                        <BorderSkin BackImageWrapMode="TileFlipXY" BorderColor="Blue" />
                    </asp:Chart>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
