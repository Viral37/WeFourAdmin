using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Vender_Reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lnk_assured_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "B-Assured Reports");
    }

    protected void lnk_commision_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "Commision Invoices");
    }
    protected void lnk_unsold_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "Unsold listings");
    }


    protected void lnk_order_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "Orders");
    }

    protected void lnk_inwards_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "Consignment Inwards");
    }

    protected void lnk_seller_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "Seller Recalls");
    }

    protected void lnk_weight_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "Weight Anomaly Orders");
    }

    protected void lnk_returns_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "Returns");
    }

    protected void lnk_unsettle_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "Unsettled Transactions");
    }

    protected void lnk_settle_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "Settled Transactions");
    }

    protected void lnk_sales_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "Sales Reports");
    }

    protected void lnk_tds_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "TDS");
    }

    protected void lnk_gst_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate.aspx?ReportName=" + "GSTR return report");
    }

    
}