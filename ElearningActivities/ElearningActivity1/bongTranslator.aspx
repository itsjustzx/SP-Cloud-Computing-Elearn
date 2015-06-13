<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bongTranslator.aspx.cs" Inherits="ElearningActivity1.bongTranslator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body> 
 
<form id="form1" runat="server"> 
 
<div> 
 
<h2>My Translator</h2> 
 
<p> 
 
Enter your text in English:&nbsp; </p> 
 
<p> 
 
<asp:TextBox ID="TextBox1" runat="server" 
 
Width="198px"></asp:TextBox> 
 
</p> 
 
<p> 
 
<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
 
Text="Translate" /> 
 
</p> 
 
<p> 
 
Here is your translation:</p> 
 
<p> 
 
<asp:Literal ID="lbl1" runat="server"></asp:Literal> 
 
</p> 
 
</div> 
 
</form></body>
</html>
