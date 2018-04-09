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
public partial class AddAttribute : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    string loginuser = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindAttribute();
        }
        
    }

    public void BindAttribute()
    {
        SqlParameter[] lstparameter = new SqlParameter[1];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FetchAttribute" };
        DataSet dsbindattribute = objsql.ExecuteQuery("ManageAttribute", CommandType.StoredProcedure, lstparameter);
        if (dsbindattribute.Tables[0].Rows.Count > 0)
        {
            gdattribute.DataSource = dsbindattribute;
            gdattribute.DataBind();
        }
        else
        {
        }

    }
    protected void btncreate_ServerClick(object sender, EventArgs e)
     {
        string loginemail = Context.Request.Cookies["logincookie"].Value;
        if (txtattributename.Text != string.Empty && ddtoolname.SelectedItem != null)
        {
            SqlParameter[] lstparameter = new SqlParameter[5];
            lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "AddAttribute" };
            lstparameter[1] = new SqlParameter { ParameterName = "@AttributeName", Value = txtattributename.Text };
            lstparameter[2] = new SqlParameter { ParameterName = "@Type", Value = ddtype.SelectedValue };
            lstparameter[3] = new SqlParameter { ParameterName = "@ToolName", Value = ddtoolname.SelectedValue.ToString().TrimEnd()};
            lstparameter[4] = new SqlParameter { ParameterName = "@CreatedBy", Value = loginemail };
            int row = objsql.ExecuteNonQuery("ManageAttribute", CommandType.StoredProcedure, lstparameter);
            if (row < 0)
            {


                ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
           "<script type='text/javascript'>alert('Thanks for providing your valuable information.');window.location.replace('AddAttribute.aspx');</script>");
                BindAttribute();
            }
        }

    }

    protected void txtattributename_TextChanged(object sender, EventArgs e)
    {
        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FindByNameAttribute" };
        lstparameter[1] = new SqlParameter { ParameterName = "@AttributeName", Value = txtattributename.Text };
       
        DataSet ds = objsql.ExecuteQuery("ManageAttribute", CommandType.StoredProcedure, lstparameter);
        if (ds.Tables[0].Rows.Count > 0)
        {
            attributemsg.Visible = true;
        }
        else
        {
            attributemsg.Visible = false;
        }
    }

    protected void gdattribute_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gdattribute.EditIndex = e.NewEditIndex;
        BindAttribute();
    }

    protected void gdattribute_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdattribute.PageIndex = e.NewPageIndex;
        BindAttribute();
    }

    protected void gdattribute_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       int id = Convert.ToInt16(gdattribute.DataKeys[e.RowIndex].Values["AttributeId"].ToString());
        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "DeleteAttribute" };
        lstparameter[1] = new SqlParameter { ParameterName = "@AttributeId", Value = id };
        int row = objsql.ExecuteNonQuery("ManageAttribute", CommandType.StoredProcedure, lstparameter);
        if (row < 0)
        {
            gdattribute.EditIndex = -1;
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
          "<script type='text/javascript'>alert('Succesfully Delete.');window.location.replace('AddAttribute.aspx');</script>");
            BindAttribute();
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
            "<script type='text/javascript'>alert('Error in Delete Data.');window.location.replace('AddAttribute.aspx');</script>");
        }

    }
    int i = 1;
    protected void gdattribute_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            lblSerial.Text = i.ToString();
            i++;
        }

    }

    protected void gdattribute_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtname = gdattribute.Rows[e.RowIndex].FindControl("txtattribute") as TextBox;
        int id = Convert.ToInt16(gdattribute.DataKeys[e.RowIndex].Values["AttributeId"].ToString());
        SqlParameter[] lstparameter = new SqlParameter[3];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "UpdateAttributeName" };
        lstparameter[1] = new SqlParameter { ParameterName = "@AttributeId", Value = id };
        lstparameter[2] = new SqlParameter { ParameterName = "@AttributeName", Value = txtname.Text };
        int row = objsql.ExecuteNonQuery("ManageAttribute", CommandType.StoredProcedure, lstparameter);
        if (row < 0)
        {
            gdattribute.EditIndex = -1;
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
          "<script type='text/javascript'>alert('Succesfully Update.');window.location.replace('AddAttribute.aspx');</script>");
            BindAttribute();
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
            "<script type='text/javascript'>alert('Error in Update Data.');window.location.replace('Manage_Subcatgory.aspx');</script>");
        }
    }

    protected void gdattribute_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdattribute.EditIndex = -1;
        BindAttribute();
    }
}