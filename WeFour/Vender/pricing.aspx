<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="pricing.aspx.cs" EnableEventValidation="false" Inherits="Vender_pricing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="js/pricing/smoothscroll.js"></script>

    <style type="text/css">
        .col-centered {
            width: 40%;
            margin: auto;
        }

        @media only screen and (max-width: 768px) {
            /* For mobile phones: */
            .col-centered {
                width: 100%;
                margin: auto;
            }
        }

        .col-centeredupdown {
            width: 100%;
            margin: auto;
        }

        .top-border {
            border-top: 1px solid #ddd;
        }

        .bottom-border {
            border-bottom: 2px double black;
        }

        .as-font-size-medium {
            font-size: 2rem !important;
        }

        .move-right {
            padding-left: 5px;
        }

        #cal-referral-rate-container {
            position: absolute;
            right: 0;
            color: #999;
        }

        .as-tab {
            box-sizing: border-box;
        }

        .drop_cat {
            padding-top: 4px;
            padding-bottom: 4px;
            padding-left: 4px;
            border-left: 1px solid gray;
            border-right: 1px solid gray;
            border-bottom: 1px solid gray;
        }

        .price-symbol:before {
            content: '₹';
            position: absolute;
            font-size: 20px;
            font-weight: 500;
            top: 8px;
            left: 20px;
            margin-left: -3px;
        }

        .gms:before {
            content: 'gms';
            position: absolute;
            font-size: 16px;
            font-weight: 500;
            top: 8px;
            left: 270px;
        }

        .thblack {
            background-color: black;
            color: white;
            text-align: center;
            border: 1px solid black;
        }

        .thwhite {
            background-color: white;
            border: none;
        }

        .tdblack {
            border: 1px solid black;
            text-align: center;
            color: black;
        }

        .tbcells {
            empty-cells: hide;
        }

        .divrate {
            padding-top: 145px;
        }
    </style>

    <style type="text/css">
        /*
 CSS for the main interaction tab
*/
        .tabset > input[type="radio"] {
            position: absolute;
            left: -200vw;
        }

        .tabset .tab-panel {
            display: none;
        }

        .tabset > input:first-child:checked ~ .tab-panels > .tab-panel:first-child,
        .tabset > input:nth-child(3):checked ~ .tab-panels > .tab-panel:nth-child(2),
        .tabset > input:nth-child(5):checked ~ .tab-panels > .tab-panel:nth-child(3),
        .tabset > input:nth-child(7):checked ~ .tab-panels > .tab-panel:nth-child(4),
        .tabset > input:nth-child(9):checked ~ .tab-panels > .tab-panel:nth-child(5),
        .tabset > input:nth-child(11):checked ~ .tab-panels > .tab-panel:nth-child(6) {
            display: block;
        }

        /*
 Styling
*/

        .tabset > label {
            position: relative;
            display: inline-block;
            padding: 12px 45px 22px;
            border: 1px solid transparent;
            border-bottom: 0;
            cursor: pointer;
            font-weight: 600;
        }

            .tabset > label::after {
                content: "";
                position: absolute;
                left: 15px;
                bottom: 10px;
                width: 22px;
                height: 4px;
                background: #8d8d8d;
            }

            .tabset > label:hover,
            .tabset > input:focus + label {
                color: #06c;
            }

                .tabset > label:hover::after,
                .tabset > input:focus + label::after,
                .tabset > input:checked + label::after {
                    background: #06c;
                }

        .tabset > input:checked + label {
            border-color: #ccc;
            border-bottom: 1px solid #fff;
            margin-bottom: -1px;
        }

        .tab-panel {
            padding: 30px 0;
            border-top: 1px solid #ccc;
        }

        /*
 Demo purposes only
*/
        *,
        *:before,
        *:after {
            box-sizing: border-box;
        }


        .tabset {
            max-width: 100%;
        }
    </style>

    /*css for locally,regionally,Nationally
  <style type="text/css">
      .radiobutton {
      }

          .radiobutton input {
              visibility: hidden;
          }

          .radiobutton label {
              cursor: pointer;
              padding: 5px;
              border: 1px solid gray;
              border-radius: 5px;
              color: gray;
              margin:4px;
          }

          .radiobutton input:checked + label {
              border: 2px solid green;
          }
  </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div role="main" class="main" style="background: white">

                <div class="container-fluid ">
                    <div class="row">
                        <div class="col-md-12">
                            <h2 class="text-center">Find out the Referral Fee for your Product Category</h2>
                            <div class="col-centered ">
                                <div class="col-sm-12 ">
                                    <div class="form-group">
                                        <asp:DropDownList runat="server" ID="ddl_cat" CssClass="form-control" AutoPostBack="true"
                                            AppendDataBoundItems="True" OnSelectedIndexChanged="ddl_cat_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <div class="drop_cat" runat="server" visible="false" id="cat_comm">
                                            <label class="as-font-size-medium">
                                                <asp:Label runat="server" ID="lbl_main"></asp:Label>%</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="col-centered">
                                <div class="col-sm-offset-4 col-sm-4">
                                    <img src="img/subsidycalculator_blue.png" alt="" title="" class="img-responsive" style="width: 100%; height: 100%">
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="col-centered">
                                <h2 class="text-center">Calculate the amount you earn with<br />
                                    Pricing Calculator</h2>
                            </div>
                            <div class="col-centered">
                                <div class="col-sm-12 ">
                                    <div class="form-group">
                                        <asp:TextBox ID="txt_subcat" runat="server" CssClass="form-control"  OnTextChanged="txt_subcat_TextChanged" AutoPostBack="true" placeholder="Please type Category"></asp:TextBox>

                                        <asp:AutoCompleteExtender ID="txt_auto_AutoCompleteExtender" runat="server"
                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="20" CompletionInterval="1000"
                                            ServiceMethod="Getcat"
                                            ServicePath="~/Vender/pricing.aspx" TargetControlID="txt_subcat">
                                        </asp:AutoCompleteExtender>
                                        <div runat="server" visible="false" id="dv_referral_third">
                                            <label>
                                                Referral Fee @
                                <asp:Label runat="server" ID="lbl_sub_rf"></asp:Label>%</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div runat="server" visible="false" id="dv_product_price">
                                <div class="col-centered">
                                    <h4 class="text-center">Enter Product Price (including shipping charge to customer)</h4>
                                </div>
                                <div class="col-centered">
                                    <div class="col-sm-8">
                                        <div class="form-group ">
                                            <div class="price-symbol">

                                                <asp:TextBox ID="txt_prod_price" runat="server" autocomplete="off" CssClass="form-control" placeholder="5000" type="number" min="1" step="1"></asp:TextBox>
                                            </div>
                                            <%-- <asp:NumericUpDownExtender ID="NumericUpDown_product"
                                                runat="server" TargetControlID="txt_prod_price"
                                                 Step="1" Minimum="1" Maximum="100">
                                            </asp:NumericUpDownExtender>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_product" ControlToValidate="txt_prod_price" runat="server" Display="Dynamic"
                                                ValidationGroup="product_price" ErrorMessage=""></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:Button runat="server" CssClass="btn btn-success" Text="Calculate Fees" ValidationGroup="product_price" ID="btn_cal_fees" Width="100%" OnClick="btn_cal_fees_Click" />

                                    </div>
                                </div>
                            </div>

                            <br />
                            <br />
                            <br />

                            <div class="col-centered" id="dv_referral_fee" runat="server" visible="false">
                                <div class="col-xs-12  col-sm-12t top-border">
                                    <div>Referral Fee</div>
                                    <div>
                                        <label class="as-font-size-medium">₹<asp:Label runat="server" ID="lbl_ref"></asp:Label></label>
                                        <span class="pull-right">@
                            <asp:Label runat="server" ID="lbl_rf_percentage"></asp:Label>%</span>
                                    </div>
                                    <div class="clearfix"></div>

                                </div>
                                <br />
                                <br />
                                <br />

                            </div>

                            <div class="col-centered" runat="server" visible="false" id="dv_closing">
                                <div class="col-xs-12  col-sm-12  top-border">
                                    <div>Closing Fee</div>
                                    <div>
                                        <span class="as-font-size-medium">₹
                                    <asp:Label runat="server" ID="lbl_closingfee"></asp:Label></span>
                                    </div>

                                    <div class="clearfix"></div>

                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <div class="col-centered" runat="server" visible="false" id="dv_shipping">
                                <div class="tabset">
                                    <!-- Tab 1 -->
                                    <input type="radio" name="tabset" id="tab1" aria-controls="ship_using_amazon" checked>
                                    <label for="tab1">Ship using BudgetOk EasyShip</label>
                                    <!-- Tab 2 -->
                                    <input type="radio" name="tabset" id="tab2" aria-controls="ship_by_self">
                                    <label for="tab2">Ship by Self</label>


                                    <div class="tab-panels">
                                        <section id="ship_using_budgetok" class="tab-panel">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <label>Ship the product</label>
                                                </div>
                                                <div class="col-sm-6">
                                                    <a class="pull-right" href="http://localhost:60477/Vender/pricing.aspx#rate" id="a1" target="_self" onclick="return SetFocus()">Rate Card</a>
                                                    <div class="clearfix"></div>


                                                </div>
                                            </div>

                                            <br />
                                            <div class="display-inline-block">
                                                <div class="radio-group">
                                                    <asp:RadioButtonList ID="rbl_lrn" runat="server" CssClass="radiobutton" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Locally</asp:ListItem>
                                                        <asp:ListItem>Regionally</asp:ListItem>
                                                        <asp:ListItem>Nationally</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_rbl"
                                                        ControlToValidate="rbl_lrn" runat="server"
                                                        Display="Dynamic"
                                                        ValidationGroup="rbl_lrn" ErrorMessage=""></asp:RequiredFieldValidator>

                                                    <%--         <input type="radio" id="local" name="selector"><label for="option-one">Locally</label>
                                    <input type="radio" id="Regional" name="selector"><label for="option-two">Regionally</label>
                                    <input type="radio" id="National" name="selector"><label for="option-three">Nationally</label>
                                                    --%>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">

                                                <div>
                                                    <label>&nbsp;&nbsp;&nbsp;&nbsp;Enter Product Weight</label>
                                                </div>
                                                <div class="col-sm-8">
                                                    <div class="gms">
                                                        <asp:TextBox ID="txt_weight" runat="server" CssClass="form-control" type="number" min="1" step="1" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_weight"
                                                        ControlToValidate="txt_weight" runat="server"
                                                        Display="Dynamic"
                                                        ValidationGroup="rbl_lrn" ErrorMessage=""></asp:RequiredFieldValidator>

                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:Button ID="btn_easy_amazon" runat="server" Text="Submit"
                                                        ValidationGroup="rbl_lrn" CssClass="btn btn-success" Width="100%" OnClick="btn_easy_amazon_Click" />
                                                </div>

                                            </div>
                                        </section>
                                        <section id="ship_by_self" class="tab-panel" runat="server">
                                            <div class="row">

                                                <div>
                                                    <label>Shipping Cost</label>
                                                </div>
                                                <div class="col-sm-8">
                                                    <asp:TextBox ID="txt_self_ship" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:Button ID="btn_selfsubmit" runat="server" Text="Submit" CssClass="btn btn-success" Width="100%" OnClick="btn_selfsubmit_Click" />
                                                </div>

                                            </div>
                                        </section>

                                    </div>

                                </div>
                            </div>


                            <div class="col-centered" id="dv_ship_by_budgetok" runat="server" visible="false">
                                <div class="col-xs-12  col-sm-12  top-border">
                                    <br />
                                    <div class="as-font-size-medium">₹<asp:Label runat="server" ID="lbl_ship"></asp:Label></div>

                                    <div class="row">
                                        <div class="col-sm-8">
                                            <label>

                                                <asp:Label runat="server" ID="lbl_weight"></asp:Label>
                                                gms, Shipped
                                        <asp:Label runat="server" ID="lbl_ship_by_budgetok"></asp:Label><label>by Amazon</label></label>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:LinkButton ID="lnk_budgetok" runat="server" CssClass="pull-right" OnClick="lnk_budgetok_Click">Edit</asp:LinkButton>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>

                                </div>
                            </div>
                            <div class="col-centered" id="dv_ship_by_self" runat="server" visible="false">
                                <div class="col-xs-12  col-sm-12  top-border">
                                    <br />
                                    <div class="as-font-size-medium">₹<asp:Label runat="server" ID="lbl_ship_self"></asp:Label></div>

                                    <div class="row">
                                        <div class="col-sm-8">
                                            <label>
                                                ₹
                                        <asp:Label runat="server" ID="lbl_ship_charge"></asp:Label>

                                                <label>Ship By Self</label></label>
                                        </div>
                                        <%--<div class="col-sm-4">
                            <asp:LinkButton ID="lnk_self" runat="server" CssClass="pull-right" OnClick="lnk_self_Click">Edit</asp:LinkButton>
                        </div>--%>
                                    </div>

                                    <div class="clearfix"></div>

                                </div>
                            </div>
                            <div runat="server" visible="false" id="dv_RCS">
                                <div class="col-centered">
                                    <div class="col-xs-12  col-sm-12  top-border">
                                        <br />
                                        <div>Referral+Closing+Shipping</div>
                                        <div>
                                            <span class="as-font-size-medium">₹
                                    <asp:Label runat="server" ID="lbl_RCS"></asp:Label></span>
                                        </div>

                                        <div class="clearfix"></div>

                                    </div>
                                </div>
                                <div class="col-centered">
                                    <div class="col-xs-12  col-sm-12  bottom-border top-border">
                                        <br />
                                        <div>GST</div>
                                        <div class="row">
                                            <div class="col-sm-8">
                                                <span class="as-font-size-medium">₹
                                    <asp:Label runat="server" ID="lbl_GST"></asp:Label></span>

                                            </div>
                                            <div class="col-sm-4">
                                                <label class="pull-right">
                                                    @
                                    <asp:Label runat="server" ID="lbl_gst_per" Text="18"></asp:Label>%</label>
                                            </div>
                                        </div>

                                        <div class="clearfix"></div>

                                    </div>
                                </div>

                                <div class="col-centered">
                                    <div class="col-xs-12  col-sm-12 bottom-border">
                                        <br />
                                        <div class="row">
                                            <div class="col-sm-8">
                                                <label>Total Charges</label>

                                            </div>
                                            <div class="col-sm-4">
                                                <label class="pull-right">You Make</label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-8">
                                                <span class="as-font-size-medium">₹
                                    <asp:Label runat="server" ID="lbl_total" Text="295"></asp:Label></span>

                                            </div>
                                            <div class="col-sm-4">
                                                <span class="as-font-size-medium pull-right">₹
                                    <asp:Label runat="server" ID="lbl_you_make"></asp:Label></span>

                                            </div>
                                        </div>

                                        <div class="clearfix"></div>

                                    </div>
                                </div>
                                <div class="col-centered bottom-border">

                                    <br />

                                    <div>

                                        <label>Calculate your Profit</label>
                                    </div>
                                    <div class="col-xs-12  col-sm-12" id="dv_show_profit" runat="server" visible="false">

                                        <div class="col-xs-12  col-sm-12 ">
                                            <span class="as-font-size-medium">₹
                                            <asp:Label runat="server" ID="lbl_profit_price"></asp:Label></span>
                                        </div>
                                        <div class="col-sm-8">
                                            <label></label>
                                            <span>For the cost of ₹
                                            <asp:Label runat="server" ID="lbl_cost"></asp:Label></span>

                                        </div>
                                        <div class="col-sm-4">
                                            <asp:LinkButton ID="lnk_profit_edit" runat="server" CssClass="pull-right" OnClick="lnk_profit_edit_Click">Edit</asp:LinkButton>

                                        </div>
                                    </div>

                                    <div class="row" id="dv_cal_profit" runat="server">
                                        <div>
                                            &nbsp;&nbsp;&nbsp;&nbsp;<label>Enter Cost of Product</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <div class="price-symbol">
                                                <asp:TextBox ID="txt_cost" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <asp:Button ID="btn_profit" runat="server" Text="Whats my Profit" CssClass="btn btn-success" Width="100%" OnClick="btn_profit_Click" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="clearfix"></div>



                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <a name="rate"></a>
    <div id="rate_card" runat="server" class="divrate">


        <div class="container">
            <div class="col-sm-6">

                <h4>Fixed Closing Fee as per price band</h4>
                <div class="table-responsive">
                    <table class="table ">
                        <thead>
                            <tr>
                                <th class="thblack">Item Price</th>
                                <th class="thblack">Fixed CLosing Fee</th>

                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="tdblack">INR 0-500</td>
                                <td class="tdblack">INR 10</td>

                            </tr>
                            <tr>
                                <td class="tdblack">INR 500-1000</td>
                                <td class="tdblack">INR 20</td>

                            </tr>
                            <tr>
                                <td class="tdblack">INR 1000+</td>
                                <td class="tdblack">INR 40</td>

                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

        </div>
        <div class="container">
            <div class="col-sm-10">
                <h4>EasyShip Weight Handling Fees Standard-size items</h4>
                <div class="table-responsive">
                    <table class="table ">
                        <thead>
                            <tr>
                                <th class="thwhite"></th>
                                <th class="thblack" colspan="3">Easy Ship Weight Handling Fee</th>

                            </tr>
                            <tr>
                                <th class="thblack">Easy Ship Fee for Standard-size Items</th>
                                <th class="thblack">Local</th>
                                <th class="thblack">Regional</th>
                                <th class="thblack">National</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="tdblack">Up to 500 gm.</td>
                                <td class="tdblack">40</td>
                                <td class="tdblack">55</td>
                                <td class="tdblack">75</td>
                            </tr>
                            <tr>
                                <td class="tdblack">Each additional 500 gm.</td>
                                <td class="tdblack">40</td>
                                <td class="tdblack">45</td>
                                <td class="tdblack">55</td>
                            </tr>

                        </tbody>
                    </table>
                </div>
            </div>

        </div>
        <div class="container">
            <div class="col-sm-10">
                <h4>EasyShip Weight Handling Fee Oversize items</h4>
                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th class="thwhite"></th>
                                <th class="thblack" colspan="3">Easy Ship Weight Handling Fee</th>

                            </tr>
                            <tr>
                                <th class="thblack">Easy Ship Fee for Oversize Items</th>
                                <th class="thblack">Local</th>
                                <th class="thblack">Regional</th>
                                <th class="thblack">National</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="tdblack">Up to 5 kg.(fixed minimum fee)</td>
                                <td class="tdblack">90</td>
                                <td class="tdblack">140</td>
                                <td class="tdblack">190</td>
                            </tr>
                            <tr>
                                <td class="tdblack">Each additional kg.</td>
                                <td class="tdblack">19</td>
                                <td class="tdblack">21</td>
                                <td class="tdblack">23</td>
                            </tr>

                        </tbody>
                    </table>
                </div>
            </div>

        </div>
        <div class="container">
            <div class="col-sm-10">
                <h4>EasyShip Weight Handling Fee Heavy and Bulky items</h4>
                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th class="thwhite"></th>
                                <th class="thblack" colspan="3">Easy Ship Weight Handling Fee</th>

                            </tr>
                            <tr>
                                <th class="thblack">Easy Ship Fee for Oversize Heavy and Bulky Items</th>
                                <th class="thblack">Local</th>
                                <th class="thblack">Regional</th>

                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="tdblack">Up to 12 kg.(fixed minimum fee)</td>
                                <td class="tdblack">210</td>
                                <td class="tdblack">310</td>

                            </tr>
                            <tr>
                                <td class="tdblack">Each additional kg.</td>
                                <td class="tdblack">12.50</td>
                                <td class="tdblack">15</td>

                            </tr>

                        </tbody>
                    </table>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

