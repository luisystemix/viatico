<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNuevoProv.aspx.cs" Inherits="WebAplication.Insumos.frmNuevoProv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.8.2.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js"></script>
    <link href="../css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" />
    <script type="text/javascript">
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

    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        REGISTRO DE PROVEEDOR</div>
    <table class="TableBorder">
        <tr>
            <td width="80">Regional:</td>
            <td>
                <asp:Label ID="LblRegional" runat="server" CssClass="textoFondoIzq"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="130">
                <asp:Label ID="LblCamp" runat="server" CssClass="textoFondoIzq"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblProg" runat="server"></asp:Label>
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td"></td>
        </tr>
        <tr>
            <td class="auto-style1">Insumo:</td>
            <td class="auto-style1">
                <asp:Label ID="LblInsumo" runat="server"></asp:Label>
                </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
    </table>
    <div class="SubTitulo2">
        <br />
        DATOS DE LA EMPRESA DE PROVISIÓN DE MATERIA PRIMA</div>
    <table class="TableBorder">
        <tr>
            <td width="30"></td>
            <td width="145">NIT:<asp:Label ID="LblIdInsProv" runat="server"></asp:Label>
            </td>
            <td width="100">
                <asp:TextBox ID="TxtNIT" runat="server" Width="100px" AutoPostBack="True" OnTextChanged="TxtNIT_TextChanged"></asp:TextBox>
            </td>
            <td width="100">
                &nbsp;</td>
            <td width="20"></td>
            <td width="160">Matricula de comercio N°:</td>
            <td>
                <asp:TextBox ID="TxtMatriculaComer" runat="server" Width="50px"></asp:TextBox>
                <asp:Label ID="LblAux" runat="server"></asp:Label>
                <asp:Label ID="LblEP" runat="server" Text="0"></asp:Label>
            </td>
            <td width="60">
                <asp:LinkButton ID="LnkNuevo" runat="server">[ Nuevo ]</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Razon Social:</td>
            <td colspan="2">
                <asp:TextBox ID="TxtRazonSocial" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>Departamento</td>
            <td>
                <asp:DropDownList ID="DDLDepartamento" runat="server">
                    <asp:ListItem>LA PAZ</asp:ListItem>
                    <asp:ListItem>SANTA CRUZ</asp:ListItem>
                    <asp:ListItem>BENI</asp:ListItem>
                    <asp:ListItem>COCHABAMBA</asp:ListItem>
                    <asp:ListItem>TARIJA</asp:ListItem>
                    <asp:ListItem>POTOSI</asp:ListItem>
                    <asp:ListItem>CHUQUISACA</asp:ListItem>
                    <asp:ListItem>ORURO</asp:ListItem>
                    <asp:ListItem>PANDO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>N° Testimonio Creacion:</td>
            <td>
                <asp:TextBox ID="TxtNumTestim" runat="server" Width="50px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>Fecha de Creación:</td>
            <td colspan="2">
                <asp:TextBox ID="TxtFechCreacion" runat="server" Width="80px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtFechCreacion" ErrorMessage="Error de fecha Dia/Mes/Año" ForeColor="#CC0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Domicilio:</td>
            <td colspan="4">
                <asp:TextBox ID="TxtDomicilio" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="8">
                <div style="text-align: center"><asp:Label ID="LblMsj1" runat="server" style="color: #FF0000; font-weight: 700"></asp:Label></div>
            </td>
        </tr>
    </table>
    <div class="SubTitulo2">DATOS REPRESENTANTE LEGAL</div>
    <table class="TableBorder">
        <tr>
            <td width="30"></td>
            <td width="90">Cedula:</td>
            <td width="230">
                <asp:TextBox ID="TxtCedula" runat="server" Width="80px" AutoPostBack="True" OnTextChanged="TxtCedula_TextChanged"></asp:TextBox>
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
                <asp:Label ID="LblRL" runat="server" Text="0"></asp:Label>
            </td>
            <td width="20">&nbsp;</td>
            <td width="90">&nbsp;</td>
            <td width="220">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Nombre:</td>
            <td>
                <asp:TextBox ID="TxtNombre" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Paterno:</td>
            <td>
                <asp:TextBox ID="TxtPaterno" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>Materno:</td>
            <td>
                <asp:TextBox ID="TxtMaterno" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><strong>REFERENCIA</strong></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">Telefono Fijo:</td>
            <td class="auto-style1">
                <asp:TextBox ID="TxtFijo" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1">Telefono Movil:</td>
            <td class="auto-style1">
                <asp:TextBox ID="TxtMovil" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td colspan="7">
                <div style="text-align: center"><asp:Label ID="LblMsj2" runat="server" style="color: #FF0000; font-weight: 700"></asp:Label></div>
                </td>
        </tr>
    </table>
    <div class="SubTitulo2">DATOS TESTIMONIO DE PODER</div>
    <table class="TableBorder">
        <tr>
            <td width="30"></td>
            <td width="90">N° Testimonio:</td>
            <td width="230">
                <asp:TextBox ID="TxtNumTesti" runat="server"></asp:TextBox>
                <asp:Label ID="LblTP" runat="server" Text="0"></asp:Label>
            </td>
            <td width="20">&nbsp;</td>
            <td width="90">Fecha:</td>
            <td colspan="2">
                <asp:TextBox ID="TxtFechaTetim" runat="server" Width="80px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtFechaTetim" ErrorMessage="Error de fecha Dia/Mes/Año" ForeColor="#CC0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
            </td>
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
                <div style="text-align: center"><asp:Label ID="LblMsj3" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label></div>
                </td>
        </tr>
    </table>
    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrar_Click" />
    <asp:Button ID="Button2" runat="server" Text="Cancelar" />
</asp:Content>
