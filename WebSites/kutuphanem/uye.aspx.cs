using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class uye : System.Web.UI.Page
{
    SqlCommand komut = new SqlCommand();
    SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {


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

    private void temizle()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox9.Text = "";
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        temizle();
    }
    //"ÜYE EKLE" PANELİ KAYDET BUTONU
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand uye = new SqlCommand();
            uye.Connection = baglanti;
            uye.CommandText = "insert into uyeler(tc, ad, soyad, tel, mail, sifre, yetki) values ('" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox9.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "' , '" + DropDownList1.SelectedValue + "')";
            baglanti.Open();
            uye.ExecuteNonQuery();
            baglanti.Close();
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            Response.Write("Bir Hatayla Karşılaşıldı. Lütfen Son İşlemleriniz Kontrol ediniz. HATA MESAJI:" + ex.Message);
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}