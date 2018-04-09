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
public partial class Manage_Category : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    string loginuser = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            findall();
            fetchdata();
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

    public void fetchdata()
    {
        SqlParameter[] lstparameter = new SqlParameter[1];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FetchCategory" };
        DataSet dsfindall1 = objsql.ExecuteQuery("CreateGroupProcedure", CommandType.StoredProcedure, lstparameter);

        if (dsfindall1.Tables[0].Rows.Count > 0)
        {
            datagridcat.DataSource = dsfindall1;
            datagridcat.DataBind();
        }

    }
    protected void btncreate_Click(object sender, EventArgs e)
    {
        if (ddgrouplist.SelectedItem != null && (txtcatname.Text != null))
        {
            loginuser = Context.Request.Cookies["logincookie"].Value;
            SqlParameter[] lstparameter = new SqlParameter[4];

            lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "CreateCategory" };
            lstparameter[1] = new SqlParameter { ParameterName = "@CategoryName", Value = txtcatname.Text };
            lstparameter[2] = new SqlParameter { ParameterName = "@ID", Value = ddgrouplist.SelectedValue };
            lstparameter[3] = new SqlParameter { ParameterName = "@Email", Value = loginuser };
            int row = objsql.ExecuteNonQuery("CreateGroupProcedure", CommandType.StoredProcedure, lstparameter);
            if (row < 0)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
            "<script type='text/javascript'>alert('Succesfully Created Category.');window.location.replace('Manage_Category.aspx');</script>");
                findall();
                txtcatname.Text = "";
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
              "<script type='text/javascript'>alert('Something is Wrong.'); window.location.replace('Manage_Category.aspx');</script>");
            }
        }
    }

    protected void datagridcat_RowEditing(object sender, GridViewEditEventArgs e)
    {
        datagridcat.EditIndex = e.NewEditIndex;
        fetchdata();
    }

    protected void datagridcat_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtname = datagridcat.Rows[e.RowIndex].FindControl("txtcatnameedit") as TextBox;
        int id = Convert.ToInt16(datagridcat.DataKeys[e.RowIndex].Values["CategoryId"].ToString());
        SqlParameter[] lstparameter = new SqlParameter[3];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "UpdateCatGrid" };
        lstparameter[1] = new SqlParameter { ParameterName = "@ID", Value = id };
        lstparameter[2] = new SqlParameter { ParameterName = "@CategoryName", Value = txtname.Text };
        int row = objsql.ExecuteNonQuery("CreateGroupProcedure", CommandType.StoredProcedure, lstparameter);
        if (row < 0)
        {
            datagridcat.EditIndex = -1;
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
          "<script type='text/javascript'>alert('Succesfully Update.');window.location.replace('Manage_Category.aspx');</script>");
            fetchdata();
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
            "<script type='text/javascript'>alert('Error in Update Data.');window.location.replace('Manage_Category.aspx');</script>");
        }
    }

    protected void datagridcat_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        datagridcat.EditIndex = -1;
        fetchdata();

    }

    protected void datagridcat_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt16(datagridcat.DataKeys[e.RowIndex].Values["CategoryId"].ToString());
        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "DeleteCatGrid" };
        lstparameter[1] = new SqlParameter { ParameterName = "@ID", Value = id };
        int row = objsql.ExecuteNonQuery("CreateGroupProcedure", CommandType.StoredProcedure, lstparameter);
        if (row < 0)
        {
            datagridcat.EditIndex = -1;
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
          "<script type='text/javascript'>alert('Delete Succesfully.');window.location.replace('Manage_Category.aspx');</script>");
            fetchdata();
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
            "<script type='text/javascript'>alert('Error in Delete Data.');window.location.replace('Manage_Category.aspx');</script>");
        }
    }

    protected void datagridcat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        datagridcat.PageIndex = e.NewPageIndex;
        fetchdata();
    }

    int i = 1;
    protected void datagridcat_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            lblSerial.Text = i.ToString();
            i++;
        }
    }
}