using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
public partial class Vender_invoice2 : System.Web.UI.Page
{
    CRUD objcrud = new CRUD();
    string tbl, str, gettxt, dsget, prod_id, status, product_grp, ord_qnt, wgt, sell_price, comm_per;
    Double weight, gms, kg5, kg12, gms500u, kg5u, kg12u, ship, getwgt, finalwgt, wgtconvert, kg1, mult, finalship, totship, tot, closing_fee, close, finalclose, totclosing, totclo, close1, close2, close3, taxable, Gst1, totalget, per, comm, finalcomm, totcomm, comm_price, h194, hper, c194, cper, i194, iper;

    Double collectiontext, cancellationtext, emitext, feetext, picktext, storagetext, removaltext, nexttext, sametext, service_text, tdsgn;

    DataSet dsnew = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btngen_Click(object sender, EventArgs e)
    {
        collectiontext = 0.0;
        cancellationtext = 0.0;
        emitext = 0.0;
        feetext = 0.0;
        picktext = 0.0;
        storagetext = 0.0;
        removaltext = 0.0;
        nexttext = 0.0;
        sametext = 0.0;
        service_text = 0.0;
        string getd = hd.Value;
        //string start = getd.Substring(0, getd.IndexOf("-")).ToStr
        //String end= getd.Substring(0, getd.IndexOf("-")+1).ToString();
        string start = getd.Substring(0, getd.IndexOf("-"));
        string end = getd.Substring(getd.IndexOf("-") + 1);
        //string sDate = "";
        //string edate = "";
        //// CONVERT DATE FORMAT.
        //sDate = DateTime.ParseExact(
        //    start, "MM/dd/yyyy", null).ToString("dd / MM / yyyy");
        //edate = DateTime.ParseExact(
        //end, "MM/dd/yyyy", null).ToString("dd / MM / yyyy");

        Document pdfDoc = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        PdfPTable pt = new PdfPTable(1);
        pt.TotalWidth = 595f;

        pt.LockedWidth = true;
        pt.HorizontalAlignment = 0;
        //leave a gap before and after the table

        PdfPCell cell = null;
        cell = new PdfPCell(new Phrase("TDS Calculation made easier with Commision invoice", FontFactory.GetFont("Arial", 18, BaseColor.WHITE)));
        cell.BackgroundColor = BaseColor.BLUE;
        pt.SpacingBefore = 20f;
        pt.SpacingAfter = 30f;
        cell.Colspan = 2;
        cell.Border = 0;
        //cell.BorderWidthBottom = 1;
        cell.HorizontalAlignment = 1;
        cell.PaddingBottom = 5f;
        pt.AddCell(cell);

        PdfPTable pt1 = new PdfPTable(1);
        cell = new PdfPCell(new Phrase("The new Commision Invoice has TDS Calculation guide which will help you calculate the right TDS amount.This amount should be paid to government will be reimbursed by BudgetOk(unless seller has been issued a Nil With holding certificate.)", FontFactory.GetFont("Arial", 14, BaseColor.BLACK)));
        cell.BackgroundColor = BaseColor.WHITE;
        cell.Colspan = 2;
        cell.Border = 0;
        //cell.BorderWidthBottom = 1;
        cell.HorizontalAlignment = 1;
        cell.PaddingBottom = 5f;
        pt1.AddCell(cell);

        PdfPTable pt2 = new PdfPTable(1);
        cell = new PdfPCell(new Phrase("Let Us take you through the new commision invoice:", FontFactory.GetFont("Arial", 18, Font.BOLD, BaseColor.WHITE)));
        cell.BackgroundColor = BaseColor.RED;
        pt2.SpacingBefore = 20f;
        pt2.SpacingAfter = 30f;
        cell.Colspan = 2;
        cell.Border = 0;
        //cell.BorderWidthBottom = 1;
        cell.HorizontalAlignment = 1;
        cell.PaddingBottom = 5f;

        pt2.TotalWidth = 595f;

        pt2.LockedWidth = true;
        pt2.HorizontalAlignment = 0;
        pt2.AddCell(cell);

        PdfPTable table = new PdfPTable(2);
        //var path = "logo_9.png";
        //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(path);
        //img.ScaleAbsolute(100f, 70f);
        //cell = new PdfPCell(img);
        string stri = @"Bazarish";

        cell = new PdfPCell(new Phrase(str));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;

        cell.Border = Rectangle.NO_BORDER;
        table.AddCell(cell);
        //table.DefaultCell.Border = Rectangle.NO_BORDER;
        string vadd = @"Budgetok,F-14,thakkar Arcade
sardar gunj Road,
Near People’s Co-Operative Bank,
Anand, Gujarat 388001";
        cell = new PdfPCell(new Phrase(vadd));
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        cell.Border = Rectangle.NO_BORDER;
        table.AddCell(cell);

        PdfPTable table1 = new PdfPTable(2);
        table1.SpacingBefore = 20f;
        table1.SpacingAfter = 30f;

        PdfPTable table2 = new PdfPTable(3);
        table2.SpacingBefore = 20f;
        table2.SpacingAfter = 100f;


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
                    cell = new PdfPCell(new Phrase("InvoiceDate:" + DateTime.Today.ToString("dd-MM-yyyy")));
                    cell.Border = Rectangle.NO_BORDER;
                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Telephone:" + dsdetail.Tables[0].Rows[j]["contact"].ToString()));
                    cell.Border = Rectangle.NO_BORDER;
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Invoice Period:" + start + " - " + end));
                    cell.Border = Rectangle.NO_BORDER;
                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Email:" + ssss));
                    cell.Border = Rectangle.NO_BORDER;
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Display Name:" + dsdetail.Tables[0].Rows[j]["username"].ToString()));
                    cell.Border = Rectangle.NO_BORDER;
                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Contact No:" + dsdetail.Tables[0].Rows[j]["contact"].ToString()));
                    cell.Border = Rectangle.NO_BORDER;
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Business Name:" + dsdetail.Tables[0].Rows[j]["buss_name"].ToString()));
                    cell.Border = Rectangle.NO_BORDER;
                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase("PAN:" + dsdetail.Tables[0].Rows[j]["com_pan"].ToString()));
                    cell.Border = Rectangle.NO_BORDER;
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase(dsdetail.Tables[0].Rows[j]["reg_add"].ToString()));
                    cell.Border = Rectangle.NO_BORDER;
                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase("CIN:" + dsdetail.Tables[0].Rows[j]["com_cin"].ToString()));
                    cell.Border = Rectangle.NO_BORDER;
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table1.AddCell(cell);
                    table1.DefaultCell.Border = Rectangle.NO_BORDER;
                    table1.DefaultCell.Padding = 5f;



                }
            }




            string getstring = @"select		distinct toi.Product_id,toi.Status,cg.cat_grp_name,toi.order_quantity,tod.order_date,toi.sell_price,pro.P_weight,tc.commission_fee 
                                 from		tblorderitem as toi 
                                 inner join	tblorderdetails as tod 
                                 on		    toi.order_num_det=concAT(tod.prefix,tod.order_number)
                                 left join	Products as pro
                                 on			pro.Product_id =toi.Product_id 
                                 inner join Category_Group as cg
                                 on			cg.cat_grp_id=pro.Cat_group_id
                                 left join	Category as tc 
                                 on			tc.cat_id = pro.Sub_cat_id
                                 where		Convert(datetime,tod.order_date,103) BETWEEN Convert(datetime,'" + start + "',103) AND Convert(datetime,'" + end + "',103) and toi.vender_emailid = '" + ssss + "'  and toi.Status = 'Delivered' and pro.P_weight!= 'NULL' and CONVERT(datetime,toi.delivery_after_date,103)<= getdate()";

            dsnew = objcrud.dataset_(getstring);
            collectiontext = 0.0;
            cancellationtext = 0.0;
            emitext = 0.0;
            feetext = 0.0;
            picktext = 0.0;
            storagetext = 0.0;
            removaltext = 0.0;
            nexttext = 0.0;
            sametext = 0.0;
            service_text = 0.0;
            if (dsnew.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsnew.Tables[0].Rows.Count; k++)
                {
                    prod_id = dsnew.Tables[0].Rows[k]["Product_id"].ToString();
                    product_grp = dsnew.Tables[0].Rows[k]["cat_grp_name"].ToString();
                    ord_qnt = dsnew.Tables[0].Rows[k]["order_quantity"].ToString();
                    wgt = dsnew.Tables[0].Rows[k]["P_weight"].ToString();
                    sell_price = dsnew.Tables[0].Rows[k]["sell_price"].ToString();
                    comm_per = dsnew.Tables[0].Rows[k]["commission_fee"].ToString();
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
                Gst1 = Math.Round(GST, 2);

                totalget = taxable + Gst1;

                double cm = Math.Round(totcomm, 2);
                double tax_turn = Math.Round(taxable, 2);
                double tot_get = Math.Round(totalget, 2);
                cell = new PdfPCell(new Phrase("Sr.No", FontFactory.GetFont("Arial", 14, Font.BOLD)));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Description", FontFactory.GetFont("Arial", 14, Font.BOLD)));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Arial", 14, Font.BOLD)));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("1"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Shipping Charges"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(tot.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("2"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Commision Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(cm.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("3"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Collection Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(collectiontext.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("4"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Fixed Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(totclosing.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("5"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Cancellation Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(cancellationtext.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("6"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Emi Convenience Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(emitext.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("7"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Fee Discount"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(feetext.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("8"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Pick and Pack Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(picktext.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("9"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Storage Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(storagetext.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("10"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Removal Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(removaltext.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("11"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Next Day Delivery Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(nexttext.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("12"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Same Day Delivery Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(sametext.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("13"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Service Cancellation Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(service_text.ToString()));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("taxable turnover", FontFactory.GetFont("Arial", 10, Font.BOLD)));
                cell.Colspan = 2;
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(tax_turn.ToString(), FontFactory.GetFont("Arial", 10, Font.BOLD)));
                //cell.Border = Rectangle.NO_BORDER;
                //cell.Border = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("CGST @9%+SGST@9%", FontFactory.GetFont("Arial", 10, Font.BOLD)));
                cell.Colspan = 2;
                table2.AddCell(cell);

                cell = new PdfPCell(new Phrase(Gst1.ToString(), FontFactory.GetFont("Arial", 10, Font.BOLD)));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 10, Font.BOLD)));
                cell.Colspan = 2;
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(tot_get.ToString(), FontFactory.GetFont("Arial", 10, Font.BOLD)));
                table2.AddCell(cell);


            }
            else
            {
                cell = new PdfPCell(new Phrase("Sr.No", FontFactory.GetFont("Arial", 14, Font.BOLD)));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Description", FontFactory.GetFont("Arial", 14, Font.BOLD)));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Arial", 14, Font.BOLD)));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("1"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Shipping Charges"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("2"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Commision Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("3"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Collection Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("4"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Fixed Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("5"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Cancellation Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("6"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Emi Convenience Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("7"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Fee Discount"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("8"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Pick and Pack Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("9"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Storage Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("10"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Removal Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("11"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Next Day Delivery Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("12"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Same Day Delivery Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("13"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Service Cancellation Fee"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0"));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("taxable turnover", FontFactory.GetFont("Arial", 10, Font.BOLD)));
                cell.Colspan = 2;
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("0.0", FontFactory.GetFont("Arial", 10, Font.BOLD)));
                //cell.Border = Rectangle.NO_BORDER;
                //cell.Border = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("GST @18%", FontFactory.GetFont("Arial", 10, Font.BOLD)));
                cell.Colspan = 2;
                table2.AddCell(cell);

                cell = new PdfPCell(new Phrase(Gst1.ToString(), FontFactory.GetFont("Arial", 10, Font.BOLD)));
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 10, Font.BOLD)));
                cell.Colspan = 2;
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(totalget.ToString(), FontFactory.GetFont("Arial", 10, Font.BOLD)));
                table2.AddCell(cell);
            }


        }
        PdfPTable tbl3 = new PdfPTable(1);
        cell = new PdfPCell(new Phrase("This Part of the invoice will help you map the different fee types with relevant TDS section and applicable TDS rates.", FontFactory.GetFont("Arial", 13, BaseColor.WHITE)));
        cell.BackgroundColor = BaseColor.RED;
        tbl3.SpacingBefore = 20f;
        tbl3.SpacingAfter = 10f;
        cell.Colspan = 2;
        cell.Border = 0;
        //cell.BorderWidthBottom = 1;
        cell.HorizontalAlignment = 1;
        cell.PaddingBottom = 5f;
        tbl3.TotalWidth = 595f;
        tbl3.LockedWidth = true;
        tbl3.HorizontalAlignment = 0;
        tbl3.AddCell(cell);

        PdfPTable tbl4 = new PdfPTable(1);
        cell = new PdfPCell(new Phrase(""));
        cell.BackgroundColor = BaseColor.GRAY;
        tbl4.SpacingBefore = 50f;
        tbl4.SpacingAfter = 30f;
        cell.Colspan = 2;
        cell.Border = 0;
        cell.FixedHeight = 5f;
        //cell.BorderWidthBottom = 1;
        cell.HorizontalAlignment = 1;
        cell.PaddingBottom = 5f;
        tbl4.AddCell(cell);

        PdfPTable tbl5 = new PdfPTable(1);
        cell = new PdfPCell(new Phrase("TDS detail for this Invoice.", FontFactory.GetFont("Arial", 18, BaseColor.BLACK)));
        cell.BackgroundColor = BaseColor.WHITE;
        cell.Colspan = 2;
        cell.Border = 0;
        //cell.BorderWidthBottom = 1;
        cell.HorizontalAlignment = 1;
        cell.PaddingBottom = 5f;
        tbl5.AddCell(cell);
        cell = new PdfPCell(new Phrase("TDS Rates Corresponding to Invoice Componenets.", FontFactory.GetFont("Arial", 14, BaseColor.BLACK)));
        cell.BackgroundColor = BaseColor.WHITE;
        cell.Colspan = 2;
        cell.Border = 0;
        //cell.BorderWidthBottom = 1;
        cell.HorizontalAlignment = 1;
        cell.PaddingLeft = 5f;
        tbl5.AddCell(cell);



        PdfPTable table6 = new PdfPTable(3);
        table6.SpacingBefore = 20f;
        table6.SpacingAfter = 20f;

        cell = new PdfPCell(new Phrase("Fee Types", FontFactory.GetFont("Arial", 14, Font.BOLD)));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Applicable TDS Section", FontFactory.GetFont("Arial", 14, Font.BOLD)));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Applicable TDS Rate", FontFactory.GetFont("Arial", 14, Font.BOLD)));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Shipping Charges"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("194C"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("2%"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Commision Fee"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("194H"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("5%"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Collection Fee"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("194H"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("5%"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Fixed Fee"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("194H"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("5%"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Cancellation Fee"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("194H"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("5%"));
        table6.AddCell(cell);

        cell = new PdfPCell(new Phrase("Pick and Pack Fee"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("194C"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("2%"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Storage Fee"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("194I"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("10%"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Removal Fee"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("194C"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("2%"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Next Day Delivery Fee"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("194C"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("2%"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Same Day Delivery Fee"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("194C"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("2%"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Ad Services Fee"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("194C"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("2%"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("Service Cancellation Fee"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("194H"));
        table6.AddCell(cell);
        cell = new PdfPCell(new Phrase("5%"));
        table6.AddCell(cell);


        PdfPTable tbl7 = new PdfPTable(1);
        cell = new PdfPCell(new Phrase(@"This part of the invoice give you clarity on total TDS amount to be paid to government for a given month.You can also view the amount for differnet TDS sections. If you have been issued with  Nil WHT certificate, you can see the Nil WHT 
                            exemption limit, amount consumed so far and remaining balance details.", FontFactory.GetFont("Arial", 13, BaseColor.WHITE)));
        cell.BackgroundColor = BaseColor.RED;
        tbl7.SpacingBefore = 10f;
        tbl7.SpacingAfter = 10f;
        cell.Colspan = 2;
        cell.Border = 0;
        //cell.BorderWidthBottom = 1;
        cell.HorizontalAlignment = 1;
        cell.PaddingBottom = 5f;
        tbl7.TotalWidth = 595f;
        tbl7.LockedWidth = true;
        tbl7.HorizontalAlignment = 0;
        tbl7.AddCell(cell);

        PdfPTable tbl8 = new PdfPTable(1);
        cell = new PdfPCell(new Phrase(""));
        cell.BackgroundColor = BaseColor.GRAY;
        tbl8.SpacingBefore = 20f;
        tbl8.SpacingAfter = 20f;
        cell.Colspan = 2;
        cell.Border = 0;
        cell.FixedHeight = 5f;
        //cell.BorderWidthBottom = 1;
        cell.HorizontalAlignment = 1;
        cell.PaddingBottom = 5f;
        tbl8.AddCell(cell);


        PdfPTable table9 = new PdfPTable(7);
        table9.TotalWidth = 590f;
        table9.LockedWidth = true;

        table9.SpacingBefore = 20f;
        table9.SpacingAfter = 20f;
        cell = new PdfPCell(new Phrase("TDS Calculations.", FontFactory.GetFont("Arial", 14, BaseColor.BLACK)));
        cell.BackgroundColor = BaseColor.WHITE;
        cell.Colspan = 7;
        cell.Border = Rectangle.NO_BORDER;

        cell.PaddingBottom = 10f;
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("Invoice Period", FontFactory.GetFont("Arial", 14, Font.BOLD)));
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("Section Wise Invoice Amounts", FontFactory.GetFont("Arial", 14, Font.BOLD)));
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("NIL WHT comminication date", FontFactory.GetFont("Arial", 14, Font.BOLD)));
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("NIL WHT annual exemption limit", FontFactory.GetFont("Arial", 14, Font.BOLD)));
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("NIL WHT consumed so far", FontFactory.GetFont("Arial", 14, Font.BOLD)));
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("NIL WHT balance", FontFactory.GetFont("Arial", 14, Font.BOLD)));
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("TDS amount,calculate using rates as in above table(Rs.)", FontFactory.GetFont("Arial", 14, Font.BOLD)));
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("June,2016"));
        cell.Rowspan = 4;
        cell.PaddingTop = 3f;
        table9.AddCell(cell);

        h194 = totcomm + collectiontext + totclosing + cancellationtext + service_text;
        h194 = Math.Round(h194, 2);
        c194 = totship + removaltext + nexttext + sametext + service_text;
        c194 = Math.Round(c194, 2);

        cell = new PdfPCell(new Phrase("194H:" + h194.ToString()));
        cell.PaddingTop = 5f;
        cell.PaddingBottom = 5f;
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("NO NIL WHT fot this period."));
        cell.PaddingTop = 5f;
        cell.PaddingBottom = 5f;
        cell.Rowspan = 4;
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("0.0"));
        cell.PaddingTop = 5f;
        cell.PaddingBottom = 5f;
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("Nil"));
        cell.PaddingBottom = 5f;
        cell.PaddingTop = 5f;
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("Nil"));
        cell.PaddingBottom = 5f;
        cell.PaddingTop = 5f;
        table9.AddCell(cell);

        i194 = storagetext;
        per = 100;
        hper = ((h194 * 5) / per);
        hper = Math.Round(hper, 2);
        cper = ((c194 * 2) / per);
        cper = Math.Round(hper, 2);
        iper = ((i194 * 10) / per);
        iper = Math.Round(iper, 2);
        cell = new PdfPCell(new Phrase("194H:" + hper));
        cell.PaddingTop = 5f;
        cell.PaddingBottom = 5f;
        table9.AddCell(cell);

        cell = new PdfPCell(new Phrase("194C:" + c194.ToString()));
        cell.PaddingTop = 5f;
        cell.PaddingBottom = 5f;
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("0.0"));
        cell.PaddingTop = 5f;
        cell.PaddingBottom = 5f;
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("Nil"));
        cell.PaddingBottom = 5f;
        cell.PaddingTop = 5f;
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("Nil"));
        cell.PaddingBottom = 5f;
        cell.PaddingTop = 5f;
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("194C:" + cper));
        cell.PaddingBottom = 5f;
        cell.PaddingTop = 5f;
        table9.AddCell(cell);


        cell = new PdfPCell(new Phrase("194I:" + i194.ToString()));
        cell.PaddingTop = 5f;
        cell.PaddingBottom = 5f;
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("0.0"));
        cell.PaddingTop = 5f;
        cell.PaddingBottom = 5f;
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("Nil"));
        cell.PaddingTop = 5f;
        cell.PaddingBottom = 5f;
        table9.AddCell(cell);
        cell = new PdfPCell(new Phrase("Nil"));
        cell.PaddingTop = 5f;
        cell.PaddingBottom = 5f;
        table9.AddCell(cell);


        cell = new PdfPCell(new Phrase("194I:" + iper.ToString()));
        cell.PaddingTop = 5f;
        cell.PaddingBottom = 5f;
        table9.AddCell(cell);

        PdfPTable table10 = new PdfPTable(1);

        tdsgn = hper + cper + iper;
        tdsgn = Math.Round(tdsgn, 2);
        var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
        var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15, Font.UNDERLINE);

        var phrase = new Phrase();
        phrase.Add(new Chunk("TDS amount to be paid to government ", normalFont));
        phrase.Add(new Chunk(tdsgn.ToString(), boldFont));
        phrase.Add(new Chunk(" /- Rs.", normalFont));
        cell = new PdfPCell(phrase);

        cell.BackgroundColor = BaseColor.WHITE;

        cell.Border = Rectangle.NO_BORDER;
        cell.PaddingTop = 5f;
        table10.AddCell(cell);



        pdfDoc.Open();
        pdfDoc.Add(pt);
        pdfDoc.Add(pt1);
        pdfDoc.Add(pt2);
        pdfDoc.Add(table);
        pdfDoc.Add(table1);
        pdfDoc.Add(table2);
        pdfDoc.Add(tbl3);
        pdfDoc.Add(tbl4);
        pdfDoc.Add(tbl5);
        pdfDoc.Add(table6);
        pdfDoc.Add(tbl7);
        pdfDoc.Add(tbl8);
        pdfDoc.Add(table9);
        pdfDoc.Add(table10);
        pdfWriter.CloseStream = false;
        pdfDoc.Close();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Today.ToString("dd-MM-yyyy") + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(pdfDoc);
        Response.End();
    }




}