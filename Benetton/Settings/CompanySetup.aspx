<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanySetup.aspx.cs" Inherits="Benetton.Settings.CompanySetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
     <h2>
        Company Information</h2>
    <div class="form_inner">
        <ul>
            <li>
                <label>
                    Company Name:
                </label>
                <asp:TextBox ID="txtbox_companyName" runat="server" CssClass="textBox1" Text='<%# Bind("CompanyName") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbox_companyName"
                    ErrorMessage="*" ValidationGroup="validateCompany" Font-Size="XX-Small" Display="Dynamic"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
            </li>
            <li>
                <label>
                    Pan No:
                </label>
                <asp:TextBox ID="txtbox_panNo" runat="server" CssClass="textBox1" Text='<%# Bind("PanNo") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtbox_panNo"
                    ErrorMessage="*" ValidationGroup="validateCompany" Font-Size="XX-Small" Display="Dynamic"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
            </li>
            <li>
                <label>
                    Registration No:
                </label>
                <asp:TextBox ID="txtbox_registrationNo" runat="server" CssClass="textBox1" Text='<%# Bind("RegistrationNo") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbox_registrationNo"
                    ErrorMessage="*" ValidationGroup="validateCompany" Font-Size="XX-Small" Display="Dynamic"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                <%--<td>
                                Logo:
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" CssClass="textBox1" runat="server" />
                            </td>--%>
            </li>
            <li>
                <label>
                    Address1:
                </label>
                <asp:TextBox ID="txtbox_add" runat="server" CssClass="textBox1" Text='<%# Bind("Adress1") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_add" runat="server" ControlToValidate="txtbox_add"
                    ErrorMessage="*" ValidationGroup="validateCompany" Font-Size="XX-Small" Display="Dynamic"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
            </li>
            <li>
                <label>
                    Address2:
                </label>
                <asp:TextBox ID="txtbox_add2" runat="server" CssClass="textBox1" Text='<%# Bind("Adress2") %>'></asp:TextBox>
            </li>
            <li>
                <label>
                    City:
                </label>
                <asp:TextBox ID="txtbox_city" runat="server" CssClass="textBox1" Text='<%# Bind("City") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbox_city"
                    ErrorMessage="*" ValidationGroup="validateCompany" Font-Size="XX-Small" Display="Dynamic"
                    CssClass="textBox1"></asp:RequiredFieldValidator>
            </li>
            <li>
                <label>
                    State:
                </label>
                <asp:TextBox ID="txtbox_state" runat="server" CssClass="textBox1" Text='<%# Bind("State") %>'></asp:TextBox>
            </li>
            <li>
                <label>
                    Country:
                </label>
                <asp:TextBox ID="txtbox_country" runat="server" CssClass="textBox1" Text='<%# Bind("Country") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbox_country"
                    ErrorMessage="*" ValidationGroup="validateCompany" Font-Size="XX-Small" Display="Dynamic"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
            </li>
            <li>
                <label>
                    Telephone No:
                </label>
                <asp:TextBox ID="txtbox_telephoneNo" runat="server" CssClass="textBox1" Text='<%# Bind("TelephoneNo") %>'></asp:TextBox>
            </li>
            <li>
                <label>
                    Web Address:
                </label>
                <asp:TextBox ID="txtbox_webAddress" runat="server" CssClass="textBox1" Text='<%# Bind("WebAdress") %>'></asp:TextBox>
            </li>
            <li>
                <label>
                    Email Address:
                </label>
                <asp:TextBox ID="txtbox_emailAddress" runat="server" CssClass="textBox1" Text='<%# Bind("EmailAdress") %>'></asp:TextBox>
            </li>
            <li>
                <label>
                    Cash Amount:
                </label>
                <asp:TextBox ID="tb_cash" runat="server" CssClass="textBox1"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tb_cash"
                    Display="Dynamic" ErrorMessage="*" Font-Size="XX-Small" MaximumValue="99999999"
                    MinimumValue="0" Type="Double" ValidationGroup="validateCompany" SetFocusOnError="true"></asp:RangeValidator>
            </li>
            <li>
                <label>
                    Date:
                </label>
                <asp:TextBox ID="tb_date" runat="server" CssClass="textBox1"></asp:TextBox>
            </li>
        </ul>
        </div>
        <div class="clear">
        </div>
        <div class="btn_sec">
            <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="btn_insert_Click"
                CssClass="button" ValidationGroup="validateCompany" />
        </div>
</asp:Content>
