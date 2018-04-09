<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="Manage_Subcatgory.aspx.cs" Inherits="Manage_Subcatgory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <section class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="Home.aspx">Home</a></li>
                        <li class="active">Manage Category</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h1>Manage Category</h1>
                </div>
            </div>
        </div>
    </section>
    <div class="container-fulid" style="margin-left: 10%">

        <div class="col-md-3">
            <label>Group List</label>
            <asp:DropDownList runat="server" ID="ddgrouplist" CssClass="form-control ddcss" AutoPostBack="true" OnSelectedIndexChanged="ddgrouplist_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ValidationGroup="btnbtn" runat="server" ControlToValidate="ddgrouplist" EnableClientScript="false" Display="Dynamic" ErrorMessage="Group name can't be None" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

        <div class="col-md-3">
            <label>Category List</label>
            <asp:DropDownList runat="server" ID="ddcatlist" CssClass="form-control ddcss" AutoPostBack="true">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ValidationGroup="btnbtn" runat="server" ControlToValidate="ddcatlist" EnableClientScript="false" Display="Dynamic" ErrorMessage="Group name can't be None" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

        <div class="col-md-3">
            <label>Sub Category Name</label>
            <asp:TextBox runat="server" ID="txtsubcatname" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtsubcatname" ValidationGroup="btnbtn" ErrorMessage="Group name can't be None" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label runat="server" ID="lblerror" ForeColor="Red" Text="Enter Subcategory name is alwaredy availabel in system,Please enter other group name." Visible="false"></asp:Label>
        </div>

        <div class="col-md-3" style="margin-top: 2.5%">
            <asp:Button runat="server" ID="btncreate" Text="Add Sub Category" ValidationGroup="btnbtn" CssClass="btn btn-primary" OnClick="btncreate_Click" />
        </div>
    </div>
    <hr />
    <div class="container" style="margin-left: 12%; margin-top: 2%">
        <asp:GridView ID="datagridsubcat" runat="server"
            DataKeyNames="Subid" AllowPaging="True"
            PagerStyle-CssClass="pagination" PageSize="5" Width="63%" AutoGenerateColumns="false"
            OnRowEditing="datagridsubcat_RowEditing" OnPageIndexChanging="datagridsubcat_PageIndexChanging" OnRowDeleting="datagridsubcat_RowDeleting" OnRowDataBound="datagridsubcat_RowDataBound" OnRowUpdating="datagridsubcat_RowUpdating" OnRowCancelingEdit="datagridsubcat_RowCancelingEdit">

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

                <asp:TemplateField HeaderText="Group Name" HeaderStyle-CssClass="hederstyle">

                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("grp") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Category Name" HeaderStyle-CssClass="hederstyle">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("catagoty") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subcategory Name" HeaderStyle-CssClass="hederstyle">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtsubcatedit" Text='<%# Bind("subcategory") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%# Bind("subcategory") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit Here" CommandName="Edit" CssClass="btn btn-tertiary mr-xs mb-sm btncss" />
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

