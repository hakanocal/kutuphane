using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class odunc_istekleri : System.Web.UI.Page
{
    DateTime bugun;
    object kullanici;
    SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
    protected void istekguncelle()
    {
        //ÖDÜNÇ İSTEKLERİNİ LİSTELİYORUM
        //convert() ile tarih formatını istediğim biçime dönüştürerek listeliyorum.
        //üye bilgileri, ödünç bilgileri ve kitap bilgilerini tek bir sorguda birleştirerek Datalist'de Eval ile kullanabilmek için hazırladığım sorgu cümlesi:
        string sorgu = "select uyeler.tc, uyeler.ad, uyeler.soyad, uyeler.tel, uyeler.mail, odunc.durum, odunc.istek_tarihi, convert(varchar, odunc.istedigi_tarih, 104) as istedigi_tarih, kitaplar.kitap_adi, odunc_detay.ISBN, odunc_detay.detay_id from uyeler, odunc, kitaplar, odunc_detay where uyeler.tc = odunc.tc and kitaplar.ISBN = odunc_detay.ISBN and odunc.odunc_id = odunc_detay.odunc_id and durum = 'Ödünç alma isteği gönderildi'";
        SqlCommand cmd2 = new SqlCommand(sorgu, baglanti);
        baglanti.Open();
        SqlDataReader dr = cmd2.ExecuteReader();
        lstkitaplar.DataSource = dr;
        lstkitaplar.DataBind();
        baglanti.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        bugun = DateTime.Now;
        kullanici = Session["tc"];
        object yetki = Session["yetki"];

        if (kullanici == null || yetki.ToString() != "admin")
        {
            Response.Redirect("default.aspx");
        }
        else
        {
           istekguncelle();

        }

    }


    protected void lstkitaplar_ItemCommand(object source, DataListCommandEventArgs e)
    {
        bugun = DateTime.Now;
        //ÖDÜNÇ İSTEĞİNİ KABUL ET VE/VEYA KİTABI ÖDÜNÇ VER
        if (e.CommandName.Equals("odunc_ver"))
        {
            //Tarih kısmının boş geçilememsi ve geçmiş tarihlerin seçilebilmesini engelliyorum
            if (TextBox1.Text == "" || Convert.ToDateTime(TextBox1.Text) <= Convert.ToDateTime(bugun))
            {
                Response.Write("LÜTFEN GEÇERLİ BİR TESLİM ALMA TARİHİ SEÇİN!!!");
            }
            else
            {
                lstkitaplar.SelectedIndex = e.Item.ItemIndex;
                //"((Label)lstkitaplar.SelectedItem.FindControl("Label12")).Text"  İLE DATALISTDEN İŞLEM YAPILACAK ISBN'Yİ ALIYORUM. BİRAZDAN KİTAP STOKTA VAR MI YOK MU KONTROL EDECEĞİM :)
                string sorgu9 = "select * from kitaplar where ISBN='" + ((Label)lstkitaplar.SelectedItem.FindControl("Label12")).Text + "'";
                SqlCommand cmd9 = new SqlCommand(sorgu9, baglanti);
                baglanti.Open();
                SqlDataReader dr9 = cmd9.ExecuteReader();

                if (dr9.Read())
                {
                    //KİTAP STOKTAYSA KİTABI ÖDÜNÇ VER ARDINDAN İLGİLİ KİTABIN STOĞUNU 1 AZALT
                    if (Convert.ToInt32(dr9["stok"]) > 0)
                    {
                        baglanti.Close();
                        baglanti.Open();
                        string insertQuery4 = "update kitaplar set stok=stok-1 where ISBN=@ISBN";
                        SqlCommand cmd3 = new SqlCommand(insertQuery4, baglanti);
                        cmd3.Parameters.AddWithValue("@ISBN", ((Label)lstkitaplar.SelectedItem.FindControl("Label12")).Text);
                        cmd3.ExecuteNonQuery();
                        baglanti.Close();


                        baglanti.Open();
                        //Zaten "odunc" tablosunda kaydımız var. Alis_tarihi, teslim_tarihi, durumu güncelliyorum
                        string insertQuery = "update odunc set alis_tarihi=@alis_tarihi, teslim_tarihi=@teslim_tarihi, durum=@durum where durum = 'Ödünç alma isteği gönderildi' and odunc_id IN (select odunc_id from odunc_detay where ISBN= '" + ((Label)lstkitaplar.SelectedItem.FindControl("Label12")).Text + "' and detay_id='" + ((Label)lstkitaplar.SelectedItem.FindControl("Label15")).Text + "')";
                        SqlCommand cmd = new SqlCommand(insertQuery, baglanti);
                        cmd.Parameters.AddWithValue("@alis_tarihi", bugun);
                        cmd.Parameters.AddWithValue("@teslim_tarihi", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@durum", "Kitap hala üyede");
                        cmd.ExecuteNonQuery();
                        baglanti.Close();


                        Response.Write("ÖDÜNÇ VERME İŞLEMİ BAŞARILI");
                    }
                    else
                    {
                        baglanti.Close();
                        //Bu ne zaman stokta olacak? Bu kitabı Emanet verdiğimiz üyelerden; Teslim tarihi yaklaşan en yakın tarihi tarihi min() ile alıyorum. tarih formatını convert(varchar, column, 104) ile istediğim biçimde websayfamda gösteriyorum.
                        string sorgu1 = "select convert(varchar, min(teslim_tarihi), 104) as teslim_tarihi from odunc where odunc_id IN (select odunc_id from odunc_detay where ISBN='" + ((Label)lstkitaplar.SelectedItem.FindControl("Label12")).Text + "') and durum='Kitap hala üyede'";
                        SqlCommand cmd1 = new SqlCommand(sorgu1, baglanti);
                        baglanti.Open();
                        SqlDataReader dr1 = cmd1.ExecuteReader();

                        if (dr1.Read())
                        {
                            Response.Write("BU KİTAP STOKTA YOK!!! TAHMİNİ STOKTA OLACAĞI TARİH: " + dr1["teslim_tarihi"].ToString());
                            baglanti.Close();
                        }
                        else
                        {
                            baglanti.Close();
                            Response.Write("BU KİTAP STOKTA YOK!!!");
                        }
                    }
                }
                baglanti.Close();

                istekguncelle();
            }

        }
        //ÖDÜNÇ İSTEĞİNİ REDDET
        else if (e.CommandName.Equals("reddet"))
        {
            lstkitaplar.SelectedIndex = e.Item.ItemIndex;
            baglanti.Open();
            string insertQuery = "delete from odunc where durum = 'Ödünç alma isteği gönderildi' and odunc_id IN (select odunc_id from odunc_detay where ISBN= '" + ((Label)lstkitaplar.SelectedItem.FindControl("Label12")).Text + "' and detay_id='" + ((Label)lstkitaplar.SelectedItem.FindControl("Label15")).Text + "' )";
            SqlCommand cmd = new SqlCommand(insertQuery, baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            istekguncelle();
            istekguncelle();
        }
    }
}