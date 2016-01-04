<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BankSetup.aspx.cs" Inherits="Benetton.Settings.BankSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">

        function IsBankAccountnoExists(Code) {

            PageMethods.IsBankAccountnoExists(Code, onSucess, onError);

            function onSucess(result) {
                if (result == false) {
                    alert('Account No Doesnt Exist!!!');
                    document.getElementById('btn_submit').attributes.add("ReadOnly", true);
                }
            }
            function onError(result) {
                alert('Invalid bank');
            }
        }

        function ShowHideDiv(vaue1) {
            if (vaue1 == 1) {
                hideAccountDetails();
            }
            else if (vaue1 == 2) {
                showAccountDetails();
            }
            else {
                show();
            }

        }
        function show() {
            document.getElementById('divAccountType').style.display = 'block';
            document.getElementById('divMaturity').style.display = 'block';
        }
        function hide() {
            document.getElementById('divMaturity').style.display = 'none';
        }

        function showAccountDetails() {
            document.getElementById('divAccountType').style.display = 'block';
            document.getElementById('divMaturity').style.display = 'none';
        }
        function hideAccountDetails() {
            document.getElementById('divAccountType').style.display = 'none';
            document.getElementById('divMaturity').style.display = 'none';
        }


        function IsEnoughCash(Code1) {
            var Code = $('#<%=ddlBranch.ClientID%>').val();
            PageMethods.IsEnoughCash(Code, Code1, onSucess, onError);
            function onSucess(result) {
                if (result == false) {
                    alert('Insufficient Cash Amount!!!');
                    $('#<%=btn_submit.ClientID%>').attributes.add("Disabled", true);
                }
            }
            function onError(result) {
                alert('Invalid');
            }
        }
        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $(".number").ForceNumericOnly();
            });

            function pageLoad() {
                $(".number").ForceNumericOnly();
            }
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
            <div class="form_inner">
                <ul>
                    <li>
                        <label>
                            Branch
                        </label>
                        <asp:DropDownList ID="ddlBranch" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                            <%--<asp:ListItem Value="-1">- - -select- - -</asp:ListItem>--%>
                        </asp:DropDownList>
                    </li>
                    <li>
                        <label>
                            Bank Name
                        </label>
                        <asp:TextBox ID="txt_BankName" runat="server" required="true"></asp:TextBox>
                    </li>
                    <li>
                        <label>
                            Account Number
                        </label>
                        <asp:TextBox ID="txt_AccountNo" runat="server" required="true"></asp:TextBox>
                    </li>
                    <li>
                        <label>
                            Bank Class
                        </label>
                        <asp:DropDownList ID="ddl_class" runat="server">
                            <asp:ListItem Value="NRB">NRB</asp:ListItem>
                            <asp:ListItem Value="A">A Class</asp:ListItem>
                            <asp:ListItem Value="B">B Class</asp:ListItem>
                            <asp:ListItem Value="C">C Class</asp:ListItem>
                            <asp:ListItem Value="D">D Class</asp:ListItem>
                            <asp:ListItem Value="E">E Class</asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li>
                        <label>
                            Opening Date
                        </label>
                        <asp:TextBox ID="txt_OpeningDate" runat="server" ReadOnly="true" required="true"></asp:TextBox>
                    </li>
                    <li>
                        <label>
                            Account Type
                        </label>
                        <asp:DropDownList ID="ddlaccounttype" runat="server" OnSelectedIndexChanged="ddlaccounttype_SelectedIndexChanged"
                            AutoPostBack="True">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">Current</asp:ListItem>
                            <asp:ListItem Value="2">Call</asp:ListItem>
                            <asp:ListItem Value="3">FD</asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <asp:Panel ID="pnlFD" runat="server" Visible="False">
                        <li>
                            <label>
                                Total Amount
                            </label>
                            <asp:TextBox ID="txtAmount" CssClass="number" runat="server" onchange="IsEnoughCash(this.value);"
                                AutoPostBack="True" disabled="true"></asp:TextBox>
                        </li>
                        <li>
                            <label>
                                Maturity Date
                            </label>
                            <asp:TextBox ID="txtMaturityDate" runat="server" required="true"></asp:TextBox>
                        </li>
                        <li>
                            <label>
                                Interest Accumulation A/c
                            </label>
                            <asp:TextBox ID="txtinterestaccumulation" onchange="IsBankAccountnoExists(this.value)"
                                runat="server" required="true"></asp:TextBox>
                        </li>
                        <li>
                            <label>
                                Mode of Payment
                            </label>
                            <asp:DropDownList ID="ddlmodeofpayment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlmodeofpayment_SelectedIndexchanged">
                                <asp:ListItem>Cash</asp:ListItem>
                                <asp:ListItem>Bank</asp:ListItem>
                            </asp:DropDownList>
                        </li>
                        <asp:Panel ID="pnlSelectBank" runat="server" Visible="False">
                            <li>
                                <label>
                                    Select Bank
                                </label>
                                <asp:DropDownList ID="ddlSelectBank" runat="server" OnSelectedIndexChanged="ddlSelectBank_SelectedIndexChanged"
                                    AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="BDesc_Name"
                                    DataValueField="BDesc_ID">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CSCommonDB %>"
                                    SelectCommand="select '0' as BDesc_ID,'---Select---' as BDesc_Name union all SELECT [BDesc_ID], [BDesc_Name] FROM [BankDesc]">
                                </asp:SqlDataSource>
                            </li>
                            <li>
                                <label>
                                    Available Balance</label>
                                <asp:TextBox ID="txtavailablebalance" runat="server" Enabled="False"></asp:TextBox>
                            </li>
                        </asp:Panel>
                    </asp:Panel>
                    <asp:Panel ID="pnlAccountType" runat="server" Visible="False">
                        <li>
                            <label>
                                Rate
                            </label>
                            <asp:TextBox ID="txtRate" runat="server" CssClass="number" required="true"></asp:TextBox>
                        </li>
                        <li>
                            <label>
                                Interest Calculation Method
                            </label>
                            <asp:DropDownList ID="ddl_calMethod" runat="server" required="required" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </li>
                        <li>
                            <label>
                                Interest Accumulation Period
                            </label>
                            <asp:DropDownList ID="ddl_acc" runat="server" required="required" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </li>
                    </asp:Panel>
                </ul>
                <div class="clear">
                </div>
                <div class="btn_sec">
                    <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="Submit"
                        CssClass="button" ValidationGroup="ls" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click"
                        Visible="true" />
                    <asp:Label ID="lbl_msg" runat="server" Text="" ForeColor="Red" Font-Size="X-Small"
                        EnableViewState="False"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Blue" Font-Size="X-Small"
                        EnableViewState="False"></asp:Label>
                </div>
                <div class="form_inner">
                    <h2>
                        <asp:Label ID="lblbankList" runat="server" Text="Bank List"></asp:Label>
                        <asp:Label ID="msgSuccess" runat="server" ForeColor="Blue" Visible="false"></asp:Label>
                    </h2>
                    <div class="clr">
                    </div>
                    <asp:GridView ID="gridview_mode" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        CssClass="table1" OnRowDataBound="gridview_mode_RowDataBound" OnRowCommand="gridview_mode_RowCommand">
                        <FooterStyle CssClass="GridFooter" />
                        <RowStyle CssClass="GridItem" />
                        <Columns>
                            <asp:TemplateField SortExpression="BDesc_Name" HeaderText="Bank Name" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%# Bind("BDesc_ID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblBankName" runat="server" Text='<%# Bind("BDesc_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="BDesc_AccNo" HeaderText="Account No" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAccountNo" runat="server" Text='<%# Bind("BDesc_AccNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Opening Date" ItemStyle-HorizontalAlign="Center" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblOpeningDate" runat="server" Text='<%# Bind("Opening_Date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account Type" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAccounttype" runat="server" Text='<%# Bind("Accounttype") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bank Class" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblBankClass" runat="server" Text='<%# Bind("Class") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRate" runat="server" Text='<%# Bind("Rate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Calculation Method" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblcalmethod" runat="server" Text='<%# Bind("IntCalMethod_Desc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Accumulation Method" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblaccumulationmethod" runat="server" Text='<%# Bind("IntAcc_Desc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="MaturityDate" HeaderText="Maturity Date" HeaderStyle-HorizontalAlign="Right"
                                ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                     <asp:Label ID="lblNomineeAc" runat="server" Text='<%# Bind("NomineeAcNo") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblMaturityDate" runat="server" Text='<%# Bind("MaturityDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit1" Text="Edit" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' />
                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Delete"
                                        OnClientClick="return confirm('Are you soure to Delete?')" ToolTip="Delete" Visible="false" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="GridHeader" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                        <SelectedRowStyle CssClass="GridRowOver" />
                        <EditRowStyle />
                        <AlternatingRowStyle CssClass="GridAltItem" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
