<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" type="text/css" />

</head>
<body>

    <div class="wrapper-form">

    <div class="login-header" style="text-align:center">
        <h1> KÜTÜPHANE • GİRİŞ YAP </h1>
    </div>
    <div class="login-form">
    <form id="form1" runat="server">
    <div>
    <p> TC:&nbsp; </p>
        <p> <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBox"></asp:TextBox>
        </p>
    <p> şifre: </p>
        <p> <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="TextBox"></asp:TextBox>
        </p>
        <p> &nbsp;</p>
            
        <p> &nbsp; <asp:Button ID="Button1" runat="server" Text="Giriş yap" OnClick="Button1_Click" Cssclass="button1"/>
        </p>
        <p> 
            <asp:Label ID="Label1" runat="server" Text="Kullanıcı adı veya şifre yanlış!" Visible="False"></asp:Label>
        </p>
        <p> 
            &nbsp;</p>
        <p> 
            &nbsp;</p>
        <p> 
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Bir hesabınız yok mu? Kayıt olun!</asp:LinkButton>
        </p>

    </div>
    </form>
    </div>
</div>


  
</body>
</html>
