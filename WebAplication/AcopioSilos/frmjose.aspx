<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmjose.aspx.cs" Inherits="WebAplication.AcopioSilos.frmjose" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <link href="jquery.cleditor.css" rel="stylesheet" />
    <script src="jquery.cleditor.js" type="text/javascript"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#MainContent_TextBox1").cleditor();
            });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="TableBorder"></asp:TextBox>
</asp:Content>
