<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSeleccionarProd.aspx.cs" Inherits="WebAplication.Extensiones.frmSeleccionarProd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js/jquery.quicksearch.js"></script>
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
    <script type="text/javascript">
        $(function () {            
            $('input#MainContent_txtBuscar').quicksearch('table#MainContent_GVDesignadoProd tbody tr');
        });
        function selectAll(checked) {
            var isChecked = $(checked).attr('checked') ? true : false;
            if (isChecked) {
                $('input:checkbox[name$=CBXEstado]').each(
                        function () {
                            $(this).attr('checked', 'checked');
                        });
            }
            else {
                $('input:checkbox[name$=CBXEstado]').each(
                        function () {
                            $(this).removeAttr('checked');
                        });
            }
        }
        $(function () {
            $("[id*=GVDesignadoProd] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        SELECCIONAR PRODUCTORES PARA SU SEGUIMIENTO</div>
    <table class="TableBorder">
        <tr>
            <td width="80">Regional:</td>
            <td>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="150">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="80">Programa:</td>
            <td>
                <asp:DropDownList ID="DDLPrograma" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrograma_SelectedIndexChanged">
                    <asp:ListItem>ARROZ</asp:ListItem>
                    <asp:ListItem>MAIZ</asp:ListItem>
                    <asp:ListItem>SOJA</asp:ListItem>
                    <asp:ListItem>TRIGO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td width="60">&nbsp;</td>
            <td width="150">
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Organización:</td>
            <td>
                <asp:DropDownList ID="DDLOrgAsig" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLOrgAsig_SelectedIndexChanged" OnPreRender="DDLOrgAsig_PreRender">
                </asp:DropDownList>
                <asp:Label ID="lblMesajeOrganizacion" runat="server" Text="" style="font-weight: 700; color: #CC0000"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td rowspan="3">
               <div style="text-align: right"> <asp:ImageButton ID="ImgBtnPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" OnClick="ImgBtnPrint_Click" /></div>

            </td>
        </tr>
        <tr>
            <td>Productor:</td>
            <td>
                <asp:TextBox ID="txtBuscar" runat="server" Width="227px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="3">
                <div style="text-align: center">
                <asp:Label ID="LblMsj" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label><br/>                 
                <asp:Label ID="LblContador" runat="server"></asp:Label>  /
                <asp:Label ID="LblMaximo" runat="server" style="font-weight: 700"></asp:Label>                
                    </div>
            </td>
        </tr>
        </table>
    <asp:GridView ID="GVDesignadoProd" runat="server" AutoGenerateColumns="False" CssClass="TableBorder" OnRowDataBound="GVDesignadoProd_RowDataBound" OnPreRender="GVDesignadoProd_PreRender">
        <Columns>
            <asp:BoundField DataField="Personeria_Juridica" HeaderText="Personalidad Jurídica" />
            <asp:BoundField DataField="Productor" HeaderText="Productor" />
            <asp:BoundField DataField="ci" HeaderText="ci" />
            <asp:BoundField DataField="Comunidad" HeaderText="Comunidad" />
            <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
            <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
            <asp:BoundField DataField="Tipo_Produccion" HeaderText="Tipo_Produccion" />
            <asp:BoundField DataField="Has_Inscrito" HeaderText="Has_Inscrito" />
            <asp:BoundField DataField="Id_Productor" HeaderText="Id_Productor" />
            <asp:BoundField DataField="Id_Usuario" HeaderText="Id_Usuario" />            
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox runat="server" ID="chkEnabled" AutoPostBack="True" ToolTip="Habilitar/Deshabilitar - VERIFICACION_PARCELA (1)" OnCheckedChanged="chkEnabled_CheckedChanged" Font-Bold="True" Text="Habilitar" TextAlign="Left" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CBXEstado" runat="server" AutoPostBack="True" OnCheckedChanged="CBXEstado_CheckedChanged" />
                </ItemTemplate>
                <ItemStyle Width="20px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="Etapa" HeaderText="Etapa" />   
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnAceptar" runat="server" OnClick="BtnAceptar_Click" Text="Registrar Selección" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
</asp:Content>
