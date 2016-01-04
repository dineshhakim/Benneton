<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MenuAssign.aspx.cs" Inherits="Benetton.Menu.MenuAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
           
            <div class="contentpanel">
                <div class="col-sm-12">
                    <h5 class="md-title">Menu Settings</h5>
                    <div class="btn-list">
                        <a class="btn btn-info" href='<%= ResolveUrl("~/Menu/MainMenuSetup.aspx")%>'>Main Menu Setup</a>
                        <a class="btn btn-primary" href='<%= ResolveUrl("~/Menu/ChildMenuSetup.aspx")%>'>Child Menu Setup</a>
                        <a class="btn btn-warning" href='<%= ResolveUrl("~/Menu/MenuAssign.aspx")%>'>Assign Menu</a>
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="well mt10">
                        <div class="row">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class="control-label">Role Name</label>
                                    <asp:DropDownList ID="ddlRoleName" runat="server" AutoPostBack="True" CssClass="form-control"
                                        OnSelectedIndexChanged="ddlRoleName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class="control-label">
                                        Main Menu
                                    </label>
                                    <asp:DropDownList ID="ddlMainMenu" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                        CssClass="form-control" OnSelectedIndexChanged="ddlMainMenu_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-1">
                                <div class="form-group">
                                    <label class="control-label">&nbsp;</label>
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" OnClick="btnSave_Click"
                                        Text="Save" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-md-6">
                            <h4 class="xlg-title mb10">Unassigned Menu </h4>
                            <div class="table-responsive">
                                <asp:GridView ID="gvAllMenu" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                                    CssClass="table table-bordered table-hover table-dark"
                                    ShowHeaderWhenEmpty="True" EmptyDataText="There Is No Data To Display..!!"
                                    PageSize="20">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkMenu" runat="server" OnClick="selectAll(this)" />
                                                <asp:HiddenField ID="hdChildMenuID" runat="server" Value='<%#Bind("ChildMenuID") %>' />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="cbSelectAll" runat="server" OnClick="selectAll(this)" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Menu Name" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Bind("MenuName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Records yet!
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <h4 class="xlg-title mb10">Assigned Menu </h4>
                            <div class="table-responsive">

                                <asp:GridView ID="gvAssignedMenu" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                                    ShowHeaderWhenEmpty="true" EmptyDataText="There Is No Data To Display..!!" CssClass="table table-bordered table-hover table-dark"
                                    PageSize="20" OnRowCommand="gvAssignedMenu_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkTransfer" runat="server" OnClick="selectAll1(this)" />
                                                <asp:HiddenField ID="hdchildMenuID" runat="server" Value='<%#Bind("ID") %>' />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="cbSelectAll" runat="server" OnClick="selectAll(this)" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Child ID" ItemStyle-HorizontalAlign="Center" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChildID" runat="server" Text='<%#Bind("ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Menu Name" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Bind("MenuName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete1" ImageUrl="~/Images/Delete.png"
                                                    Height="20px" ToolTip="Delete" ImageAlign="Middle" OnClientClick="return confirm('Confirm Delete?')"
                                                    CommandArgument='<%#Bind("ID" ) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Records yet!
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function selectAll(invoker) {
            var chk = document.getElementById("<%= gvAllMenu.ClientID %>");
            var cbl = document.getElementById('<%=gvAllMenu.ClientID %>').getElementsByTagName("input");
            for (i = 0; i < cbl.length; i++) cbl[i].checked = invoker.checked;
        }
        function selectAll1(invoker) {
            var chk = document.getElementById("<%= gvAssignedMenu.ClientID %>");
            var cbl = document.getElementById('<%=gvAssignedMenu.ClientID %>').getElementsByTagName("input");
            for (i = 0; i < cbl.length; i++) cbl[i].checked = invoker.checked;
        }
    </script>
</asp:Content>
