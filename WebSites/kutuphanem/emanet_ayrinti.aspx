<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="emanet_ayrinti.aspx.cs" Inherits="emanet_ayrinti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Text="EMANET BİLGİLERİ"></asp:Label>
    <br />
    <br />
    <%-- "KITABI GERI TESLIM AL" PANELI BAŞLANGIÇ--%>
    <%-- BU PANELI SADECE ADMINLERIN GOREBİLMESİ İÇİN PANEL ARACINI KULLANDIM. YETKIYE GORE VISIBLE ÖZELLİĞİNİ DEĞİŞTİRİYOR OLACAĞIM --%>
    <asp:Panel ID="Panel1" runat="server" CssClass="oduncpanel" Visible="False">
        <br />
    <div class="oduncverbaslik">
        <h5>KİTABI GERİ TESLİM AL</h5>
    </div>
    <table class="kitapekle"  >

        <tr> 
            <td class="oduncveraltbaslik" colspan="2"> Ödünç Alan:</td>
        </tr>
        <tr> 
            <td> TC:</td>
            <td> <asp:Label ID="Label6" runat="server" Text=""></asp:Label> </td>
        </tr>
        <tr> 
            <td> Ad:</td>
            <td> <asp:Label ID="Label7" runat="server" Text=""></asp:Label> </td>
        </tr>
        <tr> 
            <td> Soyad:</td>
            <td> <asp:Label ID="Label8" runat="server" Text=""></asp:Label> </td>
        </tr>
        <tr> 
            <td> Tel:</td>
            <td> <asp:Label ID="Label9" runat="server" Text=""></asp:Label> </td>
        </tr>
        <tr> 
            <td> Mail:</td>
            <td> <asp:Label ID="Label10" runat="server" Text=""></asp:Label> </td>
        </tr>
        <tr> 
            <td> Aldığı Tarih:</td>
            <td> <asp:TextBox ID="TextBox1" runat="server"  CssClass="TextBox" Enabled="False" Width="230px"></asp:TextBox> </td>
        </tr>
        <tr> 
            <td> Teslim Etmesi Gereken Tar.</td>
            <td> <asp:TextBox ID="TextBox8" runat="server"  CssClass="TextBox" Width="230px" Enabled="False"></asp:TextBox> </td>
        </tr>
        <tr> 
            <td> Teslim Ettiği Tar.</td>
            <td> <asp:TextBox ID="TextBox2" runat="server"  CssClass="TextBox" Width="230px"></asp:TextBox> </td>
        </tr>
    

        <tr> 
            <td colspan ="2">    
                <br />
                <asp:Button ID="Button4" runat="server" Text="İPTAL" Cssclass="button1" OnClick="Button4_Click" />
                &nbsp;
                <asp:Button ID="Button5" runat="server" Text="GERİ TESLİM AL" OnClick="Button5_Click" Cssclass="button1" Width="130px"/>
                <br />
                <asp:LinkButton ID="lblDurum" runat="server" CssClass="imjusttext" OnClick="LinkButton1_Click" ForeColor="Red" Visible="False">LinkButton </asp:LinkButton>
            </td>
        </tr>


    </table>
    </asp:Panel>
     <%-- "KITABI GERI TESLIM AL" PANELI BİTİŞ--%>


    <asp:Label ID="Label3" runat="server" cssclass="oduncveraltbaslik" Text="Bu kitabı ödünç alan kişiler:" Font-Bold="True" Font-Names="Arial"></asp:Label>
    <br />

     <%-- "KİTAP ÖDÜNÇ ALANLARI LİSTELEDİĞİM GRIDVIEW--%>

    <asp:GridView ID="GridView1" runat="server" autogeneratecolumns="False" cssclass="GridMain"  CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="tc"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >

            <%--  --%>

            <headerstyle cssclass="GridHeader" BackColor="#151515"> </headerstyle>

            <rowstyle cssclass="GridRow" BackColor="#1487ff"> </rowstyle>
            <selectedrowstyle cssclass="GridSelectedRow" BackColor="#C5BBAF" ForeColor="#333333"> </selectedrowstyle>


            <AlternatingRowStyle BackColor="#1487ff"  />
            <columns>
                <asp:CommandField ShowSelectButton="True" SelectText="İşlem Yap" />
            <asp:boundfield datafield="tc" headertext="tc" ReadOnly="True" SortExpression="tc"> </asp:boundfield>
            <asp:boundfield datafield="ad" headertext="ad" SortExpression="ad"> </asp:boundfield>
            <asp:boundfield datafield="soyad" headertext="soyad" SortExpression="soyad"> </asp:boundfield>
            <asp:boundfield datafield="tel" headertext="tel" SortExpression="tel"> </asp:boundfield>
            <asp:boundfield datafield="mail" headertext="mail" SortExpression="mail"> </asp:boundfield>
            <asp:boundfield datafield="alis_tarihi" headertext="Alış Tarihi" SortExpression="alis_tarihi"> </asp:boundfield>
            <asp:boundfield datafield="teslim_tarihi" headertext="Teslim Tar." ReadOnly="True" SortExpression="teslim_tarihi"> </asp:boundfield>
            <asp:boundfield datafield="detay_id" headertext="ID" ReadOnly="True" SortExpression="detay_id"> </asp:boundfield>

            </columns>


            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />

            <HeaderStyle />

            <PagerStyle BackColor="red" ForeColor="red" HorizontalAlign="Center" />

            <RowStyle />
            <SelectedRowStyle />


            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />

        </asp:GridView>





    <%-- KİTAP RESMİ VE KİTAP AYRINTILARINI GÖREBİLDİĞİMİZ KISIM --%>
    <div class="kitap-wrapper">

        <div class="kitap-sol">

             <asp:Image ID="imgkitap" ImageUrl="imageurl" runat="server" width="250" Height="380" />
        </div>
        <div class="kitap-sag">

            <table>
                <tr>
                    <td><b> ISBN </b></td>
                    <td>
                        <asp:Label ID="lblISBN" Text ="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><b>Kitap adı</b></td>
                    <td class="auto-style1">
                        <asp:Label ID="lblkitapadi" Text ="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><b>Yazar ad</b></td>
                    <td>
                        <asp:Label ID="lblyazar" Text ="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><b>Yazar soyad</b></td>
                    <td>
                        <asp:Label ID="Label2" Text ="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><b>Yayın Evi</b></td>
                    <td>
                        <asp:Label ID="lblyayinevi" Text ="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><b>Yayın Tarihi</b></td>
                    <td>
                        <asp:Label ID="lblyayintarihi" Text ="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><b>Sayfa Sayısı</b></td>
                    <td>
                        <asp:Label ID="lblsayfasayisi" Text ="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><b>Türü</b></td>
                    <td>
                        <asp:Label ID="lblturu" Text ="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><b>Stok</b></td>
                    <td>
                        <asp:Label ID="lblstok" Text ="text" runat="server" />
                    </td>
                </tr>
            </table>

        </div>
    </div>
    <br />
    <br />
</asp:Content>
