<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repSeguimientosTecnicos.aspx.cs" Inherits="WebAplication.Extensiones.repSeguimientosTecnicos" %>

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
                <td width="200"><div style="text-align: center">E-EMP/GP/P/ 30X XXX</div></td>
            </tr>
            <tr>
                <td><div style="text-align: center">REPORTE SEGUIMIENTOS TECNICOS REALIZADOS
                    </div></td>
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
                <td>Fecha:</td>
                <td>
                    <asp:Label ID="LblFechaSeg" runat="server"></asp:Label>
                &nbsp;
                </td>
                <td width="70">Hora:</td>
                <td>
                    <asp:Label ID="LblHoraSeg" runat="server"></asp:Label>
                </td>
                <td width="55">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td width="80"><div style="text-align: right">N°</div></td>
                <td>
                    <asp:Label ID="LblNum" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Nombre del agricultor:</td>
                <td class="auto-style1">
                    <asp:Label ID="LblProductor" runat="server"></asp:Label>
                    , CI:
                    <asp:Label ID="LblCedula" runat="server"></asp:Label>
                </td>
                <td class="auto-style1">Organización:</td>
                <td class="auto-style1">
                    <asp:Label ID="LblOrg" runat="server"></asp:Label>
                </td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style2">Comunidad:</td>
                <td class="auto-style2">
                    <asp:Label ID="LblComunidad" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">Municipio:</td>
                <td class="auto-style2">
                    <asp:Label ID="LblMunicipio" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">Provincia:</td>
                <td class="auto-style2">
                    <asp:Label ID="LblProvincia" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">Departamento:</td>
                <td class="auto-style2">
                    <asp:Label ID="LblDep" runat="server"></asp:Label>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>Nombre del Tecnico:</td>
                <td>
                    <asp:Label ID="LblTecnico" runat="server"></asp:Label>
                    <asp:Label ID="LblIdUser" runat="server" Visible="False"></asp:Label>
                </td>
                <td>Programa:</td>
                <td>
                    <asp:Label ID="LblPrograma" runat="server"></asp:Label>
                </td>
                <td>Campaña:</td>
                <td>
                    <asp:Label ID="LblCamp" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Regional:</td>
                <td>
                    <asp:Label ID="LblRegional" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="LblEtapa" runat="server" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
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
            </tr>
        </table>
    
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <div class="SubTitulo2">
                Coordenadas de Verificacion:</div>
            <asp:GridView ID="GVCoordenadas" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
                <Columns>
                    <asp:BoundField DataField="Num_Parcela" HeaderText="Parcela">
                    <ItemStyle Width="20px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CoordenadaX" HeaderText="Coordenada X" />
                    <asp:BoundField DataField="CoordenadaY" HeaderText="Coordenada Y" />
                </Columns>
            </asp:GridView>
            <table class="TableBorder">
                <tr>
                    <td width="50">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td width="100">Observación:</td>
                    <td rowspan="2">
                        <asp:Label ID="LblObsParcela" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Recomendación:</td>
                    <td rowspan="2">
                        <asp:Label ID="LblRecomParcela" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    
        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <div class="SubTitulo2">
                Datos Siembra:</div>
            <asp:GridView ID="GVSiembra" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
                <Columns>
                    <asp:BoundField DataField="Boleta_Numero" HeaderText="N° Boleta" />
                    <asp:BoundField DataField="Fecha_SiembraINI" HeaderText="Fecha inicial de siembra" />
                    <asp:BoundField DataField="Fecha_SiembraFIN" HeaderText="Fecha final de siembra" />
                    <asp:BoundField DataField="Sistema_Siembra" HeaderText="Sistema siembra" />
                    <asp:BoundField DataField="Cultivo_Anterior" HeaderText="Cultivo anterior" />
                    <asp:BoundField DataField="Variedad_Semilla" HeaderText="Variedad de semilla" />
                    <asp:BoundField DataField="Avance_Siembra" HeaderText="% Avance de siembra" Visible="False" />
                </Columns>
            </asp:GridView>
            <table class="TableBorder">
                <tr>
                    <td width="50">&nbsp;</td>
                    <td colspan="2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td width="100">Observación:</td>
                    <td>
                        <asp:Label ID="LblObsParcela0" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Recomendación:</td>
                    <td>
                        <asp:Label ID="LblRecomParcela0" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Visible="False">
            <div class="SubTitulo2">
                Datos del Cultivo:</div>
            <asp:GridView ID="GVCultivo" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
                <Columns>
                    <asp:BoundField DataField="Boleta_Numero" HeaderText="N° Boleta" />
                    <asp:BoundField DataField="Estado" HeaderText="Etapa" />
                    <asp:BoundField DataField="Nom_Fenologia" HeaderText="Estado Fenologico" />
                    <asp:BoundField DataField="Porcentaje_FF" HeaderText="%" />
                    <asp:BoundField DataField="Elemento" HeaderText="Adversidades Ocurridas" Visible="False" />
                    <asp:BoundField DataField="Nombre_Elemento" HeaderText="Nombre adversidad" Visible="False" />
                    <asp:BoundField DataField="Intencidad" HeaderText="Intencidad" Visible="False" />
                    <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento Recomendado" Visible="False" />
                </Columns>
            </asp:GridView>
            <table class="TableBorder">
                <tr>
                    <td width="150">&nbsp;</td>
                    <td><div style="text-align: center">ADVERSIDADES PRESENTADAS</div></td>
                    <td width="150">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:GridView ID="GVAdversidad" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
                            <Columns>
                                <asp:BoundField DataField="Adversidad" HeaderText="Adversidad" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                <asp:BoundField DataField="Intencidad" HeaderText="Intencidad" />
                                <asp:BoundField DataField="Porcentage" HeaderText="Porcentage" />
                                <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" />
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table class="TableBorder">
                <tr>
                    <td width="50">&nbsp;</td>
                    <td colspan="3">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td width="100">Observación:</td>
                    <td>
                        <asp:Label ID="LblObsParcela1" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Recomendación:</td>
                    <td>
                        <asp:Label ID="LblRecomParcela1" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server">
            <div class="SubTitulo2">
                Datos del Cosecha:</div>
        
            <asp:GridView ID="GVCosecha" runat="server" AutoGenerateColumns="False" CssClass="TableBorder">
                <Columns>
                    <asp:BoundField DataField="Boleta_Numero" HeaderText="N° Boleta" />
                    <asp:BoundField DataField="Estado" HeaderText="Etapa" />
                    <asp:BoundField DataField="Nom_Fenologia" HeaderText="Estado Fenologico" />
                    <asp:BoundField DataField="Porcentaje_FF" HeaderText="%" />
                    <asp:BoundField DataField="Elemento" HeaderText="Adversidades Ocurridas" Visible="False" />
                    <asp:BoundField DataField="Nombre_Elemento" HeaderText="Nombre adversidad" Visible="False" />
                    <asp:BoundField DataField="Intencidad" HeaderText="Intencidad" Visible="False" />
                    <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento Recomendado" Visible="False" />
                </Columns>
            </asp:GridView>
            <table class="TableBorder">
                <tr>
                    <td width="50">&nbsp;</td>
                    <td colspan="3">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td width="100">Observación:</td>
                    <td>
                        <asp:Label ID="LblObsParcela2" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Recomendación:</td>
                    <td>
                        <asp:Label ID="LblRecomParcela2" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            </asp:Panel>
        <table class="TableBorder">
            <tr>
                <td width="150">&nbsp;</td>
                <td width="300">&nbsp;</td>
                <td width="60">&nbsp;</td>
                <td width="100">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td width="150">&nbsp;</td>
                <td width="300">&nbsp;</td>
                <td width="60">&nbsp;</td>
                <td width="100">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>TÉCNICO ENCARGADO:</td>
                <td><hr></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Nombre y cargo</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
    
        </div>
    </form>
</body>
</html>
