<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListElaboracionContrato.aspx.cs" Inherits="WebAplication.Responsable.frmListElaboracionContrato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        REGISTRO DE ORGANIZACIONES PARA LA ELABORACIÓN DE CONTRATOS DE PROBACIÓN DE MATERIA PRIMA</div>
        <table class="TableBorder">
        <tr>
            <td width="65">Regional:</td>
            <td width="100">
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="130">
                <asp:DropDownList ID="DDLCamp" runat="server" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="LblIdRol" runat="server"></asp:Label>
                <asp:Label ID="LblNumero" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td rowspan="2">
                <div style="text-align: right"><asp:ImageButton ID="ImgBtnContratos" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" OnClick="ImgBtnContratos_Click" Width="30px" /></div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
            <td>
                <div style="text-align: center; font-weight: 700; color: #FF0000"><asp:Label ID="LblMsj" runat="server"></asp:Label></div>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    
    <asp:GridView ID="GVResitroContrat" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" style="font-size: 8pt" OnRowCommand="GVResitroContrat_RowCommand">
        <Columns>
            <asp:BoundField DataField="Programa" HeaderText="Programa" Visible="False" />
            <asp:BoundField DataField="Personeria_Juridica" HeaderText="Organización" />
            <asp:BoundField DataField="Sigla" HeaderText="Sigla" />
            <asp:BoundField DataField="Resolucion_Prefect" HeaderText="Resolución" Visible="False" />
            <asp:BoundField DataField="Fecha_Creacion" HeaderText="Fecha resolucion" Visible="False" />
            <asp:BoundField DataField="DomicilioOrg" HeaderText="DomicilioOrg" Visible="False" />
            <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
            <asp:BoundField DataField="Rep_Legal" HeaderText="Rep. Legal" />
            <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
            <asp:BoundField DataField="Nun_Testimonio" HeaderText="N° Testim" />
            <asp:BoundField DataField="Num_Notaria" HeaderText="N° Notaria" />
            <asp:BoundField DataField="Abg_A_Cargo" HeaderText="Abg. a Cargo" Visible="False" />
            <asp:BoundField DataField="Distrito_Judicial" HeaderText="Distrito Judicial" Visible="False" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" />
            <asp:ButtonField CommandName="RevisarDatos" Text="Revisar" />
            <asp:ButtonField Text="Aprobar" CommandName="Contrato" />
            <asp:ButtonField CommandName="Habilitar" Text="Re-Habilitar" Visible="False" />
            <asp:ButtonField CommandName="Planilla" Text="Planilla" />
            <asp:ButtonField CommandName="VerDoc" Text="Ver-Doc" Visible="False" />
        </Columns>
    </asp:GridView>
    
</asp:Content>
