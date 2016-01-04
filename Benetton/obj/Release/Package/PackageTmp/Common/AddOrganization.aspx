<%@ Page Title="Add Organization" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddOrganization.aspx.cs" Inherits="Benetton.Common.AddOrganization" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/nepali.datepicker.js" type="text/javascript"></script>
    <link href="../Styles/nepali.datepicker.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/JScript.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $(".number").ForceNumericOnly();
            $("#txtDate").nepaliDatePicker({ changeYear: true });
            $j("#txtDate").val(getNepaliDate());
            $("#btn_insert").click(function () {
                return $("#pnlDetails").validation();

            });

        });
        function pageLoad() {
            $("#txtDate").nepaliDatePicker({ changeYear: true });
            $("#btn_insert").click(function () {
                return $("#pnlDetails").validation();

            });
        }
    </script>
    <style type="text/css">
        #ndp-nepali-box
        {
            left: 800px !important;
            top: 230px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
            <fieldset class="fieldsetCss">
                <legend class="legendCss">Company Info</legend>
                <asp:Panel ID="pnlDetails" runat="server" ClientIDMode="Static">
                    <table>
                        <tr>
                            <td>
                                Company Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="txtbox req"></asp:TextBox>
                            </td>
                            <td>
                                Pan No:
                            </td>
                            <td>
                                <asp:TextBox ID="txtPanNo" runat="server" CssClass="txtbox req"></asp:TextBox>
                            </td>
                            <td>
                                Registration No:
                            </td>
                            <td>
                                <asp:TextBox ID="txtRegistrationNo" runat="server" CssClass="txtbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Logo:
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" CssClass="txtbox" runat="server" />
                            </td>
                            <td>
                                Images Path:
                            </td>
                            <td>
                                <asp:TextBox ID="txtImagesDrive" runat="server" Text="D:\" CssClass="txtbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Address1:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress1" runat="server" CssClass="txtbox req"></asp:TextBox>
                            </td>
                            <td>
                                Address2:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress2" runat="server" CssClass="txtbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Country:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCountry" runat="server" CssClass="txtbox req" Text="Nepal"></asp:TextBox>
                            </td>
                            <td>
                                City:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server" CssClass="txtbox req"></asp:TextBox>
                            </td>
                            <td>
                                State:
                            </td>
                            <td>
                                <asp:TextBox ID="txtState" runat="server" CssClass="txtbox req"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Telephone No:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelephoneNo" runat="server" CssClass="txtbox"></asp:TextBox>
                            </td>
                            <td>
                                Web Address:
                            </td>
                            <td>
                                <asp:TextBox ID="txtWebAddress" runat="server" CssClass="txtbox">  </asp:TextBox>
                            </td>
                            <td>
                                Email Address:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="txtbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Cash Amount:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCash" runat="server" CssClass="txtbox number" Text="0"></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCash"
                                    Display="Dynamic" ErrorMessage="*" Font-Size="XX-Small" MaximumValue="99999999"
                                    MinimumValue="0" Type="Double" ValidationGroup="validateCompany" SetFocusOnError="true"></asp:RangeValidator>
                            </td>
                            <td>
                                Date:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDate" ClientIDMode="Static" runat="server" CssClass="txtbox req"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                User Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="txtbox req" Text></asp:TextBox>
                            </td>
                            <td>
                                Password:
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="txtbox" TextMode="Password"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </fieldset>
            <fieldset class="fieldsetCss">
                <legend class="legendCss">Contact Person Info</legend>
                <table>
                    <tr>
                        <td>
                            Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactPersonName" runat="server" CssClass="txtbox"></asp:TextBox>
                        </td>
                        <td>
                            Tel No.
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelNo" runat="server" CssClass="txtbox"></asp:TextBox>
                        </td>
                        <td>
                            Mob No
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobNo" runat="server" CssClass="txtbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Contact Address
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactAddress" runat="server" CssClass="txtbox" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td>
                            Email
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmailAdd" runat="server" CssClass="txtbox"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset class="fieldsetCss">
                <legend class="legendCss">A/C Info</legend>
                <table>
                    <tr>
                        <td>
                            Nostro A/C With NCB
                        </td>
                        <td>
                            <asp:TextBox ID="txtNostroAcNCB" runat="server" CssClass="txtbox"></asp:TextBox>
                        </td>
                        <td>
                            Mirror A/C of NCB
                        </td>
                        <td>
                            <asp:TextBox ID="txtMirrorNCB" runat="server" CssClass="txtbox"></asp:TextBox>
                        </td>
                        <td>
                            Mirror A/C of Drose Tech.
                        </td>
                        <td>
                            <asp:TextBox ID="txtMirrorDrose" runat="server" CssClass="txtbox"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <table style="width: 100%">
                <tr>
                    <td style="width: 80%">
                        <asp:UpdateProgress ID="updProgress" runat="server">
                            <ProgressTemplate>
                                <img src="../Images/ajax-loader.gif" alt="Loading..." />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                    <td>
                        <asp:Button ID="btn_insert" runat="server" Text="Insert" ClientIDMode="Static" OnClick="btn_insert_Click"
                            CommandName="Insert" CssClass="Button" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" ClientIDMode="Static" OnClick="btnCancel_Click"
                            CssClass="Button" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
