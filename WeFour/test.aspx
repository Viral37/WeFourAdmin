<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
     <asp:DataList ID="DataList1" runat="server" Width="100%" OnItemDataBound="DataList1_ItemDataBound">
            <ItemTemplate>
                <div style="width: 100%; float: left;">
                    <div style="width: 20%; float: left;">
                        <asp:Label ID="AttType" runat="server" Text='<%# Eval("MAttributeName") %>' />
                        <asp:HiddenField ID="HideType" runat="server" Value='<%# Eval("ToolName") %>' />
                    </div>
                    <div style="width: 80%; float: left;">
                        <asp:TextBox ID="TextType" runat="server" CssClass="form-control"></asp:TextBox><br />
                        <%--<asp:RadioButton runat="server" CssClass="form-control" ID="Rediotype" />--%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:Button ID="btnInsert" runat="server" Text="Insert"/><br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>


</asp:Content>

