using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox10.Text == "" || TextBox11.Text == "" || TextBox12.Text == "" || TextBox13.Text == "" || TextBox14.Text == "" || TextBox15.Text == "" || TextBox1.Text == "")
            {
                Response.Write("LÜTFEN BOŞ ALAN BIRAKMAYINIZ");
            }
            else if (TextBox14.Text != TextBox15.Text)
            {
                Response.Write("ŞİFRELER BİRBİRİYLE UYUŞMUYOR");
            }
            else if (TextBox12.Text.Length != 11)
            {
                Response.Write("TC 11 HANELİ OLMALIDIR");
            }
            else
            {
                conn.Open();
                //TextBox'a girilen TC Veritabanında var mı yok mu?
                string checkuser = "select count(*) from uyeler where tc='" + TextBox12.Text + "'";
                SqlCommand cmd = new SqlCommand(checkuser, conn);

                //Burada niye *ExecuteScalar() kullanmayı tercih ettim bilmiyorum. O an ki ruh halime bağlı.
                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                //Eğer Girilen TC'ye ait üye zaten veritabanında kayıtlıysa hata mesajı veriyorum.
                if (temp == 1)
                {
                    conn.Close();
                    Response.Write("UYARI! BU TC KİMLİK NUMARASINA AİT ÜYE ZATEN KAYITLI");
                    TextBox1.Text = "";
                    TextBox10.Text = "";
                    TextBox11.Text = "";
                    TextBox12.Text = "";
                    TextBox13.Text = "";
                    TextBox14.Text = "";
                }
                else
                {
                    //Eğer Girilen TC'ye ait üye halihazırda veritabanında yoksa kayıt işlemlerini yapıyorum
                    conn.Close();
                    conn.Open();
                    string insertQuery = "insert into uyeler(tc,ad,soyad,tel, mail, sifre, yetki)values (@tc,@ad,@soyad,@tel, @mail, @sifre,@yetki)";
                    SqlCommand cmd2 = new SqlCommand(insertQuery, conn);
                    cmd2.Parameters.AddWithValue("@ad", TextBox10.Text);
                    cmd2.Parameters.AddWithValue("@soyad", TextBox11.Text);
                    cmd2.Parameters.AddWithValue("@tc", TextBox12.Text);
                    cmd2.Parameters.AddWithValue("@tel", TextBox13.Text);
                    cmd2.Parameters.AddWithValue("@mail", TextBox1.Text);
                    cmd2.Parameters.AddWithValue("@sifre", TextBox14.Text);
                    cmd2.Parameters.AddWithValue("@yetki", "normal_uye");
                    cmd2.ExecuteNonQuery();

                    Response.Write("ÜYE KAYDI BAŞARILI");
                    TextBox1.Text = "";
                    TextBox10.Text = "";
                    TextBox11.Text = "";
                    TextBox12.Text = "";
                    TextBox13.Text = "";
                    TextBox14.Text = "";
                }
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            Response.Write("Bir Hatayla Karşılaşıldı. Lütfen Son İşlemleriniz Kontrol ediniz. HATA MESAJI:" + ex.Message);
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}