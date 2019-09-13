<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRevisarDatos.aspx.cs" Inherits="WebAplication.Responsable.frmRevisarDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        DATOS DEL CONTRATO</div>
    <table class="TableBorder">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblIdInsOrg" runat="server"></asp:Label>
            </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table><div>
        <asp:GridView ID="GVContrato" runat="server" CssClass="TableBorder" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Num_Contrato" HeaderText="Contrato" />
                <asp:BoundField DataField="Nombre" HeaderText="Campaña" />
                <asp:BoundField DataField="Programa" HeaderText="Programa" />
                <asp:BoundField DataField="Personeria_Juridica" HeaderText="Organización" />
                <asp:BoundField DataField="Resolucion_Prefect" HeaderText="Resolucion N°" />
                <asp:BoundField DataField="Fecha_Creacion" HeaderText="Fecha Resolución" />
                <asp:BoundField DataField="DomicilioOrg" HeaderText="Domicilio Localidad/Comunidad" />
                <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
                <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                <asp:BoundField DataField="Rep_Legal" HeaderText="Rep. Legal" />
                <asp:BoundField DataField="Cedula" HeaderText="Ci Rep. Leg." />
                <asp:BoundField DataField="Nun_Testimonio" HeaderText="N° Testimonio" />
                <asp:BoundField DataField="Num_Notaria" HeaderText="N° Notaria" />
                <asp:BoundField DataField="Abg_A_Cargo" HeaderText="Abg. A Cargo" />
                <asp:BoundField DataField="Distrito_Judicial" HeaderText="Distrito Judicial" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha Testimonio" />
            </Columns>
        </asp:GridView>
        </div>
        </asp:Content>
