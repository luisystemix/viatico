<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDocdeAnulados.aspx.cs" Inherits="WebAplication.Viaticos.frmDocdeAnulados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

    .auto-style1 {
        height: 19px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        &nbsp;SOLICITUDES ANULADAS</div>
    <table class="TableBorder">
        <tr>
            <td  width="130"></td>
            <td></td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Desplegar por Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="100">Buscar Solicitud:</td>
            <td width="100">
                <asp:TextBox ID="TxtBuscar" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td rowspan="2" class="auto-style1" width="35">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/buscar.png" Height="35px" Width="35px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                <asp:Label ID="LblMsg" runat="server" style="color: #CC0000; font-weight: 700"></asp:Label>
            </td>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style1">
                <div style="font-size: 8pt">
                    Ejm: Codigo</div>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVListSolicitud" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVListSolicitud_RowCommand" AllowPaging="true" OnPageIndexChanging="GVListSolicitud_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Id_Solicitud" HeaderText="Codigo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="ci" HeaderText="ci" Visible="False" />
            <asp:BoundField DataField="Motivo_Viaje" HeaderText="Motivo" Visible="False" />
            <asp:BoundField DataField="Fecha" HeaderText="Enviado" />
            <asp:BoundField DataField="Tipo_Viaje" HeaderText="Tipo" />
            <asp:BoundField DataField="Regional" HeaderText="Regional" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Id_Usuario" HeaderText="Id_Usuario" Visible="False" />
            <asp:BoundField DataField="EstadoInf" HeaderText="Informe" Visible="False" />
            <asp:ButtonField CommandName="Solicitud" Text="Solicitud">
            <ItemStyle Width="45px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Memo" Text="Memo">
            <ItemStyle Width="20px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Planilla" CommandName="Planilla">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Informe" CommandName="Informe">
            <ItemStyle Width="20px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
        </asp:Content>
