<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StoreSetup.aspx.cs" Inherits="Benetton.Settings.StoreSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/filter.js" type="text/javascript"></script>
    <script type="text/javascript ">
           $(document).ready(function () {
            $('.name').filter_input({ regex: '[a-zA-Z_ ]' });
            $('.number').filter_input({ regex: '[0-9]' });
        });
    </script>
    <style type="text/css">
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .loading
        {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
            <asp:UpdateProgress ID="updProgress" runat="server" AssociatedUpdatePanelID="updForm">
                <ProgressTemplate>
                    <div class="loading" align="center">
                        Loading.... Please wait.<br />
                        <br />
                        <img src="../Images/page-loader.gif" alt="" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="form_inner">
                <ul>
                    <li>
                        <label>
                           Store No
                        </label>
                        <asp:TextBox runat="server" ID="txtStoreNo" required="required"></asp:TextBox>
                    </li>
                    <li>
                        <label>
                           Store Name
                        </label>
                        <asp:TextBox runat="server" ID="txtStoreName" required="required"></asp:TextBox>
                    </li>
                </ul>
            </div>
            <div class="clear">
            </div>
            <div class="btn_sec">
                <asp:Button runat="server" ID="btnsave" OnClick="btn_save_Click" Text="Save" ValidationGroup="Save"
                    CssClass="button" CommandName="Save" />
                <asp:Button runat="server" ID="btncancel" ValidationGroup="Cancel" CssClass="button"
                    Text="Cancel" OnClick="btncancel_Click" />
            </div>
            <div class="clear">
            </div>
            <asp:GridView runat="server" ID="gvStoreSetup" ShowHeaderWhenEmpty="True" CssClass="table1"
                OnRowDataBound="gvStoreSetup_OnRowDataBound" OnRowCommand="gvStoreSetup_RowCommand"
                EmptyDataText="There is no data to display.......!!" AutoGenerateColumns="False"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblStoreId" Text='<%#Bind("Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Store No">
                        <ItemTemplate>
                            <asp:Label ID="lblStoreNo" runat="server" Text='<%# Bind("Store_No") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Store Name">
                        <ItemTemplate>
                            <asp:Label ID="lblStoreName" runat="server" Text='<%# Bind("Store_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnedit" ImageUrl="~/Images/edit.png" Height="20px" Width="20px"
                                CommandName="edit1" formnovalidate="formnovalidate" CommandArgument='<%# Container.DataItemIndex%>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="btndelete" ImageUrl="~/Images/delete.png" Height="20px" Width="20px"
                                CommandName="delete1" formnovalidate="formnovalidate" CommandArgument='<%# Bind("Id") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

