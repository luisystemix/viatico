<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNuevaOrg.aspx.cs" Inherits="WebAplication.Registro.frmNuevaOrg" %>
<%@ Register src="contEncabezado1.ascx" tagname="contEncabezado1" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.24.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/validar.js"></script>
    <link href="../css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" />
    <script type="text/javascript">
        //
        function validaFechaDDMMAAAA(fecha)
        {
            return /^(0[1-9]|[12]\d|3[01])\/(0[1-9]|1[0-2])\/(19|20)\d{2}$/.test(fecha);
        }
        //
        //*** Este Codigo permite Validar que sea un campo Numerico
        function Solo_Numerico(variable) {
            Numer = parseInt(variable);
            if (isNaN(Numer)) {
                return "";
            }
            return Numer;
        }
        function ValNumero(Control) {
            Control.value = Solo_Numerico(Control.value);
        }
        //

        $(document).ready(function () {
            //debugger;
            $('#MainContent_TxtFechCreacion,#MainContent_TxtFechaTetim').datepicker({
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
    <div class="SubTitulo">REGISTRÓ DE NUEVA ORGANIZACIÓN</div>
    <uc1:contEncabezado1 ID="contEncabezado11" runat="server" />
    <div class="SubTitulo2">DATOS DE LA ORGANIZACIÓN</div>
    
    <table class="TableBorder">
        <tr>
            <td width="30" class="auto-style1">&nbsp;</td>
            <td width="160" class="auto-style1">Tipo de Produccion:</td>
            <td width="350">
                <asp:DropDownList ID="DDLTipProd" runat="server">
                </asp:DropDownList>
                </td>
            <td class="auto-style3" width="10">&nbsp;</td>
            <td width="40" class="auto-style1">&nbsp;</td>
            <td width="170" class="auto-style1">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
            <td width="60" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td width="160" class="auto-style1">Departamento:</td>
            <td class="auto-style1">
                <asp:DropDownList ID="DDLDepartamento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLDepartamento_SelectedIndexChanged">
                    <asp:ListItem Value="0">BUSCAR --?--</asp:ListItem>
                    <asp:ListItem Value="LA PAZ">LA PAZ</asp:ListItem>
                    <asp:ListItem Value="SANTA CRUZ">SANTA CRUZ</asp:ListItem>
                    <asp:ListItem Value="BENI">BENI</asp:ListItem>
                    <asp:ListItem Value="COCHABAMBA">COCHABAMBA</asp:ListItem>
                    <asp:ListItem Value="TARIJA">TARIJA</asp:ListItem>
                    <asp:ListItem Value="SUCRE">SUCRE</asp:ListItem>
                    <asp:ListItem Value="POTOSI">POTOSI</asp:ListItem>
                    <asp:ListItem Value="ORURO">ORURO</asp:ListItem>
                    <asp:ListItem Value="PANDO">PANDO</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="LblAux" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="LblIdOrg" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="LblEstadoO" runat="server" Text="noorg" Visible="False"></asp:Label>
                </td>
            <td class="auto-style3" width="10"></td>
            <td width="40" class="auto-style1"></td>
            <td width="170" class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td width="60" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Sigla Organización:</td>
            <td>
                <asp:TextBox ID="TxtSigla" runat="server" onKeyUp="toUpper(this)" Width="250px"></asp:TextBox>
                <asp:DropDownList ID="DDLSigla" runat="server" Visible="False" OnSelectedIndexChanged="DDLSigla_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                <asp:LinkButton ID="LnkNuevaOrg" runat="server" OnClick="LnkNuevaOrg_Click">[ Nuevo ]</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Personeria Juridica:</td>
            <td>
                <asp:TextBox ID="TxtPersonJuridi" runat="server" onKeyUp="toUpper(this)" Width="300px"></asp:TextBox>
            </td>
            <td></td>
            <td>Tipo:</td>
            <td>
                <asp:DropDownList ID="DDLTipoOrg" runat="server">
                    <asp:ListItem>COMUNIDAD</asp:ListItem>
                    <asp:ListItem>OTB</asp:ListItem>
                    <asp:ListItem>ASOCIACION</asp:ListItem>
                    <asp:ListItem>COOPERATIVA</asp:ListItem>
                    <asp:ListItem>CENTRAL CAMPESINA</asp:ListItem>
                    <asp:ListItem>SINDICATO AGRARIO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Resolucion Prefectural N°:</td>
            <td>
                <asp:TextBox ID="TxtNumResolucion" runat="server" onKeyUp="toUpper(this)" Width="100px"></asp:TextBox>
            </td>
            <td class="auto-style2">&nbsp;</td>
            <td>Fecha:</td>
            <td>
                <asp:TextBox ID="TxtFechCreacion" runat="server" onkeyUp="return validaFechaDDMMAAAA(this);" Width="70px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtFechCreacion" ErrorMessage="Error Fecha" style="color: #CC0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Domicilio:</td>
            <td>
                <asp:TextBox ID="TxtDomicilio" runat="server" onKeyUp="toUpper(this)" Width="300px"></asp:TextBox>
            </td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="9">
                <div style="text-align: center"><asp:Label ID="LblMsj1" runat="server"></asp:Label></div>
            </td>
        </tr>
    </table>    
    <div class="SubTitulo2">DATOS REPRESENTANTE LEGAL</div>
    
    <table class="TableBorder">
        <tr>
            <td width="30">&nbsp;</td>
            <td width="100">Cedula:</td>
            <td class="auto-style4" width="250">
                <asp:TextBox ID="TxtCedula" runat="server" onkeyUp="return ValNumero(this);" Width="80px" OnTextChanged="TxtCedula_TextChanged" AutoPostBack="True"></asp:TextBox>
&nbsp;Ext:
                <asp:DropDownList ID="DDLExt" runat="server">
                    <asp:ListItem>LP</asp:ListItem>
                    <asp:ListItem>SC</asp:ListItem>
                    <asp:ListItem>CB</asp:ListItem>
                    <asp:ListItem>PT</asp:ListItem>
                    <asp:ListItem>BN</asp:ListItem>
                    <asp:ListItem>OR</asp:ListItem>
                    <asp:ListItem>CH</asp:ListItem>
                    <asp:ListItem>TJ</asp:ListItem>
                    <asp:ListItem>PN</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="10">&nbsp;</td>
            <td width="110">&nbsp;</td>
            <td width="220">
                <asp:Label ID="LblEstadoP" runat="server" Text="noper" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">Nombre:</td>
            <td class="auto-style7">
                <asp:TextBox ID="TxtNombre" runat="server" onKeyUp="toUpper(this)" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">Primer Apellido:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtPaterno" runat="server" onKeyUp="toUpper(this)" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1">Segundo Apellido:</td>
            <td class="auto-style1">
                <asp:TextBox ID="TxtMaterno" runat="server" onKeyUp="toUpper(this)" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="SubTitulo2">&nbsp;</td>
            <td class="SubTitulo2">REFERENCIA:</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblFechaNac" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Telefono Fijo:</td>
            <td class="auto-style4">
                <asp:TextBox ID="TxtFijo" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>Movil:</td>
            <td>
                <asp:TextBox ID="TxtMovil" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="9">
                <div style="text-align: center"><asp:Label ID="LblMsj2" runat="server"></asp:Label></div>
            </td>
        </tr>
        </table>
    <div class="SubTitulo2">DATOS TESTIMONIO DE PODER</div>
    
    <table class="TableBorder">
        <tr>
            <td width="30">&nbsp;</td>
            <td width="100">Testimonio N°:</td>
            <td width="180">
                <asp:TextBox ID="TxtNumTesti" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td width="90">Fecha:</td>
            <td>
                <asp:TextBox ID="TxtFechaTetim" runat="server" Width="70px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtFechaTetim" ErrorMessage="Error Fecha" style="color: #CC0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
                <asp:Label ID="LblEstadoTP" runat="server" Text="notp"></asp:Label>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td width="30">&nbsp;</td>
            <td width="100">Notaría N°:</td>
            <td width="200">
                <asp:TextBox ID="TxtNumNotario" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td>Distrito judicial:</td>
            <td>
                <asp:TextBox ID="TxtDistritoJudi" runat="server" onKeyUp="toUpper(this)" Width="150px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <%--<td width="30">&nbsp;</td>--%>
            <td width="100">Abg. A Cargo:</td>
            <td width="200" colspan="3">
                <asp:TextBox ID="TxtAbogado" runat="server" onKeyUp="toUpper(this)" Width="280px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Tipo de Poder:</td>
            <td>
                <asp:DropDownList ID="DDLTipoPoder" runat="server">
                    <asp:ListItem>ESPECIAL Y SUFICIENTE</asp:ListItem>
                    <asp:ListItem>ESPECIAL</asp:ListItem>
                    <asp:ListItem>SUFICIENTE</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="7">
                <div style="text-align: center"><asp:Label ID="LblMsj3" runat="server"></asp:Label></div>
            </td>
        </tr>
    </table>
    
    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrar_Click" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" />
    
</asp:Content>
