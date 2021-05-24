<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profil.aspx.cs" Inherits="profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <h1> PROFİL </h1> 
    <br />
  
    <br />
    <%-- KENDİ PROFİL BİLGİLERİMİ LİSTELEDİĞİM DATALIST --%>
    <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">
        <%-- EditItemTemplate etiketi ile PROFİL GÜNCELLEMESİ YAPTIĞIM ALAN --%>
        <EditItemTemplate>
      <div class="card-wrapper"> 
                <div class="row">
                    <div class="column">
                        <div class="card2">
                            <table>
                                <tr>
                                    <td> TC:</td>
                                    <td>             <asp:Label ID="Label2" runat="server" Text='<%# Eval("tc") %>'></asp:Label> </td> 
                                </tr>
                                <tr>
                                    <td> Ad:</td>
                                    <td>             <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBox" Text='<%# Eval("ad") %>'></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td> Soyad:</td>
                                    <td>             <asp:TextBox ID="TextBox2" runat="server" CssClass="TextBox" Text='<%# Eval("soyad") %>'></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td> Tel:</td>
                                    <td>             <asp:TextBox ID="TextBox3" runat="server" CssClass="TextBox" Text='<%# Eval("tel") %>'></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td> Mail:</td>
                                    <td>             <asp:TextBox ID="TextBox4" runat="server" CssClass="TextBox" Text='<%# Eval("mail") %>'></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td> Şifre:</td>
                                    <td>             <asp:TextBox ID="TextBox5" runat="server" CssClass="TextBox" Text='<%# Eval("sifre") %>'></asp:TextBox> </td>
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
        <%-- Profil bilgilerimi gösterdiğim alan --%>
        <ItemTemplate>
              <div class="card-wrapper"> 
                <div class="row">
                    <div class="column">
                        <div class="card2">
                            <table>
                            <tr>
                                <td> TC: </td>
                                <td> <asp:Label ID="Label1" runat="server" Text='<%#Eval("tc")%>'></asp:Label>  </td>
                            </tr>
                            <tr>
                                <td>  Ad: </td>
                                <td>  <%#Eval("ad")%> </td>
                            </tr>
                            <tr>
                                <td>  soyad:   </td>
                                <td> <%#Eval("soyad")%></td>
                            </tr>
                            <tr>
                                <td>  Tel:  </td>
                                <td> <%#Eval("tel")%> </td>
                            </tr>
                            <tr>
                                <td> Mail:    </td>
                                <td> <%#Eval("mail")%> </td>
                            </tr>
                            <tr>
                                <td>  şifre:  </td>
                                <td> <%#Eval("sifre")%></td>
                            </tr> 
                            <tr>
                                    <td colspan="2"> 
                                    <asp:Button ID="Button12" runat="server" BackColor="#f62b2b" CommandName="edit" Cssclass="button4" ForeColor="White"  Text="PROFİLİ DÜZENLE" />
                                    <asp:Button ID="Button13" runat="server" BackColor="#f62b2b" CommandName="delete" Cssclass="button4" ForeColor="White"  Text="HESABIMI TAMAMEN SİL" />
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
    <br />



</asp:Content>

