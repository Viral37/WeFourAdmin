<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="AddAttribute.aspx.cs" Inherits="AddAttribute" %>

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
                    <h1>Add Attribute</h1>
                </div>
            </div>
        </div>
    </section>

    <div class="container-fulid" style="margin-left: 10%">

        <div class="col-md-3">
            <label>Attribute Name</label>
            <asp:TextBox runat="server" ID="txtattributename" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtattributename_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="btnbtn" runat="server" ControlToValidate="txtattributename" EnableClientScript="false" Display="Dynamic" ErrorMessage="Attribute name can't be None" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:Label runat="server" ID="attributemsg" Visible ="false" Text ="Attribute is alwaredy available." ForeColor="Red"></asp:Label>
             </div>

        <div class="col-md-3">
            <label>Type Of Attribute</label>
            <asp:DropDownList runat="server" ID="ddtype" CssClass="form-control">
                <asp:ListItem Value="Optional" Selected="True">Optional</asp:ListItem>
                <asp:ListItem Value="Required">Required</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ValidationGroup="btnbtn" runat="server" ControlToValidate="ddtype" EnableClientScript="false" Display="Dynamic" ErrorMessage="Select type Of Attribute" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

        <div class="col-md-3">
            <label>Tool For Attribute</label>
            <asp:DropDownList runat="server" ID="ddtoolname" CssClass="form-control ddcss">
                <asp:ListItem Value="TextBox" Selected="True">TextBox</asp:ListItem>
                <asp:ListItem Value="List">List</asp:ListItem>
                <asp:ListItem Value="Checkbox">Checkbox</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddtoolname" ValidationGroup="btnbtn" ErrorMessage="Select tool type of Attribute" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label runat="server" ID="lblerror" ForeColor="Red" Text="Enter Subcategory name is alwaredy availabel in system,Please enter other group name." Visible="false"></asp:Label>
        </div>

        <div class="col-md-3" style="margin-top: 2.5%">

            <button type="button" class="mb-xs mt-xs mr-xs btn btn-primary" runat="server" id="btncreate" validationgroup="btnbtn"  onserverclick="btncreate_ServerClick"><i class="fa fa-plus-circle"></i>Add Attribute</button>
        </div>
    </div>
    <hr />
    <div class="container" style="margin-left: 12%; margin-top: 2%">
        <asp:GridView ID="gdattribute" runat="server"
            DataKeyNames="AttributeId" AllowPaging="True"
            PagerStyle-CssClass="pagination" PageSize="5" Width="63%" AutoGenerateColumns="false"
            OnRowEditing="gdattribute_RowEditing" OnPageIndexChanging="gdattribute_PageIndexChanging" OnRowDeleting="gdattribute_RowDeleting" OnRowDataBound="gdattribute_RowDataBound" OnRowUpdating="gdattribute_RowUpdating" OnRowCancelingEdit="gdattribute_RowCancelingEdit">

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

                <asp:TemplateField HeaderText="Attribute Name" HeaderStyle-CssClass="hederstyle">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtattribute" Text='<%# Bind("AttributeName") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("AttributeName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Type Of Attribute" HeaderStyle-CssClass="hederstyle">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tool Used For Attribute" HeaderStyle-CssClass="hederstyle">
                    
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%# Bind("ToolName") %>'></asp:Label>
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

