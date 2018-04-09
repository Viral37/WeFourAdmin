using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class test_Seller_Profile : System.Web.UI.Page
{

    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    string ssss = null;
    CRUD objcrud = new CRUD();
    protected void Page_Load(object sender, EventArgs e)
    {
        login();
    }

    public void login()
    {
        con.Open();

        if (Context.Request.Cookies["inf"] != null)
        {
            string skp = Request.Cookies["inf"].Value;
            string mp = null;
            if (skp != null)
            {
                string[] sdss = skp.Split('$');
                for (int k = 0; k < sdss.Length; k++)
                {
                    if (mp == null)
                    {
                        mp = sdss[k];
                    }
                }
            }
            ssss = Encoding.UTF32.GetString(Convert.FromBase64String(mp));
        }
        con.Close();
    }
    protected void lblaccount_Click(object sender, EventArgs e)
    {
        con.Open();
        string ssss = null;
        if (Context.Request.Cookies["inf"] != null)
        {
            string skp = Request.Cookies["inf"].Value;
            string mp = null;
            if (skp != null)
            {
                string[] sdss = skp.Split('$');
                for (int k = 0; k < sdss.Length; k++)
                {
                    if (mp == null)
                    {
                        mp = sdss[k];
                    }
                }
            }
            ssss = Encoding.UTF32.GetString(Convert.FromBase64String(mp));
        }
        SqlCommand cmd = new SqlCommand("select * from tbl_login where status='Active' and email_id='" + ssss + "' and Vender='A1'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            vname.Text = dr["username"].ToString();
            vmno.Text = dr["contact"].ToString();
            vemail.Text = ssss;
            //vpass.Text = dr["password"].ToString();
            lbladdress.Text = dr["address"].ToString();
            lblcity.Text = dr["city"].ToString();
            lblstate.Text = dr["state"].ToString();
            lblpin.Text = dr["pincode"].ToString();
            dr.Close();

            SqlCommand cc = new SqlCommand("select * from tbl_business where email_id='" + ssss + "' ", con);
            SqlDataReader dr2 = cc.ExecuteReader();
            while (dr2.Read())
            {
                lbldname.Text = dr2["buss_name"].ToString();
                lblddesc.Text = dr2["bill_label"].ToString();
            }
            con.Close();
        }
        else
        {
            Response.Redirect("~/Vender/Home.aspx");
        }
        account.Visible = true;
        mainpanel.Visible = false;
    }

    protected void lbtnacmanager_Click(object sender, EventArgs e)
    {
        mainpanel.Visible = false;
        account.Visible = false;
        //accmanager.Visible = true;
        con.Open();
        string ssss = null;
        if (Context.Request.Cookies["inf"] != null)
        {
            string skp = Request.Cookies["inf"].Value;
            string mp = null;
            if (skp != null)
            {
                string[] sdss = skp.Split('$');
                for (int k = 0; k < sdss.Length; k++)
                {
                    if (mp == null)
                    {
                        mp = sdss[k];
                    }
                }
            }
            ssss = Encoding.UTF32.GetString(Convert.FromBase64String(mp));
        }
        SqlCommand cmd = new SqlCommand("select * from tbl_login where status='Active' and email_id='" + ssss + "' and Vender='A1'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            vname.Text = dr["username"].ToString();
            vmno.Text = dr["contact"].ToString();
            vemail.Text = ssss;
            //vpass.Text = dr["password"].ToString();
            lbladdress.Text = dr["address"].ToString();
            lblcity.Text = dr["city"].ToString();
            lblstate.Text = dr["state"].ToString();
            lblpin.Text = dr["pincode"].ToString();
            dr.Close();
            con.Close();
        }
        else
        {

            Response.Redirect("~/Vender/Home.aspx");
        }
    }

    protected void lblbussiness_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand bcmd = new SqlCommand("select * from tbl_business where email_id='"+ ssss +"'",con);
        SqlDataReader bdr = bcmd.ExecuteReader();
        if (bdr.Read())
        {
            lblbname.Text = bdr["buss_name"].ToString();
            lbldes.Text = bdr["bill_label"].ToString();
            lblradd.Text = bdr["reg_add"].ToString();
            lblrcity.Text = bdr["reg_city"].ToString();
            lbltanno.Text = bdr["TAN_Id"].ToString();
            lblgstno.Text = bdr["GST_ID"].ToString();
            lblcinno.Text = bdr["com_cin"].ToString();
            lblpannum.Text = bdr["com_pan"].ToString();

            SqlCommand bankcmd = new SqlCommand("select * from tbl_bank where email_id='" + ssss + "'", con);

            bdr.Close();
            SqlDataReader bankdr = bankcmd.ExecuteReader();
            if (bankdr.Read())
            {
                lblachname.Text = bankdr["holder_name"].ToString();
                lblacno.Text = bankdr["account_no"].ToString();
                lblbname.Text = bankdr["bank_name"].ToString();
                lblactype.Text = bankdr["account_type"].ToString();
                lblifc.Text = bankdr["ifsc_no"].ToString();
                lblbadd.Text = bankdr["benif_add"].ToString();
                lblbcity.Text = bankdr["benif_city"].ToString();
                lblbstate.Text = bankdr["benif_state"].ToString();
            }
            else
            {
                lblachname.Text = "";
                lblacno.Text = "";
                lblbname.Text = "";
                lblactype.Text = "";
                lblifc.Text = "";
                lblbadd.Text = "";
                lblbcity.Text = "";
                lblbstate.Text = "";

            }
            bankdr.Close();

        }
        else
        {

            lblbname.Text = "";
            lbldes.Text = "";
            lblradd.Text = "";
            lblrcity.Text = "";
            lbltanno.Text = "";
            lblgstno.Text = "";
            lblcinno.Text = "";
            lblpannum.Text = "";
        }
        
        con.Close();
        mainpanel.Visible = false;
        bussinesdetails.Visible = true;
    }

    protected void lblsetting_Click(object sender, EventArgs e)
    {
        mainpanel.Visible = false;
        setting.Visible = true;
    }

    protected void lblcal_Click(object sender, EventArgs e)
    {
        mainpanel.Visible = false;
        //calendar.Visible = true;
    }

    protected void lblmanage_Click(object sender, EventArgs e)
    {
        mainpanel.Visible = false;
        manageuser.Visible = true;
    }


    protected void btnbssave_Click(object sender, EventArgs e)
    {
        con.Open();
        string ssss = null;
        if (Context.Request.Cookies["inf"] != null)
        {
            string skp = Request.Cookies["inf"].Value;
            string mp = null;
            if (skp != null)
            {
                string[] sdss = skp.Split('$');
                for (int k = 0; k < sdss.Length; k++)
                {
                    if (mp == null)
                    {
                        mp = sdss[k];
                    }
                }
            }
            ssss = Encoding.UTF32.GetString(Convert.FromBase64String(mp));
        }
        SqlCommand com = new SqlCommand();

    }
}
