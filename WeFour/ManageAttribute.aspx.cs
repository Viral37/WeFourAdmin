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

public partial class ManageAttribute : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    string loginuser = string.Empty;

    int i = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            findall();
            //BindGrid();

        }
    }
   
    public void findall()
    {
        SqlParameter[] lstparameter = new SqlParameter[1];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "Findall" };
       DataSet  dsfindall = objsql.ExecuteQuery("FindDataProcedure", CommandType.StoredProcedure, lstparameter);

        if (dsfindall.Tables[0].Rows.Count > 0)
        {
            ddgrouplist.DataSource = dsfindall;
            ddgrouplist.DataValueField = "GroupId";
            ddgrouplist.DataTextField = "GroupName";
            ddgrouplist.DataBind();
            ddgrouplist.Items.Insert(0, new ListItem("--Select--", "--Select--"));
        }

    }

    public void findAttribute()
    {
        SqlParameter[] lstparameter = new SqlParameter[1];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FetchAttribute" };
        DataSet dsfindall = objsql.ExecuteQuery("ManageAttribute", CommandType.StoredProcedure, lstparameter);

        if (dsfindall.Tables[0].Rows.Count > 0)
        {
            //ddattributelist.DataSource = dsfindall;
            //ddattributelist.DataValueField = "AttributeId";
            //ddattributelist.DataTextField = "AttributeName";
            //ddattributelist.DataBind();

            //ddattributelist.Items.Insert(0, new ListItem("--Select--", "--Select--"));
        }
    }

    public void BindGrid()
    {
        SqlParameter[] lstparameter = new SqlParameter[1];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "BindGridview" };
        DataSet dsfindall = objsql.ExecuteQuery("ManageAttribute", CommandType.StoredProcedure, lstparameter);

        if (dsfindall.Tables[0].Rows.Count > 0)
        {
            datagrid.DataSource = dsfindall;
            datagrid.DataBind();
        }


    }

    protected void ddgrouplist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddgrouplist.SelectedIndex == 0)
        {
            panelcategory.Visible = false;
            panelsubcat.Visible = false;
            panelattribute.Visible = false;
            panelbutton.Visible = false;
        }
        else
        {
            DataSet dsfindcat = null;
            ddcatlist.ClearSelection();
            SqlParameter[] lstparameter = new SqlParameter[2];
            lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "Findcatbygroup" };
            lstparameter[1] = new SqlParameter { ParameterName = "@ID", Value = ddgrouplist.SelectedValue };
            dsfindcat = objsql.ExecuteQuery("FindDataProcedure", CommandType.StoredProcedure, lstparameter);
            if (dsfindcat.Tables[0].Rows.Count >= 0)
            {
                ddcatlist.DataSource = dsfindcat;
                ddcatlist.DataValueField = "CategoryId";
                ddcatlist.DataTextField = "CategoryName";
                ddcatlist.DataBind();
                ddcatlist.Items.Insert(0, new ListItem("--Select--", "--Select--"));
                panelcategory.Visible = true;
                panelsubcat.Visible = false;
                panelattribute.Visible = false;
                panelbutton.Visible = false;
            }
            else
            {
                ddcatlist.Text = "No ";
            }
        }
    }

    protected void ddcatlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddcatlist.SelectedIndex == 0)
        {
            panelsubcat.Visible = false;
            panelattribute.Visible = false;
            panelbutton.Visible = false;
        }
        else
        {

        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FetchSubcategorybycategory" };
        lstparameter[1] = new SqlParameter { ParameterName = "@ID", Value = ddcatlist.SelectedValue };
        DataSet dsfindall = objsql.ExecuteQuery("CreateGroupProcedure", CommandType.StoredProcedure, lstparameter);

        if (dsfindall.Tables[0].Rows.Count > 0)
        {
            ddsubcatlist.DataSource = dsfindall;
            ddsubcatlist.DataTextField = "CategoryName";
            ddsubcatlist.DataValueField = "CategoryId";
            ddsubcatlist.DataBind();
            panelsubcat.Visible = true;
            panelattribute.Visible = true;
            panelbutton.Visible = true;
            ddsubcatlist.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            findAttribute();
        }

        }
    }

    protected void ddattributelist_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnapply_ServerClick(object sender, EventArgs e)
    {
        string loginemail = Context.Request.Cookies["logincookie"].Value;
        string attributename = ddattributelist.SelectedItem.ToString();
        string subcatname = ddsubcatlist.SelectedItem.ToString();
        
        if(ddattributelist.SelectedValue!= null)
        {

        }
        SqlParameter[] lstparameter = new SqlParameter[6];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "ManageAttributes" };
        lstparameter[1] = new SqlParameter { ParameterName = "@MSubCatId", Value = ddsubcatlist.SelectedValue };
        lstparameter[2] = new SqlParameter { ParameterName = "@AttributeId", Value = ddattributelist.SelectedValue };
        lstparameter[3] = new SqlParameter { ParameterName = "@AttributeName", Value = attributename };
        lstparameter[4] = new SqlParameter { ParameterName = "@MSubCatName", Value = subcatname };
        lstparameter[5] = new SqlParameter { ParameterName = "@CreatedBy", Value = loginemail };
        int row = objsql.ExecuteNonQuery("ManageAttribute", CommandType.StoredProcedure, lstparameter);
        if (row < 0)
        {
            FetchAttrinute(ddsubcatlist.SelectedValue);
            findSubcat(ddsubcatlist.SelectedValue);

            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
       "<script type='text/javascript'>alert('Thanks for providing your valuable information.');</script>");
        }

    }

    protected void datagrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt16(datagrid.DataKeys[e.RowIndex].Values["ManageAttributeId"].ToString());
        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "DeleteAttribute" };
        lstparameter[1] = new SqlParameter { ParameterName = "@AttributeId", Value = id };
        int row = objsql.ExecuteNonQuery("ManageAttribute", CommandType.StoredProcedure, lstparameter);
        if (row < 0)
        {
            datagrid.EditIndex = -1;
            FetchAttrinute(ddsubcatlist.SelectedValue);
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
          "<script type='text/javascript'>alert('Succesfully Delete.');</script>");
            findSubcat(ddsubcatlist.SelectedValue);
           
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
            "<script type='text/javascript'>alert('Error in Delete Data.');window.location.replace('ManageAttribute.aspx');</script>");
        }    
    }

    protected void datagrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        datagrid.EditIndex = -1;
        BindGrid();
    }

    protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        datagrid.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            lblSerial.Text = i.ToString();
            i++;
        }
    }

    protected void datagrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        datagrid.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void ddsubcatlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchAttrinute(ddsubcatlist.SelectedValue);
        findSubcat(ddsubcatlist.SelectedValue);
        

    }

    public void FetchAttrinute(string atrrinutename)

    {
        SqlParameter[] lstparameter1 = new SqlParameter[2];
        lstparameter1[0] = new SqlParameter { ParameterName = "@Action", Value = "FetchSelectedAttribute" };
        lstparameter1[1] = new SqlParameter { ParameterName = "@MSubCatId", Value = atrrinutename };
        DataSet dsfindallsubcat = objsql.ExecuteQuery("ManageAttribute", CommandType.StoredProcedure, lstparameter1);

        if (dsfindallsubcat.Tables[0].Rows.Count > 0)
        {
            ddattributelist.DataSource = dsfindallsubcat;
            ddattributelist.DataValueField = "AttributeId";
            ddattributelist.DataTextField = "AttributeName";
            ddattributelist.DataBind();

            ddattributelist.Items.Insert(0, new ListItem("--Select--", "--Select--"));

        }
    }

    public void findSubcat(string subcat)
    {
        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FetchBySubcategory" };
        lstparameter[1] = new SqlParameter { ParameterName = "@MSubCatId", Value = subcat };
        DataSet dsfindallsubcat1 = objsql.ExecuteQuery("ManageAttribute", CommandType.StoredProcedure, lstparameter);

        if (dsfindallsubcat1.Tables[0].Rows.Count > 0)
        {
            datagrid.DataSource = dsfindallsubcat1;
            datagrid.DataBind();

        }

    }
}