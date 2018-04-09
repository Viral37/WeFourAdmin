<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Listing.aspx.cs" Inherits="test_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function showTime() {
            var dt = new Date();
            //alert(dt.toLocaleString());
            var sk = dt.getMonth() + 1;
            var year = dt.getYear("yy");
            $('#<%=lll.ClientID%>').prop('value', sk + year)
        }
    </script>
    <body onload="showTime();">
    </body>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div role="main" class="main" style="background: #F5F5F5">
        <section class="page-header" style="background-color: forestgreen">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <ul class="breadcrumb">
                            <li><a href="Home.aspx" style="color: white">Home</a></li>
                            <li class="active" style="color: white;">Listing</li>
                            <li>
                                <asp:HiddenField ID="lll" runat="server"></asp:HiddenField>
                            </li>
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
        <div class="container-fluid">
            <div class="col-md-2" style="border: none; border-right: solid; height: 500px;">
                <h4>How to use this page</h4>
                <ul class="list list-ordened list-ordened-style-3 ">
                    <li class="appear-animation" data-appear-animation="fadeInDown" data-appear-animation-delay="0">Select Categories.</li>
                    <li class="appear-animation" data-appear-animation="fadeInDown" data-appear-animation-delay="300">Check Approvals.</li>
                    <li class="appear-animation" data-appear-animation="fadeInUp" data-appear-animation-delay="600">Create New Product.</li>
                    <li class="appear-animation" data-appear-animation="fadeInUp" data-appear-animation-delay="900">Submit for Quality Project.</li>
                </ul>

            </div>
            <asp:UpdatePanel runat="server" ID="listup">
                <ContentTemplate>
                    <div class="col-md-10">
                        <div class="col-sm-2" style="margin: 0px;">
                            <asp:ListBox ID="lstmaingroup" runat="server" ToolTip="Main Category"   Style="position: static" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="lstmaingroup_SelectedIndexChanged" CssClass="form-control" Rows="15"></asp:ListBox>
                        </div>

                        <div class="col-sm-2" style="margin: 0px;">
                            <asp:ListBox ID="lstsubgroup" runat="server" ToolTip="Sub Category" Style="position: static;" Visible="false" AutoPostBack="true" CssClass="form-control" Rows="15" OnSelectedIndexChanged="lstsubgroup_SelectedIndexChanged"></asp:ListBox>
                        </div>

                        <div class="col-sm-2" style="margin: 0px;">
                            <asp:ListBox ID="lstchildgroup" runat="server" ToolTip="Child Category" Style="position: static;" Visible="false" AutoPostBack="true" CssClass="form-control" Rows="15" OnSelectedIndexChanged="lstchildgroup_SelectedIndexChanged"></asp:ListBox>
                        </div>


                        <div class="col-md-4" id="alert" runat="server" visible="false" style="border-radius: 5px;">
                            <div class="alert alert-danger">
                                <strong>Oops!</strong> No Record Found....               
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div runat="server" id="dv_msg" visible="false">
                                <asp:Label runat="server" ID="lbl_chk" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="form-group" runat="server" id="chk_brand" visible="false">

                                <label runat="server" id="lblst">Select brand to start selling in this category.</label><br />
                                <asp:Button runat="server" ID="btn_check" Text="Check Brand Approval" OnClick="btn_check_Click" ValidationGroup="chekbrand" CssClass="btn btn-primary" />

                            </div>
                            <div runat="server" id="brand_approval" visible="false">

                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="txt_brand" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Req_brand" runat="server" ErrorMessage="*" ControlToValidate="txt_brand" ForeColor="Red" Display="Dynamic" ValidationGroup="chekbrand"></asp:RequiredFieldValidator>

                                </div>
                                <asp:Button runat="server" ID="btn_chkbrand" Text="Check Brand" OnClick="btn_chkbrand_Click" ValidationGroup="chekbrand" CssClass="btn btn-primary" />

                            </div>
                            <div runat="server" id="apply_for_approval" visible="false">
                                <br />
                                <br />
                                <br />
                                <br />
                                <label>You do not have approval to sell this brand.</label><br />
                                <asp:LinkButton runat="server" ID="lnk_applyfor" OnClick="lnk_applyfor_Click" Text="Apply For Approval"></asp:LinkButton>
                            </div>
                            <div runat="server" id="Approved" visible="false">
                                <br />
                                <br />
                                <br />
                                <br />
                                <label>
                                    Brand name
                                <a href="#">
                                    <label id="brand_name" runat="server"></label>
                                </a>
                                    is approved.</label>
                                <br />
                                <asp:Button runat="server" ID="btn_new_product" Text="Create new product" OnClick="btn_new_product_Click" ValidationGroup="chekbrand" CssClass="btn btn-primary" />

                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>

