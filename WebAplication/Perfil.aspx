<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="WebAplication.Perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Perfil de Usuario</title>
    <style type="text/css">
        .auto-style1 {
            height: 36px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #C0C0C0">
    <table >
        <tr align="center">            
            <td style="background-color: #000080">
               <h2><asp:Label ID="Label2" runat="server" Text="SPIA - EMAPA" style="color: #FFFFFF" Width="700px"></asp:Label></h2></td>
        </tr>
        <tr align="center">
            <td style="background-color: #000080">
               <h3><asp:Label ID="Label1" runat="server" Text="PERFIL USUARIO" style="color: #FFFFFF"></asp:Label></h3></td>
        </tr>        
    </table>        
    <br />
        <br />
    <table >
        <tr>
            <td style="width: 190px">Id_Usuario</td>
            <td><asp:TextBox ID="txt_Id_Usuario" runat="server" Width="500px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Regional</td>            
            <td><asp:TextBox ID="txt_Id_Regional" runat="server" Width="500px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Rol</td>
            <td><asp:TextBox ID="txt_Id_Rol" runat="server" Width="500px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Categoria</td>            
            <td><asp:TextBox ID="txt_Id_Categoria" runat="server" Width="500px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Cargo</td>            
            <td><asp:TextBox ID="txt_Cargo" runat="server" Width="500px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Ingrese Contraseña Anterior</td>            
            <td><asp:TextBox ID="txt_Contrasena_Antigua" runat="server" Width="500px" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Contraseña</td>            
            <td><asp:TextBox ID="txt_Contrasena" runat="server" Width="500px" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Repetir Contraseña</td>            
            <td><asp:TextBox ID="txt_Repetir_Contrasena" runat="server" Width="500px" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Estado (Activo)</td>
            <td>
                <asp:CheckBox ID="Chk_Estado" runat="server" Enabled="False"/></td>
        </tr> 
        <tr>
            <td colspan ="2" class="auto-style1">
                <table  align="center">
                    <tr>
                        <td><asp:Button ID="btCambiar" runat="server" Text="Cambiar" OnClick="btCambiar_Click" Height="30px" Width="100px" /></td>
                        <td><asp:Button ID="btCancelar" runat="server" Text="Cancelar" OnClick="btCancelar_Click" Height="30px" Width="100px"/></td>
                    </tr>
                </table>
            </td>            
        </tr>    
          
    </table>
        <asp:Label Font-Bold="True" ForeColor="Red" ID="lblError" runat="server"></asp:Label>    
    </div>
    </form>
</body>
</html>
