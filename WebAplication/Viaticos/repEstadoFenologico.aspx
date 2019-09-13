<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="repEstadoFenologico.aspx.cs" Inherits="WebAplication.Viaticos.repEstadoFenologico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/canvasjs.min.js"></script>
    <script type='text/javascript'>
        //window.onload = function () {
        //    var lbl = document.getElementById('lblS1').innerHTML;
        //    alert(lbl);
        //    var chart = new CanvasJS.Chart('chartContainer', {
        //        title: {
        //            text: 'Precipitación Semanal (mm)'
        //        },
        //        axisY: {
        //            title: '%'
        //        },
        //        data: [
        //        {
        //            type: 'stackedColumn',
        //            legendText: 'Semana 1 (S1)',
        //            showInLegend: 'True',
        //            indexLabel: '#total mm',
        //            indexLabelPlacement: 'outside',
        //            dataPoints: [
		//				{ y: parseInt(lbl), label: 'S1' },
		//				{ y: 87, label: 'S2' },
		//				{ y: 80, label: 'S3' },
		//				{ y: 70, label: 'S4' },
		//				{ y: 60, label: 'S5' },
		//				{ y: 50, label: 'S6' },
		//				{ y: 45, label: 'S7' },
		//				{ y: 40, label: 'S8' },
		//				{ y: 30, label: 'S9' },
        //                { y: 20, label: 'S10' },
        //                { y: 10, label: 'S11' },
        //                { y: 5, label: 'S12' }
        //            ]
        //        }
        //        ]
        //    });
        //    chart.render();
        //}
        //function MostrarOcultarDiv() {
        //    var lbl = document.getElementById('lblS1').innerHTML;
        //    alert(lbl);
        //    alert("doing..!!!")
        //}
        //function BenerarBarras() {
        //    var chart = new CanvasJS.Chart('chartContainer', {
        //        title: {
        //            text: 'Precipitación Semanal (mm)'
        //        },
        //        axisY: {
        //            title: '%'
        //        },
        //        data: [
        //        {
        //            type: 'stackedColumn',
        //            legendText: 'Semana 1 (S1)',
        //            showInLegend: 'True',
        //            indexLabel: '#total mm',
        //            indexLabelPlacement: 'outside',
        //            dataPoints: [
		//				{ y: 92, label: 'S1' },
		//				{ y: 87, label: 'S2' },
		//				{ y: 80, label: 'S3' },
		//				{ y: 70, label: 'S4' },
		//				{ y: 60, label: 'S5' },
		//				{ y: 50, label: 'S6' },
		//				{ y: 45, label: 'S7' },
		//				{ y: 40, label: 'S8' },
		//				{ y: 30, label: 'S9' },
        //                { y: 20, label: 'S10' },
        //                { y: 10, label: 'S11' },
        //                { y: 5, label: 'S12' }
        //            ]
        //        }
        //        ]
        //    });
        //    chart.render();
        //}
    </script>
    <title>Reporte Estado Fenología</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="TableBorder">        
        <tr>
            <%--<td width="135">Seleccionar la Campaña:</td>
            
            <td>&nbsp;</td>--%>
            <td width="70px">Regional:</td>
            <td >
                <asp:DropDownList ID="DDLRegional" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRegional_SelectedIndexChanged" Width="160px">
                </asp:DropDownList>
            </td>
            <td style="width: 30px">
                 <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generar" Enabled="False" Visible="False" />
                <asp:Label ID="lblS1" runat="server"></asp:Label>
        <asp:TextBox ID="txtDato" runat="server" Enabled="False" Visible="False"></asp:TextBox>
               
            </td>
             <%--<asp:DropDownList ID="DDLCamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCamp_SelectedIndexChanged">
                </asp:DropDownList>--%>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Usuario | Regional | Programa | AvanceCosecha | FechaReg(Ini) | FechaReg(Fin)"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Semanas"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged" Width="160px">
                    <asp:ListItem Value="0">Seleccione Programa</asp:ListItem>
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                </td>
            <td></td>            
            <td>
                <asp:DropDownList ID="ddlDatosGrafica" runat="server" AutoPostBack="False" Width="450px" Font-Size="X-Small">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlSemanas" runat="server" AutoPostBack="False" Width="250px" Font-Size="X-Small">
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Label ID="LblIdUsuario" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

    <%--<form id="form1" runat="server">--%>
    <%--<div id="chartContainer" style="border-color: #FF3300; height: 400px; width: 900px;"></div>--%>
      
    <%--<iframe ID="id_iframe1" src="../Viaticos/repEFGrafico.aspx" width=1000 height=600></iframe>--%>
    <iframe id="iframe1" runat="server" width=1100 height=500 frameborder="1"/>
      
    <%--</form>--%>
</asp:Content>