<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDesignarOrgTPE.aspx.cs" Inherits="WebAplication.Extensiones.frmDesignarOrgTPE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript">

        function Confirmacion()
        {
            var seleccion = confirm("acepta el mensaje ?");
            //if (seleccion)
                //alert("se acepto el mensaje");
            //else
                //alert("NO se acepto el mensaje");
            //usado para que no haga postback el boton de asp.net cuando
            //no se acepte el confirm
            return seleccion;
        }

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        DESIGNACIÓN DE ORGANIZACIONES A LOS TÉCNICOS DE EXTENSIONES</div>
    <table class="TableBorder">
        <tr>
            <td width="50">Regional:</td>
            <td>
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="60">Campaña:</td>
            <td width="150">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LblIdUser" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
     <div class="SubTitulo2">SELECCIONAR PERSONAL TÉCNICO:</div>
    <table class="TableBorder">
        <tr>
            <td width="160">Seleccionar Programa:</td>
            <td>
                <asp:Label ID="LblProg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td width="90">N° Productores:</td>
            <td width="90">
                <asp:Label ID="LblNumProd" runat="server" style="font-size: medium; font-weight: 700"></asp:Label>
            </td>
            <td rowspan="2" width="20">&nbsp;</td>
        </tr>
        <tr>
            <td>Seleccionar Personal Técnico:</td>
            <td>
                <asp:DropDownList ID="DDLTecnicos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTecnicos_SelectedIndexChanged">
                </asp:DropDownList>
                
                <asp:LinkButton ID="LnkBtnSeleccionar" runat="server" OnClick="LnkBtnSeleccionar_Click">Aceptar</asp:LinkButton>
                
                <asp:Label ID="LblIdUsuario" runat="server"></asp:Label>
                
            </td>
            <td>&nbsp;</td>
            <td>N° Muestra</td>
            <td>
                <asp:Label ID="LblMuestra" runat="server" style="font-size: medium; font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblTecnico" runat="server" style="font-weight: 700"></asp:Label>
                </td>
            <td>
                <asp:Label ID="LblCargo" runat="server" style="font-weight: 700"></asp:Label>
            
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div class="SubTitulo2">DESIGNAR DE LA LISTA LAS ORGANIZACIONES CON LAS QUE TRABAJARA:</div>
                &nbsp;<asp:GridView ID="GVOrg" runat="server" CssClass="TableBorder" OnRowDataBound="GVOrg_RowDataBound" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" />
            <asp:BoundField DataField="Personeria_Juridica" HeaderText="Personalidad Juridica" />
            <asp:BoundField DataField="Sigla" HeaderText="Sigla" />
            <asp:BoundField DataField="Departamento" HeaderText="Departamento" Visible="False" />
            <asp:BoundField DataField="Nombre" HeaderText="Regional" />
            <asp:BoundField DataField="Tipo_Produccion" HeaderText="Tipo_Produccion" />
            <asp:BoundField HeaderText="N° Productores" />
            <asp:BoundField HeaderText="Superficie" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="ChBoxEstado" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td width="110">
    <asp:Button ID="BtnDesignar" runat="server" Text="Asignar Organización &gt;&gt;" OnClick="BtnDesignar_Click" style="height: 26px" />
            </td>
            <td>
                <asp:Label ID="LblMsj" runat="server" style="color: #CC0000; font-weight: 700"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table class="TableBorder">
        <tr>
            <td width="250">&nbsp;</td>
            <td>&nbsp;</td>
            <td width="200">&nbsp;</td>
            <td width="30" rowspan="2">
                <asp:ImageButton ID="ImgPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" OnClick="ImgPrint_Click" />
            </td>
        </tr>
        <tr>
            <td><div class="SubTitulo2">LISTA DE DESIGNACIONES</div></td>
            <td>
                &nbsp;<asp:Label ID="LblMsj1" runat="server" style="font-weight: 700; color: #CC0000"></asp:Label>
            </td>
            <td>Productores seleccionados:
                <asp:Label ID="LblTotal" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVDesignado" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVDesignado_RowCommand">
        <Columns>
            <asp:BoundField DataField="Nombres" HeaderText="Tecnico designado" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Personeria_Juridica" HeaderText="Organización" />
            <asp:BoundField DataField="Sigla" HeaderText="Sigla" Visible="False" />
            <asp:BoundField DataField="Programa" HeaderText="Programa" />
            <asp:BoundField DataField="Nombre" HeaderText="Campaña" />
            <asp:BoundField DataField="Superficie" HeaderText="Sup. (ha)" />
            <asp:BoundField DataField="Num_Productores" HeaderText="N° Prod." Visible="False" />
            <asp:BoundField DataField="Id_Usuario" HeaderText="Id_Usuario" Visible="False" >
            <ItemStyle Width="10px" />
            </asp:BoundField>
            <asp:BoundField DataField="Id_InscripcionOrg" HeaderText="Id_InscripcionOrg" Visible="False" >
            <ItemStyle Width="10px" />
            </asp:BoundField>
            <asp:ButtonField ButtonType="Image" CommandName="Eliminar" ImageUrl="~/images/img-0.png" Text="Button">
            <ItemStyle Width="20px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnEnviarDesignacion" runat="server" OnClick="BtnEnviarDesignacion_Click" Text="Enviar designación &gt;&gt;" />
    <asp:Button ID="Button2" runat="server" OnClientClick ="return Confirmacion()" Text="Cancelar" OnClick="Button2_Click" />
</asp:Content>
