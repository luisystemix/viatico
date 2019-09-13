<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistroProductorNew.aspx.cs" Inherits="WebAplication.Registro.frmRegistroProductorNew" %>
<%@ Register src="contEncabezado2.ascx" tagname="contEncabezado2" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../css/updateProcess.css" rel="stylesheet" type="text/css" /> 
    <script type="text/javascript" src="../Scripts/validar.js"></script>
        <script language="javascript" type="text/javascript">
            function abrirModal(pagina) {
                var vReturnValue;
                vReturnValue = window.showModalDialog(pagina, "", "dialogHeight: 280px; dialogWidth: 300px; edge: Raised; center: Yes; help: No; resizable: No; status: No;");

                if (vReturnValue != null && vReturnValue == true) {
                    __doPostBack('', '');
                    return vReturnValue
                }
                else {
                    return false;
                }
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="SubTitulo">
        REGISTRO DE PRODUCTOR</div>
    <uc1:contEncabezado2 ID="contEncabezado21" runat="server" />
    <div class="SubTitulo2">
        DATOS DE PRODUCTOR</div>
    <table class="TableBorder">
        <tr>
            <td width="30">&nbsp;</td>
            <td width="130">CI:</td>
            <td width="240">
               <div onkeypress="return AceptaNumero(event);" style="220"><asp:TextBox ID="TextBoxCI" runat="server" Width="80px" OnTextChanged="TextBoxCI_TextChanged" AutoPostBack="True"></asp:TextBox>
                   <asp:LinkButton ID="LnkVer" runat="server" OnClick="LnkVer_Click">Ver</asp:LinkButton>
&nbsp;Ext: <asp:DropDownList ID="DropDownListEXT" runat="server">
                    <asp:ListItem>Seleccionar</asp:ListItem>
                    <asp:ListItem>LP</asp:ListItem>
                    <asp:ListItem>SC</asp:ListItem>
                    <asp:ListItem>CB</asp:ListItem>
                    <asp:ListItem>CH</asp:ListItem>
                    <asp:ListItem>PT</asp:ListItem>
                    <asp:ListItem>OR</asp:ListItem>
                    <asp:ListItem>PA</asp:ListItem>
                    <asp:ListItem>BE</asp:ListItem>
                    <asp:ListItem>TJ</asp:ListItem>
                </asp:DropDownList>
                </div>
            </td>
            <td colspan="3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxCI" ErrorMessage="se necesita número de CI"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Nombre:</td>
            <td>
                <asp:TextBox ID="TextBoxNOM" runat="server" onKeyUp="toUpper(this)" Width="200px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td width="60">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Paterno:</td>
            <td>
                <asp:TextBox ID="TextBoxPAT" runat="server" onKeyUp="toUpper(this)" Width="200px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>Materno:</td>
            <td>
                <asp:TextBox ID="TextBoxMAT" runat="server" onKeyUp="toUpper(this)" Width="200px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Fecha de Nacimiento:</td>
            <td>
                <asp:TextBox ID="TextF1TextBoxFE_NAC" runat="server" Width="80px"></asp:TextBox>
            &nbsp;Ej. Dia/Mes/Año</td>
            <td>&nbsp;</td>
            <td>Sexo:</td>
            <td>
                <asp:RadioButton ID="RadioButtonVaron" runat="server" GroupName="Sexo" Text="Varon" />
                <asp:RadioButton ID="RadioButtonMujer" runat="server" GroupName="Sexo" Text="Mujer" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Telefono Fijo:</td>
            <td>
                <div onkeypress="return AceptaNumeroTelel(event);"><asp:TextBox ID="TextBoxTEL_FIJO" runat="server" AutoCompleteType="Disabled"></asp:TextBox></div>
            </td>
            <td>&nbsp;</td>
            <td>Movil:</td>
            <td>
                <div onkeypress="return AceptaNumeroTelel(event);"><asp:TextBox ID="TextBoxTEL_MOVIL" runat="server" AutoCompleteType="Cellular"></asp:TextBox></div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Observación:</td>
            <td colspan="4" rowspan="2">
                <asp:TextBox ID="TxtObser" runat="server" Height="50px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    </asp:UpdatePanel>
            <div class="SubTitulo2" __designer:mapid="bf">DATOS DE CULTIVO</div>
            <table class="TableBorder" __designer:mapid="c0">
                <tr __designer:mapid="c1">
                    <td width="30" __designer:mapid="c2">&nbsp;</td>
                    <td width="85" __designer:mapid="c3">Departamento:</td>
                    <td __designer:mapid="c4">
                        <asp:DropDownList ID="DDLDepartamento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLDepartamento_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td width="5" __designer:mapid="c6">&nbsp;</td>
                    <td width="100" __designer:mapid="c7">&nbsp;</td>
                    <td width="250" __designer:mapid="c8">&nbsp;</td>
                    <td __designer:mapid="c9">&nbsp;</td>
                </tr>
                <tr __designer:mapid="c1">
                    <td width="30" __designer:mapid="c2">&nbsp;</td>
                    <td __designer:mapid="c3">Provincia:</td>
                    <td width="160" __designer:mapid="c4">
                        <asp:DropDownList ID="DropDownListPROV" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPROV_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td __designer:mapid="c6">&nbsp;</td>
                    <td width="100" __designer:mapid="c7">&nbsp;</td>
                    <td width="250" __designer:mapid="c8">&nbsp;</td>
                    <td __designer:mapid="c9">&nbsp;</td>
                </tr>
                <tr __designer:mapid="ca">
                    <td __designer:mapid="cb">&nbsp;</td>
                    <td __designer:mapid="cc">Municipio:</td>
                    <td __designer:mapid="cd">
                        <asp:DropDownList ID="DropDownListMUN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListMUN_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td __designer:mapid="cf">&nbsp;</td>
                    <td __designer:mapid="d0">Comunidad:</td>
                    <td __designer:mapid="d1">
                        <asp:DropDownList ID="DropDownListCOM" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCOM_SelectedIndexChanged" Width="140px">
                        </asp:DropDownList>
                        <asp:TextBox ID="TxtComunidad" runat="server" Visible="False"></asp:TextBox>
                        <asp:LinkButton ID="LnkBtnNuevo" runat="server" OnClick="LnkBtnNuevo_Click">Nuevo</asp:LinkButton>
                    </td>
                    <td __designer:mapid="d5">&nbsp;</td>
                </tr>
                <tr __designer:mapid="d6">
                    <td __designer:mapid="d7">&nbsp;</td>
                    <td __designer:mapid="d8">Tipo:</td>
                    <td __designer:mapid="d9">
                        <asp:DropDownList ID="DropDownListTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipo_SelectedIndexChanged">
                            <asp:ListItem>Seleccionar Tipo productor</asp:ListItem>
                            <asp:ListItem>Beneficiario</asp:ListItem>
                            <asp:ListItem>No BeneficiarioNo Beneficiario</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td __designer:mapid="de">&nbsp;</td>
                    <td __designer:mapid="df">Superficie (ha):</td>
                    <td __designer:mapid="e0">
                        <div onkeypress="return AceptaNumeroD(event);" __designer:mapid="e1"><asp:TextBox ID="TextBoxSUP" runat="server" Width="50px"></asp:TextBox></div>
                    </td>
                    <td __designer:mapid="e3">&nbsp;</td>
                </tr>
                <tr __designer:mapid="e4">
                    <td __designer:mapid="e5">&nbsp;</td>
                    <td __designer:mapid="e6">&nbsp;</td>
                    <td __designer:mapid="e7">&nbsp;</td>
                    <td __designer:mapid="e8">&nbsp;</td>
                    <td __designer:mapid="e9">Rau:</td>
                    <td __designer:mapid="ea">
                       <div onkeypress="return AceptaNumeroD(event);" __designer:mapid="eb"> <asp:TextBox ID="TextBoxRAU" runat="server" Width="50px"></asp:TextBox></div>
                    </td>
                    <td __designer:mapid="ed">&nbsp;</td>
                </tr>
                <tr __designer:mapid="ee">
                    <td class="auto-style1" colspan="7" __designer:mapid="ef">
                        <asp:Label ID="LabelMen" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Button ID="Registrar0" runat="server" OnClick="Registrar_Click" Text="Registrar" />
            <asp:Button ID="Cancelar" runat="server" Text="Cancelar"/>
            <asp:HiddenField ID="HiddenFieldInsOrg" runat="server" />
            <asp:HiddenField ID="HiddenFieldCampanhia" runat="server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
    <ProgressTemplate>
        <div id="Background"></div>
        <div id="Progress"><h6><p style="text-align:center"><b>Procesando Datos, Espere por favor...</b></p></h6></div>
    </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
