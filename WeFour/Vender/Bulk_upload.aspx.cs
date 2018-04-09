using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
public partial class Vender_Bulk_upload : System.Web.UI.Page
{
    OleDbConnection Econ;
    SqlConnection con;
    string constr, Query, sqlconn;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void ExcelConn(string FilePath)
    {

        constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", FilePath);
        Econ = new OleDbConnection(constr);

    }
    private void connection()
    {
        sqlconn = ConfigurationManager.ConnectionStrings["SqlCom"].ConnectionString;
        con = new SqlConnection(sqlconn);

    }

    private void InsertExcelRecords(string FilePath)
    {
        ExcelConn(FilePath);

        fpfile.SaveAs(Server.MapPath("~/DataFiles/") + fpfile.FileName);
        Query = string.Format("Select [p_name],[p_cat_group_id],[p_cat_id],[p_subcat_id],[p_child_subcat_id],[p_brand],[p_packaging_type] FROM [{0}]", "Sheet1$");
        OleDbCommand Ecom = new OleDbCommand(Query, Econ);
        Econ.Open();

        DataSet ds = new DataSet();
        OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
        Econ.Close();
        oda.Fill(ds);
        DataTable Exceldt = ds.Tables[0];
        connection();
        //creating object of SqlBulkCopy    
        SqlBulkCopy objbulk = new SqlBulkCopy(con);
        //assigning Destination table name    
        objbulk.DestinationTableName = "product";
        //Mapping Table column    
        objbulk.ColumnMappings.Add("p_name", "p_name");
        objbulk.ColumnMappings.Add("p_cat_group_id", "p_cat_group_id");
        objbulk.ColumnMappings.Add("p_cat_id", "p_cat_id");
        objbulk.ColumnMappings.Add("p_subcat_id", "p_subcat_id");
        objbulk.ColumnMappings.Add("p_child_subcat_id", "p_child_subcat_id");
        objbulk.ColumnMappings.Add("p_brand", "p_brand");
        objbulk.ColumnMappings.Add("p_packaging_type", "p_packaging_type");
        //inserting Datatable Records to DataBase    
        con.Open();
        objbulk.WriteToServer(Exceldt);
        con.Close();

    }
    

    protected void btnupload_Click(object sender, EventArgs e)
    {
        string CurrentFilePath = Path.GetFullPath(fpfile.PostedFile.FileName);
        InsertExcelRecords(CurrentFilePath);

    }
}