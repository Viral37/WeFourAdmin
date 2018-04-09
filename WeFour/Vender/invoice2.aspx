<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="invoice2.aspx.cs" Inherits="Vender_invoice2" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .did {
            display: inline-block;
        }

            .did label {
                padding: 4px 4px 4px 4px;
            }

        .daterange {
            background: #fff;
            cursor: pointer;
            padding: 5px 10px;
            border: 1px solid #ccc;
            width: 20%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div role="main" class="main" style="background: white; padding-top: 30px;">
        <div class="container">
            <div class="row">


                <div style="border-bottom: 2px solid gray; margin-bottom: 12px;">
                    <h4>Invoices</h4>
                </div>
                <div style="color: red;">
                    <label>* Please note that we will be discontinuing this page on September 30, 2017. Going forward, monthly commission invoices will be available here  </label>
                </div>

                <div style="border-left: 1px solid gray; border-right: 1px solid gray; border-bottom: 1px solid gray">
                    <div class="form-group top" style="background-color: green; padding: 10px;">
                        <div style="color: white">
                            <label>Invoice Time Period</label>
                        </div>

                        <div id="reportrange" class="daterange">
                            <asp:HiddenField ID="hd" runat="server" />
                             <i class="glyphicon glyphicon-calendar fa fa-calendar"></i>&nbsp;
                            <label id="gettxt1" runat="server" ></label>
                        </div>

                        <br />


                        
                    </div>
                    
                </div>
                <asp:Button runat="server" ID="btngen" Text="Generate" OnClick="btngen_Click" CssClass="btn btn-default" ValidationGroup="pdf" OnClientClick="return getdatetext();" />
            </div>
           

        </div>
    </div>
    <script type="text/javascript">


        $(function () {

            var start = moment().subtract(29, 'days');
            var end = moment();

            function cb(start, end) {
                $('#reportrange label').html(start.format('DD/MM/YYYY') + ' - ' + end.format('DD/MM/YYYY'));
                var g = $('#reportrange label').html();
                $("#ContentPlaceHolder1_hd").val(g);
            }

            $('#reportrange').daterangepicker({

                startDate: start,
                endDate: end,
                ranges: {
                    //'Today': [moment(), moment()],
                    //'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                    'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                    'This Month': [moment().startOf('month'), moment().endOf('month')],
                    'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                }
            }, cb);

            cb(start, end);

        });
    </script>
    
    <script type="text/javascript" src="http://cdn.jsdelivr.net /jquery/1/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdn.jsdelivr.net/momentjs/latest/moment.min.js"></script>
    <link rel="stylesheet" type="text/css" href="http://cdn.jsdelivr.net/bootstrap/3/css/bootstrap.css" />

    <!-- Include Date Range Picker -->
    <script type="text/javascript" src="http://cdn.jsdelivr.net/bootstrap.daterangepicker/2/daterangepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="http://cdn.jsdelivr.net/bootstrap.daterangepicker/2/daterangepicker.css" />
</asp:Content>

