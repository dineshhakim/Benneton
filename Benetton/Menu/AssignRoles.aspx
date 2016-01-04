<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AssignRoles.aspx.cs" Inherits="Benetton.Menu.AssignRoles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
            <div>
            </div>
            <div class="form_inner">
                <ul>
                    <li>
                        <label>
                            User Name
                        </label>
                        <asp:DropDownList ID="ddlUsers" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvUsers" runat="server" ControlToValidate="ddlUsers"
                            ValidationGroup="Save" InitialValue="0" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <label>
                            Roles
                        </label>
                        <asp:DropDownList ID="ddlRoles" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvRoles" runat="server" ControlToValidate="ddlRoles"
                            InitialValue="0" ErrorMessage="*" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <label>
                            &nbsp</label>
                        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" CommandName="Save"
                            ValidationGroup="Save" OnClick="btnSave_Click" />
                    </li>
                </ul>
            </div>
            <div class="clear">
                <div class="divhead">
                    User Roles List
                </div>
            </div>
            <asp:GridView runat="server" ID="gvUsersRoles" CssClass="table1" ShowHeaderWhenEmpty="true"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" EmptyDataText="There Is No Data To Display..!!"
                AutoGenerateColumns="false" DataKeyNames="ID" OnRowCommand="gvUsersRoles_RowCommand">
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblRoleId" runat="server" Text='<%# Bind("ROLE_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblUserId" runat="server" Text='<%# Bind("USER_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Roles" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblFullName" runat="server" Text='<%# Bind("ROLE_NAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblRoleName" runat="server" Text='<%# Bind("USER_NAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/edit.png" ToolTip="Edit"
                                Height="25px" ImageAlign="Middle" CommandName="Edit1" CausesValidation="false"
                                CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' />
                        </ItemTemplate>
                        <HeaderStyle CssClass="planeHead" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete1" ImageUrl="~/Images/delete.png"
                                Height="25px" CommandArgument='<%# BIND("ID") %>' ToolTip="Delete" ImageAlign="Middle"
                                OnClientClick="return confirm('Confirm Delete?')" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="planeHead" />
                    </asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <HeaderStyle Font-Bold="true" />
            </asp:GridView>
            <div class="divhead1">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
