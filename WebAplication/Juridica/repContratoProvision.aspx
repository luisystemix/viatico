<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repContratoProvision.aspx.cs" Inherits="WebAplication.Juridica.repContratoProvision" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

 p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:11.0pt;
	font-family:"Arial","sans-serif";
	        margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
p.MsoHeading8
	{margin-top:12.0pt;
	margin-right:0cm;
	margin-bottom:3.0pt;
	margin-left:0cm;
	font-size:12.0pt;
	font-family:"Times New Roman","serif";
	font-style:italic;
        }
p.MsoBodyText
	{margin: 12.0pt 0cm;
            text-align:justify;
	        font-size:12.0pt;
	        font-family:"Arial","sans-serif";
	}
 table.MsoNormalTable
	{font-size:10.0pt;
	font-family:"Calibri","sans-serif";
	}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div style="page: WordSection1;">
            <p align="center" class="MsoNormal" style="text-align:center">
                <b style="mso-bidi-font-weight:normal"><span lang="ES" style="font-size:12.0pt;
mso-bidi-font-size:10.0pt;color:#404040">CONTRATO DE PROVISIÓN<br />
                DE MATERIA PRIMA Nº <asp:Label ID="LblCodContrato" runat="server"></asp:Label>
                </span>
                <asp:Label ID="LblIdInsOrg" runat="server" Visible="False"></asp:Label>
                </b></p>
            <p class="MsoNormal">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="color:#404040">Conste por el presente Contrato de Provisión de MATERIA PRIMA – Programa </span></i>
                <asp:Label ID="LblPrograma" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="color:#404040">, que se</span></i><i><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"> suscribe al tenor y contenido de las siguientes</span></i><b style="mso-bidi-font-weight:
normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040"> </span></i></b><i><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040">cláusulas:<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">PRIMERA.- (PARTES INTERVINIENTES).</span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040"> Intervienen en el presente contrato:<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="margin-top:6.0pt;margin-right:0cm;margin-bottom:12.0pt;
margin-left:36.0pt;text-align:justify;text-indent:-36.0pt;mso-list:l5 level2 lfo8">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">1.1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></i></b><![endif]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">EMPRESA DE APOYO LA PRODUCCIÓN DE ALIMENTOS – EMAPA</span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040">, representada<span style="mso-spacerun:yes">&nbsp; </span>legalmente por su <b style="mso-bidi-font-weight:normal">Gerente de Producción Ing. Juan Condori Canaviri</b>, con Cédula de Identidad Nº 4241897 LP, facultado mediante Resolución Administrativa Nº 01-016/2010 de 01 de abril de 2013, con domicilio en la calle 9, Nº 7835, de la Zona de Calacoto, en la ciudad de La Paz, que en adelante se denominará <b style="mso-bidi-font-weight:normal">EMAPA</b>.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="margin-top:6.0pt;margin-right:0cm;margin-bottom:12.0pt;
margin-left:36.0pt;text-align:justify;text-indent:-36.0pt;mso-list:l5 level2 lfo8">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">1.2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp; </span></span></span></i></b>
                <asp:Label ID="LblOrganizacion" runat="server" style="font-weight: 700"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">, con Personalidad Jurídica otorgada mediante Resolución Nº </span></i>
                <asp:Label ID="LblNumResol" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">&nbsp;de </span></i>
                <asp:Label ID="LblFechaResol" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">, representada legalmente por: </span></i><!--[if supportFields]><![endif]-->
                <asp:Label ID="LblRespJuridi" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">, con Cédula de Identidad Nº </span></i>
                <asp:Label ID="LblciRespJuridi" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">,, facultad otorgada mediante Testimonio de Poder Nº</span></i><!--[if supportFields]><![endif]--><asp:Label ID="LblNumTestim" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">, otorgado ante la Notaría de Fe Pública Nº </span></i><!--[if supportFields]><![endif]-->
                <asp:Label ID="LblNumNotario" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">,a cargo de Abog. </span></i>
                <asp:Label ID="LblAbogadoACarg" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:white">_/spa</i><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">del Distrito Judicial de </span></i>
                <asp:Label ID="LblDistritJudi" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">, mayor de edad y hábil por ley; con domicilio en la comunidad </span></i>
                <asp:Label ID="LblComunidad" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">, del municipio </span></i>
                <asp:Label ID="LblNumicipio" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">, de la provincia </span></i>
                <asp:Label ID="LblProvincia" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">, departamento de </span></i><!--[if supportFields]><![endif]-->
                <asp:Label ID="LblDepartamento" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">, que en adelante se denominará la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN</b>.<o:p> </o:p></span></i>
            </p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">SEGUNDA.- (ANTECEDENTES).</span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040"> </span><span lang="ES-TRAD" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES-TRAD">El Decreto Supremo No 29230 de 15 de agosto de 2007, crea como Empresa Pública Nacional Estratégica a la Empresa de Apoyo a la Producción de Alimentos (EMAPA), cuyo objeto está descrito en el Artículo 2º de la citada norma, mismo que fue modificado por el Decreto Supremo Nº 29710 de fecha 17 de Septiembre de 2008, <span style="mso-spacerun:yes">&nbsp;&nbsp;</span>cuya organización y funcionamiento está sujeto al marco establecido por Ley Nº 1178 de 20 de julio de 1990, Ley 3351 de 21 de febrero de 2006 y sus disposiciones reglamentarias.<o:p></o:p></span></i></p>
            <p class="MsoHeading8" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <span lang="X-NONE" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
color:#404040;mso-bidi-font-style:normal">El Decreto Supremo Nº 0181 de 28 de Junio de 2009 en su Artículo 83º, faculta a las Empresas Públicas Nacionales Estratégicas, realizar todos sus procesos de contratación de bienes y servicios de manera directa.<o:p></o:p></span></p>
            <p class="MsoBodyText" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto">
                <i style="mso-bidi-font-style:normal"><span lang="X-NONE" style="font-size:11.0pt;
mso-bidi-font-family:Arial;color:#404040">El Decreto Supremo Nº 29562 de fecha 14 de mayo de 2008, </span><span style="font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:
ES-BO">faculta a EMAPA<span style="mso-spacerun:yes">&nbsp; </span>a solicitar en los procesos de contratación de bienes y servicios generales, para que los </span><span lang="ES" style="font-size:11.0pt;
mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES">proponentes que pertenezcan al sector productivo del área rural conjuntamente la organización territorial y/o económico productiva a la que pertenezcan, podrán presentar una Garantía Social por la cual garanticen de forma solidaria y mancomunada el cumplimiento de las obligaciones contraídas.<o:p></o:p></span></i></p>
            <p class="MsoBodyText" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="font-size:11.0pt;
mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES">Asimismo el mencionado Decreto Supremo, señala que, cuando el incumplimiento se deba a una causa externa o hecho de un tercero, no imputable al contratado o proveedor, EMAPA previa evaluación técnica, económico social y financiera, podrá adoptar las medidas necesarias para procurar el cumplimiento del objeto del contrato.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <i style="mso-bidi-font-style:normal"><span lang="ES-MX" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040;
mso-ansi-language:ES-MX">El Artículo 7° parágrafo I de la Ley N° 2341 de 23 de abril de 2002, Procedimiento Administrativo, establece que las autoridades administrativas, podrán delegar el ejercicio de sus competencias para conocer determinados asuntos administrativos, por causa justificada, mediante Resolución expresa, motivada y pública. Esta delegación se efectuará únicamente dentro de la entidad pública a su cargo.</span></i><i style="mso-bidi-font-style:
normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040;mso-ansi-language:ES-TRAD"><o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040;
mso-ansi-language:ES-TRAD">Mediante la Resolución Administrativa Nº 01-016 de 01 de Abril de 2013, la Gerencia General al amparo del Artículo 7º</span><span lang="ES-MX" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES-MX"> de la Ley N° 2341, delega competencias al Gerente de Producción, designándolo como autoridad Responsable de los Procesos de Contratación Directas sin límite de cuantía, y delegando la suscripción de contratos y adendas para todos los procesos de contratación cuya necesidad se origine en la Gerencia de Producción.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">TERCERA.- (OBJETO DEL CONTRATO). </span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">El objeto del presente contrato es la adquisición de <b style="mso-bidi-font-weight:normal">MATERIA PRIMA,</b> emergente de la producción realizada por la <b style="mso-bidi-font-weight:
normal">ORGANIZACIÓN, </b>resultado de la entrega de insumos agrícolas por<b style="mso-bidi-font-weight:normal"> EMAPA.<o:p></o:p></b></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040">La<b style="mso-bidi-font-weight:normal"> MATERIA PRIMA </b>objeto de la adquisición deberá cumplir<b style="mso-bidi-font-weight:normal"> </b></span><span lang="ES-TRAD" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES-TRAD">normas, condiciones, cantidad, calidad y precio establecidos por <b style="mso-bidi-font-weight:
normal">EMAPA</b> al momento de la compra y considerando las cláusulas contractuales contenidas en el presente instrumento legal.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">CUARTA.- (DOCUMENTOS INTEGRANTES DEL CONTRATO). </span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">Forman parte del presente contrato:<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:21.3pt;text-align:justify;text-indent:-21.3pt;mso-list:l3 level2 lfo3">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">4.1<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">Carta de solicitud de participación de la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN </b>(Original).<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:21.3pt;text-align:justify;text-indent:-21.3pt;mso-list:l3 level2 lfo3">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">4.2<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">Personalidad Jurídica de la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN </b>(fotocopia simple).<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:21.3pt;text-align:justify;text-indent:-21.3pt;mso-list:l3 level2 lfo3">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">4.3<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">Poder del representante legal de la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN </b>(fotocopia legalizada).<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:21.3pt;text-align:justify;text-indent:-21.3pt;mso-list:l3 level2 lfo3">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">4.4<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">Fotocopia de las Cédulas de Identidad del Representante Legal y de los miembros de la <b style="mso-bidi-font-weight:
normal">ORGANIZACIÓN</b>.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:21.3pt;text-align:justify;text-indent:-21.3pt;mso-list:l3 level2 lfo3">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">4.5<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040">ANEXO “A”:</span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"> Documento de Garantía Social que incluye la lista definitiva de Beneficiarios, de la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN, </b>debidamente firmadas y con la huella digital correspondiente.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
margin-left:21.3pt;text-align:justify;text-indent:-21.3pt;mso-list:l3 level2 lfo3">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">4.6<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040">ANEXO “B”:</span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"> Planilla de la superficie a trabajar por beneficiario.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">QUINTA.- (GARANTÍAS). </span></i></b><i style="mso-bidi-font-style:
normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040;mso-ansi-language:ES-TRAD">La <b style="mso-bidi-font-weight:
normal">ORGANIZACIÓN,<span style="mso-bidi-font-weight:bold"> </span></b></span></i><i><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040">en representación legal<b style="mso-bidi-font-weight:normal"> </b></span></i><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">de sus miembros y con plena aceptación de los mismos, </span><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;
color:#404040;mso-ansi-language:ES-TRAD">garantiza el cumplimiento de la obligación de manera solidaria y mancomunada conforme a</span><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">l artículo 3º del Decreto Supremo Nº 29562, de fecha 14 de mayo de 2008, acompañando los siguientes documentos:<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:21.3pt;text-align:justify;text-indent:-21.25pt;mso-list:l7 level2 lfo1">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">5.1<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040">GARANTÍA SOCIAL</span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"> <span style="mso-spacerun:yes">&nbsp;</span>de cumplimiento de contrato (Anexo “A”).<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:21.3pt;text-align:justify;text-indent:-21.25pt;mso-list:l7 level2 lfo1">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">5.2<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">Los miembros de la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN </b>se comprometen a responder de forma solidaria y mancomunada por la obligación contraída con <b style="mso-bidi-font-weight:normal">EMAPA, </b>trabajando dentro de la superficie establecida en Anexo “B” y garantizando que en ningún momento se desvíen los insumos gestionados por la empresa<b style="mso-bidi-font-weight:normal"> </b>a otros fines de los comprometidos.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
margin-left:21.3pt;text-align:justify;text-indent:-21.25pt;mso-list:l7 level2 lfo1">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">5.3<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">La <b style="mso-bidi-font-weight:
normal">ORGANIZACIÓN </b>garantiza que en ningún momento negará la obligación asumida por problemas y/o conflictos internos, puesto que es aceptada y es de conocimiento pleno de todos sus miembros.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">SEXTA.- (PRECIO DEL CONTRATO). </span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">Ambas partes por el presente contrato, sin que medie ninguno de los vicios del consentimiento como son: el error, dolo o violencia; acuerdan que los precios de <b style="mso-bidi-font-weight:
normal">LA MATERIA PRIMA </b>entregada<b style="mso-bidi-font-weight:normal"> </b>a <b style="mso-bidi-font-weight:normal">EMAPA</b> se fijarán en base a valores del mercado<b style="mso-bidi-font-weight:normal">. </b>Una vez definido el precio por <b style="mso-bidi-font-weight:normal">EMAPA</b>, se procederá al descuento de las obligaciones asumidas por los insumos agrícolas recibidos por los miembros de la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN</b> de manera individual y de acuerdo a la base de datos de <b style="mso-bidi-font-weight:
normal">EMAPA</b>.<b style="mso-bidi-font-weight:normal"><o:p></o:p></b></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-right:10.8pt;
mso-margin-bottom-alt:auto;text-align:justify">
                <b style="mso-bidi-font-weight:
normal"><i><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">SÉPTIMA.-</span></i></b><i><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040"> <b style="mso-bidi-font-weight:
normal">(PLAZO Y FORMA DE PAGO). </b></span></i><i style="mso-bidi-font-style:
normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040;mso-ansi-language:ES-TRAD"><o:p></o:p></span></i>
            </p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:21.3pt;text-align:justify;text-indent:-21.3pt;mso-list:l6 level2 lfo4">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">7.1<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">La <b style="mso-bidi-font-weight:
normal">ORGANIZACIÓN</b>, se encuentra obligada a entregar <b style="mso-bidi-font-weight:
normal">LA MATERIA PRIMA</b> comprometida en la cláusula tercera del presente contrato hasta el cierre de la campaña agrícola </span><span lang="ES" style="mso-bidi-font-size: 11.0pt; mso-bidi-font-family: Arial; color: #404040; background: yellow; mso-highlight: yellow"><span style="mso-no-proof:yes">VVerano 2013/2014</span></span></i><!--[if supportFields]><![endif]--><asp:Label ID="LblCamp" runat="server"></asp:Label>
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">. Para este efecto, b style="mso-bidi-font-weight:normal">EMAPA</b>, a través de una carta, comunicará oportunamente a la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN </b>la fecha de cierre de la campaña agrícola.<b style="mso-bidi-font-weight:
normal"><o:p></o:p></b></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:21.3pt;text-align:justify;text-indent:-21.3pt;mso-list:l6 level2 lfo4">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">7.2<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES-TRAD">El pago por la provisión de <b style="mso-bidi-font-weight:normal">MATERIA PRIMA</b>, será efectuado por <b style="mso-bidi-font-weight:normal">EMAPA</b> a favor del beneficiario de la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN</b> una </span><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">vez entregado el lote de la producción de <b style="mso-bidi-font-weight:normal">MATERIA PRIMA</b> a <b style="mso-bidi-font-weight:normal">EMAPA</b>, con plena aceptación y conformidad de la misma. Este lote puede corresponder a una entrega parcial o total de la producción del beneficiario. <b style="mso-bidi-font-weight:normal"><o:p></o:p></b></span></i>
            </p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:21.3pt;text-align:justify;text-indent:-21.3pt;mso-list:l6 level2 lfo4">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">7.3<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">Para realizar el cobro correspondiente, el beneficiario de la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN</b> deberá realizar la apertura de una cuenta bancaria individual en entidades financieras comunicadas por <b style="mso-bidi-font-weight:normal">EMAPA</b>, de acuerdo a la cláusula sexta del presente documento.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:21.3pt;text-align:justify;text-indent:-21.3pt;mso-list:l6 level2 lfo4">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">7.4<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">La <b style="mso-bidi-font-weight:
normal">ORGANIZACIÓN</b> y cada uno de sus miembros, autorizan en forma expresa a EMAPA, a solicitar información sobre sus antecedentes crediticios y otras cuentas por pagar de carácter económico, financiero y comercial registrados en los BIC´s (Buros de Información Crediticia), mientras dure la relación contractual entre las partes.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-bottom-alt:auto;margin-left:21.25pt;
text-align:justify">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040">Asimismo, autoriza a incorporar los datos crediticios y de otras cuentas por pagar de carácter económico, financiero y comercial derivados de la relación con <b style="mso-bidi-font-weight:normal">EMAPA</b>, en las bases de datos de propiedad de los Burós de Información Crediticia que cuenten con la licencia de funcionamiento del Organismo de Supervisión.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b style="mso-bidi-font-weight:normal"><i><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;
color:#404040;mso-ansi-language:ES-TRAD">OCTAVA.-</span></i></b><i><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;
color:#404040;mso-ansi-language:ES-TRAD"> </span></i><b style="mso-bidi-font-weight:
normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">(FACTURACIÓN).</span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040"> En cumplimiento con la Ley Tributaria, <b style="mso-bidi-font-weight:normal">EMAPA,</b> al momento del pago a los miembros de la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN</b> por la provisión de <b style="mso-bidi-font-weight:normal">MATERIA PRIMA</b>, realizará los descuentos correspondientes a impuestos (retención impositiva) en caso de que el beneficiario <b style="mso-bidi-font-weight:normal">NO</b> cuente con Registro Agropecuario Unificado (RAU) o Certificado de no Imponibilidad (CNI).<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">NOVENA.- (VIGENCIA DEL CONTRATO). </span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">El presente contrato tendrá vigencia a partir de la suscripción del mismo, hasta cumplimiento total de la obligación y de acuerdo a lo estipulado en la cláusula 7.1 del presente contrato.<o:p></o:p></span></i></p>
            <p class="MsoHeading8" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b style="mso-bidi-font-weight:normal"><span lang="X-NONE" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040;
mso-bidi-font-style:normal">DÉCIMA.- (OBLIGACIONES DE LAS PARTES). <o:p></o:p></span></b>
            </p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:30.0pt;text-align:justify;text-indent:-30.0pt;mso-list:l1 level2 lfo2">
                <![if !supportLists]><b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:
11.0pt;mso-fareast-font-family:Arial;mso-bidi-font-family:Arial;color:#404040;
mso-ansi-language:ES-TRAD"><span style="mso-list:Ignore">10.1<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp; </span></span></span></i></b><![endif]><b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES-TRAD">EMAPA</span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES-TRAD;
mso-bidi-font-weight:bold"> se obliga al pago por la adquisición de <b>MATERIA PRIMA</b> de acuerdo a lo establecido en el presente contrato. <o:p></o:p></span></i>
            </p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:30.0pt;text-align:justify;text-indent:-30.0pt;mso-list:l1 level2 lfo2">
                <![if !supportLists]><b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:
11.0pt;mso-fareast-font-family:Arial;mso-bidi-font-family:Arial;color:#404040;
mso-ansi-language:ES-TRAD"><span style="mso-list:Ignore">10.2<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">La<b style="mso-bidi-font-weight:
normal"> ORGANIZACIÓN</b> deberá cumplir con las siguientes obligaciones:</span><span lang="ES-TRAD" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES-TRAD;
mso-bidi-font-weight:bold"><o:p></o:p></span></i></p>
            <p class="MsoHeading8" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:70.9pt;text-align:justify;text-indent:-42.55pt;mso-list:l1 level3 lfo2">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><span lang="X-NONE" style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:Arial"><span style="mso-list:Ignore">10.2.1<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></b><![endif]><span lang="X-NONE" style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040">Entregar </span><span lang="ES" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040;
mso-ansi-language:ES">la <b style="mso-bidi-font-weight:normal">MATERIA PRIMA</b></span><b style="mso-bidi-font-weight:normal"><span lang="ES" style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040"> </span></b><span lang="X-NONE" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040">comprometid</span><span style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040;
mso-ansi-language:ES-BO">a</span><b style="mso-bidi-font-weight:normal"><span lang="X-NONE" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
color:#404040">,</span></b><span lang="ES" style="font-size:11.0pt;font-family:
&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040;mso-ansi-language:ES"> dentro los plazos </span><span lang="X-NONE" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
color:#404040">calidad y cantidad </span><span style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040;mso-ansi-language:ES-BO">establecidos </span><span lang="X-NONE" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
color:#404040">por </span><b style="mso-bidi-font-weight:normal"><span style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040;
mso-ansi-language:ES-BO">EMAPA,</span></b><span style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040"> </span><span style="font-size:
11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040;mso-ansi-language:ES-BO">mismos que serán definidos y comunicados a la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN</b></span><span lang="X-NONE" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
color:#404040">.<o:p></o:p></span></p>
            <p class="MsoHeading8" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:70.9pt;text-align:justify;text-indent:-42.55pt;mso-list:l1 level3 lfo2">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><span lang="X-NONE" style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:Arial;mso-bidi-font-style:
normal"><span style="mso-list:Ignore">10.2.2<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></b><![endif]><span lang="X-NONE" style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040;mso-bidi-font-style:normal">Custodiar </span><span lang="ES" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
color:#404040;mso-ansi-language:ES;mso-bidi-font-style:normal">la <b style="mso-bidi-font-weight:normal">MATERIA PRIMA</b></span><span lang="X-NONE" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040;
mso-bidi-font-style:normal">, hasta la recepción definitiva por <b style="mso-bidi-font-weight:normal">EMAPA</b>.<o:p></o:p></span></p>
            <p class="MsoHeading8" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:70.9pt;text-align:justify;text-indent:-42.55pt;mso-list:l1 level3 lfo2">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><span lang="X-NONE" style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:Arial"><span style="mso-list:Ignore">10.2.3<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></b><![endif]><span lang="X-NONE" style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040">La<b style="mso-bidi-font-weight:
normal"> ORGANIZACIÓN</b> garantiza que ninguno de sus miembros pertenece o form</span><span lang="ES" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
color:#404040;mso-ansi-language:ES">a</span><span lang="X-NONE" style="font-size:
11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040"> parte de empresas proveedoras de insumos o </span><span lang="ES" style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040;mso-ansi-language:ES"><span style="mso-spacerun:yes">&nbsp;&nbsp;</span>de </span><b style="mso-bidi-font-weight:
normal"><span lang="X-NONE" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
color:#404040">EMAPA</span></b><span lang="X-NONE" style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040">. En caso de encontrarse este tipo de irregularidades, <b style="mso-bidi-font-weight:normal">EMAPA</b> automáticamente suspenderá cualquier provisión, pago y apoyo productivo a l</span><span style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040;
mso-ansi-language:ES-BO">os miembros de l</span><span lang="X-NONE" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040">a <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN </b>sin perjuicio de iniciar las acciones legales correspondientes.<o:p></o:p></span></p>
            <p class="MsoHeading8" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
margin-left:70.9pt;text-align:justify;text-indent:-42.55pt;mso-list:l1 level3 lfo2">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><span lang="X-NONE" style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:Arial"><span style="mso-list:Ignore">10.2.4<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></b><![endif]><span lang="X-NONE" style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040">La <b style="mso-bidi-font-weight:
normal">ORGANIZACIÓN</b> no podrá incorporar listas adicionales y/o complementarias fuera de </span><span style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
color:#404040;mso-ansi-language:ES-BO">las condiciones establecidas por </span><b style="mso-bidi-font-weight:normal"><span lang="X-NONE" style="font-size:11.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040">EMAPA</span><span style="font-size:11.0pt;font-family:
&quot;Arial&quot;,&quot;sans-serif&quot;;color:#404040;mso-ansi-language:ES-BO">.</span></b><span lang="X-NONE" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
color:#404040"><o:p></o:p></span></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">DÉCIMA PRIMERA.- (LUGAR DE ENTREGA Y CONDICIONES PARA LA RECEPCIÓN DE LA MATERIA PRIMA). </span></i></b><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">Los miembros de la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN</b><span style="mso-bidi-font-style:italic"> harán entrega de la<b style="mso-bidi-font-weight:
normal"> MATERIA PRIMA</b> en el lugar establecido por <b style="mso-bidi-font-weight:
normal">EMAPA </b>a través de la Gerencia de Acopio y Transformación<b style="mso-bidi-font-weight:normal"> </b>bajo las siguientes condiciones:<o:p></o:p></span></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:35.45pt;text-align:justify;text-indent:-35.45pt;mso-list:l2 level2 lfo5">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">11.1<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">Los miembros de la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN,</b> deberán respetar su turno para el depósito de su producto en los lugares determinados por <b style="mso-bidi-font-weight:normal">EMAPA</b>, a través de la Gerencia de Acopio y Transformación.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
margin-left:35.45pt;text-align:justify;text-indent:-35.45pt;mso-list:l2 level2 lfo5">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">11.2<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">En el momento de la recepción del <b style="mso-bidi-font-weight:normal">PRODUCTO</b>, se realizará el análisis de laboratorio que certifique el cumplimiento de las características de calidad definidas por <b style="mso-bidi-font-weight:normal">EMAPA</b>, a través de la Gerencia de Acopio y Transformación quien se reservará el derecho de rechazar el <b style="mso-bidi-font-weight:normal">PRODUCTO</b> cuando no cumpla los parámetros establecidos por la misma.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;
color:#404040;mso-ansi-language:ES-TRAD">DÉCIMA SEGUNDA.- (CAUSAS DE FUERZA MAYOR Y/O CASO FORTUITO). </span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;
color:#404040;mso-ansi-language:ES-TRAD">Con el fin de exceptuar a la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN<span style="mso-bidi-font-weight:
bold"> </span></b>de determinadas responsabilidades por incumplimiento durante la vigencia del presente contrato, <b style="mso-bidi-font-weight:normal">EMAPA<span style="mso-bidi-font-weight:bold"> </span></b>tendrá la facultad de calificar las causas de fuerza mayor y/o caso fortuito, que pudieran tener efectiva consecuencia sobre el cumplimiento del Contrato.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:35.45pt;text-align:justify;text-indent:-35.45pt;mso-list:l0 level2 lfo6">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">12.1<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">Se entiende por fuerza mayor al obstáculo externo, imprevisto o inevitable que origina una fuerza extraña al hombre y que impide el cumplimiento de la obligación (ejemplo: incendios, inundaciones, y otros desastres naturales).<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:35.45pt;text-align:justify;text-indent:-35.45pt;mso-list:l0 level2 lfo6">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">12.2<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES-TRAD">Se entiende por caso fortuito al obstáculo interno atribuible al hombre, imprevisto o inevitable, proveniente de las condiciones mismas en que la obligación debía ser cumplida (ejemplo: conmociones civiles, huelgas, bloqueos, revoluciones, etc.)</span><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"><o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:35.45pt;text-align:justify;text-indent:-35.45pt;mso-list:l0 level2 lfo6">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">12.3<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">En cualquiera de los casos anteriores, la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN</b> tiene la obligación de comunicar por escrito y de manera oportuna la ocurrencia de estas adversidades, para que <b style="mso-bidi-font-weight:normal">EMAPA</b> efectúe la evaluación correspondiente.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
margin-left:35.45pt;text-align:justify;text-indent:-35.45pt;mso-list:l0 level2 lfo6">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040"><span style="mso-list:Ignore">12.4<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></i></b><![endif]><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">En caso de presentarse causas de fuerza mayor y/o caso fortuito debidamente comprobados, se procederá de acuerdo a lo establecido en la Cláusula Decima Sexta del presente Contrato.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;
color:#404040;mso-ansi-language:ES-TRAD">DÉCIMA TERCERA.- (TERMINACIÓN DEL CONTRATO). </span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;
color:#404040;mso-ansi-language:ES-TRAD">El presente contrato, concluirá por una de las siguientes causas:<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:30.05pt;text-align:justify;text-indent:-30.05pt;mso-list:l4 level1 lfo7">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES-TRAD"><span style="mso-list:Ignore">13.2<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp; </span></span></span></i></b><![endif]><b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;
color:#404040;mso-ansi-language:ES-TRAD">Por Cumplimiento de Contrato: </span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES-TRAD">De forma normal, tanto <b style="mso-bidi-font-weight:normal">EMAPA<span style="mso-bidi-font-weight:bold"> </span></b>como la <b style="mso-bidi-font-weight:
normal">ORGANIZACIÓN<span style="mso-bidi-font-weight:bold">, </span></b>darán por terminado el presente Contrato, una vez que ambas partes hayan dado cumplimiento a todas las condiciones y estipulaciones contenidas en él.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
margin-left:30.05pt;text-align:justify;text-indent:-30.05pt;mso-list:l4 level1 lfo7">
                <![if !supportLists]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:Arial;
mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES-TRAD"><span style="mso-list:Ignore">13.2<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp; </span></span></span></i></b><![endif]><b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040;mso-ansi-language:ES-TRAD">Por Incumplimiento del contrato:</span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;
color:#404040;mso-ansi-language:ES-TRAD"> en caso de que la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN</b> incumpla con las obligaciones asumidas, <b style="mso-bidi-font-weight:normal">EMAPA</b> iniciara acciones legales correspondientes.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;
color:#404040;mso-ansi-language:ES-TRAD">DÉCIMA CUARTA.- (MECANISMOS DE RESOLUCIÓN DE CONTROVERSIAS). </span></i></b><i style="mso-bidi-font-style:
normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040;mso-ansi-language:ES-TRAD">En caso de surgir controversias entre la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN<span style="mso-bidi-font-weight:bold"> </span></b>y <b>EMAPA, </b>que no puedan ser solucionadas por la vía de la concertación, las partes están facultadas para acudir a la vía judicial, bajo la jurisdicción coactiva fiscal, civil y/o penal.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify;mso-layout-grid-align:none;text-autospace:none">
                <b style="mso-bidi-font-weight:normal"><i><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">DÉCIMA QUINTA.- (LEGISLACIÓN APLICABLE). </span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040">El presente Contrato es un documento Administrativo, por lo que está sujeto a la normativa prevista en la Ley Nº 1178 de Administración<span style="mso-bidi-font-style:
italic"> y Control Gubernamentales,</span> Código Civil en los aspecto<span style="mso-bidi-font-style:italic">s de su ejecución y resultados y en caso de incumplimiento y daño económico al Estado la Ley Nº 004 de </span></span></i><b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-fareast-font-family:Calibri;mso-bidi-font-family:Arial;color:#404040"><span style="mso-spacerun:yes">&nbsp;</span></span></i></b><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-fareast-font-family:
Calibri;mso-bidi-font-family:Arial;color:#404040;mso-bidi-font-weight:bold">Lucha Contra La Corrupción, Enriquecimiento Ilícito<span style="mso-spacerun:yes">&nbsp; </span>e Investigación de Fortunas “Marcelo Quiroga Santa Cruz”.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">DÉCIMA<span style="mso-bidi-font-style:italic"> SEXTA.- </span>(ADENDA AL CONTRATO DE PROVISIÓN DE MATERIA PRIMA). </span></i></b><i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">En caso de presentarse causas de fuerza mayor y/o caso fortuito comprobados por <b style="mso-bidi-font-weight:normal">EMAPA</b> y avalado por entidades correspondientes que afecten la entrega de la producción comprometida por la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN</b>, <b style="mso-bidi-font-weight:normal">EMAPA</b> realizará una Adenda al Contrato de Provisión de Materia Prima (Reprogramación de Cancelación de Deuda) correspondiente, de acuerdo a procedimiento establecido y mediante acuerdo entre partes.<o:p></o:p></span></i></p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify">
                <b style="mso-bidi-font-weight:normal"><i><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040">DÉCIMA SÉPTIMA.- </span></i></b><b><i style="mso-bidi-font-style:normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;
color:#404040;mso-ansi-language:ES-TRAD">(MODIFICACIONES AL CONTRATO). </span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">Los términos y condiciones de este contrato podrán ser modificados, previa justificación técnica legal, mediante un contrato modificatorio. <o:p></o:p></span></i>
            </p>
            <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify;mso-outline-level:1">
                <b style="mso-bidi-font-weight:normal"><i><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040">DECIMA OCTAVA.- (CONFORMIDAD). </span></i></b><i><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">Las</span></i><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040"> partes intervinientes en el presente contrato, aceptamos y damos nuestra plena conformidad con todas y cada una de las cláusulas precedentes y nos comprometemos a su fiel y estricto cumplimiento, en fe de lo cual firmamos al pie en cinco ejemplares de igual valor, en el Departamento de </span><span lang="ES" style="mso-bidi-font-size: 11.0pt; mso-bidi-font-family: Arial; color: #404040; background: yellow; mso-highlight: yellow"><span style="mso-no-proof:yes">Cochabamba</span></span></i><!--[if supportFields]><![endif]--><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">, a los </span></i><!--[if supportFields]><![endif]--><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size: 11.0pt; mso-bidi-font-family: Arial; color: #404040; background: yellow; mso-highlight: yellow"><span style="mso-no-proof:yes">30 días del mes de Septiembre del año 2013</span></span></i><!--[if supportFields]><![endif]--><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">.<o:p></o:p></span></i></p>
            <p class="MsoNormal">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
            <p class="MsoNormal">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
            <p class="MsoNormal">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
            <p class="MsoNormal">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
            <p class="MsoNormal">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
            <p class="MsoNormal">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
            <p class="MsoNormal">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
            <p class="MsoNormal">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
            <p class="MsoNormal">
                <i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
            <table align="left" border="0" cellpadding="0" cellspacing="0" class="MsoNormalTable" style="width:466.85pt;border-collapse:collapse;mso-table-overlap:
 never;mso-yfti-tbllook:1184;mso-table-lspace:7.05pt;margin-left:4.8pt;
 mso-table-rspace:7.05pt;margin-right:4.8pt;mso-table-anchor-vertical:paragraph;
 mso-table-anchor-horizontal:margin;mso-table-left:center;mso-table-top:-8.75pt;
 mso-padding-alt:0cm 5.4pt 0cm 5.4pt" width="622">
                <tr style="mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes">
                    <td style="width:173.2pt;border:none;border-top:solid windowtext 1.0pt;
  mso-border-top-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt" valign="top" width="231">
                        <p align="center" class="MsoNormal" style="text-align:center;mso-element:frame;
  mso-element-frame-hspace:7.05pt;mso-element-wrap:around;mso-element-anchor-vertical:
  paragraph;mso-element-anchor-horizontal:margin;mso-element-left:center;
  mso-element-top:-8.75pt;mso-height-rule:exactly">
                            <i style="mso-bidi-font-style:normal"><span style="color: #404040; background: yellow; mso-highlight: yellow; mso-ansi-language: ES-BO; mso-no-proof: yes">Dionicia Chura Castro</span></i><!--[if supportFields]><![endif]--><i style="mso-bidi-font-style:normal"><span style="color:#404040;mso-ansi-language:
  ES-BO"><o:p></o:p></span></i></p>
                        <p align="center" class="MsoNormal" style="text-align:center;mso-element:frame;
  mso-element-frame-hspace:7.05pt;mso-element-wrap:around;mso-element-anchor-vertical:
  paragraph;mso-element-anchor-horizontal:margin;mso-element-left:center;
  mso-element-top:-8.75pt;mso-height-rule:exactly">
                            <i style="mso-bidi-font-style:
  normal"><span style="color:#404040;mso-ansi-language:ES-BO">C.I. </span></i><i style="mso-bidi-font-style:normal"><span lang="EN-US" style="color: #404040; background: yellow; mso-highlight: yellow; mso-ansi-language: EN-US; mso-no-proof: yes">3819250 CB</span></i><!--[if supportFields]><![endif]--><i style="mso-bidi-font-style:normal"><span lang="EN-US" style="color:#404040;
  mso-ansi-language:EN-US"><o:p></o:p></span></i></p>
                        <p align="center" class="MsoNormal" style="text-align:center;mso-element:frame;
  mso-element-frame-hspace:7.05pt;mso-element-wrap:around;mso-element-anchor-vertical:
  paragraph;mso-element-anchor-horizontal:margin;mso-element-left:center;
  mso-element-top:-8.75pt;mso-height-rule:exactly">
                            <b style="mso-bidi-font-weight:
  normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="color:
  #404040">REPRESENTANTE LEGAL<o:p></o:p></span></i></b></p>
                        <p align="center" class="MsoNormal" style="text-align:center;mso-element:frame;
  mso-element-frame-hspace:7.05pt;mso-element-wrap:around;mso-element-anchor-vertical:
  paragraph;mso-element-anchor-horizontal:margin;mso-element-left:center;
  mso-element-top:-8.75pt;mso-height-rule:exactly">
                            <b style="mso-bidi-font-weight:
  normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="color:
  #404040">ORGANIZACIÓN</span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="color:#404040"><o:p></o:p></span></i></p>
                    </td>
                    <td style="width:1.0cm;padding:0cm 5.4pt 0cm 5.4pt" valign="top" width="38">
                        <p align="center" class="MsoNormal" style="text-align:center;mso-element:frame;
  mso-element-frame-hspace:7.05pt;mso-element-wrap:around;mso-element-anchor-vertical:
  paragraph;mso-element-anchor-horizontal:margin;mso-element-left:center;
  mso-element-top:-8.75pt;mso-height-rule:exactly">
                            <i style="mso-bidi-font-style:
  normal"><span lang="ES" style="color:#404040"><o:p>&nbsp;</o:p></span></i></p>
                    </td>
                    <td style="width:162.05pt;border:none;border-top:solid windowtext 1.0pt;
  mso-border-top-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt" valign="top" width="216">
                        <p align="center" class="MsoNormal" style="text-align:center;mso-element:frame;
  mso-element-frame-hspace:7.05pt;mso-element-wrap:around;mso-element-anchor-vertical:
  paragraph;mso-element-anchor-horizontal:margin;mso-element-left:center;
  mso-element-top:-8.75pt;mso-height-rule:exactly">
                            <i style="mso-bidi-font-style:
  normal"><span lang="ES" style="color:#404040">Juan Condori Canaviri<o:p></o:p></span></i></p>
                        <p align="center" class="MsoNormal" style="text-align:center;mso-element:frame;
  mso-element-frame-hspace:7.05pt;mso-element-wrap:around;mso-element-anchor-vertical:
  paragraph;mso-element-anchor-horizontal:margin;mso-element-left:center;
  mso-element-top:-8.75pt;mso-height-rule:exactly">
                            <i style="mso-bidi-font-style:
  normal"><span lang="ES" style="color:#404040">C.I. 4241897 LP<o:p></o:p></span></i></p>
                        <p align="center" class="MsoNormal" style="text-align:center;mso-element:frame;
  mso-element-frame-hspace:7.05pt;mso-element-wrap:around;mso-element-anchor-vertical:
  paragraph;mso-element-anchor-horizontal:margin;mso-element-left:center;
  mso-element-top:-8.75pt;mso-height-rule:exactly">
                            <b style="mso-bidi-font-weight:
  normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="color:
  #404040">GERENTE DE PRODUCCIÓN</span></i></b><i style="mso-bidi-font-style:
  normal"><span lang="ES" style="color:#404040"><o:p></o:p></span></i></p>
                        <p align="center" class="MsoNormal" style="text-align:center;mso-element:frame;
  mso-element-frame-hspace:7.05pt;mso-element-wrap:around;mso-element-anchor-vertical:
  paragraph;mso-element-anchor-horizontal:margin;mso-element-left:center;
  mso-element-top:-8.75pt;mso-height-rule:exactly">
                            <b style="mso-bidi-font-weight:
  normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="color:
  #404040">EMAPA</span></i></b><i style="mso-bidi-font-style:normal"><span lang="ES" style="color:#404040"><o:p></o:p></span></i></p>
                    </td>
                </tr>
            </table>
        </div>
        <b style="mso-bidi-font-weight:normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="font-size:11.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:#404040;mso-ansi-language:ES;mso-fareast-language:ES;
mso-bidi-language:AR-SA">
        <br clear="all" style="page-break-before:always;
mso-break-type:section-break" />
        </span></i></b>
        <p align="center" class="MsoNormal" style="text-align:center">
            <b style="mso-bidi-font-weight:
normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">ANEXO “A”<o:p></o:p></span></i></b></p>
        <p align="center" class="MsoNormal" style="text-align:center">
            <b style="mso-bidi-font-weight:
normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">DOCUMENTO DE GARANTÍA SOCIAL, LISTA DEFINITIVA DE<o:p></o:p></span></i></b></p>
        <p align="center" class="MsoNormal" style="text-align:center">
            <b style="mso-bidi-font-weight:
normal"><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">BENEFICIARIOS, DE LA ORGANIZACIÓN.<o:p></o:p></span></i></b></p>
        <p align="center" class="MsoNormal" style="text-align:center">
            <i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
        <p class="MsoNormal" style="text-align:justify">
            <i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
        <p class="MsoNormal" style="text-align:justify">
            <i style="mso-bidi-font-style:
normal"><span lang="ES-TRAD" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040;mso-ansi-language:ES-TRAD">En cumplimiento d</span></i><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">el artículo 3º del Decreto Supremo Nº 29562, de fecha 14 de mayo de 2008, la <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN,</b> con plena aceptación y conformidad de sus miembros que firman el presente documento, garantizan de forma solidaria y mancomunada el cumplimiento de las obligaciones contraídas con <b style="mso-bidi-font-weight:normal">EMAPA</b> de acuerdo a las condiciones establecidas en el contrato de provisión de <b style="mso-bidi-font-weight:normal">MATERIA PRIMA</b> suscrito en fecha </span><span lang="ES" style="mso-bidi-font-size: 11.0pt; mso-bidi-font-family: Arial; color: #404040; background: yellow; mso-highlight: yellow"><span style="mso-no-proof:yes">30 de Septiembre de 2013</span></span></i><!--[if supportFields]><![endif]--><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">. <o:p></o:p></span></i>
        </p>
        <p class="MsoNormal" style="text-align:justify">
            <i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
        <p class="MsoNormal" style="text-align:justify">
            <i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">Los beneficiarios de la <b style="mso-bidi-font-weight:
normal">ORGANIZACIÓN</b> garantizan que los insumos agrícolas entregados en calidad de recursos reembolsables serán utilizados exclusivamente para los fines establecidos en el Contrato de Provisión de <b style="mso-bidi-font-weight:
normal">MATERIA PRIMA</b> con <b style="mso-bidi-font-weight:normal">EMAPA</b>, asimismo<b style="mso-bidi-font-weight:normal"> </b>se comprometen a vender a <b style="mso-bidi-font-weight:normal">EMAPA</b> la producción emergente de la campaña agrícola </span></i><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size: 11.0pt; mso-bidi-font-family: Arial; color: #404040; background: yellow; mso-highlight: yellow"><span style="mso-no-proof:yes">Verano 2013/2014</span></span></i><!--[if supportFields]><![endif]--><i style="mso-bidi-font-style:normal"><span lang="ES" style="mso-bidi-font-size:
11.0pt;mso-bidi-font-family:Arial;color:#404040">.<o:p></o:p></span></i></p>
        <p class="MsoNormal" style="text-align:justify">
            <i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
        <p class="MsoNormal" style="text-align:justify">
            <i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">La <b style="mso-bidi-font-weight:normal">ORGANIZACIÓN</b>, al momento del pago, autoriza el descuento correspondiente por la cantidad de insumos entregados en calidad de anticipo por la producción comprometida.<o:p></o:p></span></i></p>
        <p class="MsoNormal" style="text-align:justify">
            <i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040"><o:p>&nbsp;</o:p></span></i></p>
        <p class="MsoNormal" style="text-align:justify">
            <i style="mso-bidi-font-style:
normal"><span lang="ES" style="mso-bidi-font-size:11.0pt;mso-bidi-font-family:
Arial;color:#404040">En conformidad y aceptación plena por lo anteriormente expuesto, firmamos los siguientes beneficiarios<span style="mso-bidi-font-weight:bold">:<o:p></o:p></span></span></i></p>
    
    </div>
    </form>
</body>
</html>
