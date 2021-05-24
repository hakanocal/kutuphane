<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="emanet.aspx.cs" Inherits="emanet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1> EMANETLER </h1> 
    <br />
    <%-- EMANETLERİN LİSTELENDİĞİ DATALIST YAPISI--%>
    <asp:DataList ID="lstkitaplar" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" >
        <ItemTemplate>

            <div class="card-wrapper"> 
                <div class="row">
                    <div class="column">
                        <div class="card">
                            <a href="emanet_ayrinti.aspx?kitapISBN=<%#Eval("ISBN") %>">
                                <asp:Image ID="Image1" CssClass="img" ImageUrl='<%#Eval("resim") %>' runat="server" width="140" Height="210" />
                            <br />
                            </a>
                                <asp:Label ID="Label1" Text='<%#Eval("kitap_adi") %>' runat="server" CssClass="isim" Font-Names="Arial" />
                        </div>
                    </div>
                </div>
            </div>

        </ItemTemplate>

    </asp:DataList>

</asp:Content>