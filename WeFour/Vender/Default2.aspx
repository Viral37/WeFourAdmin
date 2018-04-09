<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Vender_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:TextBox runat="server" placeholder="Enter Any number" ID="txtno1"></asp:TextBox>

    <asp:TextBox runat="server" placeholder="Enter Any number" ID="txtno2"></asp:TextBox>

    <asp:TextBox runat="server" placeholder-="Results" ID="txtresults"></asp:TextBox>

    <asp:Button runat="server" ID="txtbenadd" Text="Add" OnClick="txtbenadd_Click" />

    <asp:Button runat="server" ID="txtsub" Text="Sub" OnClick="txtsub_Click" />
</asp:Content>

