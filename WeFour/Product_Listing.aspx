<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="Product_Listing.aspx.cs" Inherits="Product_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
   
    <div role="main" class="main">
        <section class="page-header">
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
                <div class="row">
                    <div class="col-md-12">
                        <h1>Browse By Category</h1>
                    </div>
                </div>
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
                        <asp:Panel runat="server" ID="mainpanel" >
                             <div class="col-sm-2" style="margin: 0px; width:23%">
                            <asp:Label runat="server" Text="[Main Category]" ForeColor="Red"></asp:Label>
                            <asp:ListBox ID="lstmaingroup" runat="server" ToolTip="Main Category"  Style="position: static" Visible="false" AutoPostBack="true"  CssClass="form-control" Rows="15" OnSelectedIndexChanged="lstmaingroup_SelectedIndexChanged"></asp:ListBox>
                        </div>
                        </asp:Panel>
                       <asp:Panel runat="server" ID="subcatpanel" Visible ="false">
                           <div class="col-sm-2" style="margin: 0px;width:23%">
                            <asp:Label runat="server" ID="lstcatlabel" Text="[Sub Category]" ForeColor="Red" > </asp:Label>
                            <asp:ListBox ID="lstsubgroup" runat="server" ToolTip="Sub Category" Style="position: static;"  AutoPostBack="true" CssClass="form-control" Rows="15" OnSelectedIndexChanged="lstsubgroup_SelectedIndexChanged"></asp:ListBox>
                        </div>
                       </asp:Panel>
                        
                        <asp:Panel runat="server" ID="childpanel" Visible ="false">
                            <div class="col-sm-2" style="margin: 0px;width:23%">
                            <asp:Label runat="server" ID="lblsublabel" Text="[Child Category]" ForeColor="Red"> </asp:Label>
                            <asp:ListBox ID="lstchildgroup" runat="server" ToolTip="Child Category" Style="position: static;"  AutoPostBack="true" CssClass="form-control" Rows="15" OnSelectedIndexChanged="lstchildgroup_SelectedIndexChanged"></asp:ListBox>
                        </div>
                        </asp:Panel>
                        
                        <div class="col-md-2" id="alert" runat="server" visible="false" style="border-radius: 5px;">
                            <div class="alert alert-danger">
                                <strong>Oops!</strong> No Record Found....               
                            </div>
                        </div>
                        <div class="col-md-2">
                             <button type="button" class="mb-xs mt-xs mr-xs btn btn-primary" runat="server" id="btncreate" visible="false" onserverclick="btncreate_ServerClick" ><i class="fa fa-plus-circle"></i> Add product</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>

