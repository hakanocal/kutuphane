<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="mybooks_ayrinti.aspx.cs" Inherits="mybooks_ayrinti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1> ÖDÜNÇ ALDIĞIM KİTAPLAR </h1>
    <asp:Label ID="Label3" runat="server" cssclass="oduncveraltbaslik" Text="Ödünç Ayrıntı:" Font-Bold="True" Font-Names="Arial"></asp:Label>
    <br />

    <asp:Label ID="Label1" runat="server" Text="Ödünç Aldığım Tarih: "></asp:Label>     <asp:Label ID="Label5" runat="server" Text="Label" Font-Bold="True"></asp:Label> 
    <br />

    <asp:Label ID="Label6" runat="server" Text="Teslim Etmem Gereken Tarih: "></asp:Label>    <asp:Label ID="Label4" runat="server" Text="Label" Font-Bold="True" ForeColor="#CC0000"></asp:Label>    

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

</asp:Content>

