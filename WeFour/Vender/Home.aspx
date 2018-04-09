<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Vender_Home" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function HideLabel() {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=msg.ClientID %>".style.display = "none";
            }, seconds * 1000);
        };
    </script>
    <script type="text/javascript">
        $(function () {

            $('#uploadFilegst').click(function (e) {
                $('#filegst').click();
                e.preventDefault();
            });
            $('#uploadFiletan').click(function (e) {
                $('#filetan').click();
                e.preventDefault();
            });

            $('#uploadFilecin').click(function (e) {
                $('#filecin').click();
                e.preventDefault();
            });
            $('#uploadFilebproof').click(function (e) {
                $('#filebproof').click();
                e.preventDefault();
            });
            $('#uploadFilesign').click(function (e) {
                $('#filesign').click();
                e.preventDefault();
            });


        });

    </script>
    <style>
        .lbluser {
            color: yellowgreen;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div role="main" class="main" style="background: #F5F5F5; scrollbar-3dlight-color: aqua;">
        <div class="row" style="background: #556B2F">
            <div class="col-sm-12">
                <div class="col-sm-5">
                    <h3 style="margin: 5px; color: white">Welcome <b>
                        <asp:Label runat="server" ID="lbluser" CssClass="lbluser"></asp:Label>
                    <h5 style="margin: 5px; color: white">Complete your profile.</h5>
                </div>
                <div class="col-sm-4">
                    <h2 runat="server" style="margin: 5px; color: white" id="msg"></h2>
                </div>
                <div class="col-sm-3">

                    <div class="progress" style="margin: 20px;">
                        <div class="progress-bar progress-bar-success progress-bar-striped active" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" style="width: 10%" id="pp" runat="server">
                        </div>
                        <br />
                        <span style="color: white">Your Process is
                            <asp:Label runat="server" ID="lblprocess" Text="10%"> </asp:Label>
                            Complated.</span>
                    </div>
                </div>

            </div>

            <div class="featured-boxes" runat="server" id="businfo">
                <div class="row">
                    <div class="col-md-3 col-sm-6">
                        <div class="featured-box featured-box-primary featured-box-effect-1">
                            <div class="box-content">
                                <i class="icon-featured fa fa-user"></i>
                                <h4 class="text-uppercase">Business Details</h4>
                                <p>You need to provide your business information</p>
                                <p><a href="" style="text-decoration-line: none;" data-toggle="modal" data-target="#formModal1" id="addd" runat="server">Add Detail&nbsp<i class="fa fa-angle-right"></i></a></p>
                                <p><a href="" style="text-decoration-line: none;" data-toggle="modal" data-target="#formModal1" id="view" runat="server" visible="false">View Detail&nbsp<i class="fa fa-angle-right"></i></a></p>

                            </div>
                        </div>
                        <div class="modal fade" id="formModal1" tabindex="-1" role="dialog" aria-labelledby="formModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title" id="formModal12">Business Details</h4>
                                    </div>
                                    <div class="modal-body">

                                        <div id="demo-form-bus" class="form-horizontal mb-lg">
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Bussiness Name</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox CssClass="form-control" runat="server" placeholder="Type your Register Bussiness name..." ID="txtbname"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqbname" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl" ControlToValidate="txtbname"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Register Address</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox CssClass="form-control" runat="server" placeholder="Type your Register Bussiness address..." ID="txtregadd"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqaddress" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl" ControlToValidate="txtregadd"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <label class="col-sm-3 control-label">City</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox CssClass="form-control" runat="server" placeholder="Type your Bussiness City..." ID="txtbcity" MaxLength="30"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqcity" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl" ControlToValidate="txtbcity"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <label class="col-sm-3 control-label">State</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox CssClass="form-control" runat="server" placeholder="Type your Bussiness State..." ID="txtbstate" MaxLength="30"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqstate" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl" ControlToValidate="txtbstate"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Pincode</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox CssClass="form-control" runat="server" placeholder="Type your City Pincode..." ID="txtbpcode" MaxLength="6"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqpin" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl" ControlToValidate="txtbpcode"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="Reg_pn" runat="server"
                                                        ControlToValidate="txtbpcode" Display="Dynamic" ForeColor="Red"
                                                        ErrorMessage="InValid Pincode"
                                                        ValidationExpression="\d{6}" ValidationGroup="bdtl">

                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Country</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox CssClass="form-control" runat="server" placeholder="Type your Country..." ID="txtbcontry"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqcontry" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl" ControlToValidate="txtbcontry"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Pan Holder Name</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox CssClass="form-control" runat="server" MaxLength="30" placeholder="Type your Pan Card Holder Name..." ID="txtpanname"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqpholer" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl" ControlToValidate="txtpanname"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Pan Number</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox CssClass="form-control" MaxLength="10" runat="server" placeholder="Type your Pan Number..." ID="txtpno"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqbpno" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl" ControlToValidate="txtpno"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="Reg_pannumber" runat="server"
                                                        ControlToValidate="txtpno" Display="Dynamic" ForeColor="Red"
                                                        ErrorMessage="InValid PAN Number"
                                                        ValidationExpression="[A-Z]{5}\d{4}[A-Z]{1}" ValidationGroup="bdtl">

                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">GSTIN Number</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox CssClass="form-control" runat="server" MaxLength="15" placeholder="15-character alphanumeric(Eg.22AxxxA0000A1ZM)" ID="txtgstno"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqgstno" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl" ControlToValidate="txtgstno"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="Reg_gstin"
                                                        runat="server"
                                                        ControlToValidate="txtgstno"
                                                        Display="Dynamic"
                                                        ForeColor="Red"
                                                        ErrorMessage="InValid GST Number"
                                                        ValidationExpression="^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[0-9]{1}[Z]{1}[0-9]{1}$"
                                                        ValidationGroup="bdtl">
                                                    </asp:RegularExpressionValidator>
                                                    <asp:FileUpload ID="fu_gstin" runat="server" CssClass="center" />
                                                    <br />
                                                    <%-- <asp:Image ID="img_gstin" runat="server" Visible="false" />--%>
                                                    <asp:Label ID="lbl_gstin" runat="server" Text="Label"></asp:Label>
                                                    <asp:RequiredFieldValidator ID="Req_gstin" runat="server"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl"
                                                        ControlToValidate="fu_gstin" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="Reg_format_gstin"
                                                        runat="server"
                                                        ControlToValidate="fu_gstin"
                                                        Display="Dynamic"
                                                        ForeColor="Red"
                                                        ErrorMessage="Only .jpeg, .jpg,. png, .pdf Formats allowed!"
                                                        ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.pdf)$"
                                                        ValidationGroup="bdtl">
                                                    </asp:RegularExpressionValidator>


                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">TAN Number</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox CssClass="form-control" runat="server" MaxLength="10" placeholder="Type your TAN Number..." ID="txttanno"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtan" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl" ControlToValidate="txttanno"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="Reg_tan"
                                                        runat="server"
                                                        ControlToValidate="txttanno"
                                                        Display="Dynamic"
                                                        ForeColor="Red"
                                                        ErrorMessage="InValid TAN Number"
                                                        ValidationExpression="[A-Za-z]{4}[0-9]{5}[A-Za-z]{1}"
                                                        ValidationGroup="bdtl">
                                                    </asp:RegularExpressionValidator>
                                                    <asp:FileUpload ID="fu_tan" runat="server" CssClass="center" />
                                                    <asp:Label ID="lbl_tan" runat="server" Text="Label"></asp:Label>

                                                    <asp:RequiredFieldValidator ID="Req_tan" runat="server"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl"
                                                        ControlToValidate="fu_tan" Display="Dynamic"></asp:RequiredFieldValidator>

                                                    <asp:RegularExpressionValidator ID="Reg_format_tan"
                                                        runat="server"
                                                        ControlToValidate="fu_tan"
                                                        Display="Dynamic"
                                                        ForeColor="Red"
                                                        ErrorMessage="Only .jpeg, .jpg,. png, .pdf Formats allowed!"
                                                        ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.pdf)$"
                                                        ValidationGroup="bdtl">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">CIN Number</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" CssClass="form-control" MaxLength="21" placeholder="Type your CIN Number..." ID="txtcino"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqcinno" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl" ControlToValidate="txtcino"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="Reg_cin"
                                                        runat="server"
                                                        ControlToValidate="txtcino"
                                                        Display="Dynamic"
                                                        ForeColor="Red"
                                                        ErrorMessage="InValid CIN Number"
                                                        ValidationExpression="[A-Z]{1}[0-9]{5}[A-Z]{2}[0-9]{4}[A-Z]{3}[0-9]{6}"
                                                        ValidationGroup="bdtl">
                                                    </asp:RegularExpressionValidator>
                                                    <asp:FileUpload ID="fu_cin" runat="server" CssClass="center" />
                                                    <asp:Label ID="lbl_cin" runat="server" Text="Label"></asp:Label>

                                                    <asp:RequiredFieldValidator ID="Requ_cin" runat="server"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl"
                                                        ControlToValidate="fu_cin" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="Reg_format_cin"
                                                        runat="server"
                                                        ControlToValidate="fu_cin"
                                                        Display="Dynamic"
                                                        ForeColor="Red"
                                                        ErrorMessage="Only .jpeg, .jpg,. png, .pdf Formats allowed!"
                                                        ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.pdf)$"
                                                        ValidationGroup="bdtl">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">

                                                <label class="col-sm-3 control-label">Bussiness Establish Date</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Type your Business Establish Date" ID="txt_date"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="Req_date" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl" ControlToValidate="txt_date"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:FileUpload ID="fu_bus_proof" runat="server" CssClass="center" />
                                                    <asp:Label ID="lbl_buss_proof" runat="server" Text="Label"></asp:Label>

                                                    <asp:RequiredFieldValidator ID="Req_bp" runat="server"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl"
                                                        ControlToValidate="fu_bus_proof" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="Reg_format_buss"
                                                        runat="server"
                                                        ControlToValidate="fu_cin"
                                                        Display="Dynamic"
                                                        ForeColor="Red"
                                                        ErrorMessage="Only .jpeg, .jpg,. png, .pdf Formats allowed!"
                                                        ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.pdf)$"
                                                        ValidationGroup="bdtl">
                                                    </asp:RegularExpressionValidator>
                                                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                                                    <asp:CalendarExtender ID="Calendar_date" runat="server" TargetControlID="txt_Date" Format="dd/MM/yyyy"></asp:CalendarExtender>

                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Signature</label>
                                                <div class="col-sm-9">
                                                    <asp:FileUpload ID="fu_sign" runat="server" CssClass="center" />

                                                    <asp:Label ID="lbl_sign" runat="server" Text="Label"></asp:Label>
                                                    <asp:RequiredFieldValidator ID="Req_sign" runat="server"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="bdtl"
                                                        ControlToValidate="fu_sign" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="Reg_format_sign"
                                                        runat="server"
                                                        ControlToValidate="fu_sign"
                                                        Display="Dynamic"
                                                        ForeColor="Red"
                                                        ErrorMessage="Only .jpeg, .jpg,. png, .pdf Formats allowed!"
                                                        ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.pdf)$"
                                                        ValidationGroup="bdtl">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Save Changes" type="button" ID="btnbsinsert" OnClick="btnbsinsert_Click" ValidationGroup="bdtl" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--for view--%>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <div class="featured-box featured-box-secondary featured-box-effect-1">
                            <div class="box-content">
                                <i class="icon-featured fa fa-book"></i>
                                <h4 class="text-uppercase">Bank Details</h4>
                                <p>We need bank account details to verify bank account.</p>
                                <p><a href="" class="lnk-secondary learn-more" data-toggle="modal" data-target="#formModalbank" id="bankadd" runat="server">Add Details&nbsp <i class="fa fa-angle-right"></i></a></p>
                                <p><a href="" class="lnk-secondary learn-more" data-toggle="modal" data-target="#formModalbank" id="bankview" runat="server" visible="false">View Details&nbsp <i class="fa fa-angle-right"></i></a></p>
                            </div>
                        </div>
                        <div class="modal fade" id="formModalbank" tabindex="-1" role="dialog" aria-labelledby="formModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title" id="formModalbank1">Bank Details</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div id="demo-form-bank" class="form-horizontal mb-lg">

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Bank Name</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtbank_name" runat="server" CssClass="form-control" placeholder="Type Your Bank Name" MaxLength="100"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqbankname" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtbank_name" Display="Dynamic" ValidationGroup="reqbank"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">IFSC Code</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" class="form-control" placeholder="Type your IFSC code..." ID="txtbifcode" MaxLength="12"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqifc" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtbifcode" ValidationGroup="reqbank"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator
                                                        ID="regexvifcno"
                                                        ControlToValidate="txtbifcode"
                                                        ValidationExpression="[A-Z]{4}[0][0-9]{6}$"
                                                        Display="Dynamic"
                                                        EnableClientScript="true"
                                                        ErrorMessage="Please Enter Valid IFSC Code"
                                                        runat="server" ValidationGroup="reqbank"
                                                        ForeColor="Red" />
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Account number</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Type account number..." ID="txtbacno"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqbacno" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtbacno" ValidationGroup="reqbank"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="regbacno" ControlToValidate="txtbacno" Display="Dynamic" ValidationExpression="\d+" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" ValidationGroup="reqbank" ForeColor="Red" />
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Account Type</label>
                                                <div class="col-sm-9">

                                                    <asp:DropDownList ID="ddactype" CssClass="form-control" runat="server">
                                                        <asp:ListItem>Please Choose Account type</asp:ListItem>
                                                        <asp:ListItem>Savings Account</asp:ListItem>
                                                        <asp:ListItem>Current Account</asp:ListItem>
                                                        <asp:ListItem>Business Account</asp:ListItem>
                                                        <asp:ListItem>Personal Account</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvcandidate" runat="server" ControlToValidate="ddactype"
                                                        Display="Dynamic" ErrorMessage="0" InitialValue="Please Choose Account type" ValidationGroup="reqbank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Account holder name</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Type account holder name..." ID="txtbholname"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqaholname" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbholname" ValidationGroup="reqbank"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Bank Address</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Type bank address..." ID="txtbadd"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqbadd" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbadd" ValidationGroup="reqbank"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">City</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Type city..." ID="txtbacity"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqbcity" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtbacity" ValidationGroup="reqbank"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="regcity" runat="server" Display="Dynamic" ErrorMessage="only characters allowed" ForeColor="Red" ControlToValidate="txtbacity" ValidationExpression="^[A-Za-z]*$" ValidationGroup="reqbank"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">State</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Type state..." ID="txtbastate"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqbstate" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtbastate" ValidationGroup="reqbank"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="regstate" runat="server" Display="Dynamic" ErrorMessage="only characters allowed" ForeColor="Red" ControlToValidate="txtbastate" ValidationExpression="^[A-Za-z]*$" ValidationGroup="reqbank"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Pincode</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Type pincode..." ID="txtbpin"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqbpin" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbpin" ValidationGroup="reqbank"></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="rngpin" runat="server" ErrorMessage="Only 6 Number allowed." Display="Dynamic" MaximumValue="6" ControlToValidate="txtbpin" ForeColor="Red" ValidationGroup="reqbank"></asp:RangeValidator>
                                                    <asp:RegularExpressionValidator
                                                        ID="regpin" ControlToValidate="txtbpin"
                                                        ValidationExpression="\d{6}"
                                                        Display="Static"
                                                        EnableClientScript="true"
                                                        ErrorMessage="Please enter numbers only"
                                                        runat="server" ValidationGroup="reqbank"
                                                        ForeColor="Red" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Country</label>
                                                <div class="col-sm-9">
                                                    <asp:DropDownList ID="ddcountry" CssClass="form-control" runat="server">
                                                        <asp:ListItem>Please Choose Country</asp:ListItem>
                                                        <asp:ListItem>Afghanistan</asp:ListItem>
                                                        <asp:ListItem>Bangladesh</asp:ListItem>
                                                        <asp:ListItem>Bhutan</asp:ListItem>
                                                        <asp:ListItem>China</asp:ListItem>
                                                        <asp:ListItem>Hong Kong</asp:ListItem>
                                                        <asp:ListItem>India</asp:ListItem>
                                                        <asp:ListItem>Iraq</asp:ListItem>
                                                        <asp:ListItem>Japan</asp:ListItem>
                                                        <asp:ListItem>Malaysia</asp:ListItem>
                                                        <asp:ListItem>Nepal</asp:ListItem>
                                                        <asp:ListItem>Pakistan</asp:ListItem>
                                                        <asp:ListItem>Saudi Arabia</asp:ListItem>
                                                        <asp:ListItem>Singapore</asp:ListItem>
                                                        <asp:ListItem>Sri Lanka</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="regcountry" runat="server"
                                                        ControlToValidate="ddcountry" ErrorMessage="Please Choose Country"
                                                        InitialValue="Please Choose Country" ValidationGroup="reqbank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Save Changes" ID="btn_bank" ValidationGroup="reqbank" OnClick="btn_bank_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <div class="featured-box featured-box-tertiary featured-box-effect-1">
                            <div class="box-content">
                                <i class="icon-featured fa fa-trophy"></i>
                                <h4 class="text-uppercase">Store Details</h4>
                                <p>We need Your store details and documents for verify.</p>
                                <p><a href="" style="text-decoration-line: none;" class="lnk-tertiary learn-more" data-toggle="modal" data-target="#formModalstoreadd" id="storeadd" runat="server">Add Store Details&nbsp <i class="fa fa-angle-right"></i></a></p>
                                <p><a href="" style="text-decoration-line: none;" class="lnk-tertiary learn-more" data-toggle="modal" data-target="#formModalstoreadd" id="storeview" visible="false" runat="server">View Store Details&nbsp <i class="fa fa-angle-right"></i></a></p>
                            </div>
                        </div>
                        <div class="modal fade" id="formModalstoreadd" tabindex="-1" role="dialog" aria-labelledby="formModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title" id="formModalLabelinfo">Store Details</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div id="demo-form1" class="form-horizontal mb-lg">
                                            <div class="form-group mt-lg">
                                                <label class="col-sm-4 control-label">Display Name</label>
                                                <div class="col-sm-8">
                                                    <asp:TextBox runat="server" ID="txtstore_name" CssClass="form-control" placeholder="Type your Store name..."></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="Req_sname" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic" ValidationGroup="store" ControlToValidate="txtstore_name"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-4 control-label">Bussiness Description</label>
                                                <div class="col-sm-8">
                                                    <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" ID="txtstore_desc" placeholder="Type bussiness details..."></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-4 control-label">Image Preview</label>
                                                <div class="col-sm-8">
                                                    <asp:Image ID="imgMain" runat="server" ImageUrl="~/Product_IMG/product_image (1).png" Width="380px" Height="210px" />
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Save Changes" ID="btn_store" OnClick="btn_store_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal fade" id="formModalstoreview" tabindex="-1" role="dialog" aria-labelledby="formModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">Store Details</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div id="demo-form12" class="form-horizontal mb-lg">
                                            <div class="form-group mt-lg">
                                                <label class="col-sm-4 control-label">Display Name</label>
                                                <div class="col-sm-8">
                                                    <asp:TextBox runat="server" ID="txtvbname" CssClass="form-control" placeholder="Type your Store name..."></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-4 control-label">Bussiness Description</label>
                                                <div class="col-sm-8">
                                                    <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" ID="txtvbdec" placeholder="Type bussiness details..."></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-4 control-label">Image Preview</label>
                                                <div class="col-sm-8">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Product_IMG/leptop.jpg" />
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Save Changes" ID="Button2" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <div class="featured-box featured-box-quaternary featured-box-effect-1">
                            <div class="box-content">
                                <i class="icon-featured fa fa-cogs"></i>
                                <h4 class="text-uppercase">Add Listing</h4>
                                <p>You need to add minimum 1 listings to activate your account. </p>
                                <p><a href="Listing.aspx" class="lnk-quaternary learn-more">Add a new Listing&nbsp <i class="fa fa-angle-right"></i></a></p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="margin: 5%">
            <div class="col-md-3">
                <div class="panel-group panel-group-primary" id="accordion2Primary">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2Primary" href="#collapse2PrimaryOne">Accordion Title 1
                                </a>
                            </h4>
                        </div>
                        <div id="collapse2PrimaryOne" class="accordion-body collapse ">
                            <div class="panel-body">
                                <p>Donec tellus massa, tristique sit amet condimentum vel, facilisis quis sapien.</p>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2Primary" href="#collapse2PrimaryTwo">Accordion Title 2
                                </a>
                            </h4>
                        </div>
                        <div id="collapse2PrimaryTwo" class="accordion-body collapse">
                            <div class="panel-body">
                                <p>Donec tellus massa, tristique sit amet condimentum vel, facilisis quis sapien.</p>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2Primary" href="#collapse2PrimaryThree">Accordion Title 3
                                </a>
                            </h4>
                        </div>
                        <div id="collapse2PrimaryThree" class="accordion-body collapse">
                            <div class="panel-body">
                                <p>Donec tellus massa, tristique sit amet condimentum vel, facilisis quis sapien.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel-group panel-group-secondary" id="accordion2Secondary">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2Secondary" href="#collapse2SecondaryOne">Accordion Title 1
                                </a>
                            </h4>
                        </div>
                        <div id="collapse2SecondaryOne" class="accordion-body collapse">
                            <div class="panel-body">
                                <p>Donec tellus massa, tristique sit amet condimentum vel, facilisis quis sapien.</p>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2Secondary" href="#collapse2SecondaryTwo">Accordion Title 2
                                </a>
                            </h4>
                        </div>
                        <div id="collapse2SecondaryTwo" class="accordion-body collapse">
                            <div class="panel-body">
                                <p>Donec tellus massa, tristique sit amet condimentum vel, facilisis quis sapien.</p>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2Secondary" href="#collapse2SecondaryThree">Accordion Title 3
                                </a>
                            </h4>
                        </div>
                        <div id="collapse2SecondaryThree" class="accordion-body collapse">
                            <div class="panel-body">
                                <p>Donec tellus massa, tristique sit amet condimentum vel, facilisis quis sapien.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">

                <div class="owl-carousel owl-theme show-nav-hover" data-plugin-options="{'items': 4, 'margin': 10, 'loop': false, 'nav': true, 'dots': false}">

                    <div>
                        <img alt="" class="img-responsive img-rounded" src="img/my/img1.jpg">
                    </div>
                    <div>
                        <img alt="" class="img-responsive img-rounded" src="img/my/img2.jpg">
                    </div>
                    <div>
                        <img alt="" class="img-responsive img-rounded" src="img/my/img3.jpg">
                    </div>
                    <div>
                        <img alt="" class="img-responsive img-rounded" src="img/my/img4.jpg">
                    </div>
                    <div>
                        <img alt="" class="img-responsive img-rounded" src="img/my/img5.jpg">
                    </div>
                    <div>
                        <img alt="" class="img-responsive img-rounded" src="img/my/img6.jpg">
                    </div>

                </div>

                <%--<div class="col-md-4">
                    <img class="img-responsive img-rounded mb-lg" src="../Product_IMG/Antibiotics-Kya-Hai-or-Inka-Kya-Use-hai-Uski-Jankari-in-Hindi.jpg" alt="Project Image">
                </div>
                <div class="col-md-4">
                    <img class="img-responsive img-rounded mb-lg" src="../Product_IMG/Aspirin.jpg" alt="Project Image">
                </div>
                <div class="col-md-4">
                    <img class="img-responsive img-rounded mb-lg" src="../Product_IMG/b12.jpg" alt="Project Image">
                </div>--%>
                <%--<div class="panel-group panel-group-tertiary" id="accordion2Tertiary">
								<div class="panel panel-default">
									<div class="panel-heading">
										<h4 class="panel-title">
											<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2Tertiary" href="#collapse2TertiaryOne">
												Accordion Title 1
											</a>
										</h4>
									</div>
									<div id="collapse2TertiaryOne" class="accordion-body collapse in">
										<div class="panel-body">
											<p>Donec tellus massa, tristique sit amet condimentum vel, facilisis quis sapien.</p>
										</div>
									</div>
								</div>
								<div class="panel panel-default">
									<div class="panel-heading">
										<h4 class="panel-title">
											<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2Tertiary" href="#collapse2TertiaryTwo">
												Accordion Title 2
											</a>
										</h4>
									</div>
									<div id="collapse2TertiaryTwo" class="accordion-body collapse">
										<div class="panel-body">
											<p>Donec tellus massa, tristique sit amet condimentum vel, facilisis quis sapien.</p>
										</div>
									</div>
								</div>
								<div class="panel panel-default">
									<div class="panel-heading">
										<h4 class="panel-title">
											<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2Tertiary" href="#collapse2TertiaryThree">
												Accordion Title 3
											</a>
										</h4>
									</div>
									<div id="collapse2TertiaryThree" class="accordion-body collapse">
										<div class="panel-body">
											<p>Donec tellus massa, tristique sit amet condimentum vel, facilisis quis sapien.</p>
										</div>
									</div>
								</div>
							</div>--%>
            </div>

        </div>

    </div>


</asp:Content>

