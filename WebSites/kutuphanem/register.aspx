<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" type="text/css" />

</head>
<body>

    <div class="wrapper-form">

    <div class="login-header" style="text-align:center">
    <h1> KÜTÜPHANE • KAYIT OL </h1>
    </div>
    <div class="login-form">
    <form id="form1" runat="server">
    <div>
    <p> Ad:</p>
        <p> 
            <asp:TextBox ID="TextBox10" runat="server" CssClass="TextBox"></asp:TextBox>
    </p>
        <p> 
            Soyad:</p>
        <p> 
            <asp:TextBox ID="TextBox11" runat="server" CssClass="TextBox"></asp:TextBox>
    </p>
    <p> TC:&nbsp; </p>
        <p> 
            <asp:TextBox ID="TextBox12" runat="server" CssClass="TextBox"></asp:TextBox>
    </p>
        <p> 
            Telefon</p>
        <p> 
            <asp:TextBox ID="TextBox13" runat="server"  CssClass="TextBox"></asp:TextBox>
    </p>
        <p> 
            Mail</p>
        <p> 
            <asp:TextBox ID="TextBox1" runat="server"  CssClass="TextBox"></asp:TextBox>
    </p>
    <p> şifre: </p>
        <p> 
            <asp:TextBox ID="TextBox14" runat="server" TextMode="Password" CssClass="TextBox"></asp:TextBox>
        </p>
    <p> şifre Tekrar: </p>
        <p> <asp:TextBox ID="TextBox15" runat="server" TextMode="Password" CssClass="TextBox"></asp:TextBox>
        </p>
        <p> &nbsp;</p>
            
        <p> &nbsp; <asp:Button ID="Button1" runat="server" Text="KAYIT OL" OnClick="Button1_Click" Cssclass="button1"/>
        </p>
        <p> 
            <asp:Label ID="Label1" runat="server" Text="Bir hatayla karşılaşıldı" Visible="False"></asp:Label>
        </p>
        <p> 
            &nbsp;</p>
        <p> 
            &nbsp;</p>
        <p> 
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Zaten bir hesabınız var mı? Giriş yapın.</asp:LinkButton>
        </p>

    </div>
    </form>
    </div>
</div>


  
</body>
</html>
