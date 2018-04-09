<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="Bulk_upload.aspx.cs" Inherits="Vender_Bulk_upload"  EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div runat="server" id="main" style="border-top:solid;">
        
    <asp:Label runat="server" ID="lblmsg" Text="Click on Browse Button For Bulk Uploading"></asp:Label>
    <asp:FileUpload runat="server" ID="fpfile" />
    <br />
    <asp:Button runat="server" id="btnupload" Text="Upload" CssClass="btn btn-borders btn-primary btn-lg" OnClick="btnupload_Click"/>
    </div>
</asp:Content>

