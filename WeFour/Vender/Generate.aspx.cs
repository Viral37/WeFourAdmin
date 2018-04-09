using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using ClosedXML.Excel;
using System.Diagnostics;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using iTextSharp.text;


//using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
//using System.Text.RegularExpressions;
public partial class Vender_Generate : System.Web.UI.Page
{
    CRUD objcrud = new CRUD();
    string tbl, tbl1, str, get, gettxt, dsget, prod_id, status, product_grp, ssss, ord_qnt, wgt, sell_price, comm_per;
    double tsp, comms, comm_price, final_comm, totcomm, comm_with_price;
    Double weight, gms, kg5, kg12, gms500u, kg5u, kg12u, ship, getwgt, finalwgt, wgtconvert, kg1, mult, finalship, totship, tot, closing_fee, close, finalclose, totclosing, totclo, close1, close2, close3, taxable, Gst1, totalget, per, comm, finalcomm, h194, hper, c194, cper, i194, iper;
    Double ship_charge, comm_fee, fix_fee, coll_fee, canc_fee, emi_fee, fee_dis, pick_fee, storage_fee, removal_fee, next_fee, same_fee, service_fee, tdsgn;
    DataSet dsnew = new DataSet();
    int x, index, y, y1, rngborder;
    string r, rtax;
    string getgroupD, dsgroupD, dsgetD;
    DataSet dsnewD = new DataSet();
    string getgroupDD, dsgroupDD, dsgetDD;
    DataSet dsnewDD = new DataSet();
    string name, reg_Add, email, num, cdate, idate, business;
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["ReportName"] = Request.QueryString["ReportName"];
        if (Request.QueryString["ReportName"] != null)
        {
            lbl_rname.InnerText = ViewState["ReportName"].ToString();
            if (Request.QueryString["ReportName"] == "B-Assured Reports" || Request.QueryString["ReportName"] == "Unsold listings")
            {
                dvbnk.Visible = true;
            }
            else
            {
                dvdt.Visible = true;
            }
        }

    }

    protected void btn_generate_Click(object sender, EventArgs e)
    {
        XLWorkbook wb = new XLWorkbook();
        DataTable dt1 = new DataTable();
        var help = wb.Worksheets.Add("Help");

        var ws = wb.Worksheets.Add(ViewState["ReportName"].ToString());

        ws.ShowGridLines = false;

        ws.ColumnWidth = 20;
        ws.Cell("C1").Value = ViewState["ReportName"].ToString();
        ws.Cell("C1").Style.Fill.BackgroundColor = XLColor.ForestGreen;
        ws.Cell("C1").Style.Font.FontColor = XLColor.White;
        ws.Cell("C1").Style.Font.Bold = true;
        ws.Cell("C1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        ws.Cell("C1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        ws.Range("C1:E2").Merge();
        // Merge a row
        string getd = hd.Value;


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

            string get = @"select  * 
        from tbl_login as tb
        inner join  tbl_business as t
        on tb.email_id = t.email_id
        where tb.email_id='" + ssss + "'";

            DataSet dsdetail = objcrud.dataset_(get);

            if (dsdetail.Tables[0].Rows.Count > 0)
            {

                for (int j = 0; j < dsdetail.Tables[0].Rows.Count; j++)
                {
                    ws.Cell("A3").Value = dsdetail.Tables[0].Rows[j]["username"].ToString();
                    ws.Range("A3:G3").Row(1).Merge();
                    ws.Cell("A4").Value = dsdetail.Tables[0].Rows[j]["reg_add"].ToString() + "\n" + ssss + "\n" + "+91" + dsdetail.Tables[0].Rows[j]["contact"].ToString();
                    ws.Cell("A4").Style.Alignment.WrapText = true;
                    ws.Cell("A4").Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                    ws.Range("A4:B8").Merge();
                }
            }
        }
        if (Request.QueryString["ReportName"] == "B-Assured Reports")
        {

            help.ColumnWidth = 20;
            var col1 = help.Column("B");
            col1.Width = 60;
            help.Range("A3:A4").Merge();
            help.Range("B3:B4").Merge();
            help.Cell("A3").Value = "Dear Seller,";
            help.Cell("B3").Value = "Description";
            help.Range("A3:B4").Style.Font.Bold = true;
            help.Cell("A6").Value = "Use of this report";
            help.Cell("B6").Value = @"You can check the status of BudgetOk Assured Badge for the products in BudgetOk Fulfilment and Smart Fulfilment.You can view the parameters of product quality (returns, ratings) that determine the badge.Please note that you will not receive any delivery charges";
            help.Cell("A7").Value = "Name";
            help.Cell("B7").Value = "Vender Name";
            help.Cell("A8").Value = "Address";
            help.Cell("B8").Value = "Register business Address";
            help.Cell("A9").Value = "Email Id";
            help.Cell("B9").Value = "Vender Email Id";
            help.Cell("A10").Value = "Contact No";
            help.Cell("B10").Value = "Vender Contact Number";
            help.Cell("A11").Value = "Category";
            help.Cell("B11").Value = "Category of the product";
            help.Cell("A12").Value = "Vertical";
            help.Cell("B12").Value = "Vertical of the product";
            help.Cell("A13").Value = "Brand";
            help.Cell("B13").Value = "Brand of the product";
            help.Cell("A14").Value = "SKU";
            help.Cell("B14").Value = "Seller defined identifier for their products";
            help.Cell("A15").Value = "BSN";
            help.Cell("B15").Value = "BudgetOk defined identifer for products";
            help.Cell("A16").Value = "Product Name";
            help.Cell("B16").Value = "BudgetOk defined identifer for products";
            help.Cell("A17").Value = "Product Name";
            help.Cell("B17").Value = @"Type of order fulfilment depending on source and seller involvement
             FBF - Orders fulfilled by BudgetOk
            - FBF_Lite - Orders fulfilled by Seller warehouse";
            help.Cell("A18").Value = "B-Assured Badge";
            help.Cell("B18").Value = "Status of BudgetOk Assured Badge - Yes / No / Warning";
            help.Cell("A19").Value = "Ratings Health";
            help.Cell("B19").Value = "Status of Ratings for the product - Good / Medium / Poor";
            help.Cell("A21").Value = "Returns Health";
            help.Cell("B21").Value = "Status of Returns for the product - Good / Medium / Poor";

            DataTable dt = new DataTable();
            dt.Columns.Add("Category");
            dt.Columns.Add("Vertical");
            dt.Columns.Add("Brand");
            dt.Columns.Add("Seller SKU");
            dt.Columns.Add("BSN");
            dt.Columns.Add("Service Profile");


            ws.Range("A10:J10").Style.Font.Bold = true;
            ws.Cell("A10").Value = "Category";
            ws.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("B10").Value = "Vertical";
            ws.Cell("B10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("C10").Value = "Brand";
            ws.Cell("C10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("D10").Value = "Seller SKU";
            ws.Cell("D10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("E10").Value = "Product Id";
            ws.Cell("E10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("F10").Value = "Product Name";
            ws.Cell("F10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("G10").Value = "Service Profile";
            ws.Cell("G10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("H10").Value = "B-Assured Badge";
            ws.Cell("H10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("I10").Value = "Ratings Health";
            ws.Cell("I10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("J10").Value = "Returns Health";
            ws.Cell("J10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            
        }
        else if (Request.QueryString["ReportName"] == "Unsold listings")
        {


            help.ColumnWidth = 20;
            var col1 = help.Column("B");
            col1.Width = 60;
            help.Range("A3:A4").Merge();
            help.Range("B3:B4").Merge();
            help.Cell("A3").Value = "Dear Seller,";
            help.Cell("B3").Value = "Description";
            help.Range("A3:B4").Style.Font.Bold = true;
            help.Cell("A6").Value = "Use of this report";
            help.Cell("B6").Value = "Information of listings created but have not had a sale";
            help.Cell("A7").Value = "Name";
            help.Cell("B7").Value = "Vender Name";
            help.Cell("A8").Value = "Address";
            help.Cell("B8").Value = "Register business Address";
            help.Cell("A9").Value = "Email Id";
            help.Cell("B9").Value = "Vender Email Id";
            help.Cell("A10").Value = "Contact No";
            help.Cell("B10").Value = "Vender Contact Number";
            help.Cell("A11").Value = "Product Id";
            help.Cell("B11").Value = "Id of the Product";
            help.Cell("A12").Value = "Product Name";
            help.Cell("B12").Value = "Name Of the Product";
            help.Cell("A13").Value = "Product Group";
            help.Cell("B13").Value = "Group of the Product";
            help.Cell("A14").Value = "Selling Price";
            help.Cell("B14").Value = "Selling Price of Product";
            help.Cell("A15").Value = "Retail Price";
            help.Cell("B15").Value = "Retail Price of Product";
            help.Cell("A16").Value = "GST";
            help.Cell("B16").Value = "GST of the Product";
            help.Cell("A17").Value = "Stock";
            help.Cell("B17").Value = "Stock of the Product";

            ws.Range("A10:G10").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

            ws.Range("A10:G10").Style.Font.Bold = true;
            ws.Cell("A10").Value = "Product Id";
            ws.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("B10").Value = "Product Name";
            ws.Cell("B10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("C10").Value = "Product Group";
            ws.Cell("C10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("D10").Value = "Selling_Price";
            ws.Cell("D10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("E10").Value = "MRP";
            ws.Cell("E10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("F10").Value = "GST";
            ws.Cell("F10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("G10").Value = "Stock";
            ws.Cell("G10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


            //str = "select " + tbl1 + ".Pro_ID," + tbl1 + ".Product_Name," + tbl1 + ".Group_Id," + tbl1 + ".Selling_price," + tbl1 + ".Retail_Price," + tbl1 + ".Tax," + tbl1 + ".Stock from " + tbl1;
            // get = str + " where " + tbl1 + ".Pro_ID not in (select Product_id from tblorderitem) and Status IN('Approve with Brand','Approve without Brand') and Vender_Email_Id='" + ssss + "'";
            // dsget += get;

            string dsget = @"select		Pro.Product_id,Pro.Product_Name,cg.cat_grp_name,Pro.Your_selling_price,Pro.MRP,Pro.GST,Pro.Stocks 
                             from		Products as Pro
                             inner join Category_Group as cg
                             on			cg.cat_grp_id=Pro.Cat_group_id
                             where		Pro.Product_id not in (select Product_id from tblorderitem) and Product_status IN('Approve with Brand','Approve without Brand') and Vender_id='" + ssss + "' and Product_Name !='NULL'";
            dsnew = objcrud.dataset_(dsget);
            int x = 10;
            if (dsnew.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsnew.Tables[0].Rows.Count; i++)
                {
                    x++;

                    int index = x + 1;
                    ws.Cell("A" + index).Value = dsnew.Tables[0].Rows[i]["Product_ID"].ToString();
                    ws.Cell("A" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell("B" + index).Value = dsnew.Tables[0].Rows[i]["Product_Name"].ToString();
                    ws.Cell("B" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell("C" + index).Value = dsnew.Tables[0].Rows[i]["cat_grp_name"].ToString();
                    ws.Cell("C" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell("D" + index).Value = dsnew.Tables[0].Rows[i]["Your_selling_price"].ToString();
                    ws.Cell("D" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell("E" + index).Value = dsnew.Tables[0].Rows[i]["MRP"].ToString();
                    ws.Cell("E" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell("F" + index).Value = dsnew.Tables[0].Rows[i]["GST"].ToString();
                    ws.Cell("F" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell("G" + index).Value = dsnew.Tables[0].Rows[i]["Stocks"].ToString();
                    ws.Cell("G" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }
                int insx = 10;
                int ins = insx + 1;
                int cnt = ins + dsnew.Tables[0].Rows.Count;
                ws.Range("A" + ins + ":" + "G" + cnt).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range("A" + cnt + ":" + "G" + cnt).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            }


        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + ViewState["ReportName"].ToString() + "_" + DateTime.Today.ToString("dd-MM-yyyy") + ".xlsx");
        MemoryStream MyMemoryStream = new MemoryStream();

        wb.SaveAs(MyMemoryStream);
        MyMemoryStream.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
    }





    protected void btn_report_Click(object sender, EventArgs e)
    {
        XLWorkbook wb = new XLWorkbook();
        DataTable dt1 = new DataTable();
        coll_fee = 0;
        canc_fee = 0;
        emi_fee = 0;
        fee_dis = 0;
        pick_fee = 0;
        storage_fee = 0;
        removal_fee = 0;
        next_fee = 0;
        same_fee = 0;
        service_fee = 0;

        var help = wb.Worksheets.Add("Help");
        help.Protect();
        string getd = hd.Value;

        string start = getd.Substring(0, getd.IndexOf("-"));
        string end = getd.Substring(getd.IndexOf("-") + 1);
        string ssss = null;
        var ws = wb.Worksheets.Add(Request.QueryString["ReportName"]);
        ws.ShowGridLines = false;
        ws.Protect();
        ws.Cell("C1").Value = Request.QueryString["ReportName"];
        ws.Cell("C1").Style.Fill.BackgroundColor = XLColor.ForestGreen;
        ws.Cell("C1").Style.Font.FontColor = XLColor.White;
        ws.Cell("C1").Style.Font.Bold = true;
        ws.Cell("C1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        ws.Cell("C1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        ws.Range("C1:E2").Merge();
        // Merge a row

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

            string get = @"select  * 
        from tbl_login as tb
        inner join  tbl_business as t
        on tb.email_id = t.email_id
        where tb.email_id='" + ssss + "'";

            DataSet dsdetail = objcrud.dataset_(get);

            if (dsdetail.Tables[0].Rows.Count > 0)
            {

                for (int j = 0; j < dsdetail.Tables[0].Rows.Count; j++)
                {
                    name = dsdetail.Tables[0].Rows[j]["username"].ToString();
                    reg_Add = dsdetail.Tables[0].Rows[j]["reg_add"].ToString();
                    email = ssss;
                    num = dsdetail.Tables[0].Rows[j]["contact"].ToString();
                    cdate = DateTime.Today.ToString("dd/MM/yyyy");
                    idate = start + "-" + end;
                    business = dsdetail.Tables[0].Rows[j]["buss_name"].ToString();


                    ws.Cell("A3").Value = name;
                    ws.Range("A3:G3").Row(1).Merge();
                    ws.Cell("A4").Value = reg_Add + "\n" + email + "\n" + "+91" + num;
                    ws.Cell("A4").Style.Alignment.WrapText = true;
                    ws.Cell("A4").Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                    ws.Cell("A5").Value = ssss;
                    ws.Cell("A5").Style.Alignment.WrapText = true;
                    ws.Cell("A5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                    ws.Range("A4:B8").Merge();
                    ws.Cell("C4").Value = "Invoice Date: " + cdate;
                    ws.Cell("C4").RichText.Substring(13, 10).SetFontColor(XLColor.ForestGreen);
                    ws.Cell("C4").RichText.Substring(13, 10).SetBold();
                    ws.Range("C4:D4").Row(1).Merge();
                    ws.Cell("C4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Cell("C5").Value = "Invoice Period: " + idate;
                    ws.Cell("C5").RichText.Substring(15, 23).SetFontColor(XLColor.ForestGreen);
                    ws.Cell("C5").RichText.Substring(15, 23).SetBold();
                    ws.Cell("C5").Style.Font.Bold = true;
                    ws.Range("C5:D5").Row(1).Merge();
                    ws.Cell("C6").Value = "Business Name: " + business;
                    ws.Cell("C6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Range("C6:D6").Row(1).Merge();
                    //ws.Cell("C6").RichText.Substring(15, 6).SetFontColor(XLColor.ForestGreen);
                    //ws.Cell("C6").RichText.Substring(15, 6).SetBold();
                    ws.Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                }

            }


            ws.ColumnWidth = 20;
            if (Request.QueryString["ReportName"] == "Commision Invoices")
            {
                help.ColumnWidth = 20;
                var col1 = help.Column("B");
                col1.Width = 55;
                help.Range("A3:A4").Merge();
                help.Range("B3:B4").Merge();
                help.Cell("A3").Value = "Dear Seller,";
                help.Cell("B3").Value = "Description";
                help.Range("A3:B4").Style.Font.Bold = true;

                help.Cell("A6").Value = "Use of this report";
                help.Cell("B6").Value = "This report provides details monthly Total Commision Price";
                help.Cell("A7").Value = "Name";
                help.Cell("B7").Value = "Vender Name";
                help.Cell("A8").Value = "Address";
                help.Cell("B8").Value = "Register business Address";
                help.Cell("A9").Value = "Email Id";
                help.Cell("B9").Value = "Vender Email Id";
                help.Cell("A10").Value = "Contact No";
                help.Cell("B10").Value = "Vender Contact Number";
                help.Cell("A11").Value = "Invoice Date";
                help.Cell("B11").Value = "Created Date";
                help.Cell("A12").Value = "Invoice Period";
                help.Cell("B12").Value = "Invoice Period";
                help.Cell("A13").Value = "Product Id";
                help.Cell("B13").Value = "Id of the Product";
                help.Cell("A14").Value = "Product Name";
                help.Cell("B14").Value = "Name Of the Product";
                help.Cell("A15").Value = "Product Group";
                help.Cell("B15").Value = "Group of the Product";
                help.Cell("A16").Value = "Qty";
                help.Cell("B16").Value = "Quantity Of the Product";
                help.Cell("A17").Value = "%";
                help.Cell("B17").Value = "Commision In Percentage";
                help.Cell("A18").Value = "Commision Amount";
                help.Cell("B18").Value = "Commision Amount on particular Product";
                help.Cell("A19").Value = "Selling Price";
                help.Cell("B19").Value = "Product Selling Price";
                help.Cell("A20").Value = "Final Commision";
                help.Cell("B20").Value = "Final Commision";

                ws.Cell("G7").Value = "Total:";
                ws.Cell("G7").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                ws.Cell("G7").Style.Font.Bold = true;

                ws.Range("A10:H10").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                ws.Range("A10:H10").Style.Font.Bold = true;
                ws.Cell("A10").Value = "Product Id";
                ws.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("B10").Value = "Product Name";
                ws.Cell("B10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("C10").Value = "Product Group";
                ws.Cell("C10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("D10").Value = "Qty";
                ws.Cell("D10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("E10").Value = "%";
                ws.Cell("E10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("F10").Value = "Commision Amount";
                ws.Cell("F10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("G10").Value = "Selling Price";
                ws.Cell("G10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("H10").Value = "Final Commision";
                ws.Cell("H10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                string getnew = @"select		distinct toi.Product_id,toi.Status,cg.cat_grp_name,toi.order_quantity,tod.order_date,toi.sell_price,pro.P_weight,pro.Product_Name,pro.GST,tc.commission_fee 
                                  from		    tblorderitem as toi 
                                  inner join	tblorderdetails as tod 
                                  on			toi.order_num_det=concAT(tod.prefix,tod.order_number)
                                  left join	    Products as pro
                                  on			pro.Product_id=toi.Product_id 
                                  inner join    Category_Group as cg
                                  on			cg.cat_grp_id=pro.Cat_group_id
                                  inner join	Category as tc 
                                  on			tc.cat_id = pro.Sub_cat_id
                                  where         Convert(datetime,tod.order_date,103) BETWEEN Convert(datetime,'" + start + "',103) AND Convert(datetime,'" + end + "',103) and toi.vender_emailid = '" + ssss + "' and toi.Status = 'Delivered' and pro.P_weight!= 'NULL'";
                dsnew = objcrud.dataset_(getnew);
                x = 10;
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < dsnew.Tables[0].Rows.Count; k++)
                    {
                        x++;

                        index = x;
                        ws.Cell("A" + index).Value = dsnew.Tables[0].Rows[k]["Product_id"].ToString();

                        ws.Cell("A" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("B" + index).Value = dsnew.Tables[0].Rows[k]["Product_Name"].ToString();
                        ws.Cell("B" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("C" + index).Value = dsnew.Tables[0].Rows[k]["cat_grp_name"].ToString();
                        ws.Cell("C" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("D" + index).Value = dsnew.Tables[0].Rows[k]["order_quantity"].ToString();
                        ws.Cell("D" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("E" + index).Value = dsnew.Tables[0].Rows[k]["commission_fee"].ToString();
                        ws.Cell("E" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        prod_id = dsnew.Tables[0].Rows[k]["Product_id"].ToString();
                        product_grp = dsnew.Tables[0].Rows[k]["cat_grp_name"].ToString();
                        ord_qnt = dsnew.Tables[0].Rows[k]["order_quantity"].ToString();
                        wgt = dsnew.Tables[0].Rows[k]["P_weight"].ToString();
                        sell_price = dsnew.Tables[0].Rows[k]["sell_price"].ToString();
                        comm_per = dsnew.Tables[0].Rows[k]["commission_fee"].ToString();
                        double weight;
                        double.TryParse(wgt, out weight);
                        double.TryParse(comm_per, out comm_price);
                        int per = 100;
                        comms = ((Convert.ToDouble(sell_price) * comm_price) / per);
                        final_comm = (comms * Convert.ToDouble(ord_qnt));
                        ws.Cell("F" + index).Value = comms;
                        ws.Cell("F" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("G" + index).Value = sell_price;
                        ws.Cell("G" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("H" + index).Value = final_comm;
                        ws.Cell("H" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        r += "H" + index + ":";
                    }
                    if (r.EndsWith(":"))
                    {
                        r = r.Remove(r.LastIndexOf(":"));

                    }
                    y++;
                    y = index + 2;
                    y1 = y + 1;
                    //totcomm = totcomm + final_comm;
                    ws.Cell("G" + y).Value = "Total:";
                    ws.Cell("G" + y).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Cell("G" + y).Style.Font.Bold = true;
                    //ws.Cell("G" + y1).Value = "Comm:";
                    //ws.Cell("G" + y1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    //ws.Cell("G" + y1).Style.Font.Bold = true;
                    ws.Cell("H" + y).SetFormulaA1("= SUM(" + r + ")");
                    ws.Cell("H" + y).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    ws.Cell("H7").SetFormulaA1("= SUM(" + r + ")");
                    ws.Cell("H7").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    int insx = 10;
                    int ins = insx;
                    int cnt = ins + dsnew.Tables[0].Rows.Count;
                    ws.Range("A" + ins + ":" + "H" + cnt).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Range("A" + ins + ":" + "H" + cnt).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                }


            }
            else if (Request.QueryString["ReportName"] == "Orders")
            {
                help.ColumnWidth = 20;
                var col1 = help.Column("B");
                col1.Width = 55;
                help.Range("A3:A4").Merge();
                help.Range("B3:B4").Merge();
                help.Cell("A3").Value = "Dear Seller,";
                help.Cell("B3").Value = "Description";
                help.Range("A3:B4").Style.Font.Bold = true;

                help.Cell("A6").Value = "Use of this report";
                help.Cell("B6").Value = "This report provides details monthly Total Commision Price";
                help.Cell("A7").Value = "Name";
                help.Cell("B7").Value = "Vender Name";
                help.Cell("A8").Value = "Address";
                help.Cell("B8").Value = "Register business Address";
                help.Cell("A9").Value = "Email Id";
                help.Cell("B9").Value = "Vender Email Id";
                help.Cell("A10").Value = "Contact No";
                help.Cell("B10").Value = "Vender Contact Number";
                help.Cell("A11").Value = "Invoice Date";
                help.Cell("B11").Value = "Created Date";
                help.Cell("A12").Value = "Invoice Period";
                help.Cell("B12").Value = "Invoice Period";
                help.Cell("A13").Value = "Business Name";
                help.Cell("B13").Value = "Business Name";
                help.Cell("A14").Value = "Name";
                help.Cell("B14").Value = "Customer Name";
                help.Cell("A15").Value = "Order Number";
                help.Cell("B15").Value = "Order Id";
                help.Cell("A16").Value = "Order Number Detail";
                help.Cell("B16").Value = "Refrence Number detail ";
                help.Cell("A17").Value = "Product Id";
                help.Cell("B17").Value = "Id of the Product";
                help.Cell("A18").Value = "Product Name";
                help.Cell("B18").Value = "Name of the Product";
                help.Cell("A19").Value = "Group";
                help.Cell("B19").Value = "Group of the Product";
                help.Cell("A20").Value = "Selling Price";
                help.Cell("B20").Value = "Price of the Product";
                help.Cell("A21").Value = "Total Item";
                help.Cell("B21").Value = "Total Order Items";
                help.Cell("A22").Value = "Order Date";
                help.Cell("B22").Value = "Order Date";
                help.Cell("A23").Value = "Delivery Date";
                help.Cell("B23").Value = "Delivery Date";
                help.Cell("A24").Value = "Order Delivery Type";
                help.Cell("B24").Value = "Order Delivery Type";
                help.Cell("A25").Value = "Order Total";
                help.Cell("B25").Value = "Order Total";
                help.Cell("A26").Value = "Status";
                help.Cell("B26").Value = "Status of Product";
                help.Cell("A27").Value = "Return Status";
                help.Cell("B27").Value = "Return Status";

                ws.Cell("A10").Value = "Name";
                ws.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("B10").Value = "Order Number";
                ws.Cell("B10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("C10").Value = "Order Number Detail";
                ws.Cell("C10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("D10").Value = "Product Id";
                ws.Cell("D10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("E10").Value = "Product Name";
                ws.Cell("E10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("F10").Value = "Group";
                ws.Cell("F10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("G10").Value = "Selling Price";
                ws.Cell("G10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("H10").Value = "total Item";
                ws.Cell("H10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("I10").Value = "Order Date";
                ws.Cell("I10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("J10").Value = "Item Delivery Date";
                ws.Cell("J10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("K10").Value = "Order Delivery Type";
                ws.Cell("K10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("L10").Value = "Order Total";
                ws.Cell("L10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("M10").Value = "Status";
                ws.Cell("M10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("N10").Value = "Return Status";
                ws.Cell("N10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range("A10:N10").Style.Font.Bold = true;
                ws.Range("A10:N10").Style.Border.TopBorder = XLBorderStyleValues.Thin;

                string getnew = @"select		distinct username,order_number,order_num_det,pro.Product_id,pro.Product_Name,pro.Your_selling_price,cg.cat_grp_name,total_item,order_date,item_delivery_date,order_deliverytype,Order_total,toi.Status,Return_Status 
from		tblorderitem as toi 
inner join	tblorderdetails as tod 
on			toi.order_num_det=concAT(tod.prefix,tod.order_number)
inner join	tbl_login as tl 
on			tl.email_id = tod.customer_emailid 
left join	Products as pro
on			pro.Product_id=toi.Product_id 
inner join Category_Group as cg
on			cg.cat_grp_id=pro.Cat_group_id
where		Convert(datetime,tod.order_date,103) BETWEEN Convert(datetime,'" + start + "',103) AND Convert(datetime,'" + end + "',103) and toi.vender_emailid = '" + ssss + "' and toi.Status = 'Delivered' and pro.P_weight!= 'NULL'";
                dsnew = objcrud.dataset_(getnew);
                x = 10;
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < dsnew.Tables[0].Rows.Count; k++)
                    {
                        x++;

                        index = x;
                        ws.Cell("A" + index).Value = dsnew.Tables[0].Rows[k]["username"].ToString();
                        ws.Cell("A" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("B" + index).Value = dsnew.Tables[0].Rows[k]["order_number"].ToString();
                        ws.Cell("B" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("C" + index).Value = dsnew.Tables[0].Rows[k]["order_num_det"].ToString();
                        ws.Cell("C" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("D" + index).Value = dsnew.Tables[0].Rows[k]["Product_id"].ToString();
                        ws.Cell("D" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("E" + index).Value = dsnew.Tables[0].Rows[k]["Product_Name"].ToString();
                        ws.Cell("E" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("F" + index).Value = dsnew.Tables[0].Rows[k]["cat_grp_name"].ToString();
                        ws.Cell("F" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("G" + index).Value = dsnew.Tables[0].Rows[k]["Your_selling_price"].ToString();
                        ws.Cell("G" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("H" + index).Value = dsnew.Tables[0].Rows[k]["total_item"].ToString();
                        ws.Cell("H" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("I" + index).Value = dsnew.Tables[0].Rows[k]["order_date"].ToString();
                        ws.Cell("I" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("J" + index).Value = dsnew.Tables[0].Rows[k]["item_delivery_date"].ToString();
                        ws.Cell("J" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("K" + index).Value = dsnew.Tables[0].Rows[k]["order_deliverytype"].ToString();
                        ws.Cell("K" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("L" + index).Value = dsnew.Tables[0].Rows[k]["Order_total"].ToString();
                        ws.Cell("L" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("M" + index).Value = dsnew.Tables[0].Rows[k]["Status"].ToString();
                        ws.Cell("M" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("N" + index).Value = dsnew.Tables[0].Rows[k]["Return_Status"].ToString();
                        ws.Cell("N" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }
                    int insx = 10;
                    int ins = insx;
                    int cnt = ins + dsnew.Tables[0].Rows.Count;
                    ws.Range("A" + ins + ":" + "N" + cnt).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Range("A" + ins + ":" + "N" + cnt).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                }


            }
            else if (Request.QueryString["ReportName"] == "Unsettled Transactions")
            {


                ws.Range("A10:O10").Style.Font.Bold = true;
                ws.Range("A10:O10").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                ws.Cell("A10").Value = "Customer Name";
                ws.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("B10").Value = "Customer EmailId";
                ws.Cell("B10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("C10").Value = "Order Number";
                ws.Cell("C10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("D10").Value = "Order Detail Number";
                ws.Cell("D10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("E10").Value = "Order Date";
                ws.Cell("E10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("F10").Value = "Item Delivery Date";
                ws.Cell("F10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("G10").Value = "Item Delivery Type";
                ws.Cell("G10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("H10").Value = "Status";
                ws.Cell("H10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("I10").Value = "Order Quantity";
                ws.Cell("I10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("J10").Value = "Return Status";
                ws.Cell("J10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("K10").Value = "Return Quantity";
                ws.Cell("K10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("L10").Value = "Group Name";
                ws.Cell("L10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("M10").Value = "Product Id";
                ws.Cell("M10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("N10").Value = "Product Name";
                ws.Cell("N10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("O10").Value = "Selling Price";
                ws.Cell("O10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.ColumnWidth = 20;
                var colBws = ws.Column("B");
                colBws.Width = 40;

                var worksheet = wb.Worksheet(2);
                var pre = worksheet.Worksheet.Name = "Pre-Dispatch";
                var Dispatch = wb.Worksheets.Add("Dispatch");
                var uo = wb.Worksheets.Add("Unpaid Orders");


                help.ColumnWidth = 20;
                var col1 = help.Column("B");
                col1.Width = 55;
                help.Range("A3:A4").Merge();
                help.Range("B3:B4").Merge();
                help.Cell("A3").Value = "Dear Seller,";
                help.Cell("B3").Value = "Description";
                help.Range("A3:B4").Style.Font.Bold = true;

                help.Cell("A6").Value = "Use of this report";
                help.Cell("B6").Value = "This report provides details monthly Total Commision Price";
                help.Cell("A7").Value = "Name";
                help.Cell("B7").Value = "Vender Name";
                help.Cell("A8").Value = "Address";
                help.Cell("B8").Value = "Register business Address";
                help.Cell("A9").Value = "Email Id";
                help.Cell("B9").Value = "Vender Email Id";
                help.Cell("A10").Value = "Contact No";
                help.Cell("B10").Value = "Vender Contact Number";
                help.Cell("A11").Value = "Invoice Date";
                help.Cell("B11").Value = "Created Date";
                help.Cell("A12").Value = "Invoice Period";
                help.Cell("B12").Value = "Invoice Period";
                help.Cell("A13").Value = "Customer Name";
                help.Cell("B13").Value = "Customer Name";
                help.Cell("A14").Value = "Customer Email Id";
                help.Cell("B14").Value = "Customer Email Id";
                help.Cell("A15").Value = "Order Number";
                help.Cell("B15").Value = "Order Number";
                help.Cell("A16").Value = "Order Detail Number";
                help.Cell("B16").Value = "Order Detail Number";
                help.Cell("B16").Style.Alignment.WrapText = true;
                help.Cell("A17").Value = "Order Date";
                help.Cell("B17").Value = "Order Date";
                help.Cell("A18").Value = "Delivery Date";
                help.Cell("B18").Value = "Delivery Date";
                help.Cell("A19").Value = "Order Delivery Type";
                help.Cell("B19").Value = "Order Delivery Type";
                help.Cell("A20").Value = "Order Quantity";
                help.Cell("B20").Value = "Order Quantity";
                help.Cell("A21").Value = "Order Status";
                help.Cell("B21").Value = "Order Status Like *Pending,Confirm For Pre-Dispatch";
                help.Cell("B22").Value = "Order Status Like *Dispatch For Dispatch";
                help.Cell("B23").Value = "Order Status Like *Delivery For Unpaid Order";
                help.Cell("A24").Value = "Product Group";
                help.Cell("B24").Value = "Product Group";
                help.Cell("A25").Value = "Product Id";
                help.Cell("B25").Value = "Product Id";
                help.Cell("A26").Value = "Product Name";
                help.Cell("B26").Value = "Product Name";
                help.Cell("A27").Value = "Selling Price";
                help.Cell("B27").Value = "Selling Price";
                help.Cell("A28").Value = "Return Status";
                help.Cell("B28").Value = "Return Status";
                help.Cell("A29").Value = "Return Quantity";
                help.Cell("B29").Value = "Return Quantity";

                string getnew = @"select		distinct tl.username,tl.email_id,order_number,order_num_det,order_date,Delivery_Date,order_deliverytype,order_quantity,toi.Status,toi.Return_Status,toi.Return_qty,cg.cat_grp_name,pro.Product_id,pro.Product_Name,pro.Your_selling_price 
from		tblorderitem as toi 
inner join	tblorderdetails as tod 
on			toi.order_num_det=concAT(tod.prefix,tod.order_number)
inner join	tbl_login as tl 
on			tl.email_id = tod.customer_emailid 
left join	Products as pro
on			pro.Product_id=toi.Product_id 
inner join Category_Group as cg
on			cg.cat_grp_id=pro.Cat_group_id
where		Convert(datetime,tod.order_date,103) BETWEEN Convert(datetime,'" + start + "',103) AND Convert(datetime,'" + end + "',103) and toi.vender_emailid = '" + ssss + "' and toi.Status In('Pending','Confirm') and pro.P_weight!= 'NULL'";
                dsnew = objcrud.dataset_(getnew);


                x = 10;

                if (dsnew.Tables[0].Rows.Count > 0)
                {

                    for (int k = 0; k < dsnew.Tables[0].Rows.Count; k++)
                    {
                        x++;

                        index = x;
                        ws.Cell("A" + index).Value = dsnew.Tables[0].Rows[k]["username"].ToString();
                        ws.Cell("A" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("B" + index).Value = dsnew.Tables[0].Rows[k]["email_id"].ToString();
                        ws.Cell("B" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("C" + index).Value = dsnew.Tables[0].Rows[k]["order_number"].ToString();
                        ws.Cell("C" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("D" + index).Value = dsnew.Tables[0].Rows[k]["order_num_det"].ToString();
                        ws.Cell("D" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("E" + index).Value = dsnew.Tables[0].Rows[k]["order_date"].ToString();
                        ws.Cell("E" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("F" + index).Value = dsnew.Tables[0].Rows[k]["Delivery_Date"].ToString();
                        ws.Cell("F" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("G" + index).Value = dsnew.Tables[0].Rows[k]["order_deliverytype"].ToString();
                        ws.Cell("G" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("H" + index).Value = dsnew.Tables[0].Rows[k]["Status"].ToString();
                        ws.Cell("H" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("I" + index).Value = dsnew.Tables[0].Rows[k]["order_quantity"].ToString();
                        ws.Cell("I" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("J" + index).Value = dsnew.Tables[0].Rows[k]["Return_Status"].ToString();
                        ws.Cell("J" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("K" + index).Value = dsnew.Tables[0].Rows[k]["Return_qty"].ToString();
                        ws.Cell("K" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("L" + index).Value = dsnew.Tables[0].Rows[k]["cat_grp_name"].ToString();
                        ws.Cell("L" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("M" + index).Value = dsnew.Tables[0].Rows[k]["Product_id"].ToString();
                        ws.Cell("M" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("N" + index).Value = dsnew.Tables[0].Rows[k]["Product_Name"].ToString();
                        ws.Cell("N" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("O" + index).Value = dsnew.Tables[0].Rows[k]["Your_selling_price"].ToString();
                        ws.Cell("O" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }
                    int insx = 10;
                    int ins = insx;
                    int cnt = ins + dsnew.Tables[0].Rows.Count;
                    ws.Range("A" + ins + ":" + "O" + cnt).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Range("A" + ins + ":" + "O" + cnt).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                }
                Dispatch.ShowGridLines = false;
                Dispatch.Cell("C1").Value = Request.QueryString["ReportName"];
                Dispatch.Cell("C1").Style.Fill.BackgroundColor = XLColor.ForestGreen;
                Dispatch.Cell("C1").Style.Font.FontColor = XLColor.White;
                Dispatch.Cell("C1").Style.Font.Bold = true;
                Dispatch.Cell("C1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("C1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                Dispatch.Range("C1:E2").Merge();

                Dispatch.ColumnWidth = 20;
                Dispatch.Cell("A3").Value = name;
                Dispatch.Range("A3:G3").Row(1).Merge();
                Dispatch.Cell("A4").Value = reg_Add + "\n" + email + "\n" + "+91" + num;
                Dispatch.Cell("A4").Style.Alignment.WrapText = true;
                Dispatch.Cell("A4").Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                Dispatch.Cell("A5").Value = ssss;
                Dispatch.Cell("A5").Style.Alignment.WrapText = true;
                Dispatch.Cell("A5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                Dispatch.Range("A4:B8").Merge();
                Dispatch.Cell("C4").Value = "Invoice Date: " + cdate;
                Dispatch.Cell("C4").RichText.Substring(13, 10).SetFontColor(XLColor.ForestGreen);
                Dispatch.Cell("C4").RichText.Substring(13, 10).SetBold();
                Dispatch.Range("C4:D4").Row(1).Merge();
                Dispatch.Cell("C4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                Dispatch.Cell("C5").Value = "Invoice Period: " + idate;
                Dispatch.Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                Dispatch.Cell("C5").RichText.Substring(15, 23).SetFontColor(XLColor.ForestGreen);
                Dispatch.Cell("C5").RichText.Substring(15, 23).SetBold();
                Dispatch.Cell("C5").Style.Font.Bold = true;
                Dispatch.Range("C5:D5").Row(1).Merge();
                Dispatch.Cell("C6").Value = "Business Name: " + business;
                Dispatch.Range("C6:D6").Row(1).Merge();
                Dispatch.Cell("C6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                Dispatch.Range("A10:O10").Style.Font.Bold = true;
                Dispatch.Range("A10:O10").Style.Border.TopBorder = XLBorderStyleValues.Thin;
                Dispatch.Cell("A10").Value = "Customer Name";
                Dispatch.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("B10").Value = "Customer EmailId";
                Dispatch.Cell("B10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("C10").Value = "Order Number";
                Dispatch.Cell("C10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("D10").Value = "Order Detail Number";
                Dispatch.Cell("D10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("E10").Value = "Order Date";
                Dispatch.Cell("E10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("F10").Value = "Item Delivery Date";
                Dispatch.Cell("F10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("G10").Value = "Item Delivery Type";
                Dispatch.Cell("G10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("H10").Value = "Status";
                Dispatch.Cell("H10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("I10").Value = "Order Quantity";
                Dispatch.Cell("I10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("J10").Value = "Return Status";
                Dispatch.Cell("J10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("K10").Value = "Return Quantity";
                Dispatch.Cell("K10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("L10").Value = "Group Name";
                Dispatch.Cell("L10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("M10").Value = "Product Id";
                Dispatch.Cell("M10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("N10").Value = "Product Name";
                Dispatch.Cell("N10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Dispatch.Cell("O10").Value = "Selling Price";
                Dispatch.Cell("O10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                string getnewD = @"select		distinct tl.username,tl.email_id,order_number,order_num_det,order_date,Delivery_Date,order_deliverytype,order_quantity,toi.Status,toi.Return_Status,toi.Return_qty,cg.cat_grp_name,pro.Product_id,pro.Product_Name,pro.Your_selling_price 
from		tblorderitem as toi 
inner join	tblorderdetails as tod 
on			toi.order_num_det=concAT(tod.prefix,tod.order_number)
inner join	tbl_login as tl 
on			tl.email_id = tod.customer_emailid 
left join	Products as pro
on			pro.Product_id=toi.Product_id 
inner join Category_Group as cg
                                 on			cg.cat_grp_id=pro.Cat_group_id
where		Convert(datetime,tod.order_date,103) BETWEEN Convert(datetime,'" + start + "',103) AND Convert(datetime,'" + end + "',103) and toi.vender_emailid = '" + ssss + "' and toi.Status In('Dispatch') and pro.P_weight!= 'NULL'";
                dsnewD = objcrud.dataset_(getnewD);
                x = 10;
                if (dsnewD.Tables[0].Rows.Count > 0)
                {

                    for (int k = 0; k < dsnewD.Tables[0].Rows.Count; k++)
                    {
                        x++;

                        index = x;
                        Dispatch.Cell("A" + index).Value = dsnewD.Tables[0].Rows[k]["username"].ToString();
                        Dispatch.Cell("A" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("B" + index).Value = dsnewD.Tables[0].Rows[k]["email_id"].ToString();
                        Dispatch.Cell("B" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("C" + index).Value = dsnewD.Tables[0].Rows[k]["order_number"].ToString();
                        Dispatch.Cell("C" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("D" + index).Value = dsnewD.Tables[0].Rows[k]["order_num_det"].ToString();
                        Dispatch.Cell("D" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("E" + index).Value = dsnewD.Tables[0].Rows[k]["order_date"].ToString();
                        Dispatch.Cell("E" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("F" + index).Value = dsnewD.Tables[0].Rows[k]["Delivery_Date"].ToString();
                        Dispatch.Cell("F" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("G" + index).Value = dsnewD.Tables[0].Rows[k]["order_deliverytype"].ToString();
                        Dispatch.Cell("G" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("H" + index).Value = dsnewD.Tables[0].Rows[k]["Status"].ToString();
                        Dispatch.Cell("H" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("I" + index).Value = dsnewD.Tables[0].Rows[k]["order_quantity"].ToString();
                        Dispatch.Cell("I" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("J" + index).Value = dsnewD.Tables[0].Rows[k]["Return_Status"].ToString();
                        Dispatch.Cell("J" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("K" + index).Value = dsnewD.Tables[0].Rows[k]["Return_qty"].ToString();
                        Dispatch.Cell("K" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("L" + index).Value = dsnewD.Tables[0].Rows[k]["cat_grp_name"].ToString();
                        Dispatch.Cell("L" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("M" + index).Value = dsnewD.Tables[0].Rows[k]["Product_id"].ToString();
                        Dispatch.Cell("M" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("N" + index).Value = dsnewD.Tables[0].Rows[k]["Product_Name"].ToString();
                        Dispatch.Cell("N" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Dispatch.Cell("O" + index).Value = dsnewD.Tables[0].Rows[k]["Your_selling_Price"].ToString();
                        Dispatch.Cell("O" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }
                    int insx = 10;
                    int ins = insx;
                    int cnt = ins + dsnewD.Tables[0].Rows.Count;
                    Dispatch.Range("A" + ins + ":" + "O" + cnt).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    Dispatch.Range("A" + ins + ":" + "O" + cnt).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                }


                uo.ShowGridLines = false;
                uo.Cell("C1").Value = Request.QueryString["ReportName"];
                uo.Cell("C1").Style.Fill.BackgroundColor = XLColor.ForestGreen;
                uo.Cell("C1").Style.Font.FontColor = XLColor.White;
                uo.Cell("C1").Style.Font.Bold = true;
                uo.Cell("C1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("C1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                uo.Range("C1:E2").Merge();
                uo.ColumnWidth = 20;
                uo.Cell("A3").Value = name;
                uo.Range("A3:G3").Row(1).Merge();
                uo.Cell("A4").Value = reg_Add + "\n" + email + "\n" + "+91" + num;
                uo.Cell("A4").Style.Alignment.WrapText = true;
                uo.Cell("A4").Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                uo.Cell("A5").Value = ssss;
                uo.Cell("A5").Style.Alignment.WrapText = true;
                uo.Cell("A5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                uo.Range("A4:B8").Merge();
                uo.Cell("C4").Value = "Invoice Date: " + cdate;
                uo.Cell("C4").RichText.Substring(13, 10).SetFontColor(XLColor.ForestGreen);
                uo.Cell("C4").RichText.Substring(13, 10).SetBold();
                uo.Range("C4:D4").Row(1).Merge();
                uo.Cell("C4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                uo.Cell("C5").Value = "Invoice Period: " + idate;
                uo.Cell("C5").RichText.Substring(15, 23).SetFontColor(XLColor.ForestGreen);
                uo.Cell("C5").RichText.Substring(15, 23).SetBold();
                uo.Cell("C5").Style.Font.Bold = true;
                uo.Range("C5:D5").Row(1).Merge();
                uo.Cell("C6").Value = "Business Name: " + business;
                uo.Cell("C6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                uo.Range("C6:D6").Row(1).Merge();
                uo.Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                uo.Range("A10:O10").Style.Font.Bold = true;
                uo.Range("A10:O10").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                uo.Cell("A10").Value = "Customer Name";
                uo.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("B10").Value = "Customer EmailId";
                uo.Cell("B10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("C10").Value = "Order Number";
                uo.Cell("C10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("D10").Value = "Order Detail Number";
                uo.Cell("D10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("E10").Value = "Order Date";
                uo.Cell("E10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("F10").Value = "Item Delivery Date";
                uo.Cell("F10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("G10").Value = "Delivery Type";
                uo.Cell("G10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("H10").Value = "Status";
                uo.Cell("H10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("I10").Value = "Order Quantity";
                uo.Cell("I10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("J10").Value = "Return Status";
                uo.Cell("J10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("K10").Value = "Return Quantity";
                uo.Cell("K10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("L10").Value = "Group Name";
                uo.Cell("L10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("M10").Value = "Product Id";
                uo.Cell("M10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("N10").Value = "Product Name";
                uo.Cell("N10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                uo.Cell("O10").Value = "Selling Price";
                uo.Cell("O10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                string getnewDD = @"select		distinct tl.username,tl.email_id,order_number,order_num_det,order_date,item_delivery_date,Delivery_Date,order_deliverytype,order_quantity,toi.Status,toi.Return_Status,toi.Return_qty,cg.cat_grp_name,pro.Product_id,pro.Product_Name,pro.Your_selling_price 
from		tblorderitem as toi 
inner join	tblorderdetails as tod 
on			toi.order_num_det=concAT(tod.prefix,tod.order_number)
inner join	tbl_login as tl 
on			tl.email_id = tod.customer_emailid 
left join	Products as pro
on			pro.Product_id=toi.Product_id 
inner join Category_Group as cg
                                 on			cg.cat_grp_id=pro.Cat_group_id
where		Convert(datetime,tod.order_date,103) BETWEEN Convert(datetime,'" + start + "',103) AND Convert(datetime,'" + end + "',103) and toi.vender_emailid = '" + ssss + "' and toi.Status In('Delivered') and pro.P_weight!= 'NULL'";

                dsnewDD = objcrud.dataset_(getnewDD);
                x = 10;

                if (dsnewDD.Tables[0].Rows.Count > 0)
                {

                    for (int k = 0; k < dsnewDD.Tables[0].Rows.Count; k++)
                    {
                        x++;

                        index = x;
                        uo.Cell("A" + index).Value = dsnewDD.Tables[0].Rows[k]["username"].ToString();
                        uo.Cell("A" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("B" + index).Value = dsnewDD.Tables[0].Rows[k]["email_id"].ToString();
                        uo.Cell("B" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("C" + index).Value = dsnewDD.Tables[0].Rows[k]["order_number"].ToString();
                        uo.Cell("C" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("D" + index).Value = dsnewDD.Tables[0].Rows[k]["order_num_det"].ToString();
                        uo.Cell("D" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("E" + index).Value = dsnewDD.Tables[0].Rows[k]["order_date"].ToString();
                        uo.Cell("E" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("F" + index).Value = dsnewDD.Tables[0].Rows[k]["item_delivery_date"].ToString();
                        uo.Cell("F" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("G" + index).Value = dsnewDD.Tables[0].Rows[k]["order_deliverytype"].ToString();
                        uo.Cell("G" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("H" + index).Value = dsnewDD.Tables[0].Rows[k]["Status"].ToString();
                        uo.Cell("H" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("I" + index).Value = dsnewDD.Tables[0].Rows[k]["order_quantity"].ToString();
                        uo.Cell("I" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("J" + index).Value = dsnewDD.Tables[0].Rows[k]["Return_Status"].ToString();
                        uo.Cell("J" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("K" + index).Value = dsnewDD.Tables[0].Rows[k]["Return_qty"].ToString();
                        uo.Cell("K" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("L" + index).Value = dsnewDD.Tables[0].Rows[k]["cat_grp_name"].ToString();
                        uo.Cell("L" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("M" + index).Value = dsnewDD.Tables[0].Rows[k]["Product_id"].ToString();
                        uo.Cell("M" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("N" + index).Value = dsnewDD.Tables[0].Rows[k]["Product_Name"].ToString();
                        uo.Cell("N" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        uo.Cell("O" + index).Value = dsnewDD.Tables[0].Rows[k]["Your_selling_Price"].ToString();
                        uo.Cell("O" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }


                    int insx = 10;
                    int ins = insx;
                    int cnt = ins + dsnewDD.Tables[0].Rows.Count;
                    Dispatch.Range("A" + ins + ":" + "O" + cnt).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    Dispatch.Range("A" + ins + ":" + "O" + cnt).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                }
            }
            else if (Request.QueryString["ReportName"] == "Settled Transactions")
            {
                help.ColumnWidth = 20;
                var col1 = help.Column("B");
                col1.Width = 55;
                help.Range("A3:A4").Merge();
                help.Range("B3:B4").Merge();
                help.Cell("A3").Value = "Dear Seller,";
                help.Cell("B3").Value = "Description";
                help.Range("A3:B4").Style.Font.Bold = true;

                help.Cell("A6").Value = "Use of this report";
                help.Cell("B6").Value = "This report provides details monthly Total Commision Price";
                help.Cell("A7").Value = "Name";
                help.Cell("B7").Value = "Vender Name";
                help.Cell("A8").Value = "Address";
                help.Cell("B8").Value = "Register business Address";
                help.Cell("A9").Value = "Email Id";
                help.Cell("B9").Value = "Vender Email Id";
                help.Cell("A10").Value = "Contact No";
                help.Cell("B10").Value = "Vender Contact Number";
                help.Cell("A11").Value = "Invoice Date";
                help.Cell("B11").Value = "Created Date";
                help.Cell("A12").Value = "Invoice Period";
                help.Cell("B12").Value = "Invoice Period";
                help.Cell("A13").Value = "Customer Name";
                help.Cell("B13").Value = "Customer Name";
                help.Cell("A14").Value = "Customer Email Id";
                help.Cell("B14").Value = "Customer Email Id";
                help.Cell("A15").Value = "Order Number";
                help.Cell("B15").Value = "Order Number";
                help.Cell("A16").Value = "Order Detail Number";
                help.Cell("B16").Value = "Order Detail Number";
                help.Cell("B16").Style.Alignment.WrapText = true;
                help.Cell("A17").Value = "Order Date";
                help.Cell("B17").Value = "Order Date";
                help.Cell("A18").Value = "Delivery Date";
                help.Cell("B18").Value = "Delivery Date";
                help.Cell("A19").Value = "Order Delivery Type";
                help.Cell("B19").Value = "Order Delivery Type";
                help.Cell("A20").Value = "Order Quantity";
                help.Cell("B20").Value = "Order Quantity";
                help.Cell("A21").Value = "Order Status";
                help.Cell("B21").Value = "Order Status Like *Pending,Confirm For Pre-Dispatch";
                help.Cell("B22").Value = "Order Status Like *Dispatch For Dispatch";
                help.Cell("B23").Value = "Order Status Like *Delivery For Unpaid Order";
                help.Cell("A24").Value = "Return Status";
                help.Cell("B24").Value = "Return Status";
                help.Cell("A25").Value = "Return Quantity";
                help.Cell("B25").Value = "Return Quantity";
                help.Cell("A26").Value = "Product Group";
                help.Cell("B26").Value = "Product Group";
                help.Cell("A27").Value = "Product Id";
                help.Cell("B27").Value = "Product Id";
                help.Cell("A28").Value = "Product Name";
                help.Cell("B28").Value = "Product Name";
                help.Cell("A29").Value = "Selling Price";
                help.Cell("B29").Value = "Product Selling Price";
                help.Cell("A30").Value = "GST(%)";
                help.Cell("B30").Value = "Product GST";


                ws.Range("A10:P10").Style.Font.Bold = true;
                ws.Range("A10:P10").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                ws.Cell("A10").Value = "Customer Name";
                ws.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("B10").Value = "Customer EmailId";
                ws.Cell("B10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("C10").Value = "Order Number";
                ws.Cell("C10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("D10").Value = "Order Detail Number";
                ws.Cell("D10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("E10").Value = "Order Date";
                ws.Cell("E10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("F10").Value = "Item Delivery Date";
                ws.Cell("F10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("G10").Value = "Delivery Type";
                ws.Cell("G10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("H10").Value = "Status";
                ws.Cell("H10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("I10").Value = "Order Quantity";
                ws.Cell("I10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("J10").Value = "Return Status";
                ws.Cell("J10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("K10").Value = "Return Quantity";
                ws.Cell("K10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("L10").Value = "Group Name";
                ws.Cell("L10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("M10").Value = "Product Id";
                ws.Cell("M10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("N10").Value = "Product Name";
                ws.Cell("N10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("O10").Value = "Selling Price";
                ws.Cell("O10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("P10").Value = "Gst(%)";
                ws.Cell("P10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                String getnew = @"select		distinct tl.username,tl.email_id,order_number,order_num_det,order_date,Delivery_Date,order_deliverytype,order_quantity,toi.item_delivery_date,toi.Status,toi.Return_Status,toi.Return_qty,cg.cat_grp_name,pro.Product_id,pro.Product_Name,pro.Your_selling_price 
from		tblorderitem as toi 
inner join	tblorderdetails as tod 
on			toi.order_num_det=concAT(tod.prefix,tod.order_number)
inner join	tbl_login as tl 
on			tl.email_id = tod.customer_emailid 
left join	Products as pro
on			pro.Product_id=toi.Product_id
inner join Category_Group as cg
on			cg.cat_grp_id=pro.Cat_group_id 
where       toi.vender_emailid='" + ssss + "' and toi.Status = 'Delivered' and Convert(datetime, tod.order_date,103) BETWEEN Convert(datetime,'" + start + "', 103) AND Convert(datetime,'" + end + "', 103) and CONVERT(datetime,toi.delivery_after_date,103)<= getdate()";
                dsnew = objcrud.dataset_(getnew);
                x = 10;

                if (dsnew.Tables[0].Rows.Count > 0)
                {

                    for (int k = 0; k < dsnew.Tables[0].Rows.Count; k++)
                    {
                        x++;

                        index = x;
                        ws.Cell("A" + index).Value = dsnew.Tables[0].Rows[k]["username"].ToString();
                        ws.Cell("A" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("B" + index).Value = dsnew.Tables[0].Rows[k]["email_id"].ToString();
                        ws.Cell("B" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("C" + index).Value = dsnew.Tables[0].Rows[k]["order_number"].ToString();
                        ws.Cell("C" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("D" + index).Value = dsnew.Tables[0].Rows[k]["order_num_det"].ToString();
                        ws.Cell("D" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("E" + index).Value = dsnew.Tables[0].Rows[k]["order_date"].ToString();
                        ws.Cell("E" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("F" + index).Value = dsnew.Tables[0].Rows[k]["item_delivery_date"].ToString();
                        ws.Cell("F" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("G" + index).Value = dsnew.Tables[0].Rows[k]["order_deliverytype"].ToString();
                        ws.Cell("G" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("H" + index).Value = dsnew.Tables[0].Rows[k]["Status"].ToString();
                        ws.Cell("H" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("I" + index).Value = dsnew.Tables[0].Rows[k]["order_quantity"].ToString();
                        ws.Cell("I" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("J" + index).Value = dsnew.Tables[0].Rows[k]["Return_Status"].ToString();
                        ws.Cell("J" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("K" + index).Value = dsnew.Tables[0].Rows[k]["Return_qty"].ToString();
                        ws.Cell("K" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("L" + index).Value = dsnew.Tables[0].Rows[k]["cat_grp_name"].ToString();
                        ws.Cell("L" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("M" + index).Value = dsnew.Tables[0].Rows[k]["Product_id"].ToString();
                        ws.Cell("M" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("N" + index).Value = dsnew.Tables[0].Rows[k]["Product_Name"].ToString();
                        ws.Cell("N" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("O" + index).Value = dsnew.Tables[0].Rows[k]["Your_selling_Price"].ToString();
                        ws.Cell("O" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("P" + index).Value = dsnew.Tables[0].Rows[k]["GST"].ToString();
                        ws.Cell("P" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }
                    int insx = 10;
                    int ins = insx;
                    int cnt = ins + dsnew.Tables[0].Rows.Count;
                    ws.Range("A" + ins + ":" + "P" + cnt).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Range("A" + ins + ":" + "P" + cnt).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                }
            }
            else if (Request.QueryString["ReportName"] == "Sales Reports")
            {
                help.ColumnWidth = 20;
                var col1 = help.Column("B");
                col1.Width = 55;
                help.Range("A3:A4").Merge();
                help.Range("B3:B4").Merge();
                help.Cell("A3").Value = "Dear Seller,";
                help.Cell("B3").Value = "Description";
                help.Range("A3:B4").Style.Font.Bold = true;

                help.Cell("A6").Value = "Use of this report";
                help.Cell("B6").Value = "Check all your sales happened over a time period. Use it for posting your sales and paying your sales taxes.";
                help.Cell("A7").Value = "Name";
                help.Cell("B7").Value = "Vender Name";
                help.Cell("A8").Value = "Address";
                help.Cell("B8").Value = "Register business Address";
                help.Cell("A9").Value = "Email Id";
                help.Cell("B9").Value = "Vender Email Id";
                help.Cell("A10").Value = "Contact No";
                help.Cell("B10").Value = "Vender Contact Number";
                help.Cell("A11").Value = "Invoice Date";
                help.Cell("B11").Value = "Created Date";
                help.Cell("A12").Value = "Invoice Period";
                help.Cell("B12").Value = "Invoice Period";
                help.Cell("A13").Value = "Product Id";
                help.Cell("B13").Value = "Id of the Product";
                help.Cell("A14").Value = "Product Name";
                help.Cell("B14").Value = "Name Of the Product";
                help.Cell("A15").Value = "Product Group";
                help.Cell("B15").Value = "Group of the Product";
                help.Cell("A16").Value = "Qty";
                help.Cell("B16").Value = "Quantity Of the Product";
                help.Cell("A17").Value = "%";
                help.Cell("B17").Value = "Commision In Percentage";
                help.Cell("A18").Value = "Commision Amount";
                help.Cell("B18").Value = "Commision Amount on particular Product";
                help.Cell("A19").Value = "Selling Price";
                help.Cell("B19").Value = "Product Selling Price";
                help.Cell("A20").Value = "Final Commision";
                help.Cell("B20").Value = "Final Commision";
                help.Cell("A21").Value = "GST(%)";
                help.Cell("B21").Value = "GST Of The Product";



                ws.Cell("H7").Value = "Total:";
                ws.Cell("H7").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                ws.Cell("H7").Style.Font.Bold = true;
                ws.Cell("H8").Value = "GST:";
                ws.Cell("H8").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                ws.Cell("H8").Style.Font.Bold = true;

                ws.Range("A10:I10").Style.Font.Bold = true;
                ws.Cell("A10").Value = "Product Id";
                ws.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell("B10").Value = "Product Name";
                ws.Cell("B10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("C10").Value = "Product Group";
                ws.Cell("C10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("D10").Value = "Qty";
                ws.Cell("D10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("E10").Value = "%";
                ws.Cell("E10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("F10").Value = "Commision Amount";
                ws.Cell("F10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("G10").Value = "Selling Price";
                ws.Cell("G10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("H10").Value = "Final Commision";
                ws.Cell("H10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("I10").Value = "GST";
                ws.Cell("I10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Range("A9:I9").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Range("A10:I10").Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                string getnew = @"select		tl.username,tl.email_id,order_number,order_num_det,order_date,item_delivery_date,order_deliverytype,order_quantity,toi.Status,toi.Return_Status,toi.Return_qty,cg.cat_grp_name,pro.Product_id,pro.Product_Name,pro.Your_selling_price,pro.GST,pro.P_weight,tc.commission_fee
from		tblorderitem as toi 
inner join	tblorderdetails as tod 
on			toi.order_num_det=concAT(tod.prefix,tod.order_number)
inner join	tbl_login as tl 
on			tl.email_id = tod.customer_emailid 
left join	Products as pro
on			pro.Product_id=toi.Product_id 
left join	    Category as tc 
on			tc.cat_id = pro.Sub_cat_id
inner join  Category_Group as cg
on			cg.cat_grp_id=pro.Cat_group_id
where toi.vender_emailid='" + ssss + "' and toi.Status = 'Delivered' and Convert(datetime, tod.order_date,103) BETWEEN Convert(datetime,'" + start + "', 103) AND Convert(datetime,'" + end + "', 103) and CONVERT(datetime,toi.delivery_after_date,103)<= getdate() ";
                dsnew = objcrud.dataset_(getnew);
                x = 10;
                rngborder = dsnew.Tables[0].Rows.Count + 1;
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < dsnew.Tables[0].Rows.Count; k++)
                    {
                        x++;

                        index = x;
                        ws.Cell("A" + index).Value = dsnew.Tables[0].Rows[k]["Product_id"].ToString();
                        ws.Cell("A" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("B" + index).Value = dsnew.Tables[0].Rows[k]["Product_Name"].ToString();
                        ws.Cell("B" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("C" + index).Value = dsnew.Tables[0].Rows[k]["cat_grp_name"].ToString();
                        ws.Cell("C" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("D" + index).Value = dsnew.Tables[0].Rows[k]["order_quantity"].ToString();
                        ws.Cell("D" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("E" + index).Value = dsnew.Tables[0].Rows[k]["commission_fee"].ToString();
                        ws.Cell("E" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        prod_id = dsnew.Tables[0].Rows[k]["Product_id"].ToString();
                        product_grp = dsnew.Tables[0].Rows[k]["cat_grp_name"].ToString();
                        ord_qnt = dsnew.Tables[0].Rows[k]["order_quantity"].ToString();
                        wgt = dsnew.Tables[0].Rows[k]["P_weight"].ToString();
                        sell_price = dsnew.Tables[0].Rows[k]["Your_selling_Price"].ToString();
                        comm_per = dsnew.Tables[0].Rows[k]["commission_fee"].ToString();
                        double weight;
                        double.TryParse(wgt, out weight);
                        double.TryParse(comm_per, out comm_price);
                        int per = 100;
                        comms = ((Convert.ToDouble(sell_price) * comm_price) / per);
                        final_comm = (comms * Convert.ToDouble(ord_qnt));
                        ws.Cell("F" + index).Value = comms;
                        ws.Cell("F" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("G" + index).Value = sell_price;
                        ws.Cell("G" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("H" + index).Value = final_comm;
                        ws.Cell("H" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("I" + index).Value = dsnew.Tables[0].Rows[k]["GST"].ToString();
                        ws.Cell("I" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        r += "H" + index + ":";
                        rtax += "I" + index + ":";
                    }
                    if (r.EndsWith(":"))
                    {
                        r = r.Remove(r.LastIndexOf(":"));

                    }
                    if (rtax.EndsWith(":"))
                    {
                        rtax = rtax.Remove(rtax.LastIndexOf(":"));

                    }
                    y++;
                    y = index + 2;
                    y1 = y + 1;
                    //ws.Cell("A10:I10").Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                    //ws.Cell("A10:I10").Style.Border.BottomBorderColor = XLColor.Red;
                    totcomm = totcomm + final_comm;
                    ws.Cell("H" + y).Value = "Total:";
                    ws.Cell("H" + y).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Cell("H" + y).Style.Font.Bold = true;
                    ws.Cell("H" + y1).Value = "GST(%):";
                    ws.Cell("H" + y1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Cell("H" + y1).Style.Font.Bold = true;
                    ws.Cell("I" + y).SetFormulaA1("= SUM(" + r + ")");
                    ws.Cell("I" + y).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell("I" + y1).SetFormulaA1("= SUM(" + rtax + ")");
                    ws.Cell("I" + y1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell("I7").SetFormulaA1("= SUM(" + r + ")");
                    ws.Cell("I7").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell("I8").SetFormulaA1("= SUM(" + rtax + ")");
                    ws.Cell("I8").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    int insx = 10;
                    int ins = insx;
                    int cnt = ins + dsnew.Tables[0].Rows.Count;
                    ws.Range("A" + ins + ":" + "I" + cnt).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Range("A" + ins + ":" + "I" + cnt).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                }

            }
            else if (Request.QueryString["ReportName"] == "TDS")
            {

                var tdscal = wb.Worksheets.Add("Tds Calculation");

                help.ColumnWidth = 20;
                var col1 = help.Column("B");
                col1.Width = 55;
                help.Range("A3:A4").Merge();
                help.Range("B3:B4").Merge();
                help.Cell("A3").Value = "Dear Seller,";
                help.Cell("B3").Value = "Description";
                help.Range("A3:B4").Style.Font.Bold = true;

                help.Cell("A6").Value = "Use of this report";
                help.Cell("B6").Value = "Check all your sales happened over a time period. Use it for posting your sales and paying your sales taxes.";
                help.Cell("A7").Value = "Name";
                help.Cell("B7").Value = "Vender Name";
                help.Cell("A8").Value = "Address";
                help.Cell("B8").Value = "Register business Address";
                help.Cell("A9").Value = "Email Id";
                help.Cell("B9").Value = "Vender Email Id";
                help.Cell("A10").Value = "Contact No";
                help.Cell("B10").Value = "Vender Contact Number";
                help.Cell("A11").Value = "Invoice Date";
                help.Cell("B11").Value = "Created Date";
                help.Cell("A12").Value = "Invoice Period";
                help.Cell("B12").Value = "Invoice Period";
                help.Cell("A13").Value = "Customer Name";
                help.Cell("B13").Value = "Customer Name";
                help.Cell("A14").Value = "Order Number";
                help.Cell("B14").Value = "Order Number";
                help.Cell("A15").Value = "Order Detail Number";
                help.Cell("B15").Value = "Order Detail Number";
                //help.Cell("B16").Style.Alignment.WrapText = true;
                help.Cell("A16").Value = "Order Date";
                help.Cell("B16").Value = "Order Date";
                help.Cell("A17").Value = "Delivery Date";
                help.Cell("B17").Value = "Delivery Date";
                help.Cell("A18").Value = "Order Delivery Type";
                help.Cell("B18").Value = "Order Delivery Type";
                help.Cell("A19").Value = "Order Quantity";
                help.Cell("B19").Value = "Order Quantity";
                help.Cell("A20").Value = "Order Status";
                help.Cell("B20").Value = "Order Status Like Delivered";
                help.Cell("A21").Value = "Product Group";
                help.Cell("B21").Value = "Product Group";
                help.Cell("A22").Value = "Product Id";
                help.Cell("B22").Value = "Product Id";
                help.Cell("A23").Value = "Product Name";
                help.Cell("B23").Value = "Product Name";
                help.Cell("A24").Value = "Selling Price";
                help.Cell("B24").Value = "Product Selling Price";
                help.Cell("A25").Value = "Weight";
                help.Cell("B25").Value = "Product Weight";
                help.Cell("A26").Value = "Commision Fee(%)";
                help.Cell("B26").Value = "Commision Fee";

                ws.Range("A10:N10").Style.Font.Bold = true;

                ws.Cell("A10").Value = "Name";
                ws.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("B10").Value = "Order Number";
                ws.Cell("B10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("C10").Value = "Order Number Detail";
                ws.Cell("C10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("D10").Value = "Product Id";
                ws.Cell("D10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("E10").Value = "Product Name";
                ws.Cell("E10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("F10").Value = "Group";
                ws.Cell("F10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("G10").Value = "Selling Price";
                ws.Cell("G10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("H10").Value = "Weight";
                ws.Cell("H10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("I10").Value = "Commision Fee(%)";
                ws.Cell("I10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("J10").Value = "Order Date";
                ws.Cell("J10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("K10").Value = "Delivery Date";
                ws.Cell("K10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("L10").Value = "Order Delivery Type";
                ws.Cell("L10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("M10").Value = "Order Quantity";
                ws.Cell("M10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("N10").Value = "Status";
                ws.Cell("N10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                string getnew = @"select		username,order_number,order_num_det, pro.Product_id, pro.Product_Name, pro.Your_selling_price, cg.cat_grp_name, pro.P_weight,tc.commission_fee,order_quantity,order_date,item_delivery_date,order_deliverytype,toi.Status 
                                  from		    tblorderitem as toi 
                                  inner join	tblorderdetails as tod 
                                  on			toi.order_num_det=concAT(tod.prefix,tod.order_number)
                                  inner join	tbl_login as tl 
                                  on			tl.email_id = tod.customer_emailid 
                                  left join	    Products as pro
                                  on			pro.Product_id=toi.Product_id 
                                  inner join Category_Group as cg
                                  on			cg.cat_grp_id=pro.Cat_group_id
                                  left join	    Category as tc 
                                  on			tc.cat_id = pro.Sub_cat_id
                                  where		    Convert(datetime, tod.order_date,103) BETWEEN Convert(datetime,'" + start + "', 103) AND Convert(datetime,'" + end + "', 103) and toi.vender_emailid = '" + ssss + "' and toi.Status = 'Delivered' and CONVERT(datetime,toi.delivery_after_date,103)<= getdate()";
                dsnew = objcrud.dataset_(getnew);
                x = 10;
                rngborder = dsnew.Tables[0].Rows.Count + 1;
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < dsnew.Tables[0].Rows.Count; k++)
                    {

                        prod_id = dsnew.Tables[0].Rows[k]["Product_id"].ToString();
                        product_grp = dsnew.Tables[0].Rows[k]["cat_grp_name"].ToString();
                        ord_qnt = dsnew.Tables[0].Rows[k]["order_quantity"].ToString();
                        wgt = dsnew.Tables[0].Rows[k]["P_weight"].ToString();
                        sell_price = dsnew.Tables[0].Rows[k]["Your_selling_Price"].ToString();
                        comm_per = dsnew.Tables[0].Rows[k]["commission_fee"].ToString();
                        x++;

                        index = x;
                        ws.Cell("A" + index).Value = dsnew.Tables[0].Rows[k]["username"].ToString();
                        ws.Cell("A" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("B" + index).Value = dsnew.Tables[0].Rows[k]["order_number"].ToString();
                        ws.Cell("B" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("C" + index).Value = dsnew.Tables[0].Rows[k]["order_num_det"].ToString();
                        ws.Cell("C" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("D" + index).Value = dsnew.Tables[0].Rows[k]["Product_id"].ToString();
                        ws.Cell("D" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("E" + index).Value = dsnew.Tables[0].Rows[k]["Product_Name"].ToString();
                        ws.Cell("E" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("F" + index).Value = dsnew.Tables[0].Rows[k]["cat_grp_name"].ToString();
                        ws.Cell("F" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("G" + index).Value = dsnew.Tables[0].Rows[k]["Your_selling_price"].ToString();
                        ws.Cell("G" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("H" + index).Value = dsnew.Tables[0].Rows[k]["P_weight"].ToString();
                        ws.Cell("H" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("I" + index).Value = dsnew.Tables[0].Rows[k]["commission_fee"].ToString();
                        ws.Cell("I" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("J" + index).Value = dsnew.Tables[0].Rows[k]["order_date"].ToString();
                        ws.Cell("J" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("K" + index).Value = dsnew.Tables[0].Rows[k]["item_delivery_date"].ToString();
                        ws.Cell("K" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("L" + index).Value = dsnew.Tables[0].Rows[k]["order_deliverytype"].ToString();
                        ws.Cell("L" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("M" + index).Value = dsnew.Tables[0].Rows[k]["order_quantity"].ToString();
                        ws.Cell("M" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("N" + index).Value = dsnew.Tables[0].Rows[k]["Status"].ToString();
                        ws.Cell("N" + index).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range("A" + index + ":" + "N" + index).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Range("A" + index + ":" + "N" + index).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        double.TryParse(wgt, out weight);
                        double.TryParse(comm_per, out comm_price);

                        per = 100;
                        comm = ((Convert.ToDouble(sell_price) * comm_price) / per);
                        finalcomm = finalcomm + (comm * Convert.ToDouble(ord_qnt));



                        totclosing = 0;
                        close1 = 10;
                        close2 = 20;
                        close3 = 40;
                        if (Convert.ToDouble(sell_price) > 0 && Convert.ToDouble(sell_price) <= 500)
                        {
                            closing_fee = close1 * Convert.ToDouble(ord_qnt);
                            finalclose = closing_fee;
                        }
                        else if (Convert.ToDouble(sell_price) > 500 && Convert.ToDouble(sell_price) <= 1000)
                        {
                            closing_fee = close2 * Convert.ToDouble(ord_qnt);
                            finalclose = closing_fee;
                        }
                        else if (Convert.ToDouble(sell_price) > 1000)
                        {
                            closing_fee = close3 * Convert.ToDouble(ord_qnt);
                            finalclose = closing_fee;
                        }

                        totclo = totclo + finalclose;
                        //Total Shipping Charge Calculation
                        gms = 40;
                        gms500u = 40;
                        kg5 = 90;
                        kg5u = 19;
                        kg12 = 210;
                        kg12u = 12.50;

                        kg1 = 1000;
                        int comma = wgt.IndexOf(',');
                        string b = wgt;
                        tot = 0;

                        if (b.Contains('K'))
                        {
                            b = wgt.Substring(0, comma);
                            wgtconvert = (Convert.ToDouble(b) * (kg1));
                            b = Convert.ToString(wgtconvert);
                        }
                        else
                        {
                            b = wgt.Substring(0, comma);
                        }
                        mult = Convert.ToDouble(b);
                        if (mult <= 500)
                        {
                            ship = gms;
                            finalship = ship * Convert.ToDouble(ord_qnt);
                        }

                        else if (mult >= 501 && mult < 5000)
                        {
                            double extra = (mult - 500);
                            if (extra <= 500)
                            {
                                ship = gms + (gms500u * 1);
                                finalship = ship * Convert.ToDouble(ord_qnt);
                            }
                            else if (extra > 500)
                            {
                                double my = (extra / 500);
                                double aa = Math.Ceiling(my);
                                ship = (gms + (gms500u * aa));
                                finalship = ship * Convert.ToDouble(ord_qnt);
                            }
                        }
                        else if (mult == 5000)
                        {
                            finalship = kg5 * Convert.ToDouble(ord_qnt);
                        }
                        else if (mult >= 5001 && mult < 12000)
                        {
                            double extra = (mult - 5000);
                            if (extra <= 1000)
                            {
                                ship = kg5 + (kg5u * 1);
                                finalship = ship * Convert.ToDouble(ord_qnt);
                            }
                            else if (extra > 1000)
                            {
                                double my = (extra / 1000);
                                double aa = Math.Ceiling(my);
                                ship = (kg5 + (kg5u * aa));
                                finalship = ship * Convert.ToDouble(ord_qnt);
                            }
                        }
                        else if (mult == 12000)
                        {
                            finalship = kg12 * Convert.ToDouble(ord_qnt);
                        }
                        else if (mult >= 12001)
                        {
                            double extra = (mult - 12000);
                            if (extra <= 1000)
                            {
                                ship = kg12 + (kg12u * 1);
                                finalship = ship * Convert.ToDouble(ord_qnt);
                            }
                            else if (extra > 1000)
                            {
                                double my = (extra / 1000);
                                double aa = Math.Ceiling(my);
                                ship = (kg12 + (kg12u * aa));
                                finalship = ship * Convert.ToDouble(ord_qnt);
                            }
                        }
                        totship = totship + finalship;
                    }
                    tot = tot + totship;
                    totcomm = totcomm + finalcomm;
                    totclosing = totclosing + totclo;
                    taxable = tot + totcomm + totclosing;

                    double GST, rcs, gst;
                    per = 100;
                    double.TryParse(taxable.ToString(), out rcs);
                    double.TryParse("18", out gst);
                    GST = ((rcs * gst) / per);
                    Gst1 = GST;

                    totalget = taxable + Gst1;


                    int insx = 10;
                    int ins = insx + 3;
                    int cnt = dsnew.Tables[0].Rows.Count + ins + 1;




                    //int insx = 10;
                    //int ins = insx + 1;
                    //int cnt = ins + dsnew.Tables[0].Rows.Count;

                    //ws.Range("A" + ins + ":" + "N" + cnt).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    //ws.Range("A" + cnt + ":" + "N" + cnt).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                }
                else
                {
                    ship_charge = 0.0;
                }
                tdscal.ShowGridLines = false;
                tdscal.ColumnWidth = 20;
                tdscal.Style.Font.FontSize = 14;
                tdscal.Range("C1:E2").Merge();
                tdscal.Cell("C1").Value = "This Part of the invoice will help you map the different fee types with relevant TDS section and applicable TDS rates.";
                tdscal.Cell("C1").Style.Alignment.SetWrapText(true);
                tdscal.Cell("C1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                tdscal.Cell("C1").Style.Fill.BackgroundColor = XLColor.Red;
                tdscal.Cell("C1").Style.Font.FontColor = XLColor.White;
                tdscal.Cell("C5").Value = "Sr.No";
                tdscal.Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C6").Value = "1";
                tdscal.Cell("C6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C7").Value = "2";
                tdscal.Cell("C7").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C8").Value = "3";
                tdscal.Cell("C8").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C9").Value = "4";
                tdscal.Cell("C9").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C10").Value = "5";
                tdscal.Cell("C10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C11").Value = "6";
                tdscal.Cell("C11").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C12").Value = "7";
                tdscal.Cell("C12").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C13").Value = "8";
                tdscal.Cell("C13").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C14").Value = "9";
                tdscal.Cell("C14").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C15").Value = "10";
                tdscal.Cell("C15").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C16").Value = "11";
                tdscal.Cell("C16").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C17").Value = "12";
                tdscal.Cell("C17").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C18").Value = "13";
                tdscal.Cell("C18").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Range("C19:D19").Merge();
                tdscal.Cell("C19").Value = "taxable turnover";
                tdscal.Cell("C19").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Range("C20:D20").Merge();
                tdscal.Cell("C20").Value = "GST @18%";
                tdscal.Cell("C20").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Range("C21:D21").Merge();
                tdscal.Cell("C21").Value = "Total";
                tdscal.Cell("C21").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                tdscal.Cell("D5").Value = "Description";
                tdscal.Cell("D5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D6").Value = "Shipping Charges";
                tdscal.Cell("D6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D7").Value = "Commision Fee";
                tdscal.Cell("D7").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D8").Value = "Collection Fee";
                tdscal.Cell("D8").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D9").Value = "Fixed Fee";
                tdscal.Cell("D9").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D10").Value = "Cancellation Fee";
                tdscal.Cell("D10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D11").Value = "Emi Convenience Fee";
                tdscal.Cell("D11").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D12").Value = "Fee Discount";
                tdscal.Cell("D12").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D13").Value = "Pick and Pack Fee";
                tdscal.Cell("D13").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D14").Value = "Storage Fee";
                tdscal.Cell("D14").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D15").Value = "Removal Fee";
                tdscal.Cell("D15").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D16").Value = "Next Day Delivery Fee";
                tdscal.Cell("D16").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D17").Value = "Same Day Delivery Fee";
                tdscal.Cell("D17").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D18").Value = "Service Cancellation Fee";
                tdscal.Cell("D18").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D18").Style.Alignment.SetWrapText(true);
                tdscal.Cell("E5").Value = "Amount";
                tdscal.Cell("E5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                tdscal.Cell("E6").Value = tot.ToString();
                tdscal.Cell("E6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E7").Value = totcomm.ToString();
                tdscal.Cell("E7").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E8").Value = coll_fee;
                tdscal.Cell("E8").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E9").Value = totclosing.ToString();
                tdscal.Cell("E9").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E10").Value = canc_fee;
                tdscal.Cell("E10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E11").Value = emi_fee;
                tdscal.Cell("E11").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E12").Value = fee_dis;
                tdscal.Cell("E12").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E13").Value = pick_fee;
                tdscal.Cell("E13").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E14").Value = storage_fee;
                tdscal.Cell("E14").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E15").Value = removal_fee;
                tdscal.Cell("E15").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E16").Value = next_fee;
                tdscal.Cell("E16").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E17").Value = same_fee;
                tdscal.Cell("E17").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E18").Value = service_fee;
                tdscal.Cell("E18").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E19").Value = taxable.ToString();
                tdscal.Cell("E19").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E20").Value = Gst1.ToString();
                tdscal.Cell("E20").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E21").Value = totalget.ToString();
                tdscal.Cell("E21").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                tdscal.Range("C5:E5").Style.Font.Bold = true;

                for (int b = 5; b < 22; b++)
                {

                    tdscal.Cell("C" + b).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    tdscal.Cell("D" + b).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    tdscal.Range("C" + b + ":E" + b).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                }
                tdscal.Range("C25:E25").Merge();
                tdscal.Cell("C25").Value = "TDS detail for this Invoice.";
                tdscal.Cell("C25").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                tdscal.Range("C26:E26").Merge();
                tdscal.Cell("C26").Value = "TDS Rates Corresponding to Invoice Componenets.";
                tdscal.Cell("C26").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                tdscal.Cell("C27").Value = "Fee Types";
                tdscal.Cell("C27").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D27").Value = "Applicable TDS Section";
                tdscal.Cell("D27").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D27").Style.Alignment.SetWrapText(true);
                tdscal.Cell("E27").Value = "Applicable TDS Rate";
                tdscal.Cell("E27").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E27").Style.Alignment.SetWrapText(true);
                tdscal.Range("C27:E27").Style.Font.Bold = true;

                for (int t = 27; t < 40; t++)
                {
                    tdscal.Cell("C" + t).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    tdscal.Cell("D" + t).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    tdscal.Range("C" + t + ":E" + t).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
                tdscal.Range("B49:H49").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                tdscal.Cell("C28").Value = "Shipping Charges";
                tdscal.Cell("C28").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C29").Value = "Commision Fee";
                tdscal.Cell("C29").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C30").Value = "Collection Fee";
                tdscal.Cell("C30").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C31").Value = "Fixed Fee";
                tdscal.Cell("C31").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C32").Value = "Cancellation Fee";
                tdscal.Cell("C32").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C33").Value = "Pick and Pack Fee";
                tdscal.Cell("C33").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C34").Value = "Storage Fee";
                tdscal.Cell("C34").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C35").Value = "Removal Fee";
                tdscal.Cell("C35").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C36").Value = "Next Day Delivery Fee";
                tdscal.Cell("C36").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C37").Value = "Same Day Delivery Fee";
                tdscal.Cell("C37").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C38").Value = "Ad Services Fee";
                tdscal.Cell("C38").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C39").Value = "Service Cancellation Fee";
                tdscal.Cell("C40").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                //var coltd = tdscal.Column("C");
                //coltd.Width = 55;

                tdscal.Cell("D28").Value = "194C";
                tdscal.Cell("D28").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D29").Value = "194H";
                tdscal.Cell("D29").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D30").Value = "194H";
                tdscal.Cell("D30").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D31").Value = "194H";
                tdscal.Cell("D31").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D32").Value = "194H";
                tdscal.Cell("D32").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D33").Value = "194C";
                tdscal.Cell("D33").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D34").Value = "194I";
                tdscal.Cell("D34").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D35").Value = "194C";
                tdscal.Cell("D35").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D36").Value = "194C";
                tdscal.Cell("D36").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D37").Value = "194C";
                tdscal.Cell("D37").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D38").Value = "194C";
                tdscal.Cell("D38").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D39").Value = "194H";
                tdscal.Cell("D40").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;


                tdscal.Cell("E28").Value = "2%";
                tdscal.Cell("E28").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E29").Value = "5%";
                tdscal.Cell("E29").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E30").Value = "5%";
                tdscal.Cell("E30").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E31").Value = "5%";
                tdscal.Cell("E31").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E32").Value = "5%";
                tdscal.Cell("ED32").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E33").Value = "2%";
                tdscal.Cell("E33").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E34").Value = "10%";
                tdscal.Cell("E34").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E35").Value = "2%";
                tdscal.Cell("E35").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E36").Value = "2%";
                tdscal.Cell("E36").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E37").Value = "2%";
                tdscal.Cell("E37").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E38").Value = "2%";
                tdscal.Cell("E38").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E39").Value = "5%";
                tdscal.Cell("E40").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                tdscal.Range("B43:F46").Merge();
                tdscal.Cell("B43").Value = "This part of the invoice give you clarity on total TDS amount to be paid to government for a given month.You can also view the amount for differnet TDS sections.If you have been issued with Nil WHT certificate, you can see the Nil WHT exemption limit, amount consumed so far and remaining balance details.";
                tdscal.Cell("B43").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                tdscal.Cell("B43").Style.Alignment.SetWrapText(true);
                tdscal.Cell("B43").Style.Fill.BackgroundColor = XLColor.Red;
                tdscal.Cell("B43").Style.Font.FontColor = XLColor.White;
                tdscal.Cell("B48").Value = "TDS Calculations.";
                tdscal.Cell("B48").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                tdscal.Cell("B49").Value = "Invoice Period";
                tdscal.Cell("B49").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("B49").Style.Alignment.SetWrapText(true);
                tdscal.Cell("C49").Value = "Section Wise Invoice Amounts";
                tdscal.Cell("C49").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C49").Style.Alignment.SetWrapText(true);
                tdscal.Cell("D49").Value = "NIL WHT comminication date";
                tdscal.Cell("D49").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D49").Style.Alignment.SetWrapText(true);
                tdscal.Cell("E49").Value = "NIL WHT annual exemption limit";
                tdscal.Cell("E49").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("F49").Value = "NIL WHT consumed so far";
                tdscal.Cell("F49").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("G9").Value = "NIL WHT balance";
                tdscal.Cell("G49").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("H49").Value = "TDS amount,calculate using rates as in above table(Rs.)";
                tdscal.Cell("H49").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E49").Style.Alignment.SetWrapText(true);
                tdscal.Cell("F49").Style.Alignment.SetWrapText(true);
                tdscal.Cell("G49").Style.Alignment.SetWrapText(true);
                tdscal.Cell("H49").Style.Alignment.SetWrapText(true);

                tdscal.Cell("A49").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                tdscal.Cell("B49").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                tdscal.Cell("C49").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                tdscal.Cell("D49").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                tdscal.Cell("E49").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                tdscal.Cell("F49").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                tdscal.Cell("G49").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                tdscal.Cell("A49").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                tdscal.Cell("A49").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                h194 = totcomm + coll_fee + totclosing + canc_fee + canc_fee;
                c194 = totship + removal_fee + next_fee + same_fee + service_fee;
                i194 = storage_fee;
                per = 100;
                hper = ((h194 * 5) / per);

                cper = ((c194 * 2) / per);

                iper = ((i194 * 10) / per);

                tdsgn = hper + cper + iper;


                tdscal.Range("A49:G49").Style.Font.Bold = true;
                tdscal.Range("B50:B52").Merge();
                tdscal.Cell("B50").Value = "June,2016";
                tdscal.Cell("B50").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("B50").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                tdscal.Cell("C50").Value = "194H:" + h194.ToString();
                tdscal.Cell("C50").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C51").Value = "194C:" + c194.ToString();
                tdscal.Cell("C51").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("C52").Value = "194I:" + i194.ToString();
                tdscal.Cell("C52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D50").Value = "NO NIL WHT for this period.";
                tdscal.Cell("D50").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("D50").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                tdscal.Cell("D50").Style.Alignment.SetWrapText(true);
                tdscal.Cell("E50").Value = "0.0";
                tdscal.Cell("E50").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E51").Value = "0.0";
                tdscal.Cell("E51").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("E52").Value = "0.0";
                tdscal.Cell("E52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("F50").Value = "Nil";
                tdscal.Cell("F50").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("F51").Value = "Nil";
                tdscal.Cell("F51").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("F52").Value = "Nil";
                tdscal.Cell("F52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("G50").Value = "Nil";
                tdscal.Cell("G50").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("G51").Value = "Nil";
                tdscal.Cell("G51").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("G52").Value = "Nil";
                tdscal.Cell("G52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                tdscal.Cell("H50").Value = "194H:" + hper;
                tdscal.Cell("H50").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("H51").Value = "194C:" + cper;
                tdscal.Cell("H51").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                tdscal.Cell("H52").Value = "194I:" + iper.ToString();
                tdscal.Cell("H52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;


                tdscal.Cell("B55").Value = "TDS amount to be paid to government " + tdsgn.ToString() + " /- Rs.";
                tdscal.Cell("B55").RichText.Substring(36, 3).SetBold();
                tdscal.Cell("B55").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                tdscal.Range("B55:E55").Merge();

                for (int b = 49; b < 53; b++)
                {
                    tdscal.Cell("B" + b).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    tdscal.Cell("C" + b).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    tdscal.Cell("D" + b).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    tdscal.Cell("E" + b).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    tdscal.Cell("F" + b).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    tdscal.Cell("G" + b).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    tdscal.Cell("H" + b).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    //tdscal.Range("E" + b + ":H" + b).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                }
                tdscal.Range("B52:H52").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                tdscal.Cell("B50").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                tdscal.Cell("B51").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                tdscal.Cell("B52").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                tdscal.Cell("C50").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                tdscal.Cell("C51").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                tdscal.Cell("C52").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                for (int b = 50; b < 53; b++)
                {

                    tdscal.Cell("E" + b).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    tdscal.Cell("F" + b).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    tdscal.Cell("G" + b).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    tdscal.Cell("H" + b).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    //tdscal.Range("E" + b + ":H" + b).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                }

                //ws.Range("A9:N9").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Range("A10:N10").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;


            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=" + ViewState["ReportName"].ToString() + "_" + DateTime.Today.ToString("dd-MM-yyyy") + ".xlsx");
            MemoryStream MyMemoryStream = new MemoryStream();
            wb.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
}


