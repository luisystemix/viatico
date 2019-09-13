<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repEFGrafico.aspx.cs" Inherits="WebAplication.Viaticos.repEFGrafico" %>

<!DOCTYPE html>
<html>
<head>
    <script src="../Scripts/canvasjs.min.js"></script>
    <script type='text/javascript'>
        window.onload = function () {
            var lbls1 = document.getElementById('lblS1').innerHTML;
            //alert(lbls1);
            var lbls2 = document.getElementById('lblS2').innerHTML;
            //alert(lbls2);
            var lbls3 = document.getElementById('lblS3').innerHTML;
            //alert(lbls3);
            var lbls4 = document.getElementById('lblS4').innerHTML;
            //alert(lbls4);
            var lbls5 = document.getElementById('lblS5').innerHTML;
            //alert(lbls5);
            var lbls6 = document.getElementById('lblS6').innerHTML;
            //alert(lbls6);
            var lbls7 = document.getElementById('lblS7').innerHTML;
            //alert(lbls7);
            var lbls8 = document.getElementById('lblS8').innerHTML;
            //alert(lbls8);
            var lbls9 = document.getElementById('lblS9').innerHTML;
            //alert(lbls9);
            var lbls10 = document.getElementById('lblS10').innerHTML;
            //alert(lbls10);
            var lbls11 = document.getElementById('lblS11').innerHTML;
            //alert(lbls11);
            var lbls12 = document.getElementById('lblS12').innerHTML;
            //alert(lbls12);
            var chart = new CanvasJS.Chart('chartContainer', {
                title: {
                    text: 'Estado Fenológico'
                },
                axisY: {
                    title: '%'
                },
                data: [
                {
                    type: 'stackedColumn',
                    legendText: 'Semana 1 (S1)',
                    showInLegend: 'True',
                    indexLabel: '#total',
                    indexLabelPlacement: 'outside',
                    dataPoints: [
						{ y: parseFloat(lbls1), label: 'S1' },
						{ y: parseFloat(lbls2), label: 'S2' },
						{ y: parseFloat(lbls3), label: 'S3' },
						{ y: parseFloat(lbls4), label: 'S4' },
						{ y: parseFloat(lbls5), label: 'S5' },
						{ y: parseFloat(lbls6), label: 'S6' },
						{ y: parseFloat(lbls7), label: 'S7' },
						{ y: parseFloat(lbls8), label: 'S8' },
						{ y: parseFloat(lbls9), label: 'S9' },
                        { y: parseFloat(lbls10), label: 'S10' },
                        { y: parseFloat(lbls11), label: 'S11' },
                        { y: parseFloat(lbls12), label: 'S12' }
                    ]
                }
                ]
            });
            chart.render();
        }
        function MostrarOcultarDiv() {
            var lbl = document.getElementById('lblS1').innerHTML;
            alert(lbl);
            alert("doing..!!!")
        }
        function BenerarBarras() {
            var chart = new CanvasJS.Chart('chartContainer', {
                title: {
                    text: 'Precipitación Semanal (mm)'
                },
                axisY: {
                    title: 'Porcentaje %'
                },
                data: [
                {
                    type: 'stackedColumn',
                    legendText: 'S1 (Semana1).',
                    showInLegend: 'True',
                    indexLabel: '#total mm',
                    indexLabelPlacement: 'outside',
                    dataPoints: [
						{ y: 92, label: 'S1' },
						{ y: 87, label: 'S2' },
						{ y: 80, label: 'S3' },
						{ y: 70, label: 'S4' },
						{ y: 60, label: 'S5' },
						{ y: 50, label: 'S6' },
						{ y: 45, label: 'S7' },
						{ y: 40, label: 'S8' },
						{ y: 30, label: 'S9' },
                        { y: 20, label: 'S10' },
                        { y: 10, label: 'S11' },
                        { y: 5, label: 'S12' }
                    ]
                }
                ]
            });
            chart.render();
        }
    </script>
    <title>CanvasJS Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="chartContainer" style="border-color: #FF3300; height: 450px; width: 970px;"></div>
        <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generar" />--%>
        <asp:Label ID="lblS1" runat="server" Visible="True" ></asp:Label>
        <asp:Label ID="lblS2" runat="server" Visible="True" ></asp:Label>
        <asp:Label ID="lblS3" runat="server" Visible="True"></asp:Label>
        <asp:Label ID="lblS4" runat="server" Visible="True"></asp:Label>
        <asp:Label ID="lblS5" runat="server" Visible="True"></asp:Label>
        <asp:Label ID="lblS6" runat="server" Visible="True"></asp:Label>
        <asp:Label ID="lblS7" runat="server" Visible="True"></asp:Label>
        <asp:Label ID="lblS8" runat="server" Visible="True"></asp:Label>
        <asp:Label ID="lblS9" runat="server" Visible="True"></asp:Label>
        <asp:Label ID="lblS10" runat="server" Visible="True"></asp:Label>
        <asp:Label ID="lblS11" runat="server" Visible="True"></asp:Label>
        <asp:Label ID="lblS12" runat="server" Visible="True"></asp:Label>
        <%--<asp:TextBox ID="txtDato" runat="server"></asp:TextBox>--%>
    </form>
</body>
</html>


