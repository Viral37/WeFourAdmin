<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="View_Product.aspx.cs" Inherits="Vender_View_Product" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/My.css" rel="stylesheet" />
    <script type="text/javascript">

        //function for Live Products
        function Live() {

            var period_val = $("#nav li.active").attr('id');
            var lbl = document.getElementById("lbl_text").innerHTML = period_val;
            if (lbl == "ContentPlaceHolder1_nl") {
                $("#Live").show();
                $("#browse").show();
            }
        }

        //function for NonLive Products
        function NonLive() {
            var period_val = $("#nav li.active").attr('id');
            var lbl = document.getElementById("lbl_text").innerHTML = period_val;
            if (lbl == "ContentPlaceHolder1_ll") {
                $("#Live").hide();
                $("#browse").hide();
            }
        }
    </script>
    <style>
        /* Add here all your CSS customizations */
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main" role="main" style="background: #F5F5F5; height: 700px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2" style="border-right: solid">
                    <aside class="sidebar">
                        <h3 style="margin: 5px;">My Listings</h3>
                        <asp:Button runat="server" ID="mylist" CssClass="btn btn-3d btn-success mr-xs mb-sm" Text="Add New Listing" OnClick="mylist_Click" />
                        <hr class="invisible mt-xl mb-sm" />
                        <h4 class="heading-primary" id="browse">Browse</h4>

                        <ul class="nav nav-list mb-xlg sort-source" data-sort-id="portfolio" data-option-key="filter" data-plugin-options="{'layoutMode': 'fitRows', 'filter': '*'}" id="Live">
                            <li><a runat="server" id="sall" onserverclick="sall_ServerClick">Show All</a></li>
                            <h4>View by Approve status</h4>
                            <li><a runat="server" id="ab" onserverclick="ab_ServerClick">Active With Brand</a></li>
                            <li><a runat="server" id="awb" onserverclick="awb_ServerClick">Active Without Brand</a></li>
                            <h4>View by Stock Leval</h4>
                            <li><a runat="server" id="sl5" onserverclick="sl5_ServerClick">Less than 10</a></li>
                            <li><a runat="server" id="sm5" onserverclick="sm5_ServerClick">More then 10</a></li>
                            <li><a runat="server" id="outst" onserverclick="outst_ServerClick">Out of Stock</a></li>
                        </ul>

                        <hr class="invisible mt-xl mb-sm" />
                    </aside>
                </div>
                <div class="col-md-10">
                    <div class="tabs" style="margin-top: 30px;">
                        <div runat="server" id="divsk">
                            <ul class="nav nav-tabs" id="nav">
                                <li id="ll" runat="server" class="active">
                                    <a href="#popular10" data-toggle="tab" class="text-center" id="a_ll" runat="server" onclick="Live()"><i class="fa fa-star"></i>Live</a>
                                </li>
                                <li runat="server" id="nl">
                                    <a href="#recent10" data-toggle="tab" class="text-center" id="a_nl" runat="server" onclick="NonLive()">Not Live</a>
                                </li>
                            </ul>
                        </div>
                        <div class="tab-content" runat="server" id="ksl">
                            <div id="popular10" class="tab-pane active">
                                <div runat="server" id="divlk">
                                    <div class="header-search hidden-xs">
                                        <div id="searchForm" style="margin: 10px;">
                                            <div class="input-group">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="schbox" placeholder="Search your product by Name, price and stock ..."></asp:TextBox>
                                                <asp:AutoCompleteExtender ID="schbox_AutoCompleteExtender"
                                                    runat="server" MinimumPrefixLength="1"
                                                    EnableCaching="true"
                                                    CompletionSetCount="1"
                                                    CompletionInterval="1000"
                                                    ServiceMethod="GetCity"
                                                    TargetControlID="schbox">
                                                </asp:AutoCompleteExtender>
                                                <span class="input-group-btn">
                                                    <button runat="server" id="btnRun" class="btn btn-mini" title="Search" onserverclick="btnRun_ServerClick">
                                                        <i class="icon-camera-retro"></i>Search
                                                    </button>
                                                </span>

                                            </div>
                                        </div>
                                    </div>
                                    <asp:GridView CssClass="table table-hover center" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                        CellPadding="4" ForeColor="#333333" Width="100%" ID="apd"
                                        OnSelectedIndexChanging="apd_SelectedIndexChanging" AllowPaging="true" PageSize="10"
                                        OnPageIndexChanging="apd_PageIndexChanging">
                                        <RowStyle HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <HeaderStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="White" Font-Italic="true" HorizontalAlign="Left" />
                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                        <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />

                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>Product ID</HeaderTemplate>
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblGId" runat="server" Text='<%#Bind("Product_Name")%>'></asp:Label>--%>
                                                    <asp:LinkButton ID="lbtnviewproduct" runat="server" OnClick="lbtnviewproduct_Click" Text='<%#Eval("Prefix") +""+Eval("Product_id") %>' CommandArgument='<%#Eval("Prefix") +""+Eval("Product_id") %>' ToolTip="Click here to View Order Detail"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>Product Name</HeaderTemplate>
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblGId" runat="server" Text='<%#Bind("Product_Name")%>'></asp:Label>--%>
                                                    <asp:Label ID="lbtnviewproduct1" runat="server" Text='<%#Bind("Product_Name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>MRP</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIds" runat="server" Text='<%#Bind("MRP")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>Selling Price</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Bind("Your_selling_price")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>GST on Product(%)</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Bind("GST") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>Stock</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCity" runat="server" Text='<%#Bind("Stocks") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>Status</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblst" runat="server" Text='<%#Bind("Product_status") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div id="recent10" class="tab-pane">
                                <div runat="server" id="div1">
                                    <div class="header-search hidden-xs">
                                        <div id="searchForm1" style="margin: 10px;">
                                            <div class="input-group">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="nonlivesrch" placeholder="Search your product by Name, price and stock ..."></asp:TextBox>
                                                <asp:AutoCompleteExtender ID="AutoCompleteExtender1"
                                                    runat="server" MinimumPrefixLength="1"
                                                    EnableCaching="true"
                                                    CompletionSetCount="1"
                                                    CompletionInterval="1000"
                                                    ServiceMethod="GetCity"
                                                    TargetControlID="schbox">
                                                </asp:AutoCompleteExtender>
                                                <span class="input-group-btn">
                                                    <button runat="server" id="Button1" class="btn btn-mini" title="Search" onserverclick="srchnonlive_ServerClick">
                                                        <i class="icon-camera-retro"></i>Search
                                                    </button>
                                                </span>

                                            </div>
                                        </div>
                                    </div>
                                    <asp:GridView CssClass="table table-hover" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                        CellPadding="4" ForeColor="#333333" Width="100%" ID="nonlive"
                                        Visible="true" OnPageIndexChanging="nonlive_PageIndexChanging"
                                        AllowPaging="true" PageSize="10">
                                        <RowStyle HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <HeaderStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="White" Font-Italic="true" HorizontalAlign="Left" />
                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                        <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>Product ID</HeaderTemplate>
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblGId" runat="server" Text='<%#Bind("Product_Name")%>'></asp:Label>--%>
                                                    <asp:LinkButton ID="lbtnviewproduct" runat="server" OnClick="lbtnviewproduct_Click" Text='<%#Eval("Prefix") +""+Eval("Product_id") %>' CommandArgument='<%#Eval("Prefix") +""+Eval("Product_id") %>' ToolTip="Click here to View Order Detail"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>Product Name</HeaderTemplate>
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblGId" runat="server" Text='<%#Bind("Product_Name")%>'></asp:Label>--%>
                                                    <asp:Label ID="lbtnviewproducts" runat="server" Text='<%#Bind("Product_Name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>MRP</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIds" runat="server" Text='<%#Bind("MRP")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>Selling Price</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Bind("Your_selling_price")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>GST on Product(%) </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Bind("GST") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>Stock</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCity" runat="server" Text='<%#Bind("Stocks") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>Status</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblst" runat="server" Text='<%#Bind("Product_status") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

