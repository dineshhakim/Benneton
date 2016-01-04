<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CacheClear.aspx.cs" Inherits="Benetton.Settings.CacheClear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="updForm">
        <ContentTemplate>
            <asp:UpdateProgress ID="updProgress" runat="server" AssociatedUpdatePanelID="updForm">
                <ProgressTemplate>
                    <div class="outerDiv1">
                    </div>
                    <div class="innerDiv1" title="Processing...">
                        <div style="margin-top: 7%; margin-left: 40%; margin-right: 10%; margin-bottom: 10%;
                            font-family: Verdana; font-size: medium;">
                            Processing...
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
            <div class="form_inner">
                <ul>
                    <li>
                        <label>
                            Cache Key
                        </label>
                        <asp:TextBox runat="server" ID="txtCacheKey" required="required"></asp:TextBox>
                    </li>
                    <li>
                        <label>
                            &nbsp;</label>
                        <asp:Button runat="server" ID="btnClear" CssClass="btn" OnClick="btnClear_Click"
                            Text="Clear Cache" />
                    </li>
                  <%--  <li>
                        <label>
                            &nbsp;</label>
                        <asp:Button runat="server" ID="btnUserList" CssClass="btn" Text="View Active Users"
                            OnClick="btnUserList_Click" />
                    </li>--%>
                </ul>
                <asp:GridView runat="server" ID="gvActiveUsers">
                </asp:GridView>
                <asp:Label runat="server" ID="lblAuthenticatedUsers"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
