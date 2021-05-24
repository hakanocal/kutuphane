using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class profil : System.Web.UI.Page
{
    object kullanici;
    object yetki;
    SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kitaplar"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
       
        kullanici = Session["tc"];
        yetki = Session["yetki"];

        if (kullanici == null)
        {
            Response.Redirect("default.aspx");
        }
        else
        {

        }


        if (!IsPostBack)
        {
            verigetir();

        }
    }

    //PROFİL BİLGİLERİMİ DEĞİŞTİRMEK VEYA HESABIMI SİLMEK İÇİN DATALIST'E SADECE KENDİ BİLGİLERİMİ ALIYORUM
    private void verigetir()
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from uyeler where tc='" + Session["tc"] + "'", baglanti);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataList1.DataSource = ds;
        DataList1.DataBind();
    }
    //PROFİL GÜNCELLEME/SİLME YAPMAK İÇİN GRIDVIEW YERİNE DATALIST KULLANMAYI TERCİH ETTİM.
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            DataList1.EditItemIndex = e.Item.ItemIndex;
            verigetir();
        }
        else if (e.CommandName == "cancel"){
            DataList1.EditItemIndex = -1;
            verigetir();
        }
        else if (e.CommandName == "update"){
            string tc = ((Label)e.Item.FindControl("Label2")).Text;
            string ad = ((TextBox)e.Item.FindControl("TextBox1")).Text;
            string soyad = ((TextBox)e.Item.FindControl("TextBox2")).Text;
            string tel = ((TextBox)e.Item.FindControl("TextBox3")).Text;
            string mail = ((TextBox)e.Item.FindControl("TextBox4")).Text;
            string sifre = ((TextBox)e.Item.FindControl("TextBox5")).Text;
            SqlCommand komut = new SqlCommand("update uyeler set tc = '" + tc + "', ad='" + ad + "', soyad='" + soyad + "', tel='" + tel + "', mail='" + mail + "', sifre='" + sifre + "' where tc='" + Session["tc"] + "'", baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            DataList1.EditItemIndex = -1;
            verigetir();
            //Session.Abandon();
        }
        else if (e.CommandName == "delete")
        {
            string tc = ((Label)e.Item.FindControl("Label1")).Text;
            SqlCommand komut = new SqlCommand("delete from uyeler where tc= '" + tc + "'", baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            verigetir();
            Session.Abandon();
            Response.Redirect("default.aspx");
        }
    }
    
}