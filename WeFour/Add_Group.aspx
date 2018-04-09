<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="Add_Group.aspx.cs" Inherits="Add_Group" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/Gridview/Gridview.css" rel="stylesheet" />
    <style> 
    .btncss {
            margin:5px;
        }
        .hederstyle {
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <section class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="Home.aspx">Home</a></li>
                        <li class="active">Add Group</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h1>Add Group</h1>
                </div>
            </div>
        </div>
    </section>

    <div class="container" style="margin-left: 10%">
        <div class="col-md-8">
            <label>Group Name</label>
            <asp:TextBox runat="server" ID="txtgroupname" CssClass="form-control input-lg" OnTextChanged="txtgroupname_TextChanged" AutoPostBack="true"></asp:TextBox>
            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtgroupname" ErrorMessage="Group name can't be None" ForeColor="Red"></asp:RequiredFieldValidator>--%>
            <asp:Label runat="server" ID="lblerror" ForeColor="Red" Text="Enter Group name is alwaredy availabel in system,Please enter other group name." Visible="false"></asp:Label>
        </div>

        <div class="col-md-4" style="margin-top: 2.5%">
            <asp:Button runat="server" ID="btncreate" Text="Add Group" CssClass="btn btn-primary" OnClick="btncreate_Click" />
        </div>

    </div>
    <div class="container" style="margin-left: 12%; margin-top: 2%">
        <asp:GridView ID="datagrid" runat="server" GridLines="Both"
            DataKeyNames="GroupId" AllowPaging="True" Width="63%" CellPadding="2" AutoGenerateColumns="false" PageSize="10"
             OnRowDeleting="datagrid_RowDeleting" OnRowCancelingEdit="datagrid_RowCancelingEdit" OnPageIndexChanging="datagrid_PageIndexChanging" OnRowDataBound="datagrid_RowDataBound" OnRowEditing="datagrid_RowEditing" OnRowUpdating="datagrid_RowUpdating" CellSpacing="5">
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
                <asp:TemplateField HeaderText=" Group Name" HeaderStyle-CssClass="hederstyle">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtgname" Text='<%# Bind("GroupName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%# Bind("GroupName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit Here" CommandName="Edit" CssClass="btn btn-tertiary mr-xs mb-sm btncss" />
                        <asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-tertiary mr-xs mb-sm btncss" /> 
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

