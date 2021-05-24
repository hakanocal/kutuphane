using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Eğer bir kullanıcı zaten üye/admin girişi yaptıysa tekrar giriş sayfasına ulaşamaması için hazırladığım koşul yapısı:
        object kullanici = Session["tc"];
        if (kullanici != null)
        {
            Response.Redirect("default.aspx");
        }
        else
        {

        }
    }
    //Giriş yap Butonu
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from uyeler where tc=@tc and sifre=@sifre", conn);  
        cmd.Parameters.AddWithValue("@tc", TextBox1.Text);  
        cmd.Parameters.AddWithValue("sifre", TextBox2.Text);  
        SqlDataAdapter sda = new SqlDataAdapter(cmd);  
        DataTable dt = new DataTable();
        sda.Fill(dt);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //300 dakika sonunda oturum sonlandırılacak (sanırım bunu tüm sayfalarda kullanmam gerekiyordu)
        Session.Timeout = 300;
        //Eğer TextBox'lara girilen TC ve Şifre veritabanındaki TC ve Şifre ile eşleşiyorsa Session'a kullanıcının bilgilerini ekliyorum.
        if (dr.Read())
        {
            Session.Add("tc", dr["tc"].ToString());
            Session.Add("ad", dr["ad"].ToString());
            Session.Add("soyad", dr["soyad"].ToString());
            Session.Add("yetki", dr["yetki"].ToString());
            Response.Redirect("default.aspx");
        }
            //Böyle bir Kullanıcı DB'de kayıtlı değilse verdiğim hata mesajı
        else
        {
            Response.Write("KULLANICI GİRİŞ SAĞLANMADI");
        }
        conn.Close();

    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
}