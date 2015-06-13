<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="navigation.aspx.cs" Inherits="ElearningActivity1.navigation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Welcome to Zi Xiang's web page</p>
        <asp:Menu ID="NavigationMenu" runat="server">
                    <Items>
                        <asp:MenuItem NavigateUrl="bongTranslator.aspx" Text="Elearning Activity 1"/>
                        <asp:MenuItem NavigateUrl="Exercise6.html" Text="Elearning Activity 2"/>
                        <asp:MenuItem NavigateUrl="WeatherService.html" Text="Elearning Activity 3"/>
                        <asp:MenuItem NavigateUrl="apiQuiz.html" Text="Elearning Activity 4"/>
                    </Items>
                </asp:Menu>
    
    </div>
    </form>
</body>
</html>
