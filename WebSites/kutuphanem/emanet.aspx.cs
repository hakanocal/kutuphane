using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class emanet : System.Web.UI.Page
{
    SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
    //EMANET KİTAPLAR DATALIST DOLDURMA KODLARI
    protected void kitapguncelle()
    {
        //AŞAĞIDAKİ SORGUYLA durum='Kitap hala üyede' OLAN KİTAPLARI ALIYORUM VE ORDER BY ASC İLE A-Z SIRALAMA YAPIYORUM
        string sorgu = "select * from kitaplar where ISBN IN (select ISBN from odunc_detay where odunc_id IN (select odunc_id from odunc where durum='Kitap hala üyede'))order by kitap_adi ASC";
        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
        baglanti.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        lstkitaplar.DataSource = dr;
        lstkitaplar.DataBind();
        baglanti.Close();
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        //SAYFA İLK YÜKLENDİĞİNDE SESSION İLE TC VE YETKIYI ALIYORUM
        object kullanici = Session["tc"];
        object yetki = Session["yetki"];

        //SADECE ADMINLERIN EMANET SAYFASINA ERİŞEBİLMESİ İÇİN KOŞUL YAPISI:
        if (kullanici == null || yetki.ToString() != "admin")
        {
            Response.Redirect("default.aspx");
        }
        else
        {
            kitapguncelle();
        }
    }
}