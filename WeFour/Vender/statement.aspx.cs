using System;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


public partial class Vender_statement : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    CRUD objcrud = new CRUD();
    string ssss = null;
    string str2, sel, dsgetdata;
    DateTime d1, d2;
    string n, n1;
    DataSet ds, outds;
    double qty = 0;
    double total = 0;
    double total_tax = 0;
    double finalamt = 0;
    double toshipment = 0, totcom = 0, totselling = 0, netsetamt = 0, tfixes = 0;

    protected void Page_PreLoad(object sender, EventArgs e)
    {
        login();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
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

    public void Bind()
    {
        double commisionfee = 0, fixedfee = 30, shipping = 0, collection_fee=0, canllation_fee = 0;


        con.Open();
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        //string vv = "select * from tblorderdetails where Convert(datetime,order_date,103) between '"+d1+"' and '"+d2+"'";

        string vv = "select * from tblorderitem where vender_emailid='" + ssss + "' and Status='Delivered'";

        ds = objcrud.dataset_(vv);
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

                str2 += @"select Pro_ID,Product_Name,Description,Tax,Weight,tblorderitem.*,tblorderdetails.*,tbl_group.* from " + tbnm + " INNER JOIN tblorderitem on tblorderitem.vender_emailid = '" + ssss + "' INNER JOIN tbl_group on tbl_group.group_name ='" + tbnm + "' inner join tblorderdetails  on tblorderitem.order_num_det = '" + num + "' where tblorderdetails.order_number = '" + no
                            + "' and " + tbnm + ".Pro_ID = '" + proid
                            + "' and  " + tbnm + ".Pro_ID=tblorderitem.Product_id and tblorderitem.Status='Delivered' and Convert(datetime,tblorderdetails.order_date,103)  between '" + d1 + "' and '" + d2 + "' union all ";

                //str2 += @"select Pro_ID,Product_Name,Description,Tax,Weight,tblorderitem.*,tblorderdetails.*,tbl_group.* from " + tbnm + " INNER JOIN tblorderitem on tblorderitem.vender_emailid = '" + ssss + "' INNER JOIN tbl_group on tbl_group.group_name ='" + tbnm + "' inner join tblorderdetails  on tblorderitem.order_num_det = '" + num + "' where tblorderdetails.order_number = '" + no
                //            + "' and " + tbnm + ".Pro_ID = '" + proid
                //            + "' and  " + tbnm + ".Pro_ID=tblorderitem.Product_id and tblorderitem.Status='Delivered' and Convert(datetime,tblorderdetails.order_date,103)  between '" + d1 + "' and '" + d2 + "' union all ";
            }
            sel = str2.Remove(str2.LastIndexOf(" union all "));
            dsgetdata = sel;
            dss = objcrud.dataset_(dsgetdata);
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
                            ww = we;
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
                        totselling += sp * order_qty;
                        totcom += (((sp * commisionfee) / 100));
                        toshipment += shipping * order_qty;
                        netsetamt += sp1 * order_qty;
                        tfixes += fixedfee * order_qty;
                        totalsellprice.Text = totselling.ToString("0.00");
                        totshipment.Text = toshipment.ToString("0.00");
                        totcommsion.Text = totcom.ToString("0.00");
                        nsetamt.Text = netsetamt.ToString("0.00");
                        netfixedfee.Text = tfixes.ToString("0.00");
                        collectionlb.Text = collection_fee.ToString("0.00");
                        cancellationlb.Text = canllation_fee.ToString("0.00");
                        //===========================================================================





                    }
                    else
                    {
                        total += 0;
                    }

                }
            }
            else
            {
                lblerror.Text = "No Data Found";
                lblerror.Visible = true;
                datatable.Visible = false;
            }

        }
        con.Close();

    }
    protected void cal_SelectionChanged(object sender, EventArgs e)
    {

        PopupControlExtender1.Commit(cal.SelectedDate.ToString("yyyy/MM/dd"));
        txtstart.Text = cal.SelectedDate.ToString("d'/'M'/'yyyy");
    }

    protected void calend_SelectionChanged(object sender, EventArgs e)
    {
        PopupControlExtender_end.Commit(calend.SelectedDate.ToString("yyyy/MM/dd"));
        txtend.Text = calend.SelectedDate.ToString("d'/'M'/'yyyy");
    }

    protected void btngenrate_Click(object sender, EventArgs e)
    {
        n = txtstart.Text;
        n1 = txtend.Text;
        d1 = Convert.ToDateTime(txtstart.Text);
        d2 = Convert.ToDateTime(txtend.Text);
        if (d1 < d2)
        {
            Bind();
            lblerror.Visible = false;
            datatable.Visible = true;
        }
        else
        {
            datatable.Visible = false;
            lblerror.Text = "End date should not be grether then Start Date!";
        }

    }

    protected void genratepdf_Click(object sender, EventArgs e)
    {
        d1 = Convert.ToDateTime(txtstart.Text);
        d2 = Convert.ToDateTime(txtend.Text);
        if (d1 < d2)
        {
            Bind();

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] {
                        new DataColumn("Description", typeof(string)),
                        new DataColumn("Credits(Rs)", typeof(string)),
                        new DataColumn("Debits(Rs)", typeof(string)),
                        new DataColumn("Net Setteld Amount(Rs)",  typeof(string))});
            //new DataColumn("Total",  typeof(string))});
            dt.Rows.Add("Total Selling Amount", totalsellprice.Text, "-", "-");
            dt.Rows.Add("Commission Amount", "-", totcommsion.Text, "-");
            dt.Rows.Add("Fixed Fee Amount", "-", netfixedfee.Text, "-");
            dt.Rows.Add("Shipment Charges", "-", totshipment.Text, "-");
            dt.Rows.Add("Collection Fee", "-", collectionlb.Text, "-");
            dt.Rows.Add("Cancellation Fee", "-", cancellationlb.Text, "-");

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();

                    //Generate Invoice (Bill) Header.
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2' align='center'>");

                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    //sb.Append("<tr><td><img src='~/img/logo_9.png'></td></tr>");
                    //sb.Append("<tr><td align = 'Left' style='background-color: #B9B9B9;color:#ffffff'><b>BudgetOk </b>");
                    //sb.Append("</td><td align = 'right' style='background-color: #B9B9B9;color:#ffffff'><b>BudgetOk Internet Pvt. Ltd<br>F-14,thakkar Arcade<br> sardar gunj Road<br>Anand, Gujarat 388001 </b>");
                    //sb.Append(DateTime.Now);
                    sb.Append("<tr><td align = 'Left'><b>BudgetOk </b>");
                    sb.Append("</td><td align = 'right'><b>BudgetOk Internet Pvt. Ltd<br>F-14,thakkar Arcade<br> sardar gunj Road<br>Anand, Gujarat 388001 </b>");
                    sb.Append(" </td></tr>");

                    //sb.Append("<tr><td><b>Invoice Start Date:- </b>");
                    //sb.Append(d1.Date.ToString("dd/MM/yyyy"));
                    //sb.Append("</td><td align = 'right'><b>Date: </b>");
                    //sb.Append(DateTime.Now.ToString("dd/MM/yyyy"));
                    sb.Append(" </td></tr>");
                    sb.Append("<tr><td colspan = '2' align = 'center'><b>Statement for " + d1.Date.ToString("dd/MM/yyyy") + " to " + d2.Date.ToString("dd/MM/yyyy") + " for Both Cash and Bank Account. </b>");
                    //sb.Append(d2.Date.ToString("dd/MM/yyyy"));
                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");

                    //Generate Invoice (Bill) Items Grid.
                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<th style = 'background-color: #006400;color:#ffffff'>");
                        sb.Append(column.ColumnName);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<td>");
                            sb.Append(row[column]);
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                    }
                    sb.Append("<tr><td align = 'right' colspan = '");
                    sb.Append(dt.Columns.Count - 1);
                    sb.Append("'>Total</td>");
                    sb.Append("<td>");
                    sb.Append(nsetamt.Text);
                    sb.Append("</td>");
                    sb.Append("</tr></table>");

                    //Export HTML String as PDF.
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Statement_" + DateTime.Now.ToString("dd/MM/yyyy") + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }

        }
    }
    
}