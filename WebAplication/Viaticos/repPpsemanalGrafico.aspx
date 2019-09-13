<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repPpsemanalGrafico.aspx.cs" Inherits="WebAplication.Viaticos.repPpsemanalGrafico" %>

<!DOCTYPE html>
<html>
<head>
    <script src="../Scripts/canvasjs.min.js"></script>
    <script type='text/javascript'>
        window.onload = function () {
            var lbls1 = document.getElementById('lblS1').innerHTML; //alert(lbls1);
            var lbls2 = document.getElementById('lblS2').innerHTML; //alert(lbls2);
            var lbls3 = document.getElementById('lblS3').innerHTML; //alert(lbls3);
            var lbls4 = document.getElementById('lblS4').innerHTML; //alert(lbls4);
            var lbls5 = document.getElementById('lblS5').innerHTML; //alert(lbls5);
            var lbls6 = document.getElementById('lblS6').innerHTML; //alert(lbls6);
            var lbls7 = document.getElementById('lblS7').innerHTML; //alert(lbls7);
            var lbls8 = document.getElementById('lblS8').innerHTML; //alert(lbls8);
            var lbls9 = document.getElementById('lblS9').innerHTML; //alert(lbls9);
            var lbls10 = document.getElementById('lblS10').innerHTML; //alert(lbls10);
            var lbls11 = document.getElementById('lblS11').innerHTML; //alert(lbls11);
            var lbls12 = document.getElementById('lblS12').innerHTML; //alert(lbls12);
            var lbls13 = document.getElementById('lblS13').innerHTML; //alert(lbls13);
            var lbls14 = document.getElementById('lblS14').innerHTML; //alert(lbls14);
            var lbls15 = document.getElementById('lblS15').innerHTML; //alert(lbls15);
            var lbls16 = document.getElementById('lblS16').innerHTML; //alert(lbls16);
            var lbls17 = document.getElementById('lblS17').innerHTML; //alert(lbls17);
            var lbls18 = document.getElementById('lblS18').innerHTML; //alert(lbls18);
            var lbls19 = document.getElementById('lblS19').innerHTML; //alert(lbls19);
            var lbls20 = document.getElementById('lblS20').innerHTML; //alert(lbls20);
            var lbls21 = document.getElementById('lblS21').innerHTML; //alert(lbls21);
            var lbls22 = document.getElementById('lblS22').innerHTML; //alert(lbls22);
            var lbls23 = document.getElementById('lblS23').innerHTML; //alert(lbls23);
            var lbls24 = document.getElementById('lblS24').innerHTML; //alert(lbls24);
            var lbls25 = document.getElementById('lblS25').innerHTML; //alert(lbls25);
            var lbls26 = document.getElementById('lblS26').innerHTML; //alert(lbls26);
            var lbls27 = document.getElementById('lblS27').innerHTML; //alert(lbls27);
            var lbls28 = document.getElementById('lblS28').innerHTML; //alert(lbls28);
            var lbls29 = document.getElementById('lblS29').innerHTML; //alert(lbls29);
            var lbls30 = document.getElementById('lblS30').innerHTML; //alert(lbls30);
            var lbls31 = document.getElementById('lblS31').innerHTML; //alert(lbls31);
            var lbls32 = document.getElementById('lblS32').innerHTML; //alert(lbls32);
            //var lblss = document.getElementById('lblSS').innerHTML; alert(lblss);

            var chart = new CanvasJS.Chart('chartContainer', {
                title: {
                    text: 'Precipitación Semanal (mm)'
                },
                axisY: {
                    title: '% en Milimetros'
                },
                data: [
                {
                    type: 'stackedColumn',
                    legendText: 'S1 (Semana 1)',
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
                        { y: parseFloat(lbls12), label: 'S12' },
                        { y: parseFloat(lbls13), label: 'S13' },
                        { y: parseFloat(lbls14), label: 'S14' },
                        { y: parseFloat(lbls15), label: 'S15' },
                        { y: parseFloat(lbls16), label: 'S16' },
                        { y: parseFloat(lbls17), label: 'S17' },
                        { y: parseFloat(lbls18), label: 'S18' },
                        { y: parseFloat(lbls19), label: 'S19' },
                        { y: parseFloat(lbls20), label: 'S20' },
                        { y: parseFloat(lbls21), label: 'S21' },
                        { y: parseFloat(lbls22), label: 'S22' },
                        { y: parseFloat(lbls23), label: 'S23' },
                        { y: parseFloat(lbls24), label: 'S24' },
                        { y: parseFloat(lbls25), label: 'S25' },
                        { y: parseFloat(lbls26), label: 'S26' },
                        { y: parseFloat(lbls27), label: 'S27' },
                        { y: parseFloat(lbls28), label: 'S28' },
                        { y: parseFloat(lbls29), label: 'S29' },
                        { y: parseFloat(lbls30), label: 'S30' },
                        { y: parseFloat(lbls31), label: 'S31' },
                        { y: parseFloat(lbls32), label: 'S32' }                        
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
                    legendText: lblss,
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
                        { y: 41, label: 'S9' },
                        { y: 41, label: 'S9' },
                        { y: 41, label: 'S10' },
                        { y: 41, label: 'S11' },
                        { y: 41, label: 'S12' },
                        { y: 41, label: 'S13' },
                        { y: 41, label: 'S14' },
                        { y: 41, label: 'S15' },
                        { y: 41, label: 'S16' },
                        { y: 41, label: 'S17' },
                        { y: 41, label: 'S18' },
                        { y: 41, label: 'S19' },
                        { y: 41, label: 'S20' },
                        { y: 41, label: 'S21' },
                        { y: 41, label: 'S22' },
                        { y: 41, label: 'S23' },
                        { y: 41, label: 'S24' },
                        { y: 41, label: 'S25' },
                        { y: 41, label: 'S26' },
                        { y: 41, label: 'S27' },
                        { y: 41, label: 'S28' },
                        { y: 41, label: 'S29' },
                        { y: 41, label: 'S30' },
                        { y: 41, label: 'S31' },
                        { y: 41, label: 'S32' }                        
                    ]
                }
                ]
            });
            chart.render();
        }
    </script>
    <title>Precipitación Semanal (mm)</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="chartContainer" style="border-color: #FF3300; height: 400px; width: 1050px;"></div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generar" Enabled="False" Visible="False" />
        <asp:Label ID="lblS1" runat="server"></asp:Label>
        <asp:Label ID="lblS2" runat="server"></asp:Label>
        <asp:Label ID="lblS3" runat="server"></asp:Label>
        <asp:Label ID="lblS4" runat="server"></asp:Label>
        <asp:Label ID="lblS5" runat="server"></asp:Label>
        <asp:Label ID="lblS6" runat="server"></asp:Label>
        <asp:Label ID="lblS7" runat="server"></asp:Label>
        <asp:Label ID="lblS8" runat="server"></asp:Label> 
        <asp:Label ID="lblS9" runat="server"></asp:Label> 
        <asp:Label ID="lblS10" runat="server"></asp:Label> 
        <asp:Label ID="lblS11" runat="server"></asp:Label> 
        <asp:Label ID="lblS12" runat="server"></asp:Label> 
        <asp:Label ID="lblS13" runat="server"></asp:Label> 
        <asp:Label ID="lblS14" runat="server"></asp:Label> 
        <asp:Label ID="lblS15" runat="server"></asp:Label> 
        <asp:Label ID="lblS16" runat="server"></asp:Label> 
        <asp:Label ID="lblS17" runat="server"></asp:Label> 
        <asp:Label ID="lblS18" runat="server"></asp:Label> 
        <asp:Label ID="lblS19" runat="server"></asp:Label> 
        <asp:Label ID="lblS20" runat="server"></asp:Label> 
        <asp:Label ID="lblS21" runat="server"></asp:Label> 
        <asp:Label ID="lblS22" runat="server"></asp:Label> 
        <asp:Label ID="lblS23" runat="server"></asp:Label> 
        <asp:Label ID="lblS24" runat="server"></asp:Label> 
        <asp:Label ID="lblS25" runat="server"></asp:Label> 
        <asp:Label ID="lblS26" runat="server"></asp:Label> 
        <asp:Label ID="lblS27" runat="server"></asp:Label> 
        <asp:Label ID="lblS28" runat="server"></asp:Label> 
        <asp:Label ID="lblS29" runat="server"></asp:Label> 
        <asp:Label ID="lblS30" runat="server"></asp:Label> 
        <asp:Label ID="lblS31" runat="server"></asp:Label> 
        <asp:Label ID="lblS32" runat="server"></asp:Label> 

        <asp:Label ID="lblSS" runat="server" Text="By Luis" Visible="False"></asp:Label> 
        <asp:TextBox ID="txtDato" runat="server" Enabled="False" Visible="False"></asp:TextBox>
    </form>
     
</body>
     
</html>