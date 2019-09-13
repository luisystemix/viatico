<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDefinirMuestra.aspx.cs" Inherits="WebAplication.Extensiones.frmDefinirMuestra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">DETERMINACIÓN DEL TAMAÑO DE MUESTRA</div>
    <table class="TableBorder">
        <tr>
            <td width="135">Seleccionar la Campaña:</td>
            <td>
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td width="60">Regional:</td>
            <td width="150">
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Seleccionar el Programa:</td>
            <td>
                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                </td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
     <table class="TableBorder">
         <tr>
             <td width="160">Numero de Organizaciones:</td>
             <td>
                 <asp:Label ID="LblNumOrg" runat="server"></asp:Label>
             </td>
             <td>&nbsp;</td>
             <td>&nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         <tr>
             <td>Numero de Productores:&nbsp; X =</td>
             <td>
                 <asp:Label ID="LblNumProd" runat="server"></asp:Label>
             </td>
             <td>&nbsp;</td>
             <td>&nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         <tr>
             <td><div style="text-align: right">
                 <asp:Label ID="LblTexto1" runat="server" Text="N ="></asp:Label>
                 </div></td>
             <td>
                 <asp:Image ID="ImgFormula" runat="server" ImageUrl="~/images/clip_image001.png" />
                 <asp:Label ID="LblMuestra" runat="server" Visible="False"></asp:Label>
             </td>
             <td>&nbsp;</td>
             <td></td>
             <td></td>
         </tr>
    </table>
     <table class="TableBorder">
         <tr>
             <td>
                <div style="text-align: center">
                    <asp:Button ID="BtnCalcular" runat="server" OnClick="BtnCalcular_Click" Text="Calcular Muestra" />
                    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" Visible="False" OnClick="BtnRegistrar_Click" />
                    <asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label>
                 </div>
             </td>
         </tr>
    </table>
     <asp:GridView ID="GVMuestras" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVMuestras_RowCommand">
         <Columns>
             <asp:BoundField DataField="Nombre" HeaderText="Campaña" />
             <asp:BoundField DataField="Regional" HeaderText="Regional" />
             <asp:BoundField DataField="Programa" HeaderText="Programa" />
             <asp:BoundField DataField="Num_Org" HeaderText="N° Organizaciones" />
             <asp:BoundField DataField="Num_Prod" HeaderText="N° Productores" />
             <asp:BoundField DataField="Num_Muestra" HeaderText="Muestra" />
             <asp:BoundField DataField="Num_Tecnicos" HeaderText="N° de Tecnicos" />
             <asp:BoundField DataField="Id_Campanhia" HeaderText="Id_Campanhia" />
             <asp:BoundField DataField="Id_Regional" HeaderText="Id_Regional" />
             <asp:ButtonField CommandName="Designar" Text="Designar organizacion a técnicos">
             <ItemStyle Width="175px" />
             </asp:ButtonField>
         </Columns>
    </asp:GridView>
     <table class="TableBorder">
         <tr>
             <td>&nbsp;</td>
             <td>&nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         <tr>
             <td>&nbsp;</td>
             <td>&nbsp;</td>
             <td>
                 <div style="text-align: right"></div>
             </td>
         </tr>
    </table>
     </asp:Content>
