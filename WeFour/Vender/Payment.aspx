<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Vender_Payment" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="body" style="background: #F5F5F5;">

        <div class="container-fulid">
            <div class="col-md-4" style="border: solid; height: 300px; margin: 5px; border-radius: 5px">
                <div class="col-sm-12">
                    <div class="col-sm-12" style="margin-top: 5px;">
                        <dl>
                            <h2 style="margin: 5px; color: forestgreen">Next Payment</h2>
                            <p>Estimated value of next payment. </p>

                            <dt>Date</dt>
                            <dd style="color: red">
                                <asp:Label runat="server" ID="lbldate"></asp:Label></dd>
                        </dl>
                        <dl>
                            <dt>Cash Payment</dt>
                            <dd>
                                <asp:Label runat="server" ID="lblcodpmt"></asp:Label></dd>
                            <dt>Bank Payment</dt>
                            <dd>
                                <asp:Label runat="server" ID="lblbankpmt"></asp:Label></dd>
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
            <div class="col-md-4" style="border: solid; height: 300px; margin: 5px; background-color: white; border-radius: 5px">
                <div class="col-sm-12">
                    <div class="col-sm-12" style="margin-top: 5px;">
                        <dl>
                            <h2 style="margin: 5px; color: forestgreen">Last Payment</h2>
                            <p>These payments have been initiated and may take up to 48 hours to reflect in your bank account </p>
                        </dl>
                        <dl>
                            <dt>Cash Payment</dt>
                            <dd>
                                <asp:Label runat="server" ID="Label1"></asp:Label></dd>
                            <dt>Bank Payment</dt>
                            <dd>
                                <asp:Label runat="server" ID="Label2"></asp:Label></dd>
                        </dl>
                    </div>
                    <div class="col-sm-5" style="margin-top: 5px;">
                        <dl>
                            <dt><%--<a href="" style="text-decoration-nline: none;" data-toggle="modal" data-target="#formModal">Change Password</a>--%></dt>
                            <dd>
                                <asp:Label runat="server" ID="Label3"></asp:Label></dd>
                        </dl>
                    </div>
                </div>
            </div>
            <div class="col-md-3" style="background-color: ghostwhite; margin: 10px;">
                <div class="panel-group panel-group-sm" id="accordion3">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#collapse3One">When will I receive payment?
                                </a>
                            </h4>
                        </div>
                        <div id="collapse3One" class="accordion-body collapse in">
                            <div class="panel-body">
                                <p>here to know how we pay you for different types of orders.</p>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#collapse3Two">BudgetOk Rate Card
                                </a>
                            </h4>
                        </div>
                        <div id="collapse3Two" class="accordion-body collapse">
                            <div class="panel-body">
                                <p>Check out our rate card to understand the marketplace fee structure for orders and other services.</p>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#collapse3Three">Have other payment related questions?
                                </a>
                            </h4>
                        </div>
                        <div id="collapse3Three" class="accordion-body collapse">
                            <div class="panel-body">
                                <p>Learn all about Flipkart's payment policies and get certified today!.</p>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-4" style="border: solid; height: 300px; margin: 5px; background-color: white; border-radius: 5px">
                <div class="col-sm-12">
                    <div class="col-md-12" style="margin-top: 5px;">
                        <dl>
                            <h2 style="margin: 5px; color: forestgreen">Outstanding Payments</h2>
                            <p>Total amount you are to receive from BudgetOk for dispatched orders.</p>

                        </dl>
                        <dl>
                            <dt>Cash Payment</dt>
                            <dd>
                                <asp:Label runat="server" ID="Label4"></asp:Label></dd>
                            <dt>Bank Payment</dt>
                            <dd>
                                <asp:Label runat="server" ID="Label6"></asp:Label></dd>
                        </dl>
                    </div>
                    <div class="col-sm-5" style="margin-top: 5px;">
                        <dl>
                            <dt><%--<a href="" style="text-decoration-nline: none;" data-toggle="modal" data-target="#formModal">Change Password</a>--%></dt>

                            <dd>
                                <asp:Label runat="server" ID="Label7"></asp:Label></dd>
                        </dl>

                    </div>
                </div>
            </div>
            <div class="col-md-4" style="border: solid; height: 300px; margin: 5px; background-color: white; border-radius: 5px">
                <div class="col-sm-12">
                    <div class="col-sm-12" style="margin-top: 5px;">
                        <dl>
                            <h2 style="margin: 5px; color: forestgreen">Unbilled Orders</h2>
                            <p>These are orders yet to be dispatched. Once dispatched, payments will be scheduled. </p>
                        </dl>
                        <dl>
                            <dt>No. of Orders </dt>
                            <dd>
                                <asp:Label runat="server" ID="Label8"></asp:Label></dd>
                            <%--<dt>Bank Payment</dt>--%>
                            <%--<dd>
                                    <asp:Label runat="server" ID="Label9"></asp:Label></dd>--%>
                        </dl>
                    </div>
                    <div class="col-sm-5" style="margin-top: 5px;">
                        <dl>
                            <dt><%--<a href="" style="text-decoration-nline: none;" data-toggle="modal" data-target="#formModal">Change Password</a>--%></dt>
                            <dd>
                                <asp:Label runat="server" ID="Label10"></asp:Label></dd>
                        </dl>
                    </div>
                </div>
            </div>
        </div>
        <%--                <div class="col-md-3" style="border: solid; height: 350px; margin: 30px; background-color: white; border-radius: 5px">
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
                    </div>
                </div>
            </div>--%>
</asp:Content>

