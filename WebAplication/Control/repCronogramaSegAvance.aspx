<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repCronogramaSegAvance.aspx.cs" Inherits="WebAplication.Control.repCronogramaSegAvance" %>
<%@ Register Assembly="C1.Web.C1WebReport.2, Version=2.5.20063.223, Culture=neutral, PublicKeyToken=79882d576c6336da"
    Namespace="C1.Web.C1WebReport" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/EmapaStyele.css" rel="stylesheet" />
<script type="text/javascript" id="igClientScript1">

    function pasa() {
        var modificando = document.getElementById('<%= hf1.ClientID %>');
        alert("2");
        modificando.value = "false";
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hf1" runat="server"></asp:HiddenField>
    <asp:MultiView ID="mvUsuarios" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwDatos" runat="server">

    <table class="TableBorder">
            <tr>
                <td width="200" rowspan="3">
                    <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td><div style="text-align: center">PROGRAMACIÓN SEMANAL</div></td>
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ </div></td>
            </tr>
            <tr>
                <td>
                    <div style="text-align: center">REGIONAL <asp:Label ID="LblRegional" runat="server"></asp:Label></div> </td>
                <td>
                    <div style="text-align: center">Versión 1</div></td>
            </tr>
            <tr>
                <td><asp:Label ID="LblIdReg" runat="server"></asp:Label></td>
                <td></td>
            </tr>
        </table>
        <table class="TableBorder">
            <tr>
                <td>
                    <asp:Label ID="LblIdCrono" runat="server"></asp:Label>
                </td>
                <td><asp:Label ID="LblMes" runat="server"></asp:Label></td>
                <td><asp:Label ID="LblPersonal" runat="server" Visible="False"></asp:Label></td>
                <td width="50">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Label ID="LblUser" runat="server" CssClass="colorCerrar" Visible="False"></asp:Label>
                    <asp:Label ID="LblIdUser" runat="server" Visible="False" ></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style2"></td>
                <td>&nbsp;</td>
                <td>
                    <div style="text-align:right">                    
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl="~/images/exportar.png" Width="50px" OnClick="btnExportExcel_Click" ToolTip="Exportar" />
                    </div>
                </td>
               
            </tr>
        </table>
    <asp:GridView ID="GVCronogramas" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCreated="GVCronogramas_RowCreated" OnRowDataBound="GVCronogramas_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Personal" HeaderText="PERSONAL TECNICO(GERENCIA PRODUCCION)" />
            <asp:BoundField DataField="Regional" HeaderText="LUGAR DEL EVENTO"/>
            <asp:BoundField DataField="Fecha" HeaderText="FECHA EVENTO"/>
            <asp:BoundField DataField="Tema" HeaderText="TEMA" />
            <asp:BoundField DataField="Organizaciones" HeaderText="ORGANIZACIONES PROGRAMADAS "/>
            <asp:BoundField DataField="Resultado" HeaderText="RESULTADOS A OBTENER" />
            <asp:BoundField DataField="Transporte" HeaderText="DATOS DE TRANSPORTE" />
            <asp:BoundField DataField="FVerificacion" HeaderText="FUENTE DE VERIFICACION" />
            <asp:BoundField DataField="Observacion" HeaderText="OBSERVACION"/>            
        </Columns>
    </asp:GridView>
    
    </asp:View>
        <asp:View ID="vwReporte" runat="server">
            <table align="right">
                <tr>
                    <td>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Back.png"
                            ToolTip="Volver" OnClick="btnVolver_Click" Enabled="True" OnClientClick="pasa" Height="50px" Width="50px" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Volver"></asp:Label>
                    </td>
                </tr>
            </table>
            <div align="center">
                
                <cc1:C1WebReport ID="C1WebReport1" runat="server">
                    <NavigationBar HasExportButton="True" HasGotoPageButton="False" Style-BackColor="Control">
                    </NavigationBar>
                </cc1:C1WebReport>
            </div>
        </asp:View>
    </asp:MultiView>
            </div>
    </form>
</body>
</html>