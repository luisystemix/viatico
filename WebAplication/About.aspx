<%@ Page Title="Acerca de SPIA - A" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebAplication.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">   
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        SPIA-EMAPA</h2>
    <h3>
        SISTEMA DE PROCESAMIENTO DE INFORMACION ALIMENTARIA</h3>

        <table cellspacing="1" class="TableBorder">
            <tr style="background: #F7F7F7; ">
                <td class="espacio">
                    &nbsp;</td>
                <td>
                    <h2>NOTA: 1</h2></td>
                <td class="espacio">
                    &nbsp;</td>
            </tr>
            <tr style="background: #F7F7F7; ">
                <td class="espacio">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="LblNota" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="LblNota1" runat="server"></asp:Label>
                </td>
                <td class="espacio">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    Saludos compañeros.<br />
                    <br />
                    José Luis Aruquipa Hilari<br />
                    SISTEMAS - CENTRAL LA PAZ<br />
                    Teléfono Cel: 
                    67001998<br />
                    <br />
&nbsp;Rubén Daniel Conde Aguilar<br />
                    SISTEMAS - CENTRAL LA PAZ<br />
                    Teléfono Cel: 71523611<br />
&nbsp;<br />
                    Teléfono Fijo: 2115500 Int 202 - 2112728 Int 202</td>
                <td>
                    &nbsp;</td>
            </tr>
    </table>
</asp:Content>
