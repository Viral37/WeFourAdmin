﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style id="cssStyle" type="text/css">
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

    <style>
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
    </style>
    <script>
        function ShowImagePreview1(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {

                    $('#<%=imgi1.ClientID%>').prop('src', e.target.result)
                                        .width(409)
                                        .height(307);
            $('#<%=main1.ClientID%>').prop('src', e.target.result)
            .width(84)
                                        .height(63);

        };
        reader.readAsDataURL(input.files[0]);
    }
}
function ShowImagePreview2(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#<%=imgi2.ClientID%>').prop('src', e.target.result)
                .width(409)
                .height(307);
            $('#<%=main2.ClientID%>').prop('src', e.target.result)
            .width(84)
                                        .height(63);
        };

        reader.readAsDataURL(input.files[0]);
    }
}
function ShowImagePreview3(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#<%=imgi3.ClientID%>').prop('src', e.target.result)
                .width(409)
                .height(307);
            $('#<%=main3.ClientID%>').prop('src', e.target.result)
           .width(84)
                                       .height(63);
        };

        reader.readAsDataURL(input.files[0]);
    }
}
function ShowImagePreview4(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#<%=imgi4.ClientID%>').prop('src', e.target.result)
                .width(409)
                .height(307);
            $('#<%=main4.ClientID%>').prop('src', e.target.result)
.width(84)
                           .height(63);
        };

        reader.readAsDataURL(input.files[0]);
    }
}
function ShowImagePreview5(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#<%=imgi5.ClientID%>').prop('src', e.target.result)
                .width(409)
                .height(307);
            $('#<%=main5.ClientID%>').prop('src', e.target.result)
.width(84)
                           .height(63);
        };

        reader.readAsDataURL(input.files[0]);
    }
}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <div role="main" class="main" style="height: auto">
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

                                            <%--image script--%>

                                            <div class="col-md-12">
                                                <div class="row mt-xlg">
                                                    <div class="col-md-6">
                                                        <div class="thumb-gallery">
                                                            <div class="owl-carousel owl-theme manual thumb-gallery-detail show-nav-hover" id="thumbGalleryDetail">

                                                                <div>
                                                                    <label class="lblfile">Image 1</label>
                                                                    <span class="thumb-info thumb-info-centered-info thumb-info-no-borders">
                                                                        <span class="img-thumbnail">
                                                                            <asp:Image ID="imgi1" ImageUrl="img/projects/project-carousel-4.png" runat="server" CssClass="img-responsive" Style="width: 409px; height: 307px" />
                                                                            <span id="i1"></span>
                                                                            <span class="thumb-info-title">
                                                                                <label for="upload" class="btn">Upload File</label>
                                                                                <asp:FileUpload runat="server" ID="fp1" onchange="ShowImagePreview1(this);" CssClass="ifile" />


                                                                                <br />

                                                                            </span>
                                                                        </span>
                                                                    </span>
                                                                </div>
                                                                <div>
                                                                    <label class="lblfile">Image 2</label>
                                                                    <span class="thumb-info thumb-info-centered-info thumb-info-no-borders">
                                                                        <span class="img-thumbnail">
                                                                            <asp:Image ID="imgi2" ImageUrl="img/projects/project-carousel-4.png" runat="server" CssClass="img-responsive" Style="width: 409px; height: 307px" />
                                                                            <span class="thumb-info-title">
                                                                                <label for="upload" class="btn">Upload File</label>
                                                                                <asp:FileUpload runat="server" ID="fp2" onchange="ShowImagePreview2(this);" CssClass="ifile" />
                                                                                <br />
                                                                            </span>
                                                                        </span>
                                                                    </span>
                                                                </div>
                                                                <div>
                                                                    <label class="lblfile">Image 3</label>
                                                                    <span class="thumb-info thumb-info-centered-info thumb-info-no-borders">
                                                                        <span class="img-thumbnail">
                                                                            <asp:Image ID="imgi3" ImageUrl="img/projects/project-carousel-4.png" runat="server" CssClass="img-responsive" Style="width: 409px; height: 307px" />
                                                                            <span class="thumb-info-title">
                                                                                <label for="upload" class="btn">Upload File</label>
                                                                                <asp:FileUpload runat="server" ID="fp3" onchange="ShowImagePreview3(this);" CssClass="ifile" />


                                                                            </span>
                                                                        </span>
                                                                    </span>
                                                                </div>
                                                                <div>
                                                                    <label class="lblfile">Image 4</label>
                                                                    <span class="thumb-info thumb-info-centered-info thumb-info-no-borders">
                                                                        <span class="img-thumbnail">
                                                                            <asp:Image ID="imgi4" ImageUrl="img/projects/project-carousel-4.png" runat="server" CssClass="img-responsive" Style="width: 409px; height: 307px" />
                                                                            <span class="thumb-info-title">
                                                                                <label for="upload" class="btn">Upload File</label>
                                                                                <asp:FileUpload runat="server" ID="fp4" onchange="ShowImagePreview4(this);" CssClass="ifile" />


                                                                            </span>
                                                                        </span>
                                                                    </span>
                                                                </div>
                                                                <div>
                                                                    <label class="lblfile">Image 5</label>
                                                                    <span class="thumb-info thumb-info-centered-info thumb-info-no-borders">
                                                                        <span class="img-thumbnail">
                                                                            <asp:Image ID="imgi5" ImageUrl="~/Vender/img/DemoImage/demo_1.jpg" runat="server" CssClass="img-responsive" Style="width: 409px; height: 307px" />
                                                                            <span class="thumb-info-title">
                                                                                <label for="upload" class="btn">Upload File</label>
                                                                                <asp:FileUpload runat="server" ID="fp5" onchange="ShowImagePreview5(this);" CssClass="ifile" />


                                                                            </span>
                                                                        </span>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div class="owl-carousel owl-theme manual thumb-gallery-thumbs mt" id="thumbGalleryThumbs">
                                                                <div>
                                                                    <span class="img-thumbnail cur-pointer">
                                                                        <asp:Image ID="main1" alt="Project Image" runat="server" ImageUrl="img/projects/project.jpg" class="img-responsive" Style="width: 84px; height: 63px" />
                                                                    </span>
                                                                </div>
                                                                <div>
                                                                    <span class="img-thumbnail cur-pointer">
                                                                        <asp:Image ID="main2" alt="Project Image" runat="server" ImageUrl="img/projects/project-2.jpg" class="img-responsive" Style="width: 84px; height: 63px" />

                                                                    </span>
                                                                </div>
                                                                <div>
                                                                    <span class="img-thumbnail cur-pointer">
                                                                        <asp:Image ID="main3" alt="Project Image3" runat="server" ImageUrl="i" class="img-responsive" Style="width: 84px; height: 63px" />

                                                                    </span>
                                                                </div>
                                                                <div>
                                                                    <span class="img-thumbnail cur-pointer">
                                                                        <asp:Image ID="main4" alt="Project Image4" runat="server" ImageUrl="img/projects/project-5.jpg" class="img-responsive" Style="width: 84px; height: 63px" />

                                                                    </span>
                                                                </div>
                                                                <div>
                                                                    <span class="img-thumbnail cur-pointer">
                                                                        <asp:Image ID="main5" alt="Project Image5" runat="server" ImageUrl="img/projects/project-6.jpg" class="img-responsive" Style="width: 84px; height: 63px" />

                                                                    </span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 ">
                                                        <div class="thumb-gallery">
                                                            <h1>Front View</h1>
                                                            <h5>Remember!</h5>
                                                            <ul>
                                                                <li>Upload authentic product photos taken in bright lighting.</li>
                                                                <li>Use clear color images with minimum resolution of 1100x1100px.</li>
                                                            </ul>
                                                            <br />
                                                            <asp:RequiredFieldValidator ID="Req_file1" runat="server"
                                                                ForeColor="Red"
                                                                Display="Dynamic" ControlToValidate="fp1">

                                                            </asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="Reg_img1" runat="server"
                                                                ForeColor="red" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"
                                                                ControlToValidate="fp1" ValidationGroup="addprd"></asp:RegularExpressionValidator>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="Reg_img2" runat="server"
                                                                ForeColor="red" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"
                                                                ControlToValidate="fp2" ValidationGroup="addprd"></asp:RegularExpressionValidator>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="Reg_img3" runat="server"
                                                                ForeColor="red" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"
                                                                ControlToValidate="fp3" ValidationGroup="addprd"></asp:RegularExpressionValidator>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="Reg_img4" runat="server"
                                                                ForeColor="red" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"
                                                                ControlToValidate="fp4" ValidationGroup="addprd"></asp:RegularExpressionValidator>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="Reg_img5" runat="server"
                                                                ForeColor="red" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"
                                                                ControlToValidate="fp5" ValidationGroup="addprd"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancle</button>
                                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Save Changes" ID="btn_upload" />

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="collapse-coupon" class="panel-collapse collapse in">
                                    <div class="panel-body">
                                        <div class="image-gallery">
                                            <aside class="">
                                                <a href="#" class="selected thumbnail" style="margin-bottom: 0px;" id="thum1" runat="server">
                                                    <img id="img1" alt="Project Image" src="img/projects/project.jpg" runat="server" class="img-responsive" />
                                                    <%--<div class="thumbnail-image" style="background-image: url(img/projects/1.jpg)"></div>--%>
                                                </a>
                                                <a href="#" class="thumbnail" style="margin-bottom: 0px;" id="thum2" runat="server">
                                                    <img id="img2" alt="Project Image" src="img/projects/project-2.jpg" runat="server" class="img-responsive" />
                                                    <%--<div class="thumbnail-image" style="background-image: url(img/projects/2.jpg)"></div>--%>
                                                </a>
                                                <a href="#" class="thumbnail" style="margin-bottom: 0px;" id="thum3" runat="server">
                                                    <img id="img3" alt="Project Image" src="img/projects/project-4.jpg" runat="server" class="img-responsive" />
                                                    <%--<div class="thumbnail-image" style="background-image: url(img/projects/3.jpg)"></div>--%>
                                                </a>
                                                <a href="#" class="thumbnail" style="margin-bottom: 0px;" id="thum4" runat="server">
                                                    <img id="img4" alt="Project Image" src="img/projects/project-5.jpg" runat="server" class="img-responsive" />
                                                    <%--<div class="thumbnail-image" style="background-image: url(img/projects/4.jpg)"></div>--%>
                                                </a>
                                                <a href="#" class="thumbnail" style="margin-bottom: 0px;" id="thum5" runat="server">
                                                    <img id="img5" alt="Project Image" src="img/projects/project-6.jpg" runat="server" class="img-responsive" />
                                                    <%--<div class="thumbnail-image" style="background-image: url(img/projects/5.jpg)"></div>--%>
                                                </a>
                                            </aside>

                                            <main class="primary" id="mainimg" runat="server"></main>
                                        </div>
                                        <script>
                                            $('.thumbnail').on('click', function () {
                                                var clicked = $(this);
                                                var newSelection = clicked.data('big');
                                                var $img = $('.primary').css("background-image", "url(" + newSelection + ")");
                                                clicked.parent().find('.thumbnail').removeClass('selected');
                                                clicked.addClass('selected');
                                                $('.primary').empty().append($img.hide().fadeIn('slow'));
                                            });
                                        </script>

                                        <style>
                                            .wrapper {
                                                margin: 0 auto;
                                                width: 80%;
                                                text-align: center;
                                            }

                                            .image-gallery {
                                                margin: 0 auto;
                                                display: table;
                                            }

                                            .primary,
                                            .thumbnails {
                                                display: table-cell;
                                            }

                                            .thumbnails {
                                                width: 300px;
                                            }

                                            .primary {
                                                width: 400px;
                                                height: 50px;
                                                background-color: #cccccc;
                                                background-size: cover;
                                                background-position: center center;
                                                background-repeat: no-repeat;
                                            }

                                            .thumbnail:hover .thumbnail-image, .selected .thumbnail-image {
                                                border: 4px solid red;
                                            }

                                            .thumbnail-image {
                                                width: 80px;
                                                height: 80px;
                                                background-size: cover;
                                                background-position: center center;
                                                background-repeat: no-repeat;
                                            }
                                        </style>
                                    </div>
                                </div>
                            </div>
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
                                                                <asp:ListItem>Active</asp:ListItem>
                                                                <asp:ListItem>Inactive</asp:ListItem>
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
                                                                <asp:HiddenField ID="HideType" runat="server" Value='<%# Eval("ToolName") %>' />
                                                                <asp:Label ID="AttType" CssClass="col-sm-4 control-label" runat="server" Text='<%# Eval("MAttributeName") %>' />
                                                                <div class="col-sm-6">
                                                                    <asp:TextBox ID="TextType" runat="server" CssClass="form-control lg"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancle</button>
                                                
                                                <asp:Button ID="btn" runat="server" CssClass="btn btn-primary" Text="Button" OnClick="btnsavedynamic1_Click" />
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



                            <%--kjhkjnb--%>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <label class="panel-title">
                                        <asp:Label runat="server" ID="lblpdcom"><i class="fa fa-check-circle"></i></asp:Label>
                                        Product Description(<asp:Label runat="server" ID="lblopnct"></asp:Label>/<asp:Label runat="server" ID="lblcs"></asp:Label>)<asp:Label runat="server" ID="lblpder"></asp:Label></label>
                                    <label class="panel-title pull-right"><a href="#" data-target="#ProductDescription" data-toggle="modal" id="ProDes">Edit</a></label>
                                </div>
                                <div class="modal fade" id="ProductDescription" tabindex="-1" role="dialog" aria-labelledby="largeModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title" id="ProductDescription1">Product Description</h4>
                                            </div>
                                            <div class="modal-body">
                                                <div id="demo-form-prodes" class="form-horizontal mb-lg">

                                                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Save Changeds" ID="btnsavedynamic1" OnClick="btnsavedynamic1_Click" />
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancle</button>
                                                <button type="button" class="btn btn-default" id="btnsavedynamic" runat="server" onserverclick="btnsavedynamic_ServerClick">Save Changeds</button>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <label class="panel-title ">
                                            <i class="fa fa-check-circle"></i>Additional Description(<asp:Label runat="server" ID="lbladc"></asp:Label>/<asp:Label runat="server" ID="lbladct"></asp:Label>)</label>
                                        <label class="panel-title pull-right"><a href="#" data-target="#ProductDescriptionad" data-toggle="modal" id="AdProDes">Edit</a></label>
                                    </h4>
                                </div>
                                <div class="modal fade " id="ProductDescriptionad" tabindex="-1" role="dialog" aria-labelledby="largeModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title" id="ProductDescriptio">Additional Description</h4>
                                            </div>
                                            <div class="modal-body">
                                                <div id="demo-form-prodess" class="form-horizontal mb-lg">
                                                    <asp:Panel runat="server" ID="panadi"></asp:Panel>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancle</button>
                                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Save Changes" ID="btnassa" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <asp:HyperLink class="accordion-toggle" data-toggle="collapse" runat="server" ID="linkerro" data-parent="#accordion5" href="#collapse5Two">Error Know More
                                        </asp:HyperLink>
                                    </h4>
                                </div>
                                <div id="collapse5Two" class="accordion-body collapse">
                                    <div class="panel-body">
                                        <p>
                                            <asp:Label runat="server" ID="Nukl"></asp:Label><br />
                                            <asp:Label runat="server" ID="kil"></asp:Label>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <section class="page-header" style="background-color: forestgreen">
                <div class="container">
                    <div class="col-md-11">
                        <div class="col-md-8">
                            <%--<asp:CheckBox ID="chk" Style="color: white" runat="server" Text=" Brand :" />--%>
                            <label class="pull-sm-left" style="color: white">Brand :-</label>
                            <asp:Label runat="server" ID="lblbrand" CssClass="pull-sm-left" Style="color: white"></asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnPageSave" runat="server" CssClass="btn btn-default pull-right" Text="Add Product" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button runat="server" CssClass="btn btn-default pull-right" Text="View Draft" ID="viewdraft" />
                        </div>

                    </div>
                </div>
            </section>
        </div>
    </div>
    <!-- Examples -->
    <script src="js/examples/examples.gallery.js"></script>
    <script src="js/myimg.js"></script>

</asp:Content>

