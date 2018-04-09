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

public partial class ViewProduct : System.Web.UI.Page
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
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FetchApproveProduct" };
        DataSet dsfind = objsql.ExecuteQuery("ManageProduct", CommandType.StoredProcedure, lstparameter);
        if (dsfind.Tables[0].Rows.Count > 0)
        {
            datalistbox.DataSource = dsfind;
            datalistbox.DataBind();
        }
        lblcount.Text = dsfind.Tables[0].Rows.Count.ToString();
    }
}