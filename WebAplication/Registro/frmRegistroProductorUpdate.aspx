<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistroProductorUpdate.aspx.cs" Inherits="WebAplication.Registro.frmRegistroProductorUpdate" %>
<%@ Register src="contEncabezado2.ascx" tagname="contEncabezado2" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../css/updateProcess.css" rel="stylesheet" type="text/css" /> 
    <script type="text/javascript" src="../Scripts/validar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="SubTitulo">
        REGISTRO DE PRODUCTOR</div>
        <uc1:contEncabezado2 ID="contEncabezado21" runat="server" />
        <div class="SubTitulo2">DATOS DEL PRODUCTOR</div>
        <table class="TableBorder">
            <tr>
                <td width="30">&nbsp;</td>
                <td width="130">CI:</td>
                <td width="250">
                    <div onkeypress="return AceptaNumero(event);"><asp:TextBox ID="TextBoxCI" runat="server" Enabled="False" Width="80px"></asp:TextBox>&nbsp;Ext:<asp:DropDownList ID="DropDownListEXT" runat="server">
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
                <td width="10">&nbsp;</td>
                <td width="60">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Nombre:</td>
                <td>
                    <asp:TextBox ID="TextBoxNOM" runat="server" onKeyUp="toUpper(this)" Width="250px"></asp:TextBox>
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
                    <asp:TextBox ID="TextBoxPAT" runat="server" onKeyUp="toUpper(this)" Width="250px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>Materno:</td>
                <td>
                    <asp:TextBox ID="TextBoxMAT" runat="server" onKeyUp="toUpper(this)" style="margin-bottom: 0px" Width="180px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Fecha de Nacimiento:</td>
                <td>
                    <asp:TextBox ID="TextF1TextBoxFE_NAC" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>Sexo:</td>
                <td>
                    <asp:RadioButton ID="RadioButtonVaron" runat="server" GroupName="Sexo" Text="Varon" />
                    <asp:RadioButton ID="RadioButtonMujer" runat="server" GroupName="Sexo" Text="Mujer" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1">Telefono Fijo:</td>
                <td class="auto-style1">
                    <div onkeypress="return AceptaNumeroTelel(event);"><asp:TextBox ID="TextBoxTEL_FIJO" runat="server" AutoCompleteType="Disabled"></asp:TextBox></div>
                </td>
                <td class="auto-style1"></td>
                <td class="auto-style1">Movil:</td>
                <td class="auto-style1">
                   <div onkeypress="return AceptaNumeroTelel(event);"><asp:TextBox ID="TextBoxTEL_MOVIL" runat="server" AutoCompleteType="Cellular"></asp:TextBox></div>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Observacion:</td>
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
            <ContentTemplate>
                <div class="SubTitulo2">DATOS DE CULTIVO</div>
                <table class="TableBorder">
                    <tr>
                        <td width="30">&nbsp;</td>
                        <td width="70">Provincia:</td>
                        <td width="160">
                            <asp:DropDownList ID="DropDownListPROV" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPROV_SelectedIndexChanged" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td width="30">&nbsp;</td>
                        <td width="100">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>Municipio:</td>
                        <td>
                            <asp:DropDownList ID="DropDownListMUN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListMUN_SelectedIndexChanged" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                        <td>Comunidad:</td>
                        <td>
                            <asp:DropDownList ID="DropDownListCOM" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCOM_SelectedIndexChanged" Width="140px">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>Tipo:</td>
                        <td>
                            <asp:DropDownList ID="DropDownListTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipo_SelectedIndexChanged" Width="150px">
                                <asp:ListItem>Seleccionar TipoSeleccionar Tipo</asp:ListItem>
                                <asp:ListItem>Beneficiario</asp:ListItem>
                                <asp:ListItem>No BeneficiarioNo Beneficiario</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                        <td>Superficie (ha):</td>
                        <td>
                            <div onkeypress="return AceptaNumeroD(event);"><asp:TextBox ID="TextBoxSUP" runat="server"></asp:TextBox></div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>Rau:</td>
                        <td>
                            <div onkeypress="return AceptaNumeroD(event);"><asp:TextBox ID="TextBoxRAU" runat="server"></asp:TextBox></div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="LabelMen" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <asp:Button ID="Registrar0" runat="server" OnClick="Registrar_Click" Text="Actualizar" />
                <asp:Button ID="Cancelar" runat="server" Text="Cancelar" />
                <asp:HiddenField ID="HiddenFieldInsOrg" runat="server" />
                <asp:HiddenField ID="HiddenFieldCampanhia" runat="server" />
                <asp:HiddenField ID="HiddenFieldIDPRO" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
    <ProgressTemplate>
        <div id="Background"></div>
        <div id="Progress"><h6><p style="text-align:center"><b>Procesando Datos, Espere por favor...</b></p></h6></div>
    </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
