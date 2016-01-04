<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManualProductEntry.aspx.cs" Inherits="Benetton.Product.ManualProductEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMsgBox" runat="server">
            </asp:Panel>
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
            <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btn_Save">
                <div id="Div1" runat="server">
                    <div class="form_inner">
                        <div id="div3" class="notice right" style="display: none;">
                            <asp:Label ID="Label1" runat="server" Text="Successfully Updated"></asp:Label>
                        </div>
                        <ul>
                             <li>
                                <label>
                                    Invoice No.
                                </label>
                                 <asp:TextBox ID="txtInvoiceNo" runat="server" required></asp:TextBox>
                            </li>
                            <li>
                                <label>
                                    Branch
                                </label>
                                <asp:DropDownList ID="ddl_branch" runat="server" 
                                    AutoPostBack="true">
                                    <asp:ListItem Value="-2" Text="All" Selected="True" Enabled="true"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                              <li>
                                <label>
                                    Season
                                </label>
                                <asp:DropDownList ID="ddlSeason" runat="server" 
                                    AutoPostBack="true">
                                    <asp:ListItem Value="-1" Text="Select" Selected="True" Enabled="true"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>
                                    Date
                                </label>
                                  <asp:TextBox ID="txtDate" runat="server" CssClass="datePicker" onChange="CheckDate(this);"
                                    placeholder="YYYY/MM/DD" Enabled="true" required></asp:TextBox>
                            </li>
                      <li>
                                <label>
                                    Document No
                                </label>
                                  <asp:TextBox ID="txtDocumentNo" runat="server"  required></asp:TextBox>
                            </li>
                             <li>
                                <label>
                                    Stock No
                                </label>
                                  <asp:TextBox ID="txtStockNo" runat="server"  required></asp:TextBox>
                            </li>
                             <li>
                                <label>
                                    Airway Bill No
                                </label>
                                  <asp:TextBox ID="txtAirwayBillNo" runat="server"  required></asp:TextBox>
                            </li>
                                  <li>
                                <label>
                                    Gender
                                </label>
                                <asp:DropDownList ID="ddlGender" runat="server" 
                                    AppendDataBoundItems="true">
                                    <asp:ListItem Value="-1" Text="Select" Selected="True" Enabled="true"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                              <li>
                                <label>
                                    Category
                                </label>
                                <asp:DropDownList ID="ddlCategory" runat="server" 
                                    AutoPostBack="true">
                                    <asp:ListItem Value="-1" Text="Select" Selected="True" Enabled="true"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                              <li>
                                <label>
                                    Style
                                </label>
                                <asp:DropDownList ID="ddlStyle" runat="server" 
                                    AutoPostBack="true" onselectedindexchanged="ddlStyle_SelectedIndexChanged">
                                    <asp:ListItem Value="-1" Text="Select" Selected="True" Enabled="true"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                              <li>
                                <label>
                                    Color
                                </label>
                                <asp:DropDownList ID="ddlColor" runat="server" 
                                    AutoPostBack="true">
                                    <asp:ListItem Value="-1" Text="Select" Selected="True" Enabled="true"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                              <li>
                                <label>
                                    Size
                                </label>
                                <asp:DropDownList ID="ddlSize" runat="server" 
                                    AppendDataBoundItems="true">
                                    <asp:ListItem Value="-1" Text="Select" Selected="True" Enabled="true"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                              <li>
                                <label>
                                    Qty
                                </label>
                                 <asp:TextBox ID="txtQty" runat="server" required></asp:TextBox>
                            </li>
                              <li>
                                <label>
                                    Rate
                                </label>
                                 <asp:TextBox ID="txtRate" runat="server" required></asp:TextBox>
                            </li>
                              <li>
                                <label>
                                    Mrp
                                </label>
                                 <asp:TextBox ID="txtMrp" runat="server"></asp:TextBox>
                            </li>
                        </ul>
                        <div class="clear">
                        </div>
                        <div class="btn_sec">
                            <asp:Button ID="btn_Save" runat="server" Text="Save" CssClass="button" OnClick="btn_Save_Click"
                                OnClientClick="return confirm('Sure to Save ?')" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click"
                                Visible="true" />
                           <%-- <asp:Button runat="server" ID="btnINactive" Text="Inactive Staff" OnClientClick="return confirm('Confirm To Deactive?')"
                                CssClass="button" Visible="False" OnClick="btnINactive_Click" />--%>
                        </div>
                        <div class="clear">
                        </div>
                        <%--<div id="gvDiv">
                            <asp:GridView ID="gvProductEntry" runat="server" AllowPaging="false" Width="100%" ClientIDMode="Static"
                                AutoGenerateColumns="False" CssClass="table1" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid" Visible="true"
                                EmptyDataText="No Record Found." ShowFooter="false" OnRowDataBound="gvProductEntry_RowDataBound"
                                OnRowCommand="gvProductEntry_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sn">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Invoice.No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceNo" runat="server" Text='<%#Eval("InvoiceNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Season">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSeason" runat="server" Text='<%#Eval("Season") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("Branch") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Doc. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocNo" runat="server" Text='<%#Eval("DocNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Gender">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGender" runat="server" Text='<%#Eval("Gender") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stock No." Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStockNo" runat="server" Text='<%#Eval("StockNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Style" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStyle" runat="server" Text='<%#Eval("Style") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Color">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColor" runat="server" Text='<%#Eval("Color") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Size" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSize" runat="server" Text='<%#Eval("Size") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mrp" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMrp" runat="server" Text='<%#Eval("Mrp") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ProductId" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProductId" runat="server" Text='<%#Eval("ProductId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="CreatedDate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedDate" runat="server" Text='<%#Eval("CreatedDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CreatedBy" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedBy" runat="server" Text='<%#Eval("CreatedBy") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                        <%--         <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" ImageUrl="~/Images/edit.png" Height="20px" Width="20px"
                                CommandName="edit1" formnovalidate="formnovalidate" CommandArgument='<%# Container.DataItemIndex%>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" ImageUrl="~/Images/delete.png" Height="20px" Width="20px"
                                CommandName="delete1" formnovalidate="formnovalidate" CommandArgument='<%# Bind("ProductId") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>--%>
                           
                     </div>
                    </div>
               <%-- </div>--%>
          
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
