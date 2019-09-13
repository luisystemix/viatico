<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListCronogramaReg.aspx.cs" Inherits="WebAplication.Control.frmListCronogramaReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">CRONOGRAMA DE ACTIVIDADES POR TÉCNICO DE EXTENSIÓN</div>
        <table class="TableBorder">
            <tr>
                <td width="60">Regional:</td>
                <td>
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td width="60">Campaña:</td>
                <td width="120">
                <asp:DropDownList ID="DDLCamp" runat="server" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Mes:</td>
                <td>
                    <asp:DropDownList ID="DDLMes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLMes_SelectedIndexChanged">
                        <asp:ListItem Value="01">Enero</asp:ListItem>
                        <asp:ListItem Value="02">Febrero</asp:ListItem>
                        <asp:ListItem Value="03">Marzo</asp:ListItem>
                        <asp:ListItem Value="04">Abril</asp:ListItem>
                        <asp:ListItem Value="05">Mayo</asp:ListItem>
                        <asp:ListItem Value="06">Junio</asp:ListItem>
                        <asp:ListItem Value="07">Julio</asp:ListItem>
                        <asp:ListItem Value="08">Agosto</asp:ListItem>
                        <asp:ListItem Value="09">Septiembre</asp:ListItem>
                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td rowspan="2"> 
                    <div style="text-align: right"><asp:ImageButton ID="ImgPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" OnClick="ImgPrint_Click" /></div></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="LblMsj" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:GridView ID="GVCronogramas" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCreated="GVCronogramas_RowCreated">
            <Columns>
                <asp:BoundField DataField="Semana" HeaderText="Semana" />
                <asp:BoundField DataField="Personal" HeaderText="Personal" />
                <asp:BoundField DataField="FechaLunes" HeaderText="Fecha" />
                <asp:BoundField DataField="Lunes" HeaderText="Tarea" />
                <asp:BoundField DataField="FechaMartes" HeaderText="Fecha" />
                <asp:BoundField DataField="Martes" HeaderText="Tarea" />
                <asp:BoundField DataField="FechaMiercoles" HeaderText="Fecha" />
                <asp:BoundField DataField="Miercoles" HeaderText="Tarea" />
                <asp:BoundField DataField="FechaJueves" HeaderText="Fecha" />
                <asp:BoundField DataField="Jueves" HeaderText="Tarea" />
                <asp:BoundField DataField="FechaViernes" HeaderText="Fecha" />
                <asp:BoundField DataField="Viernes" HeaderText="Tarea" />
                <asp:BoundField DataField="FechaSabado" HeaderText="Fecha" />
                <asp:BoundField DataField="Sabado" HeaderText="Tarea" />
                <asp:BoundField DataField="FechaDomingo" HeaderText="Fecha" />
                <asp:BoundField DataField="Domingo" HeaderText="Tarea" />
            </Columns>
        </asp:GridView>
</asp:Content>
