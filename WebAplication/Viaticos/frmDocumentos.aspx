<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDocumentos.aspx.cs" Inherits="WebAplication.Viaticos.frmDocumentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        DOCUMENTOS DEL PROCESO DE VIÁTICOS</div>
    <table class="TableBorder">
        <tr>
            <td width="60">Nombre:</td>
            <td>
                <asp:Label ID="LblNombre" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="120">Lugar de Funciones:</td>
            <td>
                <asp:Label ID="LbLugarFun" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Cargo:</td>
            <td>
                <asp:Label ID="LblCargo" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>Codigo Solicitud:</td>
            <td>
                <asp:Label ID="LblIdSolicitud" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td></td>
            <td><div class="SubTitulo2" style="text-align: center">Solicitud</div></td>
            <td><div class="SubTitulo2" style="text-align: center">Memorandum</div></td>
            <td><div class="SubTitulo2" style="text-align: center">Planilla de pago</div></td>
            <td><div class="SubTitulo2" style="text-align: center">Informre</div></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
               <div style="text-align: center"><asp:ImageButton ID="ImgBtnSolicitud" runat="server" ImageUrl="~/images/news.png" OnClick="ImgBtnSolicitud_Click" /></div> 
            </td>
            <td>
                <div style="text-align: center"><asp:ImageButton ID="ImgBtnMemo" runat="server" ImageUrl="~/images/news_alt2.png" OnClick="ImgBtnMemo_Click" /></div>
            </td>
            <td>
                <div style="text-align: center"><asp:ImageButton ID="ImgBtnPlanilla" runat="server" ImageUrl="~/images/excel7.png" OnClick="ImgBtnPlanilla_Click" /></div>
            </td>
            <td>
                <div style="text-align: center"><asp:ImageButton ID="ImgBtnInforme" runat="server" ImageUrl="~/images/Shopping_list.png" OnClick="ImgBtnInforme_Click" /></div>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="LblEstado" runat="server"></asp:Label>
            </td>
            <td colspan="2">
                <asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
            </td>
            <td></td>
            <td></td>
        </tr>
    </table>
</asp:Content>
