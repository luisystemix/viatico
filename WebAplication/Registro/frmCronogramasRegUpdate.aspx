<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCronogramasRegUpdate.aspx.cs" Inherits="WebAplication.Registro.frmCronogramasRegUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.24.custom.min.js"></script>
    <link href="../css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" />

    <script type="text/javascript">
        $(function () {
            var $gv = $("table[id$=GVActividades]");
            var $rows = $("> tbody > tr:not(:has(th, table))", $gv);
            var $inputs = $(".myDatePickerClass");

            //$rows.css("background-color", "yellow");

            $inputs.datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: false,
                changeYear: false,
                nextText: 'Siguiente Mes',
                prevText: 'Mes Anterior',
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                montNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic']
            }
                );
        });
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">SEGUIMIENTO AL CRONOGRAMA PLANIFICADO</div><table class="TableBorder">
        <tr>
            <td width="60">Regional:</td>
            <td>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="120">
                <asp:Label ID="LblCampanhia" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblPrograma" runat="server"></asp:Label>
                <asp:Label ID="LblIdCrono" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td rowspan="2">
                <div style="text-align: right"><asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" OnClick="ImageButton1_Click" Visible="False" /></div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVConograma" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowDataBound="GVConograma_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Numero" HeaderText="N°" >
            <ItemStyle Width="20px" />
            </asp:BoundField>
            <asp:BoundField DataField="Actividad" HeaderText="Actividad" />
            <asp:BoundField DataField="Estado_Camp" HeaderText="Estado" />
            <asp:BoundField DataField="Inicio_Planificado" HeaderText="Inicio Planificado" >
            <ItemStyle Width="95px" />
            </asp:BoundField>
            <asp:BoundField DataField="Final_Planificado" HeaderText="Final Planificado" >
            <ItemStyle Width="90px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Inicio Ejecutado">
                <ItemTemplate>
                    <asp:TextBox ID="TxtInicEject" CssClass="myDatePickerClass" runat="server" Width="80px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Final Ejecutado">
                <ItemTemplate>
                    <asp:TextBox ID="TxtFinEject" CssClass="myDatePickerClass" runat="server" Width="80px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Observacion">
                <ItemTemplate>
                    <asp:TextBox ID="TxtObserv" runat="server" Height="30px" TextMode="MultiLine" Width="250px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="250px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnRegistrar" runat="server" Text="Enviar Modificación" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" />
</asp:Content>
