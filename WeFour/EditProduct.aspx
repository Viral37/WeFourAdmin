<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <section class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="Home.aspx">Home</a></li>
                        <li class="active">Edit Product</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h1>Draft</h1>
                </div>
            </div>
        </div>
    </section>
    <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="kh" runat="server" Style="color: dodgerblue; font-size: 22px">Add New Listing</asp:Label>
                    <div class="tabs tabs-bottom tabs-center tabs-simple">
                        <div class="row">
                            <ul class="nav nav-tabs pull-left">
                                <%--<li >
                                    <a href="#tabsNavigationSimple1" data-toggle="tab">Your Recents </a>
                                </li>--%>
                                <li class="active">
                                    <a href="#tabsNavigationSimple2" data-toggle="tab">Draft(<asp:Label runat="server" ID="lblcount"></asp:Label>)</a>
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
                                        <asp:DataList runat="server" ID="datalistbox"  Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal">
                                            <ItemTemplate>

                                                <div class="col-sm-12">
                                                    <div class="panel panel-default">
                                                        <div id="collapse-voucher1" class="panel-collapse collapse in">
                                                            <div class="panel-body">
                                                                <div class="col-sm-4">
                                                                    <asp:Image runat="server" ImageUrl ="~/img/products/product-1.jpg" CssClass="img-responsive" alt="BudgetOk" ID="Mainimg" />
                                                                    <%--<asp:Image runat="server" ImageUrl='<%#"~/Product_IMG/" + Eval("Image_1") %>' CssClass="img-responsive" alt="BudgetOk" ID="Mainimg" />--%>
                                                                </div>
                                                                <div class="col-sm-8">
                                                                    <table>
                                                                        <tr>
                                                                            <th>
                                                                              &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Name &nbsp:-
                                                                            </th>
                                                                            <td>&nbsp&nbsp<%# Eval("ProductName") %></td>
                                                                        </tr>

                                                                        <tr>
                                                                            <th>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp MRP&nbsp:-</th>
                                                                            <td>&nbsp&nbsp<%# Eval("MRP") %></td>
                                                                        </tr>

                                                                        <tr> 
                                                                            <th>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Selling Price &nbsp:-</th>
                                                                            
                                                                            <td>&nbsp&nbsp<%# Eval("SellingPrice") %></td>
                                                                        </tr>

                                                                    </table>
                                                              
                                                                    <br />
                                                                    <%--<asp:LinkButton ID="lbtnremove" CssClass="pull-left" runat="server" CommandArgument='<%#Eval("Product_id") %>' OnClick="lbtnremove_Click">Remove</asp:LinkButton>--%>
                                                                    <asp:LinkButton ID="lbtnedit" CssClass="pull-right" runat="server" CommandArgument='<%#Eval("ProductId") %>' OnClick="lbtnedit_Click">Edit</asp:LinkButton>
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

