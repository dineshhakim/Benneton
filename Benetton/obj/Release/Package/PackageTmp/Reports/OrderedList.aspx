<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderedList.aspx.cs" Inherits="Benetton.Reports.OrderedList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
            <asp:UpdateProgress ID="updProgress" runat="server" AssociatedUpdatePanelID="updForm">
                <ProgressTemplate>
                     <div class="outerDiv">
                    </div>
                    <div class="innerDiv" title="Processing your Request...">
                    </div>
                    
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="form_inner">
                <ul>
                      <li>
                        <label>
                           Branch
                        </label>
                       <asp:DropDownList ID="ddlBranch" runat="server">
                          </asp:DropDownList>
                    </li>
                    <li>
                        <label>
                           Season
                        </label>
                       <asp:DropDownList ID="ddlSeason" runat="server">
                          </asp:DropDownList>
                    </li>
                  
                </ul>
            </div>
            <div class="clear">
            </div>
            <div class="btn_sec">
                <asp:Button runat="server" ID="btn_Search" OnClick="btn_Search_Click" Text="Search" 
                    CssClass="button" CommandName="Search" />
                
            </div>
            <div class="clear">
            </div>
            <asp:GridView runat="server" ID="gvOrderedList" ShowHeaderWhenEmpty="True" CssClass="table1"
                EmptyDataText="There is no data to display.......!!" AutoGenerateColumns="False"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblStoreNo" Text='<%#Bind("Store_No") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Store Name">
                        <ItemTemplate>
                            <asp:Label ID="lblStoreName" runat="server" Text='<%# Bind("Store_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <%--<asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblGender" Text='<%#Bind("Gender") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCategory" Text='<%#Bind("Category") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Description">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblItemDescr" Text='<%#Bind("Description") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Style">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblStyle" Text='<%#Bind("Style") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Color">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblColor" Text='<%#Bind("Color") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Size">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSize" Text='<%#Bind("Size") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblQty" Text='<%#Bind("Qty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mrp">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblMrp" Text='<%#Bind("Mrp") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnedit" ImageUrl="~/Images/edit.png" Height="20px" Width="20px"
                                CommandName="edit1" formnovalidate="formnovalidate" CommandArgument='<%# Container.DataItemIndex%>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="btndelete" ImageUrl="~/Images/delete.png" Height="20px" Width="20px"
                                CommandName="delete1" formnovalidate="formnovalidate" CommandArgument='<%# Bind("BranchId") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
