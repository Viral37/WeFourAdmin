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

public partial class AddProduct : System.Web.UI.Page
{
    string SubcatName = string.Empty,GroupName = string.Empty,CatName = string.Empty;
    SQLHelper objsql = new SQLHelper();
    string loginemail = string.Empty;
    int ProductId = 0;

    protected void Page_PreLoad(object sender, EventArgs e)
    {
        if (Request.QueryString["subcatname"] != string.Empty && Request.QueryString["ProId"] != null && Request.QueryString["groupname"] != string.Empty && Request.QueryString["catname"] != string.Empty )
        {
            ProductId =Convert.ToInt32(Request.QueryString["ProId"].ToString());
            GroupName = Request.QueryString["groupname"].ToString();
            CatName = Request.QueryString["catname"].ToString();
            SubcatName = Request.QueryString["subcatname"].ToString();
        }
        else
        {
            Response.Redirect("Product_Listing.aspx");
        }
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //FindDynamicAttribute();
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

    protected void btnsavedynamic_Click(object sender, EventArgs e)
    {
       

    }

    protected void btnsavedynamic_ServerClick(object sender, EventArgs e)
    {
        Dictionary<string, string> ListColVal = new Dictionary<string, string>();
        string[] Keys = ListValues.Keys.ToArray();
        foreach (string key in Keys)
        {
            switch (ListValues[key])
            {
                case "Textbox":
                    foreach (DataListItem dItem in DataList1.Items)
                    {
                        TextBox txtBox = (TextBox)dItem.FindControl(key);
                        if (txtBox != null)
                        {
                            ListColVal.Add(ListAtt[key], txtBox.Text);
                            break;
                        }
                    }
                    break;
            }
        }

        string[] ArrColumns = ListColVal.Keys.ToArray();
        string[] ArrValues = ListColVal.Values.ToArray();
    }

    protected void btnstaticsave_Click(object sender, EventArgs e)
    {
        string loginemail = Context.Request.Cookies["logincookie"].Value;
        SqlParameter[] lstparameter = new SqlParameter[9];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "UpdateProduct" };
        lstparameter[1] = new SqlParameter { ParameterName = "@ProductName", Value = txtpname.Text };
        lstparameter[2] = new SqlParameter { ParameterName = "@MRP", Value =Convert.ToDecimal(txtmrp.Text) };
        lstparameter[3] = new SqlParameter { ParameterName = "@SellingPrice", Value = Convert.ToDecimal(txtsellprice.Text)  }; 
         lstparameter[4] = new SqlParameter { ParameterName = "@Stocks", Value = Convert.ToDecimal(txtstock.Text)  };
        lstparameter[5] = new SqlParameter { ParameterName = "@HSN", Value = txthsn.Text };
        lstparameter[6] = new SqlParameter { ParameterName = "@GST", Value =Convert.ToDecimal(ddgst.SelectedValue.ToString())};
        lstparameter[7] = new SqlParameter { ParameterName = "@ProId", Value = ProductId };
        lstparameter[8] = new SqlParameter { ParameterName = "@ListingStatus", Value = ddstatus.SelectedValue.ToString()};
        int row = objsql.ExecuteNonQuery("ManageProduct", CommandType.StoredProcedure, lstparameter);
        if (row != 0)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
         "<script type='text/javascript'>alert('Succesfully Update.');</script>");
        }  
        
    }

    protected void btnsavedynamic1_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
         "<script type='text/javascript'>alert('Succesfully Update.');</script>");
    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
    //     "<script type='text/javascript'>alert('Succesfully Update.');</script>");
    //}

    
}