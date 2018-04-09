<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="Track_Approvel.aspx.cs" Inherits="Vender_Track_Approvel" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="body" style="background-color: #F5F5F5;">
        <div class="container">
            <%--<div class="col-md-8">
            <h2>Track Approval Requests</h2>
        </div>
        <div class="col-md-2" style="margin-top:20px";>
        
        </div>--%>
            <div class="col-md-4">
                <h3 style="color: forestgreen">Track Approval Requests</h3>
            </div>
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <div class="header-search hidden-xs">
                    <div id="searchForm">
                        <div class="input-group">

                            <asp:TextBox runat="server" CssClass="form-control" ID="srchorder" placeholder="Search by Product Name"></asp:TextBox>
                            <span class="input-group-btn">
                                <button runat="server" class="btn btn-default" type="submit" id="btnserch" onserverclick="btnserch_ServerClick"><i class="fa fa-search"></i></button>

                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />

            <div class="row right">

                <div class="col-md-3">

                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddfliter" AutoPostBack="true" OnSelectedIndexChanged="ddfliter_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select Status</asp:ListItem>
                        <asp:ListItem Value="Decline">Decline</asp:ListItem>
                        <asp:ListItem Value="Pending">Pending</asp:ListItem>
                        <asp:ListItem Value="Approve with Brand">Approve with Brand</asp:ListItem>
                        <asp:ListItem Value="Approve without Brand">Approve without Brand</asp:ListItem>
                    </asp:DropDownList>

                </div>
            </div>
            <br />
            <asp:GridView CssClass="table table-hover center" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%" ID="apd">
                <RowStyle HorizontalAlign="Center" />
                <AlternatingRowStyle BackColor="White" />
                <HeaderStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="White" Font-Italic="true" HorizontalAlign="Left" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />

                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>Product ID</HeaderTemplate>
                        <ItemTemplate>
                             <asp:LinkButton ID="lbtnviewproduct" runat="server" OnClick="lbtnviewproduct_Click" Text='<%# Eval("Prefix") +""+ Eval("Product_id") %>' CommandArgument='<%#Eval("Prefix") +""+Eval("Product_id") %>' ToolTip="Click here to View Product Detail"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Product_Name" HeaderText="Name" />
                    <asp:BoundField DataField="Your_selling_price" HeaderText="Price" />
                    <asp:BoundField DataField="GST" HeaderText="GST(%)" />
                    <asp:BoundField DataField="Stocks" HeaderText="Stock" />
                    <asp:BoundField DataField="Product_status" HeaderText="Status" />
                    <asp:BoundField DataField="Vender_id" HeaderText="Vender Email" />
                </Columns>

            </asp:GridView>
        </div>

    </div>
</asp:Content>

