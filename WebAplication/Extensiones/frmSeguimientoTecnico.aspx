<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSeguimientoTecnico.aspx.cs" Inherits="WebAplication.Extensiones.frmSeguimientoTecnico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--GRIDVIEW MAKEOVER--%>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        td
        {
            cursor: pointer;
        }
        .hover_row
        {
            background-color: #c5bfb7/*#A1DCF2*/;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=GVDesignado] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
        $(function () {
            $("[id*=GVNoDesignado] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>
    <%--GRIDVIEW MAKEOVER--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">REGISTRO DE DATOS DEL SEGUIMIENTO TÉCNICO </div>
    <table class="TableBorder">
        <tr>
            <td width="75">Regional:</td>
            <td>
                <asp:Label ID="LblReg" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server" Visible="False"></asp:Label> 
            </td>
            <td></td>
            <td width="60">Campaña:</td>
            <td width="140">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Programa:</td>
            <td>
                <asp:Label ID="LblPrograma" runat="server"></asp:Label>
            </td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Organización:</td>
            <td>
                <asp:Label ID="LblOrg" runat="server"></asp:Label>
                <asp:Label ID="LblIdInsOrg" runat="server" Visible="False"></asp:Label>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                </td>
        </tr>
    </table>
    <div style="text-align: center"><asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label></div>
    <div class="SubTitulo2">PRODUCTORES SELECCIONADOS PARA SU SEGUIMIENTO</div><asp:GridView ID="GVDesignado" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVDesignado_RowCommand" OnRowDataBound="GVDesignado_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Productor" HeaderText="Productor" />
            <asp:BoundField DataField="ci" HeaderText="Cedula" >
            <ItemStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="Has_Inscrito" HeaderText="Sup." >
            <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="Etapa" HeaderText="Etapa" >
            <ItemStyle Width="140px" />
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" />
            <asp:BoundField DataField="Id_Productor" HeaderText="Id_Productor" Visible="False" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="ImgEstado" runat="server" Height="15px" Width="15px" />
                </ItemTemplate>
                <ItemStyle Width="15px" />
            </asp:TemplateField>
            <asp:ButtonField CommandName="Parcela" Text="Seguimiento">
            <ItemStyle Width="40px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Semilla" Text="Distribución Semilla">
            <ItemStyle Width="105px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Agroquimico" Text="Distribución Insumo">
            <ItemStyle Width="110px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Rendimiento" Text="Rendimiento">
            <ItemStyle Width="70px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Costos" Text="Costos">
            <ItemStyle Width="40px" />
            </asp:ButtonField>  
             <asp:BoundField DataField="Id_Etapa" HeaderText="">
            <ItemStyle Width="20px" />
            </asp:BoundField>          
        </Columns>
    </asp:GridView>
    <table class="TableBorder2">
        <tr>
            <td>
                <div style="text-align: center; color: #FF0000; font-weight: 700; font-size: small;"><asp:Label ID="LblMsj1" runat="server"></asp:Label></div>
            </td>
        </tr>
    </table>
    <div class="SubTitulo2">PRODUCTORES NO SELECCIONADOS COMO PARTE DE LA MUESTRA</div><asp:GridView ID="GVNoDesignado" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowCommand="GVNoDesignado_RowCommand" OnRowDataBound="GVNoDesignado_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Productor" HeaderText="Productor" />
            <asp:BoundField DataField="ci" HeaderText="Cedula" >
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Has_Inscrito" HeaderText="Sup." >
            <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="Etapa" HeaderText="Etapa" Visible="False" >
            <ItemStyle Width="140px" />
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" />
            <asp:BoundField DataField="Id_Productor" HeaderText="Id_Productor" Visible="False" />
            <asp:TemplateField Visible="False">
                <ItemTemplate>
                    <asp:Image ID="ImgEstado0" runat="server" Height="15px" Width="15px" />
                </ItemTemplate>
                <ItemStyle Width="15px" />
            </asp:TemplateField>
            <asp:ButtonField CommandName="Habilitar" Text="Habilitar seguimiento">
            <ItemStyle Width="115px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    </asp:Content>
