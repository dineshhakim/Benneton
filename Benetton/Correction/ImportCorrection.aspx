﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ImportCorrection.aspx.cs" Inherits="Benetton.Correction.ImportCorrection" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .popup
        {
            background-color: #F1F1F1;
            -moz-border-radius: 2px;
            border: 1px solid;
            width: 900px;
            font-size: 16px;
            height: 500px;
            overflow: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="updProgress" runat="server" AssociatedUpdatePanelID="updForm">
                <ProgressTemplate>
                    <div class="outerDiv">
                    </div>
                    <div class="innerDiv" title="Processing your Request...">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
            <div class="form_inner">
                <ul>
                    <li>
                        <label>
                            Branch</label>
                        <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                    </li>
                    <li>
                        <label>
                            Season
                        </label>
                        <asp:DropDownList ID="ddlSeason" runat="server">
                        </asp:DropDownList>
                    </li>
                    <li>
                        <label>
                            Date</label>
                        <asp:TextBox ID="txtDate" runat="server" required="required"></asp:TextBox>
                    </li>
                </ul>
                <div class="clear">
                </div>
                <div class="btn_sec">
                    <asp:Button ID="btnShow" runat="server" CssClass="button" Text="Show" OnClick="btnShow_Click" />
                </div>
                <asp:GridView ID="gvOrderList" runat="server" CssClass="table1" ShowHeaderWhenEmpty="true"
                    EmptyDataText="There is No Data To Display..!!" AutoGenerateColumns="false" OnRowCommand="gvOrderList_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="S.N.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice No">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%#Bind("InvoiceNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Airway Bill No">
                            <ItemTemplate>
                                <asp:Label ID="lblAirwayBillNo" runat="server" Text='<%#Bind("AirwayBillNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkView" runat="server" OnClientClick="handleSubmit();" Text="View"
                                    Height="20px" CommandName="View1" CommandArgument='<%#Eval("InvoiceNo") %>'>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" Height="20px" CommandName="Delete1"
                                    CommandArgument='<%#Eval("InvoiceNo") %>' OnClientClick="handleSubmit(); return confirm('Confirm Delete?'); "></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle CssClass="alt" />
                    <PagerStyle CssClass="pgr" />
                </asp:GridView>
                <cc1:ModalPopupExtender ID="mpeDetails" ClientIDMode="Static" runat="server" TargetControlID="hfValue"
                    CancelControlID="imgClose" PopupControlID="pnlDetails">
                </cc1:ModalPopupExtender>
                <asp:HiddenField ID="hfValue" runat="server" />
                <asp:Panel ID="pnlDetails" runat="server">
                    <div class="popup">
                        <table style="width: 100%; font-size: 16px;">
                            <tr>
                                <td>
                                    Invoice No:
                                    <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: right; width: 50%" colspan="3">
                                    <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/Images/close.png" />
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="gvOrderedDetails" runat="server" CssClass="table1" ShowHeaderWhenEmpty="true"
                            EmptyDataText="There Is No Data To Display..!!" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Document No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocNo" runat="server" Text='<%# Bind("DocNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="StockNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStockNo" runat="server" Text='<%# Bind("StockNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gender">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblGender" Text='<%#Bind("Gender") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCategory" Text='<%#Bind("Category") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item Description">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblItemDescr" Text='<%#Bind("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Style">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblStyle" Text='<%#Bind("Style") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Color">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblColor" Text='<%#Bind("Color") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Size">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblSize" Text='<%#Bind("Size") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblQty" Text='<%#Bind("Qty") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ItemRate">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblItemRate" Text='<%#Bind("ItemRate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mrp (INR)">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblMrpInr" Text='<%#Bind("MRPINR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mrp (NPR)">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblMrpNpr" Text='<%#Bind("MRPNPR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
