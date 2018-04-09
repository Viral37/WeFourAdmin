using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using Shreeman.Models;

public partial class test : System.Web.UI.Page
{
    string SubcatName = string.Empty;
    SQLHelper objsql = new SQLHelper();
    string loginemail = string.Empty;
    protected void Page_PreLoad(object sender, EventArgs e)
    {
        SubcatName = Request.QueryString["subcatname"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        FindDynamicAttribute();
    }
    
    int TEmpId = 0;
    Dictionary<string, string> ListValues = new Dictionary<string, string>();
    Dictionary<string, string> ListAtt = new Dictionary<string, string>();
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        TEmpId++;
        Label att = (Label)e.Item.FindControl("AttType");
        HiddenField Type = (HiddenField)e.Item.FindControl("HideType");
        TextBox TextType = (TextBox)e.Item.FindControl("TextType");
        //RadioButton Rediotype = (RadioButton)e.Item.FindControl("Rediotype");
        switch (Type.Value)
        {
            case "Textbox":
                TextType.Visible = true;
                TextType.ID = TextType.ID + TEmpId;
                ListValues.Add(TextType.ID, "Textbox");
                ListAtt.Add(TextType.ID, att.Text);
                break;
        }

    }

    public void FindDynamicAttribute()
    {
        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FindDynamicAttribute" };
        lstparameter[1] = new SqlParameter { ParameterName = "@SubcategoryName", Value = SubcatName };
        DataSet ds = objsql.ExecuteQuery("ManageProduct", CommandType.StoredProcedure, lstparameter);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataList1.DataSource = ds.Tables[0];
            DataList1.DataBind();
        }
    }
}