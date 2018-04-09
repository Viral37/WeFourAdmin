using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Calculator;

public partial class Vender_Default2 : System.Web.UI.Page
{
    Calc objc = new Calc();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void txtbenadd_Click(object sender, EventArgs e)
    {
        int no = Convert.ToInt16(txtno1.Text);
        int no2 = Convert.ToInt16(txtno2.Text);
        int results = objc.add(no, no2);
        txtresults.Text = results.ToString();
    }

    protected void txtsub_Click(object sender, EventArgs e)
    {
        int no = Convert.ToInt16(txtno1.Text);
        int no2 = Convert.ToInt16(txtno2.Text);
        int results = objc.sub(no, no2);
        txtresults.Text = results.ToString();
    }
}