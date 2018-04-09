using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System.Text;
using System.Net.Mail;
using System.Net;

public partial class Register_User : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    CRUD objcrud = new CRUD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con.Open();
            SqlCommand cmddd = new SqlCommand("select cat_grp_id,cat_grp_name from Category_Group", con);
            SqlDataAdapter dq = new SqlDataAdapter();
            DataSet ds = new DataSet();
            dq.SelectCommand = cmddd;
            dq.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCountry.DataSource = cmddd.ExecuteReader();
                ddlCountry.DataTextField = "cat_grp_name";
                ddlCountry.DataValueField = "cat_grp_id";
                ddlCountry.DataBind();
            }

            con.Close();
            getdet();
        }
    }
    private void getdet()
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
            SqlCommand cmd = new SqlCommand("select * from tbl_login where status='Active' and email_id='" + ssss + "' and Vender='1'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Response.Write("<script>alert('Please wait for Approvel Process form BudgetOk Admin side.');</script>");
            }
            else
            {
                dr.Close();
                SqlCommand cmdsk = new SqlCommand("select * from tbl_login where status='Active' and email_id='" + ssss + "' and Vender='0'", con);
                SqlDataReader drsk = cmdsk.ExecuteReader();
                if (drsk.Read())
                {
                    Response.Write("<script>alert('Your Email ID is " + ssss + "') </script>");
                    ddlmr.SelectedValue = drsk["mr_ms"].ToString();
                    ddlmr.Enabled = false;
                    txtmail.Text = drsk["email_id"].ToString();
                    txt_name.Text = drsk["username"].ToString();
                    txt_name.ReadOnly = true;
                    txtmnu.Text = drsk["contact"].ToString();
                    txtlname.Text = drsk["last_name"].ToString();
                    txtlname.ReadOnly = true;
                    txtmname.ReadOnly = true;
                    txtmname.Text = drsk["middle_name"].ToString();
                    txtoadd.Text = drsk["address"].ToString();
                    txtocity.Text = drsk["city"].ToString();
                    txtocoun.Text = drsk["country"].ToString();
                    txtopin.Text = drsk["pincode"].ToString();
                    txtost.Text = drsk["state"].ToString();
                    pwssk.Visible = false;
                }
                else
                {
                    Response.Redirect("~/Seller/SellerHome.aspx");
                }
            }
        }
        else
        {
            txtmail.ReadOnly = false;
            txtmnu.ReadOnly = false;
        }
        con.Close();
    }

    protected void txtmail_TextChanged(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmdv = new SqlCommand("select * from tbl_login where status='Active' and email_id='" + txtmail.Text + "'", con);
        SqlDataReader drd = cmdv.ExecuteReader();
        if (drd.Read())
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
            "<script type='text/javascript'>alert('Your E-Mial ID already Registered. Please Use other E-Mail ID.');</script>");
            txtmail.Text = "";
            drd.Close();
        }
        con.Close();
    }

    //protected void btn1_Click(object sender, EventArgs e)
    //{
    //    step1.Visible = false;
    //    step2.Visible = true;
    //string sna = Convert.ToBase64String(Encoding.UTF32.GetBytes(txtpwd.Text));
    ////string uid= "BOKRPL"
    //string sk = txtrfid.Text;
    //string uid = null;
    //string[] ss = sk.Split('L');
    //for (int i = 0; i < ss.Length; i++)
    //{
    //    if (ss[i] != "BOKRP")
    //    {
    //        uid = ss[i];
    //    }
    //}

    //string insert = @"insert into tbl_login(mr_ms,username,middle_name,last_name,email_id,password,contact,status,User_Cust,Vender
    //  ,reference_id,total_pv,used_pv)values('" + ddlmr.SelectedValue + "','" + txt_name.Text + "','" + txtmname.Text + "','"
    //  + txtlname.Text + "','" + txtmail.Text + "','" + sna + "','" + txtmnu.Text + "','Deactive','0','0','" + uid
    //  + "','0','0')";
    //objcrud.crud(insert);
    //string inslog = "insert into tbl_login_ext(email)values('" + txtmail.Text + "')";
    //objcrud.crud(inslog);
    //// lbl_status.Text = "Registration successful.Please Check your Email and verify Account.";
    //string emailId = string.Empty;
    //string ActivationUrl = string.Empty;
    //MailMessage msg;
    //SmtpClient client;
    //client = new SmtpClient();
    //client.Host = "smtp.gmail.com";
    //client.Port = 587;
    //client.Credentials = new NetworkCredential("web.budgetok@gmail.com", "Budgetok@1473#");
    //client.EnableSsl = true;
    //MailAddress f = new MailAddress("sagardarji@gmail.com");
    //msg = new MailMessage();
    //msg.From = f;
    //msg.To.Add(txtmail.Text);
    //msg.Subject = "Confirmation email for account activation";
    //emailId = txtmail.Text.Trim();
    //ActivationUrl = Server.HtmlEncode("http://budgetok.infonaya.com/Login.aspx?email_id=" + FetchUserId(emailId));
    //msg.Body = "Hi " + txt_name.Text.Trim() + "!\n" +
    //      "Thanks for showing interest and registring in <a href='#'>http://www.infonaya.com/<a> " +
    //      " Please <a href='" + ActivationUrl + "'>click here to activate</a>  your account and enjoy our services. \nThanks!";
    //msg.IsBodyHtml = true;
    //client.Send(msg);
    //}
    private string FetchUserId(string emailId)
    {
        //string ssss = Encoding.UTF32.GetString(Convert.FromBase64String(emailId));
        string select = "SELECT email_id FROM tbl_login WHERE email_id='" + emailId + "'";
        string UserID = Convert.ToString(objcrud.scscalar(select));
        return UserID;
    }
    protected void btnst1_Click(object sender, EventArgs e)
    {
        con.Open();
        if (pwssk.Visible == true)
        {
            string sna = Convert.ToBase64String(Encoding.UTF32.GetBytes(txtpwd.Text));
            //string uid= "BOKRPL"
            string sk = txtrfid.Text;
            string uid = null;
            string[] ss = sk.Split('L');
            for (int i = 0; i < ss.Length; i++)
            {
                if (ss[i] != "BOKRP")
                {
                    uid = ss[i];
                }
            }
            string insert = @"insert into tbl_login(mr_ms,username,middle_name,last_name,email_id,password,contact,status,User_Cust,Vender,
reference_id,total_pv,used_pv)values('" + ddlmr.SelectedValue + "','" + txt_name.Text + "','" + txtmname.Text + "','" + txtlname.Text
+ "','" + txtmail.Text + "','" + sna + "','" + txtmnu.Text + "','Deactive','0','0','" + uid + "','0','0')";
            SqlCommand cmdin = new SqlCommand(insert, con);
            int login = cmdin.ExecuteNonQuery();
            string inslog = "insert into tbl_login_ext(email)values('" + txtmail.Text + "')";
            SqlCommand cmds = new SqlCommand(inslog, con);
            int log = cmds.ExecuteNonQuery();
            if (login > 0 || log > 0)
            {
                string sn = Convert.ToBase64String(Encoding.UTF32.GetBytes(txtmail.Text));
                HttpCookie ckid = new HttpCookie("inf");
                ckid.Value = sn + "$" + sna;
                ckid.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(ckid);
                step1.Visible = false;
                step2.Visible = true;
                step3.Visible = false;
                step4.Visible = false;
                btns2.Attributes.Remove("class");
                btns2.Attributes.Remove("disabled");
                btns2.Attributes.Add("class", "btn btn-primary btn-circle");
                btns1.Attributes.Add("class", "btn btn-primary btn-circle");
            }
        }
        else
        {
            SqlCommand cmduplo = new SqlCommand(@"update tbl_login set Vender='1',address='" + txtoadd.Text + "',state='" + 
                txtost.Text + "',city='" + txtocity.Text + "',pincode='" + txtopin.Text + "',country='" + txtocoun.Text
                + "' where status='Active' and email_id='" + txtmail.Text + "'", con);
            int sr = cmduplo.ExecuteNonQuery();
            if (sr > 0)
            {
                step1.Visible = false;
                step2.Visible = true;
                step3.Visible = false;
                step4.Visible = false;
                btns2.Attributes.Remove("class");
                btns2.Attributes.Remove("disabled");
                btns2.Attributes.Add("class", "btn btn-primary btn-circle");
                btns1.Attributes.Add("class", "btn btn-primary btn-circle");
            }
        }
        con.Close();
    }
    protected void btnnn_Click(object sender, EventArgs e)
    {
        string s = null;
        foreach (System.Web.UI.WebControls.ListItem item in ddlCountry.Items)
        {
            if (item.Selected)
            {
                s += item.Value + ",";
            }
        }
        string sl = s.TrimEnd(',');
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
        con.Open();
        SqlCommand cmd = new SqlCommand(@"update tbl_login set address='" + txtoadd.Text + "',state='" + txtost.Text + "',city='" +
            txtocity.Text + "',pincode='" + txtopin.Text + "',country='" + txtocoun.Text + "',group_name='" + sl 
            + "' WHERE email_id='" + ssss + "'", con);
        int sk = cmd.ExecuteNonQuery();
        SqlCommand cmdc = new SqlCommand(@"insert into tbl_business (email_id,buss_name,bill_label,reg_state,reg_city,reg_pincode,
        buss_date_establish,com_cin,com_pan,name_pan,country) values('" + ssss + "','" + txtbnm.Text + "','" + 
        txtblbl.Text + "','" + txtrst.Text + "','" + txtrcity.Text + "','" + txtpin.Text + "','" + txted.Text + "','" + 
        txtcpin.Text + "','" + txtcnpin.Text + "','" + txtpnam.Text + "','" + txtrcoun.Text + "')", con);
        int rs = cmdc.ExecuteNonQuery();
        if (rs > 0)
        {
            step1.Visible = false;
            step2.Visible = false;
            step3.Visible = true;
            step4.Visible = false;
            btns3.Attributes.Remove("class");
            btns2.Attributes.Remove("disabled");
            btns3.Attributes.Remove("disabled");
            btns1.Attributes.Add("class", "btn btn-primary btn-circle");
            btns2.Attributes.Add("class", "btn btn-primary btn-circle");
            btns3.Attributes.Add("class", "btn btn-primary btn-circle");
        }
        con.Close();
    }
    protected void btnst3_Click(object sender, EventArgs e)
    {
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
        con.Open();
        SqlCommand cmdban = new SqlCommand(@"insert into tbl_bank (ifsc_no,account_no,account_type,holder_name,benif_state,benif_city,
    benif_pincode,email_id,country)values('" + txtifsc.Text + "','" + txtacno.Text + "','" + txttyp.Text + "','" + txtbname.Text + "','" +
    txtbsta.Text + "','" + txtbcity.Text + "','" + txthpi.Text + "','" + ssss + "','" + txtbancaon.Text + "')", con);
        int sd = cmdban.ExecuteNonQuery();
        if (sd > 0)
        {
            step1.Visible = false;
            step2.Visible = false;
            step3.Visible = false;
            step4.Visible = true;
            btns4.Attributes.Remove("class");
            btns2.Attributes.Remove("disabled");
            btns3.Attributes.Remove("disabled");
            btns4.Attributes.Remove("disabled");
            btns1.Attributes.Add("class", "btn btn-primary btn-circle");
            btns2.Attributes.Add("class", "btn btn-primary btn-circle");
            btns3.Attributes.Add("class", "btn btn-primary btn-circle");
            btns4.Attributes.Add("class", "btn btn-primary btn-circle");
        }
        con.Close();
    }
    protected void btnst4_Click(object sender, EventArgs e)
    {
        string ssss = null;
        string mp = null;
        if (Context.Request.Cookies["inf"] != null)
        {
            string skp = Request.Cookies["inf"].Value;
            
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
        con.Open();
        string f_brp = filebrp.PostedFile.FileName;
        string f_pan = fupan.PostedFile.FileName;
        string f_as = fupcsta.PostedFile.FileName;
        string f_ap = fautadds.PostedFile.FileName;
        filebrp.SaveAs(Server.MapPath("~/Document/") + f_brp);
        fupan.SaveAs(Server.MapPath("~/Document/") + f_pan);
        fupcsta.SaveAs(Server.MapPath("~/Document/") + f_as);
        fautadds.SaveAs(Server.MapPath("~/Document/") + f_ap);
        string fb = "~/Document/" + f_brp;
        string fn = "~/Document/" + f_pan;
        string fs = "~/Document/" + f_as;
        string fp = "~/Document/" + f_ap;

        SqlCommand cmddoc = new SqlCommand(@"insert into tbl_doc (email_id,bus_reg_proof,bus_pan,com_bank_statment,auth_add_sign_proof)
        values('" + ssss + "','" + fb + "','" + fn + "','" + fs + "','" + fp + "')", con);
        int dd = cmddoc.ExecuteNonQuery();
        if (dd > 0)
        {
            string emailId = string.Empty;
            string ActivationUrl = string.Empty;
            MailMessage msg;
            SmtpClient client;
            client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new NetworkCredential("web.budgetok@gmail.com", "Budgetok@1473#");
            client.EnableSsl = true;
            MailAddress f = new MailAddress("sagardarji@infonaya.com");
            msg = new MailMessage();
            msg.From = f;
            msg.To.Add(ssss);
            msg.Subject = "Confirmation email for account activation";
            emailId = ssss.Trim();
            ActivationUrl = Server.HtmlEncode("http://budgetok.com/Seller/SellerHome.aspx?email_id=" + FetchUserId(emailId));
            msg.Body = "Hi " + ssss.Trim() + "!\n" +
                  "Thanks for showing interest and registring in <a href='#'>http://www.infonaya.com/<a> " +
                  " Please <a href='" + ActivationUrl + "'>click here to activate</a>  your vender account and enjoy our services. \nThanks!";
            msg.IsBodyHtml = true;
            client.Send(msg);
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
            "<script type='text/javascript'>alert('You are Registered. Please Check your Email and verify your vender Account..');</script>");
        }
    }
}