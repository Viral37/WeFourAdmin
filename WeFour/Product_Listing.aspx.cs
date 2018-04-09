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
using Shreeman.Models;
public partial class Product_Listing : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    string loginemail = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            findall();
        }
    }

    public void findall()
    {
        SqlParameter[] lstparameter = new SqlParameter[1];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "Findall" };
        DataSet dsfindall = objsql.ExecuteQuery("FindDataProcedure", CommandType.StoredProcedure, lstparameter);
        if (dsfindall.Tables[0].Rows.Count > 0)
        {
            lstmaingroup.DataSource = dsfindall;
            lstmaingroup.DataTextField = "GroupName"; 
            lstmaingroup.DataValueField = "GroupId";
            lstmaingroup.DataBind();
            lstmaingroup.Visible = true;
        }
    }

    protected void lstmaingroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsfindcat = null;
        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "Findcatbygroup" };
        lstparameter[1] = new SqlParameter { ParameterName = "@ID", Value = lstmaingroup.SelectedValue };

        dsfindcat = objsql.ExecuteQuery("FindDataProcedure", CommandType.StoredProcedure, lstparameter);

        if (dsfindcat.Tables[0].Rows.Count > 0)
        {
            lstsubgroup.DataValueField = "CategoryId";
            lstsubgroup.DataTextField = "CategoryName";
            lstsubgroup.DataSource = dsfindcat;
            lstsubgroup.DataBind();
            subcatpanel.Visible = true;
            alert.Visible = false;
            childpanel.Visible = false;
            btncreate.Visible = false;
        }
        else
        {
            btncreate.Visible = false;
            childpanel.Visible = false;
            subcatpanel.Visible = false;
            alert.Visible = true;
        }
    }

    protected void lstsubgroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsfindsubcat = null;
        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FetchSubcategorybycategory" };
        lstparameter[1] = new SqlParameter { ParameterName = "@ID", Value = lstsubgroup.SelectedValue };
        dsfindsubcat = objsql.ExecuteQuery("CreateGroupProcedure", CommandType.StoredProcedure, lstparameter);
        if (dsfindsubcat.Tables[0].Rows.Count > 0)
        {
            lstchildgroup.DataSource = dsfindsubcat;
            lstchildgroup.DataValueField = "CategoryId";
            lstchildgroup.DataTextField = "CategoryName";
            lstchildgroup.DataBind();
            childpanel.Visible = true;
            alert.Visible = false;
            btncreate.Visible = false;
        }
        else
        {
            btncreate.Visible = false;
            childpanel.Visible = false;
            alert.Visible = true;
        }
    }

    protected void lstchildgroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        alert.Visible = false;
        btncreate.Visible = true;
    }

    protected void btncreate_ServerClick(object sender, EventArgs e)
    {
        loginemail = Context.Request.Cookies["logincookie"].Value;
        int groupid = Convert.ToInt32(lstmaingroup.SelectedValue.ToString());
        int catid = Convert.ToInt32(lstsubgroup.SelectedValue.ToString());
        int subcatid = Convert.ToInt32(lstchildgroup.SelectedValue.ToString());

        string groupname = lstmaingroup.SelectedItem.ToString();
        string catname = lstsubgroup.SelectedItem.ToString();
        string subcatname = lstchildgroup.SelectedItem.ToString();

        DateTime date = DateTime.Now;
        string dateonly = date.Month.ToString() + date.Year.ToString().Substring(2) + "sm";

        SqlParameter[] lstparameter = new SqlParameter[7];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "AddProduct" };
        lstparameter[1] = new SqlParameter { ParameterName = "@GroupName", Value = groupname };
        lstparameter[2] = new SqlParameter { ParameterName = "@CategoryName", Value = catname };
        lstparameter[3] = new SqlParameter { ParameterName = "@SubcategoryName", Value = subcatname };
        lstparameter[4] = new SqlParameter { ParameterName = "@CreatedBy", Value = loginemail };
        lstparameter[5] = new SqlParameter { ParameterName = "@ProStatus", Value = "Draft" };
        lstparameter[6] = new SqlParameter { ParameterName = "@LastUpdateId", Direction = ParameterDirection.ReturnValue };
        int row = objsql.ExecuteNonQuery("ManageProduct",CommandType.StoredProcedure,lstparameter);

        int LastProductId = Convert.ToInt32(lstparameter[6].Value);
        if (row < 0)
        {
            Response.Redirect("Add.aspx?&ProId=" + LastProductId + "&groupname=" + groupname + "&catname=" + catname + "&subcatname=" + subcatname + "");
            //Response.Redirect("test.aspx?groupname=" + groupname + "&catname=" + catname + "&subcatname=" + subcatname + "");
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
               "<script type='text/javascript'>alert('Error.');window.location.replace('Product_Listing.aspx');</script>");
        }

        //Server.Transfer("ViewFull_order.aspx?oname=" + name + "&pid=" + pid + "");
        //Response.Write("<script>");
        //Response.Write("window.open(_parent)");
        //Response.Write("</script>");
    }
    
}