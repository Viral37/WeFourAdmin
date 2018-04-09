using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class Vender_addbrand : System.Web.UI.Page
{
    CRUD objcrud = new CRUD();
    CRUD objmcrud = new CRUD();
    string cat_id = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_name.Text = Request.QueryString["brand"].ToString();
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        //try
        //{


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
                string brand = fu_logo.PostedFile.FileName;
                string brand_logo = "~/brand_logo/" + brand;

                string mrptag = fu_mrp_tag.PostedFile.FileName;
                string mrptag_file = "~/mrp_tag_image/" + mrptag;

                string tra_doc = fu_document.PostedFile.FileName;
                string tra_doc_file = "~/trademark_doc/" + tra_doc;


                StringBuilder selling = new StringBuilder(string.Empty);
                foreach (ListItem li in chk_selling.Items)
                {
                    if (li.Selected)
                    {
                        selling.Append(li).Append(", ");
                    }
                }
                string selcat = "select cat_id from Category where cat_name='" + Request.QueryString["Cat_id"].ToString() + "'";
                SqlDataReader dr = objmcrud.datareader(selcat);
                while (dr.Read())
                {
                    cat_id = dr["cat_id"].ToString();
                }
                string sell = selling.ToString().TrimEnd(' ').TrimEnd(',');
                string insert = @"insert into vender_brand_detail(ven_brand_name,ven_cat_id,brand_widely_distributed,self_dec,brand_alias,brand_desc,brand_logo,brand_website_link,brand_selling_currently,brand_manufracturer,brand_primary,mrptag_image,brand_owner,trademark_doc,trademark_num,trademark_class,trademark_date,status,v_email)values('" + lbl_name.Text + "','" + cat_id + "','" + rbl_widely.SelectedValue + "','" + rbl_self_dec.SelectedValue + "','" + txt_balias.Text + "','" + txt_bdesc.Text + "','" + brand_logo.ToString() + "','" + txt_blink.Text + "','" + sell.ToString() + "','" + rbl_manufracture.SelectedValue + "','" + rbl_primary.SelectedValue + "','" + mrptag_file.ToString() + "','" + rbl_owner.SelectedValue + "','" + tra_doc_file.ToString() + "','" + txt_number.Text + "','" + txt_class.Text + "','" + txt_date.Text + "','Pending','" + ssss + "')";
                objmcrud.crud(insert);
                fu_logo.SaveAs(Server.MapPath("~/brand_logo/" + brand));
                fu_mrp_tag.SaveAs(Server.MapPath("~/mrp_tag_image/" + mrptag));
                fu_document.SaveAs(Server.MapPath("~/trademark_doc/" + tra_doc));

                txt_balias.Text = "";
                txt_bdesc.Text = "";
                txt_blink.Text = "";
                txt_class.Text = "";
                txt_date.Text = "";
                txt_number.Text = "";
                rbl_widely.SelectedValue = "";

            }
        //}
        //catch (Exception ex)
        //{

        //}

    }


}