<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="viewfull_product.aspx.cs" Inherits="Vender_viewfull_product" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style>
.myimg {
    position: relative;
    float: left;
    width:  100px;
    height: 100px;
    max-height:100px;
    max-width:100px;
    background-position: 50% 50%;
    background-repeat:   no-repeat;
    background-size:     cover;

}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="body" style="background: #F5F5F5">
        <div class="row">
            <div class="col-md-12">

                <div class="featured-boxes">
                    <div class="container">
                        <div class="col-sm-12">

                            <div class="row">
                                <%--<div class="col-md-6">
                                    </div>--%>
                                <div class="col-md-3 pull-lg-right btn-lg">
                                    <asp:Button runat="server" Text="Back" CssClass="btn btn-primary pull-right mb-xl" ID="Button1" OnClick="btnback_Click" />
                                </div>
                            </div>
                            <div class="featured-box featured-box-primary align-left mt-xlg">
                                <div class="box-content">
                                    <h4 class="heading-primary text-uppercase mb-md">Full Product Details</h4>
                                    <div id="frmSignIn">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-md-4">
                                                    <label class="l">Product Name</label>
                                                    <asp:Label runat="server" ID="lblpname" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="l">MRP</label>
                                                    <asp:Label runat="server" ID="lblmrp" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="l">Selling Price</label>
                                                    <asp:Label runat="server" ID="lblsprice" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-md-4">
                                                    <%--<a class="pull-right" href="#">(Lost Password?)</a>--%>
                                                    <label class="l">Weight</label>
                                                    <asp:Label runat="server" ID="lblweight" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <%--<a class="pull-right" href="#">(Lost Password?)</a>--%>
                                                    <label class="l">Stock</label>
                                                    <asp:Label runat="server" ID="lblstock" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <%--<a class="pull-right" href="#">(Lost Password?)</a>--%>
                                                    <label class="l">Listing Status</label>
                                                    <asp:Label runat="server" ID="lblliststatus" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        
                                           <div class="row">
                                            <div class="form-group">
                                                <div class="col-md-4">
                                                    <%--<a class="pull-right" href="#">(Lost Password?)</a>--%>
                                                    <label class="l">HSN</label>
                                                    <asp:Label runat="server" ID="lblhsn" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <%--<a class="pull-right" href="#">(Lost Password?)</a>--%>
                                                    <label class="l">GST</label>
                                                    <asp:Label runat="server" ID="lblgst" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <%--<a class="pull-right" href="#">(Lost Password?)</a>--%>
                                                    <label class="l">Procument Type</label>
                                                    <asp:Label runat="server" ID="lblprocurmenttype" CssClass="form-control input-lg"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        
                                        <h4 class="heading-primary text-uppercase mb-md">Product Image</h4>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-md-3">

                                                    <h5 class="text-uppercase mt-lg">Main Display Image</h5>
                                                    <span class="thumb-info thumb-info-lighten">
                                                        <span class="thumb-info-wrapper">
                                                            <%-- <img src="img/projects/project-2.jpg" class="img-responsive" alt="">--%>
                                                            <asp:Image runat="server" ID="mainimg" CssClass=" myimg " alt="image not availabel"/>

                                                            <span class="thumb-info-action">
                                                                <span class="thumb-info-action-icon"><i class="fa fa-link"></i></span>
                                                            </span>
                                                        </span>
                                                    </span>
                                                </div>

                                                <div class="col-md-3">
                                                    <h5 class="text-uppercase mt-lg">Extra Image</h5>
                                                    <span class="thumb-info thumb-info-lighten">
                                                        <span class="thumb-info-wrapper">
                                                            <%-- <img src="img/projects/project-2.jpg" class="img-responsive" alt="">--%>
                                                            <asp:Image runat="server" ID="mainimg1" CssClass="myimg" alt="image not availabel"/>
                                                            <span class="thumb-info-action">
                                                                <span class="thumb-info-action-icon"><i class="fa fa-link"></i></span>
                                                            </span>
                                                        </span>
                                                    </span>
                                                </div>
                                                <div class="col-md-3">


                                                    <h5 class="text-uppercase mt-lg">Extra Image</h5>

                                                    <span class="thumb-info thumb-info-lighten">
                                                        <span class="thumb-info-wrapper">
                                                            <%-- <img src="img/projects/project-2.jpg" class="img-responsive" alt="">--%>
                                                            <asp:Image runat="server" ID="mainimg2" CssClass="myimg" alt="image not availabel"  />
                                                            <span class="thumb-info-action">
                                                                <span class="thumb-info-action-icon"><i class="fa fa-link"></i></span>
                                                            </span>
                                                        </span>
                                                    </span>


                                                </div>
                                                <div class="col-md-3">

                                                    <h5 class="text-uppercase mt-lg">Extra Image</h5>
                                                    <span class="thumb-info thumb-info-lighten">
                                                        <span class="thumb-info-wrapper">
                                                            <%-- <img src="img/projects/project-2.jpg" class="img-responsive" alt="">--%>
                                                            <asp:Image runat="server" ID="mainimg3" CssClass="img-responsive myimg" alt="image not availabel"/>
                                                            <span class="thumb-info-action">
                                                                <span class="thumb-info-action-icon"><i class="fa fa-link"></i></span>
                                                            </span>
                                                        </span>
                                                    </span>

                                                </div>
                                            </div>
                                        </div>
                                        <%--                                        <div class="row">
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
                                                        <asp:Label runat="server" ID="lblmrp1" CssClass="form-control input-lg"></asp:Label>
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
                                    </div>
                                    <div class="col-md-6">
                                        <%--<asp:Button runat="server" Text="Back" CssClass="btn btn-primary pull-right mb-xl" ID="btnback" OnClick="btnback_Click" />--%>
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

