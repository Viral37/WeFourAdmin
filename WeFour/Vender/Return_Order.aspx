<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="Return_Order.aspx.cs" Inherits="Vender_Return_Order" EnableEventValidation="false" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="row" style="margin-top: 10px;">
        <div class="col-md-12">
            <div class="tabs">
                <ul class="nav nav-tabs">
                    <li class="active">
                        <a href="#popular" data-toggle="tab">Retutn Items </a>
                    </li>
                    <li>
                        <a href="#recent" data-toggle="tab">Cancel Items</a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div id="popular" class="tab-pane active">
                        <%--for cancel order view--%>
                        <asp:Panel runat="server" CssClass="table-responsive" ID="pncancel">
                            <h3 style="color: forestgreen; margin: 0px; margin-bottom: 10px;">Return Order Item</h3>
                            <asp:GridView runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                CellPadding="4" ForeColor="#333333" ID="gdretuen" OnPageIndexChanging="gdretuen_PageIndexChanging"
                                AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover table-responsive">
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
                                            <asp:LinkButton ID="lbb" runat="server" OnClick="lbb_Click1" Text='<%#Bind("order_num_det")%>' CommandArgument='<%#Eval("order_num_det") %>' CommandName='<%#Eval("Product_id") %>' ToolTip="Click here to View Order Detail"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>Order Date </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblodate" runat="server" Text='<%#Bind("order_date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>Status</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_status" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
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
                                        <HeaderTemplate>Order Return Quantity</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Bind("Return_qty")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>Return Reason</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCity" runat="server" Text='<%#Bind("Return_resion") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" />
                            </asp:GridView>
                            <asp:Label runat="server" ID="lblmsg" Visible="false" Text="No Order Found"></asp:Label>
                        </asp:Panel>
                    </div>
                    <div id="recent" class="tab-pane">

                        <%--for cancel order view--%>
                        <asp:Panel runat="server" CssClass="table-responsive" ID="Panel1">
                            <h3 style="color: forestgreen; margin: 0px; margin-bottom: 10px;">Cancel Order Item </h3>
                            <asp:GridView runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                                CellPadding="4" ForeColor="#333333" ID="gdcancel" OnPageIndexChanging="gdcancel_PageIndexChanging"
                                AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover table-responsive">
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
                                            <asp:LinkButton ID="lbbcalcel" OnClick="lbbcalcel_Click" runat="server" Text='<%#Bind("order_num_det")%>' CommandArgument='<%#Eval("order_num_det") %>' CommandName='<%#Eval("Product_id") %>' ToolTip="Click here to View Order Detail"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>Order Date </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblodate" runat="server" Text='<%#Bind("order_date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>Status</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_status" runat="server" Text='<%#Bind("Status")%>'></asp:Label>
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
                                        <HeaderTemplate>Order Return Quantity</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Bind("Return_qty")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>Return Reason</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCity" runat="server" Text='<%#Bind("Return_resion") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddv" runat="server">
                                            <asp:ListItem>Select Status</asp:ListItem>
                                            <asp:ListItem>Conform</asp:ListItem>
                                            <asp:ListItem>Cancel</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lbtnstatus" Text="Update Status" CommandArgument='<%#Eval("order_number") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" />
                            </asp:GridView>
                            <asp:Label runat="server" ID="Label1" Visible="false" Text="No Order Found"></asp:Label>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

