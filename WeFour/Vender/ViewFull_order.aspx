<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="ViewFull_order.aspx.cs" Inherits="Vender_ViewFull_order" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .l {
            color: forestgreen;
            font-size: 20px;
            font-family: 'Times New Roman', Times, serif;
        }
    </style>
    <script>
        function myFunction() {
            document.getElementById("demo").innerHTML = "Paragraph changed.";
            swal("ddd");
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <p id="demo">A Paragraph</p>
        <button type="button" onclick="myFunction()">Try it</button>
        <asp:GridView ID="datagrid" runat="server" CssClass="table table-striped table-bordered table-hover table-responsive" PagerStyle-CssClass="pager"
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>Order Number</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblGId" runat="server" Text='<%#Bind("order_num_det")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Order Date </HeaderTemplate>
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
                        <asp:Label ID="lblCity" runat="server" Text='<%#Bind("vender_emailid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" />
        </asp:GridView>

    </div>
    <div class="body" style="background: #F5F5F5">
        <div class="row">
            <div class="col-md-12">
                <div class="featured-boxes">
                    <div class="container">
                        <div class="col-sm-12">
                            <div class="featured-box featured-box-primary align-left mt-xlg">
                                <div class="box-content">
                                    <h4 class="heading-primary text-uppercase mb-md">Full Order Details</h4>
                                    <div id="frmSignIn">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-md-4">
                                                    <label class="l">Order Number</label>
                                                    <asp:Label runat="server" ID="lblname" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="l">Order Date</label>
                                                    <asp:Label runat="server" ID="lbldate" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="l">Order Status</label>
                                                    <%--<asp:Label runat="server" ID="lblstatus" CssClass="form-control input-lg"></asp:Label>--%>
                                                    <asp:DropDownList runat="server" ID="lbls" CssClass="form-control input-lg" OnSelectedIndexChanged="lbls_SelectedIndexChanged">
                                                        <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                                        <asp:ListItem Value="Conform">Conform</asp:ListItem>
                                                        <asp:ListItem Value="Dispatch">Dispatch</asp:ListItem>
                                                        <asp:ListItem Value="Delivered">Delivered</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-md-6">
                                                    <%--<a class="pull-right" href="#">(Lost Password?)</a>--%>
                                                    <label class="l">Product Name</label>
                                                    <asp:Label runat="server" ID="lblpname" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-6">
                                                    <%--<a class="pull-right" href="#">(Lost Password?)</a>--%>
                                                    <label class="l">Product Description</label>
                                                    <asp:Label runat="server" ID="lbldes" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <hr />
                                        <h4 class="heading-primary text-uppercase mb-md">Customer Details</h4>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-md-6">
                                                    <label class="l">Name</label>
                                                    <asp:Label runat="server" ID="lblcname" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="l">Emaild</label>
                                                    <asp:Label runat="server" ID="lblcid" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-md-3">
                                                    <label class="l">Address</label>
                                                    <asp:Label runat="server" ID="lblcaddress" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="l">Area</label>
                                                    <asp:Label runat="server" ID="lblcarea" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="l">Vilage/City</label>
                                                    <asp:Label runat="server" ID="lblcvilage" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="l">Area Pincode</label>
                                                    <asp:Label runat="server" ID="lblpincode" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <hr />
                                        <h4 class="heading-primary text-uppercase mb-md">Order  Details</h4>

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-md-3">
                                                    <label class="l">Base Unit</label>
                                                    <asp:Label runat="server" ID="lblbaseunit" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="l">Tax On Mrp</label>
                                                    <asp:Label runat="server" ID="lbltax" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="l">MRP</label>
                                                    <asp:Label runat="server" ID="lblmrp" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="l">Selling Price</label>
                                                    <asp:Label runat="server" ID="lblsellpr" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-md-3">
                                                    <label class="l">Quantity</label>
                                                    <asp:Label runat="server" ID="lblquaty" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="l">Discount On Order</label>
                                                    <asp:Label runat="server" ID="lbldiscount" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="l">Delivery Type</label>
                                                    <asp:Label runat="server" ID="lbldtype" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="l">PromoCode</label>
                                                    <asp:Label runat="server" ID="lblpromocode" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <hr />
                                        <h4 class="heading-primary text-uppercase mb-md">Cancel Order Details</h4>

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-md-6">
                                                    <label class="l">Return Quantiy</label>
                                                    <asp:Label runat="server" ID="lblrqty" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="l">Reason For Return</label>
                                                    <asp:Label runat="server" ID="lblreason" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <%--<div class="col-md-3">
                                                    <label class="l">MRP</label>
                                                    <asp:Label runat="server" ID="Label3" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <label class="l">Selling Price</label>
                                                    <asp:Label runat="server" ID="Label4" CssClass="form-control input-lg"></asp:Label>
                                                </div>--%>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:Button runat="server" Text="Save Changes" CssClass="btn btn-primary pull-right mb-xl" ID="btnsave" OnClick="btnsave_Click" />
                                            </div>
                                            <asp:Label runat="server" ID="lblmsg" Text="Data Save Succesfully" Visible="false"></asp:Label>
                                            <div class="col-md-6">
                                                <asp:Button runat="server" Text="Back to all Order" CssClass="btn btn-primary pull-right mb-xl" ID="btnback" OnClick="btnback_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

