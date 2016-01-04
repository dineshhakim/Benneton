<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ChildMenuSetup.aspx.cs" Inherits="Benetton.Menu.ChildMenuSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
          <%--  <div class="pageheader">
                <div class="media">
                    <div class="pageicon pull-left">
                        <i class="fa fa-user"></i>
                    </div>
                    <div class="media-body">
                        <ul class="breadcrumb">
                            <li>
                                <a href='<%= ResolveUrl("~/DashBoard.aspx")%>'>
                                    <i class="glyphicon glyphicon-home"></i>
                                </a>
                            </li>
                            <li>
                                <a href="#">Menu Setting</a>
                            </li>
                            <li>Child Menu Setup</li>
                        </ul>
                        <h4>Child Menu Setup</h4>
                    </div>
                </div>
            </div>--%>
            <div class="contentpanel">
                <div class="row">
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
                                        <label class="control-label">
                                            Main Menu
                                        </label>
                                        <asp:DropDownList ID="ddlMainManu" runat="server" CssClass="form-control" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlMainManu_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label class="control-label">
                                            Child Menu Name
                                        </label>
                                        <asp:TextBox ID="txtChildMenuName" runat="server" CssClass="form-control"> </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label class="control-label">
                                            Order
                                        </label>
                                        <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control"> </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label class="control-label">
                                            Child Menu Url
                                        </label>
                                        <asp:TextBox ID="txtChildMenuUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <div class="form-group">
                                        <label class="control-label">&nbsp;</label>
                                        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-primary form-control" CommandName="Save"
                                            OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="pull-right">
                        </div>
                        <h3 class="xlg-title">Child Menu List</h3>
                        <div class="table-responsive">
                            <asp:GridView ID="gvChildMenu" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                                CssClass="table table-bordered table-hover table-dark" DataKeyNames="ChildMenuID" ShowHeaderWhenEmpty="True"
                                PageSize="20" OnPageIndexChanging="gvChildMenu_PageIndexChanging"
                                OnRowCommand="gvChildMenu_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Main Menu">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMainMenu" runat="server" Text='<%#Bind("MainMenuName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Child Menu">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChildMenu" runat="server" Text='<%#Bind("ChildMenuName") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnChildMenu" runat="server" Value='<%# Bind("ChildMenuID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder" runat="server" Text='<%#Bind("Odr") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Child Menu URL">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNavigate" runat="server" Text='<%#Bind("NavigationURL") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/Edit.png" ToolTip="Edit"
                                                Height="20px" ImageAlign="Middle" CommandName="Editone" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete1" ImageUrl="~/Images/Delete.png"
                                                Height="20px" ToolTip="Delete" ImageAlign="Middle" OnClientClick="return confirm('Confirm Delete?')"
                                                CommandArgument='<%#Bind("ChildMenuID" ) %>' />
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
            <asp:HiddenField ID="hdnMainID" runat="server" />
            <asp:HiddenField ID="hdnChildID" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
