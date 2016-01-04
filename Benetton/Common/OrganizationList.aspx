<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="OrganizationList.aspx.cs" Inherits="Benetton.Common.OrganizationList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/jquery.js"></script>
    <script src="../Scripts/jquery.tablesorter.js" type="text/javascript"></script>
    <style type="text/css">
        .header
        {
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#gvCompany").tablesorter();
        });
        function pageLoad(sender, args) {

            $("#gvCompany").tablesorter();

        }

        function pageLoad(sender, args) {
            if (!args.get_isPartialLoad()) {
                //  add our handler to the document's
                //  keydown event
                $addHandler(document, "keydown", onKeyDown);
            }
        }

        function onKeyDown(e) {
            if (e && e.keyCode == Sys.UI.Key.esc) {
                // if the key pressed is the escape key, dismiss the dialog
                $find('mpeDetails').hide();
            }
        } 

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <fieldset class="fieldsetCss">
                <legend class="legendCss">Search</legend>
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtCompanyCode" runat="server" placeholder="Company Code"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompanyName" runat="server" placeholder="Company Name"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="Button" Text="Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset class="fieldsetCss">
                <legend class="legendCss">Organization List</legend>
                <asp:GridView ID="gvCompany" runat="server" ClientIDMode="Static" AutoGenerateColumns="false"
                    ShowHeaderWhenEmpty="true" CssClass="grid" OnRowCommand="gvCompany_RowCommand"
                    PageSize="40" AllowPaging="true" OnPageIndexChanging="gvCompany_PageIndexChanging"
                    RowStyle-HorizontalAlign="Left" OnRowDataBound="gvCompany_RowDataBound">
                    <RowStyle CssClass="row" />
                    <AlternatingRowStyle CssClass="altrow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Company Code">
                            <ItemTemplate>
                                <asp:Label ID="lblComanyCode" runat="server" Text='<%# Bind("COMPANY_CODE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company Name">
                            <ItemTemplate>
                                <asp:Label ID="lblCompanyName" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Adress1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City">
                            <ItemTemplate>
                                <asp:Label ID="lblCity" runat="server" Text='<%#  Eval("City")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/edit.png" ToolTip="Edit"
                                    Height="15px" ImageAlign="Middle" CommandName="Edit1" CausesValidation="false"
                                    CommandArgument='<%# BIND("COMPANY_CODE") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnView" runat="server" ImageUrl="~/Images/view.ico" ToolTip="View Details"
                                    Height="15px" ImageAlign="Middle" CommandName="View1" CausesValidation="false"
                                    CommandArgument='<%# BIND("COMPANY_CODE") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </fieldset>
            <cc1:ModalPopupExtender ID="mpeDetails" ClientIDMode="Static" runat="server" TargetControlID="hfValue"
                CancelControlID="imgClose" PopupControlID="pnlDetails">
            </cc1:ModalPopupExtender>
            <asp:HiddenField ID="hfValue" runat="server" />
            <asp:Panel ID="pnlDetails" runat="server">
                <div class="popup">
                    <table style="width: 96%">
                        <tr>
                            <td style="text-align: right">
                                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/Images/close.png" />
                            </td>
                        </tr>
                    </table>
                    <fieldset class="fieldsetCss">
                        <legend class="legendCss">Company Info</legend>
                        <table style="width: 95%">
                            <tr>
                                <td>
                                    Code:
                                </td>
                                <td>
                                    <asp:Label ID="lblCode" runat="server"></asp:Label>
                                </td>
                                <td>
                                    Company Name:
                                </td>
                                <td>
                                    <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Pan No:
                                </td>
                                <td>
                                    <asp:Label ID="txtPanNo" runat="server"></asp:Label>
                                </td>
                                <td>
                                    Images Path:
                                </td>
                                <td>
                                    <asp:Label ID="txtImagesDrive" runat="server" Text="D:\"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Address1:
                                </td>
                                <td>
                                    <asp:Label ID="txtAddress1" runat="server"></asp:Label>
                                </td>
                                <td>
                                    Address2:
                                </td>
                                <td>
                                    <asp:Label ID="txtAddress2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Country:
                                </td>
                                <td>
                                    <asp:Label ID="txtCountry" runat="server" Text="Nepal"></asp:Label>
                                </td>
                                <td>
                                    City:
                                </td>
                                <td>
                                    <asp:Label ID="txtCity" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    State:
                                </td>
                                <td>
                                    <asp:Label ID="txtState" runat="server"></asp:Label>
                                </td>
                                <td>
                                    Telephone No:
                                </td>
                                <td>
                                    <asp:Label ID="txtTelephoneNo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Web Address:
                                </td>
                                <td>
                                    <asp:Label ID="txtWebAddress" runat="server">  </asp:Label>
                                </td>
                                <td>
                                    Email Address:
                                </td>
                                <td>
                                    <asp:Label ID="txtEmailAddress" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Date:
                                </td>
                                <td>
                                    <asp:Label ID="txtDate" ClientIDMode="Static" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset class="fieldsetCss">
                        <legend class="legendCss">Contact Person Info</legend>
                        <table style="width: 95%">
                            <tr>
                                <td>
                                    Name:
                                </td>
                                <td>
                                    <asp:Label ID="txtContactPersonName" runat="server"></asp:Label>
                                </td>
                                <td>
                                    Tel No.:
                                </td>
                                <td>
                                    <asp:Label ID="txtTelNo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mob No:
                                </td>
                                <td>
                                    <asp:Label ID="txtMobNo" runat="server"></asp:Label>
                                </td>
                                <td>
                                    Address:
                                </td>
                                <td>
                                    <asp:Label ID="txtContactAddress" runat="server" TextMode="MultiLine"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email:
                                </td>
                                <td>
                                    <asp:Label ID="txtEmailAdd" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset class="fieldsetCss">
                        <legend class="legendCss">A/C Info</legend>
                        <table style="width: 95%">
                            <tr>
                                <td>
                                    Nostro A/C With NCB:
                                </td>
                                <td>
                                    <asp:Label ID="txtNostroAcNCB" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mirror A/C of NCB:
                                </td>
                                <td>
                                    <asp:Label ID="txtMirrorNCB" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mirror A/C of Drose Tech.:
                                </td>
                                <td>
                                    <asp:Label ID="txtMirrorDrose" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
