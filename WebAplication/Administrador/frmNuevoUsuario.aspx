<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNuevoUsuario.aspx.cs" Inherits="WebAplication.Administrador.frmNuevoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../js/validar.js" type="text/ecmascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <link href="../Css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../Scripts/validar.js"></script>
        <script type="text/javascript">
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

             $(document).ready(function () {
              //debugger;
              $('#MainContent_TxtFechNac').datepicker({
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
        <asp:Label runat="server" ID="lbltitulo" Text="REGISTRO DE NUEVO USUARIO" Font-Size="16px">
        </asp:Label>
    </div>
    <table class="TableBorder">
        <tr>
            <td width="60" class="auto-style1">&nbsp;</td>
            <td width="60" class="auto-style1">CI:</td>
            <td class="auto-style1" width="300">
                <asp:TextBox ID="TxtCedula" runat="server" onkeyUp="return ValNumero(this);" Width="60px" AutoPostBack="True" OnTextChanged="TxtCedula_TextChanged"></asp:TextBox>
&nbsp;ext:<asp:DropDownList ID="DDLExt" runat="server">
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
            <td width="70" class="auto-style1">Regional:</td>
            <td>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdRegional" runat="server" Visible="False"></asp:Label>
                </td>
            <td></td>
            <td width="60">
                <asp:Label ID="LblEstado" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Nombre:</td>
            <td>
                <asp:TextBox ID="TxtNombre" runat="server" onKeyUp="toUpper(this)" Width="250px"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Paterno:</td>
            <td>
                <asp:TextBox ID="TxtApPat" runat="server" onKeyUp="toUpper(this)" Width="250px"></asp:TextBox>
            </td>
            <td>Materno:</td>
            <td>
                <asp:TextBox ID="TxtApMat" runat="server" onKeyUp="toUpper(this)" Width="250px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Cargo:</td>
            <td>
                <asp:TextBox ID="TxtCargo" runat="server" onKeyUp="toUpper(this)" Width="300px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Fono Fijo</td>
            <td>
                <asp:TextBox ID="TxtFonoFijo" runat="server"></asp:TextBox>
            </td>
            <td>Fono Movil:</td>
            <td>
                <asp:TextBox ID="TxtFonoMovil" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Fecha Nac.</td>
            <td>
                <asp:TextBox ID="TxtFechNac" runat="server" ValidationGroup="Formulario"></asp:TextBox>
                <asp:Label ID="lblFechaNacimiento" runat="server" Text="dd/mm/aaaa"></asp:Label>
            </td>
            <td>Sexo</td>
            <td>
                <asp:DropDownList ID="DDLSexo" runat="server">
                    <asp:ListItem Value="0">VARON</asp:ListItem>
                    <asp:ListItem Value="1">MUJER</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Label ID="lblcodigo" runat="server" Font-Bold="True" Text="Código:"></asp:Label></td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
    <div class="SubTitulo2">PARAMETROS DE USUARIO
        <asp:Label ID="lblmensaje" runat="server"></asp:Label>
    </div>
    <table class="TableBorder" id="tblPU">
        <tr>
            <td width="60">&nbsp;</td>
            <td>
                SISTEMA</td>
            <td width="60">
                    <asp:DropDownList ID="DDLSistema" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLSistema_SelectedIndexChanged">
                    <asp:ListItem Value="2">PRODUCCIÓN</asp:ListItem>
                    <asp:ListItem Value="3">VIÁTICOS</asp:ListItem>
                        <asp:ListItem Value="1">ADMINISTRADOR</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="40">
                    &nbsp;</td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td width="60">&nbsp;</td>
            <td width="100">Rol:</td>
            <td width="200">
                <asp:DropDownList ID="DDLRol" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Categoria:</td>
            <td>
                <asp:DropDownList ID="DDLCategoria" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Inmediato Sup.</td>
            <td>
                <asp:DropDownList ID="DDLSup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLSup_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Ci Responsable:</td>
            <td>
                <asp:TextBox ID="TxtCiResp" runat="server" onkeyUp="return ValNumero(this);" Width="60px"></asp:TextBox>
                <asp:Label ID="lblNom_Resp" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>N° de Cuenta:</td>
            <td>
                <asp:RadioButton ID="RBTNSI" runat="server" AutoPostBack="True" GroupName="SINO" OnCheckedChanged="RBTNSI_CheckedChanged" Text="SI" />
                <asp:RadioButton ID="RBTNNO" runat="server" AutoPostBack="True" Checked="True" GroupName="SINO" OnCheckedChanged="RBTNNO_CheckedChanged" Text="NO" />
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="TxtNumCuenta" onkeyUp="return ValNumero(this);" runat="server" Enabled="False">1000000-?</asp:TextBox>
                </td>
            <td>&nbsp;Banco:</td>
            <td>
                <asp:TextBox ID="TxtBanco" runat="server" Enabled="False">No Definido</asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div class="SubTitulo2">ESTADO DEL PERSONAL</div><table class="TableBorder">
        <tr>
            <td width="110">Estado del Personal:</td>
            <td>
                <asp:DropDownList ID="DDLEstado" runat="server">
                    <asp:ListItem>HABILITADO</asp:ListItem>
                    <asp:ListItem>IN-HABILITADO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" Height="26px" OnClick="BtnRegistrar_Click" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
</asp:Content>
