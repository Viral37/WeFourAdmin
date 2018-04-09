<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Generate.aspx.cs" Inherits="Vender_Generate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .dvgray {
            background-color: #f6f6f6;
            height: 30%;
            padding: 10px;
        }

        .dvwhite {
            background-color: white;
            margin: 10px 85px 10px 85px;
            padding: 10px;
        }

        /*.ui-datepicker-next, .ui-datepicker-prev {
            display: none;
        }*/
    </style>
    <style type="text/css">
        /*.did {
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
        }*/
    </style>
    <link href="css/My/jquery-ui.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div role="main" class="main" style="background: white; padding-top: 30px;">
        <div class="container">
            <div class="row">
                <div>
                    <h2>
                        <label id="lbl_rname" runat="server"></label>
                    </h2>
                </div>
            </div>
        </div>
        <asp:Label runat="server" ID="lbl_msg"></asp:Label>
        <div class="dvgray" id="dvbnk" runat="server" visible="false">
            <div class="dvwhite">
                <asp:Button ID="btn_generate" runat="server" Text="Generate" CssClass="btn btn-primary" OnClick="btn_generate_Click" />

            </div>
        </div>
        <div class="dvgray" id="dvdt" runat="server" visible="false">
            <div class="dvwhite">
                <div class="form-group">
                    <div class="col-sm-3">
                        <div id="reportrange" class="daterange">
                            <asp:HiddenField ID="hd" runat="server" />
                             <i class="glyphicon glyphicon-calendar fa fa-calendar"></i>&nbsp;
                            <label id="gettxt1" runat="server" ></label>
                        </div>
                          <asp:Button ID="btn_report" runat="server" Text="Report Generate" CssClass="btn btn-primary" OnClick="btn_report_Click" />
                    </div>
                </div>


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

