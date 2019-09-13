<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repSolicitud.aspx.cs" Inherits="WebAplication.Viaticos.repSolicitud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="../css/EmapaStyele.css" rel="stylesheet" type="text/css" media="screen" />
        <link href="../css/EmapaStyele.css" rel="stylesheet" type="text/css" media="print" />
   

  

    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }
    </style>
   

  

</head>
<body>
    <div class="header">
    <form id="form1" runat="server">
    <div style="font-size: 9pt">
 
        <table class="TableBorder">
            <tr>
                <td width="200" rowspan="3">
                    <asp:Image ID="Image1" runat="server" Height="77px" ImageUrl="~/images/logo1.jpg" Width="130px" />
                </td>
                <td>&nbsp;</td>
                <td width="200"><div style="text-align: center">REGISTRO EUF/01 V2</div></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                   <div style="text-align: center"><asp:Label ID="LblIdSolicit" runat="server"></asp:Label></div> 
                </td>
            </tr>
            <tr>
                <td><div class="SubTitulo" style="text-align: center">SOLICITUD DE VIAJE</div></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <br />
    
        <table class="TableBorder">
            <tr>
                <td width="50">Nombre:</td>
                <td>
                    <asp:Label ID="LblAutorizar" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td width="45">Cargo:</td>
                <td>
                    <asp:Label ID="LblCargoAutorizar" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td><div style="font-weight: 700; background-color:#e1e3df; text-align:center">SOLICITA SE AUTORICE EL VIAJE DEL (A) SERVIDOR(A):</div></td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td width="50">Nombre:</td>
                <td>
                    <asp:Label ID="LblNombre" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td width="130">Cargo:</td>
                <td><asp:Label ID="LblCargo" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Fecha:</td>
                <td>
                    <asp:Label ID="LblFecha" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>Lugar de Funciones:</td>
                <td><asp:Label ID="LblRegional" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    
        <table class="TableBorder">
            <tr>
                <td><div style="font-weight: 700; background-color:#e1e3df; text-align:center">DATOS DE LA PLANIFICACIÓN DE VIAJE</div></td>
            </tr>
        </table>
    
        <asp:GridView ID="GVSolicitud" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
            <Columns>
                 <asp:TemplateField HeaderText="N°" ItemStyle-Width="20px" >
                <ItemTemplate>
                 <span><%#Container.DataItemIndex + 1%></span>
                </ItemTemplate>
         </asp:TemplateField>
                <asp:BoundField DataField="Cont" HeaderText="N°" ItemStyle-HorizontalAlign="Center" Visible="false"/>
                <asp:BoundField DataField="Tramo" HeaderText="Tramo"  ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Zona" HeaderText="Viaje" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Destino" HeaderText="Destino" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="Lugar" HeaderText="Lugar" Visible="False" />
                <asp:BoundField DataField="Objetivo" HeaderText="Objetivo especifico" Visible="False" />
                <asp:BoundField DataField="Fecha_Salida" HeaderText="Fecha" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="HoraSalida" HeaderText="Hora" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="Via_Transporte" HeaderText="Via" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="Tipo_Transporte" HeaderText="Tipo" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="Nombre_Transporte" HeaderText="Nombre" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="Identificador_Trasporte" HeaderText="Doc." ItemStyle-HorizontalAlign="Center" />
            </Columns>
        </asp:GridView>
        <table class="TableBorder">
            
            <tr>
                <td><div style="font-weight: 700; background-color:#e1e3df; text-align:center">MOTIVO DE VIAJE:</div></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td width="140" colspan="2">
                    <asp:Label ID="LblMotivo" runat="server"></asp:Label>
                    <br />
                    <br />
                </td>
            </tr>
            
            </table>
        <table class="TableBorder">
            <tr>
                <td class="AnchoColumnas"  style="text-align:center">Solicitado por:
                    <asp:Label ID="LblCi" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="LblCiSup" runat="server" Visible="False"></asp:Label>
                </td>
                <td class="AnchoColumnas" style="text-align:center"> Servidor Público</td>
                <td class="AnchoColumnas" style="text-align:center">Aprobado G.A.F.</td>
                <td class="AnchoColumnas" style="text-align:center">Orden de Liquidación U.F.</td>
            </tr>
          
        
        </table>
        <table class="TableBorder">
            <tr>
                <td colspan="4">
                    <br /><br /><br /><br /><br /><br />
                    <br /><br /><br /><br />
                    <br /><br /><br /><br />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        
        </table>

  <table width="100%" border="0" cellpadding="0" cellspacing="0" bordercolor="#999999">
  <tr>
    <td colspan="3" class="auto-style1"></td>
    <td colspan="2" class="auto-style1"><div style="text-align: center">TIPO DE VIAJE:
        <asp:Label ID="LblTipoViaje" Font-Bold="true" runat="server" Visible="true"></asp:Label>
                                                       </div> </td>
  </tr>
  <tr>
    <td width="88">&nbsp;</td>
    <td width="88">&nbsp;</td>
    <td width="88">&nbsp;</td>
    <td width="88">
        <%--<div style="text-align: center; border: 1px solid #CCCCCC">POA</div>--%>
        
    </td>
    <td width="88">
       <%-- <div style="text-align: center; border: 1px solid #CCCCCC;">Emergencia</div>--%>

    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <%--<td rowspan="7" style="border: 1px solid #CCCCCC; ">&nbsp;</td>
    <td rowspan="7" style="border: 1px solid #CCCCCC; ">&nbsp;</td>--%>
  </tr>
      <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    </tr>
      <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    </tr>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
     
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
     
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
     
</table>

    </div>
    </form>
        </div>
</body>
</html>
