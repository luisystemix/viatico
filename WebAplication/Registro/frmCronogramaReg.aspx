<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCronogramaReg.aspx.cs" Inherits="WebAplication.Registro.frmCronogramaReg" %>
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
    <div class="SubTitulo">DEFINIR CRONOGRAMA DE LA CAMPAÑA AGRÍCOLA</div>
    <table class="TableBorder">
        <tr>
            <td width="70">Regional:</td>
            <td>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="70">Campaña:</td>
            <td width="130">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblPrograma" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
    <div style="text-align: center; font-weight: 700; color: #CC0000"><asp:Label ID="LblMsj" runat="server" style="text-align: center"></asp:Label></div>
    <asp:GridView ID="GVActividades" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
        <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="N°" />
            <asp:BoundField DataField="Actividad" HeaderText="Actividad" />
            <asp:TemplateField HeaderText="Inicio">
                <ItemTemplate>
                    <asp:TextBox ID="TxtInicio" CssClass="myDatePickerClass" runat="server" Width="100px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Final">
                <ItemTemplate>
                    <asp:TextBox ID="TxtFinal" CssClass="myDatePickerClass" runat="server" Width="100px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnRegistrar" runat="server" Text="Enviar Cronograma" OnClick="BtnRegistrar_Click" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
    </asp:Content>
