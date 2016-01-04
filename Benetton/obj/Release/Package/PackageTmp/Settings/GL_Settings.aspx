<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GL_Settings.aspx.cs" Inherits="Benetton.Settings.GL_Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <script type="text/javascript">
        $(document).ready(function () {

            $("#tabs").tabs({
                beforeLoad: function (event, ui) {
                    ui.jqXHR.error(function () {
                        ui.panel.html( "Couldn't load this tab. We'll try to fix this as soon as possible. ");
                    });
                }
            });

        });
        function pageLoad() {

            $("#tabs").tabs({
                beforeLoad: function (event, ui) {
                    ui.jqXHR.error(function () {
                        ui.panel.html("Couldn't load this tab. We'll try to fix this as soon as possible. ");
                    });
                }
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
            <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnSubmit">
                <div id="tabs">
                    <ul>
                        <li id="li1" runat="server"><a href="#a"></a>
                            <asp:LinkButton ID="lnkIncome" runat="server" Text="Income" 
                                CausesValidation="false" OnClick="LnkIncome_OnClick"></asp:LinkButton></li>
                        <li id="li2" runat="server"><a href="#a"></a>
                            <asp:LinkButton ID="LnkExpense" runat="server" Text="Expenditure"
                                CausesValidation="false" OnClick="LnkExpense_OnClick"></asp:LinkButton></li>
                        <li id="li3" runat="server"><a href="#a"></a>
                            <asp:LinkButton ID="LnkAssests" runat="server" Text="Assets" 
                                CausesValidation="false" OnClick="LnkAssests_OnClick"></asp:LinkButton></li>
                        <li id="li4" runat="server"><a href="#a"></a>
                            <asp:LinkButton ID="lnkLiability" runat="server" Text="Liability"
                                CausesValidation="false" OnClick="LnkLiability_OnClick"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:UpdateProgress ID="updProgress" runat="server" AssociatedUpdatePanelID="updForm">
                                <ProgressTemplate>
                                    <img src="../Icons/progress.gif" alt="Loading..." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </li>
                    </ul>
                    <div id="a" class="form_inner" style="min-height: 500px;">
                        <asp:HiddenField ID="hfValue" runat="server" Value="0" />
                        <h2>
                            <asp:Label ID="lblHeader" runat="server"></asp:Label>
                        </h2>
                        <div class="left" style="width: 55%; height: 480px; overflow: auto">
                            <asp:TreeView ID="tv" runat="server"  
                                Font-Size="Small" Font-Names="Bell MT" ExpandDepth="3" OnSelectedNodeChanged="tv_SelectedNodeChanged" 
                                ShowExpandCollapse="true" ShowLines="false" SelectedNodeStyle-Font-Bold="true"
                                ParentNodeStyle-ImageUrl="~/Icons/downArrow1.png" LeafNodeStyle-ImageUrl="~/Icons/rightArrow1.png"
                                SelectedNodeStyle-BorderWidth="1px" CollapseImageUrl="~/Icons/rightArrow.png">
                            </asp:TreeView>
                        </div>
                        <div class="right" style="width: 40%; height: 500px; overflow: auto; margin-right: 20px;">
                            <asp:Panel ID="pnlDetails" runat="server">
                                <ul>
                                    <li style="float: right">
                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" Font-Bold="true" Font-Underline="true" OnClick="lnkEdit_OnClick"
                                            ></asp:LinkButton>
                                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" Font-Bold="true" Font-Underline="true" OnClick="lnkDelete_OnClick"
                                             OnClientClick="Confirm('Confirm To Delete')"></asp:LinkButton>
                                    </li>
                                    <li style="width: 300px">
                                        <label>
                                            Root Topic:
                                        </label>
                                        <div class="left">
                                            <asp:TextBox ID="txtRootCode" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="right">
                                            <asp:TextBox ID="txt_roottopic" runat="server" required="required">
                                            </asp:TextBox>
                                        </div>
                                    </li>
                                    <li style="width: 300px">
                                        <label>
                                            Particular:
                                        </label>
                                        <div class="left">
                                            <asp:TextBox ID="txtParticularcode" runat="server" required="required"></asp:TextBox></div>
                                        <div class="right">
                                            <asp:TextBox ID="txtParticular" runat="server" required="required"></asp:TextBox>
                                        </div>
                                    </li>
                                    <%--<li>
                                        <label>
                                            Under
                                        </label>
                                        <asp:DropDownList ID="ddlUnder" runat="server" required="required">
                                            <asp:ListItem Value="">Select</asp:ListItem>
                                            <asp:ListItem Value="CA">Current Assets</asp:ListItem>
                                            <asp:ListItem Value="CL">Current Liablities</asp:ListItem>
                                            <asp:ListItem Value="FA">Fixed Assets</asp:ListItem>
                                        </asp:DropDownList>
                                    </li>
                                    <li>
                                        <label>
                                            Under Pearls:
                                        </label>
                                        <asp:DropDownList ID="ddlPearls" runat="server" >
                                        </asp:DropDownList>
                                    </li>--%>
                                    <li>
                                        <label>
                                            Primary
                                        </label>
                                        <asp:CheckBox ID="chkPrimary" runat="server" />
                                    </li>
                                    <li>
                                        <label>
                                            Is Needed
                                        </label>
                                        <asp:CheckBox ID="chkIsNeeded" runat="server" Checked="true" />
                                    </li>
                                </ul>
                                <div class="clear">
                                </div>
                                <div class="btn_sec">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return confirm('Confirm to save?')"
                                        CssClass="button" OnClick="BtnSubmit_OnClick" />
                                    <asp:Button ID="btnCancel" formnovalidate runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_OnClick"
                                       />
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
