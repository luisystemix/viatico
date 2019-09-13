<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistroDatosTec.aspx.cs" Inherits="WebAplication.Registro.frmRegistroDatosTec" %>
<%@ Register src="contEncabezado2.ascx" tagname="contEncabezado2" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

     <script type="text/javascript" src="../Scripts/validar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="SubTitulo">REGISTRO DE DATOS TECNICOS<asp:ScriptManager ID="ScriptManager1" runat="server">
         </asp:ScriptManager>
     </div>
     <table class="TableBorder">
     <tr>
         <td class="auto-style1" colspan="3">
             <uc1:contEncabezado2 ID="contEncabezado21" runat="server" />
         </td>
     </tr>
     <tr>
         <td class="auto-style1" width="200">
             <asp:HiddenField ID="HiddenFieldInsOrg" runat="server" />
             <asp:HiddenField ID="HiddenField_ID_PRO" runat="server" />
             <asp:HiddenField ID="HiddenFieldCampanhia" runat="server" />
             <asp:HiddenField ID="HiddenFieldComu" runat="server" />
         </td>
         <td width="80">&nbsp;</td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td class="auto-style2">Departamento:
             <asp:Label ID="LabelDep" runat="server" Font-Bold="True"></asp:Label>
         </td>
         <td class="auto-style2">
             &nbsp;</td>
         <td class="auto-style2">&nbsp;</td>
     </tr>
     <tr>
         <td class="auto-style2">Provincia:
             <asp:Label ID="LabelProv" runat="server" Font-Bold="True"></asp:Label>
         </td>
         <td class="auto-style2">
             </td>
         <td class="auto-style2"></td>
     </tr>
     <tr>
         <td class="auto-style2">
             <table style="width: 100%;">
                 <tr>
                     <td class="auto-style9" width="100"> Parcela N°:
             </td>
                     <td class="auto-style9" width="100"> 
             <div onkeypress="return AceptaNumeroD(event);"><asp:TextBox ID="TextBoxParcela" runat="server" Width="100px"></asp:TextBox></div></td>
                     <td class="auto-style9">&nbsp;</td>                  
                 </tr>                
             </table>            
         </td>
         <td class="auto-style2">
             <div onkeypress="return AceptaNumeroD(event);">Superficie Doc:</div>
             </td>
         <td class="auto-style2">
             <asp:TextBox ID="TextBoxDoc" runat="server"></asp:TextBox>
             </td>
     </tr>
     <tr>
         <td class="auto-style2" colspan="3"><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
             <table style="width:100%;">
                 <tr>
                     <td class="auto-style4" width="100">Coordenada X:</td>
                     <td class="auto-style5">
                         <div onkeypress="return AceptaNumeroD(event);"><asp:TextBox ID="TextBoxX" runat="server"></asp:TextBox></div>
                     </td>
                     <td class="auto-style1"></td>
                 </tr>
                 <tr>
                     <td class="auto-style4">Coordenada Y:</td>
                     <td class="auto-style5">
                        <div onkeypress="return AceptaNumeroD(event);"><asp:TextBox ID="TextBoxY" runat="server"></asp:TextBox></div>
                     </td>
                     <td>&nbsp;</td>
                 </tr>                 
                 <tr>
                     <td class="auto-style4" colspan="3">
                         <asp:Label ID="LabelMen" runat="server" ForeColor="#CC0000"></asp:Label>
                     </td>
                 </tr>                 
                 <tr>
                     <td class="auto-style4" colspan="3">                        
                          <table style="width:45%;">
                             <tr>
                                 <td class="auto-style1" colspan="3">
                                     <asp:Button ID="ButtonQuitar" runat="server" Text="&lt;&lt; Eliminar Coordenadas" OnClick="ButtonQuitar_Click" />
                                     <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar Coordenadas &gt;&gt;" OnClick="ButtonAgregar_Click" />
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style8">PUNTO</td>
                                 <td class="auto-style8">COORDENADA X</td>
                                 <td class="auto-style8">COORDENADA Y</td>
                             </tr>
                             <tr>
                                 <td class="auto-style8">
                                     <asp:ListBox ID="ListBoxNRO" runat="server" Rows="7" Width="120px"></asp:ListBox>
                                 </td>
                                 <td class="auto-style8">
                                     <asp:ListBox ID="ListBoxX" runat="server" Rows="7" Width="120px" Enabled="False"></asp:ListBox>
                                 </td>
                                 <td class="auto-style8">
                                     <asp:ListBox ID="ListBoxY" runat="server" Rows="7" Width="120px" Enabled="False"></asp:ListBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style8">&nbsp;</td>
                                 <td class="auto-style8">&nbsp;</td>
                                 <td class="auto-style8">&nbsp;</td>
                             </tr>
                         </table>
                     </td>
                 </tr>                 
                 <tr>
                     <td class="auto-style4" colspan="3">
                         <asp:Button ID="ButtonReg" runat="server" OnClick="ButtonReg_Click" Text="Registrar Datos" />
                     </td>
                 </tr>
             </table>
                           </ContentTemplate> </asp:UpdatePanel>
         </td>
     </tr>
     <tr>
         <td class="auto-style1" colspan="3">
             &nbsp;</td>
     </tr>
     </table>   
</asp:Content>
