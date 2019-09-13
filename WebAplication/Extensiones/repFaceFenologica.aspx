<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repFaceFenologica.aspx.cs" Inherits="WebAplication.Extensiones.repFaceFenologica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
           <link href="../css/EmapaStyele.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="TableBorder">
            <tr>
                <td width="200" rowspan="3">
                    <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td><div style="text-align: center">REGISTRO</div></td>
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ 303 R05</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">SEGUIMIENTO DEL CULTIVO DE
                    <asp:Label ID="LblPrograma" runat="server"></asp:Label>
&nbsp;SEGÚN FASE FENOLÓGICA</div></td>
                <td>
                    <div style="text-align: center">Versión 1</div></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td width="70">&nbsp;</td>
                <td width="70">&nbsp;</td>
                <td width="70">&nbsp;</td>
                <td width="200"><asp:Label ID="LblIdInsOrg" runat="server" Visible="False"></asp:Label>
                </td>
                <td width="70">&nbsp;</td>
                <td>
                <asp:Label ID="LblIdUsuario" runat="server" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>CAMPAÑA:</td>
                <td>
                    <asp:Label ID="LblCamp" runat="server"></asp:Label>
                    <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
                </td>
                <td>REGIONAL:</td>
                <td>
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
                    <asp:Label ID="LblIdReg" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblNumSegCult" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>jose</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:GridView ID="GVDetalleFenologiaTrigo" runat="server" AutoGenerateColumns="False" style="font-size: xx-small" OnRowCreated="GVDetalleFenologiaTrigo_RowCreated" Visible="False" CssClass="TableBorder2">
            <Columns>
                <asp:BoundField DataField="Id_Face_Feonologica" HeaderText="Id" Visible="False" />
                <asp:BoundField DataField="Sigla" HeaderText="Organizaciones" >
                <ItemStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField DataField="Num_Boletas_Inspec" HeaderText="N° Bol" >
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Charla_Tecnica" HeaderText="Ch. Tec." Visible="False" >
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Num_Prod_Vigentes" HeaderText="N° B.Vig." >
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Sup_Actual" HeaderText="Sup sem. (ha)" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Variedad_Semilla" HeaderText="Varied" >
                <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaAvnSiemIni" HeaderText="F Inicial" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaAvnSiemFin" HeaderText="F Final" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaAvnSiemAvan" HeaderText="Avance %" >
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="GerminacionIni" HeaderText="Germinación emergencia" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="PlantulaIni" HeaderText="Plántula" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="MacollamientoIni" HeaderText="Macollamiento" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="EmbucheIni" HeaderText="Embuche" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="EspigazonIni" HeaderText="Espigazon" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="FloracionIni" HeaderText="Floración" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="LlenadoGranoIni" HeaderText="Llenado grano" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="MaduracionIni" HeaderText="Maduración" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="CosechaAcopioAvan" HeaderText="Avance %" >
                <ItemStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="CosechaAcopioRend" HeaderText="Rend" >
                <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaCosechaIni" HeaderText="Cosecha Ini" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaCosechaFin" HeaderText="Cosecha Fin" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Observacion" HeaderText="Obs." >
                <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="Fecha_Semana_Envio" HeaderText="De fecha:" />
            </Columns>
        </asp:GridView>
        <table class="TableBorder2">
            <tr>
                <td width="100"><div style="text-align: right; font-weight: 700">TOTALES:</div></td>
                <td width="40">&nbsp;</td>
                <td width="40">
                    <asp:Label ID="LblTotNumBenef" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotSupSem" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="80"></td>
                <td width="50"></td>
                <td width="50"></td>
                <td width="50">
                    <asp:Label ID="LblTotAvSiem" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotGerm" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotPlant" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotMacolla" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotEmbu" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotEspi" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotFlora" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotLlenGran" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50">
                    <asp:Label ID="LblTotMadura" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="40">
                    <asp:Label ID="LblTotAvCos" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="30">
                    <asp:Label ID="LblTotRend" runat="server" style="font-weight: 700" Text="0"></asp:Label>
                </td>
                <td width="50"></td>
                <td width="50"></td>
                <td width="150"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
    </table>
        <asp:GridView ID="GVDetalleFenologiaMaiz" runat="server" CssClass="TableBorder" Visible="False" AutoGenerateColumns="False" style="font-size: xx-small" OnRowCreated="GVDetalleFenologiaMaiz_RowCreated">
            <Columns>
                <asp:BoundField DataField="Sigla" HeaderText="Organización" />
                <asp:BoundField DataField="Num_Boletas_Inspec" HeaderText="N° Boletas" />
                <asp:BoundField DataField="Charla_Tecnica" HeaderText="Charla Técnica" />
                <asp:BoundField DataField="Num_Prod_Vigentes" HeaderText="N° Benef Vigentes" />
                <asp:BoundField DataField="Sup_Actual" HeaderText="Sup Sembrada (ha)" />
                <asp:BoundField DataField="Variedad_Semilla" HeaderText="Variedad Semilla" />
                <asp:BoundField DataField="FechaAvnSiemIni" HeaderText="F Inicial" />
                <asp:BoundField DataField="FechaAvnSiemFin" HeaderText="F Final" />
                <asp:BoundField DataField="FechaAvnSiemAvan" HeaderText="Avance %" />
                <asp:BoundField DataField="Emergencia5dias" HeaderText="Emergencia (5dias)" />
                <asp:BoundField DataField="HojasDesplegadas1y2" HeaderText="1 y 2 hojas %" />
                <asp:BoundField DataField="HojasDesplegadas3y4" HeaderText="3 y 4 hojas % " />
                <asp:BoundField DataField="HojasDesplegadas5y6" HeaderText="5 y 6 hojas %" />
                <asp:BoundField DataField="HojasDesplegadas7y8" HeaderText="7 y 8 hojas %" />
                <asp:BoundField DataField="HojasDesplegadas9y10" HeaderText="9 y 10 hojas %" />
                <asp:BoundField DataField="HojasDesplegadas11oMas" HeaderText="11 o mas hojas %" />
                <asp:BoundField DataField="FloracionyPolinizacion" HeaderText="Floración Masculina y Polinizacion %" />
                <asp:BoundField DataField="EstigmasVisiblesyAmpolla" HeaderText="Estigmas Visibles y Ampolla %" />
                <asp:BoundField DataField="GranoLechosoyMasoso" HeaderText="Grano Lechoso y Masoso %" />
                <asp:BoundField DataField="EtapaDentadayMadurez" HeaderText="Etapa Dentada y Madurez Fisiologica %" />
                <asp:BoundField DataField="CosechaAcopioAvan" HeaderText="Avance %" />
                <asp:BoundField DataField="CosechaAcopioRend" HeaderText="Rendimiento %" />
                <asp:BoundField DataField="FechaCosechaIni" HeaderText="F Inicial" />
                <asp:BoundField DataField="FechaCosechaFin" HeaderText="F Final" />
                <asp:BoundField DataField="Observacion" HeaderText="Observación" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GVDetalleFenologiaArroz" runat="server" AutoGenerateColumns="False" style="font-size: xx-small" OnRowCreated="GVDetalleFenologiaArroz_RowCreated">
            <Columns>
                <asp:BoundField DataField="Personeria_Juridica" HeaderText="Organización" />
                <asp:BoundField DataField="Num_Boletas_Inspec" HeaderText="N° Boletas" />
                <asp:BoundField DataField="Charla_Tecnica" HeaderText="Charla Tecnica" />
                <asp:BoundField DataField="Num_Prod_Vigentes" HeaderText="N° Benef Vigentes" />
                <asp:BoundField DataField="Sup_Actual" HeaderText="Superficie sembrada (ha)" />
                <asp:BoundField DataField="Variedad_Semilla" HeaderText="Variedad semilla" />
                <asp:BoundField DataField="FechaAvnSiemIni" HeaderText="F Inicial" />
                <asp:BoundField DataField="FechaAvnSiemFin" HeaderText="F Final" />
                <asp:BoundField DataField="FechaAvnSiemAvan" HeaderText="Avance %" />

                <asp:BoundField DataField="GerminacionIni" HeaderText="Ini %" />
                <asp:BoundField DataField="GerminacionFin" HeaderText="Fin %" />
                
                <asp:BoundField DataField="PlantulaIni" HeaderText="Ini %" />
                <asp:BoundField DataField="PlantulaFin" HeaderText="Fin %" />
                <asp:BoundField DataField="MacollamientoIni" HeaderText="Ini %" />
                <asp:BoundField DataField="MacollamientoFin" HeaderText="Fin %" />
                <asp:BoundField DataField="PaniculaIni" HeaderText="Ini %" />
                <asp:BoundField DataField="PaniculaFin" HeaderText="Fin %" />
                <asp:BoundField DataField="FloracionIni" HeaderText="Ini %" />
                <asp:BoundField DataField="FloracionFin" HeaderText="Fin %" />
                <asp:BoundField DataField="GranoLechosoIni" HeaderText="Ini %" />
                <asp:BoundField DataField="GranoLechosoFin" HeaderText="Fin %" />
                <asp:BoundField DataField="MaduracionIni" HeaderText="Ini %" />
                <asp:BoundField DataField="MaduracionFin" HeaderText="Fin %" />
                <asp:BoundField DataField="CosechaAcopioAvan" HeaderText="Avance %" />
                <asp:BoundField DataField="CosechaAcopioRend" HeaderText="Rend" />
                <asp:BoundField DataField="FechaCosechaIni" HeaderText="Cosecha Ini" />
                <asp:BoundField DataField="FechaCosechaFin" HeaderText="Cosecha Fin" />
                <asp:BoundField DataField="Observacion" HeaderText="Observaciones" />
            </Columns>
        </asp:GridView>
        <table class="TableBorder">
            <tr>
                <td width="80">&nbsp;</td>
                <td width="300">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Elaborado por:</td>
                <td>&nbsp;</td>
                <td>VoBo</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1">Nombre y Cargo</td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
