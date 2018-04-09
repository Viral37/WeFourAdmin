<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="addbrand.aspx.cs" Inherits="Vender_addbrand" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .bottom-bordered {
            position: relative;
            border-bottom: 1px solid #d3d3d3;
            margin-bottom: 17px;
            margin-top: 5px;
        }
    </style>
    <script type="text/javascript">
        function ValidateModuleList(source, args) {
            var chkListModules = document.getElementById('<%= chk_selling.ClientID %>');
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div role="main" class="main" style="background: white; padding-top: 30px; margin: 20px 0px 20px 0px">
        <div class="container">
            <div class="row ">
                <h3>Apply For Approval</h3>
                <ol>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <label>Brand Name</label><br />

                            <asp:Label runat="server" ID="lbl_name"></asp:Label>
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <label>Is this Brand widely distributed in offline market?</label><br />
                            <asp:RequiredFieldValidator ID="Req_widely" runat="server" ControlToValidate="rbl_widely" ErrorMessage="*" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>
                            <asp:RadioButtonList runat="server" ID="rbl_widely">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Self Declaration: If this is YOUR private label brand and you have NOT furnished a Trademark Certificate and in future any other seller applies with proper documentation to prove that the brand with same name is theirs, we may restrict you from selling this brand. Do you agree? </asp:Label>
                            <br />
                            <asp:RequiredFieldValidator ID="Req_self" runat="server" ControlToValidate="rbl_self_dec" ErrorMessage="*" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>

                            <asp:RadioButtonList runat="server" ID="rbl_self_dec">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Alternate brand alias </asp:Label>
                            <asp:RequiredFieldValidator ID="Req_balis" runat="server" ControlToValidate="txt_balias" ErrorMessage="*" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>

                            <br />
                            <asp:TextBox runat="server" ID="txt_balias" MaxLength="50" CssClass="form-control"></asp:TextBox>
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Brand Description</asp:Label>
                            <br />
                            <asp:TextBox runat="server" ID="txt_bdesc" TextMode="MultiLine" Rows="2" CssClass="form-control"></asp:TextBox>
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Brand Logo</asp:Label>
                            <asp:RequiredFieldValidator ID="Req_logo" runat="server" ControlToValidate="fu_logo" ErrorMessage="*" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ErrorMessage="Only file types .gif|.jpeg|.jpg|.png|.JPEG|.JPG|.PNG Allow" ForeColor="red" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"
                                ControlToValidate="fu_logo" ValidationGroup="addbrand"></asp:RegularExpressionValidator>
                            <br />
                            <asp:FileUpload runat="server" ID="fu_logo" />
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Brand Website Link</asp:Label>
                            <br />
                            <asp:TextBox runat="server" ID="txt_blink" MaxLength="100" CssClass="form-control"></asp:TextBox>
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Where do you sell the products of this brand currently?</asp:Label>
                            <%--        <asp:RequiredFieldValidator ID="Req_selling" runat="server" ControlToValidate="chk_selling" ErrorMessage="*" InitialValue="0" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>--%>
                            <asp:CustomValidator runat="server" ID="cvmodulelist"  ClientValidationFunction="ValidateModuleList" ForeColor="red" ValidationGroup="addbrand"
                                 ErrorMessage="*"></asp:CustomValidator>
                            <br />
                            <asp:CheckBoxList ID="chk_selling" runat="server">
                                <asp:ListItem>Not Applicable</asp:ListItem>
                                <asp:ListItem>Wholesale Distribution</asp:ListItem>
                                <asp:ListItem>Brick & Mortar Shop</asp:ListItem>
                                <asp:ListItem>Other Online Marketplaces</asp:ListItem>
                                <asp:ListItem>Brand Retail Website</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Are you the brand manufacturer?</asp:Label>
                            <asp:RequiredFieldValidator ID="Req_manufracture" runat="server" ControlToValidate="rbl_manufracture" ErrorMessage="*" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>

                            <br />
                            <asp:RadioButtonList runat="server" ID="rbl_manufracture">
                                <asp:ListItem>Yes, we manufacture the products</asp:ListItem>
                                <asp:ListItem>No, We are authorized distributor/seller for this brand</asp:ListItem>
                                <asp:ListItem>No, We procure it from open market and use our own private label</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Do the products of the brand come with branded/primary packaging?</asp:Label>
                            <asp:RequiredFieldValidator ID="Req_primary" runat="server" ControlToValidate="rbl_primary" ErrorMessage="*" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RadioButtonList runat="server" ID="rbl_primary">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Sample MRP Tag images</asp:Label>
                            <asp:RequiredFieldValidator ID="Req_mrp_tag" runat="server" ControlToValidate="fu_mrp_tag" ErrorMessage="*" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ErrorMessage="Only file types .gif|.jpeg|.jpg|.png|.JPEG|.JPG|.PNG|.pdf Allow" ForeColor="red" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"
                                ControlToValidate="fu_mrp_tag" ValidationGroup="addbrand"></asp:RegularExpressionValidator>

                            <br />
                            <asp:FileUpload runat="server" ID="fu_mrp_tag" />
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Are you the brand owner?</asp:Label>
                            <asp:RequiredFieldValidator ID="Req_owner" runat="server" ControlToValidate="rbl_owner" ErrorMessage="*" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>

                            <br />
                            <asp:RadioButtonList runat="server" ID="rbl_owner">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Kindly upload any of the following document :Trademark Certificate , Brand Authorization Letter ( with trademark number if any ) or Invoice Copy</asp:Label>
                            <asp:RequiredFieldValidator ID="Req_document" runat="server" ControlToValidate="fu_document" ErrorMessage="*" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                ErrorMessage="Only file types .gif|.jpeg|.jpg|.png|.JPEG|.JPG|.PNG|.pdf Allow" ForeColor="red" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"
                                ControlToValidate="fu_document" ValidationGroup="addbrand"></asp:RegularExpressionValidator>

                            <br />
                            <asp:FileUpload runat="server" ID="fu_document" />
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Trademark Apllication Number</asp:Label>
                            <asp:RequiredFieldValidator ID="Req_number" runat="server" ControlToValidate="txt_number" ErrorMessage="*" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>

                            <br />
                            <asp:TextBox runat="server" ID="txt_number" MaxLength="50" CssClass="form-control"></asp:TextBox>
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Trademark Class</asp:Label>
                            <asp:RequiredFieldValidator ID="Req_class" runat="server" ControlToValidate="txt_class" ErrorMessage="*" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>

                            <br />
                            <asp:TextBox runat="server" ID="txt_class" MaxLength="50" CssClass="form-control"></asp:TextBox>
                        </div>
                    </li>
                    <li class="bottom-bordered">
                        <div class="form-group">
                            <asp:Label runat="server">Trademark Apllication Date</asp:Label>
                            <asp:RequiredFieldValidator ID="Req_date" runat="server" ControlToValidate="txt_date" ErrorMessage="*" Display="Dynamic" ForeColor="red" ValidationGroup="addbrand"></asp:RequiredFieldValidator>

                            <br />
                            <asp:TextBox runat="server" ID="txt_date" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                            <asp:CalendarExtender ID="Calendar_date" runat="server" TargetControlID="txt_date" Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>
                    </li>
                    <asp:Button runat="server" ID="btn_submit" Text="Submit" ValidationGroup="addbrand" OnClick="btn_submit_Click" CssClass="btn btn-primary" />
                </ol>
            </div>
        </div>
    </div>
</asp:Content>

