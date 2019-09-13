<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDistribucionAgroquimico.aspx.cs" Inherits="WebAplication.Extensiones.frmDistribucionAgroquimico" %>
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
                height: "150", // height not including margins, borders or padding
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

        function Confirmacion() {
            var seleccion = confirm("Está seguro de enviar la información registrada…?");
            return seleccion;
        }
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        SEGUIMIENTO A LA DISTRIBUCIÓN DE INSUMOS</div>
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
        <div class="SubTitulo2">DATOS DEL SEGUIMIENTO TÉCNICO REALIZADO</div><table class="TableBorder">
        <tr>
            <td width="125">Nombre del Agricultor:</td>
            <td width="250">
                <asp:Label ID="LblProductor" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsProd" runat="server" Visible="False"></asp:Label>
            </td>
            <td width="120"></td>
            <td width="200">
                <asp:Label ID="LblIdUsuario" runat="server" Visible="False"></asp:Label>
                </td>
            <td width="110">
                </td>
            <td>
                </td>
            <td></td>
        </tr>
        <tr>
            <td>Empresa Proveedora:</td>
            <td>
                <asp:DropDownList ID="DDLProveedor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLProveedor_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>Lugar de Distribución:</td>
            <td>
                <asp:TextBox ID="TxtLugarDistrib" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td>
                Fecha Distribución:</td>
            <td>
                <asp:TextBox ID="TxtFechaDistrib" CssClass="myDatePickerClass1" runat="server" Width="70px"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        </table>
        <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
        <table class="TableBorder">
            <tr>
                <td width="140">N° Boleta Distribucion:</td>
                <td width="200">
                    <asp:TextBox ID="TxtNumBoleta" onKeyPress='return esInteger(event)' runat="server" Width="40px" style="background-color: #FFFFCC"></asp:TextBox>
                </td>
                <td width="100">&nbsp;</td>
                <td width="70">&nbsp;</td>
                <td width="50">&nbsp;</td>
                <td width="60">
                    &nbsp;</td>
                <td width="60">&nbsp;</td>
                <td width="50">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td width="125">Insumo:</td>
                <td width="200">
                    <asp:DropDownList ID="DDLInsumo" runat="server">
                        <asp:ListItem Value="2">AGROQUIMICO</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Producto:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DDLProducto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLProducto_SelectedIndexChanged">
                        <asp:ListItem Value="4">DESECANTES</asp:ListItem>
                        <asp:ListItem Value="5">TRATAMIENTO DE SEMILLA</asp:ListItem>
                        <asp:ListItem Value="6">FUNGICIDAS</asp:ListItem>
                        <asp:ListItem Value="7">HERBICIDAS</asp:ListItem>
                        <asp:ListItem Value="8">INSECTICIDAS</asp:ListItem>
                        <asp:ListItem Value="9">FERTILIZANTES</asp:ListItem>
                        <asp:ListItem Value="10">COADYUVANTES</asp:ListItem>
                        <asp:ListItem Value="15">CONTROL DE MALEZAS</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
                <td>
                    </td>
                <td></td>
                <td>
                    </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Nombre Comercial:</td>
                <td>
                    <asp:DropDownList ID="DDLNomComer" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLNomComer_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtNomComer" runat="server" Visible="False" Width="250px"></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton ID="LnkNuevo" runat="server" OnClick="LnkNuevo_Click">[ Nuevo ]</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Ingrediente Activo:</td>
                <td>
                    <asp:TextBox ID="TxtNomTecnico" runat="server" Width="250px"></asp:TextBox>
                </td>
                <td>Fecha Caducidad:</td>
                <td>
                    <asp:TextBox ID="TxtFechaCaducidad" CssClass="myDatePickerClass1" runat="server" Width="70px"></asp:TextBox>
                </td>
                <td>Cantidad:</td>
                <td>
                    <asp:TextBox ID="TxtCantidad" onKeyPress='return esInteger(event)' runat="server" Width="30px"></asp:TextBox>
                </td>
                <td>Unidad:</td>
                <td>
                    <asp:DropDownList ID="DDLUnidad" runat="server">
                        <asp:ListItem>Kg</asp:ListItem>
                        <asp:ListItem>Lt</asp:ListItem>
                        <asp:ListItem>Ton</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="9">
                    <div style="text-align: center"><asp:Label ID="LblMsj1" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
                </td>
            </tr>
        </table>
        <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar &gt;&gt;" OnClick="BtnRegistrar_Click" />
    <asp:GridView ID="GVDistribAgroQuim" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NumBoleta" HeaderText="N° Boleta" />
            <asp:BoundField DataField="Producto" HeaderText="Producto" />
            <asp:BoundField DataField="NomTec" HeaderText="Ingrediente Activo" />
            <asp:BoundField DataField="NomComer" HeaderText="Nombre Comercial" />
            <asp:BoundField DataField="FechCaducidad" HeaderText="Fecha de Caducidad" />
            <asp:BoundField DataField="Unidad" HeaderText="Unidad" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
        </Columns>
    </asp:GridView>
    <div style="font-weight: 700; color: #CC0000; text-align: center"><asp:Label ID="LblMsj2" runat="server"></asp:Label></div>
    <table class="TableBorder">
        <tr>
            <td><div class="SubTitulo2">Observaciones:</div></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="TxtObser" runat="server" CssClass="cleditorToolbar"  TextMode="MultiLine" Height="80px" Width="98%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="text-align: center"><asp:Button ID="BtnEnviar" runat="server" OnClientClick ="return Confirmacion()" Text="Enviar Seguimiento" OnClick="BtnEnviar_Click" />
    <asp:Button ID="BtnCancel" runat="server" Text="Cancelar" OnClick="BtnCancel_Click" /></div>
</asp:Content>
