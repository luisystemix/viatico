<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repBoletaSeguimiento.aspx.cs" Inherits="WebAplication.Extensiones.repBoletaSeguimiento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Boleta de Seguimiento / Asistencia Técnica</title>
<style type="text/css">
        .auto-style1 {
            width: 706px;
        }        
        .cabecera {
            font-family: Arial;
            font-size: 13px;
            text-align: justify;
            font-weight: bold;
        } 
        .titulos{
            font-family: Arial;
            font-size: 15px;
            text-align: justify;
            font-weight: bold;
        } 
        .cuerpo{
            font-family: Arial;
            font-size: 13px;
            text-align: justify;
        } 
        .obs_rec{
            font-family: Arial;
            font-size: 10px;
            text-align: left;
        } 
        table, th, td {
    	/*border: 1px solid black;
    	border-collapse: collapse;*/
		}
        #Text1 {
            height: 75px;
            width: 75px;
        }
        .piefirma {font-size: 9px!important;}		
        .codigo {font-size: 12px!important; font-family:Arial}
        .tit_cal {font-size: 8px!important;}
    </style>
</head>
<body style="width: 850px; border:1px solid black; text-align:center">
    <form id="form1" runat="server">
    <div>
        <!--CABECERAS-->
        <table style="width: 850px; vertical-align:top; border: 1px solid black; border-collapse: collapse; text-align:center">
                    <tr>                    
                        <td valign="top" rowspan="2" style="width: 100px;height: 85px; vertical-align: top; text-align: center; border: 1px solid black">
                            <img border="0" src="../images/logo1.jpg" style="width: 100%; height: 100%; vertical-align: top;"/>
                        </td>
                        <td  style="text-align: center; width: 400px; height:40px; vertical-align: middle; border: 1px solid black">
                            <span class="cabecera" ><b>REGISTRO</b></span>                           
                        </td>
                        <td style="text-align: center; width: 100px; vertical-align: middle; border: 1px solid black">                           
                            <span class="codigo">E-EMP/GP/P/303 R02</span>                            
                        </td>
                    </tr>
                    <tr>                      
                        <td style="vertical-align:middle; text-align: center; border: 1px solid black">                                                          
                          <span class="cabecera"><b>BOLETA DE SEGUIMIENTO / ASISTENCIA TÉCNICA</b><br/></span>                          
                        </td> 
                        <td style="text-align: center; vertical-align:middle; border: 1px solid black">                            
                            <span class="codigo"><b>Versión 2</b></span>
                        </td>
                    </tr>
        </table>
        <!--DATOS FECHA-->        
        <table  border="0" style="width: 850px; vertical-align:top; text-align:center" >
            <tr>
                <td style="width: 177px;height: 65px; vertical-align: top; text-align: center;">&nbsp;</td>                
                <td class="titulos">Fecha:</td>
                <td>
                    <table style="width: 130px; vertical-align:top; border: 1px solid black; border-radius:13px;">
                        <tr style="border: 1px solid black;">
                            <td class="titulos" style="border: 1px solid black; border-radius:13px;">Día</td>
                            <td class="titulos" style="border: 1px solid black; border-radius:13px;">Mes</td>
                            <td class="titulos" style="border: 1px solid black; border-radius:13px;">Año</td>
                        </tr>
                        <tr>
                            <td>01</td><td>01</td><td>0001</td>
                        </tr>
                    </table>
                </td>                
                <td>Nº 004151</td>
            </tr>
        </table>
        <!--DATOS PERSONA-->   
        <table  border="0" style="width: 850px; vertical-align:top; text-align:left" >
            <tr>
                <td style="width: 177px;vertical-align: top; text-align: left;">
                    <asp:Label ID="Label1" class="titulos" runat="server" Text="Nombre del beneficiario" Font-Bold="True"></asp:Label></td>                                
                <td colspan="3" style="border: 1px solid black; border-radius:13px; text-align:left">&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblnombrebeneficiario" class="cuerpo" runat="server" Text="beneficiario"></asp:Label></td>       
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" class="titulos" runat="server" Text="Organización" Font-Bold="True"></asp:Label>
                </td>
               <td style="border: 1px solid black; border-radius:13px; text-align:left">&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblorganizacion" class="cuerpo" runat="server" Text="organizacion"></asp:Label>
                </td>
                <td>&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" class="titulos" runat="server" Text="Comunidad" Font-Bold="True"></asp:Label>
                </td>
                <td style="border: 1px solid black; border-radius:13px; text-align:left">&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblcomunidad" class="cuerpo" runat="server" Text="comunidad"></asp:Label>
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" class="titulos" runat="server" Text="Municipio" Font-Bold="True"></asp:Label>
                </td>
               <td style="border: 1px solid black; border-radius:13px; text-align:left">&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblmunicipio" class="cuerpo" runat="server" Text="municipio"></asp:Label>
                </td>
                <td>&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label6" class="titulos" runat="server" Text="Programa" Font-Bold="True"></asp:Label>
                </td>
                <td style="border: 1px solid black; border-radius:13px; text-align:left">&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblprograma" class="cuerpo" runat="server" Text="programa"></asp:Label>
                </td>                
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label5" class="titulos" runat="server" Text="Campaña" Font-Bold="True"></asp:Label>
                </td>
               <td style="border: 1px solid black; border-radius:13px; text-align:left">&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblcampania" class="cuerpo" runat="server" Text="campaña"></asp:Label>
                </td>
                <td>&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label8" class="titulos" runat="server" Text="Regional" Font-Bold="True"></asp:Label>
                </td>
                <td style="border: 1px solid black; border-radius:13px; text-align:left">&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblregional" class="cuerpo" runat="server" Text="regional"></asp:Label>
                </td>                
            </tr>
        </table>
       <!--DATOS-->
        <p class="titulos">Recopilación de Datos</p>
        <table style="width: 850px; vertical-align:top; border: 1px solid black; border-collapse: collapse; text-align:center">            
                <tr>                  
                  <th style="width:200px;border: 1px solid black"colspan="2">                    
                    <span class="titulos">Coordenadas</span>
                  </th>
                  <th rowspan="2" style="width:80px;border: 1px solid black; vertical-align:top"><span class="titulos">Fecha de siembra</span></th>                  
                   <th rowspan="2" style="width:130px;border: 1px solid black; vertical-align:top" ><span class="titulos">Densidad de siembra (kg./ha.)</span></th>
                  <th rowspan="2" style="width:100px;border: 1px solid black; vertical-align:top" ><span class="titulos">Sistema de siembra</span></th>  
                  <th rowspan="2" style="width:100px;border: 1px solid black; vertical-align:top"><span class="titulos">Variedad</span></th>  
                    <th rowspan="2" style="width:150px;border: 1px solid black; vertical-align:top"><span class="titulos">Fase fenológica</span></th>  
                    <th rowspan="2" style="width:80px;border: 1px solid black; vertical-align:top"><span class="titulos">Cultivo anterior</span></th>  
                </tr>
                <tr>
                  <td style="width:100px; text-align:center;border: 1px solid black"><span class="titulos">X</span></td>
                  <td style="width:100px; text-align:center;border: 1px solid black"><span class="titulos">Y</span></td>                  
                </tr>
                <tr>
                  <td style="text-align:center;border: 1px solid black; vertical-align:top">
                      <asp:Label ID="lblcord_x" class="cuerpo" runat="server" Text="cord_X"></asp:Label>                      
                  </td>
                  <td style="text-align:center;border: 1px solid black; vertical-align:top">
                      <asp:Label ID="lblcord_y" class="cuerpo" runat="server" Text="cord_Y"></asp:Label>
                  </td>
                  <td style="text-align:center;border: 1px solid black; vertical-align:top">
                      <asp:Label ID="lblfecha_siembra" class="cuerpo" runat="server" Text="01/01/0001"></asp:Label>
                  </td>
                  <td style="text-align:center;border: 1px solid black; vertical-align:top">
                      <asp:Label ID="lbldensidad" class="cuerpo" runat="server" Text="densidad"></asp:Label>
                  </td>
                  <td style="text-align:center;border: 1px solid black; vertical-align:top">
                      <asp:Label ID="lblsistema_siembra" class="cuerpo" runat="server" Text="sistema_siembra"></asp:Label>
                  </td>
                  <td style="text-align:center;border: 1px solid black; vertical-align:top">
                      <asp:Label ID="lblsemilla" class="cuerpo" runat="server" Text="variedad/semilla"></asp:Label>
                  </td>
                    <td style="text-align:center;border: 1px solid black; vertical-align:top">
                        <asp:Label ID="lblfase" class="obs_rec" runat="server" Text="fase_fenológica"></asp:Label>
                    </td>
                    <td style="text-align:center;border: 1px solid black; vertical-align:top">
                        <asp:Label ID="lblcultivo_anterior" class="cuerpo" runat="server" Text="cultivo_anterior"></asp:Label>
                    </td>
                </tr>
        </table>
        <table style="width: 850px; vertical-align:top; border: 1px solid black; border-collapse: collapse; text-align:center">            
                <tr>                  
                  <th style="width:138px;border: 1px solid black"><span class="titulos">Maleza</span></th>
                  <th style="width:138px;border: 1px solid black"><span class="titulos">Intensidad</span></th>                  
                   <th style="width:138px;border: 1px solid black" ><span class="titulos">Tratamiento</span></th>
                  <th style="width:138px;border: 1px solid black" ><span class="titulos">Plaga/Enfermedad</span></th>  
                  <th style="width:138px;border: 1px solid black"><span class="titulos">Intensidad</span></th>  
                    <th style="width:138px;border: 1px solid black"><span class="titulos">Tratamiento</span></th>                      
                </tr>                
                <tr>
                  <td style="text-align:left;border: 1px solid black;width:138px; vertical-align:top">
                      <asp:Label ID="lblmaleza" class="obs_rec" runat="server" Text="-" Width="138px"></asp:Label>                      
                  </td>
                  <td style="text-align:left;border: 1px solid black;width:138px; vertical-align:top">
                      <asp:Label ID="lblmaleza_intensidad" class="obs_rec" runat="server" Text="-" Width="138px"></asp:Label>
                  </td>
                  <td style="text-align:left;border: 1px solid black;width:138px; vertical-align:top">
                      <asp:Label ID="lblmaleza_tratamiento" class="obs_rec" runat="server" Text="-" Width="138px"></asp:Label>
                  </td>
                  <td style="text-align:left;border: 1px solid black;width:138px; vertical-align:top">
                      <asp:Label ID="lblplaga_enf" class="obs_rec" runat="server" Text="-" Width="138px"></asp:Label>
                  </td>
                  <td style="text-align:left;border: 1px solid black;width:138px; vertical-align:top">
                      <asp:Label ID="lblplaga_enf_instensidad" class="obs_rec" runat="server" Text="-" Width="138px"></asp:Label>
                  </td>
                  <td style="text-align:left;border: 1px solid black;width:138px; vertical-align:top">
                      <asp:Label ID="lblplaga_enf_tratamiento" class="obs_rec" runat="server" Text="-" Width="138px"></asp:Label>
                  </td>                    
                </tr>
        </table>
        <p class="titulos">Observaciones</p>           
        <table  border="0" style="width: 850px; vertical-align:top; text-align:center" >
            <tr>                
                <td style="border: 1px solid black; border-radius:13px; text-align:left; width:835px">
                    <asp:Label ID="lblobservacion" class="obs_rec" runat="server" Text="Observaciones generales" Width="835px"></asp:Label></td>                       
            </tr>                       
        </table>
        <p class="titulos">Recomendaciones</p>           
        <table  border="0" style="width: 850px; vertical-align:top; text-align:center" >
            <tr>                
                <td style="border: 1px solid black; border-radius:13px; text-align:left; width:835px">
                    <asp:Label ID="lblrecomendacion" class="obs_rec" runat="server" Text="Recoendaciones generales" Width="835px"></asp:Label></td>                       
            </tr>                       
        </table>
        <br/><br/><br/><br/><br/>
        <table  border="0" style="width: 850px; vertical-align:top; text-align:center" >
            <tr>                
                <td style="width:5%">&nbsp;</td>
                <td style="width: 40%; text-align:left"><span class="obs_rec"><b>Nombre y firma T.C.</b>&nbsp;&nbsp;</span>
                    <asp:Label ID="lblnombrerevisor" class="obs_rec" runat="server" Text="nombre de revisor" Font-Overline="True"></asp:Label>
                </td>                       
                <td style="width:5%">&nbsp;</td>
                <td style="width:40%; text-align:right"><span class="obs_rec"><b>Firma beneficiario</b>&nbsp;&nbsp;</span>
                    <asp:Label ID="lblfirmabeneficiario" class="obs_rec" runat="server" Text="..........................................."></asp:Label>
                </td>
                <td style="width:5%">&nbsp;</td>
            </tr>                       
        </table>
    </div>
    </form>
</body>
</html>
