<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repDFGraficoSemanas.aspx.cs" Inherits="WebAplication.Viaticos.repDFGraficoSemanas" %>

<html>
<head>
    <script src="../Scripts/canvasjs.min.js"></script>
    <script type='text/javascript'>
        window.onload = function () {
            var lblS1 = document.getElementById('lblS1').innerHTML;
            //alert(lblS1);
            var lblS2 = document.getElementById('lblS2').innerHTML;
            //alert(lblS2);
            var lblS3 = document.getElementById('lblS3').innerHTML;
            //alert(lblS3);
            var lblS4 = document.getElementById('lblS4').innerHTML;
            //alert(lblS4);
            var lblS5 = document.getElementById('lblS5').innerHTML;
            //alert(lblS5);
            var lblS6 = document.getElementById('lblS6').innerHTML;
            //alert(lblS6);
            var lblS7 = document.getElementById('lblS7').innerHTML;
            //alert(lblS7);
            var lblS8 = document.getElementById('lblS8').innerHTML;
            //alert(lblS8);
            var lblSS = document.getElementById('lblSS').innerHTML;
            //alert(lblSS);
            var chart = new CanvasJS.Chart('chartContainer', {
                title: {
                    text: 'Fase Fenológica (Semana)'
                },
                axisY: {
                    title: '%'
                },
                data: [
                {
                    type: 'stackedColumn',
                    legendText: lblSS,
                    showInLegend: 'True',
                    indexLabel: '#total %',
                    indexLabelPlacement: 'outside',
                    dataPoints: [
						{ y: parseFloat(lblS1), label: 'Germinación' },
						{ y: parseFloat(lblS2), label: 'Plántula' },
						{ y: parseFloat(lblS3), label: 'Macollamiento' },
						{ y: parseFloat(lblS4), label: 'Embuche' },
						{ y: parseFloat(lblS5), label: 'Espigazón' },
						{ y: parseFloat(lblS6), label: 'Floración' },
						{ y: parseFloat(lblS7), label: 'Llenado_de_Grano' },
						{ y: parseFloat(lblS8), label: 'Maduración' }
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
                    title: '%'
                },
                data: [
                {
                    type: 'stackedColumn',
                    legendText: 'Semana 1 (S1)',
                    showInLegend: 'True',
                    indexLabel: '#total mm',
                    indexLabelPlacement: 'outside',
                    dataPoints: [
						{ y: 92, label: 'Germinación' },
						{ y: 87, label: 'Plántula' },
						{ y: 80, label: 'Macollamiento' },
						{ y: 70, label: 'Embuche' },
						{ y: 60, label: 'Espigazón' },
						{ y: 50, label: 'Floración' },
						{ y: 45, label: 'Llenado_de_Grano' },
						{ y: 40, label: 'Maduración' }						
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
    <div id="chartContainer" style="border-color: #FF3300; height: 400px; width: 1000px;"></div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generar" Visible="False" />
        <asp:Label ID="lblS1" runat="server" ></asp:Label>
        <asp:Label ID="lblS2" runat="server" ></asp:Label>
        <asp:Label ID="lblS3" runat="server" ></asp:Label>
        <asp:Label ID="lblS4" runat="server" ></asp:Label>
        <asp:Label ID="lblS5" runat="server" ></asp:Label>
        <asp:Label ID="lblS6" runat="server" ></asp:Label>
        <asp:Label ID="lblS7" runat="server" ></asp:Label>
        <asp:Label ID="lblS8" runat="server" ></asp:Label>
        <asp:Label ID="lblSS" runat="server" ></asp:Label>
        <asp:TextBox ID="txtDato" runat="server" Visible="False"></asp:TextBox>
    </form>
</body>
</html>
