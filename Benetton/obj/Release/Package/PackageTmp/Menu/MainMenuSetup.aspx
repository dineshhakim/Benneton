<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MainMenuSetup.aspx.cs" Inherits="Benetton.Menu.MainMenuSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updForm" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
           
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
                                            Menu Name
                                        </label>
                                        <asp:TextBox ID="txtMenuName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label class="control-label">
                                            Order
                                        </label>
                                        <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label class="control-label">
                                            Image Url
                                        </label>
                                        <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <div class="form-group">
                                        <label class="control-label">&nbsp;</label>
                                        <asp:Button ID="btnMenu" runat="server" CssClass="btn btn-primary form-control" Text="Save" CommandName="Save"
                                            OnClick="btnMenu_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="pull-right">
                        </div>
                        <h3 class="xlg-title">Main Menu List</h3>
                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="gvMenu" ShowHeaderWhenEmpty="true" CssClass="table table-bordered table-hover table-dark"
                                EmptyDataText="There Is No Data To Display..!!" AutoGenerateColumns="false" DataKeyNames="MainMenuID"
                                OnRowDataBound="gvMenu_RowDataBound" OnRowCommand="gvMenu_RowCommand">
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("MainMenuID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Menu Name" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMenuName" runat="server" Text='<%# Bind("MenuName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder" runat="server" Text='<%#Bind("Odr") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Menu Logo" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblImageUrl" runat="server" Visible="false" Text='<%#Bind("ImageURL") %>'></asp:Label>
                                            <asp:ImageButton ID="btnLogo" runat="server" ToolTip="Edit" Height="20px" ImageAlign="Middle" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/edit.png" ToolTip="Edit"
                                                Height="20px" ImageAlign="Middle" CommandName="Edit1" CausesValidation="false"
                                                CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="planeHead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete1" ImageUrl="~/Images/Delete.png"
                                                Height="25px" CommandArgument='<%# BIND("MainMenuID") %>' ToolTip="Delete" ImageAlign="Middle"
                                                OnClientClick="return confirm('Confirm Delete?')" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnMenu" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
