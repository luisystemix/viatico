<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrarPropuesta.aspx.cs" Inherits="WebAplication.Insumos.frmRegistrarPropuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">DATOS DEL PROVEEDOR</div><table class="TableBorder">
        <tr>
            <td width="65">Proveedor:</td>
            <td>
                <asp:Label ID="LblProveedor" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsProv" runat="server"></asp:Label>
            </td>
            <td width="55">&nbsp;</td>
            <td>&nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="130">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Insumo: </td>
            <td>
                <asp:Label ID="LblInsumo" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblProg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Regional:</td>
            <td>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="4">
                <div style="font-weight: 700; color: #FF0000; text-align: center"><asp:Label ID="LblMsj1" runat="server"></asp:Label></div>
            </td>
            <td>
                <div style="text-align: right"><asp:LinkButton ID="LnkInportar" runat="server" OnClick="LnkInportar_Click">Importar Excel</asp:LinkButton></div>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel2" runat="server">
        <asp:GridView ID="GVContratos" AllowPaging="True" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnSelectedIndexChanged="GVContratos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Id_Contrato_Insumo" HeaderText="Codigo Contrato" />
                <asp:BoundField DataField="Departamento" HeaderText="Departamento de origen" />
                <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" />
                <asp:BoundField DataField="Insumo" HeaderText="Insumo Ofertado" />
                <asp:BoundField DataField="Regional" HeaderText="Regional" />
                <asp:BoundField HeaderText="Total" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <div>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
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
                    <td colspan="5">
                        <asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridView1" runat="server" CssClass="TableBorder" OnPageIndexChanging="PageIndexChanging">
            </asp:GridView>
            <asp:Button ID="BtnImportar" runat="server" OnClick="BtnImportar_Click" Text="Importar Propuesta" Visible="False" />
            <asp:Button ID="BtnCancelar" runat="server" OnClick="BtnCancelar_Click" Text="Cancelar" Visible="False" />
        </asp:Panel>
    </div>
</asp:Content>
