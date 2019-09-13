<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListaSeguimiento.aspx.cs" Inherits="WebAplication.Extensiones.frmListaSeguimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--GRIDVIEW MAKEOVER--%>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        td
        {
            cursor: pointer;
        }
        .hover_row
        {
            background-color: #c5bfb7/*#A1DCF2*/;
        }
    </style>
    <script type="text/javascript" src="../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js/jquery.quicksearch.js"></script>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript">
        $(function () {
            $("[id*=GVListaSeg] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });        
    </script>
    <%--GRIDVIEW MAKEOVER--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">LISTA DE LOS SEGUIMIENTOS AL CULTIVO QUE SE REALIZO</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Agricultor:</td>
            <td width="250">
                <asp:Label ID="LblProductor" runat="server"></asp:Label>
                </td>
            <td width="80">Organización:</td>
            <td>
                <asp:Label ID="LblOrg" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsOrg" runat="server" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="55">Campaña:</td>
            <td width="120">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblProg" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="LblIdInsProd" runat="server" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="TableBorder" border="0">
        <tr>
            <td colspan="2" width="130">Estado:<asp:Label ID="LblEstado" runat="server"></asp:Label></td>
            <td>
                 &nbsp;</td>
            <td width="60">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="55">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="80" style="text-align:center">
                Boleta</td>
            <td style="text-align:center">
               Inf. Semanal </td>
            <td>
                  
            </td>
        </tr>
        <tr>
            <td>Seguimiento Pendiente:</td>
            <td>
                <asp:Label ID="LblEtapa" runat="server"></asp:Label>
                <asp:Label ID="LblId_Etapa" runat="server"></asp:Label>
                <asp:DropDownList ID="DDLOpcion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLOpcion_SelectedIndexChanged">
                    <%--<asp:ListItem Value="0">Seleccionar opción</asp:ListItem>
                    <asp:ListItem Value="1">Verificación y/o Georreferenciación  de Parcela</asp:ListItem>
                    <asp:ListItem Value="2">Seguimiento al Avance de Siembra</asp:ListItem>
                    <asp:ListItem Value="3">Seguimiento y/o Monitoreo de Cultivo</asp:ListItem>--%>
                </asp:DropDownList>
                <asp:Button ID="BtnRealizarSeg" runat="server" Enabled="False" OnClick="BtnRealizarSeg_Click" Text="Realizar Seguimiento" />
                <asp:Label ID="LblOpcion" runat="server" style="font-weight: 700"></asp:Label>
                <asp:Label ID="LblOpcionId" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="text-align:center">
                <asp:ImageButton ID="ImgBoletaSeg" runat="server" Height="30px" ImageUrl="~/images/boleta.png" Width="30px" ToolTip="Boleta de Seguimiento" OnClick="ImgBoletaSeg_Click"/>    
            </td>
            <td>
                <div style="text-align:center">
                     <asp:ImageButton ID="ImgSegCultivo" runat="server" Height="30px" ImageUrl="~/images/infsemanal.png" Width="30px" OnClick="ImgSegCultivo_Click" ToolTip="Seguimiento Cultivo"/>
                </div>

            </td>
        </tr>
        </table>
    <div style="text-align: center"><asp:Label ID="LblMsj1" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label></div>
    <asp:GridView ID="GVListaSeg" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVListaSeg_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id_Seguimiento" HeaderText="Id_Seguimiento" Visible="False" />
            <asp:BoundField DataField="Etapa" HeaderText="Seguimientos" />
            <asp:BoundField DataField="Boleta_Numero" HeaderText="N° Boleta" />
            <asp:BoundField DataField="Fecha_Seg" HeaderText="Fecha del Seguimiento" />
            <asp:BoundField DataField="Hora_Seg" HeaderText="Hora del Seg." />
            <asp:BoundField DataField="Fecha_Sis" HeaderText="Fecha Registro SPIA" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:ButtonField Text="Modificar" CommandName="Modificar" Visible="True" >
            <ItemStyle Width="50px" />
            </asp:ButtonField>
            <asp:ButtonField Text="Reporte" CommandName="Reporte" Visible="False" >
            <ItemStyle Width="40px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    </asp:Content>
