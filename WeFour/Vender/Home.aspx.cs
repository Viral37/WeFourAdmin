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
public partial class Vender_Home : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    string ssss = null;
    CRUD objcrud = new CRUD();
    protected void Page_Load(object sender, EventArgs e)
    {
        login();
        Business_Detail();
        Bank_Details();
        Store_Details();
        processbar();
        try
        {
            con.Open();
            string ssss = null;
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
            SqlCommand cmd = new SqlCommand("select * from tbl_login where status='Active' and email_id='" + ssss + "' and Vender='A1'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //lbluser.Text = dr["username"].ToString() + " " + dr["last_name"].ToString();
                lbluser.Text = dr["username"].ToString();
                dr.Close();
            }
            else
            {
                //Response.Redirect("~/Seller/SellerHome.aspx");
            }
            con.Close();
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    //for Display Business Details While Page load
    public void Business_Detail()
    {
        string select = "select * from tbl_business where email_id='" + ssss + "'";
        SqlDataReader dr = objcrud.datareader(select);
        while (dr.Read())
        {
            string gstid = dr["Gst_Id"].ToString();
            if (gstid == "")
            {
                addd.Visible = true;
                view.Visible = false;
                lbl_buss_proof.Visible = false;
                lbl_cin.Visible = false;
                lbl_gstin.Visible = false;
                lbl_tan.Visible = false;
                lbl_sign.Visible = false;

            }
            else
            {
                addd.Visible = false;
                view.Visible = true;
                txtbname.ReadOnly = true;
                txtregadd.ReadOnly = true;
                txtbcity.ReadOnly = true;
                txtbstate.ReadOnly = true;
                txtbpcode.ReadOnly = true;
                txtbcontry.ReadOnly = true;
                txtpanname.ReadOnly = true;
                txtpno.ReadOnly = true;
                txtgstno.ReadOnly = true;
                txttanno.ReadOnly = true;
                txtcino.ReadOnly = true;
                txt_date.ReadOnly = true;
                Calendar_date.Enabled = false;
                //View Detail
                txtbname.Text = dr["buss_name"].ToString();
                txtregadd.Text = dr["reg_add"].ToString();
                txtbcity.Text = dr["reg_city"].ToString();
                txtbstate.Text = dr["reg_State"].ToString();
                txtbpcode.Text = dr["reg_pincode"].ToString();
                txtbcontry.Text = dr["country"].ToString();
                txtpanname.Text = dr["name_pan"].ToString();
                txtpno.Text = dr["com_pan"].ToString();
                txtgstno.Text = dr["Gst_ID"].ToString();
                txttanno.Text = dr["TAN_Id"].ToString();
                txtcino.Text = dr["com_cin"].ToString();
                txt_date.Text = dr["buss_date_establish"].ToString();

                ////Start code for Image Show

                //fu_gstin.Visible = false;
                //img_gstin.Visible = true;
                //img_gstin.ImageUrl = "~/Vender/UploadImages/GSTIN/" + dr["Gst_proof_Img"].ToString();

                ////End Code For Image Show
                fu_gstin.Visible = false;
                fu_bus_proof.Visible = false;
                fu_cin.Visible = false;
                fu_sign.Visible = false;
                fu_tan.Visible = false;

                lbl_gstin.Text = dr["Gst_proof_Img"].ToString();
                lbl_buss_proof.Text = dr["Tan_proof_img"].ToString();
                lbl_cin.Text = dr["CIN_proof_img"].ToString();
                lbl_sign.Text = dr["Signature_img"].ToString();
                lbl_tan.Text = dr["B_Proof_Img"].ToString();
                btnbsinsert.Visible = false;
                //lblprocess.Text = "30%";
                //pp.Style.Add("width", "30%");
            }
        }
    }

    protected void processbar()
    {
        if (view.Visible == true && bankview.Visible == false && storeview.Visible == false)
        {
            lblprocess.Text = "40%";
            pp.Style.Add("width", "40%");
        }

        else if (view.Visible == true && bankview.Visible == true && storeview.Visible == false)
        {

            lblprocess.Text = "90%";
            pp.Style.Add("width", "90%");
        }
        else if (view.Visible == true && bankview.Visible == true && storeview.Visible == true)
        {

            lblprocess.Text = "100%";
            pp.Style.Add("width", "100%");
        }
        else if (view.Visible == false && bankview.Visible == true && storeview.Visible == false)
        {

            lblprocess.Text = "40%";
            pp.Style.Add("width", "40%");
        }
        else if (view.Visible == false && bankview.Visible == false && storeview.Visible == true)
        {

            lblprocess.Text = "40%";
            pp.Style.Add("width", "40%");
        }
        else if (view.Visible == true && bankview.Visible == false && storeview.Visible == true)
        {

            lblprocess.Text = "90%";
            pp.Style.Add("width", "90%");
        }
    }
    //For Bank Detail Display
    public void Bank_Details()
    {
        string bankselect = "select * from tbl_bank where email_id='" + ssss + "'";
        SqlDataReader drbank = objcrud.datareader(bankselect);
        while (drbank.Read())
        {
            string ifc = drbank["ifsc_no"].ToString();
            if (ifc == "")
            {
                bankadd.Visible = true;
                bankview.Visible = false;
            }
            else
            {
                bankadd.Visible = false;
                bankview.Visible = true;

                txtbank_name.ReadOnly = true;
                txtbifcode.ReadOnly = true;
                txtbacno.ReadOnly = true;
                ddactype.Enabled = false;
                txtbholname.ReadOnly = true;
                txtbadd.ReadOnly = true;
                txtbastate.ReadOnly = true;
                txtbacity.ReadOnly = true;
                txtbpin.ReadOnly = true;
                txtbcontry.ReadOnly = true;
                ddcountry.Enabled = false;



                txtbank_name.Text = drbank["bank_name"].ToString();
                txtbifcode.Text = drbank["ifsc_no"].ToString();
                txtbacno.Text = drbank["account_no"].ToString();
                ddactype.Text = drbank["account_type"].ToString();
                txtbholname.Text = drbank["holder_name"].ToString();
                txtbadd.Text = drbank["benif_add"].ToString();
                txtbacity.Text = drbank["benif_city"].ToString();
                txtbastate.Text = drbank["benif_state"].ToString();
                txtbpin.Text = drbank["benif_pincode"].ToString();
                ddcountry.SelectedItem.Text = drbank["country"].ToString();
                btn_bank.Visible = false;
                //lblprocess.Text = "60%";
                //pp.Style.Add("width", "60%");
            }
        }
    }

    //For Store Detail Display
    public void Store_Details()
    {
        string select = "select bill_label,buss_model from tbl_business where email_id='" + ssss + "'";
        SqlDataReader dr = objcrud.datareader(select);
        while (dr.Read())
        {
            string bill_label = dr["bill_label"].ToString();
            if (bill_label == "")
            {
                storeadd.Visible = true;
                storeview.Visible = false;

            }
            else
            {
                storeadd.Visible = false;
                storeview.Visible = true;
                txtstore_name.ReadOnly = true;
                txtstore_desc.ReadOnly = true;
                txtstore_name.Text = dr["bill_label"].ToString();
                txtstore_desc.Text = dr["buss_model"].ToString();
                btn_store.Visible = false;
                //lblprocess.Text = "100%";
                //pp.Style.Add("width", "100%");
            }
        }
    }

    //Insert Business Detail
    protected void btnbsinsert_Click(object sender, EventArgs e)
    {
        try
        {

            if (fu_gstin.HasFile && fu_tan.HasFile && fu_cin.HasFile && fu_bus_proof.HasFile && fu_sign.HasFile)
            {
                //GSTIN
                string str_gstin = fu_gstin.PostedFile.FileName;
                fu_gstin.PostedFile.SaveAs(Server.MapPath("~/Vender/UploadImages/GSTIN/" + str_gstin));
                string img_gsin = str_gstin.ToString();

                //TAN
                string str_tan = fu_tan.PostedFile.FileName;
                fu_tan.PostedFile.SaveAs(Server.MapPath("~/Vender/UploadImages/TAN/" + str_tan));
                string img_tan = str_tan.ToString();

                //CIN
                string str_cin = fu_cin.PostedFile.FileName;
                fu_cin.PostedFile.SaveAs(Server.MapPath("~/Vender/UploadImages/CIN/" + str_cin));
                string img_cin = str_cin.ToString();

                //BUSINESS PROOF
                string str_buss = fu_bus_proof.PostedFile.FileName;
                fu_bus_proof.PostedFile.SaveAs(Server.MapPath("~/Vender/UploadImages/BUSINESS/" + str_buss));
                string img_buss = str_buss.ToString();

                //SIGNATURE
                string str_sign = fu_sign.PostedFile.FileName;
                fu_sign.PostedFile.SaveAs(Server.MapPath("~/Vender/UploadImages/SIGN/" + str_sign));
                string img_sign = str_sign.ToString();

                string cm = "insert into tbl_business(email_id,buss_name,reg_add,reg_city,reg_state,reg_pincode,buss_date_establish,com_cin,com_pan,name_pan,country,Gst_ID,Gst_proof_Img,TAN_Id,Tan_proof_img,CIN_proof_img,Signature_img,B_Proof_Img)values('" + ssss + "','" + txtbname.Text + "','" + txtregadd.Text + "','" + txtbcity.Text + "','" + txtbstate.Text + "','" + txtbpcode.Text + "','" + txt_date.Text + "','" + txtcino.Text + "','" + txtpno.Text + "','" + txtpanname.Text + "','" + txtbcontry.Text + "','" + txtgstno.Text + "','" + img_gsin.ToString() + "','" + txttanno.Text + "','" + img_tan.ToString() + "','" + img_cin.ToString() + "','" + img_sign.ToString() + "','" + img_buss.ToString() + "')";
                objcrud.crud(cm);
                Business_Detail();
                msg.InnerText = "Data Inserted Successfully";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
            }
        }
        catch (Exception ex)
        {

        }

    }

    //To Get Login Email Id
    public void login()
    {
        con.Open();

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
        con.Close();
    }

    //Insert Bank Details
    protected void btn_bank_Click(object sender, EventArgs e)
    {

        string bname = txtbank_name.Text;
        string ifsc = txtbifcode.Text;
        string acno = txtbacno.Text;
        string actype = ddactype.SelectedItem.Text;
        string holdname = txtbholname.Text;
        string add = txtbadd.Text;
        string state = txtbastate.Text;
        string city = txtbacity.Text;
        string pincode = txtbpin.Text;
        string country = ddcountry.SelectedItem.Text;


        string insert = @"insert into tbl_bank(bank_name,ifsc_no,account_no,account_type,holder_name,benif_add,benif_state,benif_city,benif_pincode,email_id,country)values('" + bname + "','" + ifsc + "','" + acno + "','" + actype + "','" + holdname + "','" + add + "','" + state + "','" + city + "','" + pincode + "','" + ssss + "','" + country + "')";
        objcrud.crud(insert);
        txtbank_name.Text = "";
        txtbifcode.Text = "";
        txtbacno.Text = "";
        ddactype.SelectedValue = "Please Choose Account type";
        txtbholname.Text = "";
        txtbadd.Text = "";
        txtbastate.Text = "";
        txtbacity.Text = "";
        txtbpin.Text = "";
        ddcountry.SelectedValue = "Please Choose Country";
        Bank_Details();
        msg.InnerText = "Data Inserted Successfully";
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
    }

    //Insert Store Details
    protected void btn_store_Click(object sender, EventArgs e)
    {
        //string update = "update tbl_business set bill_label='" + txtstore_name.Text + "',buss_model='" + txtstore_desc.Text + "' where email_id='" + ssss + "'";
        string ins = "insert into tbl_business(bill_label,buss_model)values('" + txtstore_name.Text + "','" + txtstore_desc.Text + "')";
        objcrud.crud(ins);
        txtstore_name.Text = "";
        txtstore_desc.Text = "";
        Store_Details();
        msg.InnerText = "Data Inserted Successfully";
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
    }
}