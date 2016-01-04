<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ImportedStock.aspx.cs" Inherits="Benetton.ImportFromExcel.ImportedStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= updProgress.ClientID %>");
            var uploader = $get("<%= impImage.ClientID%>");
            if ($("#<%=txtInvoiceNo.ClientID%>").val() == "" || $("#<%=txtAirwayBillNo.ClientID%>").val() == "" || uploader.value == "") {
                updateProgress.style.display = "none";
            } else {
                updateProgress.style.display = "block";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
            <asp:UpdateProgress ID="updProgress" runat="server" AssociatedUpdatePanelID="updForm"
                ClientIDMode="Static">
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
           
            <div class="contentpanel">
                 <div style="width: 13%; float: right;">
                <div style="float: left; border-bottom: 1px solid; border-bottom-color: blue">
                    <asp:LinkButton ID="lnkDownload" runat="server" Text="Download Import Format" ForeColor="blue"
                        OnClick="lnkDownload_OnClick"></asp:LinkButton>
                </div>
            </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="well mt10">
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label class="control-label">
                                            Branch
                                        </label>
                                        <asp:DropDownList runat="server" ID="ddlBranch" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label class="control-label">
                                            Season</label>
                                        <asp:DropDownList runat="server" ID="ddlSeason" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <div class="form-group">
                                        <label class="control-label">
                                            Invoice No.</label>
                                        <asp:TextBox runat="server" ID="txtInvoiceNo" CssClass="form-control" ClientIDMode="Static" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label class="control-label">
                                            Airway Bill No.</label>
                                        <asp:TextBox runat="server" ID="txtAirwayBillNo" CssClass="form-control" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label class="control-label">
                                            File</label>
                                        <asp:FileUpload ID="impImage" runat="server" CssClass="form-control" required />
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <div class="form-group">
                                        <label class="control-label">
                                            &nbsp;
                                        </label>
                                        <asp:Button ID="btnSubmit" CssClass="btn btn-primary form-control" runat="server"
                                            Text="Import" OnClick="btnSubmit_Click" OnClientClick="showProgress();return confirm('Confirm to Import?');" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
            <asp:PostBackTrigger ControlID="lnkDownload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
