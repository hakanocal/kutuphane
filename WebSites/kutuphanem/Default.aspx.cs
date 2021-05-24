using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class kitap : System.Web.UI.Page
{
    //Birden fazla fonksiyon içerisinde kullanmak için bazı değişkenleri class altında tanımladım.
    string resim, resim2;
    SqlCommand komut = new SqlCommand();
    SqlCommand yazar = new SqlCommand();
    SqlCommand yayinevi = new SqlCommand();
    SqlCommand tur = new SqlCommand();
    //Data Reader ile aldığım değerleri tutuyorum.
    int dr_yazar_id, dr_yayinevi_id, dr_tur_id;

    SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);


    //Datalist doldurma kodlarım. Birden fazla noktada kullanmak için fonksiyon oluşturdum.
    protected void kitapguncelle()
    {
        string sorgu = "select * from kitaplar order by kitap_adi ASC";
        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
        baglanti.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        lstkitaplar.DataSource = dr;
        lstkitaplar.DataBind();
        baglanti.Close();
    }

    //SONRASINDA KİTAP EKLERKEN BERABERİNDE YAZARI DA EKLEMİŞ OLACAĞIZ. EKLENEN YAZARIN ID DEĞERİNE ULAŞMAK İÇİN HAZIRLADIĞIM SORGU CÜMLESİ:
    public void yazarsorgu()
    {
        string sorgu = "select yazar_id from yazarlar where ad = '" + TextBox3.Text + "' and soyad = '" + TextBox9.Text + "'";
        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
        baglanti.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            dr_yazar_id = Convert.ToInt32(dr["yazar_id"]);

        }
        baglanti.Close();
    }
    //SONRASINDA KİTAP EKLERKEN BERABERİNDE YAYIN EVİ DE EKLEMİŞ OLACAĞIZ. EKLENEN YAYINEVİ ID DEĞERİNE ULAŞMAK İÇİN HAZIRLADIĞIM SORGU CÜMLESİ:
    public void yayinevisorgu()
    {
        string sorgu = "select yayinevi_id from yayinevi where yayin_evi_ad = '" + TextBox4.Text + "'";
        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
        baglanti.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            dr_yayinevi_id = Convert.ToInt32(dr["yayinevi_id"]);

        }
        baglanti.Close();
    }


    //SONRASINDA KİTAP EKLERKEN BERABERİNDE TÜR DE EKLEMİŞ OLACAĞIZ. EKLENEN TÜR ID DEĞERİNE ULAŞMAK İÇİN HAZIRLADIĞIM SORGU CÜMLESİ:

    public void tursorgu()
    {
        //ID'si en yüksek olan kayıt mantıken en son eklenmiş kayıtdır. dolayısıyla max(tur_id) yapmak veritabanını yormamak açısından daha mantıklı olabilirdi. (Aynı şey yayinevisorgu() ve yazarsorgu() fonksiyonları içerisindeki sorgu cümleleri için de geçerli)
        string sorgu = "select tur_id from turler where tur_adi = '" + TextBox7.Text + "'";
        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
        baglanti.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            dr_tur_id = Convert.ToInt32(dr["tur_id"]);

        }
        baglanti.Close();
    }





    //Kitap Ekleme Formu Temizleme fonksiyonu
    private void temizle(){
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
    }

    //Sayfa yüklendiğinde çalışacak olan kodlarım
    protected void Page_Load(object sender, EventArgs e)
    {

        //DataList Doldurma fonksiyonumu çağırıyorum
        kitapguncelle();

        //Session ile giriş yapan kullanıcının yetkisini ve TC'sini alıyorum
        object yetki = Session["yetki"];
        object tc = Session["tc"];

        //Eğer herhangi bir giriş yapılmadıysa Kitap Ekle panelini gizliyorum
        
        if (tc == null)
        {
            Panel1.Visible = false;
        }
        //Eğer admin giriş yaptıysa Kitap Ekle Panelini açıyorum
        else if (yetki.ToString() == "admin")
        {
            Panel1.Visible = true;
        }
        //Üye girişi sağlandığında Bu ELSE'in içine girecek. Üye girişi yaptığında Kitap Ekle panelini gizliyorum
        else
        {
            Panel1.Visible = false;
        }
    }

    //KİTAP KAYDETME BUTONU KODLARIM
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            //EĞER BOŞ ALAN BIRAKILDIYSA UYARI VERİLMESİNİ SAĞLIYORUM
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "" || TextBox7.Text == "")
            {
                lblDurum.Text = "Tüm alanları doldurunuz";
                lblDurum.Visible = true;
            }
            //KİTAP RESMİNİN SEÇİLİP SEÇİLMEDİĞİNİ KONTROL EDİYORUM. KİTAP RESMİ SEÇİLDİYSE AŞAĞIDAKİ KODLARI ÇALIŞTIR
            else if (FileUpload1.HasFile)
            {
                try
                {
                    //SADECE JPEG, PNG, JPG FORMATLARINDA RESİM YÜKLENEBİLMESİ İÇİN YÜKLENEN RESMİN FORMATINI KONTROL EDİYORUM
                    if (FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/png" || FileUpload1.PostedFile.ContentType == "image/jpg")
                    {
                        //ÇOK BÜYÜK RESİM DOSYALARININ YÜKLENEBİLMESİNİ ÖNLEMEK İÇİN DOSYA BOYUTUNU KONTROL EDİYORUM
                        if (FileUpload1.PostedFile.ContentLength < 307200)
                        {
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            if (filename != "")
                            {
                                //Kitap Resmi yüklediğimizde eğer kitap resmi adı veritabanında varsa kitaplar listelenirken uyuşmazlık yaşanacak. Bunun önüne geçmek için Guid Metodu ile KOD üretiyorum ve yüklenen resmin adını bu kodu veriyorum.
                                Guid G = Guid.NewGuid();
                                //ÖRNEK: cfbb2d98-e4b6-4044-aa6a-f7876776b580-kitap-4636030e-103f-4cb1-8403-6d62696cd95f-kitap-ucurtma.jpg
                                string yol = G + "-kitap-" + FileUpload1.FileName;
                                FileUpload1.SaveAs(Server.MapPath("~/images/kitaplar/") + yol);
                                resim = "~/images/kitaplar/" + yol;
                                baglanti.Open();
                                //bağlantılarımı tanımlıyorum
                                komut.Connection = baglanti;
                                yazar.Connection = baglanti;
                                yayinevi.Connection = baglanti;
                                tur.Connection = baglanti;
                                //Yazar, yayınevi, ve tür Ekleme komutlarını tanımlıyorum
                                yazar.CommandText = "insert into yazarlar(ad, soyad) values ('" + TextBox3.Text + "', '" + TextBox9.Text + "')";
                                yayinevi.CommandText = "insert into yayinevi(yayin_evi_ad) values('" + TextBox4.Text + "')";
                                tur.CommandText = "insert into turler(tur_adi) values('" + TextBox7.Text + "')";
                                //Yazar, yayınevi, ve tür komutlarımı çalıştırıyorum
                                yazar.ExecuteNonQuery();
                                yayinevi.ExecuteNonQuery();
                                tur.ExecuteNonQuery();

                                baglanti.Close();
                                //Eklenen Yazar, Yayınevi, ve Tür'lerin ID'sini aşağıdaki sorgularla alıyorum.
                                yazarsorgu();
                                yayinevisorgu();
                                tursorgu();
                                //Aldığım Yazar, Yayınevi, ve Tür'lerin ID'sini kitaplar tablosuna kayıt yaparken kullanıyorum
                                baglanti.Open();
                                komut.CommandText = "insert into kitaplar(ISBN, kitap_adi, yazar_id, yayinevi_id, yayin_tarihi, sayfa_sayisi, tur_id, stok, resim) values ('" + TextBox1.Text + "', '" + TextBox2.Text + "' , '" + dr_yazar_id + "','" + dr_yayinevi_id + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + dr_tur_id + "','" + TextBox8.Text + "','" + resim + "')";
                                komut.ExecuteNonQuery();
                                baglanti.Close();
                                Response.Write("KİTAP KAYDI BAŞARILI");
                                temizle();
                                kitapguncelle();
                            }
                        }
                        //Durum kısmına hata mesajımı yazdırıyorum.
                        else
                            lblDurum.Visible = true;
                        lblDurum.Text = "Dosya boyutu 300 KB'dan düşük olmalı!";
                    }
                    //Durum kısmına hata mesajımı yazdırıyorum.
                    else
                        lblDurum.Visible = true;
                    lblDurum.Text = "Sadece JPEG ve PNG formatı kabul edilir.";
                }
                //Durum kısmına hata mesajımı yazdırıyorum.
                catch (Exception ex)
                {
                    lblDurum.Visible = true;
                    lblDurum.Text = "Dosya yüklenemedi: " + ex.Message;
                }
            }
            //KİTAP RESMİNİN SEÇİLİP SEÇİLMEDİĞİNİ KONTROL EDİYORUM. KİTAP RESMİ "SEÇİLMEDİYSE" AŞAĞIDAKİ KODLARI ÇALIŞTIR
            //RESİM SEÇİLMEDİYSE KİTABIN RESMİ "noimage.jpg(RESİM YOK RESMİ)" OLARAK ATANACAK. 
            else
            {
                baglanti.Open();
                //bağlantılarımı tanımlıyorum
                komut.Connection = baglanti;
                yazar.Connection = baglanti;
                yayinevi.Connection = baglanti;
                tur.Connection = baglanti;

                //Yazar, yayınevi, ve tür Ekleme komutlarını tanımlıyorum
                resim2 = "~/images/kitaplar/noimage.jpg";
                yazar.CommandText = "insert into yazarlar(ad, soyad) values ('" + TextBox3.Text + "', '" + TextBox9.Text + "')";
                yayinevi.CommandText = "insert into yayinevi(yayin_evi_ad) values('" + TextBox4.Text + "')";
                tur.CommandText = "insert into turler(tur_adi) values('" + TextBox7.Text + "')";
                //İlk önce yazarı, yayınevini ve türü kaydediyorum. Birazdan Kitabı kaydedeceğim
                yazar.ExecuteNonQuery();
                yayinevi.ExecuteNonQuery();
                tur.ExecuteNonQuery();

                baglanti.Close();

                //Eklenen Yazar, Yayınevi, ve Tür'lerin ID'sini aşağıdaki sorgularla alıyorum.
                yazarsorgu();
                yayinevisorgu();
                tursorgu();

                //Yukarıdaki sorgularla aldığım Yazar, Yayınevi, ve Tür'lerin ID'sini kitaplar tablosuna kayıt yaparken kullanıyorum. (dr_yazar_id, dr_yayinevi_id, dr_tur_id)
                baglanti.Open();
                komut.CommandText = "insert into kitaplar(ISBN, kitap_adi, yazar_id, yayinevi_id, yayin_tarihi, sayfa_sayisi, tur_id, stok, resim) values ('" + TextBox1.Text + "', '" + TextBox2.Text + "' , '" + dr_yazar_id + "','" + dr_yayinevi_id + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + dr_tur_id + "','" + TextBox8.Text + "','" + resim2 + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                Response.Write("KİTAP KAYDI BAŞARILI");
                temizle();
                kitapguncelle();
            }
        }
        catch (Exception ex)
        {
            Response.Write("Bir Hatayla Karşılaşıldı. Lütfen Son İşlemleriniz Kontrol ediniz. HATA MESAJI:" + ex.Message);
        }

        }
    protected void Button1_Click(object sender, EventArgs e)
    {
        temizle();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        lblDurum.Visible = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect(Request.RawUrl);

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }

    //KİTAP ARAMA BUTONU
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //LIKE İLE TEXTBOX'A YAZILAN DEĞERİ SORGULUYORUM VE DATALIST'TE LİSTELİYORUM
        string sorgu = "select * from kitaplar where kitap_adi like '%' +@kitapadi+ '%' ";
        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
        cmd.Parameters.AddWithValue("@kitapadi", TextBox10.Text);
        baglanti.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        lstkitaplar.DataSource = dr;
        lstkitaplar.DataBind();
        baglanti.Close();
    }
}