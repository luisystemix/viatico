<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmImportarProd.aspx.cs" Inherits="WebAplication.Administrador.frmImportarProd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function Confirm() {
            var seleccion = confirm("Confirma el enviar la información registrada…?");
            return seleccion;
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        IMPORTACIÓN DE EXCEL A BD</div>        
        <asp:Panel ID="Panel1" runat="server">
            <table class="TableBorder">
                <tr>
                    <td width="90">Regional:</td>
                    <td width="150">
                        <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td width="80">Region:</td>
                    <td width="90">
                        <asp:Label ID="LblRegion" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="90">Campaña:</td>
                    <td>
                        <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="LblEstadoCamp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="90">Programa:</td>
                    <td>
                        <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                            <asp:ListItem>ARROZ</asp:ListItem>
                            <asp:ListItem>MAIZ</asp:ListItem>
                            <asp:ListItem>TRIGO</asp:ListItem>
                            <asp:ListItem>SOJA</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Organizacion:</td>
                    <td>
                        <asp:DropDownList ID="DDLSigla" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLSigla_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="LblPersonJuridi" runat="server"></asp:Label>
                    </td>
                    <td></td>
                    <td></td>
                    <td>Departamento:</td>
                    <td>
                        <asp:Label ID="LblDep" runat="server"></asp:Label>
                    </td>
                </tr>                
            </table>
            <table width="600px"  width="600px">
                <tr>
                    <td class="auto-style1"><asp:DropDownList ID="ddlProvincias" runat="server"></asp:DropDownList> </td>
                    <td class="auto-style1"><asp:DropDownList ID="ddlMunicicio" runat="server" ToolTip="Municipios"></asp:DropDownList> </td>
                    <td class="auto-style1"><asp:DropDownList ID="ddlOrganizacion" runat="server" ToolTip="Organizacion" ></asp:DropDownList> </td>
                    <td class="auto-style1"><asp:DropDownList ID="ddlComunidad" runat="server" ToolTip="Comunidad"></asp:DropDownList> </td>
                    
                </tr>
            </table>
            <table class="TableBorder">
                <tr>
                    <td class="auto-style1" width="240">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                    <td class="auto-style1">
                        <asp:Button ID="btnUpload" AllowPaging="true" runat="server" OnClick="btnUpload_Click" Text="Subir registro" />
                        <asp:Label ID="Label1" runat="server" Text="Has Header ?" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:RadioButtonList ID="rbHDR" runat="server" Visible="False">
                            <asp:ListItem Selected="True" Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridView1" runat="server" CssClass="TableBorder">
            </asp:GridView>
            <asp:Button ID="BtnVerificar" runat="server" OnClick="BtnVerificar_Click" Text="Verificar Errores" Visible="False" />
            <asp:Button ID="BtnImportar" runat="server" OnClick="BtnImportar_Click" Text="Importar Propuesta" OnClientClick="return Confirm();" />
            <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" Visible="False" />
        </asp:Panel>
    &nbsp;
</asp:Content>
