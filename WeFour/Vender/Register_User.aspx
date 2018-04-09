<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="~/Vender/Register_User.aspx.cs" Inherits="Register_User" EnableEventValidation="false" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Basic page needs
	============================================ -->
    <title>E-Commerce</title>
    <meta charset="utf-8" />
    <meta name="keywords" content="boostrap, responsive, html5, css3, jquery, theme, multicolor, parallax, retina, business" />
    <meta name="author" content="Magentech" />
    <meta name="robots" content="index, follow" />

    <!-- Mobile specific metas
	============================================ -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />

    <!-- Favicon
	============================================ -->
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="ico/apple-touch-icon-144-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="ico/apple-touch-icon-114-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="ico/apple-touch-icon-72-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" href="ico/apple-touch-icon-57-precomposed.png" />
    <link rel="shortcut icon" href="ico/favicon.png" />

    <!-- Google web fonts
	============================================ -->
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,700,300' rel='stylesheet' type='text/css' />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <script src="../js/validation.js"></script>
    <!-- Libs CSS
	============================================ -->
    <link rel="stylesheet" href="css/bootstrap/css/bootstrap.min.css" />
    <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="js/datetimepicker/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link href="js/owl-carousel/owl.carousel.css" rel="stylesheet" />
    <link href="css/themecss/lib.css" rel="stylesheet" />
    <link href="js/jquery-ui/jquery-ui.min.css" rel="stylesheet" />

    <!-- Theme CSS
	============================================ -->
    <link href="css/themecss/so_megamenu.css" rel="stylesheet" />
    <link href="css/themecss/so-categories.css" rel="stylesheet" />
    <link href="css/themecss/so-listing-tabs.css" rel="stylesheet" />
    <link href="css/footer1.css" rel="stylesheet" />
    <link href="css/header1.css" rel="stylesheet" />
    <link id="color_scheme" href="css/theme.css" rel="stylesheet" />

    <link href="css/responsive.css" rel="stylesheet" />


    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />--%>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://davidstutz.github.io/bootstrap-multiselect/dist/js/bootstrap-multiselect.js"></script>
    <link rel="stylesheet" href="http://davidstutz.github.io/bootstrap-multiselect/dist/css/bootstrap-multiselect.css" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {
            $('#ddlCountry').multiselect({
                includeSelectAllOption: true,
                enableCaseInsensitiveFiltering: true,
                enableFiltering: true,
                maxHeight: 200
            });
        });

        <%--function GetSelectedCountries() {
            var selectedCountries = "";
            $("#ddlCountry option:selected").each(function () {
                selectedCountries += $(this).text() + ",";
            });
            if (selectedCountries) {
                //alert(selectedCountries);
                document.getElementById('<%= ass.ClientID %>').innerHTML = selectedCountries;
                <%Session["sdd"] = '"' + selectedCountries + '"';%>;
            }
            else {
                alert("Please select at least one country");
            };
        }--%>
    </script>

</head>
<body>
    <form id="form1" runat="server" role="form">
        <!-- Header Container  -->
        <div>
            <h2 class="title" align="center">
                <asp:Label ID="lblact" runat="server" CssClass="label label-success">Register Today.</asp:Label></h2>
            <br />
            <div class="container">
                <div class="stepwizard">
                    <div class="stepwizard-row setup-panel">
                        <div class="stepwizard-step">
                            <label runat="server" id="btns1" class="btn btn-primary btn-circle">1</label>
                            <p>Contact Detail</p>
                        </div>
                        <div class="stepwizard-step">
                            <label runat="server" id="btns2" class="btn btn-default btn-circle" disabled="disabled">2</label>
                            <p>Business Detail</p>
                        </div>
                        <div class="stepwizard-step">
                            <label runat="server" id="btns3" class="btn btn-default btn-circle" disabled="disabled">3</label>
                            <p>Bank Account Detail</p>
                        </div>
                        <div class="stepwizard-step">
                            <label runat="server" id="btns4" class="btn btn-default btn-circle" disabled="disabled">4</label>
                            <p>Document Upload</p>
                        </div>
                        <%--<div class="stepwizard-step">
                            <a href="#step5" type="button" class="btn btn-default btn-circle" disabled="disabled">5</a>
                            <p>Final Stap</p>
                        </div>--%>
                    </div>
                </div>
                <div id="step1" runat="server" visible="false">
                    <div class="col-xs-12">
                        <div class="col-md-12">
                            <h2 style="color: #00a8ff; font-family: 'Times New Roman', Times, serif">Provide Your Personal Details</h2>
                            <div class="form-group col-sm-1">
                                <asp:Label runat="server" Class="control-label" Style="font-weight: bold"></asp:Label><br />
                                <asp:Label runat="server" Class="control-label" Style="font-weight: bold; font-size: 14px">Applicant</asp:Label>
                            </div>
                            <div class="form-group required col-sm-2">
                                <asp:Label runat="server" Class="control-label" Style="font-weight: bold">Mr./Ms.</asp:Label><br />
                                <asp:DropDownList runat="server" ID="ddlmr" CssClass="form-control" TabIndex="1">
                                    <asp:ListItem>Mr.</asp:ListItem>
                                    <asp:ListItem>Ms.</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-3">
                                <asp:Label runat="server" Class="control-label" Style="font-weight: bold">First Name</asp:Label>
                                <asp:RequiredFieldValidator ID="first_name" runat="server"
                                    ControlToValidate="txt_Name" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsval" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txt_name" runat="server" placeholder="First Name" onkeypress="return onlyAlphabet(event)" CssClass="form-control" TabIndex="2" MaxLength="30"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-3">
                                <asp:Label runat="server" Class="control-label" Style="font-weight: bold">Middle Name</asp:Label>
                                <asp:RequiredFieldValidator ID="rfvmname" runat="server"
                                    ControlToValidate="txtmname" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsval" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtmname" runat="server" placeholder="Middle Name" onkeypress="return onlyAlphabet(event)" CssClass="form-control" TabIndex="3" MaxLength="30"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-3">
                                <asp:Label runat="server" Class="control-label" Style="font-weight: bold">Last Name</asp:Label>
                                <asp:RequiredFieldValidator ID="rfvlname" runat="server"
                                    ControlToValidate="txtlname" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsval" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtlname" runat="server" placeholder="Last Name" onkeypress="return onlyAlphabet(event)" CssClass="form-control" TabIndex="4" MaxLength="30"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Email ID</label><asp:Label runat="server" ID="skas"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                    ControlToValidate="txtmail" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsval" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="Reg_email" ValidationGroup="rsval" runat="server" ControlToValidate="txtmail" Display="Dynamic" ErrorMessage=" Please enter Valid Email Id" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txtmail" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtmail_TextChanged" ReadOnly="true" placeholder="Enter Email ID" TabIndex="5" runat="server" MaxLength="80"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Mobile Number</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                    ControlToValidate="txtmnu" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsval" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtmnu" CssClass="form-control" onkeypress="return mobileno(event)" ReadOnly="true" TabIndex="6" placeholder="Enter Mobile Number" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Country</label>
                                <asp:TextBox ID="txtocoun" CssClass="form-control" onkeypress="return onlyAlphabet(event)" TabIndex="7" MaxLength="30" placeholder="Enter Country Name" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">State</label>
                                <asp:TextBox ID="txtost" CssClass="form-control" onkeypress="return onlyAlphabet(event)" TabIndex="8" MaxLength="30" placeholder="Enter State Name" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">City</label>
                                <asp:TextBox ID="txtocity" CssClass="form-control" onkeypress="return onlyAlphabet(event)" TabIndex="9" MaxLength="30" placeholder="Enter City Name" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">PinCode</label>
                                <asp:TextBox ID="txtopin" CssClass="form-control" MaxLength="6" onkeypress="return mobileno(event)" TabIndex="10" placeholder="Enter PinCode" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group  col-sm-3">
                                <asp:Label runat="server" class="control-label" Style="font-weight: bold">Reference ID</asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtrfid" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                                    ValidationGroup="register" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                <asp:TextBox ID="txtrfid" runat="server" placeholder="Reference ID" CssClass="form-control" TabIndex="11" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="form-group  col-sm-3">
                                <b>Reference Name :- </b>
                                <asp:TextBox CssClass="form-control" ReadOnly="true" ID="lblna" runat="server"></asp:TextBox>
                            </div>
                            <div runat="server" id="pwssk">
                                <div class="form-group  col-sm-3">
                                    <label class="control-label">Password</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                        ControlToValidate="txtpwd" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                        ValidationGroup="rsval" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:TextBox CssClass="form-control" ID="txtpwd" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group  col-sm-3">
                                    <label class="control-label">Conform Password</label>
                                    <asp:CompareValidator runat="server" ID="ads" ControlToCompare="txtpwd" ControlToValidate="txtcpwd" ErrorMessage="Not match" ForeColor="Red"></asp:CompareValidator>
                                    <asp:TextBox CssClass="form-control" ID="txtcpwd" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group col-sm-6">
                                <label class="control-label">Address</label>
                                <asp:TextBox ID="txtoadd" CssClass="form-control" placeholder="Enter Address" TabIndex="12" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12">
                                <asp:Button ID="btnst1" OnClick="btnst1_Click" runat="server" ValidationGroup="rsval" class="btn btn-primary btn-lg pull-right" Text="Next" />
                            </div>
                        </div>
                    </div>
                </div>
                <div id="step2" runat="server" visible="false">
                    <div class="col-xs-12">
                        <div class="col-md-12">
                            <h2 style="color: #00a8ff; font-family: 'Times New Roman', Times, serif">Provide Your Business Details</h2>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Business Name</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtbnm" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsvalSK" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtbnm" CssClass="form-control" placeholder="Enter Business Name" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Biling Lable(Short Form Of Business)</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="txtblbl" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsvalSK" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtblbl" CssClass="form-control" placeholder="Enter Billing Label" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Registered Countary</label>
                                <asp:TextBox ID="txtrcoun" onkeypress="return onlyAlphabet(event)" CssClass="form-control" placeholder="Enter Registered Countary" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Registered State</label>
                                <asp:TextBox ID="txtrst" CssClass="form-control" onkeypress="return onlyAlphabet(event)" placeholder="Enter Registered State" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Registered City</label>
                                <asp:TextBox ID="txtrcity" CssClass="form-control" onkeypress="return onlyAlphabet(event)" placeholder="Enter Registered City" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">PinCode</label>
                                <asp:TextBox ID="txtpin" CssClass="form-control" MaxLength="6" onkeypress="return mobileno(event)" placeholder="Enter PinCode" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Date of Establishment</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txted" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsvalSK" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txted"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Company CIN</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ControlToValidate="txtcpin" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsvalSK" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtcpin" CssClass="form-control" placeholder="Enter Company CIN" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Company PanCard Number</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                    ControlToValidate="txtcnpin" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsvalSK" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtcnpin" CssClass="form-control" placeholder="Enter Pancard Number" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Name on PanCard</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                    ControlToValidate="txtpnam" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsvalSK" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtpnam" CssClass="form-control" placeholder="Enter Name on Pancard" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-8">
                                <label class="control-label">Select Category</label><br />
                                <asp:ListBox ID="ddlCountry" runat="server" Style="width: 80%" SelectionMode="Multiple"></asp:ListBox>
                            </div>
                            <asp:Button ID="btnnn" runat="server" OnClick="btnnn_Click" class="btn btn-primary btn-lg pull-right" ValidationGroup="rsvalSK" Text="Next" />
                        </div>
                    </div>
                </div>
                <div id="step3" runat="server" visible="false">
                    <div class="col-xs-12">
                        <div class="col-md-12">
                            <h2 style="color: #00a8ff; font-family: 'Times New Roman', Times, serif">Provide Your Business's Bank Details</h2>
                            <asp:Label ID="ass" runat="server"></asp:Label>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Bank IFSC Code</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                    ControlToValidate="txtifsc" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsvalS" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtifsc" CssClass="form-control" placeholder="Enter Bank IFSC code" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Account Number</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                    ControlToValidate="txtacno" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsvalS" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cp" runat="server" ControlToCompare="txtacno" ControlToValidate="txtracno" ForeColor="Red" ErrorMessage="Not Match"></asp:CompareValidator>
                                <asp:TextBox ID="txtacno" CssClass="form-control" MaxLength="15" onkeypress="return mobileno(event)" ValidationGroup="sk" placeholder="Enter Account number" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Re-Enter Account Number</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                    ControlToValidate="txtracno" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsvalS" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtracno" CssClass="form-control" MaxLength="15" onkeypress="return mobileno(event)" ValidationGroup="sk" placeholder="Re-Enter Account number" runat="server"></asp:TextBox>

                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Account Type</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                    ControlToValidate="txttyp" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsvalS" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txttyp" CssClass="form-control" placeholder="Enter Account Type" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Account Holder Name</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                    ControlToValidate="txtbname" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsvalS" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtbname" CssClass="form-control" onkeypress="return onlyAlphabet(event)" placeholder="Enter Benecifiary Name" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Beneficiary Countary</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                    ControlToValidate="txtbancaon" ErrorMessage="Fill it" ForeColor="Red" Font-Bold="true"
                                    ValidationGroup="rsvalS" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtbancaon" CssClass="form-control" onkeypress="return onlyAlphabet(event)" placeholder="Enter Beneficiary Countary" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Beneficiary State</label>
                                <asp:TextBox ID="txtbsta" CssClass="form-control" onkeypress="return onlyAlphabet(event)" placeholder="Enter Beneficiary State" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Beneficiary City</label>
                                <asp:TextBox ID="txtbcity" CssClass="form-control" onkeypress="return onlyAlphabet(event)" placeholder="Enter Beneficiary City" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="control-label">Pincode</label>
                                <asp:TextBox ID="txthpi" CssClass="form-control" placeholder="Enter Pincode" MaxLength="6" onkeypress="return mobileno(event)" runat="server"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnst3" OnClick="btnst3_Click" runat="server" ValidationGroup="rsvalS" class="btn btn-primary nextBtn btn-lg pull-right" Text="Next" />
                        </div>
                    </div>
                </div>
                <div id="step4" runat="server" visible="true">
                    <div class="col-xs-12">
                        <div class="col-md-12">
                            <h2 style="color: #00a8ff; font-family: 'Times New Roman', Times, serif">Provide Your Business</h2>
                            <div class="form-group col-sm-6">
                                <label class="control-label">Business Registration Proof</label>
                                <asp:FileUpload ID="filebrp" CssClass="form-control" onchange="return imageuploadformate();" runat="server" />
                            </div>
                            <div class="form-group col-sm-6">
                                <label class="control-label">Business PAN</label>
                                <asp:FileUpload ID="fupan" CssClass="form-control" runat="server" />
                            </div>
                            <div class="form-group col-sm-6">
                                <label class="control-label">Company Bank Account Statement</label>
                                <asp:FileUpload ID="fupcsta" CssClass="form-control" runat="server" />
                            </div>
                            <div class="form-group col-sm-6">
                                <label class="control-label">Authorised Address Prrof</label>
                                <asp:FileUpload ID="fautadds" CssClass="form-control" runat="server" />
                            </div>
                            <asp:Button ID="btnst4" OnClick="btnst4_Click" runat="server" Style="width: 100%" class="btn btn-primary nextBtn btn-lg pull-right" Text="Finish" />
                        </div>
                    </div>
                </div>
                <%--    <div id="step5" runat="server" visible="false">
                    <div class="col-xs-12">
                        <div class="col-md-12">
                            <h2 style="color: #00a8ff; font-family: 'Times New Roman', Times, serif">Step 5</h2>
                            <h4>
                                <asp:Label runat="server" ID="sks" ForeColor="Red"></asp:Label></h4>
                            <div class="form-group">
                                <label class="control-label">Skills</label>
                                <input maxlength="200" type="text" required="required" class="form-control" placeholder="Enter skill or skills" />
                            </div>
                            <asp:Button ID="btnfa" runat="server" OnClick="btnfa_Click" class="btn btn-success btn-lg pull-right" Text="Finish!" />
                        </div>
                    </div>
                </div>--%>
            </div>
            <%--<script src='https://code.jquery.com/jquery-2.2.4.min.js'></script>--%>
            <script src='https://cdnjs.cloudflare.com/ajax/libs/underscore.js/1.8.3/underscore-min.js'></script>
            <script type="text/javascript">
                function imageuploadformate() {
                    var uploadcontrol = document.getElementById('<%=filebrp.ClientID%>').value;
                    //Regular Expression for fileupload control.
                    var reg = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpeg|.JPEG|.gif|.GIF|.png|.PNG|.jpg|.JPG)$/;

                    if (uploadcontrol.length > 0) {
                        //Checks with the control value.
                        if (reg.test(uploadcontrol)) {
                            return true;
                        }
                        else {
                            //If the condition not satisfied shows error message.
                            alert("You Can select only '.jpeg', '.JPEG', '.gif', '.GIF', '.png', '.PNG' files!");

                            return false;
                        }
                    }
                }
            </script>
            <script src="../js/index.js"></script>

        </div>
        <!-- Include Libs & Plugins
        ============================================ -->
        <!-- Placed at the end of the document so the pages load faster -->
        <script type="text/javascript" src="js/jquery-2.2.4.min.js"></script>
        <script type="text/javascript" src="js/bootstrap.min.js"></script>
        <script type="text/javascript" src="js/owl-carousel/owl.carousel.js"></script>
        <script type="text/javascript" src="js/themejs/libs.js"></script>
        <script type="text/javascript" src="js/unveil/jquery.unveil.js"></script>
        <script type="text/javascript" src="js/countdown/jquery.countdown.min.js"></script>
        <script type="text/javascript" src="js/dcjqaccordion/jquery.dcjqaccordion.2.8.min.js"></script>
        <script type="text/javascript" src="js/datetimepicker/moment.js"></script>
        <script type="text/javascript" src="js/datetimepicker/bootstrap-datetimepicker.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui/jquery-ui.min.js"></script>


        <!-- Theme files
    ============================================ -->


        <script type="text/javascript" src="js/themejs/so_megamenu.js"></script>
        <script type="text/javascript" src="js/themejs/addtocart.js"></script>
        <script type="text/javascript" src="js/themejs/application.js"></script>
    </form>
</body>
</html>
