<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        /*use for outside image view*/
        .myimg {
            width: 250px;
            height: 120px;
        }

        /*use this for model image view*/
        .modelimg {
            max-width: 400px;
            max-height: 300px;
        }


        .overlayv {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0);
            transition: background 0.5s ease;
        }

        .containerv:hover .overlayv {
            display: block;
            background: rgba(0, 0, 0, .3);
        }


        .titlev {
            position: absolute;
            width: 500px;
            left: 50px;
            top: 120px;
            font-weight: 700;
            font-size: 30px;
            text-transform: uppercase;
            color: white;
            z-index: 1;
            transition: top .5s ease;
        }

        .containerv:hover .titlev {
            top: 90px;
        }

        .buttonv {
            position: absolute;
            width: 500px;
            left: 50px;
            top: 150px;
            opacity: 0;
            transition: opacity .35s ease;
        }

            .buttonv av {
                width: 200px;
                padding: 12px 48px;
                text-align: center;
                color: white;
                border: solid 2px white;
                z-index: 1;
            }

        .containerv:hover .buttonv {
            opacity: 1;
        }


        .txt {
            margin: 5px;
            width: 120px;
            border-radius: 5px;
            border-bottom-color: red;
        }

        .lbl {
            margin: 10px;
        }

        .hhh {
            margin-bottom: 2px;
            lighting-color: aqua;
        }

        .modal-body {
            max-height: calc(100vh - 212px);
            overflow-y: auto;
        }


        .btn {
            border: 2px solid white;
            color: white;
            background-color: forestgreen;
            padding: 6px 5px;
            border-radius: 8px;
            font-size: 15px;
            font-weight: bold;
        }

        .ifile {
            font-size: 100px;
            position: absolute;
            left: 0;
            top: 0;
            opacity: 0;
        }

        .lblfile {
            align: center;
            color: red;
            font-size: 17px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <section class="page-header" style="background-color: forestgreen">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="Home.aspx" style="color: white">Home</a></li>
                        <li class="active" style="color: white;">Product</li>
                    </ul>
                    <h1>Product</h1>
                    <div class="progress pull-right">
                        <div class="progress-bar progress-sm progress-bar-success progress-bar-striped active" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width: 50%">
                        </div>
                        <br />
                        <span style="color: white">Your Process is 50% Complated.</span>
                    </div>
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
            <div id="content" class="col-sm-12">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <label class="panel-title ">
                                    <i class="fa fa-check-circle"></i>Product Photos(<asp:Label runat="server" ID="ll"></asp:Label>/5)</label>
                                <asp:Label runat="server" ID="lbl_msg"></asp:Label>
                                <label class="panel-title pull-right"><a href="#" data-target="#ProductPhotos" data-toggle="modal" id="Photo">Edit</a></label>
                            </div>

                            <div class="modal fade" id="ProductPhotos" tabindex="-1" role="dialog" aria-labelledby="largeModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="ProductPhotos1">Product Photos</h4>
                                        </div>
                                        <div class="row mt-xlg">
                                            <div class="col-md-4 col-md-offset-1">
                                                <div class="thumb-gallery">
                                                    <div class="owl-carousel owl-theme manual thumb-gallery-detail show-nav-hover" id="thumbGalleryDetail">
                                                        <div class="containerv">
                                                            <span class="img-thumbnail">
                                                                <img alt="Project Image" src="img/projects/project.jpg" class="modelimg" id="img">
                                                                <p class="titlev">Main Image</p>
                                                                <div class="overlayv"></div>
                                                                <div class="buttonv">
                                                                    <label for="upload" class="btn">Upload Image</label>
                                                                    <asp:FileUpload runat="server" ID="fp1" onchange="readURL(this)" CssClass="ifile" />

                                                                </div>

                                                            </span>
                                                        </div>
                                                        <div class="containerv">
                                                            <span class="img-thumbnail">
                                                                <img alt="Project Image" src="img/projects/project-2.jpg" class="modelimg" id="img1">
                                                                <p class="titlev">Main Image</p>
                                                                <div class="overlayv"></div>
                                                                <div class="buttonv">
                                                                    <label for="upload" class="btn">Upload Image</label>
                                                                    <asp:FileUpload runat="server" ID="fp2" onchange="image1(this)" CssClass="ifile" />

                                                                </div>
                                                            </span>
                                                        </div>
                                                        <div class="containerv">
                                                            <span class="img-thumbnail">
                                                                <img alt="Project Image" src="img/projects/project-4.jpg" class="modelimg" id="img2">
                                                                <p class="titlev">Main Image</p>
                                                                <div class="overlayv"></div>
                                                                <div class="buttonv">
                                                                    <label for="upload" class="btn">Upload Image</label>
                                                                    <asp:FileUpload runat="server" ID="fp3" onchange="image2(this)" CssClass="ifile" />
                                                                </div>
                                                            </span>
                                                        </div>
                                                        <div class="containerv">
                                                            <span class="img-thumbnail">
                                                                <img alt="Project Image" src="img/projects/project-5.jpg" class="modelimg" id="img3">
                                                                <p class="titlev">Main Image</p>
                                                                <div class="overlayv"></div>
                                                                <div class="buttonv">
                                                                    <label for="upload" class="btn">Upload Image</label>
                                                                    <asp:FileUpload runat="server" ID="fp4" onchange="image3(this)" CssClass="ifile" />
                                                                </div>
                                                            </span>
                                                        </div>
                                                        <div class="containerv">
                                                            <span class="img-thumbnail">
                                                                <img alt="Project Image" src="img/projects/project-6.jpg" class="modelimg" id="img4">
                                                                <p class="titlev">Main Image</p>
                                                                <div class="overlayv"></div>
                                                                <div class="buttonv">
                                                                    <label for="upload" class="btn">Upload Image</label>
                                                                    <asp:FileUpload runat="server" ID="fp5" onchange="image4(this)" CssClass="ifile" />
                                                                </div>
                                                            </span>
                                                        </div>

                                                        <div class="containerv">
                                                            <span class="img-thumbnail">
                                                                <img alt="Project Image" src="img/projects/project-6.jpg" class="modelimg" id="img5">
                                                                <p class="titlev">Main Image</p>
                                                                <div class="overlayv"></div>
                                                                <div class="buttonv">
                                                                    <label for="upload" class="btn">Upload Image</label>
                                                                    <asp:FileUpload runat="server" ID="fp6" onchange="image5(this)" CssClass="ifile" />
                                                                </div>
                                                            </span>
                                                        </div>

                                                    </div>
                                                    <div class="owl-carousel owl-theme manual thumb-gallery-thumbs mt" id="thumbGalleryThumbs">
                                                        <div>
                                                            <span class="img-thumbnail cur-pointer">
                                                                <img alt="Project Image" src="img/projects/project.jpg" class="img-responsive" id="Imgthumb">
                                                            </span>
                                                        </div>
                                                        <div>
                                                            <span class="img-thumbnail cur-pointer">
                                                                <img alt="Project Image" src="img/projects/project-2.jpg" class="img-responsive" id="Imgthumb1">
                                                            </span>
                                                        </div>
                                                        <div>
                                                            <span class="img-thumbnail cur-pointer">
                                                                <img alt="Project Image" src="img/projects/project-4.jpg" class="img-responsive" id="Imgthumb2">
                                                            </span>
                                                        </div>
                                                        <div>
                                                            <span class="img-thumbnail cur-pointer">
                                                                <img alt="Project Image" src="img/projects/project-5.jpg" class="img-responsive" id="Imgthumb3">
                                                            </span>
                                                        </div>
                                                        <div>
                                                            <span class="img-thumbnail cur-pointer">
                                                                <img alt="Project Image" src="img/projects/project-6.jpg" class="img-responsive" id="Imgthumb4">
                                                            </span>
                                                        </div>
                                                        <div>
                                                            <span class="img-thumbnail cur-pointer">
                                                                <img alt="Project Image" src="img/projects/project-6.jpg" class="img-responsive" id="Imgthumb5">
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancle</button>
                                            <%--<asp:Button runat="server" CssClass="btn btn-primary" Text="Save Changes" ID="btn_upload" />--%>
                                            <button type="button" class="btn btn-default" data-dismiss="modal" runat="server" id="btnsaveimage">Save</button>
                                        </div>
                                    </div>

                                </div>

                            </div>
                            <div id="collapse-coupon" class="panel-collapse collapse in">
                                <div class="panel-body">
                                    <div class="col-md-4">
                                        <h5 class="text-uppercase mt-lg">Main Image</h5>
                                        <a href="portfolio-single-small-slider.html">
                                            <span class="thumb-info thumb-info-lighten">
                                                <span class="thumb-info-wrapper">
                                                    <img src="img/projects/project-2.jpg" class="myimg" alt="" id="Imgeout">
                                                    <span class="thumb-info-action">
                                                        <span class="thumb-info-action-icon"><i class="fa fa-link"></i></span>
                                                    </span>
                                                </span>
                                            </span>
                                        </a>
                                    </div>
                                    <div class="col-md-4">
                                        <h5 class="text-uppercase mt-lg">Default Lighten</h5>
                                        <a href="portfolio-single-small-slider.html">
                                            <span class="thumb-info thumb-info-lighten">
                                                <span class="thumb-info-wrapper">
                                                    <img src="img/projects/project-2.jpg" class="myimg" alt="" id="Imgeout1">
                                                    <span class="thumb-info-action">
                                                        <span class="thumb-info-action-icon"><i class="fa fa-link"></i></span>
                                                    </span>
                                                </span>
                                            </span>
                                        </a>
                                    </div>
                                    <div class="col-md-4">
                                        <h5 class="text-uppercase mt-lg">Default Lighten</h5>
                                        <a href="portfolio-single-small-slider.html">
                                            <span class="thumb-info thumb-info-lighten">
                                                <span class="thumb-info-wrapper">
                                                    <img src="img/projects/project-2.jpg" class="myimg" alt="" id="Imgeout2">
                                                    <span class="thumb-info-action">
                                                        <span class="thumb-info-action-icon"><i class="fa fa-link"></i></span>
                                                    </span>
                                                </span>
                                            </span>
                                        </a>
                                    </div>
                                    <div class="col-md-4">
                                        <h5 class="text-uppercase mt-lg">Default Lighten</h5>
                                        <a href="portfolio-single-small-slider.html">
                                            <span class="thumb-info thumb-info-lighten">
                                                <span class="thumb-info-wrapper">
                                                    <img src="img/projects/project-2.jpg" class="myimg" alt="" id="Imgeout3">
                                                    <span class="thumb-info-action">
                                                        <span class="thumb-info-action-icon"><i class="fa fa-link"></i></span>
                                                    </span>
                                                </span>
                                            </span>
                                        </a>
                                    </div>
                                    <div class="col-md-4">
                                        <h5 class="text-uppercase mt-lg">Default Lighten</h5>
                                        <a href="portfolio-single-small-slider.html">
                                            <span class="thumb-info thumb-info-lighten">
                                                <span class="thumb-info-wrapper">
                                                    <img src="img/projects/project-2.jpg" class="myimg" alt="" id="Imgeout4">
                                                    <span class="thumb-info-action">
                                                        <span class="thumb-info-action-icon"><i class="fa fa-link"></i></span>
                                                    </span>
                                                </span>
                                            </span>
                                        </a>
                                    </div>
                                    <div class="col-md-4">
                                        <h5 class="text-uppercase mt-lg">Default Lighten</h5>
                                        <a href="portfolio-single-small-slider.html">
                                            <span class="thumb-info thumb-info-lighten">
                                                <span class="thumb-info-wrapper">
                                                    <img src="img/projects/project-2.jpg" class="myimg" alt="" id="Imgeout5">
                                                    <span class="thumb-info-action">
                                                        <span class="thumb-info-action-icon"><i class="fa fa-link"></i></span>
                                                    </span>
                                                </span>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--end of panel default--%>
                    </div>
                    <div class="col-sm-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <label class="panel-title">
                                    <asp:Label runat="server" ID="lblprer"><i id="mp" class="fa fa-check-circle"></i></asp:Label>
                                    Price, Stock and Shipping Information(<asp:Label runat="server" ID="lblmnct"></asp:Label>/<asp:Label runat="server" ID="lblmct"></asp:Label>)<asp:Label runat="server" ID="lbler"></asp:Label></label>
                                <label class="panel-title pull-right"><a href="#" data-target="#SellingInformation" data-toggle="modal" id="SellInfo">Edit</a></label>
                            </div>
                            <div class="modal fade" id="SellingInformation" tabindex="-1" role="dialog" aria-labelledby="largeModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="SellingInformation1">Selling Information</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div id="demo-form-bank" class="form-horizontal mb-lg">
                                                <label class="control-label">Listing Information</label>
                                                <br />
                                                <div class="form-group">
                                                    <label class="col-sm-3 control-label" title="Shrey">Product Name <a><i class="fa fa-question-circle" title="Unique Identifier for the listings"></i></a></label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtpname" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtpname" runat="server" ValidationGroup="clicksubmit" Text="Enter Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <hr />
                                                <label class="control-label">Status Details</label>
                                                <br />
                                                <div class="form-group">

                                                    <label class="col-sm-3 control-label">Listing Status <a><i class="fa fa-question-circle" title="inactive listings are not available for buyers on Budgetok"></i></a></label>
                                                    <div class="col-sm-4">
                                                        <asp:DropDownList ID="ddstatus" CssClass="form-control" runat="server">
                                                            <asp:ListItem>Select One</asp:ListItem>
                                                            <asp:ListItem Value="Active">Active</asp:ListItem>
                                                            <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <hr />
                                                ser
                                                    <label class="control-label">PRICE DETAILS</label>
                                                <br />
                                                <div class="form-group">
                                                    <label class="col-sm-3 control-label">MRP <a><i class="fa fa-question-circle" title="Maximum retails price of the pruduct"></i></a></label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtmrp" runat="server" CssClass="form-control" type="number" Text="0" min="0" step="1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvmrp" ControlToValidate="txtmrp" runat="server" ValidationGroup="clicksubmit" Text="MRP: Mandatory attribute not given" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-3 control-label">Your Selling Price <a><i class="fa fa-question-circle" title="Price at which you want to sell this listing"></i></a></label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtsellprice" runat="server" CssClass="form-control" type="number" min="0" step="1"></asp:TextBox>


                                                        <asp:RequiredFieldValidator ID="rfvsellprice" ControlToValidate="txtsellprice" runat="server" ValidationGroup="clicksubmit" Text="Your selling price: Mandatory attribute not given" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator runat="server" ValidationGroup="clicksubmit" ID="cmno" ControlToValidate="txtmrp" ControlToCompare="txtsellprice" Operator="GreaterThan" Type="Integer" ErrorMessage="Your Selling Price cannot be greater than MRP." /><br />
                                                    </div>
                                                </div>
                                                <label>Please Enter Your Mrp and Selling Price Included GST and Other Charges.</label>
                                                <hr />
                                                <label class="control-label">INVENTORY DETAILS</label>
                                                <br />
                                                <div class="form-group">
                                                    <label class="col-sm-3 control-label">Stock <a><i class="fa fa-question-circle" title="Number of items you have in stock"></i></a></label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtstock" runat="server" CssClass="form-control" type="number" min="0" step="1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvstock" ControlToValidate="txtstock" runat="server" ValidationGroup="clicksubmit" Text="Your Stock count Mandatory attribute not given" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <hr />

                                                <label class="control-label">TAX DETAILS</label>
                                                <br />
                                                <div class="form-group">
                                                    <label class="col-sm-3 control-label">HSN <a><i class="fa fa-question-circle" title="Code of your product for determining applicable tax rates"></i></a></label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txthsn" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="first_name" runat="server"
                                                            ControlToValidate="txthsn" ErrorMessage="Mandatory attribute hsn is missing" ForeColor="Red"
                                                            ValidationGroup="clicksave" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        <asp:RequiredFieldValidator ID="rfvhsn" runat="server"
                                                            ControlToValidate="txthsn" ErrorMessage="Mandatory attribute hsn is missing" ForeColor="Red"
                                                            ValidationGroup="clicksubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        <%--<asp:LinkButton runat="server"><h5 style="color:cornflowerblue"><u>Find Relevent HSN Codes</u></h5></asp:LinkButton>--%>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label class="col-sm-3 control-label">Goods Service Tax <a><i class="fa fa-question-circle" title="Goods and Services Tax rate for your listing"></i></a></label>
                                                    <div class="col-sm-4">
                                                        <asp:DropDownList ID="ddgst" CssClass="form-control" runat="server">
                                                            <asp:ListItem>Select One</asp:ListItem>
                                                            <asp:ListItem>0</asp:ListItem>
                                                            <asp:ListItem>3</asp:ListItem>
                                                            <asp:ListItem>5</asp:ListItem>
                                                            <asp:ListItem>12</asp:ListItem>
                                                            <asp:ListItem>18</asp:ListItem>
                                                            <asp:ListItem>28</asp:ListItem>
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="ddgst" InitialValue="Select One" ErrorMessage="Mandatory attribute Goods Service tax is missing" ForeColor="Red"
                                                            ValidationGroup="clicksave" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <hr />
                                                <div class="form-group">
                                                    <label class="col-sm-3 control-label">Description <a><i class="fa fa-question-circle" title="Goods and Services Tax rate for your listing"></i></a></label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox runat="server" ID="txtdescription" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancle</button>
                                            <asp:Button runat="server" CssClass="btn btn-primary" Text="Save" ID="btnstaticsave" OnClick="btnstaticsave_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="collapse-voucher" class="panel-collapse collapse in">
                                <div class="panel-body">
                                    <label class="col-sm-6 control-label" for="input-voucher">Product Name</label>
                                    <label class="col-sm-6 control-label" for="input-voucher">Listing Status</label>
                                    <label class="col-sm-6 control-label" for="input-voucher">MRP</label>
                                    <label class="col-sm-6 control-label" for="input-voucher">Your Selling Price</label>
                                </div>
                            </div>
                        </div>

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <label class="panel-title">
                                    <asp:Label runat="server" ID="Label1"><i id="mp" class="fa fa-check-circle"></i></asp:Label>
                                    Price, Stock and Shipping Information(<asp:Label runat="server" ID="Label2"></asp:Label>/<asp:Label runat="server" ID="Label3"></asp:Label>)<asp:Label runat="server" ID="Label4"></asp:Label></label>
                                <label class="panel-title pull-right"><a href="" data-target="#SellingInformation11" data-toggle="modal" id="SellInfo1">Edit</a></label>
                            </div>
                            <div class="modal fade" id="SellingInformation11" tabindex="-1" role="dialog" aria-labelledby="largeModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="SellingInformation31">Selling Information</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div id="demo-form-bank1" class="form-horizontal mb-lg">
                                                <asp:DataList ID="DataList1" runat="server" Width="100%" OnItemDataBound="DataList1_ItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="form-group">
                                                            <%--<label class="col-sm-3 control-label" runat="server" id="AttType">Package Heigth <a><i class="fa fa-question-circle" title="Height of the final package in cms"></i></a></label>--%>
                                                            <asp:HiddenField ID="HideType" runat="server" Value='<%#Eval("ToolName")%>' />
                                                            <asp:Label ID="AttType" CssClass="col-sm-4 control-label" runat="server" Text='<%# Eval("MAttributeName") %>' />
                                                            <div class="col-sm-6">
                                                                <asp:TextBox ID="TextType" runat="server" CssClass="form-control lg" ValidationGroup="dynamic"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancle</button>

                                            <asp:Button ID="btndynamicsave" runat="server" CssClass="btn btn-primary" Text="Save Changes" OnClick="btndynamicsave_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="collapse-voucher1" class="panel-collapse collapse in">
                                <div class="panel-body">
                                    <label class="col-sm-6 control-label" for="input-voucher">Product Name</label>
                                    <label class="col-sm-6 control-label" for="input-voucher">Listing Status</label>
                                    <label class="col-sm-6 control-label" for="input-voucher">MRP</label>
                                    <label class="col-sm-6 control-label" for="input-voucher">Your Selling Price</label>
                                </div>
                            </div>
                        </div>

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <label class="panel-title">
                                    <asp:Label runat="server" ID="Label5"><i id="mp" class="fa fa-check-circle"></i></asp:Label>
                                    Unique Product Attribute(<asp:Label runat="server" ID="Label6"></asp:Label>/<asp:Label runat="server" ID="Label7"></asp:Label>)<asp:Label runat="server" ID="Label8"></asp:Label></label>
                                <label class="panel-title pull-right"><a href="#" data-target="#UniqueProductAttribute" data-toggle="modal" id="SellInfo11">Edit</a></label>
                            </div>
                            <div class="modal fade" id="UniqueProductAttribute" tabindex="-1" role="dialog" aria-labelledby="largeModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="UniqueProductAttribute1">Product Attribute</h4>
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>

                                                <div class="modal-body">
                                                    <div id="demo-form-UniqueProductAttribute" class="form-horizontal mb-lg">
                                                        <div class="form-group">
                                                            <label class="col-sm-3 control-label" title="Shrey">Attribute Name <a><i class="fa fa-question-circle" title="Attribute Name"></i></a></label>
                                                            <div class="col-sm-4">
                                                                <asp:TextBox ID="txtattributename" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtattributename" runat="server" ValidationGroup="unique" Text="Enter Name of Attribute" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="col-sm-3 control-label" title="Shrey">Attribute Value  <a><i class="fa fa-question-circle" title="value Of Attribute"></i></a></label>
                                                            <div class="col-sm-4">
                                                                <asp:TextBox ID="txtattributevalue" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtattributevalue" runat="server" ValidationGroup="unique" Text="Enter Value Of Attribute" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="col-sm-3 control-label"></label>
                                                            <div class="col-sm-4">
                                                                <asp:Button runat="server"  CssClass="btn btn-primary" ID="btnsaveadd" OnClick="btnsaveadd_Click" Text="Add More"  ValidationGroup="unique" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancle</button>

                                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Save Changes" OnClick="btndynamicsave_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="collapse-voucher2" class="panel-collapse collapse in">
                                <div class="panel-body">
                                    <label class="col-sm-6 control-label" for="input-voucher">Product Attribute Name</label>
                                    <%--<label class="col-sm-6 control-label" for="input-voucher">Listing Status</label>--%>
                                    <label class="col-sm-6 control-label" for="input-voucher">Attribute Value</label>
                                    <%--<label class="col-sm-6 control-label" for="input-voucher">Your Selling Price</label>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

        <script src="js/examples/examples.gallery.js"></script>
    </div>
    <section class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-md-6">

                    <asp:Button runat="server" CssClass="btn btn-default pull-right" Text="View Draft" ID="viewdraft" />
                </div>

                <div class="col-md-6">

                    <asp:Button ID="btnPageSaveAll" runat="server" CssClass="btn btn-default pull-right" Text="Add Product" OnClick="btnPageSaveAll_Click" />
                </div>
            </div>

        </div>
    </section>
    <script src="js/myimg.js"></script>
</asp:Content>

