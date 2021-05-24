<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="kitap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1> KİTAPLAR</h1>
    <p> </p>

    <%-- SADECE ADMİNLERİN KİTAP EKLEYEBİLMESİ İÇİN KİTAP EKLEME ALANINI PANEL İÇERİSİNE ALIYORUM VE VISIBLE ÖZELLİĞİNİ GİRİŞ YAPAN KİŞİNİN YETKİSİNE GÖRE BELİRLİYORUM --%>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <p> &nbsp;</p>

        <div class="kitapeklebaslik">
            <h5>KİTAP EKLE </h5>
        </div>
        <table class="kitapekle"  >

        <tr> 
            <td class="auto-style1" > ISBN:</td>
            <td class="auto-style1"> <asp:TextBox ID="TextBox1" runat="server"  Cssclass="TextBox" Width="250px"></asp:TextBox></td>

        </tr>
        <tr> 
            <td> Kitap adı:</td>
            <td> <asp:TextBox ID="TextBox2" runat="server"  Cssclass="TextBox" Width="250px"></asp:TextBox></td>
        </tr>
        <tr> 
            <td> Yazar ad:</td>
            <td> <asp:TextBox ID="TextBox3" runat="server"  Cssclass="TextBox" Width="250px"></asp:TextBox></td>
        </tr>
        <tr> 
            <td> Yazar soyad:</td>
            <td> <asp:TextBox ID="TextBox9" runat="server"  Cssclass="TextBox" Width="250px"></asp:TextBox></td>
        </tr>
        <tr> 
            <td> Yayın Evi:</td>
            <td> <asp:TextBox ID="TextBox4" runat="server"  Cssclass="TextBox" Width="250px"></asp:TextBox></td>
        </tr>
        <tr> 
            <td> Yayın Tarihi:</td>
            <td> <asp:TextBox ID="TextBox5" runat="server"  Cssclass="TextBox" Width="250px"></asp:TextBox></td>
        </tr>
        <tr> 
            <td> Sayfa Sayısı:</td>
            <td> <asp:TextBox ID="TextBox6" runat="server"  Cssclass="TextBox" Width="250px"></asp:TextBox></td>
        </tr>
        <tr> 
            <td> Türü:</td>
            <td> <asp:TextBox ID="TextBox7" runat="server"  CssClass="TextBox" Width="250px"></asp:TextBox></td>
        </tr>
        <tr> 
            <td> Stok:</td>
            <td> <asp:TextBox ID="TextBox8" runat="server"  CssClass="TextBox" Width="250px"></asp:TextBox></td>
        </tr>

        <tr>
            <td> Resim yükle:</td> 
            <td><asp:FileUpload ID="FileUpload1" runat="server" Width="" /> 
            </td>
        </tr>

        <tr> 
            <td colspan ="2">    
                <br />
                <asp:Button ID="Button1" runat="server" Text="TEMİZLE" Cssclass="button1" OnClick="Button1_Click" />
                &nbsp;
                <asp:Button ID="Button2" runat="server" Text="KAYDET" OnClick="Button2_Click" Cssclass="button1"/>
                <br />
                <asp:LinkButton ID="lblDurum" runat="server" CssClass="imjusttext" OnClick="LinkButton1_Click" ForeColor="Red" Visible="False">LinkButton </asp:LinkButton>
            </td>
        </tr>


    </table>

    </asp:Panel>
    
    

    <br />
    
    

    <br />
    <%--  KİTAP ARAMASI YAPILABİLEN KISIM --%>
        <div class="kitaplarbaslik">
           <div class="kitaplarbaslik-sol">
             <h5>TÜM KİTAPLAR </h5>
           </div>
           <div class="kitaplarbaslik-sag">
               <asp:TextBox ID="TextBox10" runat="server" CssClass="arama"></asp:TextBox>
               <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/ara.png" CssClass="search-button" OnClick="ImageButton1_Click"/>
           </div>
        </div>
    <%-- DATALIST İLE KİTAPLARI LİSTELİYORUM --%>
    <asp:DataList ID="lstkitaplar" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" >
        <ItemTemplate>

            <div class="card-wrapper"> 
                <div class="row">
                    <div class="column">
                        <div class="card">
                            <a href="kitap_ayrinti.aspx?kitapISBN=<%#Eval("ISBN") %>">
                                <asp:Image ID="Image1" CssClass="img" ImageUrl='<%#Eval("resim") %>' runat="server" width="140" Height="210" />
                            <br />
                            </a>
                                <asp:Label Text='<%#Eval("kitap_adi") %>' runat="server" CssClass="isim" Font-Names="Arial" />
                        
                        </div>
                    </div>
                </div>
            </div>

        </ItemTemplate>

    </asp:DataList>


</asp:Content>

