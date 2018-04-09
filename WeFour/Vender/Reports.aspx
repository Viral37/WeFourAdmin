<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Reports.aspx.cs" Inherits="Vender_Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        table, td, th {
            border: 1px solid gray;
            font-family: 'Times New Roman', Times, serif;
            font-style: normal;
            font-size: 20px;
            padding-top: 4px;
        }

        /*tr:hover {
            background: #ddd;
        }*/
        .accordion {
            border-top: 1px solid gray;
        }

            .accordion td {
                padding: 10px;
                border: none;
                font-size: 20px;
                color: #4a4a4a;
            }

            .accordion:hover {
                cursor: pointer;
            }

        table {
            width: 100%;
        }

        .hidden-row td {
            border: none;
            background-color: #f6f6f6;
            font-size: 16px;
        }

        .hd {
            padding: 15px;
        }

        .bx {
            padding: 30px;
            border: 1px solid gray;
            color: #4a4a4a;
            background-color: white;
            margin-left: 15px;
            margin-top: 5px;
            margin-bottom: 15px;
            width: 40%;
        }

        .bxs {
            padding: 30px;
            border: 1px solid gray;
            color: #4a4a4a;
            background-color: white;
            margin-left: 15px;
            margin-top: 5px;
            margin-bottom: 15px;
            width: 100%;
        }

        .bx1 {
            font-size: 20px;
        }

        .bx2 {
            font-size: 15px;
            color: #909090;
        }

        .bx3 {
            border-bottom: 1px solid #909090;
            padding: 9px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div role="main" class="main" style="background: white; padding-top: 30px;">
        <div class="container">
            <div class="row">
                <table class="research">

                    <tbody>
                        <tr class="accordion">
                            <td>B-Assured Reports</td>
                            <td class="pull-right"><a href="View_generated.aspx">View Generatred Reports</a></td>

                        </tr>
                        <tr class="hidden-row">
                            <td colspan="2">
                                <label class="hd">Reports of BudgetOk Assured status for your products.</label>
                                <br />
                                <div class="bx">
                                    <label class="bx1">
                                        BudgetOk Assured Health Reports
                                    </label>

                                    <br />
                                    <label class="bx2">
                                        Health check for all your products in Flipkart Fulfilment and Smart Fulfilment
                                    </label>
                                    <div class="bx3">
                                    </div>
                                    <br />
                                    <asp:LinkButton runat="server" ID="lnk_assured" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_assured_Click"></asp:LinkButton>


                                </div>

                            </td>

                        </tr>
                        <tr class="accordion">
                            <td>Invoices</td>
                            <td class="pull-right">View Generatred Reports</td>

                        </tr>
                        <tr class="hidden-row">
                            <td colspan="2">
                                <label class="hd">The monthly summary of all marketplace charges for your account.</label>
                                <br />
                                <div class="bx">
                                    <label class="bx1">
                                        Commision Invoices
                                    </label>

                                    <br />
                                    <label class="bx2">
                                        Use these reports to access all monthly commission invoices since April 2015. All credit and debit notes can also be accessed using this option.
                                    </label>
                                    <div class="bx3">
                                    </div>
                                    <br />
                                    <asp:LinkButton runat="server" ID="lnk_commision" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_commision_Click"></asp:LinkButton>


                                </div>

                            </td>

                        </tr>
                        <tr class="accordion">
                            <td>Listing reports</td>
                            <td class="pull-right">View Generatred Reports</td>

                        </tr>
                        <tr class="hidden-row">
                            <td colspan="2">
                                <label class="hd">Listings reports</label>
                                <br />
                                <div class="bx">
                                    <label class="bx1">
                                        Unsold listings
                                    </label>

                                    <br />
                                    <label class="bx2">
                                        Information of listings created before 3 months but have not had a sale in the last 3 months.
                                    </label>
                                    <div class="bx3">
                                    </div>
                                    <br />
                                    <asp:LinkButton runat="server" ID="lnk_unsold" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_unsold_Click"></asp:LinkButton>


                                </div>

                            </td>

                        </tr>
                        <tr class="accordion">
                            <td>Fulfilment Reports</td>
                            <td class="pull-right">View Generatred Reports</td>

                        </tr>
                        <tr class="hidden-row">
                            <td colspan="2">
                                <label class="hd">Reports for reconciling Orders , Returns, Inwarding and Recall Reports.</label>
                                <br />
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div class="bxs">
                                            <label class="bx1">
                                                Orders
                                            </label>

                                            <br />
                                            <label class="bx2">
                                                Detailed information of all orders and evaluation of past fulfilment performance.
                                            </label>
                                            <div class="bx3">
                                            </div>
                                            <br />
                                            <asp:LinkButton runat="server" ID="lnk_order" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_order_Click"></asp:LinkButton>


                                        </div>
                                    </div>
                                    <div class="col-sm-5">
                                        <div class="bxs">
                                            <label class="bx1">
                                                Consignment Inwards
                                            </label>

                                            <br />
                                            <label class="bx2">
                                                Detailed information of the status of your consignments that is inwarded into FA warehouses.
                                            </label>
                                            <div class="bx3">
                                            </div>
                                            <br />
                                            <asp:LinkButton runat="server" ID="lnk_inwards" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_inwards_Click"></asp:LinkButton>


                                        </div>
                                    </div>



                                </div>
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div class="bxs">
                                            <label class="bx1">
                                                Seller Recalls
                                            </label>

                                            <br />
                                            <label class="bx2">
                                                Detailed information of the status of your recalls requested across all FA warehouses.
.
                                            </label>
                                            <div class="bx3">
                                            </div>
                                            <br />
                                            <asp:LinkButton runat="server" ID="lnk_seller" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_seller_Click"></asp:LinkButton>


                                        </div>
                                    </div>
                                    <div class="col-sm-5">
                                        <div class="bxs">
                                            <label class="bx1">
                                                Weight Anomaly Orders
                                            </label>

                                            <br />
                                            <label class="bx2">
                                                Detailed information of all orders/listings for which system has reported incorrect package dimension entry.
                                            </label>
                                            <div class="bx3">
                                            </div>
                                            <br />
                                            <asp:LinkButton runat="server" ID="lnk_weight" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_weight_Click"></asp:LinkButton>


                                        </div>
                                    </div>



                                </div>
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div class="bxs">
                                            <label class="bx1">
                                                Returns
                                            </label>

                                            <br />
                                            <label class="bx2">
                                                Detailed information on all returns and tracking your reverse shipments' status.
.
                                            </label>
                                            <div class="bx3">
                                            </div>
                                            <br />
                                            <asp:LinkButton runat="server" ID="lnk_returns" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_returns_Click"></asp:LinkButton>


                                        </div>
                                    </div>




                                </div>
                            </td>

                        </tr>
                        <tr class="accordion">
                            <td>Payment Reports</td>
                            <td class="pull-right">View Generatred Reports</td>

                        </tr>
                        <tr class="hidden-row">
                            <td colspan="2">
                                <label class="hd">Reports for reconciling payments.</label>
                                <br />
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div class="bxs">
                                            <label class="bx1">
                                                Unsettled Transactions
                                            </label>

                                            <br />
                                            <label class="bx2">
                                                Report containing all the unsettled and unbilled (pre-dispatch) transactions corresponding to orders for a selected date range.
                                            </label>
                                            <div class="bx3">
                                            </div>
                                            <br />
                                            <asp:LinkButton runat="server" ID="lnk_unsettle" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_unsettle_Click"></asp:LinkButton>


                                        </div>
                                    </div>
                                    <div class="col-sm-5">
                                        <div class="bxs">
                                            <label class="bx1">
                                                Settled Transactions
                                            </label>

                                            <br />
                                            <label class="bx2">
                                                Report containing details of all transactions settled during a given date range. Includes information for Orders, PLA, TDS, SPF, Storage and Recall.
                                            </label>
                                            <div class="bx3">
                                            </div>
                                            <br />
                                            <asp:LinkButton runat="server" ID="lnk_settle" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_settle_Click"></asp:LinkButton>


                                        </div>
                                    </div>



                                </div>

                            </td>

                        </tr>
                        <tr class="accordion">
                            <td>Tax Reports</td>
                            <td class="pull-right">View Generatred Reports</td>

                        </tr>
                        <tr class="hidden-row">
                            <td colspan="2">
                                <label class="hd">Use these reports to access all tax related information. These reports should be used to file TDS and Sales tax.</label>
                                <br />
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div class="bxs">
                                            <label class="bx1">
                                                Sales Reports
                                            </label>

                                            <br />
                                            <label class="bx2">
                                                Start Here! Check all your sales happened over a time period. Use it for posting your sales and paying your sales taxes.
                                            </label>
                                            <div class="bx3">
                                            </div>
                                            <br />
                                            <asp:LinkButton runat="server" ID="lnk_sales" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_sales_Click"></asp:LinkButton>


                                        </div>
                                    </div>
                                    <div class="col-sm-5">
                                        <div class="bxs">
                                            <label class="bx1">
                                                TDS
                                            </label>

                                            <br />
                                            <label class="bx2">
                                                Contains detailed break-up of TDS related computation. Please use this report to pay and claim TDS reimbursement.
                                            </label>
                                            <div class="bx3">
                                            </div>
                                            <br />
                                            <asp:LinkButton runat="server" ID="lnk_tds" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_tds_Click"></asp:LinkButton>


                                        </div>
                                    </div>



                                </div>
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div class="bxs">
                                            <label class="bx1">
                                                GSTR return report
                                            </label>

                                            <br />
                                            <label class="bx2">
                                                Contains summary information that can be used to file GSTR - 1 and GSTR - 8 returns
                                            </label>
                                            <div class="bx3">
                                            </div>
                                            <br />
                                            <asp:LinkButton runat="server" ID="lnk_gst" Text="GENERATE REPORT" CssClass="pull-right" OnClick="lnk_gst_Click"></asp:LinkButton>


                                        </div>
                                    </div>




                                </div>
                            </td>

                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            var $research = $('.research');
            $research.find('.hidden-row').hide();

            $research.find('.accordion').click(function () {
                $research.find('.accordion').not(this).nextAll('.hidden-row:first').fadeOut(500);
                $(this).nextAll('.hidden-row:first').fadeToggle(500);
            });
        });
    </script>
</asp:Content>

