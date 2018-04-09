<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="ManageAttribute.aspx.cs" Inherits="ManageAttribute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <section class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="Home.aspx">Home</a></li>
                        <li class="active">Manage Attribute</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h1>Manage Attribute</h1>
                </div>
            </div>
        </div>
    </section>
    <div class="container-fulid" style="margin-left: 10%">

        <div class="col-md-2">
            <label>Group List</label>
            <asp:DropDownList runat="server" ID="ddgrouplist" CssClass="form-control lg ddcss" AutoPostBack="true" OnSelectedIndexChanged="ddgrouplist_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ValidationGroup="btnbtn" runat="server" ControlToValidate="ddgrouplist" EnableClientScript="false" Display="Dynamic" ErrorMessage="Group name can't be None" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <asp:Panel runat="server" ID="panelcategory" Visible="false">
            <div class="col-md-2">
                <label>Category List</label>
                <asp:DropDownList runat="server" ID="ddcatlist" CssClass="form-control lg ddcss" AutoPostBack="true" OnSelectedIndexChanged="ddcatlist_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ValidationGroup="btnbtn" runat="server" ControlToValidate="ddcatlist" EnableClientScript="false" Display="Dynamic" ErrorMessage="Group name can't be None" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="panelsubcat" Visible="false">
            <div class="col-md-2">
                <label>Sub Category Name</label>
                <asp:DropDownList runat="server" ID="ddsubcatlist" CssClass="form-control lg ddcss" AutoPostBack="true" OnSelectedIndexChanged="ddsubcatlist_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ValidationGroup="btnbtn" runat="server" ControlToValidate="ddcatlist" EnableClientScript="false" Display="Dynamic" ErrorMessage="Group name can't be None" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="panelattribute" Visible="false">
            <div class="col-md-2">
                <label>Attribute Name</label>
                <asp:DropDownList runat="server" ID="ddattributelist" CssClass="form-control lg" OnSelectedIndexChanged="ddattributelist_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ValidationGroup="btnbtn" runat="server" ControlToValidate="ddcatlist" EnableClientScript="false" Display="Dynamic" ErrorMessage="Group name can't be None" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="panelbutton" Visible="false">
            <div class="col-md-3" style="margin-top: 2.5%">
                <button type="button" class="mb-xs mt-xs mr-xs btn btn-primary" runat="server" id="btnapply" validationgroup="btnbtn" onserverclick="btnapply_ServerClick"><i class="fa fa-plus-circle"></i>Apply Attribute</button>
            </div>

        </asp:Panel>

        <br />
    </div>

    <div class="container" style="margin-left: 12%; margin-top: 8%">
        <asp:GridView ID="datagrid" runat="server" GridLines="Both"
            DataKeyNames="ManageAttributeId" AllowPaging="True" Width="63%" CellPadding="2" AutoGenerateColumns="false" PageSize="20"
            OnRowDeleting="datagrid_RowDeleting" OnRowCancelingEdit="datagrid_RowCancelingEdit" OnPageIndexChanging="datagrid_PageIndexChanging" OnRowDataBound="datagrid_RowDataBound" OnRowEditing="datagrid_RowEditing" CellSpacing="5">
            <AlternatingRowStyle BackColor="White" />
            <HeaderStyle BackColor="#2E86C1" Font-Bold="True" ForeColor="White" Font-Italic="true" HorizontalAlign="Justify" />
            <HeaderStyle CssClass="ccc" />
            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
            <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />

            <Columns>
                <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="hederstyle">
                    <ItemTemplate>
                        <asp:Label ID="lblSerial" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Subcategory Name" HeaderStyle-CssClass="hederstyle">
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%# Bind("MSubCatName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Attribute Name" HeaderStyle-CssClass="hederstyle">
                    <ItemTemplate>
                        <asp:Label ID="lblattributeName" runat="server" Text='<%# Bind("MAttributeName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%--<asp:Button ID="btn_Edit" runat="server" Text="Edit Here" CommandName="Edit" CssClass="btn btn-tertiary mr-xs mb-sm btncss" />--%>
                        <asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger mr-xs mb-sm btncss" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" CssClass="btn btn-tertiary mr-xs mb-sm btncss" />
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-tertiary mr-xs mb-sm btncss" />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>

            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="First" LastPageText="Last" />
        </asp:GridView>

    </div>
   

</asp:Content>

