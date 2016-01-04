<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Roles.aspx.cs" Inherits="Benetton.Menu.Roles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
            <div style="width: 30%; float: left">
                <div class="form_inner">
                    <ul>
                        <li>
                            <label>
                                Role Name
                            </label>
                            <asp:TextBox ID="txtRoleName" runat="server" CssClass="txtbox"></asp:TextBox>
                        </li>
                        <li>
                            <label>
                                &nbsp</label>
                            <asp:Button ID="btnRole" runat="server" CssClass="button" Text="Save" CommandName="Save"
                                OnClick="btnRole_Click" />
                        </li>
                    </ul>
                </div>
                <asp:GridView runat="server" ID="gvUsersRoles" CssClass="table1" ShowHeaderWhenEmpty="true"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" EmptyDataText="There Is No Data To Display..!!"
                    AutoGenerateColumns="false" DataKeyNames="ROLE_ID" OnRowCommand="gvUsersRoles_RowCommand">
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("ROLE_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Roles" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblFullName" runat="server" Text='<%# Bind("ROLE_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/edit.png" ToolTip="Edit"
                                    Height="15px" ImageAlign="Middle" CommandName="Edit1" CausesValidation="false"
                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' />
                            </ItemTemplate>
                            <HeaderStyle CssClass="planeHead" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete1" ImageUrl="~/Images/Delete.png"
                                    Height="15px" CommandArgument='<%# BIND("ROLE_ID") %>' ToolTip="Delete" ImageAlign="Middle"
                                    OnClientClick="return confirm('Confirm Delete?')" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="planeHead" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="width: 65%; float: right">
                <div class="form_inner">
                    <ul>
                        <li>
                            <label>
                                Role Name
                            </label>
                            <asp:DropDownList ID="ddlRoleName" runat="server" AutoPostBack="True" CssClass="ddl"
                                Width="130px" OnSelectedIndexChanged="ddlRoleName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </li>
                        <li>
                            <label>
                                Main Menu
                            </label>
                            <asp:DropDownList ID="ddlMainMenu" runat="server" AutoPostBack="True" CssClass="ddl"
                                OnSelectedIndexChanged="ddlMainMenu_SelectedIndexChanged" Width="130px" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </li>
                        <li>
                            <label>
                                &nbsp</label>
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="button" />
                        </li>
                    </ul>
                </div>
                <div style="float: left; width: 45%">
                    <div class="divhead">
                        Unassigned Menu
                    </div>
                    <asp:GridView ID="gvAllMenu" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="sortable"
                        GridLines="Horizontal" Width="100%" ShowHeaderWhenEmpty="True" EmptyDataText="There Is No Data To Display..!!"
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
                <div style="float: right; width: 45%">
                    <div class="divhead">
                        Assigned Menu
                    </div>
                    <asp:GridView ID="gvAssignedMenu" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                        ShowHeaderWhenEmpty="true" EmptyDataText="There Is No Data To Display..!!" CssClass="table1"
                        Width="100%" PageSize="20" OnRowCommand="gvAssignedMenu_RowCommand">
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
            </fieldset>
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
