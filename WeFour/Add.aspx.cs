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
public partial class Add : System.Web.UI.Page
{
    string SubcatName = string.Empty, GroupName = string.Empty, CatName = string.Empty;
    SQLHelper objsql = new SQLHelper();
    string loginemail = string.Empty;
    int ProductId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["subcatname"] != string.Empty && Request.QueryString["ProId"] != null && Request.QueryString["groupname"] != string.Empty && Request.QueryString["catname"] != string.Empty)
        {
            ProductId = Convert.ToInt32(Request.QueryString["ProId"].ToString());
            GroupName = Request.QueryString["groupname"].ToString();
            CatName = Request.QueryString["catname"].ToString();
            SubcatName = Request.QueryString["subcatname"].ToString();
            FindDynamicAttribute();
        }
        else
        {
            Response.Redirect("Product_Listing.aspx");
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
            case "TextBox":
                TextType.Visible = true;
                TextType.ID = TextType.ID + TEmpId;
                ListValues.Add(TextType.ID, "Textbox");
                ListAtt.Add(TextType.ID, att.Text);
                break;
        }

    }

    protected void btnstaticsave_Click(object sender, EventArgs e)
    {
        string loginemail = Context.Request.Cookies["logincookie"].Value;
        SqlParameter[] lstparameter = new SqlParameter[10];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "UpdateProduct" };
        lstparameter[1] = new SqlParameter { ParameterName = "@ProductName", Value = txtpname.Text };
        lstparameter[2] = new SqlParameter { ParameterName = "@MRP", Value = Convert.ToDecimal(txtmrp.Text) };
        lstparameter[3] = new SqlParameter { ParameterName = "@SellingPrice", Value = Convert.ToDecimal(txtsellprice.Text) };
        lstparameter[4] = new SqlParameter { ParameterName = "@Stocks", Value = Convert.ToDecimal(txtstock.Text) };
        lstparameter[5] = new SqlParameter { ParameterName = "@HSN", Value = txthsn.Text };
        lstparameter[6] = new SqlParameter { ParameterName = "@GST", Value = Convert.ToDecimal(ddgst.SelectedValue.ToString()) };
        lstparameter[7] = new SqlParameter { ParameterName = "@ProId", Value = ProductId };
        lstparameter[8] = new SqlParameter { ParameterName = "@ListingStatus", Value = ddstatus.SelectedValue.ToString() };
        lstparameter[9] = new SqlParameter { ParameterName = "@Description", Value = txtdescription.Text };
        int row = objsql.ExecuteNonQuery("ManageProduct", CommandType.StoredProcedure, lstparameter);
        if (row != 0)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
         "<script type='text/javascript'>alert('Succesfully Update.');</script>");
        }

    }
    Dictionary<string, string> ListColVal = new Dictionary<string, string>();
    string[] Keys;
    string[] ArrColumns;
    string[] ArrValues;
    string UpdateEle = string.Empty;
    protected void btndynamicsave_Click(object sender, EventArgs e)
    {
        
        Keys = ListValues.Keys.ToArray();
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

         ArrColumns = ListColVal.Keys.ToArray();
         ArrValues = ListColVal.Values.ToArray();
     
        

    }

    string ProductImage1 = string.Empty, ProductImage2 = string.Empty, ProductImage3 = string.Empty, ProductImage4 = string.Empty, ProductImage5 = string.Empty, ProductImage6 = string.Empty;


    protected void btnsaveadd_Click(object sender, EventArgs e)
    {
        SqlParameter[] lstparameter = new SqlParameter[4];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "InsertProductAttribute" };
        lstparameter[1] = new SqlParameter { ParameterName = "@ProId", Value = ProductId };
        lstparameter[2] = new SqlParameter { ParameterName = "@AttributeName", Value = txtattributename.Text };
        lstparameter[3] = new SqlParameter { ParameterName = "@AttributeValue", Value = txtattributevalue.Text };
        int row = objsql.ExecuteNonQuery("ManageProduct", CommandType.StoredProcedure, lstparameter);

        if (row != 0)
        {
            txtattributename.Text = "";
            txtattributevalue.Text = "";
        }
    }

    protected void btnPageSaveAll_Click(object sender, EventArgs e)
    {
        try
        {
            Keys = ListValues.Keys.ToArray();
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

            ArrColumns = ListColVal.Keys.ToArray();
            ArrValues = ListColVal.Values.ToArray();

            if (ArrColumns.Length != 0 && ArrValues.Length != 0 )
            {
                for (int i = 0; i < ArrColumns.Length; i++)
                {
                    SqlParameter[] lstparameter = new SqlParameter[4];
                    lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "InsertProductAttribute" };
                    lstparameter[1] = new SqlParameter { ParameterName = "@ProId", Value = ProductId };
                    lstparameter[2] = new SqlParameter { ParameterName = "@AttributeName", Value = ArrColumns[i] };
                    lstparameter[3] = new SqlParameter { ParameterName = "@AttributeValue", Value = ArrValues[i] };
                    int row = objsql.ExecuteNonQuery("ManageProduct", CommandType.StoredProcedure, lstparameter);
                    if (row != 0)
                    {
                      //  ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
                      //"<script type='text/javascript'>alert('Succesfully Update.');</script>");
                    }
                    //if (i == 0) UpdateEle += ArrColumns[i] + "='" + ArrValues[i] + "'";
                    //else UpdateEle += ", " + ArrColumns[i] + "='" + ArrValues[i] + "'";
                }
            }
            if (fp1.HasFile || fp2.HasFile || fp3.HasFile || fp4.HasFile || fp5.HasFile || fp6.HasFile)
            {
                if (fp1.HasFile)
                {
                    ProductImage1 = fp1.FileName.ToString();
                    fp1.PostedFile.SaveAs(Server.MapPath("~/ProductImg/") + ProductImage1);
                }
                if (fp2.HasFile)
                {
                    ProductImage2 = fp2.FileName.ToString();
                    fp2.PostedFile.SaveAs(Server.MapPath("~/ProductImg/") + ProductImage2);

                }

                if (fp3.HasFile)
                {
                    ProductImage3 = fp3.FileName.ToString();
                    fp3.PostedFile.SaveAs(Server.MapPath("~/ProductImg/") + ProductImage3);

                }

                if (fp4.HasFile)
                {
                    ProductImage4 = fp4.FileName.ToString();
                    fp4.PostedFile.SaveAs(Server.MapPath("~/ProductImg/") + ProductImage4);

                }
                if (fp5.HasFile)
                {
                    ProductImage5 = fp5.FileName.ToString();
                    fp5.PostedFile.SaveAs(Server.MapPath("~/ProductImg/") + ProductImage5);

                }

                if (fp6.HasFile)
                {
                    ProductImage6 = fp6.FileName.ToString();
                    fp6.PostedFile.SaveAs(Server.MapPath("~/ProductImg/") + ProductImage6);
                }

                SqlParameter[] lstparameter = new SqlParameter[9];
                lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "UpdateProductImage" };
                lstparameter[1] = new SqlParameter { ParameterName = "@ProId", Value = ProductId };
                lstparameter[2] = new SqlParameter { ParameterName = "@ProductImage1", Value = ProductImage1 };
                lstparameter[3] = new SqlParameter { ParameterName = "@ProductImage2", Value = ProductImage2 };
                lstparameter[4] = new SqlParameter { ParameterName = "@ProductImage3", Value = ProductImage3 };
                lstparameter[5] = new SqlParameter { ParameterName = "@ProductImage4", Value = ProductImage4 };
                lstparameter[6] = new SqlParameter { ParameterName = "@ProductImage5", Value = ProductImage5 };
                lstparameter[7] = new SqlParameter { ParameterName = "@ProductImage6", Value = ProductImage6 };
                lstparameter[8] = new SqlParameter { ParameterName = "@ProStatus", Value = "Approve" };
                int row = objsql.ExecuteNonQuery("ManageProduct", CommandType.StoredProcedure, lstparameter);

                if (row != 0)
                {
                    Response.Redirect("ViewProduct.aspx");
                }

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    
    protected void viewdraft_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewProduct.aspx");
    }
}