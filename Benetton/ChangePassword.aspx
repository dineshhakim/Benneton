<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="Benetton.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <div class="pageLeft">
                <asp:Panel ID="pnlMsgBox" runat="server">
                </asp:Panel>
            </div>
            <div class="pageRight">
                <fieldset class="fieldsetCss">
                    <legend class="legendCss">Change Password</legend>
                    <table class="table">
                        <tr>
                            <td>
                                Current Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtCurrentPwd" runat="server" CssClass="txtbox" OnTextChanged="txtCurrentPwd_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                New Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPwd" runat="server" CssClass="txtbox" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Confirm Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfirmPwd" runat="server" CssClass="txtbox" TextMode="Password"></asp:TextBox>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtNewPwd"
                                    ControlToValidate="txtConfirmPwd" Display="Dynamic" ErrorMessage="The New Password and Confirm Password must match."
                                    ValidationGroup="Save">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="Save" OnClick="btnSave_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
