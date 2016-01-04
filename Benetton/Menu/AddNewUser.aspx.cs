using System;
using System.Data;
using System.Web.UI.WebControls;
using Benetton.Classes;
using BusinessLogic;
using ProudMonkey.Common.Controls;

namespace Benetton.Menu
{
    public partial class AddNewUser : System.Web.UI.Page
    {
        ProudMonkey.Common.Controls.MessageBox msgbox;

        protected void Page_Init(object sender, EventArgs e)
        {
            msgbox = new MessageBox()
            {

            };
            this.pnlMsgBox.Controls.Clear();
            this.pnlMsgBox.Controls.Add(msgbox);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FillddlRoles();
                FillgvUsers();
                FillddlBranch();
                FillddlStaffName();
                btnSave.Attributes.Add("onclick", "return confirm('Confirm To Save');");
            }
        }

       

        #region Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (((Button)sender).CommandName == "Save")
            {
                InsupdDeleteusers('I', 0);
            }
            else
            {
                InsupdDeleteusers('U', Convert.ToInt32((string) btnSave.CommandArgument));
            }

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit1")
            {
                var index = Convert.ToInt32(e.CommandArgument);    
                var row = gvUsers.Rows[index];
                var lblId = (Label)row.FindControl("lblId");
                var lblUserName = (Label)row.FindControl("lblUserName");
                var lblEmail = (Label)row.FindControl("lblEmail");
                var lblContactNo = (Label)row.FindControl("lblContactNo");
                var lblAddress = (Label) row.FindControl("lblAddress");
                var lblRole = (Label)row.FindControl("lblRole");

                var lblStaffName = (Label) row.FindControl("lblStaffName");

                txtEmail.Text = lblEmail.Text;
                txtAddress.Text = lblAddress.Text;
                txtContactNo.Text = lblContactNo.Text;
                txtUserName.Text = lblUserName.Text;
                ddlStaffName.SelectedIndex = ddlStaffName.Items.IndexOf(ddlStaffName.Items.FindByText(lblStaffName.Text));
                ddlRoles.SelectedIndex = ddlRoles.Items.IndexOf(ddlRoles.Items.FindByText(lblRole.Text));
                btnSave.CommandArgument = lblId.Text;
                btnSave.Text = "Update";
                btnSave.CommandName = "Update";
                btnReset.Visible = true;
                btnReset.CommandArgument = lblId.Text;

            }
            else if (e.CommandName == "Delete1")
            {
                InsupdDeleteusers('D', Convert.ToInt32(e.CommandArgument));
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            InsupdDeleteusers('C', Convert.ToInt32((string) btnReset.CommandArgument));
        }
        #endregion

        #region Fill

        private void FillddlStaffName()
        {
            ddlStaffName = BL_FillDropDown.FillddlStaffName(ddlStaffName,1 , BK_Session.GetSession().BranchId, "");
        }

        private void FillddlRoles()
        {
            ddlRoles = BL_FillDropDown.FillddlRoles(ddlRoles, 1, 0, "");
        }

        private void FillgvUsers()
        {
            var dt = new DataTable();
            dt = BL_Users.GetUsers(1, Convert.ToInt32(BK_Session.GetSession().BranchId), "");
            if (dt.Rows.Count > 0)
            {
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
            else
            {
                gvUsers.DataSource = new string[] { };
                gvUsers.DataBind();
            }

        }
        private void FillddlBranch()
        {
            ddlBranch = BL_FillDropDown.FillddlBranch(ddlBranch, 1, 0, "", "");
        }
        #endregion


        #region InsUpdDel
        private void InsupdDeleteusers(char Event, int Id)
        {
            var obj = new BL_Users();
            if (Event == 'I')
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    obj.EVENT = 'I';
                  //  obj.NAME = txtFirstName.Text + " " + txtLastName.Text;
                    obj.STAFF_ID = Convert.ToInt32((string) ddlStaffName.SelectedValue);
                    obj.PWD = EncryptDecrypt.base64Encode(txtPassword.Text);
                    obj.CONTACT_NO = txtContactNo.Text;
                    obj.ADDRESS = txtAddress.Text;
                    obj.EMAIL_ID = txtEmail.Text;
                    obj.REGISTERED_BY = Convert.ToInt32(BK_Session.GetSession().UserId);
                    obj.REGISTERED_DATE = System.DateTime.Now;
                    obj.USER_NAME = txtUserName.Text + lblCompanyCode.Text;

                    obj.USER_STATUS = true;
                    obj.ROLE_ID = Convert.ToInt32((string) ddlRoles.SelectedValue);
                    obj.BranchId = Convert.ToInt32(BK_Session.GetSession().BranchId);
                    Id = 0;
                    var msg = "";
                    msg = obj.InsUpdDeleteUsers(out Id);
                    if (msg == "Record Inserted Successfully")
                    {
                        msgbox.ShowSuccess(msg);
                        Clear();
                    }
                    else
                    {
                        msgbox.ShowWarning(msg);
                    }
                }
            }
            else if (Event == 'U')
            {
                obj.EVENT = Event;
                obj.ID = Id;
                obj.STAFF_ID = Convert.ToInt32((string)ddlStaffName.SelectedValue);
                obj.PWD = EncryptDecrypt.base64Encode(txtPassword.Text + lblCompanyCode.Text);
                obj.CONTACT_NO = txtContactNo.Text;
                obj.ADDRESS = txtAddress.Text;
                obj.EMAIL_ID = txtEmail.Text;
                obj.REGISTERED_BY = Convert.ToInt32(BK_Session.GetSession().UserId);
                obj.REGISTERED_DATE = BK_Session.GetSession().OpDate;
                obj.USER_NAME = txtUserName.Text;
                obj.USER_STATUS = true;
                obj.ROLE_ID = Convert.ToInt32((string) ddlRoles.SelectedValue);
                obj.BranchId = Convert.ToInt32(BK_Session.GetSession().BranchId);
                Id = 0;
                var msg = "";
                msg = obj.InsUpdDeleteUsers(out Id);
                if (msg == "Record Updated Successfully")
                {
                    msgbox.ShowSuccess(msg);
                    Clear();
                }
                else
                {
                    msgbox.ShowWarning(msg);
                }
            }
            else if (Event == 'D')
            {
                obj.EVENT = Event;
                obj.ID = Id;
                obj.STAFF_ID = Convert.ToInt32((string)ddlStaffName.SelectedValue);
                obj.PWD = EncryptDecrypt.base64Encode(txtPassword.Text);
                obj.ADDRESS = txtAddress.Text;
                obj.CONTACT_NO = txtContactNo.Text;
                obj.EMAIL_ID = txtEmail.Text;
                obj.REGISTERED_BY = Convert.ToInt32(BK_Session.GetSession().UserId);
                obj.REGISTERED_DATE = BK_Session.GetSession().OpDate;
                obj.USER_NAME = txtUserName.Text;

                Id = 0;
                var msg = "";
                msg = obj.InsUpdDeleteUsers(out Id);
                if (msg == "Record Deleted Successfully")
                {
                    msgbox.ShowSuccess(msg);
                    Clear();
                }
                else
                {
                    msgbox.ShowWarning(msg);
                }
            }
            else
            {
                obj.EVENT = Event;
                obj.ID = Id;
                obj.STAFF_ID = Convert.ToInt32((string)ddlStaffName.SelectedValue);
                var pwd = (txtPassword.Text).ToLower();
                obj.PWD = EncryptDecrypt.base64Encode(pwd);
                obj.ADDRESS = txtAddress.Text;
                obj.CONTACT_NO = txtContactNo.Text;
                obj.EMAIL_ID = txtEmail.Text;
                obj.REGISTERED_BY = Convert.ToInt32(BK_Session.GetSession().UserId);
                obj.REGISTERED_DATE = BK_Session.GetSession().OpDate;
                obj.USER_NAME = txtUserName.Text;
                Id = 0;
                var msg = "";
                msg = obj.InsUpdDeleteUsers(out Id);
                if (msg == "Password Changed Successfully")
                {
                    msgbox.ShowSuccess(msg);
                    Clear();
                }
                else
                {
                    msgbox.ShowWarning(msg);
                }
            }

            FillgvUsers();
        }
        #endregion


        private void Clear()
        {
            ddlStaffName.SelectedValue = "0";
            txtConfirmPassword.Text = "";
            txtContactNo.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            txtAddress.Text = "";
            ddlRoles.SelectedValue = "0";
            btnSave.Text = "Save";
            btnSave.CommandName = "Save";
            btnReset.Visible = false;
        }


    }
}