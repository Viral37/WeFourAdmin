<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="ViewProduct.aspx.cs" Inherits="ViewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .proimg {
            width: 50px;
            height: 60px;
        }

        .Ellipses {
            color: black;
            text-overflow: ellipsis;
            white-space: nowrap;
            overflow: hidden;
            display: block;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <section class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="Home.aspx">Home</a></li>
                        <li class="active">View Product</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h1>All product</h1>
                </div>
            </div>
        </div>
    </section>

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="kh" runat="server" Style="color: dodgerblue; font-size: 22px">Your Product Information</asp:Label>
                <div class="tabs tabs-bottom tabs-center tabs-simple">
                    <div class="row">
                        <ul class="nav nav-tabs pull-left">
                            <%--<li >
                                    <a href="#tabsNavigationSimple1" data-toggle="tab">Your Recents </a>
                                </li>--%>
                            <li class="active">
                                <a href="#tabsNavigationSimple2" data-toggle="tab">Active or Deactive Product(<asp:Label runat="server" ID="lblcount"></asp:Label>)</a>
                            </li>
                        </ul>
                    </div>
                    <div class="tab-content">
                        <%--    <div class="tab-pane active" id="tabsNavigationSimple1">
                                <div class="center">
                                    <h4>No Data Display</h4>
                                </div>
                            </div>--%>
                        <div class="tab-pane active" id="tabsNavigationSimple2">
                            <div class="pull-left">
                                <div class="row">
                                    <asp:DataList runat="server" ID="datalistbox" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal">
                                        <ItemTemplate>

                                            <div class="col-sm-12">
                                                <div class="panel panel-default">
                                                    <div id="collapse-voucher1" class="panel-collapse collapse in">
                                                        <div class="panel-body">
                                                            <div class="col-sm-3">
                                                                <%--<asp:Image runat="server" ImageUrl="~/img/products/product-1.jpg" CssClass="img-responsive" alt="BudgetOk" ID="Mainimg" />--%>
                                                                <asp:Image runat="server" ImageUrl='<%#"~/ProductImg/" + Eval("ProductImage1") %>' CssClass="proimg" alt="ProImage" ID="Mainimg" />
                                                            </div>
                                                            <div class="col-sm-8">
                                                                <table>
                                                                    <tr>
                                                                        <asp:Label runat="server" CssClass="Ellipses" Title='<%# Eval("ProductName") %>'><%# Eval("ProductName") %></asp:Label>
                                                                    <%--<label class="Ellipses"><%# Eval("ProductName") %></label>--%>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>MRP&nbsp:-</th>
                                                                        <td>&nbsp&nbsp<%# Eval("MRP") %></td>
                                                                    </tr>

                                                                    <tr>
                                                                        <th>Selling Price &nbsp:-</th>

                                                                        <td>&nbsp&nbsp<%# Eval("SellingPrice") %></td>
                                                                    </tr>

                                                                </table>

                                                                <br />
                                                                <%--<asp:LinkButton ID="lbtnremove" CssClass="pull-left" runat="server" CommandArgument='<%#Eval("Product_id") %>' OnClick="lbtnremove_Click">Remove</asp:LinkButton>--%>
                                                                <%--<asp:LinkButton ID="lbtnedit" CssClass="pull-right" runat="server" CommandArgument='<%#Eval("ProductId") %>' OnClick="lbtnedit_Click">Edit</asp:LinkButton>--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>

                                    </asp:DataList>
                                </div>
                                <hr />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

