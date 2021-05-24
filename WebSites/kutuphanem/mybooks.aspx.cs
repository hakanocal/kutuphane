using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mybooks : System.Web.UI.Page
{
    SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
    object kullanici;

    protected void kitapguncelle()
    {
        //odunc tablosundaki "durum" sütunu ile sadece ödünç aldığım kitapları listeliyorum.
        string sorgu = "select * from kitaplar where ISBN IN (select ISBN from odunc_detay where odunc_id IN (select odunc_id from odunc where tc = '" + kullanici.ToString() + "' and durum='Kitap hala üyede')) order by kitap_adi ASC";
        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
        baglanti.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        lstkitaplar.DataSource = dr;
        lstkitaplar.DataBind();
        baglanti.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //sadece giriş yapanların bu sayfaya erişebilmesini sağlıyorum
        kullanici = Session["tc"];
        object yetki = Session["yetki"];

        if (kullanici == null)
        {
            Response.Redirect("default.aspx");
        }
        else
        {
            kitapguncelle();
        }
    }
}