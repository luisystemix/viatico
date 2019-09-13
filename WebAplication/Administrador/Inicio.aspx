<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebAplication.Administrador.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <link href="../css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            //debugger;
            $('#MainContent_TxtInicio,#MainContent_TxtFinal').datepicker({
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
        CAMPAÑAS AGRICOLAS EMAPA</div>
    <table class="TableBorder">
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td width="120">
                <asp:LinkButton ID="LnkIniciar" runat="server" OnClick="LnkIniciar_Click" Visible="False">Iniciar Campaña</asp:LinkButton>
            </td>
        </tr>
    </table>
           <asp:Panel ID="Panel2" runat="server" Visible="False">
               <table class="TableBorder">
                   <tr>
                       <td width="80">Campaña:</td>
                       <td width="150">
                           <asp:DropDownList ID="DDLCamp" runat="server">
                               <asp:ListItem>VERANO</asp:ListItem>
                               <asp:ListItem>INVIERNO</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td width="40"></td>
                       <td width="80"></td>
                       <td width="40"></td>
                       <td width="130"></td>
                       <td></td>
                   </tr>
                   <tr>
                       <td>Region:</td>
                       <td>
                           <asp:DropDownList ID="DDLRegion" runat="server">
                               <asp:ListItem>ORIENTE</asp:ListItem>
                               <asp:ListItem>OCCIDENTE</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td>Inicio:</td>
                       <td>
                           <asp:TextBox ID="TxtInicio" runat="server" Width="70px"></asp:TextBox>
                       </td>
                       <td>Final:</td>
                       <td>
                           <asp:TextBox ID="TxtFinal" runat="server" Width="70px"></asp:TextBox>
                       </td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td colspan="2">
                           <asp:Button ID="BtnGeneraCamp" runat="server" Text="Generar" OnClick="BtnGeneraCamp_Click" />
                       </td>
                       <td colspan="4">
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtInicio" ErrorMessage="Error Fecha" style="color: #CC0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtFinal" ErrorMessage="Error Fecha" style="color: #CC0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
                       </td>
                       <td></td>
                   </tr>
               </table>
    </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" style="margin-bottom: 0px" Visible="False">
                <div class="SubTitulo2">
                    PARAMETROS DE LA CAMPAÑA
                    <asp:Label ID="LblCamp" runat="server" style="font-weight: 700"></asp:Label>
                    <asp:Label ID="LblIdCamp" runat="server" Visible="False"></asp:Label>
                </div>
                <table class="TableBorder">
                    <tr>
                        <td width="120">Programa:</td>
                        <td width="100">
                            <asp:DropDownList ID="DDLProg" runat="server">
                                <asp:ListItem>ARROZ</asp:ListItem>
                                <asp:ListItem>MAIZ</asp:ListItem>
                                <asp:ListItem>SOJA</asp:ListItem>
                                <asp:ListItem>TRIGO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="125">Tipo de Produccion:</td>
                        <td width="150">
                            <asp:DropDownList ID="DDLTipoProd" runat="server">
                                <asp:ListItem>PEQUEÑO</asp:ListItem>
                                <asp:ListItem>MEDIANO</asp:ListItem>
                                <asp:ListItem Value="GRANDE">GRANDE</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Hectareas Minimo:</td>
                        <td>
                            <asp:TextBox ID="TxtHmin" runat="server" Width="60px"></asp:TextBox>
                        </td>
                        <td>Hectareas Maximo:</td>
                        <td>
                            <asp:TextBox ID="TxtHmax" runat="server" Width="60px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="BtnRegistrarCamp" runat="server" OnClick="BtnRegistrarCamp_Click" Text="Registrar" />
                        </td>
                        <td colspan="5">
                            <asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
            <asp:GridView ID="GVCampaniha" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVCampaniha_RowCommand" Visible="False">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Fecha_Inicio" HeaderText="Inicio" Visible="False" />
                <asp:BoundField DataField="Fecha_Final" HeaderText="Final" Visible="False" />
                <asp:BoundField DataField="Region" HeaderText="Region" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="Id_Campanhia" HeaderText="Id_Campanhia" />
                <asp:ButtonField Text="Agrear Programa" CommandName="Parametro" >
                <ItemStyle Width="100px" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
    <div class="SubTitulo2">HISTORIAL</div>
    <asp:GridView ID="GVCampanihaParam" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Fecha_Inicio" HeaderText="Fecha Inicio" />
            <asp:BoundField DataField="Fecha_Final" HeaderText="Fecha Final" />
            <asp:BoundField DataField="Region" HeaderText="Region" />
            <asp:BoundField DataField="Tipo_Produccion" HeaderText="Tipo_Produccion" />
            <asp:BoundField DataField="Has_Min" HeaderText="Has_Min" />
            <asp:BoundField DataField="Has_Max" HeaderText="Has_Max" />
            <asp:BoundField DataField="Programa" HeaderText="Programa" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" />
            <asp:ButtonField Text="Detalle" >
            <ItemStyle Width="40px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
