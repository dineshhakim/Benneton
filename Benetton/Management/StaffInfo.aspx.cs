using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Benetton.Classes;
using BusinessLogic;
using Domain;
using ProudMonkey.Common.Controls;

namespace Benetton.Management
{
    public partial class StaffInfo : System.Web.UI.Page
    {
        private MessageBox _msgbox;

        protected void Page_Init(object sender, EventArgs e)
        {
            _msgbox = new MessageBox()
            {
            };

            this.pnlMsgBox.Controls.Clear();
            this.pnlMsgBox.Controls.Add(_msgbox);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridview();
                FillDdlBranch();
                FillDdlDepartment();
                FillDdlDesignation();
                FillDdlGender();
                FillDdlEthnicGroup();
                FillDdlTitle();
                FillDdlMaritalStatus();
                FillDdlServiceType();
                FillDdlAcedamicQualification();
            }
        }
        #region Fill DropDownList
        private void FillDdlAcedamicQualification()
        {
            BL_FillDropDown.FillDdlAcedamicQualification(ddlQualification, 1, 0, "");
            ddlQualification.Items[1].Attributes["style"] = "color:dark-blue;font-weight:bold;";
        }
        private void FillDdlServiceType()
        {
            BL_FillDropDown.FillddlServiceType(ddlServiceType, 1, 0, "");
            ddlServiceType.Items[1].Attributes["style"] = "color:dark-blue;font-weight:bold;";
        }
        private void FillDdlMaritalStatus()
        {
            BL_FillDropDown.FillddlMaritalStatus(ddlmaritalstatus, 1, 0, "");
        }
        private void FillDdlTitle()
        {
            BL_FillDropDown.FillddlTitle(ddlTitle, 1, 0, "");
        }
        private void FillDdlEthnicGroup()
        {
            BL_FillDropDown.FillddlEthnicGroup(ddlEthnicGroups, 1, 0, "");
            ddlEthnicGroups.Items[1].Attributes["style"] = "color:dark-blue;font-weight:bold;";
        }
        private void FillDdlGender()
        {
            BL_FillDropDown.FillddlGender(ddlGender, 1, 0, "");
        }
        private void FillDdlDesignation()
        {
            BL_FillDropDown.FillddlDesignation(ddlDesignation, 1, 0, "");
            ddlDesignation.Items[1].Attributes["style"] = "color:dark-blue;font-weight:bold;";
        }
        private void FillDdlDepartment()
        {
            BL_FillDropDown.FillddlDepartment(ddlDepartment, 1, 0, "");
            ddlDepartment.Items[1].Attributes["style"] = "color:dark-blue;font-weight:bold;";
        }
        public void FillDdlBranch()
        {
            BL_FillDropDown.FillddlBranch(ddl_branch, 1, 0, "", "");
        }
        #endregion
        protected void gvMemberInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                InsUpdDelStaffInfo('D', Convert.ToInt32(e.CommandArgument));
                FillGridview();
            }

            else
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var row = gvMemberInfo.Rows[index];
                var lblStaffId = (Label)row.FindControl("lblStaffId");
                var lblName = (Label)row.FindControl("lblName");
                var lblAddress = (Label)row.FindControl("lblAddress");
                var lblContctNo = (Label)row.FindControl("lblContactNo");
                var lblDOB = (Label)row.FindControl("lblDOB");
                var lblTitle = (Label)row.FindControl("lblTitle");
                var lblQualification = (Label)row.FindControl("lblQualification");
                var lblDesignation = (Label)row.FindControl("lblDesignation");
                var lblDepartment = (Label)row.FindControl("lblDepartment");
                var lblEnrolledDate = (Label)row.FindControl("lblEnrolledDate");
                var lblGender = (Label)row.FindControl("lblGender");
                var lblEmail = (Label)row.FindControl("lblEmail");
                var lblCitizenNo = (Label)row.FindControl("lblCitizenNo");
                var lblPassportNo = (Label)row.FindControl("lblPassportNo");
                var lblJobStartDate = (Label)row.FindControl("lblJobStartDate");
                var lblRemarks = (Label)row.FindControl("lblRemarks");
                var lblDesignationId = (Label)row.FindControl("lblDesignationId");
                var lblDepartmentId = (Label)row.FindControl("lblDepartmentId");
                var lblMarriedId = (Label)row.FindControl("lblMarriedId");
                var lblServiceId = (Label)row.FindControl("lblServiceId");
                var lblEthinicityId = (Label) row.FindControl("lblEthinicityId");
                var lblBranchId = (Label) row.FindControl("lblBranchId");
                var lblBranchName = (Label) row.FindControl("lblBranchName");
                var lblMaritalStatus = (Label) row.FindControl("lblMaritalStatus");
                var lblServiceName = (Label)row.FindControl("lblServiceName");
                var lblCategoryName = (Label)row.FindControl("lblCategoryName");


                ddl_branch.SelectedIndex = ddl_branch.Items.IndexOf(ddl_branch.Items.FindByText(lblBranchName.Text));
                ddlTitle.SelectedIndex = ddlTitle.Items.IndexOf(ddlTitle.Items.FindByText(lblTitle.Text));
                txtStaffName.Text = lblName.Text;
                ddlGender.SelectedIndex = ddlGender.Items.IndexOf(ddlGender.Items.FindByText(lblGender.Text));
                ddlmaritalstatus.SelectedIndex = ddlmaritalstatus.Items.IndexOf(ddlmaritalstatus.Items.FindByText(lblMaritalStatus.Text));
                ddlServiceType.SelectedIndex = ddlServiceType.Items.IndexOf(ddlServiceType.Items.FindByText(lblServiceName.Text));
                ddlEthnicGroups.SelectedIndex = ddlEthnicGroups.Items.IndexOf(ddlEthnicGroups.Items.FindByText(lblCategoryName.Text));
                txtDOB.Text = lblDOB.Text;
                txtCitizenNo.Text = lblCitizenNo.Text;
                txtPpNo.Text = lblPassportNo.Text;
                txtAddress.Text = lblAddress.Text;
                txtContactNo.Text = lblContctNo.Text;
                txtEmail.Text = lblEmail.Text;
                ddlQualification.SelectedIndex = ddlQualification.Items.IndexOf(ddlQualification.Items.FindByText(lblQualification.Text));
                ddlDepartment.SelectedIndex = ddlDepartment.Items.IndexOf(ddlDepartment.Items.FindByText(lblDepartment.Text));
                ddlDesignation.SelectedIndex = ddlDesignation.Items.IndexOf(ddlDesignation.Items.FindByText(lblDesignation.Text));
                txtJobStartDate.Text = lblJobStartDate.Text;
                txtJoinDate.Text = lblEnrolledDate.Text;
                txtRemarks.Text = lblRemarks.Text;
                btn_Save.Text = "Update";
                btn_Save.CommandName = "Update";
                btn_Save.CommandArgument = lblStaffId.Text;
                btnCancel.Visible = true;
                btnINactive.Visible = true;
            }
        }
        protected void gvMemberInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #region SUBMIT BUTTON CLICK
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InsUpdDelSetup("Dg",'I', 0);
            txtDesignation.Text = " ";
            FillDdlDesignation();
        }
        protected void btnSubmitDepartment_Click(object sender, EventArgs e)
        {
            InsUpdDelSetup("Dp", 'I', 0);
            txtDepartment.Text = " ";
            FillDdlDepartment();
        }
        protected void btnSubmitAcedamicQualification_Click(object sender, EventArgs e)
        {
            InsUpdDelSetup("Aq", 'I', 0);
            txtAcedamicQualification.Text = " ";
            FillDdlAcedamicQualification();
        }
        protected void btnSubmitServiceType_Click(object sender, EventArgs e)
        {
            InsUpdDelSetup("St", 'I', 0);
            txtServiceType.Text = " ";
            FillDdlServiceType();
        }
        protected void btnEthnicGroup_Click(object sender, EventArgs e)
        {
            InsUpdDelSetup("Eg", 'I', 0);
            txtEthnicGroup.Text = " ";
            FillDdlEthnicGroup();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
            btn_Save.Text = "Save";
            btn_Save.CommandName = "Save";
            btnCancel.Visible = false;
            btnINactive.Visible = false;
        }
        protected void btnINactive_Click(object sender, EventArgs e)
        {

            InsUpdDelStaffInfo('N', Convert.ToInt32((string)btn_Save.CommandArgument));
            _msgbox.ShowSuccess("Staff Successfully Deactivated!!!");
            ClearAll();
            btn_Save.Text = "Save";
            btn_Save.CommandName = "Save";
            btnCancel.Visible = false;
            btnINactive.Visible = false;
          
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            int  staffId = 0;

            bool isValid = char.IsLetter(txtStaffName.Text.FirstOrDefault());
            if (btn_Save.Text == "Update")
            {
                // center = -1;
              //  staffId = (Label)row.FindControl("lblStaffId");
            }
          
            if (ddlTitle.SelectedItem.Text == "Select")
            {
                _msgbox.ShowInfo("Please Select Title");
                return;
            }
            else if (txtStaffName.Text == "")
            {
                //txtStaffName.Attributes.Add("required", "required");
                //txtAddress.Attributes.Add("required", "required");
                //txtContactNo.Attributes.Add("required", "required");
                _msgbox.ShowInfo("Please Enter Staff Name");
                return;
            }

            else if (isValid == false)
            {

                _msgbox.ShowInfo("Please Enter Staff Name");
                return;
            }


            else if (ddlmaritalstatus.SelectedItem.Text == "Select")
            {
                _msgbox.ShowInfo("Please Select Marital Status");
                return;
            }
            else if (ddlServiceType.SelectedItem.Text == "Select")
            {
                _msgbox.ShowInfo("Please Select Service Type");
                return;
            }
            else if (ddlServiceType.SelectedItem.Text == "Add New Item")
            {
                _msgbox.ShowInfo("Please Select Service Type");
                return;
            }
            else if (ddlEthnicGroups.SelectedItem.Text == "Select")
            {
                _msgbox.ShowInfo("Please Select Ethnic Groups");
                return;
            }
            else if (ddlEthnicGroups.SelectedItem.Text == "Add New Item")
            {
                _msgbox.ShowInfo("Please Select Ethnic Group");
                return;
            }

            else if (txtDOB.Text == "")
            {
                _msgbox.ShowInfo("Please Enter Staff Date Of Birth");
                return;
            }
            else if (txtCitizenNo.Text == "")
            {
                _msgbox.ShowInfo("Please Enter CitizenNo");
                return;
            }

            else if (txtAddress.Text == "")
            {
                _msgbox.ShowInfo("Please Enter Address");
                return;
            }

            else if (txtContactNo.Text == "")
            {
                _msgbox.ShowInfo("Please Enter Contact Number");
                return;
            }
            else if (ddlQualification.SelectedItem.Text == "Select")
            {
                _msgbox.ShowInfo("Please Select Staff Qualification");
                return;
            }
            else if (ddlQualification.SelectedItem.Text == "Add New Item")
            {
                _msgbox.ShowInfo("Please Select Staff Qualification");
                return;
            }
            else if (ddlDepartment.SelectedItem.Text == "Select")
            {
                _msgbox.ShowInfo("Please Select Staff Department");
                return;
            }
            else if (ddlDepartment.SelectedItem.Text == "Add New Item")
            {
                _msgbox.ShowInfo("Please Select Staff Department");
                return;
            }
            else if (ddlDesignation.SelectedItem.Text == "Select")
            {
                _msgbox.ShowInfo("Please Select Staff Designation in Organization");
                return;
            }

            else if (ddlDesignation.SelectedItem.Text == "Add New Item")
            {
                _msgbox.ShowInfo("Please Select Staff Designation in Organization");
                return;
            }

            else if (txtJobStartDate.Text == "")
            {
                _msgbox.ShowInfo("Please Enter Job Start Date in Organization");
                return;
            }

            if (btn_Save.CommandName == "Update")
            {
                InsUpdDelStaffInfo('U', Convert.ToInt32((string)btn_Save.CommandArgument));
                btn_Save.Text = "Save";
                btn_Save.CommandName = "Save";
            }
            else
            {
                InsUpdDelStaffInfo('I', 0);
                FillGridview();
                ClearAll();
            }

     
        }
        #endregion
        protected void ddlQualification_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void InsUpdDelSetup(string value, char Event, int id)
        {
            var msg = "";

            if ((value == "Dg") && (Event == 'I' || Event == 'U'))
            {
                var objDesignation = new Designation(id, txtDesignation.Text);
                msg = BL_Staff.InsUpdDelDesignation(Event, objDesignation, out id);

            }
            else if ((value == "Dp") && (Event == 'I' || Event == 'U'))
            {
                var objDepartment = new Department(id, txtDepartment.Text);
                msg = BL_Staff.InsUpdDelDepartment(Event, objDepartment, out id);
            }
            else if ((value == "Aq") && (Event == 'I' || Event == 'U'))
            {
                var objQualification = new AcedamicQualification(id, txtAcedamicQualification.Text);
                msg = BL_Staff.InsUpdDelAcedamicQualification(Event, objQualification, out id);
            }
            else if ((value == "St") && (Event == 'I' || Event == 'U'))
            {
                var objServiceType = new ServiceType(id, txtServiceType.Text);
                msg = BL_Staff.InsUpdDelService(Event, objServiceType, out id);
            }
            else if ((value == "Eg") && (Event == 'I' || Event == 'U'))
            {
                var objEthnicGroup = new EthnicGroup(id, txtEthnicGroup.Text,1,"XX");
                msg = BL_Staff.InsUpdDelEthnicGroup(Event, objEthnicGroup, out id);
            }
            if (DatabaseMessage.ContainMessage(msg))
            {
                _msgbox.ShowSuccess(msg);

            }
            else
            {
                _msgbox.ShowWarning(msg);
            }
          //  FillGridview();
          //  ClearAll();
        }
        protected void ddlEthnicGroups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void InsUpdDelStaffInfo(char Event, int id)
        {
            var msg = "";

            if (Event == 'I' || Event == 'U')
            {
                
               // var session=new BK_Session(int userId,)
                var objStaff = new Staff(id, Convert.ToInt32(BK_Session.GetSession().UserId), Convert.ToInt32((string)ddl_branch.SelectedValue), txtStaffName.Text, Convert.ToInt32((string)ddlDesignation.SelectedValue), txtAddress.Text, txtContactNo.Text, txtEmail.Text, Convert.ToInt32((string)ddlQualification.SelectedValue), txtRemarks.Text, true, Convert.ToDateTime(BK_Session.GetSession().OpDate),
                    Convert.ToInt32((string)ddlGender.SelectedValue),Convert.ToDateTime(txtJobStartDate.Text),Convert.ToInt32((string)ddlTitle.SelectedValue),Convert.ToDateTime("01/01/1991"),Convert.ToDateTime("01/01/1991"),Convert.ToDateTime(txtDOB.Text),txtCitizenNo.Text,txtPpNo.Text,Convert.ToInt32((string)ddlDepartment.SelectedValue),Convert.ToInt32((string)ddlmaritalstatus.SelectedValue),Convert.ToInt32((string)ddlServiceType.SelectedValue),Convert.ToInt32((string)ddlEthnicGroups.SelectedValue));
                msg = BL_Staff.InsUpdDelStaffInfo(Event, objStaff, out id);

            }
            else if (Event == 'N')
            {
                var objStaff = new Staff(id, 0, 0, "", 0, "", "", "", 0, "", false, Convert.ToDateTime("01/01/1991"), 0, Convert.ToDateTime("01/01/1991"), 0, Convert.ToDateTime("01/01/1991"), Convert.ToDateTime("01/01/1991"), Convert.ToDateTime("01/01/1991"), "", "", 0, 0, 0, 0);
                msg = BL_Staff.UpdStaffToInactive(Event, objStaff, out id);
            }
            else
            {
                var objStaff = new Staff(id, 0, 0, "", 0, "", "", "", 0, "", false, Convert.ToDateTime("01/01/1991"), 0, Convert.ToDateTime("01/01/1991"), 0, Convert.ToDateTime("01/01/1991"), Convert.ToDateTime("01/01/1991"), Convert.ToDateTime("01/01/1991"), "", "", 0, 0, 0, 0);
                msg = BL_Staff.InsUpdDelStaffInfo(Event, objStaff, out id);
            }

            if (DatabaseMessage.ContainMessage(msg))
            {
                _msgbox.ShowSuccess(msg);

            }
            else
            {
                _msgbox.ShowWarning(msg);
            }
            FillGridview();
            ClearAll();
        }
        private void ClearAll()
        {
            ddl_branch.SelectedValue = "";
            ddlTitle.SelectedValue = "0";
            ddlGender.SelectedValue = "0";
            ddlQualification.SelectedValue = "0";
            ddlmaritalstatus.SelectedValue = "0";
            ddlDesignation.SelectedValue = "0";
            ddlDepartment.SelectedValue = "0";
            ddlServiceType.SelectedValue = "0";
            ddlEthnicGroups.SelectedValue = "0";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtCitizenNo.Text = "";
            txtDOB.Text = "";
            txtEmail.Text = "";
            txtJobStartDate.Text = "";
            txtJoinDate.Text = "";
            txtPpNo.Text = "";
            txtRemarks.Text = "";
            txtStaffName.Text = "";
        }
        private void FillGridview()
        {
            gvMemberInfo.DataSource = BL_Staff.GetStaffDetail(1, BK_Session.GetSession().BranchId, "", "");
            gvMemberInfo.DataBind();
        }
    }
}