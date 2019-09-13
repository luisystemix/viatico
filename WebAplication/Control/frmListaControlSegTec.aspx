<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaControlSegTec.aspx.cs" Inherits="WebAplication.Control.frmListaControlSegTec" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        SEGUIMIENTO A LOS TÉCNICOS DE CAMPO</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Programa:</td>
            <td>
                <asp:DropDownList ID="DDLProg" runat="server" OnSelectedIndexChanged="DDLProg_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
            <td width="60">Campaña:</td>
            <td width="120">
                <asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td>Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            &nbsp;<asp:Label ID="LblIdReg" runat="server"></asp:Label>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <div style="text-align: right">
                <asp:ImageButton ID="ImgBtnPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" OnClick="ImgBtnPrint_Click" />
               </div>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVSegTec" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVSegTec_RowCommand" OnRowDataBound="GVSegTec_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Tecnico" HeaderText="Personal Tecnico" />
            <asp:TemplateField HeaderText="N° Boleta">
                <ItemTemplate>
                    <asp:Label ID="LblNumBolet" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Etapa" HeaderText="Tipo Seguimirnto" />
            <asp:BoundField DataField="Productor" HeaderText="Productor" />
            <asp:BoundField DataField="Fecha_Envio" HeaderText="Fecha Envio " />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_Seguimiento" HeaderText="Id_Seguimiento" Visible="False" />
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" />
            <asp:BoundField DataField="Tipo_Seguimiento" HeaderText="Seguimiento" />
            <asp:ButtonField Text="Ver Seguimiento" CommandName="Seguimiento" >
            <ItemStyle Width="90px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Aceptar" CommandName="Aceptar" >
            <ItemStyle Width="45px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Observar" Visible="False" />
        </Columns>
    </asp:GridView>
   
    </asp:Content>
