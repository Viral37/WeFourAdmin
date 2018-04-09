using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class Vender_product : System.Web.UI.Page
{
    //static ProductMainInfo objProductMainInfo = new ProductMainInfo();
    //static DefalutData objDefalutData = new DefalutData();
    static string constr = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(constr);
    SqlDataAdapter da;
    DataTable dt;
    SqlCommand cmd;
    CRUD objcrud = new CRUD();
    CRUD objcrudm = new CRUD();
    string str2 = "", str1 = "";
    DataSet ds = new DataSet();
    string fp11, fp22, fp33, fp44, fp55;
    string catname = string.Empty, ssss = string.Empty;
    string cat_grp_id = string.Empty;
    string catt_id = string.Empty;
    string sub_cat_id = string.Empty;
    string ListAtt = null, proid = null, listadatt = null;
    protected void Page_PreLoad(object sender, EventArgs e)
    {
        string pro = Request.QueryString["sid"].ToString();
        string[] prf = pro.Split('D');
        string tem = null;
        for (int s = 0; prf.Length > s; s++)
        {
            if (tem == null)
            {
                tem = prf[s].ToString() + "D";
            }
            else
            {
                proid = prf[s].ToString();
            }
        }
        login();
        getdyddata();
        getaddyddata();
    }
    private void getdyddata()
    {
        catt_id = Request.QueryString["cat"].ToString();
        sub_cat_id = Request.QueryString["cica"].ToString();
        con.Open();
        str1 = @"select category_attributes.*,cat_attributes.* from category_attributes INNER JOIN cat_attributes on category_attributes.attrib_id = cat_attributes.a_id  where category_attributes.cat_id = '" + sub_cat_id + "' and cat_attributes.Type='Primary' order by cat_attributes.a_id asc";
        SqlCommand cmd = new SqlCommand(str1, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet dsk = new DataSet();
        da.Fill(dsk);
        if (dsk.Tables[0].Rows.Count > 0)
        {
            //dycount.Text = dsk.Tables[0].Rows.Count.ToString();
            for (int i = 0; dsk.Tables[0].Rows.Count > i; i++)
            {
                string id = dsk.Tables[0].Rows[i]["a_id"].ToString();
                HtmlGenericControl divlbl = new HtmlGenericControl("div");
                divlbl.Attributes.Add("class", "col-sm-5");
                Label lblsk = new Label();
                lblsk.ID = "lblsk" + id;
                lblsk.Attributes.Add("Class", "lbl");
                lblsk.Text = dsk.Tables[0].Rows[i]["Attributes"].ToString();
                lblsk.Attributes.Add("title", dsk.Tables[0].Rows[i]["Tool_tip"].ToString());
                HtmlGenericControl ask = new HtmlGenericControl("a");
                HtmlGenericControl alk = new HtmlGenericControl("i");
                alk.Attributes.Add("class", "fa fa-question-circle");
                alk.Attributes.Add("title", dsk.Tables[0].Rows[i]["Tool_tip"].ToString());
                HtmlGenericControl divtex = new HtmlGenericControl("div");
                divtex.Attributes.Add("class", "col-sm-6");
                TextBox txt = new TextBox();
                txt.ID = "ATTR" + id;
                txt.Attributes.Add("Class", "form-control");
                txt.Attributes.Add("title", dsk.Tables[0].Rows[i]["Tool_tip"].ToString());
                divlbl.Controls.Add(lblsk);
                ask.Controls.Add(alk);
                divlbl.Controls.Add(ask);
                panatt.Controls.Add(divlbl);
                divtex.Controls.Add(txt);
                panatt.Controls.Add(divtex);
                HtmlGenericControl br = new HtmlGenericControl("br");
                panatt.Controls.Add(br);
                ListAtt += "ATTR" + id + ",";
            }
        }
        else
        {
            //dycount.Text = dsk.Tables[0].Rows.Count.ToString();
        }
        con.Close();
    }
    private void getaddyddata()
    {
        catt_id = Request.QueryString["cat"].ToString();
        sub_cat_id = Request.QueryString["cica"].ToString();
        con.Open();
        str1 = @"select category_attributes.*,cat_attributes.* from category_attributes INNER JOIN cat_attributes on category_attributes.attrib_id = cat_attributes.a_id  where category_attributes.cat_id = '" + sub_cat_id + "' and cat_attributes.Type='Optional' order by cat_attributes.a_id asc";
        SqlCommand cmd = new SqlCommand(str1, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet dsk = new DataSet();
        da.Fill(dsk);
        if (dsk.Tables[0].Rows.Count > 0)
        {
            //dycount.Text = dsk.Tables[0].Rows.Count.ToString();
            for (int i = 0; dsk.Tables[0].Rows.Count > i; i++)
            {
                string id = dsk.Tables[0].Rows[i]["a_id"].ToString();
                HtmlGenericControl divlbl = new HtmlGenericControl("div");
                divlbl.Attributes.Add("class", "col-sm-5");
                Label lblsk = new Label();
                lblsk.ID = "lblsk" + id;
                lblsk.Attributes.Add("Class", "lbl");
                lblsk.Text = dsk.Tables[0].Rows[i]["Attributes"].ToString();
                lblsk.Attributes.Add("title", dsk.Tables[0].Rows[i]["Tool_tip"].ToString());
                HtmlGenericControl ask = new HtmlGenericControl("a");
                HtmlGenericControl alk = new HtmlGenericControl("i");
                alk.Attributes.Add("class", "fa fa-question-circle");
                alk.Attributes.Add("title", dsk.Tables[0].Rows[i]["Tool_tip"].ToString());
                HtmlGenericControl divtex = new HtmlGenericControl("div");
                divtex.Attributes.Add("class", "col-sm-6");
                TextBox txt = new TextBox();
                txt.ID = "ATTR" + id;
                txt.Attributes.Add("Class", "form-control");
                txt.Attributes.Add("title", dsk.Tables[0].Rows[i]["Tool_tip"].ToString());
                divlbl.Controls.Add(lblsk);
                ask.Controls.Add(alk);
                divlbl.Controls.Add(ask);
                panadi.Controls.Add(divlbl);
                divtex.Controls.Add(txt);
                panadi.Controls.Add(divtex);
                HtmlGenericControl br = new HtmlGenericControl("br");
                panadi.Controls.Add(br);
                listadatt += "ATTR" + id + ",";
            }
        }
        else
        {
            //dycount.Text = dsk.Tables[0].Rows.Count.ToString();
        }
        con.Close();
    }
    private void getoptda()
    {
        con.Open();
        if (ListAtt != null)
        {
            string skl = ListAtt.Remove(ListAtt.LastIndexOf(','));
            string[] colnm = skl.Split(',');
            int lk = 0;
            for (int c = 0; colnm.Length > c; c++)
            {
                string optstr = "select " + colnm[c] + " from Products where Product_id='" + proid + "'";
                SqlCommand cmdpro = new SqlCommand(optstr, con);
                SqlDataAdapter das = new SqlDataAdapter(cmdpro);
                DataSet ds = new DataSet();
                das.Fill(ds);
                TextBox txt = (TextBox)panatt.FindControl(colnm[c]);
                txt.Text = ds.Tables[0].Rows[0][colnm[c]].ToString();
                if (ds.Tables[0].Rows[0][colnm[c]].ToString() != "")
                {
                    lk = lk + 1;
                }
                lblopnct.Text = lk.ToString();
                lblcs.Text = colnm.Length.ToString();
            }
            if (lk.ToString() == colnm.Length.ToString())
            {
                lblpder.Visible = false;
                lblpdcom.ForeColor = System.Drawing.Color.Green;
                linkerro.ForeColor = System.Drawing.Color.Black;
                lblopnct.Text = lk.ToString();
                lblcs.Text = colnm.Length.ToString();
            }
            else
            {
                lblpdcom.ForeColor = System.Drawing.Color.Black;
            }
        }
        con.Close();
    }
    private void getAdoptda()
    {
        con.Open();
        if (listadatt != null)
        {
            string skl = listadatt.Remove(listadatt.LastIndexOf(','));
            string[] colnm = skl.Split(',');
            int lk = 0;
            for (int c = 0; colnm.Length > c; c++)
            {
                string optstr = "select " + colnm[c] + " from Products where Product_id='" + proid + "'";
                SqlCommand cmdpro = new SqlCommand(optstr, con);
                SqlDataAdapter das = new SqlDataAdapter(cmdpro);
                DataSet ds = new DataSet();
                das.Fill(ds);
                TextBox txt = (TextBox)panatt.FindControl(colnm[c]);
                txt.Text = ds.Tables[0].Rows[0][colnm[c]].ToString();
                if (ds.Tables[0].Rows[0][colnm[c]].ToString() != "")
                {
                    lk = lk + 1;
                }
                lbladc.Text = lk.ToString();
                lbladct.Text = colnm.Length.ToString();
            }
            lbladc.Text = lk.ToString();
            lbladct.Text = colnm.Length.ToString();
        }
        con.Close();
    }
    private void manddata()
    {
        con.Open();
        string optstr = @"select Product_Name,Seller_sku_id,Listing_status,MRP,Brand
      ,Your_selling_price,Fullfilment_by,Procurement_types,Procurement_sla,Stocks,Stock_for_buyers,Local_charges,Zonal_charges
      ,National_charges,P_weight,P_length,P_breadth,P_height,HSN,GST,Luxury_cess from Products where Product_id='" + proid + "'";
        SqlCommand cmdpro = new SqlCommand(optstr, con);
        SqlDataAdapter das = new SqlDataAdapter(cmdpro);
        DataSet ds = new DataSet();
        das.Fill(ds);

        int lk = 0, nk = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {

            lblbrand.Text = ds.Tables[0].Rows[0]["Brand"].ToString();
            txtpname.Text = ds.Tables[0].Rows[0]["Product_Name"].ToString();
            txtskuid.Text = ds.Tables[0].Rows[0]["Seller_sku_id"].ToString();
            ddstatus.SelectedValue = ds.Tables[0].Rows[0]["Listing_status"].ToString(); ;
            txtmrp.Text = ds.Tables[0].Rows[0]["MRP"].ToString();
            txtsellprice.Text = ds.Tables[0].Rows[0]["Your_selling_price"].ToString();
            ddfullfilby.SelectedValue = ds.Tables[0].Rows[0]["Fullfilment_by"].ToString();
            ddprotype.SelectedValue = ds.Tables[0].Rows[0]["Procurement_types"].ToString();
            txtprosla.Text = ds.Tables[0].Rows[0]["Procurement_sla"].ToString();
            txtstock.Text = ds.Tables[0].Rows[0]["Stocks"].ToString();
            txtsbuyer.Text = ds.Tables[0].Rows[0]["Stock_for_buyers"].ToString();
            txtlocal.Text = ds.Tables[0].Rows[0]["Local_charges"].ToString();
            txtzonal.Text = ds.Tables[0].Rows[0]["Zonal_charges"].ToString();
            txtnational.Text = ds.Tables[0].Rows[0]["National_charges"].ToString();
            txtlenght.Text = ds.Tables[0].Rows[0]["P_length"].ToString();
            txtbreadth.Text = ds.Tables[0].Rows[0]["P_breadth"].ToString();
            txtheight.Text = ds.Tables[0].Rows[0]["P_height"].ToString();
            txthsn.Text = ds.Tables[0].Rows[0]["HSN"].ToString();
            ddgst.SelectedValue = ds.Tables[0].Rows[0]["GST"].ToString();
            txtluxury.Text = ds.Tables[0].Rows[0]["Luxury_cess"].ToString();
            if (ds.Tables[0].Rows[0]["P_weight"].ToString() != "NULL")
            {
                string[] wei = ds.Tables[0].Rows[0]["P_weight"].ToString().Split(',');
                string we = null, mes = null;
                for (int t = 0; wei.Length > t; t++)
                {
                    if (we == null)
                    {
                        we = wei[t].ToString();
                        txtweight.Text = we;
                    }
                    else
                    {
                        mes = wei[t].ToString();
                        drpmasur.SelectedValue = mes;
                    }
                }
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; ds.Tables[0].Columns.Count > i; i++)
                {
                    string sk = ds.Tables[0].Columns[i].ToString();
                    if (ds.Tables[0].Rows[0][sk].ToString() != "" && ds.Tables[0].Rows[0][sk].ToString() != "0" && ds.Tables[0].Rows[0][sk].ToString() != "Select One")
                    {
                        lk = lk + 1;
                    }
                }
                if (lk.ToString() == ds.Tables[0].Columns.Count.ToString())
                {
                    lbler.Visible = false;
                    lblprer.ForeColor = System.Drawing.Color.Green;
                    linkerro.ForeColor = System.Drawing.Color.Black;
                    lblmnct.Text = lk.ToString();
                    lblmct.Text = ds.Tables[0].Columns.Count.ToString();
                }
                else
                {
                    lblprer.ForeColor = System.Drawing.Color.Black;
                    lbler.Visible = false;
                }

                //lblmnct.Text = lk.ToString();
                //lblmct.Text = ds.Tables[0].Columns.Count.ToString();
            }
        }

        lblmnct.Text = lk.ToString();
        lblmct.Text = ds.Tables[0].Columns.Count.ToString();
        string optst = @"select Image_1,Image_2,Image_3,Image_4,Image_5
       from Products where Product_id='" + proid + "'";
        SqlCommand cmdpr = new SqlCommand(optst, con);
        SqlDataAdapter dask = new SqlDataAdapter(cmdpr);
        DataSet dss = new DataSet();
        dask.Fill(dss);
        int lks = 0, nks = 0;

        if (dss.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; dss.Tables[0].Columns.Count > i; i++)
            {
                string sk = dss.Tables[0].Columns[i].ToString();
                if (dss.Tables[0].Rows[0][sk].ToString() == "")
                {
                    lks = lks + 1;

                }
                else
                {
                    nks = nks + 1;
                }
            }
            ll.Text = nks.ToString();

            string img11 = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_1"].ToString();
            string img22 = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_2"].ToString();
            string img33 = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_3"].ToString();
            string img44 = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_4"].ToString();
            string img55 = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_5"].ToString();

            thum1.Attributes["data-big"] = img11;
            thum2.Attributes["data-big"] = img22;
            thum3.Attributes["data-big"] = img33;
            thum4.Attributes["data-big"] = img44;
            thum5.Attributes["data-big"] = img55;
            mainimg.Style["background-image"] = "url(" + img11 + ")";
            if (img11 != "")
            {
                imgi1.ImageUrl = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_1"].ToString();
                main1.ImageUrl = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_1"].ToString();
                img1.Src = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_1"].ToString();
            }
            //else
            //{
            //    imgi1.ImageUrl = "~/Vender/img/DemoImage/demo_1.jpg";
            //    main1.ImageUrl = "~/Vender/img/DemoImage/demo_1.jpg";
            //    img1.Src = "~/Vender/img/DemoImage/demo_1.jpg";
            //}

            if (img22 != "")
            {
                imgi2.ImageUrl = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_2"].ToString();
                main2.ImageUrl = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_2"].ToString();
                img2.Src = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_2"].ToString();
            }
            //else
            //{
            //    imgi2.ImageUrl = "~/Vender/img/DemoImage/demo_2.jpg";
            //    main2.ImageUrl = "~/Vender/img/DemoImage/demo_2.jpg";
            //    img2.Src = "~/Vender/img/DemoImage/demo_2.jpg";
            //}
            if (img33 != "")
            {
                imgi3.ImageUrl = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_3"].ToString();
                main3.ImageUrl = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_3"].ToString();
                img3.Src = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_3"].ToString();
            }
            //else
            //{
            //    imgi3.ImageUrl = "~/Vender/img/DemoImage/demo_3.jpg";
            //    main3.ImageUrl = "~/Vender/img/DemoImage/demo_3.jpg";
            //    img3.Src = "~/Vender/img/DemoImage/demo_3.jpg"; 
                    
            //}
            if (img44 != "")
            {
                imgi4.ImageUrl = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_4"].ToString();
                main4.ImageUrl = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_4"].ToString();
                img4.Src = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_4"].ToString();
            }
            //else
            //{
            //    imgi4.ImageUrl = "~/Vender/img/DemoImage/demo_4.jpg";
            //    main4.ImageUrl = "~/Vender/img/DemoImage/demo_4.jpg";
            //    img4.Src = "~/Vender/img/DemoImage/demo_4.jpg";

            //}
            if (img55 != "")
            {
                imgi5.ImageUrl = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_5"].ToString();
                main5.ImageUrl = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_5"].ToString();
                img5.Src = "../Product_IMG/" + dss.Tables[0].Rows[0]["Image_5"].ToString();
            }
            //else
            //{
            //    imgi5.ImageUrl = "~/Vender/img/DemoImage/demo_5.jpg";
            //    main5.ImageUrl = "~/Vender/img/DemoImage/demo_5.jpg";
            //    img5.Src = "~/Vender/img/DemoImage/demo_5.jpg";
            //}
        }
        ll.Text = nks.ToString();
        con.Close();
    }
    public void login()
    {
        if (Context.Request.Cookies["inf"] != null)
        {
            string skp = Request.Cookies["inf"].Value;
            string mp = null;
            if (skp != null)
            {
                string[] sdss = skp.Split('$');
                for (int k = 0; k < sdss.Length; k++)
                {
                    if (mp == null)
                    {
                        mp = sdss[k];
                    }
                }
            }
            ssss = Encoding.UTF32.GetString(Convert.FromBase64String(mp));
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            findtax();
            con.Open();
            string select = "select * from Products where Product_id='" + proid + "'";
            DataSet ds = objcrudm.dataset_(select);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    string img11 = ds.Tables[0].Rows[j]["Image_1"].ToString();
                    if (img11 == "")
                    {
                        Req_file1.ValidationGroup = "addprd";
                        Req_file1.ErrorMessage = "Please File 1 is Require";
                    }
                }
            }
            Reg_img1.ErrorMessage = "Only file 1 types .gif|.jpeg|.jpg|.png|.JPEG|.JPG|.PNG Allow";
            Reg_img2.ErrorMessage = "Only file 2 types .gif|.jpeg|.jpg|.png|.JPEG|.JPG|.PNG Allow";
            Reg_img3.ErrorMessage = "Only file 3 types .gif|.jpeg|.jpg|.png|.JPEG|.JPG|.PNG Allow";
            Reg_img4.ErrorMessage = "Only file 4 types .gif|.jpeg|.jpg|.png|.JPEG|.JPG|.PNG Allow";
            Reg_img5.ErrorMessage = "Only file 5 types .gif|.jpeg|.jpg|.png|.JPEG|.JPG|.PNG Allow";
            con.Close();
            getoptda();
            manddata();
            getAdoptda();
        }
    }

    public void findtax()
    {
        con.Open();
        SqlDataAdapter das = new SqlDataAdapter("select * from tbl_tax where Measurement!='NULL'", con);
        DataSet dsk = new DataSet();
        das.Fill(dsk);
        drpmasur.Items.Clear();
        drpmasur.DataTextField = "Measurement";
        drpmasur.DataValueField = "Measurement";
        drpmasur.DataSource = dsk;
        drpmasur.DataBind();
        drpmasur.Items.Insert(0, new ListItem("Select Measurement", "0"));
        con.Close();
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        string[] ArrColumns = ListAtt.Remove(ListAtt.LastIndexOf(',')).Split(',');
        string UpdateEle = null;
        for (int i = 0; i < ArrColumns.Length; i++)
        {
            TextBox txt = (TextBox)panatt.FindControl(ArrColumns[i]);
            UpdateEle += "" + ArrColumns[i] + "='" + txt.Text + "',";
        }
        string skup = UpdateEle.Remove(UpdateEle.LastIndexOf(','));
        string updatedynamic = "update Products set " + skup + "  where Product_id=" + proid + " and Vender_id='" + ssss + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(updatedynamic, con);
        int sk = cmd.ExecuteNonQuery();
        if (sk > 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "message", "alert('Data Successfully.');", true);
            linkerro.ForeColor = System.Drawing.Color.Black;
            lbler.Visible = false;
            lblprer.ForeColor = System.Drawing.Color.Black;
            con.Close();
            manddata();
            getoptda();
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "message", "alert('Data Update Error.');", true);
            con.Close();
        }
    }
    protected void btnsks_Click(object sender, EventArgs e)
    {
        if (drpmasur.SelectedValue.ToString() != "0")
        {
            string Fullfilment_by = ddfullfilby.SelectedValue.ToString();
            string Procurement_types = ddprotype.SelectedValue.ToString();
            //int Stocks = Convert.ToInt32(txtstock.Text);
            //int Stock_for_buyers = Convert.ToInt32(txtsbuyer.Text);
            //int Local_charges = Convert.ToInt32(txtlocal.Text);
            //int Zonal_charges = Convert.ToInt32(txtzonal.Text);
            //int National_charges = Convert.ToInt32(txtnational.Text);
            //int P_length = Convert.ToInt32(txtlenght.Text);
            //int P_breadth = Convert.ToInt32(txtbreadth.Text);
            //int P_height = Convert.ToInt32(txtheight.Text);
            //int GST = Convert.ToInt32(ddgst.SelectedValue.ToString());
            //int Luxury_cess = Convert.ToInt32(txtluxury.Text);
            string strproins = "update Products set Product_Name='" + txtpname.Text + "',Seller_sku_id ='" + txtskuid.Text + "', Listing_status='" + ddstatus.Text
                + "', MRP = '" + txtmrp.Text + "', Your_selling_price ='" + txtsellprice.Text + "' ,Fullfilment_by ='" + Fullfilment_by.ToString()
                + "' ,Procurement_types ='" + Procurement_types.ToString() + "' ,Procurement_sla = '" + txtprosla.Text + "',Stocks ='" + txtstock.Text
                + "' ,Stock_for_buyers ='" + txtsbuyer.Text + "' ,Local_charges = '" + txtlocal.Text + "',Zonal_charges ='" + txtzonal.Text
                + "' ,National_charges = '" + txtnational.Text + "',P_weight ='" + txtweight.Text + "," + drpmasur.SelectedItem.ToString()
                + "' ,P_length='" + txtlenght.Text + "',P_breadth = '" + txtbreadth.Text + "' ,P_height = '" + txtheight.Text + "',HSN = '" + txthsn.Text
                + "',GST ='" + ddgst.SelectedValue.ToString() + "' ,Luxury_cess ='" + txtluxury.Text + "'  where Product_id=" + proid + " and Vender_id='" + ssss + "' ";
            con.Open();
            SqlCommand cmd = new SqlCommand(strproins, con);
            int sk = cmd.ExecuteNonQuery();
            if (sk > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "alert('Data Successfully.');", true);
                linkerro.ForeColor = System.Drawing.Color.Black;
                lbler.Visible = false;
                lblprer.ForeColor = System.Drawing.Color.Black;
                con.Close();
                manddata();
                getoptda();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "alert('Data Update Error.');", true);
                con.Close();
            }
        }
        else
        {
            lblme.Text = "Select It.";
        }

    }
    protected void viewdraft_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Vender/Edit_Product.aspx");
    }
    protected void btn_upload_Click(object sender, EventArgs e)
    {
        //try
        //{
            string select = "select Image_1,Image_2,Image_3,Image_4,Image_5 from Products where Product_id='" + proid + "'";
            DataSet ds = objcrudm.dataset_(select);
            fp11 = fp1.PostedFile.FileName;
            string fp_img1 = fp11;
            fp22 = fp2.PostedFile.FileName;
            string fp_img2 = fp22;
            fp33 = fp3.PostedFile.FileName;
            string fp_img3 = fp33;
            fp44 = fp4.PostedFile.FileName;
            string fp_img4 = fp44;
            fp55 = fp5.PostedFile.FileName;
            string fp_img5 = fp55;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    string img11 =  ds.Tables[0].Rows[j]["Image_1"].ToString();
                    string img22 = ds.Tables[0].Rows[j]["Image_2"].ToString();
                    string img33 = ds.Tables[0].Rows[j]["Image_3"].ToString();
                    string img44 =  ds.Tables[0].Rows[j]["Image_4"].ToString();
                    string img55 =  ds.Tables[0].Rows[j]["Image_5"].ToString();

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFile PostedFile = Request.Files[i];
                        if (PostedFile.ContentLength > 0)
                        {
                            System.Drawing.Image img = System.Drawing.Image.FromStream(PostedFile.InputStream);
                            int height = img.Height;
                            int width = img.Width;
                            decimal size = Math.Round(((decimal)PostedFile.ContentLength / (decimal)1024), 2);
                            Stream strm = PostedFile.InputStream;
                            using (var image = System.Drawing.Image.FromStream(strm))
                            {
                                int newWidth = 1600; // New Width of Image in Pixel  
                                int newHeight = 1200; // New Height of Image in Pixel  
                                var thumbImg = new Bitmap(newWidth, newHeight);
                                var thumbGraph = Graphics.FromImage(thumbImg);
                                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                                thumbGraph.DrawImage(image, imgRectangle);
                                string targetPath = Server.MapPath("~/Product_IMG/") + PostedFile.FileName;
                                thumbImg.Save(targetPath, image.RawFormat);
                            }
                        }
                    }
                    if (fp1.HasFile)
                    {
                        if (img11 == "")
                        {
                            string update = "update Products set Image_1='" + fp_img1 + "' where Product_id='" + proid + "'";
                            objcrudm.crud(update);
                        }
                        else
                        {
                            if (fp1.HasFile)
                            {
                                RemoveFile(img11);
                                string update = "update Products set Image_1='" + fp_img1 + "' where Product_id='" + proid + "'";
                                objcrudm.crud(update);
                            }
                        }
                    }

                    if (fp2.HasFile)
                    {
                        if (img22 == "")
                        {
                            string update = "update Products set Image_2='" + fp_img2 + "' where Product_id='" + proid + "'";
                            objcrudm.crud(update);
                        }
                        else
                        {
                            if (fp2.HasFile)
                            {
                                RemoveFile(img22);
                                string update = "update Products set Image_2='" + fp_img2 + "' where Product_id='" + proid + "'";
                                objcrudm.crud(update);
                            }
                        }
                    }

                    if (fp3.HasFile)
                    {
                        if (img33 == "")
                        {
                            string update = "update Products set Image_3='" + fp_img3 + "' where Product_id='" + proid + "'";
                            objcrudm.crud(update);
                        }
                        else
                        {
                            RemoveFile(img33);
                            string update = "update Products set Image_3='" + fp_img3 + "' where Product_id='" + proid + "'";
                            objcrudm.crud(update);
                        }
                    }
                    if (fp4.HasFile)
                    {
                        if (img44 == "")
                        {
                            string update = "update Products set Image_4='" + fp_img4 + "' where Product_id='" + proid + "'";
                            objcrudm.crud(update);
                        }
                        else
                        {
                            RemoveFile(img44);
                            string update = "update Products set Image_4='" + fp_img4 + "' where Product_id='" + proid + "'";
                            objcrudm.crud(update);
                        }
                    }
                    if (fp5.HasFile)
                    {
                        if (img55 == "")
                        {
                            string update = "update Products set Image_5='" + fp_img5 + "' where Product_id='" + proid + "'";
                            objcrudm.crud(update);
                        }
                        else
                        {
                            RemoveFile(img55);
                            string update = "update Products set Image_5='" + fp_img5 + "' where Product_id='" + proid + "'";
                            objcrudm.crud(update);
                        }
                    }
                    con.Close();
                    manddata();
                    getoptda();
                    lbl_msg.Text = "Successfully Updated";
                }

            }
        //}

        //catch (Exception ex)
        //{

        //}
    }

    //Remove File From Folder
    public void RemoveFile(string name)
    {
        string file_name = name;
        string path = Server.MapPath(file_name);
        FileInfo file = new FileInfo(path);
        if (file.Exists)//check file exsit or not
        {
            file.Delete();

        }
    }

    protected void btnPageSa_Click(object sender, EventArgs e)
    {
        //ValidationGroup = "clicksubmit"
        int nk = 0, lk = 0;
        string optstr = @"select Product_Name,Seller_sku_id,Listing_status,MRP
      ,Your_selling_price,Fullfilment_by,Procurement_types,Procurement_sla,Stocks,Stock_for_buyers,Local_charges,Zonal_charges
      ,National_charges,P_weight,P_length,P_breadth,P_height,HSN,GST,Luxury_cess from Products where Product_id='" + proid + "'";
        SqlCommand cmdpro = new SqlCommand(optstr, con);
        SqlDataAdapter das = new SqlDataAdapter(cmdpro);
        DataSet ds = new DataSet();
        das.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; ds.Tables[0].Columns.Count > i; i++)
            {
                string sk = ds.Tables[0].Columns[i].ToString();
                if (ds.Tables[0].Rows[0][sk].ToString() == "" || ds.Tables[0].Rows[0][sk].ToString() == "0" || ds.Tables[0].Rows[0][sk].ToString() == "Select One")
                {
                    lk = lk + 1;
                }
            }
            if (lk != 0)
            {
                lbler.Visible = true;
                lblprer.ForeColor = System.Drawing.Color.Red;
                linkerro.ForeColor = System.Drawing.Color.Red;
                lbler.ForeColor = System.Drawing.Color.Red;
                lbler.Text = "(Error :- " + lk.ToString() + ")";
                Nukl.Text = "Total NUll Value :-" + lk.ToString();
                kil.Text = "Total Mandatory Field :- " + ds.Tables[0].Columns.Count.ToString();
            }
        }

        if (ListAtt != null)
        {
            string skl = ListAtt.Remove(ListAtt.LastIndexOf(','));
            //string[] colnm = skl.Split(',');
            string mdop = "select " + skl + " from Products where Product_id='" + proid + "'";
            SqlCommand cmdad = new SqlCommand(mdop, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmdad);
            DataSet dsd = new DataSet();
            dad.Fill(dsd);

            if (dsd.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; dsd.Tables[0].Columns.Count > i; i++)
                {
                    string sk = dsd.Tables[0].Columns[i].ToString();
                    if (dsd.Tables[0].Rows[0][sk].ToString() == "" || dsd.Tables[0].Rows[0][sk].ToString() == "0")
                    {
                        nk = nk + 1;
                    }
                }
                if (nk != 0)
                {
                    lblpder.Visible = true;
                    lblpdcom.ForeColor = System.Drawing.Color.Red;
                    linkerro.ForeColor = System.Drawing.Color.Red;
                    lblpder.ForeColor = System.Drawing.Color.Red;
                    //lblopnct.Text = nk.ToString();
                    lblpder.Text = "(Error :- " + nk.ToString() + ")";
                }
            }
        }

        if (lk == 0 && nk == 0)
        {
            string strproins = "update Products set Product_status='Pending' where Product_id=" + proid + " and Vender_id='" + ssss + "' ";
            con.Open();
            SqlCommand cmd = new SqlCommand(strproins, con);
            int sk = cmd.ExecuteNonQuery();
            if (sk > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "alert('Product Insert Successfully.');", true);
                con.Close();
                manddata();
                getoptda();
                getAdoptda();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "alert('Product Update Error.');", true);
                con.Close();
            }
        }
    }

    protected void btnassad_Click(object sender, EventArgs e)
    {

        string[] ArrColumns = listadatt.Remove(listadatt.LastIndexOf(',')).Split(',');
        string UpdateEle = null;
        for (int i = 0; i < ArrColumns.Length; i++)
        {
            TextBox txt = (TextBox)panatt.FindControl(ArrColumns[i]);
            UpdateEle += "" + ArrColumns[i] + "='" + txt.Text + "',";
        }
        string skup = UpdateEle.Remove(UpdateEle.LastIndexOf(','));
        string updatedynamic = "update Products set " + skup + "  where Product_id=" + proid + " and Vender_id='" + ssss + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(updatedynamic, con);
        int sk = cmd.ExecuteNonQuery();
        if (sk > 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "message", "alert('Data Successfully.');", true);
            con.Close();
            manddata();
            getAdoptda();
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "message", "alert('Data Update Error.');", true);
            con.Close();
        }
    }
}


