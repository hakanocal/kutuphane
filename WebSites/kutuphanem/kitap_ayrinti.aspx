<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="kitap_ayrinti.aspx.cs" Inherits="kitap_ayrinti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Text="KİTAP BİLGİLERİ"></asp:Label>

    <br />
    <br />

    <p>
&nbsp;
        <%-- AŞAĞIDAKİ ARAÇLARIN VISIBLE ÖZELLİĞİNİ DURUMA GÖRE(ADMİN,ÜYE,GİRİŞ YAPMAYAN KİŞİLER İÇİN) DEĞİŞTİRİYOR OLACAĞIM.  --%>
        <asp:Label ID="Label3" runat="server" Text="Ödünç alma isteği göndermek için giriş yapınız" CssClass="font1"></asp:Label>
       <asp:Label ID="Label4" runat="server" Text="Ödünç alma isteğiniz başarıyla alındı" CssClass="font2"></asp:Label>
        <asp:Button ID="Button7" runat="server" Cssclass="button4" OnClick="Button7_Click" BackColor="#f62b2b" ForeColor="White" Text="İPTAL" />
        <asp:Label ID="Label5" runat="server" Text="Şu Tarihte Ödünç almak istiyorum: "></asp:Label>
        <asp:TextBox ID="TextBox12" runat="server" CssClass="TextBox" TextMode="Date"></asp:TextBox>  
           <br />
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="TextBox">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label13" runat="server" Text="Adet almak istiyorum"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button6" runat="server" Cssclass="button5" OnClick="Button6_Click" Text="ÖDÜNÇ ALMA İSTEĞİ GÖNDER" /> 
        <asp:Button ID="Button1" runat="server" Cssclass="button5" OnClick="Button1_Click" Text="ÖDÜNÇ VER" />

        <asp:Button ID="Button2" runat="server" Cssclass="button4" OnClick="Button2_Click" BackColor="#f62b2b" ForeColor="White" Text="KİTABI DÜZENLE/SİL" />
          
    </p>
   <br />

    <%-- KİTAP ÖDÜNÇ VER PANELİ --%>
    <asp:Panel ID="Panel1" runat="server" Visible="False" CssClass="oduncpanel">
        
        <br />
    <div class="oduncverbaslik">
        <h5>KİTAP ÖDÜNÇ VER</h5>
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
            <td> Teslim Etme Tar.</td>
            <td> <asp:TextBox ID="TextBox1" runat="server"  CssClass="TextBox" Enabled="False" Width="230px"></asp:TextBox> </td>
        </tr>
        <tr> 
            <td> Teslim Alma Tar.</td>
            <td> <asp:TextBox ID="TextBox8" runat="server"  CssClass="TextBox" TextMode="Date" Width="230px"></asp:TextBox> </td>
        </tr>

    

        <tr> 
            <td colspan ="2">    
                <br />
                <asp:Button ID="Button4" runat="server" Text="İPTAL" Cssclass="button1" OnClick="Button4_Click" />
                &nbsp;
                <asp:Button ID="Button5" runat="server" Text="ÖDÜNÇ VER" OnClick="Button5_Click" Cssclass="button1"/>
                <br />
                <asp:LinkButton ID="lblDurum" runat="server" CssClass="imjusttext" OnClick="LinkButton1_Click" ForeColor="Red" Visible="False">LinkButton </asp:LinkButton>
            </td>
        </tr>


    </table>
    </asp:Panel>
    
    <%-- KİTAP ÖDÜNÇ VERMEK İÇİN ÜYE SEÇMEMİZE OLANAK SAĞLAYAN GRİDVİEW --%>
<asp:GridView ID="GridView1" runat="server" cssclass="GridMain" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="tc" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="tc" HeaderText="tc" ReadOnly="True" SortExpression="tc" />
        <asp:BoundField DataField="ad" HeaderText="ad" SortExpression="ad" />
        <asp:BoundField DataField="soyad" HeaderText="soyad" SortExpression="soyad" />
        <asp:BoundField DataField="tel" HeaderText="tel" SortExpression="tel" />
        <asp:BoundField DataField="mail" HeaderText="mail" SortExpression="mail" />
    </Columns>
    <FooterStyle BackColor="#CCCCCC" />
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#2b62d2" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#808080" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#383838" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:kutuphaneConnectionString %>" SelectCommand="SELECT [tc], [ad], [soyad], [tel], [mail] FROM [uyeler]"></asp:SqlDataSource>

    




    
    <br />

    

    <%-- KİTAP DÜZENLE,SİL İŞLEMLERİNİ GERÇEKLEŞTİRMEK İÇİN KULLANDIĞIM DATALIST. SADECE ADMINLER ERİŞEBİLECEK --%>
    <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" Visible="False">
        <EditItemTemplate>
      <div class="card-wrapper"> 
                <div class="row">
                    <div class="column">
                        <div class="card2">
                            <table>
                                <tr>
                                    <td> ISBN:</td>
                                    <td>             <asp:Label ID="Label11" runat="server" Text='<%# Eval("ISBN") %>'></asp:Label> </td> 
                                </tr>
                                <tr>
                                    <td> KİTAP ADI:</td>
                                    <td>             <asp:TextBox ID="TextBox13" runat="server" CssClass="TextBox" Text='<%# Eval("kitap_adi") %>'></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td> Yazar ad:</td>
                                    <td>             <asp:TextBox ID="TextBox2" runat="server" CssClass="TextBox" Text='<%# Eval("ad") %>'></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td> Yazar soyad:</td>
                                    <td>             <asp:TextBox ID="TextBox3" runat="server" CssClass="TextBox" Text='<%# Eval("soyad") %>'></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td> Yayın Evi:</td>
                                    <td>             <asp:TextBox ID="TextBox4" runat="server" CssClass="TextBox" Text='<%# Eval("yayin_evi_ad") %>'></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td> Yayın Tarihi:</td>
                                    <td>             <asp:TextBox ID="TextBox5" runat="server" CssClass="TextBox" Text='<%# Eval("yayin_tarihi") %>'></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td> Sayfa Sayısı:</td>
                                    <td>             <asp:TextBox ID="TextBox6" runat="server" CssClass="TextBox" Text='<%# Eval("sayfa_sayisi") %>'></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td> Türü:</td>
                                    <td>             <asp:TextBox ID="TextBox7" runat="server" CssClass="TextBox" Text='<%# Eval("tur_adi") %>'></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td> Stok:</td>
                                    <td>             <asp:TextBox ID="TextBox9" runat="server" CssClass="TextBox" Text='<%# Eval("stok") %>'></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="Button14" runat="server" BackColor="#f62b2b" CommandName="update" Cssclass="button4" ForeColor="White"  Text="Güncelle" />
                                        <asp:Button ID="Button15" runat="server" BackColor="#f62b2b" CommandName="cancel" Cssclass="button4" ForeColor="White"  Text="İPTAL" />
                                    </td>
                                </tr>

                            </table>
          

            
                     
                            
                            
                            
                            
                        </div>
                    </div>
                </div>
      </div>
         </EditItemTemplate>
        <ItemTemplate>
              <div class="card-wrapper"> 
                <div class="row">
                    <div class="column">
                        <div class="card2">
                            <table>
                            <tr>
                                <td> ISBN: </td>
                                <td> <asp:Label ID="Label12" runat="server" Text='<%#Eval("ISBN")%>'></asp:Label>  </td>
                            </tr>
                            <tr>
                                <td>  Kitap Adı: </td>
                                <td>  <%#Eval("kitap_adi")%> </td>
                            </tr>
                            <tr>
                                <td>  Yazar Ad:   </td>
                                <td> <%#Eval("ad")%></td>
                            </tr>
                            <tr>
                                <td>  Yazar Soyad:  </td>
                                <td> <%#Eval("soyad")%> </td>
                            </tr>
                            <tr>
                                <td> Yayın Evi:    </td>
                                <td> <%#Eval("yayin_evi_ad")%> </td>
                            </tr>
                            <tr>
                                <td>  Yayın Tarihi:  </td>
                                <td> <%#Eval("yayin_tarihi")%></td>
                            </tr> 
                            <tr>
                                <td>  Sayfa Sayısı:  </td>
                                <td> <%#Eval("sayfa_sayisi")%></td>
                            </tr> 
                                <tr>
                                <td>  Türü:  </td>
                                <td> <%#Eval("tur_adi")%></td>
                            </tr>
                                <tr>
                                <td>  Stok:  </td>
                                <td> <%#Eval("stok")%></td>
                            </tr>
                            <tr>
                                    <td colspan="2"> 
                                    <asp:Button ID="Button12" runat="server" BackColor="#f62b2b" CommandName="edit" Cssclass="button4" ForeColor="White"  Text="KİTABI DÜZENLE" />
                                    <asp:Button ID="Button13" runat="server" BackColor="#f62b2b" CommandName="delete" Cssclass="button4" ForeColor="White"  Text="KİTABI TAMAMEN SİL" />
                                    </td>
                            </tr>
                        </table>
                        </div>
                    </div>
                </div>
            </div>
       </ItemTemplate>
    </asp:DataList>

    


    <br />

 <%-- KİTAP RESMİ VE KİTAP AYRINTILARININ YER ALDIĞI KISIM HERKES ERİŞEBİLİR --%>
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
  


    </asp:Content>

