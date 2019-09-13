<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCronogramaTec.aspx.cs" Inherits="WebAplication.Control.frmCronogramaTec" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        CRONOGRAMA DE PLANIFICACIÓN  DE LA EXTENSIÓN AGRÍCOLA POR MES </div>
    <table class="TableBorder">
        <tr>
            <td width="80">Regional:</td>
            <td>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="150">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblProg" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
            <td rowspan="2">
               <div style="text-align: right"> <asp:ImageButton ID="ImgBtnPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" /></div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="3">
                <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000; text-align: center;"></asp:Label></div>
            </td>
        </tr>
        </table>
    <table class="TableBorder">
        <tr>
            <td width="60">Tarea:</td>
            <td>
                <asp:DropDownList ID="DDLTareas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTareas_SelectedIndexChanged">
                    <asp:ListItem>UBICACIÓN DE LOS CULTIVOS</asp:ListItem>
                    <asp:ListItem>SEGUIMEINTO A DISTRIBUCION DE INSUMOS</asp:ListItem>
                    <asp:ListItem>SEGUIMEINTO A LA SIEMBRA</asp:ListItem>
                    <asp:ListItem>MONITOREO DE PLAGAS AGRO CLIMATOLOGIA Y FENOLOGIA </asp:ListItem>
                    <asp:ListItem>ASISTENCIA TECNICA</asp:ListItem>
                    <asp:ListItem>DETERMINACION DE RENDIMIENTO</asp:ListItem>
                    <asp:ListItem>ELABORACION DE COSTOS DE PRODUCCION</asp:ListItem>
                    <asp:ListItem>CAPACITACION / CHARLAS TECNICAS (DE EMAPA A PRODUCTORES)</asp:ListItem>
                    <asp:ListItem Value="FISCALIZACION A COSECHA
">FISCALIZACION A COSECHA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Gestion:</td>
            <td>
                <asp:DropDownList ID="DDLGestion" runat="server">
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem>
                    <asp:ListItem>2023</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="60">Meses:</td>
            <td width="90">
                <asp:CheckBox ID="Mes1" runat="server" Text="Enero" />
            </td>
            <td width="90">
                <asp:CheckBox ID="Mes2" runat="server" Text="Febrero" />
            </td>
            <td class="auto-style1">
                <asp:CheckBox ID="Mes3" runat="server" Text="Marzo" />
            </td>
            <td width="90">
                <asp:CheckBox ID="Mes4" runat="server" Text="Abril" />
            </td>
            <td width="90">
                <asp:CheckBox ID="Mes5" runat="server" Text="Mayo" />
            </td>
            <td width="90">
                <asp:CheckBox ID="Mes6" runat="server" Text="Junio" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:CheckBox ID="Mes7" runat="server" Text="Julio" />
            </td>
            <td>
                <asp:CheckBox ID="Mes8" runat="server" Text="Agosto" />
            </td>
            <td class="auto-style1">
                <asp:CheckBox ID="Mes9" runat="server" Text="Septiembre" />
            </td>
            <td>
                <asp:CheckBox ID="Mes10" runat="server" Text="Octubre" />
            </td>
            <td>
                <asp:CheckBox ID="Mes11" runat="server" Text="Noviembre" />
            </td>
            <td>
                <asp:CheckBox ID="Mes12" runat="server" Text="Diciembre" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Button ID="BtnRegistrar" runat="server" OnClick="BtnRegistrar_Click" Text="Registrar Tarea &gt;&gt;" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVCronograma" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVCronograma_RowDataBound" OnRowDeleting="GVCronograma_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Tarea" HeaderText="Tarea" />
            <asp:BoundField DataField="Gestion" HeaderText="Gestion" />
            <asp:TemplateField HeaderText="Enero">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Febrero">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado2" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Marzo">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado3" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Abril">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado4" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mayo">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado5" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Junio">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado6" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Julio">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado7" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Agosto">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado8" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Septiembre">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado9" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Octubre">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado10" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Noviembre">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado11" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Diciembre">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado12" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True">
            <ItemStyle Width="40px" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnEnviar" runat="server" OnClick="BtnEnviar_Click" Text="Enviar Cronograma" />
    <asp:Button ID="BtnCancel" runat="server" Text="Cancelar" />
</asp:Content>
