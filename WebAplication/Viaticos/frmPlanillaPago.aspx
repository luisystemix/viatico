<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPlanillaPago.aspx.cs" Inherits="WebAplication.Viaticos.frmPlanillaPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/validar.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             //debugger;
             $('#MainContent_TxtFecha').datepicker({
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

         function Confirmacion() {
             var seleccion = confirm("¿Está seguro de procesar la planilla para pago?, tenga en cuenta que el proceso No se revierte");
             return seleccion;
         }
  </script> 
    <style type="text/css">
        .auto-style1 {
            height: 19px;
        }
        .auto-style2 {
            width: 72px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        PLANILLA DE PAGO</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Nombre:</td>
            <td>
                <asp:Label ID="LblNombre" runat="server"></asp:Label>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="90">Meno N°:</td>
            <td>
                <asp:Label ID="LblIdSolicitud" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td width="20">&nbsp;</td>
            <td>
                <asp:Label ID="LblEstado" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Cargo:</td>
            <td>
                <asp:Label ID="LblCargo" runat="server"></asp:Label>
            </td>
            <td></td>
            <td>Fecha Salida:</td>
            <td>
                <asp:Label ID="LblFechaSalida" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            </td>
            <td></td>
            <td rowspan="2">
                <div style="text-align: right"><asp:ImageButton ID="ImgBtnPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" OnClick="ImgBtnPrint_Click" Width="30px" /></div>
            </td>
        </tr>
        <tr>
            <td>Destino:</td>
            <td>
                <asp:Label ID="LblDestino" runat="server"></asp:Label>
            </td>
            <td></td>
            <td>Fecha Retorno:</td>
            <td>
                <asp:Label ID="LblFechaRetorno" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
             <div style="text-align: center; font-weight: 700; color: #FF0000"><asp:Label ID="LblMsj" runat="server"></asp:Label></div>
    <table class="TableBorder">
        <tr>
            <td class="TableBorder">DETALLE DE DIAS EN COMISIÓN</td>
        </tr>
    </table>
    <asp:GridView ID="GVDetallePlanilla" runat="server" 
                  AutoGenerateColumns="False" CssClass="TableBorder" 
                  OnRowDataBound="GVDetallePlanilla_RowDataBound" >
        <Columns>
            <asp:BoundField HeaderText="N°" DataField="Cont" >
            <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Fecha" DataField="FechaDia" >
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Hora" DataField="Hora" >
            <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Área">
                <ItemTemplate>
                    <asp:DropDownList ID="DDLZona" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLZona_SelectedIndexChanged">
                        <asp:ListItem>Interdepartamental</asp:ListItem>
                        <asp:ListItem>Al interior del Departamento</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
<asp:BoundField HeaderText="Destino" DataField="Destino"></asp:BoundField>
            <asp:TemplateField HeaderText="N° Dias">
                <ItemTemplate>
                    <div onkeypress="return AceptaNumeroD(event);">
                    <asp:TextBox ID="TxtNumDias" runat="server" AutoPostBack="True" OnTextChanged="TxtNumDias_TextChanged" Width="40px"></asp:TextBox>
                    </div>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="Monto" DataField="Monto" DataFormatString="{0:#,#.00}" >
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Observación">
                <ItemTemplate>
                    <asp:TextBox ID="TxtObser" runat="server" Width="300px" TextMode="MultiLine"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="250px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td width="70" class="auto-style1">Total Dias:</td>
            <td class="auto-style1">
                <asp:Label ID="LblTotDias" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td colspan="4" class="auto-style1">Monto en
                <asp:Label ID="LblMoneda" runat="server" style="font-weight: 700"></asp:Label>
                : <asp:Label ID="LblMemoNum" runat="server"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>Categoria:</td>
            <td>
                <asp:Label ID="LblCategoria" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>Día Urbano:<asp:Label ID="LblPgoDiaUrbano" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td width="100">
                &nbsp;</td>
            <td>Día Rural:<asp:Label ID="LblPgoDiaRural" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td width="40">
                &nbsp;</td>
            <td></td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td class="SubTitulo2">DETALLE DE PAGO POR VIATICO</td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>Monto</td>
            <td>Dias de Comisión:</td>
            <td>Total Viaticos</td>
            <td class="auto-style2">&nbsp;</td>
            <td>Liquido Pagable</td>
            <td width="110">&nbsp;</td>
        </tr>
        <tr>
            <td>
                100%</td>
            <td>
                <asp:Label ID="Lbl100" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblDiasCom" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblTotalMonto" runat="server"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="LblConIVA" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblLiquidoTotal" runat="server">0</asp:Label>
            </td>
            <td>
               <div style="text-align: right"><asp:DropDownList ID="DDLCuenta" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCuenta_SelectedIndexChanged">
                    <asp:ListItem>N° Cheque</asp:ListItem>
                    <asp:ListItem>N° Cuenta</asp:ListItem>
                </asp:DropDownList></div> 
            </td>
        </tr>
        <tr>
            <td>
                70%</td>
            <td>
                <asp:Label ID="Lbl70" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblDiasCom15" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblTotalMonto15" runat="server"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="LblConIVA15" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblLiquidoTotal15" runat="server">0</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtNumCheque" runat="server" Width="110px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>Total a pagar:
                <asp:Label ID="LblTotalPago" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Button ID="BtnAceptar" runat="server" OnClientClick ="return Confirmacion()" Text="Procesar pago" OnClick="BtnAceptar_Click" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" />
</asp:Content>
