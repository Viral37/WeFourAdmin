<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Edit_Product.aspx.cs" Inherits="Vender_demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div role="main" class="main">
        <section class="page-header" style="background-color: forestgreen">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-sm-4">
                            <ul class="breadcrumb">
                                <li><a href="Home.aspx" style="color: white">Home</a></li>
                                <li class="active" style="color: white;">Product</li>
                            </ul>
                        </div>
                        <div class="col-sm-8">
                            <asp:LinkButton ID="create_newlisting" Style="color: white; font-size: 18px; text-transform: uppercase; color: lightyellow" CssClass="pull-right" runat="server" OnClick="create_newlisting_Click"><u>Create New Listing</u></asp:LinkButton>
                            <%--<asp:LinkButton ID="LinkButton8" style="color: white" CssClass="pull-left" runat="server">Bulk upload dashboard</asp:LinkButton>--%>
                        </div>
                        <%--<div class="col-sm-4">
                            <div class="header-search hidden-xs">
                                <div id="searchForm">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="srchorder" placeholder="Search Product Available on Budgetok"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button runat="server" class="btn btn-default" type="submit" id="btnserch"><i class="fa fa-search"></i></button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                        <%--<div class="progress pull-right">
                            <div class="progress-bar progress-sm progress-bar-success progress-bar-striped active" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width: 50%">
                            </div>
                            <br />
                            <span style="color: white">Your Process is 50% Complated.</span>
                        </div>--%>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
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
                                    <a href="#tabsNavigationSimple2" data-toggle="tab">Draft(<asp:Label runat="server"></asp:Label>)</a>
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
                                        <asp:DataList runat="server" ID="datalistbox" OnEditCommand="datalistbox_EditCommand" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" RepeatColumns="2" RepeatDirection="Horizontal">
                                            <ItemTemplate>

                                                <div class="col-sm-12">
                                                    <div class="panel panel-default">
                                                        <div id="collapse-voucher1" class="panel-collapse collapse in">
                                                            <div class="panel-body">
                                                                <div class="col-sm-4">

                                                                    <asp:Image runat="server" ImageUrl='<%#"~/Product_IMG/" + Eval("Image_1") %>' CssClass="img-responsive" alt="BudgetOk" ID="Mainimg" />
                                                                </div>
                                                                <div class="col-sm-8">
                                                                    <table>
                                                                        <tr>
                                                                            <th>
                                                                              &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Name &nbsp:-
                                                                            </th>
                                                                            <td>&nbsp&nbsp<%# Eval("Product_Name") %></td>
                                                                        </tr>

                                                                        <tr>
                                                                            <th>Seller Sku ID&nbsp:-</th>
                                                                            <td>&nbsp&nbsp<%# Eval("Seller_sku_id") %></td>
                                                                        </tr>

                                                                        <tr> 
                                                                            <th>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Brand &nbsp:-</th>
                                                                            
                                                                            <td>&nbsp&nbsp<%# Eval("Brand") %></td>
                                                                        </tr>


                                                                    </table>
                                                                    
                                                                    <br />
                                                                    <asp:LinkButton ID="lbtnremove" CssClass="pull-left" runat="server" CommandArgument='<%#Eval("Product_id") %>' OnClick="lbtnremove_Click">Remove</asp:LinkButton>
                                                                    <asp:LinkButton ID="lbtnedit" CssClass="pull-right" runat="server" CommandArgument='<%#Eval("Product_id") %>' CommandName='<%#Eval("Prefix") %>' OnClick="lbtnedit_Click">Edit</asp:LinkButton>
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
    </div>
</asp:Content>

