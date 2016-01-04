<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DayEnd.aspx.cs" Inherits="Benetton.Management.DayEnd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="updProgress" runat="server" AssociatedUpdatePanelID="updForm">
                <ProgressTemplate>
                    <div class="outerDiv1">
                    </div>
                    <div class="innerDiv1" title="Processing your Request...">
                        <div style="margin-top: 7%; margin-left: 40%; margin-right: 10%; margin-bottom: 10%;
                            font-family: Verdana; font-size: medium;">
                            Processing...
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
            <asp:Panel ID="PanelForSubmit" runat="server" DefaultButton="clrSession">
                    <div class="form_inner">
                        <h2>
                            Day End</h2>
                        <div class="clear">
                        </div>
                        <ul>
                            <li>
                                <asp:Label ID="lbltextclosed" runat="server" ForeColor="Blue"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="lblclosedate" runat="server" ForeColor="Blue"></asp:Label>
                            </li>
                            <div class="clear">
                            </div>
                           
                            <li>&nbsp;
                                <asp:Button runat="server" ID="clrSession" Text="Clear Session" OnClick="clrSession_Click"
                                    CssClass="btn" Width="200px" /></li>
                            <div class="clear">
                            </div>
                           
                        </ul>
                        <div class="clear">
                        </div>
                        <div class="btn_sec">
                            <asp:Button ID="btnSubmit" CssClass="button"  runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                Enabled="false" />
                           
                        </div>
                      </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
