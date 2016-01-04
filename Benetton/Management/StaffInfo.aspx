<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StaffInfo.aspx.cs" Inherits="Benetton.Management.StaffInfo" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .md-modal
        {
            position: fixed;
            top: 50%;
            left: 50%;
            width: 50%;
            max-width: 630px;
            min-width: 320px;
            height: auto;
            z-index: 2000;
            visibility: hidden;
            backface-visibility: hidden;
            transform: translateX(-50%) translateY(-50%);
        }
        
        .md-show
        {
            visibility: visible;
        }
        
        .md-overlay
        {
            position: fixed;
            width: 100%;
            height: 100%;
            visibility: hidden;
            top: 0;
            left: 0;
            z-index: 1000;
            opacity: 0;
            background: rgba(143,27,15,0.8);
            transition: all 0.3s;
        }
        
        .md-show ~ .md-overlay
        {
            opacity: 1;
            visibility: visible;
        }
        
        .md-perspective, .md-perspective body
        {
            height: 100%;
            overflow: hidden;
        }
        
        .md-perspective body
        {
            background: #222;
            perspective: 600px;
        }
        
        .container
        {
            background: #e74c3c;
            min-height: 100%;
        }
        .md-show.md-effect-5 ~ .md-overlay
        {
            background: rgba(0,127,108,0.8);
        }
        
        .md-effect-5 .md-content
        {
            transform: scale(0) rotate(720deg);
            opacity: 0;
            transition: all 0.5s;
        }
        
        .md-show.md-effect-5 .md-content
        {
            transform: scale(1) rotate(0deg);
            opacity: 1;
        }
        .alert-box
        {
            color: #555;
            border-radius: 10px;
            font-family: Verdana,Tahoma,Geneva,Arial,sans-serif;
            font-size: 11px;
            padding: 10px 10px 10px px;
            margin: 10px;
        }
        .alert-box span
        {
            font-weight: bold;
            text-transform: uppercase;
        }
        .error
        {
            background: #ffecec url('Icons/error.png') no-repeat 10px 50%;
            border: 1px solid #f5aca6;
        }
        .success
        {
            background: #e9ffd9 url('Icons/success.png') no-repeat 10px 50%;
            border: 1px solid #a6ca8a;
        }
        .warning
        {
            background: #fff8c4 url('Icons/warning.png') no-repeat 10px 50%;
            border: 1px solid #f2c779;
        }
        .notice
        {
            background: green;
            border: 1px solid #8ed9f6;
            font-family: Verdana;
            text-align: center;
            width: 80%;
            color: White;
            font-size: 16px;
        }
        .visible
        {
            visibility: visible;
            opacity: 1;
            transition: opacity 2s linear;
        }
        .hidden
        {
            visibility: hidden;
            opacity: 0;
            transition: visibility 0s 2s, opacity 2s linear;
        }
    </style>
    <style type="text/css">
        .align1
        {
            text-align: center;
            margin-left: 40%;
        }
        .align2
        {
            text-align: right;
            float: right;
            width: 45px;
        }
        
        .align3
        {
            width: 10%;
        }
        .popup
        {
            background-color: #F1F1F1;
            -moz-border-radius: 2px;
            border: 1px solid;
            width: 900px;
            font-size: 16px;
            height: 100px;
        }
        .hw
        {
            width: 130px;
            height: 30px;
        }
        .ModalPopupBG
        {
            /*background-color: #DEEAEB;  003366*/
            background-color: #003366;
            filter: alpha(opacity=60);
            opacity: 0.4;
            z-index: 25%;
            border-color: Red;
            font-family: Verdana;
            border-style: solid;
        }
        .HellowWorldPopup
        {
            min-width: 400px;
            min-height: 350px;
            background: white;
        }
        .pnlBackGround
        {
            position: fixed;
            top: 10%;
            left: 10px;
            width: 300px;
            height: 125px;
            text-align: center;
            background-color: White;
            border: solid 3px black;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function pageLoad() {
            //  ShowPopup();
            //setTimeout(HidePopup, 2000);
            // ShowPopup2();

        }

        function ShowPopup() {

            //  var modalPopupExtender = $find('ModalPopupExtender2');
            //  modalPopupExtender.show();
            var v = $('#<%=ddlDesignation.ClientID%> :selected').val();
            if (v == -1) {
                $find('ModalPopupExtender2').show();
                // $("#popup").fadeIn("slow");
            }

        }
        function HidePopup() {
            //  $find('ModalPopupExtender2').hide();

        }


        function ShowPopup1() {
            var v = $('#<%=ddlDepartment.ClientID%> :selected').val();
            if (v == -1) {
                $find('ModalPopupExtender3').show();
            }
        }

        function ShowPopup2() {

            document.getElementById('div3').style.display = "block";
            // $("#div3").fadeToggle(2000);
            $("#div3").fadeIn(500);
            $("#div3").fadeOut(5000);
        }
        function ShowPopup3() {

            var v = $('#<%=ddlQualification.ClientID%> :selected').val();
            if (v == -1) {
                $find('ModalPopupExtender1').show();
            }
        }
        function ShowPopup4() {

            var v = $('#<%=ddlServiceType.ClientID%> :selected').val();
            if (v == -1) {
                $find('ModalPopupExtender4').show();
            }
        }
        function ShowPopup5() {

            var v = $('#<%=ddlEthnicGroups.ClientID%> :selected').val();
            if (v == -1) {
                $find('ModalPopupExtender5').show();
            }
        }

    </script>
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
                                    Branch
                                </label>
                                <asp:DropDownList ID="ddl_branch" runat="server" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem Value="-2" Text="All" Selected="True" Enabled="true"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>
                                    Title
                                </label>
                                <asp:DropDownList ID="ddlTitle" runat="server" AutoPostBack="true" required>
                                    <%--<asp:ListItem Value="-2" Text="All" Selected="True" Enabled="true"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>
                                    Staff Name
                                </label>
                                <asp:TextBox ID="txtStaffName" runat="server" placeholder="Staff Full Name" required></asp:TextBox>
                            </li>
                            <li>
                                <label>
                                    Gender
                                </label>
                                <asp:DropDownList ID="ddlGender" runat="server">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>
                                    Marital Status
                                </label>
                                <asp:DropDownList ID="ddlmaritalstatus" runat="server">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>
                                    Service Type
                                </label>
                                <asp:DropDownList ID="ddlServiceType" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"
                                    OnChange="ShowPopup4();">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>
                                    Ethnic Groups
                                </label>
                                <asp:DropDownList ID="ddlEthnicGroups" runat="server" OnSelectedIndexChanged="ddlEthnicGroups_SelectedIndexChanged"
                                    OnChange="ShowPopup5();">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>
                                    Date Of Birth
                                </label>
                                <asp:TextBox ID="txtDOB" runat="server" onChange="CheckDate(this);" CssClass="datePicker"
                                    placeholder="YYYY/MM/DD" required></asp:TextBox>
                            </li>
                            <li>
                                <label>
                                    Citizenship Number
                                </label>
                                <asp:TextBox ID="txtCitizenNo" runat="server" required></asp:TextBox>
                            </li>
                            <li>
                                <label>
                                    Passport Number
                                </label>
                                <asp:TextBox ID="txtPpNo" runat="server"></asp:TextBox>
                            </li>
                            <li>
                                <label>
                                    Address
                                </label>
                                <asp:TextBox ID="txtAddress" runat="server" placeholder="Staff Full Address" required></asp:TextBox>
                            </li>
                            <li>
                                <label>
                                    Contact Number
                                </label>
                                <asp:TextBox ID="txtContactNo" runat="server" CssClass="number" placeholder="Mobile or Landline Number"
                                    required></asp:TextBox>
                            </li>
                            <li>
                                <label>
                                    Email Address
                                </label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="abc@gamil.com"></asp:TextBox>
                            </li>
                            <li>
                                <label>
                                    Academic Qualification
                                </label>
                                <asp:DropDownList ID="ddlQualification" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlQualification_SelectedIndexChanged"
                                    OnChange="ShowPopup3();">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>
                                    Department
                                </label>
                                <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"
                                    OnChange="ShowPopup1();">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>
                                    Designation
                                </label>
                                <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" required
                                    OnChange="ShowPopup();" AppendDataBoundItems="true" >
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                 
                            </li>
                            <li>
                                <label>
                                    Job Start Date
                                </label>
                                <asp:TextBox ID="txtJobStartDate" runat="server" CssClass="datePicker" onChange="CheckDate(this);"
                                    placeholder="YYYY/MM/DD" Enabled="true" required></asp:TextBox>
                            </li>
                            <li>
                                <label>
                                    Join Date
                                </label>
                                <asp:TextBox ID="txtJoinDate" runat="server" CssClass="datePicker" onChange="CheckDate(this);"
                                    placeholder="YYYY/MM/DD" Enabled="true" required></asp:TextBox>
                            </li>
                            <li>
                                <label>
                                    Training & Experience
                                </label>
                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" placeholder="Please Mention Staff Job experience and traning"></asp:TextBox>
                            </li>
                            <li>
                              
                                   
                            </li>
                        </ul>
                        <div class="clear">
                        </div>
                        <div class="btn_sec">
                            <asp:Button ID="btn_Save" runat="server" Text="Save" CssClass="button" OnClick="btn_Save_Click"
                                OnClientClick="return confirm('Sure to Save ?')" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click"
                                Visible="true" />
                            <asp:Button runat="server" ID="btnINactive" Text="Inactive Staff" OnClientClick="return confirm('Confirm To Deactive?')"
                                CssClass="button" Visible="False" OnClick="btnINactive_Click" />
                        </div>
                        <div class="clear">
                        </div>
                        <div id="gvDiv">
                            <asp:GridView ID="gvMemberInfo" runat="server" AllowPaging="false" Width="100%" ClientIDMode="Static"
                                AutoGenerateColumns="False" CssClass="table1" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid" Visible="true"
                                EmptyDataText="No Record Found." ShowFooter="false" OnRowDataBound="gvMemberInfo_RowDataBound"
                                OnRowCommand="gvMemberInfo_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sn">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ContactNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DOB" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Title" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qualification" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQualification" runat="server" Text='<%#Eval("Qualification") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("Department") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EnrolledDate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnrolledDate" runat="server" Text='<%#Eval("EnrolledDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="StaffId" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffId" runat="server" Text='<%#Eval("StaffId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Gender" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGender" runat="server" Text='<%#Eval("Gender") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CitizenNo" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCitizenNo" runat="server" Text='<%#Eval("CitezenNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PassportNo" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPassportNo" runat="server" Text='<%#Eval("PassportNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="JobStart" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblJobStartDate" runat="server" Text='<%#Eval("JobStartDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DesignationId" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDesignationId" runat="server" Text='<%#Eval("DesignationId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DepartmentId" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartmentId" runat="server" Text='<%#Eval("DepartmentId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marital Status" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarriedId" runat="server" Text='<%#Eval("MarriedId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Service Type" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblServiceId" runat="server" Text='<%#Eval("ServiceId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ethinicity " Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEthinicityId" runat="server" Text='<%#Eval("EthinicityId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch " Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchId" runat="server" Text='<%#Eval("Branch_id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch " Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marital Status " Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaritalStatus" runat="server" Text='<%#Eval("MaritalStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ServiceName " Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblServiceName" runat="server" Text='<%#Eval("ServiceName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CategoryName " Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategoryName" runat="server" Text='<%#Eval("CategoryName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit1" Text="Edit" Width="40px"
                                                CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <%--  <asp:TemplateField HeaderText="Active">
                                     <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkActive" Checked='<%# Eval("Active") == DBNull.Value ? false : Eval("Active") %>'/>
                                      </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                            <asp:HiddenField ID="hiddenStaffid" runat="server" />
                        </div>
                    </div>
                </div>
                <cc1:ModalPopupExtender ID="ModalPopupExtender2" ClientIDMode="Static" runat="server"
                    TargetControlID="hfValue2" BackgroundCssClass="ModalPopupBG" OkControlID="imgClose2"
                    CancelControlID="imgClose2" PopupControlID="pnlDetails2" OnOkScript="onOk()"
                    PopupDragHandleControlID="pnlDetails2" Drag="true" X="600" Y="200">
                </cc1:ModalPopupExtender>
                <asp:HiddenField ID="hfValue2" runat="server" />
                <asp:Panel ID="pnlDetails2" runat="server">
                    <div class="form_inner">
                        <div class="popup" style="height: 150px; width: 40%;">
                            <ul>
                                <asp:Label ID="lbl1" runat="server" Text="Enter New Item" Font-Names="verdana"></asp:Label>
                                <li style="text-align: right; width: 100%; margin-bottom: 0%;">
                                    <asp:ImageButton ID="imgClose2" runat="server" ImageUrl="~/Images/close.png" />
                                </li>
                                <li style="margin-top: -8%;">
                                    <label>
                                        Designation Name
                                    </label>
                                    <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnSubmit_Click" />
                                </li>
                            </ul>
                        </div>
                    </div>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender3" ClientIDMode="Static" runat="server"
                    TargetControlID="hfValue3" BackgroundCssClass="ModalPopupBG" OkControlID="imgClose3"
                    CancelControlID="imgClose3" PopupControlID="pnlDetails3" OnOkScript="onOk()"
                    PopupDragHandleControlID="pnlDetails3" Drag="true" X="600" Y="200">
                </cc1:ModalPopupExtender>
                <asp:HiddenField ID="hfValue3" runat="server" />
                <asp:Panel ID="pnlDetails3" runat="server">
                    <div class="form_inner">
                        <div class="popup" style="height: 150px; width: 40%;">
                            <ul>
                                <asp:Label ID="lbl3" runat="server" Text="Enter New Item" Font-Names="verdana"></asp:Label>
                                <li style="text-align: right; width: 100%; margin-bottom: 0%;">
                                    <asp:ImageButton ID="imgClose3" runat="server" ImageUrl="~/Images/close.png" />
                                </li>
                                <li style="margin-top: -8%;">
                                    <label>
                                        Department Name
                                    </label>
                                    <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <asp:Button ID="btnSubmitDepartment" runat="server" Text="Submit" CssClass="button"
                                        OnClick="btnSubmitDepartment_Click" />
                                </li>
                            </ul>
                        </div>
                    </div>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender1" ClientIDMode="Static" runat="server"
                    TargetControlID="hfValue4" BackgroundCssClass="ModalPopupBG" OkControlID="imgClose3"
                    CancelControlID="imgClose3" PopupControlID="pnlDetails4" OnOkScript="onOk()"
                    PopupDragHandleControlID="pnlDetails4" Drag="true" X="600" Y="200">
                </cc1:ModalPopupExtender>
                <asp:HiddenField ID="hfValue4" runat="server" />
                <asp:Panel ID="pnlDetails4" runat="server">
                    <div class="form_inner">
                        <div class="popup" style="height: 150px; width: 40%;">
                            <ul>
                                <asp:Label ID="lbl2" runat="server" Text="Enter New Item" Font-Names="verdana"></asp:Label>
                                <li style="text-align: right; width: 100%; margin-bottom: 0%;">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/close.png" />
                                </li>
                                <li style="margin-top: -8%;">
                                    <label>
                                        Acedamic Qualification
                                    </label>
                                    <asp:TextBox ID="txtAcedamicQualification" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <asp:Button ID="btnSubmitAcedamicQualification" runat="server" Text="Submit" CssClass="button"
                                        OnClick="btnSubmitAcedamicQualification_Click" />
                                </li>
                            </ul>
                        </div>
                    </div>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender4" ClientIDMode="Static" runat="server"
                    TargetControlID="hfValue5" BackgroundCssClass="ModalPopupBG" OkControlID="imgClose3"
                    CancelControlID="imgClose3" PopupControlID="pnlDetails5" OnOkScript="onOk()"
                    PopupDragHandleControlID="pnlDetails5" Drag="true" X="600" Y="200">
                </cc1:ModalPopupExtender>
                <asp:HiddenField ID="hfValue5" runat="server" />
                <asp:Panel ID="pnlDetails5" runat="server">
                    <div class="form_inner">
                        <div class="popup" style="height: 150px; width: 40%;">
                            <ul>
                                <asp:Label ID="Label2" runat="server" Text="Enter New Item" Font-Names="verdana"></asp:Label>
                                <li style="text-align: right; width: 100%; margin-bottom: 0%;">
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/close.png" />
                                </li>
                                <li style="margin-top: -8%;">
                                    <label>
                                        Service Type
                                    </label>
                                    <asp:TextBox ID="txtServiceType" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <asp:Button ID="btnSubmitServiceType" runat="server" Text="Submit" CssClass="button"
                                        OnClick="btnSubmitServiceType_Click" />
                                </li>
                            </ul>
                        </div>
                    </div>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender5" ClientIDMode="Static" runat="server"
                    TargetControlID="hfValue6" BackgroundCssClass="ModalPopupBG" OkControlID="imgClose3"
                    CancelControlID="imgClose3" PopupControlID="pnlDetails6" OnOkScript="onOk()"
                    PopupDragHandleControlID="pnlDetails6" Drag="true" X="600" Y="200">
                </cc1:ModalPopupExtender>
                <asp:HiddenField ID="hfValue6" runat="server" />
                <asp:Panel ID="pnlDetails6" runat="server">
                    <div class="form_inner">
                        <div class="popup" style="height: 150px; width: 40%;">
                            <ul>
                                <asp:Label ID="Label3" runat="server" Text="Enter New Item" Font-Names="verdana"></asp:Label>
                                <li style="text-align: right; width: 100%; margin-bottom: 0%;">
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/close.png" />
                                </li>
                                <li style="margin-top: -8%;">
                                    <label>
                                        Ethnic Group
                                    </label>
                                    <asp:TextBox ID="txtEthnicGroup" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <asp:Button ID="btnEthnicGroup" runat="server" Text="Submit" CssClass="button" OnClick="btnEthnicGroup_Click" />
                                </li>
                            </ul>
                        </div>
                    </div>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
