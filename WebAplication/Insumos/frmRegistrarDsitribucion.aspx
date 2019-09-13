<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrarDsitribucion.aspx.cs" Inherits="WebAplication.Insumos.frmRegistrarDsitribucion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        IMPORTAR INSUMOS DISTRIBUIDOS</div>
    <table class="TableBorder">
        <tr>
            <td width="115">Programa:</td>
            <td>
                <asp:Label ID="LblProg" runat="server"></asp:Label>
            </td>
            <td></td>
            <td width="60">Campaña:</td>
            <td width="140">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="115">Regional:</td>
            <td>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="60">&nbsp;</td>
            <td width="140">
                &nbsp;</td>
        </tr>
        <tr>
            <td>Insumo a Registrar:</td>
            <td>
                <asp:DropDownList ID="DDLInsumo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLInsumo_SelectedIndexChanged">
                    <asp:ListItem Value="1">SEMILLA</asp:ListItem>
                    <asp:ListItem Value="2">AGROQUIMICO</asp:ListItem>
                    <asp:ListItem Value="3">COMBUSTIBLE</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="LblInsumo" runat="server"></asp:Label>
            </td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Proveedor:</td>
            <td>
                <asp:DropDownList ID="DDLProveedor" runat="server">
                </asp:DropDownList>
            </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Organización:</td>
            <td>
                <asp:DropDownList ID="DDLOrgAsig" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        <asp:Panel ID="Panel1" runat="server">
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
                    <td class="auto-style1"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td colspan="5" class="auto-style1">
                        <asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridView1" runat="server" CssClass="TableBorder">
            </asp:GridView>
            <asp:Button ID="BtnImportar" runat="server" OnClick="BtnImportar_Click" Text="Importar Propuesta" Visible="False" />
            <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" Visible="False" />
        </asp:Panel>
    </asp:Content>
