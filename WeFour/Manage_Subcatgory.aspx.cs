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

public partial class Manage_Subcatgory : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    string loginuser = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            findall();
            BindGrid();
        }
    }
    public void findall()
    {
        SqlParameter[] lstparameter = new SqlParameter[1];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "Findall" };
        DataSet dsfindall = objsql.ExecuteQuery("FindDataProcedure", CommandType.StoredProcedure, lstparameter);

        if (dsfindall.Tables[0].Rows.Count > 0)
        {
            ddgrouplist.DataSource = dsfindall;
            ddgrouplist.DataValueField = "GroupId";
            ddgrouplist.DataTextField = "GroupName";
            ddgrouplist.DataBind();
            ddgrouplist.Items.Insert(0, new ListItem("--Select--", "--Select--"));

        }

    }

    public void BindGrid()
    {
        SqlParameter[] lstparameter = new SqlParameter[1];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FindSubCatgory" };
        DataSet dsfindall = objsql.ExecuteQuery("FindDataProcedure", CommandType.StoredProcedure, lstparameter);

        if (dsfindall.Tables[0].Rows.Count > 0)
        {
            datagridsubcat.DataSource = dsfindall;
            datagridsubcat.DataBind();
        }
    }
    protected void ddgrouplist_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsfindcat = null;
        ddcatlist.ClearSelection();
        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "Findcatbygroup" };
        lstparameter[1] = new SqlParameter { ParameterName = "@ID", Value = ddgrouplist.SelectedValue};
        dsfindcat = objsql.ExecuteQuery("FindDataProcedure", CommandType.StoredProcedure, lstparameter);
        if (dsfindcat.Tables[0].Rows.Count >= 0)
        {
            ddcatlist.DataSource = dsfindcat;
            ddcatlist.DataValueField = "CategoryId";
            ddcatlist.DataTextField = "CategoryName";
            ddcatlist.DataBind();
            ddcatlist.Items.Insert(0, new ListItem("--Select--", "--Select--"));
        }
        else
        {
            ddcatlist.Text = "No ";
        }
    }
    protected void btncreate_Click(object sender, EventArgs e)
    {
      string  loginemail = Context.Request.Cookies["logincookie"].Value;
        if (ddgrouplist.SelectedItem != null && ddcatlist.SelectedItem != null)
        {
            SqlParameter[] lstparameter = new SqlParameter[4];
            lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "CreateSubcategory" };
            lstparameter[1] = new SqlParameter { ParameterName = "@CategoryName", Value = txtsubcatname.Text };
            lstparameter[2] = new SqlParameter { ParameterName = "@SubCategoryId", Value =ddcatlist.SelectedValue };
            lstparameter[3] = new SqlParameter { ParameterName = "@Email", Value = loginemail };
            int row = objsql.ExecuteNonQuery("CreateGroupProcedure", CommandType.StoredProcedure, lstparameter);
            if (row < 0)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
           "<script type='text/javascript'>alert('Thanks for providing your valuable information.');window.location.replace('Manage_Subcatgory.aspx');</script>");
                findall();
                BindGrid();
                txtsubcatname.Text = "";
            }
        }
    }

    protected void datagridsubcat_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        datagridsubcat.EditIndex = -1;
        BindGrid();
    }

    protected void datagridsubcat_RowEditing(object sender, GridViewEditEventArgs e)
    {
        datagridsubcat.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void datagridsubcat_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt16(datagridsubcat.DataKeys[e.RowIndex].Values["Subid"].ToString());
        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "DeleteSubcategory" };
        lstparameter[1] = new SqlParameter { ParameterName = "@SubCategoryId", Value = id };
        int row = objsql.ExecuteNonQuery("CreateGroupProcedure", CommandType.StoredProcedure, lstparameter);
        if (row < 0)
        {
            datagridsubcat.EditIndex = -1;
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
          "<script type='text/javascript'>alert('Succesfully Delete.');window.location.replace('Manage_Subcatgory.aspx');</script>");
            BindGrid();
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
            "<script type='text/javascript'>alert('Error in Delete Data.');window.location.replace('Manage_Subcatgory.aspx');</script>");
        }

    }
    int i = 1;
    protected void datagridsubcat_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            lblSerial.Text = i.ToString();
            i++;
        }
    }

    protected void datagridsubcat_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        TextBox txtname = datagridsubcat.Rows[e.RowIndex].FindControl("txtsubcatedit") as TextBox;
        int id = Convert.ToInt16(datagridsubcat.DataKeys[e.RowIndex].Values["Subid"].ToString());
        SqlParameter[] lstparameter = new SqlParameter[3];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "UpdateSubcategory" };
        lstparameter[1] = new SqlParameter { ParameterName = "@SubCategoryId", Value = id };
        lstparameter[2] = new SqlParameter { ParameterName = "@CategoryName", Value = txtname.Text };
        int row = objsql.ExecuteNonQuery("CreateGroupProcedure", CommandType.StoredProcedure, lstparameter);
        if (row < 0)
        {
            datagridsubcat.EditIndex = -1;
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
          "<script type='text/javascript'>alert('Succesfully Update.');window.location.replace('Manage_Subcatgory.aspx');</script>");
            BindGrid();
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
            "<script type='text/javascript'>alert('Error in Update Data.');window.location.replace('Manage_Subcatgory.aspx');</script>");
        }
    }

    protected void datagridsubcat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        datagridsubcat.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}