using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mybooks_ayrinti : System.Web.UI.Page
{
    SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
    string dr_ISBN;
    string sorgu2, sorgu3, sorgu4, sorgu5;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string ISBN = Request.QueryString["kitapISBN"];
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
        string sorgu = "select * from kitaplar where ISBN=@ISBN";


        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
        cmd.Parameters.AddWithValue("@ISBN", ISBN);
        baglanti.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            imgkitap.ImageUrl = dr["resim"].ToString();
            lblISBN.Text = ": " + dr["ISBN"].ToString();
            dr_ISBN = dr["ISBN"].ToString();
            lblkitapadi.Text = ": " + dr["kitap_adi"].ToString();
            lblyayintarihi.Text = ": " + dr["yayin_tarihi"].ToString();
            lblsayfasayisi.Text = ": " + dr["sayfa_sayisi"].ToString();
            lblturu.Text = ": " + dr["tur_id"].ToString();
            lblstok.Text = ": " + dr["stok"].ToString();
            sorgu2 = "select ad, soyad from yazarlar where yazar_id = '" + dr["yazar_id"].ToString() + "'";
            sorgu3 = "select yayin_evi_ad from yayinevi where yayinevi_id = '" + dr["yayinevi_id"].ToString() + "'";
            sorgu4 = "select tur_adi from turler where tur_id = '" + dr["tur_id"].ToString() + "'";
            //Convert() ile Veritabanındaki tarih formatını istediğim formata dönüştürüyorum. (gg/aa/yyyy)
            sorgu5 = "select convert(varchar, alis_tarihi, 104), convert(varchar, teslim_tarihi, 104)  from odunc where odunc_id IN (select odunc_id from odunc_detay where ISBN = '" + dr["ISBN"].ToString() + "') and tc='" + Session["tc"] + "'";
        }
        baglanti.Close();


        // yazar bilgilerinin çekilmesi
        //
        SqlCommand cmd2 = new SqlCommand(sorgu2, baglanti);
        baglanti.Open();
        SqlDataReader dr2 = cmd2.ExecuteReader();
        if (dr2.Read())
        {
            lblyazar.Text = ": " + dr2["ad"].ToString();
            Label2.Text = ": " + dr2["soyad"].ToString();
        }
        baglanti.Close();
        //


        // yayın evi bilgilerinin çekilmesi
        //
        SqlCommand cmd3 = new SqlCommand(sorgu3, baglanti);
        baglanti.Open();
        SqlDataReader dr3 = cmd3.ExecuteReader();
        if (dr3.Read())
        {
            lblyayinevi.Text = ": " + dr3["yayin_evi_ad"].ToString();
        }
        baglanti.Close();
        //


        // Tür bilgilerinin çekilmesi
        //
        SqlCommand cmd4 = new SqlCommand(sorgu4, baglanti);
        baglanti.Open();
        SqlDataReader dr4 = cmd4.ExecuteReader();
        if (dr4.Read())
        {
            lblturu.Text = ": " + dr4["tur_adi"].ToString();
        }
        baglanti.Close();


        //
        // Kitap Alış tarihi bilgilerinin çekilmesi
        //
        SqlCommand cmd5 = new SqlCommand(sorgu5, baglanti);
        baglanti.Open();
        SqlDataReader dr5 = cmd5.ExecuteReader();
        if (dr5.Read())
        {
            //çalıştırdığım sorgu sonucunda alis_tarihi ve teslim_tarihi hücrelerine erişiyorum. "no column name" olduğu için index numarasına göre alis_tarihi ve teslim_tarihini alıyorum. Sorgu cümlesinde "as alis_tarihi" kullanarak sütun isimlendirmesi yapabilirdim.
            Label5.Text = ": " + dr5[0].ToString();
            Label4.Text = ": " + dr5[1].ToString();
        }
        baglanti.Close();
        //

        object kullanici = Session["tc"];
        object yetki = Session["yetki"];

        if (kullanici == null)
        {
            Response.Redirect("default.aspx");
        }
        else
        {

        }
    }
}