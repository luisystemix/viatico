<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReunion.aspx.cs" Inherits="WebAplication.Administrador.frmReunion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <script type="text/javascript" src="../Scripts/validar.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">
        ACTA DE REUNION</div>
    <table class="TableBorder">
        <tr>
            <td class="auto-style2">Campaña:</td>
            <td width="150">
                <asp:Label ID="LblCamp" runat="server"></asp:Label>
                <asp:Label ID="LblIdCamp" runat="server"></asp:Label>
            </td>
            <td width="40">&nbsp;</td>
            <td>&nbsp;</td>
            <td width="40">Fecha:</td>
            <td width="120">
                <asp:Label ID="LblFecha" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Regional:</td>
            <td>
                <asp:DropDownList ID="DDLRegional" runat="server">
                </asp:DropDownList>
            </td>
            <td>Lugar:</td>
            <td>
                <asp:TextBox ID="TxtLugar" runat="server" onKeyUp="toUpper(this)" Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Tipo de Reunion:</td>
            <td>
                <asp:DropDownList ID="DDLTipoReunion" runat="server">
                    <asp:ListItem Value="REUNION INTERNA DE PLANIFICACION DE LA CAMPAÑA AGRICOLA">RIPCA</asp:ListItem>
                    <asp:ListItem>TAPLOCA</asp:ListItem>
                    <asp:ListItem Value="SOCIALIZACION"></asp:ListItem>
                    <asp:ListItem Value="CIERRE DE CAMPAÑA">CIERRE</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Label ID="LblIdReunion" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div class="SubTitulo2">REGISTRO DE PARTICIPACIÓN</div><table class="TableBorder">
        <tr>
            <td width="30">&nbsp;</td>
            <td width="160">Organización y/o Empresa:</td>
            <td width="250">
                <asp:TextBox ID="TxtOrgEmp" runat="server" onKeyUp="toUpper(this)" Width="250px"></asp:TextBox>
            </td>
            <td width="65">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2">Comunidad:</td>
            <td class="auto-style2">
                <asp:TextBox ID="TxtComunidad" runat="server" onKeyUp="toUpper(this)" Width="200px"></asp:TextBox>
            </td>
            <td class="auto-style2">Municipio:</td>
            <td class="auto-style2">
                <asp:TextBox ID="TxtMunicipio" runat="server" onKeyUp="toUpper(this)" Width="200px"></asp:TextBox>
            </td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Nombres:</td>
            <td>
                <asp:TextBox ID="TxtNombre" runat="server" onKeyUp="toUpper(this)" Width="250px"></asp:TextBox>
            </td>
            <td>Cargo:</td>
            <td>
                <asp:TextBox ID="TxtCargo" runat="server" onKeyUp="toUpper(this)" Width="250px"></asp:TextBox>
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Cedula:</td>
            <td>
                <asp:TextBox ID="TxtCi" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:Button ID="BtnParticipante" runat="server" Text="Registrar Participante" OnClick="BtnParticipante_Click" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        </table>
    <asp:GridView ID="GVParticipantes" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="N" HeaderText="N°" >
            <ItemStyle Width="30px" />
            </asp:BoundField>
            <asp:BoundField DataField="Nombreparticipante" HeaderText="Nombre Participante" />
            <asp:BoundField DataField="ci" HeaderText="Cedula" />
            <asp:BoundField DataField="Comunidad" HeaderText="Comunidad" />
            <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
            <asp:BoundField DataField="OrganizacionEmpresa" HeaderText="Organización y/o Empresa" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:CommandField ShowDeleteButton="True" Visible="False" />
        </Columns>
    </asp:GridView>
    <br>
    <div class="SubTitulo2">
    TEMAS QUE SE TRTARON EN LA REUNION</div>
    <table class="TableBorder">
        <tr>
            <td width="30" class="auto-style1"></td>
            <td width="120" class="auto-style1">Tema Tratado:</td>
            <td class="auto-style1">
                <asp:TextBox ID="TxtTarea" runat="server" onKeyUp="toUpper(this)" Width="400px"></asp:TextBox>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnTema" runat="server" Text="Registrar Tema" OnClick="BtnTema_Click" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GVTareas" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="N" HeaderText="N°" >
            <ItemStyle Width="30px" />
            </asp:BoundField>
            <asp:BoundField DataField="TemasAbordados" HeaderText="Temas Abordados" />
            <asp:CommandField ShowDeleteButton="True" Visible="False" />
        </Columns>
    </asp:GridView>
    <table class="TableBorder">
        <tr>
            <td width="80">Conclusión:</td>
            <td rowspan="2">
                <asp:TextBox ID="TxtConclucion" runat="server" Height="50px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
    </table>
    <asp:Button ID="BtnRegistrar" runat="server" OnClick="BtnRegistrar_Click" Text="Registrar Acta" />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" />
</asp:Content>
