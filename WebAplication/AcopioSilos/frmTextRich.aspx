<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmTextRich.aspx.cs" Inherits="WebAplication.AcopioSilos.frmTextRich"  ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <link href="../css/custom-theme/jquery-ui-1.8.24.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.validate.min.js" type="text/javascript"></script>  
    
    <link href="jquery.cleditor.css" rel="stylesheet" />
    <script src="jquery.cleditor.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtPrueba").cleditor();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
     <asp:TextBox ID="txtPrueba" runat="server" TextMode="MultiLine"></asp:TextBox>
     <asp:Button ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="Enviar" />
     <asp:Label ID="lblResultado" runat="server"></asp:Label>
</asp:Content>
