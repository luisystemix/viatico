<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repFechasIniFinSiembra.aspx.cs" Inherits="WebAplication.Reportes.repFechasIniFinSiembra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/EmapaStyele.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="TableBorder">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
        </table>
    
        <asp:GridView ID="GridView1" runat="server" CssClass="TableBorder">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
