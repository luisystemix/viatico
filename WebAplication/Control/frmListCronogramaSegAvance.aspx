<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListCronogramaSegAvance.aspx.cs" Inherits="WebAplication.Control.frmListCronogramaSegAvance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script src="../js/validar.js" type="text/ecmascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
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
    function esInteger(e) {
        var charCode                
            if (navigator.appName == "Netscape") {
                charCode = e.which
            }
            else {
                charCode = e.keyCode
            }
            if (charCode < 48 || charCode > 57) {
                alert("Por favor teclee solo números en este campo!");
                return false
            }
            else {
                
                return true
            }

    }
    function check_cantidad(element) {
        var cant = element.value;
        //alert(cant);
        if (cant > 100) {
            alert('Valor introducido es mayor a 100%');
            document.getElementById(element.id).value = "0";            
        }
        
    }
    function isFloat(myNum) {
        // es true si es 1, osea si es flotante
        var myMod = myNum % 1;

        if (myMod == 0)
        { return false; }
        else { return true; }
    }
    function Confirmacion() {
        var seleccion = confirm("Está seguro de enviar la información registrada…?");
        return seleccion;
    }
    $(function () {
        $("[id*=GVCronogramas] td").hover(function () {
            $("td", $(this).closest("tr")).addClass("hover_row");
        }, function () {
            $("td", $(this).closest("tr")).removeClass("hover_row");
        });
    });
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="SubTitulo">LISTA REGISTRO DE AVANCE ACTIVIDADES</div>&nbsp;<table class="TableBorder">
        <tr>
            <td width="70">
                <asp:Label ID="LblIdUser" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="50">Regional:</td>
            <td width="130">
                <asp:Label ID="LblRegional" runat="server"></asp:Label>
                <asp:Label ID="LblIdReg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LblIdCrono" runat="server"></asp:Label></td>
            <td>
                &nbsp;</td>
            <td></td>
            <td></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3"></td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <div style="text-align: right">
                     <asp:ImageButton ID="ImgPrint" runat="server" Height="30px" ImageUrl="~/images/printmgr.png" Width="30px" OnClick="ImgPrint_Click" />

                </div>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GVCronogramas" runat="server" CssClass="TableBorder" AutoGenerateColumns="False" OnRowCommand="GVCronogramas_RowCommand" OnRowDataBound="GVCronogramas_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Id_CronogramaAvance" HeaderText="Id_Avance" >
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Id_Cronograma" HeaderText="Id_Cronograma"  Visible="false">
            <ItemStyle Width="90px" />
            </asp:BoundField>
            <asp:BoundField DataField="Dia" HeaderText="Día" >
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="FechaDia" HeaderText="Fecha" >
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="TareaDia" HeaderText="Tema" >
            <ItemStyle Width="500px" />
            </asp:BoundField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblAvance" runat="server" Text="Avance %"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtAvance" runat="server" onKeyPress="return esInteger(event)" onchange="check_cantidad(this);" Width="40px"></asp:TextBox>
                    <%--<asp:RangeValidator id="rango1" runat="server"
                      ControlToValidate="txtAvance"
                      MinimumValue="0"
                      MaximumValue="100"
                      Type="Integer"
                      Text="Avance mayor a 100 %" ForeColor="Red" />--%>                    
                </ItemTemplate>
                <ControlStyle Width="50px" />
                <ItemStyle Width="20px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblObsAvance" runat="server" Text="Observación Avance"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtObsAvance" runat="server" Width="80px"></asp:TextBox>
                </ItemTemplate>
                <ControlStyle Width="150px" />
                <ItemStyle Width="40px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblFuenteVerificacion" runat="server" Text="Fuente de Verificación"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtFuenteVerificacion" runat="server"></asp:TextBox>
                </ItemTemplate>
                <ControlStyle Width="150px" />
                <ItemStyle Width="40px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtObservaciones" runat="server"></asp:TextBox>
                </ItemTemplate>
                <ControlStyle Width="150px" />
                <ItemStyle Width="40px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <%--<asp:ButtonField ButtonType="Image" CommandName="imprimir" ImageUrl="~/images/printmgr.png" Text="Button">
            <ControlStyle Height="20px" Width="20px" />
            <ItemStyle Height="25px" Width="25px" />
            </asp:ButtonField>--%>            
        </Columns>
    </asp:GridView>
    <div style="text-align: center">
                <asp:Button ID="btnGuardar" runat="server" OnClientClick ="return Confirmacion()" Text="Registrar" OnClick="btnGuardar_Click" />
    </div>
    
</asp:Content>

