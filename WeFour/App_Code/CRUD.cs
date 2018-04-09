using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for CRUD
/// </summary>
public class CRUD
{
    SqlConnection con;
    public CRUD()
    {
        //
        // TODO: Add constructor logic here
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
    }
    public void checkcon()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
    }
    public void crud(string querystring)
    {
        checkcon();
        //SqlCommand sqlcmd = new SqlCommand(querystring, con);
        //sqlcmd.ExecuteNonQuery();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = querystring;
        cmd.Connection = con;
        int i = cmd.ExecuteNonQuery();
    }
    public void InsOrdDtl(string sql)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.Connection = con;
        int i = cmd.ExecuteNonQuery();
    }
    public string GetOrdId()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT @@IDENTITY";
        cmd.Connection = con;
        string id = cmd.ExecuteScalar().ToString();
        return id;
    }
    public SqlDataReader datareader(string readerstring)
    {
        checkcon();
        SqlCommand readercmd = new SqlCommand(readerstring, con);
        SqlDataReader dr = readercmd.ExecuteReader();
        return dr;
    }
    public DataSet dataset_(string datastring)
    {
        con.Close();
        SqlCommand datacmd = new SqlCommand(datastring, con);
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        da.SelectCommand = datacmd;
        da.Fill(ds);
        return ds;
    }
    public string scscalar(string qstring)
    {
        checkcon();
        SqlCommand scalarcmd = new SqlCommand(qstring, con);
        string sc = scalarcmd.ExecuteScalar().ToString();
        return sc;
    }
    public DataTable datatable_(string sql)
    {
        DataTable dtt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.Connection = con;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(dtt);
        return dtt;

    }


}