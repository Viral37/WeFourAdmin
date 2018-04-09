<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Manage_Category.aspx.cs" Inherits="Manage_Category" %>

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
    <div class="container" style="margin-left: 10%">
        <div class="col-md-4">
            <label>Group Name List</label>
            <asp:DropDownList runat="server" ID="ddgrouplist" CssClass="form-control ddcss">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ValidationGroup="btnbtn" runat="server" ControlToValidate="ddgrouplist" EnableClientScript="false" Display="Dynamic" ErrorMessage="Group name can't be None" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

        <div class="col-md-4">
            <label>Category Name</label>
            <asp:TextBox runat="server" ID="txtcatname" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtcatname" ValidationGroup="btnbtn" ErrorMessage="Group name can't be None" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label runat="server" ID="lblerror" ForeColor="Red" Text="Enter Group name is alwaredy availabel in system,Please enter other group name." Visible="false"></asp:Label>
        </div>

        <div class="col-md-4" style="margin-top: 2.5%">
            <asp:Button runat="server" ID="btncreate" Text="Add Category" ValidationGroup="btnbtn" CssClass="btn btn-primary" OnClick="btncreate_Click" />
        </div>

    </div>
    <hr />
    <div class="container" style="margin-left: 12%; margin-top: 2%">
        <asp:GridView ID="datagridcat" runat="server"
            DataKeyNames="CategoryId" AllowPaging="True" OnRowDataBound="datagridcat_RowDataBound" 
            PagerStyle-CssClass="pagination" PageSize="5" Width="63%" OnPageIndexChanging="datagridcat_PageIndexChanging" AutoGenerateColumns="false" OnRowCancelingEdit="datagridcat_RowCancelingEdit" OnRowDeleting="datagridcat_RowDeleting" OnRowEditing="datagridcat_RowEditing" OnRowUpdating="datagridcat_RowUpdating">

            <AlternatingRowStyle BackColor="White" />
            <HeaderStyle BackColor="#2E86C1" Font-Bold="True" ForeColor="White" Font-Italic="true" HorizontalAlign="Justify" />
            <HeaderStyle CssClass="ccc" />
            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
            <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <Columns>
                 <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="hederstyle"  >
                    <ItemTemplate>
                        <asp:Label ID="lblSerial" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Group Name" DataField="GroupName" ReadOnly="true" HeaderStyle-CssClass="hederstyle" />
          
        
                <asp:TemplateField HeaderText="Category Name" HeaderStyle-CssClass="hederstyle">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtcatnameedit" Text='<%# Bind("CategoryName") %>' CssClass="form-control" ></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit Here" CommandName="Edit" CssClass="btn btn-tertiary mr-xs mb-sm btncss" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" CssClass="btn btn-tertiary mr-xs mb-sm btncss" />
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-tertiary mr-xs mb-sm btncss" />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="First" LastPageText="Last"/>
        </asp:GridView>
    </div>

</asp:Content>

