using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class emanet_ayrinti : System.Web.UI.Page
{
    SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
    string dr_ISBN;
    string sorgu2, sorgu3, sorgu4, sorgu5;
    DateTime bugun;

    
    protected void Page_Load(object sender, EventArgs e)
    {











        bugun = DateTime.Now;
        string ISBN = Request.QueryString["kitapISBN"];
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
        string sorgu = "select * from kitaplar where ISBN=@ISBN";


        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
        cmd.Parameters.AddWithValue("@ISBN", ISBN);
        baglanti.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //KİTABIN BİLGİLERİNİ ALIYORUM VE LABEL'LARA YAZDIRIYORUM
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
            //KİTAPLAR TABLOSUNDAKİ YAZAR, YAYINEVİ, TÜR ID'LERİNİN İLİŞKİLİ VERİTABANINDA KARŞILIK GELDİĞİ DEĞERLERİ ALIYORUM
            sorgu2 = "select ad, soyad from yazarlar where yazar_id = '" + dr["yazar_id"].ToString() + "'";
            sorgu3 = "select yayin_evi_ad from yayinevi where yayinevi_id = '" + dr["yayinevi_id"].ToString() + "'";
            sorgu4 = "select tur_adi from turler where tur_id = '" + dr["tur_id"].ToString() + "'";
            //CONVERT() İLE VERİTABANINDAKİ TARİH FORMATINI İSTEDİĞİM BİÇİMDE ALIYORUM (gg/aa/yyyy)
            sorgu5 = "select convert(varchar, alis_tarihi, 104), convert(varchar, teslim_tarihi, 104)  from odunc where odunc_id IN (select odunc_id from odunc_detay where ISBN = '" + dr["ISBN"].ToString() + "')";
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




        //Gridview doldurma kodlarım
        if (!IsPostBack)
        {
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ID = "SqlDataSource1";
            this.Page.Controls.Add(SqlDataSource1);
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString;
            //Tek bir sorguda üye, ödünç, ödünç detay bilgilerine ulaşmak için farklı tablolardan sütunları birleştiriyorum.
            SqlDataSource1.SelectCommand = "select uyeler.tc, uyeler.ad, uyeler.soyad, uyeler.tel, uyeler.mail, odunc.alis_tarihi, convert(varchar, odunc.teslim_tarihi, 104) as teslim_tarihi, odunc_detay.detay_id from uyeler, odunc, odunc_detay where uyeler.tc = odunc.tc and odunc.odunc_id = odunc_detay.odunc_id and durum ='Kitap hala üyede' and ISBN='" + dr_ISBN + "'";
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }





        //BU SAYFAYI SADECE ADMİNLERİN GÖREBİLMESİ İÇİN YAPTIĞIM İŞLEMLER:     (NOT: BU KISMI PAGE LOAD KISMININ EN ÜSTÜNE ALMAK DAHA MANTIKLI OLABİLİRDİ)
        object kullanici = Session["tc"];
        object yetki = Session["yetki"];

        if (kullanici == null || yetki.ToString() != "admin")
        {
            Response.Redirect("default.aspx");
        }
        else
        {

        }


    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    //GRIDVIEW İŞLEM YAP BUTONUNA TIKLADIĞIMIZDA ROWINDEX İLE O SATIRA AİT HÜCRE BİLGİLERİNİ ALIYORUM.
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        int index = GridView1.SelectedRow.RowIndex;
        string tc = GridView1.SelectedRow.Cells[1].Text;
        string ad = GridView1.SelectedRow.Cells[2].Text;
        string soyad = GridView1.SelectedRow.Cells[3].Text;
        string tel = GridView1.SelectedRow.Cells[4].Text;
        string mail = GridView1.SelectedRow.Cells[5].Text;
        string alis_tarihi = GridView1.SelectedRow.Cells[6].Text;
        string teslim_tarihi = GridView1.SelectedRow.Cells[7].Text;
        string id = GridView1.SelectedRow.Cells[8].Text;
        string teslim_tarihi2 = bugun.ToString();

        //KİTABI GERİ TESLİM AL PANELİNİN İÇERİSİNDEKİ TEXTBOXLARI DOLDURUYORUM. 
        TextBox1.Text = alis_tarihi;
        TextBox8.Text = teslim_tarihi;
        Label6.Text = tc;
        Label7.Text = ad;
        Label8.Text = soyad;
        Label9.Text = tel;
        Label10.Text = mail;
        TextBox2.Text = bugun.ToString() ;
    }
    //KİTABI GERİ TESLİM ALMA İŞLEMİNİ İPTAL EDİYORUM (PANEL1)
    protected void Button4_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        GridView1.EditIndex = -1;
        GridView1.SelectedIndex = -1;
    }
    //GERİ TESLİM ALMA BUTONU
    protected void Button5_Click(object sender, EventArgs e)
    {
        int index = GridView1.SelectedRow.RowIndex;
        string tc = GridView1.SelectedRow.Cells[1].Text;
        string id = GridView1.SelectedRow.Cells[8].Text;
        baglanti.Open();
        //GERİ TESLİM ALDIĞIMIZDA İLGİLİ KİTABIN STOĞUNU 1 ARTTIYORUM
        string insertQuery4 = "update kitaplar set stok=stok+1 where ISBN=@ISBN";
        SqlCommand cmd3 = new SqlCommand(insertQuery4, baglanti);
        cmd3.Parameters.AddWithValue("@ISBN", dr_ISBN);
        cmd3.ExecuteNonQuery();
        baglanti.Close();

        baglanti.Open();
        //KİTABI GERİ TESLİM ALDIĞIMIZ İÇİN ÖDÜNÇ TABLOSUNDAN KAYDI SİLİYORUM ("odunc_detay" tablosuyla ilişkili olduğu için oradan da siliniyor)
        string insertQuery5 = "delete from odunc where odunc_id IN (select odunc_id from odunc_detay where ISBN=@ISBN and detay_id=@detay_id) and tc='" + tc + "'";
        SqlCommand cmd5 = new SqlCommand(insertQuery5, baglanti);
        cmd5.Parameters.AddWithValue("@ISBN", dr_ISBN);
        cmd5.Parameters.AddWithValue("@detay_id", id);
        cmd5.ExecuteNonQuery();
        baglanti.Close();
        Response.Redirect("emanet.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}