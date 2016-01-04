<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddNewUser.aspx.cs" Inherits="Benetton.Menu.AddNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
           
            <div class="contentpanel">
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Branch</label>
                                                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control" AutoPostBack="true">
                                                </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>
                                                Staff Name
                                            </label>
                                            <asp:DropDownList ID="ddlStaffName" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>
                                                Address
                                            </label>
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>
                                                Email
                                            </label>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>
                                                Contact No.
                                            </label>
                                            <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>
                                                Roles
                                            </label>
                                            <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>
                                                User Name
                                            </label>
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            <asp:Label ID="lblCompanyCode" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>
                                                Password
                                            </label>
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"
                                                required="required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>
                                                Confirm Password
                                            </label>
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword"
                                                ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                                ValidationGroup="Save">*</asp:CompareValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-footer">
                                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" CssClass="btn btn-primary"
                                    CommandName="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset Password" CommandName="Reset"
                                    CssClass="btn btn-primary" Visible="false" OnClick="btnReset_Click" />
                                <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-primary"
                                    OnClick="btncancel_Click" CausesValidation="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="gvUsers" CssClass="table table-bordered table-hover table-dark"
                                ShowHeaderWhenEmpty="true" 
                                EmptyDataText="There Is No Data To Display..!!" AutoGenerateColumns="false" DataKeyNames="ID"
                                OnRowCommand="gvUsers_RowCommand">
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Staff Name" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("USER_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EMAIL_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactNo" runat="server" Text='<%# Bind("CONTACT_NO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Role Name" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRole" runat="server" Text='<%# Bind("ROLE_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/edit.png" ToolTip="Edit"
                                                Height="20px" ImageAlign="Middle" CommandName="Edit1" formnovalidate="true" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete1" ImageUrl="~/Images/delete.png"
                                                Height="20px" CommandArgument='<%# BIND("ID") %>' ToolTip="Delete" ImageAlign="Middle"
                                                formnovalidate="true" OnClientClick="return confirm('Confirm Delete?')" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="planeHead" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
