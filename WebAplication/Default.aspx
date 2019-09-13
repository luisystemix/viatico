<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAplication.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema [- .:: SPIA ::. -] </title> 
    <%--<link href="Styles/Site.css" rel="stylesheet" type="text/css" />  --%>

    <link href="css/EmapaStyele.css" rel="stylesheet" type="text/css" />  
    <link href="images/logo.ico" type="image/x-icon" rel="shortcut icon"/> 
    <link href="css/error.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            
            $('input[type="text"]').focus(function () {
                $(this).addClass("ControlOnFocus");
                $(this).removeClass("ControlOffFocus");
            });
            $('input[type="text"]').blur(function () {
                $(this).removeClass("ControlOnFocus");
                $(this).addClass("ControlOffFocus");
            });
            $.validator.addMethod("regex", function (value, element, regexp) {
                var re = new RegExp(regexp);
                return this.optional(element) || re.test(value);
            }, "No valido");
            $("#formLogin").validate({
                rules: {
                        <%=txtUser.UniqueID %>: { required: true, regex:"^([\na-zA-Z0-9\'\"´`, ()/!&#@.///:ñÑáéíóúÁÉÍÓÚç!Ç_-]+)$"},
                        <%=txtPassword.UniqueID %>:{required: true, regex:"^([\na-zA-Z0-9\'\"´`, ()/!&#@.///:ñÑáéíóúÁÉÍÓÚç!Ç_-]+)$"}
                },
                messages:{
                        <%=txtUser.UniqueID %>: { required: "*"},
                        <%=txtPassword.UniqueID %>:{required: "*"}
                }
            });

        });
    </script>
    <style type="text/css">
      
        body
        {
	        background-color: #e8edff;
	        margin-top:0px ;
	        margin-left:0px;
	        margin-right:0px;
	        font-size: 14px;
	        font-family: Arial, Helvetica, sans-serif;
        }
        .ControlOnFocus
        {
            background: #C3CDFF;
            color: Black; 
            border: 1px outset #05293F;
        }
 
        .ControlOffFocus
        {
            background: #FEEDA8;
            color: Black; 
            border: 1px outset #FFA100;
        }

    </style>
</head>
<body >
    <form id="formLogin" runat="server">
    <div align="center" style="background-color:#012A67">        
        <img src="images/spiaBlue.jpg"  alt="SPIA"/>
    </div>
    <table width="460" border="0" align="center" cellpadding="5" cellspacing="0">                
                  <tr>
                      <td colspan="2">
                           <h2 style="text-align: center">INGRESA TUS DATOS</h2>
                           <p style="text-align: center">Si eres Nuevo Usuario, Comunicate con el Administrador para REGISTRARTE</p>
                                            </td>
                    </tr>
                </table>
                <table width="460" align="center" rules="none" border="3" style="border-color:Blue"   >
							  <tr>
                                <td align="left" valign="middle" 
                                      style=" height: 15px; font-weight: bold;width:240px"  class="textoDerecha">
                                    Ingreso</td>
                                <td align="left" style="padding-right: 5px;  height: 15px; width:220px">
                                    <a href="#" style="font-weight: bold;"> Necesitas Ayuda? </a></td>
                              </tr>                            
                              <tr>
                                <td  align="left" valign="middle" style="padding-top: 5px; height: 20px;" 
                                      class="textoDerecha">
                                    Usuario: </td>
                                <td  align="left" valign="middle" style="padding-right:5px; padding-top: 5px; width: 376px; height: 20px;">
                                
                                <asp:TextBox ID="txtUser" runat="server" CssClass="ControlOffFocus" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>                      
                                    <asp:Label ID="lblUser" runat="server"></asp:Label>   
                                </td>
                              </tr>
                              <tr>
                                <td  align="left" valign="middle"  style="height: 20px;"  class="textoDerecha">
                                    Contraseña: </td>
                                <td  align="left" valign="middle" style="padding-right:5px; width: 376px; height: 20px;">
                                  <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="ControlOffFocus"></asp:TextBox>                                    
                                    <asp:Label ID="lblPass" runat="server"></asp:Label>
                                  </td>
                              </tr>
                              <tr  align="center" valign="middle">
                                <td colspan="2" rowspan="">
                                    &nbsp;
                                    <asp:Button  ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" class="bottonLog" Height="35px" Width="65px" />
                                    <br />
                                    <a href="#">Olvidaste tu password?</a>
                                    <br />
                                    <br />
                                    <asp:Label ID="lblErrorLOG" runat="server" ForeColor="Red" /><asp:Label Font-Bold="True" ForeColor="Red" ID="lblError" runat="server"></asp:Label></td>
                              </tr>
                          </table>
        <br />                          
        <br />
        <br />
        <br />
        <br />
        <table><tr><td>
            <asp:Label ID="Label1" runat="server" Text="v. 2.0.5" Font-Size="XX-Small" ForeColor="#999999"></asp:Label></td></tr></table>
    </form>
</body>
</html>
