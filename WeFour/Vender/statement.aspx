<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="statement.aspx.cs" Inherits="Vender_statement" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section class="section section-default">
        <div class="container-fulid">
            <div class="form-group">
                <div class="col-md-3">

                    <label class="col-md-4 control-label">Select Account</label>
                    <div class="col-md-5">
                        <select data-plugin-selecttwo class="form-control populate">
                            <optgroup>
                                <option value="all">All</option>
                                <option value="cash">Cash</option>
                                <option value="bank">Bank</option>
                            </optgroup>
                        </select>
                    </div>
                </div>
                <div class="col-md-6">
                    <label class="col-md-4 control-label">Select Date range</label>
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                    <asp:PopupControlExtender ID="PopupControlExtender1" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="Panel1" Position="Top" TargetControlID="txtstart"></asp:PopupControlExtender>
                    <asp:PopupControlExtender ID="PopupControlExtender_end" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="Panel2" Position="Top" TargetControlID="txtend"></asp:PopupControlExtender>
                    <div class="col-md-8">
                        <div class="input-daterange input-group" data-plugin-datepicker>
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                            <asp:TextBox runat="server" type="text" class="form-control" name="start" Text="From" ID="txtstart"></asp:TextBox>
                            <span class="input-group-addon">to</span>
                            <asp:TextBox runat="server" type="text" class="form-control" name="end" ID="txtend" Text="End"></asp:TextBox>

                            <asp:Panel ID="Panel1" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Calendar runat="server" ID="cal" OnSelectionChanged="cal_SelectionChanged" BorderWidth="0" BackColor="#f4f4da" EnableKeyboardNavigation="true" EnableMultiSelect="false" Skin="Metro"></asp:Calendar>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:Panel>

                            <asp:Panel ID="Panel2" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Calendar runat="server" ID="calend" OnSelectionChanged="calend_SelectionChanged" BorderWidth="0" BackColor="#f4f4da" EnableKeyboardNavigation="true" EnableMultiSelect="false" Skin="Metro"></asp:Calendar>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </div>
                    </div>
                </div>

                <asp:Button CssClass="btn btn-sm" runat="server" ID="btngenrate" Text=" Genrate " OnClick="btngenrate_Click" />
                <asp:Button runat="server" CssClass="btn btn-sm" ID="genratepdf" Text="Genrate PDF" OnClick="genratepdf_Click"/>
            
            </div>
            <asp:Label  ID="lblerror" runat="server"></asp:Label>
            <div  id="datatable" runat="server" visible="false">
                
            <table class="table table-bordered align-center" style="background-color:#FFFFFF" >
                <thead>
                    <tr class="success" >
                        <th>Description
                        </th>
                        <th>Credits(Rs)
                        </th>
                        <th>Debits(Rs)
                        </th>
                        <th>Net Setteld Amount(Rs)
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Total Selling Amount
                        </td>
                        <td><asp:Label runat="server" ID="totalsellprice"></asp:Label>
                        </td>
                        <td>
                            -
                        </td>
                        <td>-
                        </td>
                    </tr>
                    <tr>
                        <td>Commission Amount
                        </td>
                        <td>
                            -
                        </td>
                        <td><asp:Label runat="server" ID="totcommsion"></asp:Label>
                        </td>
                        <td>-
                        </td>
                    </tr>
                    <tr>
                        <td>Fixed Fee Amount
                        </td>
                        <td>
                            -
                        </td>
                        <td><asp:Label runat="server" ID="netfixedfee"></asp:Label></td>
                        <td>-
                        </td>
                    </tr>
                    <tr>
                        <td>Collection Fee 
                        </td>
                        <td>
                            -
                        </td>
                        <td><asp:Label runat="server" ID="collectionlb"></asp:Label></td>
                        <td>-
                        </td>
                    </tr>
                    <tr>
                        <td>Cancellation Fee 
                        </td>
                        <td>
                            -
                        </td>
                        <td><asp:Label runat="server" ID="cancellationlb"></asp:Label>
                        <td>-
                        </td>
                    </tr>
                    <tr>
                        <td>Shipment Amount
                        </td>
                        <td>
                            -
                        </td>
                        <td><asp:Label runat="server" ID="totshipment"></asp:Label>
                        </td>
                        <td >
                            -
                        </td>
                    </tr>
                     <tr>
                        <td>Total Net Amount
                        </td>
                        <td>
                            -
                        </td>
                        <td>-
                        </td>
                        <td >
                            <asp:Label runat="server" ID="nsetamt" style="color:blue"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            </div>

            

            <asp:Label runat="server" ID="startdate"></asp:Label><br />
            <asp:Label runat="server" ID="enddate"></asp:Label><br />
            <asp:Label runat="server" ID="countlb"></asp:Label>
           
            
        </div>
    </section>
</asp:Content>

