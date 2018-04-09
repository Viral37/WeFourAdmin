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


public partial class Add_Group : System.Web.UI.Page
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
            datagrid.DataSource = dsfindall;
            
            datagrid.DataBind();

        }
    }
    protected void txtgroupname_TextChanged(object sender, EventArgs e)
    {
        if (txtgroupname.Text != null)
        {
            SqlParameter[] lstparameter = new SqlParameter[2];
            lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "Findbyid" };
            lstparameter[1] = new SqlParameter { ParameterName = "@GroupName", Value = txtgroupname.Text };
            DataSet ds = objsql.ExecuteQuery("FindDataProcedure", CommandType.StoredProcedure, lstparameter);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblerror.Visible = true;
                btncreate.Enabled = false;
            }
            else
            {
                lblerror.Visible = false;
                btncreate.Enabled = true;
            }
        }

    }
    protected void btncreate_Click(object sender, EventArgs e)
    {
        if (txtgroupname.Text != string.Empty)
        {
            loginemail = Context.Request.Cookies["logincookie"].Value;
            SqlParameter[] lstparameter = new SqlParameter[3];
            lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "CreateGroup" };
            lstparameter[1] = new SqlParameter { ParameterName = "@GroupName", Value = txtgroupname.Text };
            lstparameter[2] = new SqlParameter { ParameterName = "@Email", Value = loginemail };
            int row = objsql.ExecuteNonQuery("CreateGroupProcedure", CommandType.StoredProcedure, lstparameter);
            if (row < 0)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
           "<script type='text/javascript'>alert('Thanks for providing your valuable information.');window.location.replace('Add_Group.aspx');</script>");
                findall();
                txtgroupname.Text = "";
            }
            
        }

    }

    protected void datagrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        datagrid.EditIndex = -1;
        findall();

    }

    protected void datagrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        datagrid.EditIndex = e.NewEditIndex;
        findall();
    }

    protected void datagrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtname = datagrid.Rows[e.RowIndex].FindControl("txtgname") as TextBox;
        int id = Convert.ToInt16(datagrid.DataKeys[e.RowIndex].Values["GroupId"].ToString());
        SqlParameter[] lstparameter = new SqlParameter[3];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "UpdateGrid" };
        lstparameter[1] = new SqlParameter { ParameterName = "@ID", Value = id };
        lstparameter[2] = new SqlParameter { ParameterName = "@GroupName", Value = txtname.Text };
        int row = objsql.ExecuteNonQuery("FindDataProcedure", CommandType.StoredProcedure, lstparameter);
        if (row < 0)
        {
            datagrid.EditIndex = -1;
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
          "<script type='text/javascript'>alert('Succesfully Update.');window.location.replace('Add_Group.aspx');</script>");
            findall();
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
            "<script type='text/javascript'>alert('Error in Update Data.');</script>");
        }
    }

    protected void datagrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt16(datagrid.DataKeys[e.RowIndex].Values["GroupId"].ToString());
        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "DeleteGrid" };
        lstparameter[1] = new SqlParameter { ParameterName = "@ID", Value = id };
        int row = objsql.ExecuteNonQuery("FindDataProcedure", CommandType.StoredProcedure, lstparameter);
        if (row < 0)
        {
            datagrid.EditIndex = -1;
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
          "<script type='text/javascript'>alert('Succesfully Deleted.');window.location.replace('Add_Group.aspx');</script>");
            findall();
            
    }
        else
        { 
        }
    }
    int i = 1;
    protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            lblSerial.Text = i.ToString();
            i++;
        }
    }

    protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
            datagrid.PageIndex = e.NewPageIndex;
            findall();
        
    }
}
