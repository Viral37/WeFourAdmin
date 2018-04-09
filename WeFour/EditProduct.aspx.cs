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
public partial class EditProduct : System.Web.UI.Page
{
    string SubcatName = string.Empty, GroupName = string.Empty, CatName = string.Empty;
    SQLHelper objsql = new SQLHelper();
    string loginemail = string.Empty;
    int ProductId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDataList();
        }
    }
    public void BindDataList()
    {
        SqlParameter[] lstparameter = new SqlParameter[1];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FetchDraftProduct" };
        DataSet dsfind = objsql.ExecuteQuery("ManageProduct", CommandType.StoredProcedure, lstparameter);
        if (dsfind.Tables[0].Rows.Count > 0)
        {
            datalistbox.DataSource = dsfind;    
            datalistbox.DataBind();
        }
        lblcount.Text = dsfind.Tables[0].Rows.Count.ToString();
    }

    protected void lbtnedit_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        ProductId =Convert.ToInt32(lbtn.CommandArgument);
        if (ProductId != 0)
        {
            SqlParameter[] lstparameter = new SqlParameter[2];
            lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FetchDraftProductById" };
            lstparameter[1] = new SqlParameter { ParameterName = "@ProId", Value = ProductId };
            DataSet dsfindDraft = objsql.ExecuteQuery("ManageProduct", CommandType.StoredProcedure, lstparameter);
            if (dsfindDraft.Tables[0].Rows.Count > 0)
            {
                GroupName = dsfindDraft.Tables[0].Rows[0]["GroupName"].ToString();
                CatName = dsfindDraft.Tables[0].Rows[0]["CategoryName"].ToString();
                SubcatName = dsfindDraft.Tables[0].Rows[0]["SubcategoryName"].ToString();
            }
            Response.Redirect("Add.aspx?&ProId=" + ProductId + "&groupname=" + GroupName + "&catname=" + CatName + "&subcatname=" + SubcatName + "");
        }
    }
}