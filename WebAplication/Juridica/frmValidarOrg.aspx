<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmValidarOrg.aspx.cs" Inherits="WebAplication.Juridica.frmValidarOrg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        VALIDAR ORGANIZACIÓN PARA GENERAR CONTRATOS</div>
        <table class="TableBorder">
        <tr>
            <td width="65" class="auto-style1">Regional:</td>
            <td width="100" class="auto-style1">
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="auto-style1">
                </td>
            <td width="60" class="auto-style1">Campaña:</td>
            <td width="130" class="auto-style1">
                <asp:DropDownList ID="DDLCamp" runat="server" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Programa:</td>
            <td class="auto-style1">
                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1">
                <asp:Label ID="LblIdRol" runat="server"></asp:Label>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    
    <asp:GridView ID="GVOrg" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVOrg_RowCommand">
        <Columns>
            <asp:BoundField DataField="Personeria_Juridica" HeaderText="Personalidad Jurídica" />
            <asp:BoundField DataField="DomicilioOrg" HeaderText="Domicilio" />
            <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
            <asp:BoundField DataField="Rep_Legal" HeaderText="Rep. Legal" />
            <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" />
            <asp:ButtonField CommandName="Revisar" Text="Revisar" >
            <ItemStyle Width="45px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Planilla" Text="Planilla" >
            <ItemStyle Width="45px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Contrato" Text="Contrato" >
            <ItemStyle Width="75px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
