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
public partial class Vender_Payment : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    string ssss = null;
    CRUD objcrud = new CRUD();
    string sel, tab2, str2, get2, dsgetdata = null, srp;
    DataSet ds, outds;
    double qty = 0;
    double total = 0;
    double total_tax = 0;
    double finalamt = 0;
    protected void Page_PreLoad(object sender, EventArgs e)
    {

        login();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        nextpmtcash();
        //outstandingpmt();
        //unbillorder();
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


    public void nextpmtcash()
    {
        double commisionfee = 0, fixedfee = 30, shipping = 0;
        string today;
        con.Open();
        string sq = "select * from tblorderitem where vender_emailid='" + ssss + "' and Status ='Delivered'";
        ds = objcrud.dataset_(sq);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string num = ds.Tables[0].Rows[i]["order_num_det"].ToString();
                string tbnm = ds.Tables[0].Rows[i]["product_grp"].ToString();
                string proid = ds.Tables[0].Rows[i]["Product_id"].ToString();
                string[] tempstr = num.Split('N');
                string pno = "";
                string no = "";
                today = DateTime.Now.ToString("d/M/yyyy");
                for (int j = 0; j < tempstr.Length; j++)

                {
                    if (pno == "")
                    {
                        pno = tempstr[j] + "N";
                    }
                    else
                    {
                        no = tempstr[j];
                    }
                }
                str2 += @"select Pro_ID,Product_Name,Description,Tax,Weight,tblorderitem.*,tblorderdetails.*,tbl_group.* from " + tbnm + " INNER JOIN tblorderitem on tblorderitem.vender_emailid = '" + ssss + "' INNER JOIN tbl_group on tbl_group.group_name ='" + tbnm + "' inner join tblorderdetails  on tblorderitem.order_num_det = '" + num + "' where tblorderdetails.order_number = '" + no
                            + "' and " + tbnm + ".Pro_ID = '" + proid
                            + "' and  " + tbnm + ".Pro_ID=tblorderitem.Product_id and tblorderitem.Status='Delivered' and tblorderdetails.order_date!='"
                            + today + "' union all ";
            }
            sel = str2.Remove(str2.LastIndexOf(" union all "));
            dsgetdata = sel;
            DataSet dss = objcrud.dataset_(dsgetdata);
            if (dss.Tables[0].Rows.Count > 0)
            {
                for (int m = 0; m < dss.Tables[0].Rows.Count; m++)
                {

                    double order_qty = Convert.ToDouble(dss.Tables[0].Rows[m]["order_quantity"].ToString());
                    double sp = Convert.ToDouble(dss.Tables[0].Rows[m]["sell_price"].ToString());
                    double return_qty = Convert.ToDouble(dss.Tables[0].Rows[m]["Return_qty"].ToString());
                    double taxamt = Convert.ToDouble(dss.Tables[0].Rows[m]["Tax"].ToString());
                    commisionfee = Convert.ToDouble(dss.Tables[0].Rows[m]["Commission_fee"].ToString());
                    string weight = dss.Tables[0].Rows[m]["Weight"].ToString();
                    if (order_qty > 0 && return_qty >= 0 && sp > 0)
                    {
                        double we = 0, ww = 0;
                        string mesur = null;
                        string[] weig = weight.Split(',');
                        for (int i = 0; i < weig.Length; i++)
                        {
                            if (we == 0)
                            {
                                we = Convert.ToDouble(weig[i].ToString());
                            }
                            else
                            {
                                mesur = weig[i].ToString();
                            }
                        }
                        if (mesur == "Gram")
                        {
                            ww = (we / 1000);
                        }
                        else if (mesur == "Kilo-Gram")
                        {
                            ww = we * 1000;
                        }

                        if (ww <= 500)
                        {
                            shipping = 40;
                        }
                        else if (ww >= 501 && ww < 5000)
                        {
                            double extra1 = (ww - 500);
                            if (extra1 <= 500)
                            {
                                shipping = 40 + (40 * 1);
                            }
                            else if (extra1 > 500)
                            {
                                double my = (extra1 / 500);
                                double aa = Math.Ceiling(my);
                                shipping = (40 + (40 * aa));
                            }
                        }
                        else if (ww == 5000)
                        {
                            shipping = 90;
                        }
                        else if (ww >= 5001 && ww < 12000)
                        {
                            double extra1 = (ww - 5000);
                            double my = (extra1 / 1000);
                            double aa = Math.Ceiling(my);
                            shipping = (90 + (19 * aa));
                        }

                        else if (ww <= 12000)
                        {
                            shipping = 210;
                        }
                        else if (ww >= 12001)
                        {
                            double extra = (ww - 12000);
                            if (extra <= 1000)
                            {
                                shipping = 210 + (1 * 12.5);
                            }
                            else if (extra > 1000)
                            {
                                double my = (extra / 1000);
                                double aa = Math.Ceiling(my);
                                shipping = (200 + (aa * 2.5));
                            }
                        }
                        double sp1 = sp - (((sp * commisionfee) / 100) + (fixedfee + shipping));
                        total += sp1 * order_qty;
                        finalamt = total;
                    }
                    else
                    {
                        total += 0;
                    }

                }
                lblcodpmt.Text += finalamt.ToString();
                lbldate.Text = DateTime.Now.AddDays(7).ToString("d-MMMM ");
            }
        }
        con.Close();
    }
    public void nextpmtbank()
    {

        con.Open();
        string sq = "select * from tblorderitem where vender_emailid='" + ssss + "' and Status ='Delivered'";
        ds = objcrud.dataset_(sq);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string num = ds.Tables[0].Rows[i]["order_num_det"].ToString();
                string tbnm = ds.Tables[0].Rows[i]["product_grp"].ToString();
                string proid = ds.Tables[0].Rows[i]["Product_id"].ToString();
                string[] tempstr = num.Split('N');
                string pno = "";
                string no = "";
                string today = DateTime.Now.ToString("d/M/yyyy");
                for (int j = 0; j < tempstr.Length; j++)

                {
                    if (pno == "")
                    {
                        pno = tempstr[j] + "N";
                    }
                    else
                    {
                        no = tempstr[j];
                    }
                }
                str2 += @"select Pro_ID,Product_Name,Group_id,Description,Tax,tblorderitem.*,tblorderdetails.* from " + tbnm + " INNER JOIN tblorderitem on tblorderitem.vender_emailid = '" + ssss + "' inner join tblorderdetails  on tblorderitem.order_num_det = '" + num + "' where tblorderdetails.order_number = '" + no
                            + "' and " + tbnm + ".Pro_ID = '" + proid
                            + "' and  " + tbnm + ".Pro_ID=tblorderitem.Product_id and tblorderdetails.order_deliverytype='Bank'  and tblorderdetails.order_date!='"
                            + today + "' union all ";
            }
            sel = str2.Remove(str2.LastIndexOf(" union all "));
            dsgetdata = sel;
            DataSet dss = objcrud.dataset_(dsgetdata);
            if (dss.Tables[0].Rows.Count > 0)
            {
                for (int m = 0; m < dss.Tables[0].Rows.Count; m++)
                {

                    double order_qty = Convert.ToDouble(dss.Tables[0].Rows[m]["order_quantity"].ToString());
                    double sp = Convert.ToDouble(dss.Tables[0].Rows[m]["sell_price"].ToString());
                    double return_qty = Convert.ToDouble(dss.Tables[0].Rows[m]["Return_qty"].ToString());
                    double taxamt = Convert.ToDouble(dss.Tables[0].Rows[m]["Tax"].ToString());
                    if (order_qty > 0 && return_qty >= 0 && sp > 0)
                    {

                        total += sp * order_qty;
                        total_tax = (total * taxamt) / 100;
                        finalamt = total + total_tax;
                    }
                    else
                    {
                        total += 0;
                    }

                }
                lblcodpmt.Text += finalamt.ToString();
                //lblbl.Text += finalamt.ToString();
                //gdorder.DataSource = dss;
                //gdorder.DataBind();
            }
        }
        con.Close();

    }
    public void outstandingpmt()
    {
        double outtotal = 0;
        double finalout = 0;
       
        double commisionfee1 = 0, fixedfee1 = 30, shipping1 = 0;
        string outstr = null, dsoutdata = null;
        con.Open();
        string outpmt = "select * from tblorderitem where vender_emailid='" + ssss + "' and Status ='Delivered' or Status='Dispatch'";
        outds = objcrud.dataset_(outpmt);
        if (outds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < outds.Tables[0].Rows.Count; i++)
            {
                string num = outds.Tables[0].Rows[i]["order_num_det"].ToString();
                string tbnm = outds.Tables[0].Rows[i]["product_grp"].ToString();
                string proid = outds.Tables[0].Rows[i]["Product_id"].ToString();
                string[] tempstr = num.Split('N');
                string pno = "";
                string no = "";
                string today = DateTime.Now.ToString("d/M/yyyy");
                for (int j = 0; j < tempstr.Length; j++)

                {
                    if (pno == "")
                    {
                        pno = tempstr[j] + "N";
                    }
                    else
                    {
                        no = tempstr[j];
                    }
                }
                outstr += @"select Pro_ID,Product_Name,Description,Weight,Tax,tblorderitem.*,tblorderdetails.*,tbl_group.* from "
                            + tbnm + " INNER JOIN tblorderitem on tblorderitem.vender_emailid = '"
                            + ssss + "'  INNER JOIN tbl_group on tbl_group.group_name ='" + tbnm
                            + "'inner join tblorderdetails on tblorderitem.order_num_det = '"
                            + num + "' where tblorderdetails.order_number = '" + no
                            + "' and " + tbnm + ".Pro_ID = '" + proid
                            + "' and  " + tbnm + ".Pro_ID=tblorderitem.Product_id and tblorderdetails.order_date!='"
                            + today + "' union all ";
            }
            string selout = outstr.Remove(outstr.LastIndexOf(" union all "));
            dsoutdata = selout;
            DataSet dssout = objcrud.dataset_(dsoutdata);
            if (dssout.Tables[0].Rows.Count > 0)
            {
                for (int m = 0; m < dssout.Tables[0].Rows.Count; m++)
                {

                    double order_qty = Convert.ToDouble(dssout.Tables[0].Rows[m]["order_quantity"].ToString());
                    double spn = Convert.ToDouble(dssout.Tables[0].Rows[m]["sell_price"].ToString());
                    double return_qty = Convert.ToDouble(dssout.Tables[0].Rows[m]["Return_qty"].ToString());
                    double taxamt = Convert.ToDouble(dssout.Tables[0].Rows[m]["Tax"].ToString());
                    commisionfee1 = Convert.ToDouble(dssout.Tables[0].Rows[m]["Commission_fee"].ToString());
                    string weight1 = dssout.Tables[0].Rows[m]["Weight"].ToString();
                    if (order_qty > 0 && return_qty >= 0 && spn > 0)
                    {
                        double we1 = 0, ww1 = 0;
                        string mesur1 = null;
                        string[] weig1 = weight1.Split(',');
                        for (int n = 0; n < weig1.Length; n++)
                        {
                            if (we1 == 0)
                            {
                                we1 = Convert.ToDouble(weig1[n].ToString());
                            }
                            else
                            {
                                mesur1 = weig1[n].ToString();
                            }
                        }
                        if (mesur1 == "Gram")
                        {
                            ww1 = (we1 / 1000);
                        }
                        else if (mesur1 == "Kilo-Gram")
                        {
                            ww1 = we1 * 1000;
                        }
                        if (ww1 <= 500)
                        {
                            shipping1 = 40;
                        }
                        else if (ww1 >= 501 && ww1 < 5000)
                        {
                            double extra12 = (ww1 - 500);
                            if (extra12 <= 500)
                            {
                                shipping1 = 40 + (40 * 1);
                            }
                            else if (extra12 > 500)
                            {
                                double my1 = (extra12 / 500);
                                double aa1 = Math.Ceiling(my1);
                                shipping1 = (40 + (40 * aa1));
                            }
                        }
                        else if (ww1 == 5000)
                        {
                            shipping1 = 90;
                        }
                        else if (ww1 >= 5001 && ww1 < 12000)
                        {
                            double extra1 = (ww1 - 5000);
                            double my1 = (extra1 / 1000);
                            double aa1 = Math.Ceiling(my1);
                            shipping1 = (90 + (19 * aa1));
                        }

                        else if (ww1 <= 12000)
                        {
                            shipping1 = 210;
                        }
                        else if (ww1 >= 12001)
                        {
                            double extraa = (ww1 - 12000);
                            if (extraa <= 1000)
                            {
                                shipping1 = 210 + (1 * 12.5);
                            }
                            else if (extraa > 1000)
                            {
                                double my1 = (extraa / 1000);
                                double aa1 = Math.Ceiling(my1);
                                shipping1 = (200 + (aa1 * 2.5));
                            }
                        }


                        double sp2 = spn - (((spn * commisionfee1) / 100) + (fixedfee1 + shipping1));
                        outtotal += sp2 * order_qty;

                        finalout = outtotal;

                    }
                    else
                    {
                        outtotal += 0;
                    }

                }
                Label4.Text += finalout.ToString();
                //lblbl.Text += finalamt.ToString();
                //gdorder.DataSource = dss;
                //gdorder.DataBind();
            }
        }
        con.Close();

    }
    public void unbillorder()
    {
        string ubstr = null, ubstr1 = null;
        DataSet ubds = null;
        con.Open();
        ubstr = "select * from tblorderitem where vender_emailid='" + ssss + "' and Status ='Conform'";
        ubds = objcrud.dataset_(ubstr);
        if (ubds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ubds.Tables[0].Rows.Count; i++)
            {
                string num = ubds.Tables[0].Rows[i]["order_num_det"].ToString();
                string tbnm = ubds.Tables[0].Rows[i]["product_grp"].ToString();
                string proid = ubds.Tables[0].Rows[i]["Product_id"].ToString();
                string[] tempstr = num.Split('N');
                string pno = "";
                string no = "";
                string today = DateTime.Now.ToString("d/M/yyyy");
                for (int j = 0; j < tempstr.Length; j++)

                {
                    if (pno == "")
                    {
                        pno = tempstr[j] + "N";
                    }
                    else
                    {
                        no = tempstr[j];
                    }
                }
                ubstr1 += @"select Pro_ID,Product_Name,Group_id,Description,Tax,tblorderitem.*,tblorderdetails.* from " + tbnm + " INNER JOIN tblorderitem on tblorderitem.vender_emailid = '" + ssss + "' inner join tblorderdetails  on tblorderitem.order_num_det = '" + num + "' where tblorderdetails.order_number = '" + no
                            + "' and " + tbnm + ".Pro_ID = '" + proid
                            + "' and  " + tbnm + ".Pro_ID=tblorderitem.Product_id and tblorderitem.Status='Conform' and tblorderdetails.order_date!='"
                            + today + "' union all ";
            }
            sel = ubstr1.Remove(ubstr1.LastIndexOf(" union all "));
            dsgetdata = sel;
            DataSet dssub = objcrud.dataset_(dsgetdata);
            if (dssub.Tables[0].Rows.Count > 0)
            {
                for (int m = 0; m < dssub.Tables[0].Rows.Count; m++)
                {

                    //double order_qty = Convert.ToDouble(dss.Tables[0].Rows[m]["order_quantity"].ToString());
                    //double sp = Convert.ToDouble(dss.Tables[0].Rows[m]["sell_price"].ToString());
                    //double return_qty = Convert.ToDouble(dss.Tables[0].Rows[m]["Return_qty"].ToString());
                    //double taxamt = Convert.ToDouble(dss.Tables[0].Rows[m]["Tax"].ToString());
                    //if (order_qty > 0 && return_qty >= 0 && sp > 0)
                    //{

                    //    total += sp * order_qty;
                    //    total_tax = (total * taxamt) / 100;
                    //    finalamt = total + total_tax;
                    //}
                    //else
                    //{
                    //    total += 0;
                    //}
                    Label8.Text = dssub.Tables[0].Rows.Count.ToString();

                }
            }
        }
        con.Close();
    }
    public void lastpmt() { }

}