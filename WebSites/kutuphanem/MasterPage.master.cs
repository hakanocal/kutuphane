using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        object tc = Session["tc"];
        object ad = Session["ad"];
        object soyad = Session["soyad"];
        object yetki = Session["yetki"];



        if (tc == null)
        {

            //Session gelen değer boş ise, "ödünç istekleri, emanetler, üyeler" gibi sayfaları gizliyorum.
            Label1.Visible = false;
            Button6.Visible = false;
            Button7.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button8.Visible = false;

        }
        else if (yetki.ToString() == "admin")
        {
            //Admin giriş yaptıysa "ödünç istekleri, emanetler, üyeler" vs. butonları aktifleştiriyorum ve isminin yanında "admin" ibaresinin yer almasını sağlıyorum
            Label1.Text = ad + " " + soyad.ToString() + " (admin)";
            Label1.Visible = true;
            Button4.Visible = false;
            Button5.Visible = false;
            Button7.Visible = true;
            Button2.Visible = true;
            Button3.Visible = true;
            Button8.Visible = true;
        }
        else
        {
            //normal bir üye giriş yaptığında bu else'in içine girecek. "ödünç istekleri, emanetler, üyeler" gibi sayfaları gizliyorum. 
            Label1.Text = ad + " " + soyad.ToString();
            Label1.Visible = true;
            Button4.Visible = false;
            Button5.Visible = false;
            Button7.Visible = true;
            Button2.Visible = false;
            Button3.Visible = false;
            Button8.Visible = false;

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("uye.aspx");

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("emanet.aspx");

    }
    protected void Button4_Click(object sender, EventArgs e)
    {

        Response.Redirect("login.aspx");

    }
    //Çıkış yap butonu
    protected void Button6_Click(object sender, EventArgs e)
    {
        //Oturumu sonlandır
        Session.Abandon();
        //Sayfayı yenile
        Response.Redirect(Request.RawUrl);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("mybooks.aspx");
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Response.Redirect("odunc_istekleri.aspx");
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Response.Redirect("profil.aspx");
    }
}
