<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="odunc_istekleri.aspx.cs" Inherits="odunc_istekleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>ÖDÜNÇ İSTEKLERİ </h1>
    <p>&nbsp;</p>
    <p>
        <asp:Label ID="Label13" runat="server" Text="Kitabı geri teslim almak istediğiniz tarihi seçiniz:"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" CssClass="TextBox"></asp:TextBox> 

        <asp:DataList ID="lstkitaplar" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" OnItemCommand="lstkitaplar_ItemCommand" >
        <ItemTemplate>

            <div class="card-wrapper"> 
                <div class="row">
                    <div class="column">
                        <div class="card3">
                            <table>
                                <tr>
                                    <asp:LinkButton ID="Button1" runat="server" Text="ÖDÜNÇ VER" CommandName="odunc_ver" />              <br />
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="REDDET" ForeColor="red" CommandName="reddet" />

                                </tr>
                                <tr>
                                    <td> 
                                    <asp:Label ID="Label14" runat="server"  Text="Detay ID: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label15" Text='<%#Eval("detay_id") %>' runat="server" CssClass="isim" Font-Names="Arial" /><br />
                                   
                                    <asp:Label ID="Label9" runat="server" Text="Kitap: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label10" Text='<%#Eval("kitap_adi") %>' runat="server" CssClass="isim" Font-Names="Arial" /><br />
                                    <asp:Label ID="Label11" runat="server" Text="ISBN: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label12" Text='<%#Eval("ISBN") %>' runat="server" CssClass="isim" Font-Names="Arial" /><br />

                                    <asp:Label ID="Label7" runat="server" Text="Ad Soyad: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label8" Text='<%#Eval("ad").ToString() + " " +  Eval("soyad").ToString()%>' runat="server" CssClass="isim" Font-Names="Arial" /><br />
                                    <asp:Label ID="Label2" runat="server" Text="TC: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label1" Text='<%#Eval("tc") %>' runat="server" CssClass="isim" Font-Names="Arial" /><br />
                                    <asp:Label ID="Label3" runat="server" Text="İSTEK TARİHİ: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label4" Text='<%#Eval("istek_tarihi") %>' runat="server" CssClass="isim" Font-Names="Arial" /><br />
                                     <asp:Label ID="Label5" runat="server" Text="İSTEDİĞİ TARİH: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label6" Text='<%#Eval("istedigi_tarih") %>' runat="server" CssClass="isim" Font-Names="Arial" />
       
                                    </td>

                                </tr>
                            </table>
                        
                        </div>
                    </div>
                </div>
            </div>

        </ItemTemplate>

            <SelectedItemTemplate>
              <div class="card-wrapper"> 
                <div class="row">
                    <div class="column">
                        <div class="card3">
                            <table>
                                <tr>
                                    <asp:LinkButton ID="Button1" runat="server" Text="ÖDÜNÇ VER" CommandName="odunc_ver" />              <br />
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="REDDET" ForeColor="red" CommandName="reddet" />

                                    <td> 
                                    <asp:Label ID="Label14" runat="server"  Text="Detay ID: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label15" Text='<%#Eval("detay_id") %>' runat="server" CssClass="isim" Font-Names="Arial" /><br />
                                   
                                    <asp:Label ID="Label9" runat="server" Text="Kitap: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label10" Text='<%#Eval("kitap_adi") %>' runat="server" CssClass="isim" Font-Names="Arial" /><br />
                                    <asp:Label ID="Label11" runat="server" Text="ISBN: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label12" Text='<%#Eval("ISBN") %>' runat="server" CssClass="isim" Font-Names="Arial" /><br />

                                    <asp:Label ID="Label7" runat="server" Text="Ad Soyad: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label8" Text='<%#Eval("ad").ToString() + " " +  Eval("soyad").ToString()%>' runat="server" CssClass="isim" Font-Names="Arial" /><br />
                                    <asp:Label ID="Label2" runat="server" Text="TC: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label1" Text='<%#Eval("tc") %>' runat="server" CssClass="isim" Font-Names="Arial" /><br />
                                    <asp:Label ID="Label3" runat="server" Text="İSTEK TARİHİ: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label4" Text='<%#Eval("istek_tarihi") %>' runat="server" CssClass="isim" Font-Names="Arial" /><br />
                                     <asp:Label ID="Label5" runat="server" Text="İSTEDİĞİ TARİH: " Font-Bold="True"></asp:Label> 
                                    <asp:Label ID="Label6" Text='<%#Eval("istedigi_tarih") %>' runat="server" CssClass="isim" Font-Names="Arial" />
       
                                    </td>

                                </tr>
                            </table>
                           

                        
                        </div>
                    </div>
                </div>
            </div>

            </SelectedItemTemplate>

    </asp:DataList>

    </p>

</asp:Content>

