using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class kitap_ayrinti : System.Web.UI.Page
{
    int dr_stok;
    //Birden fazla noktada bu değerlere ulaşmak için bazı değişkenlerimi public class altında tanımlıyorum.
    DateTime bugun;
    SqlCommand komut = new SqlCommand();
    SqlCommand odunc_detay = new SqlCommand();
    SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);

    string sorgu2, sorgu3, sorgu4;

    int dr_odunc_id;
    SqlCommand yazar = new SqlCommand();
    SqlCommand yayinevi = new SqlCommand();
    SqlCommand tur = new SqlCommand();
    string dr_ISBN, dr_yazar_id, dr_yayinevi_id, dr_tur_id;


    //DATALIST'İ KİTAP BİLGİLERİYLE DOLDURUYORUM
    private void verigetir()
    {
        //DATALIST #EVAL İLE TÜR, YAZAR, YAYINEVİ GİBİ KİTABA AİT TÜM BİLGİLERE İLİŞKİLİ VERİTABANINDAN ULAŞMAK İÇİN TEK BİR SORGU İLE FARKLI TABLOLARDAN SÜTUNLARI BİRLEŞTİRİYORUM.
        SqlDataAdapter da = new SqlDataAdapter("select kitaplar.ISBN, kitaplar.kitap_adi, kitaplar.yayin_tarihi, kitaplar.sayfa_sayisi, kitaplar.stok, yazarlar.yazar_id, yazarlar.ad, yazarlar.soyad,  turler.tur_id, turler.tur_adi, yayinevi.yayinevi_id, yayinevi.yayin_evi_ad from kitaplar, turler, yayinevi, yazarlar where turler.tur_id=kitaplar.tur_id and yayinevi.yayinevi_id=kitaplar.yayinevi_id and yazarlar.yazar_id=kitaplar.yazar_id and ISBN='" + dr_ISBN + "'", baglanti);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataList1.DataSource = ds;
        DataList1.DataBind();
    }
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //Sayfam daha önceden yüklenmediyse:
        if (!IsPostBack)
        {
            GridView1.Visible = false;
            Button2.Visible = false;
        }

        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);

        object yetki = Session["yetki"];
        object tc = Session["tc"];




        bugun = DateTime.Now;
        TextBox1.Text = bugun.ToString("dd/MM/yyyy");


        string ISBN = Request.QueryString["kitapISBN"];
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
            dr_yazar_id = dr["yazar_id"].ToString();
            dr_yayinevi_id = dr["yayinevi_id"].ToString();
            dr_tur_id = dr["tur_id"].ToString();
            lblkitapadi.Text = ": " + dr["kitap_adi"].ToString();
            lblyayintarihi.Text = ": " + dr["yayin_tarihi"].ToString();
            lblsayfasayisi.Text = ": " + dr["sayfa_sayisi"].ToString();
            lblturu.Text = ": " + dr["tur_id"].ToString();
            lblstok.Text = ": " + dr["stok"].ToString();
            sorgu2 = "select ad, soyad from yazarlar where yazar_id = '" + dr["yazar_id"].ToString() + "'";
            sorgu3 = "select yayin_evi_ad from yayinevi where yayinevi_id = '" + dr["yayinevi_id"].ToString() + "'";
            sorgu4 = "select tur_adi from turler where tur_id = '" + dr["tur_id"].ToString() + "'";

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
            Label2.Text = ": " +  dr2["soyad"].ToString();

    
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


        // SESSİON DEĞERİNE GÖRE ITEMLERİN VISIBLE ÖZELLİĞİNİ DEĞİŞTİRİYORUM
        if (tc == null)
        {
            Button1.Visible = false;
            Button2.Visible = false;
            Button6.Visible = false;
            Label5.Visible = false;
            TextBox12.Visible = false;
            DropDownList1.Visible = false;
            Label13.Visible = false;
            GridView1.Visible = false;
            Label3.Visible = true;
            Button7.Visible = false;
            Label4.Visible = false;
        }
        else if (yetki.ToString() == "admin")
        {
            Button1.Visible = true;
            Button2.Visible = true;
            Button6.Visible = false;
            Label5.Visible = false;
            TextBox12.Visible = false;
            DropDownList1.Visible = false;
            Label13.Visible = false;
            Label3.Visible = false;
            Button7.Visible = false;
            Label4.Visible = false;
           
        }
        
        else
        {
            Button1.Visible = false;
            Button2.Visible = false;
            Button6.Visible = true;
            Label5.Visible = true;
            TextBox12.Visible = true;
            DropDownList1.Visible = true;
            Label13.Visible = true;
            Label3.Visible = false;
            GridView1.Visible = false;
            // ÖDÜNÇ İSTEĞİ KONTROLÜ

            string tc2 = tc.ToString();
            string sorgu5 = "select * from odunc_detay where odunc_id IN (select odunc_id from odunc where tc = @tc2 and durum='Ödünç alma isteği gönderildi')";

            
            
            SqlCommand cmd5 = new SqlCommand(sorgu5, baglanti);
            cmd5.Parameters.AddWithValue("@tc2", tc2);

            baglanti.Open();
            SqlDataReader dr5 = cmd5.ExecuteReader();

            if (dr5.HasRows && dr5.Read())
            {
                //Zaten ödünç alma isteği gönderdiysek tekrar gönderememek için visible özelliklerini ayarlıyorum
                if (dr_ISBN.ToString() == dr5["ISBN"].ToString())
                {
                    Button6.Visible = false;
                    Label5.Visible = false;
                    TextBox12.Visible = false;
                    DropDownList1.Visible = false;
                    Label13.Visible = false;
                    Button7.Visible = true;
                    Label4.Visible = true;
                    Button4.Visible = true;
                }
                else
                {
                    baglanti.Close();
                    Button6.Visible = true;
                    Label5.Visible = true;
                    TextBox12.Visible = true;
                    DropDownList1.Visible = true;
                    Label13.Visible = true;
                    Button7.Visible = false;

                    Label4.Visible = false;
                    Button4.Visible = false;
                }
            }
            else
            {
                baglanti.Close();
                Button6.Visible = true;
                Label5.Visible = true;
                TextBox12.Visible = true;
                DropDownList1.Visible = true;
                Label13.Visible = true;
                Button7.Visible = false;
                Label4.Visible = false;
                Button4.Visible = false;
            }
            baglanti.Close();
        }
        if (!IsPostBack)
        {
            verigetir();
        }

    }
    //ÖDÜNÇ VER BUTONU
    protected void Button1_Click(object sender, EventArgs e)
    {
        //ÖDÜNÇ VEREBİLMEK İÇİN GRİDVİEW'İ AÇIYOR. HALİHAZIRDA GRİDVİEW AÇIKSA KAPATIYOR
        if (GridView1.Visible == false){
            GridView1.Visible = true;
        }
        else if (GridView1.Visible == true){
            GridView1.Visible = false;
        }



        if (Panel1.Visible == true)
        {
            Panel1.Visible = false;
        }
    }


    //KİTABI DÜZENLE/SİL BUTONU
    protected void Button2_Click(object sender, EventArgs e)
    {
        //DATALIST İLE KİTAP DÜZENLEME VE SİLME İŞLEMLERİNİ YAPABİLMEK İÇİN DATALIST VISIBLE ÖZELLİĞİNİ DEĞİŞTİRİYORUM
        if (DataList1.Visible == false)
        {
            DataList1.Visible = true;
        }
        else
        {
            DataList1.Visible = false;

        }

    }

    //GRIDVIEW SEÇ BUTONUNA TIKLADIĞIMIZDA ROWINDEX İLE O SATIRA AİT HÜCRE BİLGİLERİNİ ALIYORUM.
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        int index = GridView1.SelectedRow.RowIndex;
        string tc = GridView1.SelectedRow.Cells[1].Text;
        string ad = GridView1.SelectedRow.Cells[2].Text;
        string soyad = GridView1.SelectedRow.Cells[3].Text;
        string tel = GridView1.SelectedRow.Cells[4].Text;
        string mail = GridView1.SelectedRow.Cells[5].Text;

        //KİTAP ÖDÜNÇ VER PANELİNİN İÇERİSİNDEKİ LABEL'LARI DOLDURUYORUM. 
        Label6.Text = tc;
        Label7.Text = ad;
        Label8.Text = soyad;
        Label9.Text = tel;
        Label10.Text = mail;

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        lblDurum.Visible = false;

    }
    //KİTAP ÖDÜNÇ VER PANELİ İPTAL BUTONU
    protected void Button4_Click(object sender, EventArgs e)
    {
        //GRIDVIEW DÜZENLEMESİNİ İPTAL EDİYORUM, ÖDÜNÇ VERME PANELİNİ VE ÜYELER GRIDVIEW'INI GİZLİYORUM
        Panel1.Visible = false;
        GridView1.EditIndex = -1;
        GridView1.SelectedIndex = -1;
        GridView1.Visible = false;  
    }

    //
    //Bu fonksiyon ile "odunc" tablosundan odunc_id'yi alacağım. odunc_detaya kaydetmek için kullanacağım
    protected void oduncsorgu()
    {

        string sorgu5 = "select max(odunc_id) from odunc where tc = '" + Label6.Text + "'";
        SqlCommand cmd5 = new SqlCommand(sorgu5, baglanti);
        baglanti.Open();
        SqlDataReader dr5 = cmd5.ExecuteReader();

        if (dr5.Read())
        {
            //" Convert.ToInt32(dr5[0]) "  :  sütun "no column name" olarak geldiği için index numarasına göre aldım(sorgu cümlesinde "as" kullanarak isimlendirme yapılabilirdi)
            dr_odunc_id = Convert.ToInt32(dr5[0]);

        }
        baglanti.Close();
    }

    //Bu fonksiyon ile "odunc" tablosundan odunc_id'yi alacağım. odunc_detaya kaydetmek için kullanacağım. (Giriş yapan kullanıcının TC'sine göre işlem yapıyorum)
    protected void oduncsorgu2()
    {
        object tc = Session["tc"];
        string tc2 = tc.ToString();

        string sorgu5 = "select max(odunc_id) from odunc where tc = '" + tc2 + "'";
        SqlCommand cmd5 = new SqlCommand(sorgu5, baglanti);
        baglanti.Open();
        SqlDataReader dr5 = cmd5.ExecuteReader();

        if (dr5.Read())
        {
            dr_odunc_id = Convert.ToInt32(dr5[0]);

        }
        baglanti.Close();
    }
    //
    //ÖDÜNÇ VER BUTONU
    protected void Button5_Click(object sender, EventArgs e)
    {
        //Tarih kısmının boş geçilememsi ve geçmiş tarihlerin seçilebilmesini engelliyorum
        if (TextBox8.Text == "" || Convert.ToDateTime(TextBox8.Text) <= Convert.ToDateTime(bugun))
        {
            Response.Write("LÜTFEN GEÇERLİ BİR TESLİM ALMA TARİHİ SEÇİN!!!");
        }
        else
        {
            //STOK KONTROLÜ YAPMAK İÇİN KİTAPLARI LİSTELİYORUM
            string sorgu9 = "select * from kitaplar where ISBN='" + dr_ISBN + "'";
            SqlCommand cmd9 = new SqlCommand(sorgu9, baglanti);
            baglanti.Open();
            SqlDataReader dr9 = cmd9.ExecuteReader();

            if (dr9.Read())
            {
                dr_stok = Convert.ToInt32(dr9["stok"]);

            }
            else
            {

            }
            //EĞER KİTAP STOKTAYSA KİTABI ÖDÜNÇ VERİYORUM
            if (dr_stok > 0)
            {
                baglanti.Close();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
                conn.Open();
                string insertQuery = "insert into odunc(tc, alis_tarihi, teslim_tarihi, durum) values (@tc,@alis_tarihi,@teslim_tarihi,@durum)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);

                cmd.Parameters.AddWithValue("@tc", Label6.Text);
                cmd.Parameters.AddWithValue("@alis_tarihi", bugun);
                cmd.Parameters.AddWithValue("@teslim_tarihi", TextBox8.Text);
                cmd.Parameters.AddWithValue("@durum", "Kitap hala üyede");
                cmd.ExecuteNonQuery();
                conn.Close();
                //Aşağıdaki fonksiyon ile az önce kaydettiğimiz "odunc" tablosundan "odunc_id değerine ulaşıyorum.
                oduncsorgu(); // odunc_id'yi class altındaki dr_odunc_id'ye aktarıyorum

                SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
                conn2.Open();
                string insertQuery2 = "insert into odunc_detay(odunc_id, ISBN) values (@odunc_id,@ISBN)";
                SqlCommand cmd2 = new SqlCommand(insertQuery2, conn2);
                cmd2.Parameters.AddWithValue("@odunc_id", dr_odunc_id); //Class altından aldığım dr_odunc_id'i odunc_detay'a kaydetmek için kullanıyorum.
                cmd2.Parameters.AddWithValue("@ISBN", dr_ISBN);
                cmd2.ExecuteNonQuery();
                conn2.Close();

                baglanti.Open();
                //KİTABI ÖDÜNÇ VERDİĞİMİZ İÇİN İLGİLİ KİTABIN STOĞUNU 1 AZALTIYORUM.
                string insertQuery4 = "update kitaplar set stok=stok-1 where ISBN=@ISBN";
                SqlCommand cmd3 = new SqlCommand(insertQuery4, baglanti);
                cmd3.Parameters.AddWithValue("@ISBN", dr_ISBN);
                cmd3.ExecuteNonQuery();
                baglanti.Close();
                Response.Write("ÖDÜNÇ VERME İŞLEMİ BAŞARILI");

            }
            else
            {
                baglanti.Close();
                //Bu ne zaman stokta olacak? Bu kitabı Emanet verdiğimiz üyelerden; Teslim tarihi yaklaşan en yakın tarihi tarihi min() ile alıyorum. tarih formatını convert(varchar, column, 104) ile istediğim biçimde websayfamda gösteriyorum.
                string sorgu1 = "select convert(varchar, min(teslim_tarihi), 104) as teslim_tarihi from odunc where odunc_id IN (select odunc_id from odunc_detay where ISBN='" + dr_ISBN + "') and durum='Kitap hala üyede'";
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
            baglanti.Close();
        }
        
    }






    //ÖDÜNÇ ALMA İSTEĞİ GÖNDER BUTONU
    protected void Button6_Click(object sender, EventArgs e)
    {


        string sorgu99 = "select stok from kitaplar where ISBN='" + dr_ISBN + "'";
        SqlCommand cmd99 = new SqlCommand(sorgu99, baglanti);
        baglanti.Open();
        SqlDataReader dr99 = cmd99.ExecuteReader();
        if (dr99.Read())
        {
            if (Convert.ToInt32(DropDownList1.Text) > Convert.ToInt32(dr99["stok"]))
            {
                baglanti.Close();
                //Bu ne zaman stokta olacak? Bu kitabı Emanet verdiğimiz üyelerden; Teslim tarihi yaklaşan en yakın tarihi tarihi min() ile alıyorum. tarih formatını convert(varchar, column, 104) ile istediğim biçimde websayfamda gösteriyorum.
                string sorgu1 = "select convert(varchar, min(teslim_tarihi), 104) as teslim_tarihi from odunc where odunc_id IN (select odunc_id from odunc_detay where ISBN='" + dr_ISBN + "') and durum='Kitap hala üyede'";
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
            else
            {
                baglanti.Close();

                //Tarih kısmının boş geçilememsi ve geçmiş tarihlerin seçilebilmesini engelliyorum
                if (TextBox12.Text == "" || Convert.ToDateTime(TextBox12.Text) <= Convert.ToDateTime(bugun))
                {
                    Response.Write("LÜTFEN GEÇERLİ BİR TESLİM ALMA TARİHİ SEÇİN!!!");
                }
                else
                {
                    object tc = Session["tc"];
                    string tc2 = tc.ToString();

                    string sorgu5 = "select * from odunc where tc = '" + tc2 + "'";
                    SqlCommand cmd5 = new SqlCommand(sorgu5, baglanti);
                    baglanti.Open();
                    SqlDataReader dr5 = cmd5.ExecuteReader();
                    if (dr5.HasRows)
                    {
                        //BU KİŞİ ZATEN DAHA ÖNCEDEN 1 KİTAP ÖDÜNÇ ALDIYSA VEYA ÖDÜNÇ ALMA İSTEĞİ YOLLADIYSA TEKRAR ÖDÜNÇ ALMA İSTEĞİ YOLLAMASINI ENGELLİYORUM
                        baglanti.Close();
                    }
                    else
                    {
                        for (int i = 0; i < Convert.ToInt32(DropDownList1.Text); i++)
                        {
                            //ÖDÜNÇ VERME İŞLEMLERİ
                            baglanti.Close();
                            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
                            conn.Open();
                            string insertQuery = "insert into odunc(tc, durum, istek_tarihi, istedigi_tarih) values (@tc, @durum, @istek_tarihi, @istedigi_tarih)";
                            SqlCommand cmd = new SqlCommand(insertQuery, conn);
                            cmd.Parameters.AddWithValue("@tc", tc2);
                            cmd.Parameters.AddWithValue("@durum", "Ödünç alma isteği gönderildi");
                            cmd.Parameters.AddWithValue("@istek_tarihi", bugun);
                            cmd.Parameters.AddWithValue("@istedigi_tarih", TextBox12.Text);

                            cmd.ExecuteNonQuery();
                            conn.Close();

                            oduncsorgu2();


                            SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
                            conn2.Open();
                            string insertQuery2 = "insert into odunc_detay(odunc_id, ISBN) values (@odunc_id,@ISBN)";
                            SqlCommand cmd2 = new SqlCommand(insertQuery2, conn2);
                            cmd2.Parameters.AddWithValue("@odunc_id", dr_odunc_id);
                            cmd2.Parameters.AddWithValue("@ISBN", dr_ISBN);
                            cmd2.ExecuteNonQuery();
                            conn2.Close();
                        }
                        
                    }

                    baglanti.Close();
                    Response.Redirect(Request.RawUrl);
                }

            }

        }









        
        
    }

    // ÖDÜNÇ İSTEĞİNİ İPTAL ET
    protected void Button7_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
        conn.Open();
        string insertQuery = "delete from odunc where odunc_id IN (select odunc_id from odunc_detay where ISBN=@ISBN) and tc='" + Session["tc"] + "'";
        SqlCommand cmd = new SqlCommand(insertQuery, conn);
        cmd.Parameters.AddWithValue("@ISBN", dr_ISBN);
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect(Request.RawUrl);
    }
   
    //DATALIST KİTAP GÜNCELLEME VE SİLME İŞLEMLERİ
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "edit")
            {
                DataList1.EditItemIndex = e.Item.ItemIndex;
                verigetir();
            }
            else if (e.CommandName == "cancel")
            {
                DataList1.EditItemIndex = -1;
                verigetir();
            }
            else if (e.CommandName == "update")
            {
                //"e.Item.FindControl" İLE İŞLEM YAPILAN DATALİST'E AİT LABEL VE/VEYA TEXTBOX DEĞERLERİNİ ALIYORUM.
                string ISBN = ((Label)e.Item.FindControl("Label11")).Text;
                string kitap_adi = ((TextBox)e.Item.FindControl("TextBox13")).Text;
                string ad = ((TextBox)e.Item.FindControl("TextBox2")).Text;
                string soyad = ((TextBox)e.Item.FindControl("TextBox3")).Text;
                string yayin_evi_ad = ((TextBox)e.Item.FindControl("TextBox4")).Text;
                string yayin_tarihi = ((TextBox)e.Item.FindControl("TextBox5")).Text;
                string sayfa_sayisi = ((TextBox)e.Item.FindControl("TextBox6")).Text;
                string tur_adi = ((TextBox)e.Item.FindControl("TextBox7")).Text;
                string stok = ((TextBox)e.Item.FindControl("TextBox9")).Text;

                //KİTAP GÜNCELLEME İŞLEMLERİ
                SqlCommand komut = new SqlCommand("update kitaplar set kitap_adi='" + kitap_adi + "', yayin_tarihi='" + yayin_tarihi + "', sayfa_sayisi='" + sayfa_sayisi + "', stok='" + stok + "' where ISBN='" + ISBN + "'", baglanti);
                SqlCommand komut2 = new SqlCommand("update yazarlar set ad='" + ad + "', soyad='" + soyad + "' where yazar_id='" + dr_yazar_id + "'", baglanti);
                SqlCommand komut3 = new SqlCommand("update yayinevi set yayin_evi_ad='" + yayin_evi_ad + "' where yayinevi_id='" + dr_yayinevi_id + "'", baglanti);
                SqlCommand komut4 = new SqlCommand("update turler set tur_adi='" + tur_adi + "' where tur_id='" + dr_tur_id + "'", baglanti);

                baglanti.Open();
                komut.ExecuteNonQuery();
                komut2.ExecuteNonQuery();
                komut3.ExecuteNonQuery();
                komut4.ExecuteNonQuery();
                baglanti.Close();
                DataList1.EditItemIndex = -1;
                verigetir();

            }
            else if (e.CommandName == "delete")
            {
                //KİTAP SİLME
                string ISBN = ((Label)e.Item.FindControl("Label12")).Text;
                SqlCommand komut = new SqlCommand("delete from kitaplar where ISBN= '" + ISBN + "'", baglanti);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                verigetir();
                Response.Redirect("default.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Bir Hatayla Karşılaşıldı. Lütfen Son İşlemleriniz Kontrol ediniz. HATA MESAJI:" + ex.Message);
        }
        
    }
    protected void Button16_Click(object sender, EventArgs e)
    {

    }

}