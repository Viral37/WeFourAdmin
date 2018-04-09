<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="Order_Manage.aspx.cs" Inherits="Vender_Active_Order" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .table table tbody tr td a,
        .table table tbody tr td span {
            position: relative;
            float: left;
            padding: 6px 12px;
            margin-left: -1px;
            line-height: 1.42857143;
            color: #337ab7;
            text-decoration: none;
            background-color: #fff;
            border: 1px solid #ddd;
        }

        .table table > tbody > tr > td > span {
            z-index: 3;
            color: #fff;
            cursor: default;
            background-color: #337ab7;
            border-color: #337ab7;
        }

        .table table > tbody > tr > td:first-child > a,
        .table table > tbody > tr > td:first-child > span {
            margin-left: 0;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 4px;
        }

        .table table > tbody > tr > td:last-child > a,
        .table table > tbody > tr > td:last-child > span {
            border-top-right-radius: 4px;
            border-bottom-right-radius: 4px;
        }

        .table table > tbody > tr > td > a:hover,
        .table table > tbody > tr > td > span:hover,
        .table table > tbody > tr > td > a:focus,
        .table table > tbody > tr > td > span:focus {
            z-index: 2;
            color: #23527c;
            background-color: #eee;
            border-color: #ddd;
        }
    </style>
    <script>
        function myFunction() {
            document.getElementById("cal").style.display = '';
        }
    </script>
    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="body" style="background: #F5F5F5; height: inherit;" id="vvbb">
        <div class="container-fluid">

            <div class="row" style="margin-top: 10px;">
                <div class="col-md-4">
                    <h3 style="color: forestgreen">Orders</h3>
                </div>

                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <div class="header-search hidden-xs">
                        <div id="searchForm">
                            <div class="input-group">

                                <asp:TextBox runat="server" CssClass="form-control" ID="srchorder" placeholder="Search by Order ID"></asp:TextBox>
                                <span class="input-group-btn">
                                    <button runat="server" class="btn btn-default" type="submit" id="btnserch" onserverclick="btnserch_ServerClick"><i class="fa fa-search"></i></button>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-6">
                            <div>
                                <nav>
                                    <ul class="nav nav-pills" id="my">
                                        <li style="margin-top: 2px; margin-right: 10px;">

                                            <label>Select Status</label>
                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_status">
                                                <asp:ListItem Value="0">Select Status</asp:ListItem>
                                                <asp:ListItem>Pending</asp:ListItem>
                                                <asp:ListItem>Conform</asp:ListItem>
                                                <asp:ListItem>Dispatch</asp:ListItem>
                                                <asp:ListItem>Delivered</asp:ListItem>

                                            </asp:DropDownList>
                                        </li>
                                        <li></li>


                                        <li>
                                            <div>


                                                <div>
                                                    <label>Select Time Period</label>
                                                </div>
                                                <div id="reportrange" class="daterange" style="background-color: white; padding: 5px;">
                                                    <asp:HiddenField ID="hd" runat="server" />
                                                    <i class="glyphicon glyphicon-calendar fa fa-calendar"></i>&nbsp;
                                                        <label id="gettxt1" runat="server"></label>
                                                </div>
                                                <br />


                                            </div>
                                        </li>
                                        <li style="margin-top: 31px; margin-left: 10px;">
                                            <asp:Button runat="server" ID="btn_find" Text="Find Orders" OnClick="btn_find_Click" CssClass="btn btn-primary" ValidationGroup="pdf" OnClientClick="return getdatetext();" />

                                        </li>
                                    </ul>
                                </nav>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-6"></div>
                        <div class="col-md-6">
                            <div class="col-md-8">
                                <div class="input-group">
                                </div>
                                <div class="col-md-4">
                                </div>
                            </div>
                        </div>
                    </div>


                </div>


                <div class="col-md-12">
                    <asp:Panel runat="server" CssClass="table-responsive" ID="pnall">
                        <h3 style="color: forestgreen; margin: 0px; margin-bottom: 10px;">Order Detail</h3>

                        <asp:GridView runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                            CellPadding="4" ForeColor="#333333" ID="gdorder"
                            AllowPaging="true" PageSize="8" OnPageIndexChanging="gdorder_PageIndexChanging" CssClass="table table-striped table-bordered table-hover table-responsive">
                            <RowStyle HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <HeaderStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="White" Font-Italic="true" HorizontalAlign="Left" />
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>Order Number</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbb" CausesValidation="false" runat="server" Text='<%#Bind("order_num_det")%>' CommandArgument='<%#Eval("order_num_det") %>' CommandName='<%#Eval("Product_id") %>' ToolTip="Click here to View Order Detail" OnClick="lbb_Click"></asp:LinkButton>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Status
                                       
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Order Date
                                       
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblodate" runat="server" Text='<%#Bind("order_date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Customer Email</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCId" runat="server" Text='<%#Bind("customer_emailid")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Product Name </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPName" runat="server" Text='<%#Bind("Product_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Order Quantity</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%#Bind("order_quantity")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Order Amount</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCity" runat="server" Text='<%#Bind("sell_price") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                        </asp:GridView>


                    </asp:Panel>


                    <div class="alert alert-danger col-md-2" style="margin-left: 45%;" runat="server" id="divalert" visible="false">
                        <strong>No Order Found</strong>
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

