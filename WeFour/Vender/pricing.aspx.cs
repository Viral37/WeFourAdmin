using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

public partial class Vender_pricing : System.Web.UI.Page
{
    CRUD objcrud = new CRUD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drop_cat();
            //string ssss = null;
            //if (Context.Request.Cookies["inf"] != null)
            //{
            //    string skp = Request.Cookies["inf"].Value;
            //    string mp = null;
            //    if (skp != null)
            //    {
            //        string[] sdss = skp.Split('$');
            //        for (int k = 0; k < sdss.Length; k++)
            //        {
            //            if (mp == null)
            //            {
            //                mp = sdss[k];
            //            }
            //        }
            //    }
            //    ssss = Encoding.UTF32.GetString(Convert.FromBase64String(mp));
            //}
            //string selectrights = "select * from access_detail where access_email='" + ssss + "'";
            //DataTable dt = objcrud.datatable_(selectrights);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    string page = dt.Rows[i]["access_page"].ToString();
            //    string path = HttpContext.Current.Request.Url.AbsolutePath;
            //    string fullpath = "~" + path;
            //    if (fullpath != page.Trim())
            //    {
            //        Response.Redirect("~/Vender/Fobidden.aspx");
            //    }
            //}
        }
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> Getcat(string prefixText, int count)
    {
        CRUD objcrud = new CRUD();
        string get1 = prefixText + '%';
        string select = @"select		tg.cat_grp_name as zero, tc.cat_name as first,tc1.cat_name as second
                          from		    Category as tc
                          inner join    Category as tc1
                          on			tc.cat_id = tc1.parentid
                          inner join    Category_Group as tg
                          on			tc.cat_grp_id = tg.cat_grp_id 
                          where         tc1.cat_name like '" + prefixText + "%'";


        List<string> cat = new List<string>();
        SqlDataReader sdr = objcrud.datareader(select);
        while (sdr.Read())
        {
            string get = sdr["second"].ToString() + " in " + sdr["zero"].ToString();
            cat.Add(get);
            prefixText = sdr["second"].ToString();
        }


        return cat;
    }

    public void drop_cat()
    {
        try
        {
            string dis1 = "select cat_grp_id,cat_grp_name from Category_Group";
            DataSet ds = objcrud.dataset_(dis1);
            ddl_cat.Items.Clear();
            ddl_cat.Items.Insert(0, new ListItem("Select Category", "0"));
            ddl_cat.DataSource = ds.Tables[0];
            ddl_cat.DataTextField = "cat_grp_name";
            ddl_cat.DataValueField = "cat_grp_id";
            ddl_cat.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void ddl_cat_SelectedIndexChanged(object sender, EventArgs e)
    {
        string select = "select commission_fee from Category_Group where cat_grp_id='" + ddl_cat.SelectedValue + "'";
        SqlDataReader dr = objcrud.datareader(select);
        while (dr.Read())
        {
            lbl_main.Text = dr["commission_fee"].ToString();
            cat_comm.Visible = true;
        }

    }

    protected void txt_subcat_TextChanged(object sender, EventArgs e)
    {
        string get, final;
        get = txt_subcat.Text;
        int index = get.IndexOf(" in ");
        final = get.Substring(0, index);
        txt_subcat.Text = final;
        string select = "select commission_fee from Category where cat_name='" + txt_subcat.Text + "'";
        SqlDataReader dr = objcrud.datareader(select);

        while (dr.Read())
        {
            lbl_sub_rf.Text = dr["commission_fee"].ToString();

            dv_referral_third.Visible = true;
            dv_product_price.Visible = true;

        }



    }




    protected void btn_cal_fees_Click(object sender, EventArgs e)
    {
        dv_closing.Visible = true;
        dv_shipping.Visible = true;
        dv_referral_fee.Visible = true;
        double ref_price1, ref_price2, per;
        per = 100;
        ref_price1 = Convert.ToDouble(txt_prod_price.Text);
        ref_price2 = (Convert.ToDouble(lbl_sub_rf.Text) * Convert.ToDouble(ref_price1.ToString()) / per);
        lbl_ref.Text = ref_price2.ToString();
        lbl_rf_percentage.Text = lbl_sub_rf.Text;

        if (Convert.ToDouble(txt_prod_price.Text) > 0 && Convert.ToDouble(txt_prod_price.Text) <= 500)
        {
            lbl_closingfee.Text = "10";
        }
        else if (Convert.ToDouble(txt_prod_price.Text) > 500 && Convert.ToDouble(txt_prod_price.Text) <= 1000)
        {
            lbl_closingfee.Text = "20";
        }
        else if (Convert.ToDouble(txt_prod_price.Text) > 1000)
        {
            lbl_closingfee.Text = "40";
        }

    }

    protected void btn_selfsubmit_Click(object sender, EventArgs e)
    {
        dv_shipping.Visible = false;

        dv_ship_by_self.Visible = true;
        dv_RCS.Visible = true;
        lbl_ship_self.Text = txt_self_ship.Text;
        double a1, b1, c1, i;
        double.TryParse(lbl_ref.Text, out a1);
        double.TryParse(lbl_closingfee.Text, out b1);
        double.TryParse(lbl_ship_self.Text, out c1);

        i = a1 + b1 + c1;
        lbl_RCS.Text = i.ToString();

        double GST, rcs, gst, per;
        per = 100;
        double.TryParse(lbl_RCS.Text, out rcs);
        double.TryParse(lbl_gst_per.Text, out gst);
        GST = ((rcs * gst) / per);
        lbl_GST.Text = GST.ToString();

        double total, GST_total;
        double.TryParse(lbl_GST.Text, out GST_total);
        total = rcs + GST_total;
        lbl_total.Text = total.ToString();

        double prod_price, you_make, profit, cost;
        double.TryParse(txt_prod_price.Text, out prod_price);

        you_make = prod_price - total;
        lbl_you_make.Text = you_make.ToString();
        double.TryParse(txt_cost.Text, out cost);
        profit = you_make - cost;


    }

    //protected void lnk_self_Click(object sender, EventArgs e)
    //{
    //    dv_shipping.Visible = true;
    //    dv_RCS.Visible = false;
    //    dv_ship_by_self.Visible = false;
    //}

    protected void btn_profit_Click(object sender, EventArgs e)
    {
        double you_make, profit, cost;
        double.TryParse(lbl_you_make.Text, out you_make);
        lbl_you_make.Text = you_make.ToString();
        double.TryParse(txt_cost.Text, out cost);
        profit = you_make - cost;
        lbl_profit_price.Text = profit.ToString();
        dv_show_profit.Visible = true;
        dv_cal_profit.Visible = false;
        lbl_cost.Text = cost.ToString();
    }

    protected void lnk_profit_edit_Click(object sender, EventArgs e)
    {
        dv_show_profit.Visible = false;
        dv_cal_profit.Visible = true;
    }

    protected void btn_easy_amazon_Click(object sender, EventArgs e)
    {
        dv_shipping.Visible = false;

        dv_ship_by_budgetok.Visible = true;
        dv_RCS.Visible = true;
        lbl_weight.Text = txt_weight.Text;
        Double weight, gms, kg5, kg12, gms500u, kg5u, kg12u, ship;
        double.TryParse(lbl_weight.Text, out weight);

        if (rbl_lrn.SelectedValue == "Locally")
        {
            gms = 40;
            gms500u = 40;
            kg5 = 90;
            kg5u = 19;
            kg12 = 210;
            kg12u = 12.50;
            lbl_ship_by_budgetok.Text = "&nbsp;" + rbl_lrn.SelectedValue + "&nbsp;";

            if (weight <= 500)
            {
                lbl_ship.Text = gms.ToString();

            }
            else if (weight >= 501 && weight < 5000)
            {
                double extra = (weight - 500);
                if (extra <= 500)
                {
                    ship = gms + (gms500u * 1);
                    lbl_ship.Text = ship.ToString();
                }
                else if (extra > 500)
                {
                    double my = (extra / 500);
                    double aa = Math.Ceiling(my);
                    ship = (gms + (gms500u * aa));
                    lbl_ship.Text = ship.ToString();
                }
            }
            //else if (weight >= 501 && weight <= 1000)
            //{
            //    lbl_ship.Text = (gms + (gms500u * 1)).ToString();
            //}

            //else if (weight >= 1001 && weight <= 1500)
            //{
            //    lbl_ship.Text = (gms + (gms500u * 2)).ToString();
            //}
            //else if (weight >= 1501 && weight <= 2000)
            //{
            //    lbl_ship.Text = (gms + (gms500u * 3)).ToString();
            //}
            //else if (weight >= 2001 && weight <= 3000)
            //{
            //    lbl_ship.Text = (gms + (gms500u * 4)).ToString();
            //}
            //else if (weight >= 3001 && weight <= 4000)
            //{
            //    lbl_ship.Text = (gms + (gms500u * 5)).ToString();
            //}
            //else if (weight >= 4001 && weight < 5000)
            //{
            //    lbl_ship.Text = (gms + (gms500u * 6)).ToString();
            //}
            else if (weight == 5000)
            {
                lbl_ship.Text = kg5.ToString();
            }
            else if (weight >= 5001 && weight < 12000)
            {
                double extra = (weight - 5000);
                if (extra <= 1000)
                {
                    ship = kg5 + (kg5u * 1);
                    lbl_ship.Text = ship.ToString();
                }
                else if (extra > 1000)
                {
                    double my = (extra / 1000);
                    double aa = Math.Ceiling(my);
                    ship = (kg5 + (kg5u * aa));
                    lbl_ship.Text = ship.ToString();
                }
            }

            else if (weight == 12000)
            {
                lbl_ship.Text = kg12.ToString();
            }
            else if (weight >= 12000)
            {
                double extra = (weight - 12000);
                if (extra <= 1000)
                {
                    ship = kg12 + (kg12u * 1);
                    lbl_ship.Text = ship.ToString();
                }
                else if (extra > 1000)
                {
                    double my = (extra / 1000);
                    double aa = Math.Ceiling(my);
                    ship = (kg12 + (kg12u * aa));
                    lbl_ship.Text = ship.ToString();
                }
            }

        }
        else if (rbl_lrn.SelectedValue == "Regionally")
        {
            gms = 55;
            gms500u = 45;
            kg5 = 140;
            kg5u = 21;
            kg12 = 310;
            kg12u = 15;
            lbl_ship_by_budgetok.Text = "&nbsp;" + rbl_lrn.SelectedValue + "&nbsp;";

            if (weight <= 500)
            {
                lbl_ship.Text = gms.ToString();

            }

            else if (weight >= 501 && weight < 5000)
            {
                double extra = (weight - 500);
                if (extra <= 500)
                {
                    ship = gms + (gms500u * 1);
                    lbl_ship.Text = ship.ToString();
                }
                else if (extra > 500)
                {
                    double my = (extra / 500);
                    double aa = Math.Ceiling(my);
                    ship = (gms + (gms500u * aa));
                    lbl_ship.Text = ship.ToString();
                }
            }
            else if (weight == 5000)
            {
                lbl_ship.Text = kg5.ToString();
            }
            else if (weight >= 5001 && weight < 12000)
            {
                double extra = (weight - 5000);
                if (extra <= 1000)
                {
                    ship = kg5 + (kg5u * 1);
                    lbl_ship.Text = ship.ToString();
                }
                else if (extra > 1000)
                {
                    double my = (extra / 1000);
                    double aa = Math.Ceiling(my);
                    ship = (kg5 + (kg5u * aa));
                    lbl_ship.Text = ship.ToString();
                }
            }

            else if (weight == 12000)
            {
                lbl_ship.Text = kg12.ToString();
            }
            else if (weight >= 12000)
            {
                double extra = (weight - 12000);
                if (extra <= 1000)
                {
                    ship = kg12 + (kg12u * 1);
                    lbl_ship.Text = ship.ToString();
                }
                else if (extra > 1000)
                {
                    double my = (extra / 1000);
                    double aa = Math.Ceiling(my);
                    ship = (kg12 + (kg12u * aa));
                    lbl_ship.Text = ship.ToString();
                }
            }
        }
        else if (rbl_lrn.SelectedValue == "Nationally")
        {
            gms = 75;
            gms500u = 55;
            kg5 = 190;
            kg5u = 23;

            lbl_ship_by_budgetok.Text = "&nbsp;" + rbl_lrn.SelectedValue + "&nbsp;";

            if (weight <= 500)
            {
                lbl_ship.Text = gms.ToString();

            }

            else if (weight >= 501 && weight < 5000)
            {
                double extra = (weight - 500);
                if (extra <= 500)
                {
                    ship = gms + (gms500u * 1);
                    lbl_ship.Text = ship.ToString();
                }
                else if (extra > 500)
                {
                    double my = (extra / 500);
                    double aa = Math.Ceiling(my);
                    ship = (gms + (gms500u * aa));
                    lbl_ship.Text = ship.ToString();
                }
            }
            else if (weight == 5000)
            {
                lbl_ship.Text = kg5.ToString();
            }
            else if (weight >= 5001 && weight < 12000)
            {
                double extra = (weight - 5000);
                if (extra <= 1000)
                {
                    ship = kg5 + (kg5u * 1);
                    lbl_ship.Text = ship.ToString();
                }
                else if (extra > 1000)
                {
                    double my = (extra / 1000);
                    double aa = Math.Ceiling(my);
                    ship = (kg5 + (kg5u * aa));
                    lbl_ship.Text = ship.ToString();
                }
            }

        }
        double a1, b1, c1, i;
        double.TryParse(lbl_ref.Text, out a1);
        double.TryParse(lbl_closingfee.Text, out b1);
        double.TryParse(lbl_ship.Text, out c1);

        i = a1 + b1 + c1;
        lbl_RCS.Text = i.ToString();

        double GST, rcs, gst, per;
        per = 100;
        double.TryParse(lbl_RCS.Text, out rcs);
        double.TryParse(lbl_gst_per.Text, out gst);
        GST = ((rcs * gst) / per);
        lbl_GST.Text = GST.ToString();

        double total, GST_total;
        double.TryParse(lbl_GST.Text, out GST_total);
        total = rcs + GST_total;
        lbl_total.Text = total.ToString();

        double prod_price, you_make, profit, cost;
        double.TryParse(txt_prod_price.Text, out prod_price);

        you_make = prod_price - total;
        lbl_you_make.Text = you_make.ToString();
        double.TryParse(txt_cost.Text, out cost);
        profit = you_make - cost;

    }







    protected void lnk_budgetok_Click(object sender, EventArgs e)
    {
        dv_shipping.Visible = true;
        dv_RCS.Visible = false;
        dv_ship_by_budgetok.Visible = false;
    }
}