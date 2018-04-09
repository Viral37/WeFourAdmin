<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="Seller_Profile.aspx.cs" Inherits="test_Seller_Profile" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        @media screen and (max-width: 699px) and (min-width: 250px) {
            .veer {
                visibility: hidden;
                height: 0px;
            }
        }

        .body {
            max-height: 1050px;
        }
    </style>
    <script type="text/javascript">
          $(function () {

              $('#uploadFile').click(function (e) {
                  $('#fileUploadField').click();
                  e.preventDefault();
              });
              $('#uploadFile1').click(function (e) {
                  $('#fileUploadField1').click();
                  e.preventDefault();
              });


          });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="background: #F5F5F5">
        <div runat="server" id="mainpanel">
            <div class="row">
                <div class="col-sm-12 center">
                    <h3 class="heading mt-xl" style="color: forestgreen">Manage <strong>Profile</strong></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-11">
                    <ul class="history">
                        <asp:LinkButton runat="server" ID="lblaccount" OnClick="lblaccount_Click">
                            <li class="appear-animation" data-appear-animation="fadeInUp">
                                <div class="thumb">
                                    <img src="img/user_img.png" alt="" />
                                </div>
                                <div class="featured-box">
                                    <div class="box-content" style="border-top-color: forestgreen">
                                        <div class="col-sm-10">
                                            <h4 class="heading" style="color: forestgreen"><strong>Account</strong></h4>
                                            <br />
                                            <p>View Your Display information, Pickup address, login detail and Primary details</p>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button runat="server" CssClass="btn btn-borders btn-success btn-lg mr-xs mb-sm veer" Text="View" ID="view_account" OnClick="lblaccount_Click" />
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </asp:LinkButton>

                        <%--<asp:LinkButton runat="server" ID="lbtnacmanager" OnClick="lbtnacmanager_Click">
                            <li class="appear-animation" data-appear-animation="fadeInUp">
                                <div class="thumb">
                                    <img src="img/user_img.png" alt="" />
                                </div>
                                <div class="featured-box">
                                    <div class="box-content" style="border-top-color: forestgreen">
                                        <div class="col-sm-10">
                                            <h4 class="heading" style="color: forestgreen"><strong>Account Manager</strong></h4>
                                            <br />
                                            <p>View your accounrt manager details</p>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button runat="server" CssClass="btn btn-borders btn-success btn-lg mr-xs mb-sm veer" Text="View" ID="view_accmanger" OnClick="lbtnacmanager_Click" />
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </asp:LinkButton>--%>

                        <asp:LinkButton runat="server" ID="lblbussiness" OnClick="lblbussiness_Click">
                            <li class="appear-animation" data-appear-animation="fadeInUp">
                                <div class="thumb">
                                    <img src="img/user_img.png" alt="" />
                                </div>
                                <div class="featured-box">
                                    <div class="box-content" style="border-top-color: forestgreen">
                                        <div class="col-sm-10">
                                            <h4 class="heading" style="color: forestgreen"><strong>Bussiness Details</strong></h4>
                                            <br />
                                            <p>View your bussiness details, bank details and KYC documents</p>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button runat="server" CssClass="btn btn-borders btn-success btn-lg mr-xs mb-sm veer" Text="View" ID="view_bussiness_detail" OnClick="lblbussiness_Click" />
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </asp:LinkButton>

                        <asp:LinkButton runat="server" ID="lblsetting" OnClick="lblsetting_Click">
                            <li class="appear-animation" data-appear-animation="fadeInUp">
                                <div class="thumb">
                                    <img src="img/user_img.png" alt="" />
                                </div>
                                <div class="featured-box">
                                    <div class="box-content" style="border-top-color: forestgreen">
                                        <div class="col-sm-10">
                                            <h4 class="heading" style="color: forestgreen"><strong>Setting</strong></h4>
                                            <br />
                                            <p>Manager your logistics and FBF settings </p>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button runat="server" CssClass="btn btn-borders btn-success btn-lg mr-xs mb-sm veer" Text="View" ID="view_setting" OnClick="lblsetting_Click" />
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </asp:LinkButton>

                        <%--<asp:LinkButton runat="server" ID="lblcal" OnClick="lblcal_Click">
                            <li class="appear-animation" data-appear-animation="fadeInUp">
                                <div class="thumb">
                                    <img src="img/user_img.png" alt="" />
                                </div>
                                <div class="featured-box">
                                    <div class="box-content" style="border-top-color: forestgreen">
                                        <div class="col-sm-10">
                                            <h4 class="heading" style="color: forestgreen"><strong>Calendar</strong></h4>
                                            <br />
                                            <p>View Your Working Hours,holidays List and vacation plan. </p>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button runat="server" CssClass="btn btn-borders btn-success btn-lg mr-xs mb-sm veer" Text="View" ID="view_calendar" OnClick="lblcal_Click" />
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </asp:LinkButton>--%>

                        <asp:LinkButton runat="server" ID="lblmanage" OnClick="lblmanage_Click">
                            <li class="appear-animation" data-appear-animation="fadeInUp">
                                <div class="thumb">
                                    <img src="img/user_img.png" alt="" />
                                </div>
                                <div class="featured-box">
                                    <div class="box-content" style="border-top-color: forestgreen">
                                        <div class="col-sm-10">
                                            <h4 class="heading" style="color: forestgreen"><strong>Manage Profile</strong></h4>
                                            <br />
                                            <p>Manage your Employee,add,edit,delete roles and permissions to access dashboard. </p>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button runat="server" CssClass="btn btn-borders btn-success btn-lg mr-xs mb-sm veer" Text="View" ID="view_manage_profile" OnClick="lblmanage_Click" />
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </asp:LinkButton>
                    </ul>
                </div>
            </div>
        </div>
        <%--main panel end--%>

        <div id="account" runat="server" visible="false">
            <section class="page-header" style="background-color: forestgreen">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <ul class="breadcrumb">
                                <li><a href="Seller_Profile.aspx" style="color: white">Manage Profile</a></li>
                                <li class="active" style="color: white;">Account</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </section>

            <div class="container-fluid">
                <div class="col-md-3" style="border: solid; height: 350px; margin: 30px; background-color: white; border-radius: 5px">
                    <div class="col-sm-12">
                        <div class="col-sm-12" style="margin-top: 5px;">
                            <dl>
                                <p style="margin: 5px; color: forestgreen">Vender Login Details </p>
                                <hr />
                            </dl>
                            <dl>
                                <dt>Vender Name</dt>
                                <dd>
                                    <asp:Label runat="server" ID="vname"></asp:Label></dd>
                                <dt>Contact Number.</dt>
                                <dd>
                                    <asp:Label runat="server" ID="vmno"></asp:Label></dd>
                                <dt>Email Address.</dt>
                                <dd>
                                    <asp:Label runat="server" ID="vemail"></asp:Label></dd>
                                <dt>Password.</dt>
                                <dd>
                                    <asp:Label runat="server" ID="vpass" Text="******"></asp:Label></dd>
                            </dl>
                        </div>
                        <div class="col-sm-5" style="margin-top: 5px;">
                            <dl>
                                <dt><%--<a href="" style="text-decoration-nline: none;" data-toggle="modal" data-target="#formModal">Change Password</a>--%></dt>

                                <dd>
                                    <asp:Label runat="server" ID="Label5"></asp:Label></dd>
                            </dl>

                        </div>
                    </div>
                </div>
                <div class="col-md-3" style="border: solid; height: 350px; margin: 30px; background-color: white; border-radius: 5px">
                    <div class="col-sm-12">
                        <dl>
                            <p style="margin: 5px; color: forestgreen">Vender Address </p>
                            <hr />
                        </dl>
                        <dl>
                            <dt>Address Line 1</dt>
                            <dd>
                                <asp:Label runat="server" ID="lbladdress"></asp:Label></dd>
                            <dt>Your pickup city.</dt>
                            <dd>
                                <asp:Label runat="server" ID="lblcity"></asp:Label></dd>
                            <dt>State.</dt>
                            <dd>
                                <asp:Label runat="server" ID="lblstate"></asp:Label></dd>
                            <dt>Pincode</dt>
                            <dd>
                                <asp:Label runat="server" ID="lblpin" Text="******"></asp:Label></dd>
                        </dl>
                    </div>
                </div>
                <div class="col-md-3" style="border: solid; height: 350px; margin: 30px; background-color: white; border-radius: 5px">
                    <div class="col-sm-12">
                        <div class="col-sm-12" style="margin-top: 5px">
                            <dl>
                                <p style="margin: 5px; color: forestgreen">Display information</p>
                                <hr />
                            </dl>
                            <dl>
                                <dt>Display Name</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lbldname"></asp:Label></dd>
                                <dt>Business Description.</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblddesc"></asp:Label></dd>
                            </dl>
                            <%--<div class="modal fade" id="formModalinfo" tabindex="-1" role="dialog" aria-labelledby="formModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="formModalLabelinfo">Store Details</h4>
                                        </div>
                                        <div class="modal-body">
                                            <form id="demo-form1" class="form-horizontal mb-lg" novalidate="novalidate">
                                                <div class="form-group mt-lg">
                                                    <label class="col-sm-4 control-label">Display Name</label>
                                                    <div class="col-sm-8">
                                                        <asp:TextBox runat="server" ID="txtsname" CssClass="form-control" placeholder="Type your Store name..."></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-4 control-label">Bussiness Description</label>
                                                    <div class="col-sm-8">
                                                        <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" ID="txtbdes"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                            <asp:Button runat="server" CssClass="btn btn-primary" Text="Save Changes" ID="btnsaveinfo" />
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                        <%--                        <div class="col-sm-3" style="margin-top: 5px;">
                            <dl>
                                <dt><a href="" style="text-decoration-line: none;" data-toggle="modal" data-target="#formModalinfo">Edit</a></dt>
                            </dl>

                        </div>--%>
                    </div>
                </div>
            </div>
        </div>


        <div id="bussinesdetails" runat="server" visible="false">
            <section class="page-header" style="background-color: forestgreen">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <ul class="breadcrumb">
                                <li><a href="Seller_Profile.aspx" style="color: white">Manage Profile</a></li>
                                <li class="active" style="color: white;">Business Details</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </section>
            <div class="container-fluid">
                <div class="col-sm-8" style="border: solid; height: 350px; margin-left: 100px; margin-top: 10px; background-color: white; border-radius: 5px">
                    <div class="col-sm-12">
                        <div class="col-sm-5" style="margin-top: 5px">
                            <dl>
                                <h2 style="margin: 5px; color: forestgreen">Business </h2>
                            </dl>
                            <dl>
                                <dt>Business Name</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblbname" Text="Not Available"></asp:Label></dd>
                                <dt>Business Description</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lbldes" Text="Not Available"></asp:Label></dd>
                                <dt>Registered business address</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblradd" Text="Not Available"></asp:Label></dd>
                                <dt>City</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblrcity" Text="Not Available"></asp:Label></dd>
                            </dl>
                        </div>
                        <div class="col-sm-5" style="margin-top: 5px">
                            <dl>
                                <h2 style="margin: 5px; color: forestgreen">Details:-</h2>
                            </dl>
                            <dl>
                                <dt>TAN</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lbltanno" Text="Not Available"></asp:Label></dd>
                                <dt>GSTIN / Provisional ID Number*</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblgstno" Text="Not Available"></asp:Label></dd>
                                <dt>Registered CIN Number</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblcinno" Text="Not Available"></asp:Label></dd>
                                <dt>PAN</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblpannum" Text="Not Available"></asp:Label></dd>
                            </dl>
                        </div>
                    </div>
                </div>
                <div class="col-sm-8" style="border: solid; height: 350px; margin-left: 100px; margin-top: 20px; background-color: white; border-radius: 5px">

                    <div class="col-sm-12">
                        <div class="col-sm-5" style="margin-top: 5px">
                            <dl>
                                <h2 style="margin: 5px; color: forestgreen">Bank</h2>
                            </dl>
                            <dl>
                                <dt>Account Holder Name</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblachname" Text="Not Available"></asp:Label></dd>
                                <dt>Account Number</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblacno" Text="Not Available"></asp:Label></dd>
                                <dt>Bank Name</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblbaname" Text="Not Available"></asp:Label></dd>
                                <dt>Account Type</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblactype" Text="Not Available"></asp:Label></dd>
                            </dl>
                        </div>
                        <div class="col-sm-5" style="margin-top: 5px">
                            <dl>
                                <h2 style="margin: 5px; color: forestgreen">Details</h2>
                            </dl>
                            <dl>
                                <dt>IFSC Code</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblifc" Text="Not Available"></asp:Label></dd>
                                <dt>Bank Address</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblbadd" Text="Not Available"></asp:Label></dd>
                                <dt>City</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblbcity" Text="Not Available"></asp:Label></dd>
                                <dt>State</dt>
                                <dd>
                                    <asp:Label runat="server" ID="lblbstate" Text="Not Available"></asp:Label></dd>

                            </dl>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div id="setting" runat="server" visible="false">
            <section class="page-header" style="background-color: forestgreen">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <ul class="breadcrumb">
                                <li><a href="Seller_Profile.aspx" style="color: white">Manage Profile</a></li>
                                <li class="active" style="color: white;">Setting</li>
                            </ul>
                        </div>
                    </div>
                    <%--<div class="row">
                    <div class="col-md-12">
                        <h1>Browse By Category</h1>
                    </div>
                </div>--%>
                </div>
            </section>

            <div class="container">
                <div class="col-sm-5" style="border: thick; height: 300px; margin: 20px; margin-left: 60px; background-color: white; border-radius: 5px">
                    <div class="col-sm-12">
                        <div class="col-sm-10" style="margin-top: 5px">
                            <dl>
                                <dt style="margin: 5px;">Logistic settings :-</dt>
                            </dl>
                            <dl>
                                <dd>You can now save your credentials and we will automatically generate the logistics form for you</dd>
                                <%--<dt>Vender Name</dt>
                                <dd>
                                    <asp:Label runat="server" ID="Label1"></asp:Label></dd>
                                <dt>Vender Mobil Number.</dt>
                                <dd>
                                    <asp:Label runat="server" ID="Label2"></asp:Label></dd>
                                <dt>Vender Email Address.</dt>
                                <dd>
                                    <asp:Label runat="server" ID="Label3"></asp:Label></dd>
                                <dt>Password.</dt>
                                <dd>
                                    <asp:Label runat="server" ID="Label4" Text="******"></asp:Label></dd>--%>
                            </dl>
                            <div class="modal fade" id="formModal3" tabindex="-1" role="dialog" aria-labelledby="formModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="formModal3">Logistic Settings</h4>
                                        </div>
                                        <div class="modal-body">
                                            <form id="demo-form" class="form-horizontal mb-lg" novalidate="novalidate">
                                                <div class="form-group mt-lg">
                                                    <label class="col-sm-3 control-label">State</label>
                                                    <div class="col-sm-9">
                                                        <input type="text" name="name" class="form-control" placeholder="Type account holder name..." required />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-3 control-label">Username</label>
                                                    <div class="col-sm-9">
                                                        <input type="email" name="email" class="form-control" placeholder="Type username..." required />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-3 control-label">Password</label>
                                                    <div class="col-sm-9">
                                                        <input type="url" name="url" class="form-control" placeholder="Type Your Password..." required />
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label class="col-sm-3 control-label">IFSC Code</label>
                                                    <div class="col-sm-9">
                                                        <input type="url" name="url" class="form-control" placeholder="Type your IFSC code..." required />
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                            <button type="button" class="btn btn-primary">Save Changes</button>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-sm-2" style="margin-top: 5px;">
                            <dl>
                                <dt><a href="" style="text-decoration-line: none;" data-toggle="modal" data-target="#formModal3">ADD</a></dt>
                            </dl>

                        </div>
                    </div>
                </div>

            </div>

        </div>


        <div id="manageuser" runat="server" visible="false">
            <section class="page-header" style="background-color: forestgreen">
                <div class="container">
                    <div class="row">
                        <div class="col-md-11">
                            <ul class="breadcrumb">
                                <li><a href="Seller_Profile.aspx" style="color: white">Manage Profile</a></li>
                                <li class="active" style="color: white;">Manage user</li>
                            </ul>
                        </div>

                        <div class="col-md-1">
                            <button type="button" class="mb-xs mt-xs mr-xs btn btn-primary" style="text-decoration-line: none;" data-toggle="modal" data-target="#formModalrole"><i class="fa fa-plus"></i>Add User</button>
                            <div class="modal fade" id="formModalrole" tabindex="-1" role="dialog" aria-labelledby="formModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="formModalrole">Add New User</h4>
                                        </div>
                                        <div class="modal-body">
                                            <form id="demo-form" class="form-horizontal mb-lg" novalidate="novalidate">

                                                <div class="form-group">
                                                    <label class="col-sm-3 control-label">Role</label>
                                                    <div class="col-sm-9">
                                                        <select class="form-control" data-plugin-multiselect data-plugin-options='{ "maxHeight": 200 }' id="ms_example1">
                                                            <option selected>Select Role</option>
                                                            <option>Admin</option>
                                                            <option>Operations Manager</option>
                                                            <option>Catelog Manager</option>
                                                            <option>Product Listing Ads Manager</option>
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-3 control-label">Email-id</label>
                                                    <div class="col-sm-9">
                                                        <input type="email" name="email" class="form-control" placeholder="Type your Email..." required />
                                                    </div>
                                                </div>

                                            </form>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                            <button type="button" class="btn btn-primary">Save Changes</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </section>

            <div class="row center" style="margin-top: 20%; height: 200px">
                <span class="label label-info label-lg">Assign and Manage Roles and Permissions to a User</span><br />
                <br />
                <span class="label label-info label-lg">Add a user, Select Role and Grant Permissions to provide access</span>
            </div>
        </div>
    </div>
</asp:Content>

