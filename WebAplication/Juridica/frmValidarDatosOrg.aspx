<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmValidarDatosOrg.aspx.cs" Inherits="WebAplication.Juridica.frmValidarDatosOrg" %>
<%@ Register src="../Registro/contEncabezado1.ascx" tagname="contEncabezado1" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        FORMULARIO DE VALIDACIÓN DE LOS DATOS DE LAS ORGANIZACIONES</div>
    <uc1:contEncabezado1 ID="contEncabezado11" runat="server" />
    
    <div class="SubTitulo2">DATOS DE LA ORGANIZACIÓN</div>
    
    <table class="TableBorder">
        <tr>
            <td class="auto-style1" width="30"></td>
            <td width="160" class="auto-style1">Departamento:</td>
            <td width="300" class="auto-style1">
                <asp:DropDownList ID="DDLDepartamento" runat="server" AutoPostBack="True" Enabled="False">
                    <asp:ListItem Value="0">BUSCAR --?--</asp:ListItem>
                    <asp:ListItem Value="OCCIDENTE">LA PAZ</asp:ListItem>
                    <asp:ListItem Value="ORIENTE">SANTA CRUZ</asp:ListItem>
                    <asp:ListItem Value="ORIENTE">BENI</asp:ListItem>
                    <asp:ListItem Value="OCCIDENTE">COCHABAMBA</asp:ListItem>
                    <asp:ListItem Value="OCCIDENTE">TARIJA</asp:ListItem>
                    <asp:ListItem Value="OCCIDENTE">SUCRE</asp:ListItem>
                    <asp:ListItem Value="OCCIDENTE">POTOSI</asp:ListItem>
                    <asp:ListItem Value="OCCIDENTE">ORURO</asp:ListItem>
                    <asp:ListItem Value="ORIENTE">PANDO</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="LblTipoProd" runat="server"></asp:Label>
                <asp:Label ID="LblIdOrg" runat="server"></asp:Label>
                </td>
            <td class="auto-style1" width="10"></td>
            <td width="40" class="auto-style1"></td>
            <td width="170" class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td width="60" class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Personalidad Juridica:</td>
            <td>
                <asp:TextBox ID="TxtPersonJuridi" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Sigla:</td>
            <td>
                <asp:TextBox ID="TxtSigla" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td></td>
            <td>Tipo:</td>
            <td>
                <asp:DropDownList ID="DDLTipoOrg" runat="server">
                    <asp:ListItem>OTB</asp:ListItem>
                    <asp:ListItem>ASOCIACION</asp:ListItem>
                    <asp:ListItem>COOPERATIVA</asp:ListItem>
                    <asp:ListItem>CENTRAL CAMPESINA</asp:ListItem>
                    <asp:ListItem>SINDICATO AGRARIO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Resolucion Prefectural N°:</td>
            <td>
                <asp:TextBox ID="TxtNumResolucion" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="auto-style2">&nbsp;</td>
            <td>Fecha:</td>
            <td>
                <asp:TextBox ID="TxtFechCreacion" runat="server" Width="70px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Domicilio:</td>
            <td>
                <asp:TextBox ID="TxtDomicilio" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="9">
                <div style="text-align: center"><asp:Label ID="LblMsj1" runat="server"></asp:Label></div>
            </td>
        </tr>
    </table>    
    <div class="SubTitulo2">DATOS REPRESENTANTE LEGAL</div>
    
    <table class="TableBorder">
        <tr>
            <td width="30">&nbsp;</td>
            <td width="100">Cedula:</td>
            <td class="auto-style4" width="250">
                <asp:TextBox ID="TxtCedula" runat="server" Width="80px" OnTextChanged="TxtCedula_TextChanged" AutoPostBack="True"></asp:TextBox>
&nbsp;Ext:
                <asp:DropDownList ID="DDLExt" runat="server">
                    <asp:ListItem>LP</asp:ListItem>
                    <asp:ListItem>SC</asp:ListItem>
                    <asp:ListItem>CB</asp:ListItem>
                    <asp:ListItem>PT</asp:ListItem>
                    <asp:ListItem>BN</asp:ListItem>
                    <asp:ListItem>OR</asp:ListItem>
                    <asp:ListItem>CH</asp:ListItem>
                    <asp:ListItem>TJ</asp:ListItem>
                    <asp:ListItem>PN</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="10">&nbsp;</td>
            <td width="60">&nbsp;</td>
            <td width="220">
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">Nombre:</td>
            <td class="auto-style7">
                <asp:TextBox ID="TxtNombre" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">Paterno:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtPaterno" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1">Materno:</td>
            <td class="auto-style1">
                <asp:TextBox ID="TxtMaterno" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="SubTitulo2">&nbsp;</td>
            <td class="SubTitulo2">REFERENCIA:</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Telefono Fijo:</td>
            <td class="auto-style4">
                <asp:TextBox ID="TxtFijo" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>Movil:</td>
            <td>
                <asp:TextBox ID="TxtMovil" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="9">
                <div style="text-align: center"><asp:Label ID="LblMsj2" runat="server"></asp:Label></div>
            </td>
        </tr>
        </table>
    <div class="SubTitulo2">DATOS TESTIMONIO DE PODER</div>
    
    <table class="TableBorder">
        <tr>
            <td width="30">&nbsp;</td>
            <td width="100">Testimonio N°:</td>
            <td width="180">
                <asp:TextBox ID="TxtNumTesti" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td width="90">Fecha:</td>
            <td>
                <asp:TextBox ID="TxtFechaTetim" runat="server" Width="70px"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td width="30">&nbsp;</td>
            <td width="100">Notaría N°:</td>
            <td width="200">
                <asp:TextBox ID="TxtNumNotario" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td>Distrito judicial:</td>
            <td>
                <asp:TextBox ID="TxtDistritoJudi" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="30">&nbsp;</td>
            <td width="100">Abg. A Cargo:</td>
            <td width="200" colspan="3">
                <asp:TextBox ID="TxtAbogado" runat="server" Width="280px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="7">
                <div style="text-align: center"><asp:Label ID="LblMsj3" runat="server"></asp:Label></div>
            </td>
        </tr>
    </table>
    
    <asp:Button ID="BtnRegistrar" runat="server" Text="Aprobar  para contrato" OnClick="BtnRegistrar_Click" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" />
    
</asp:Content>
