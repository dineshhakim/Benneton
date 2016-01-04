using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessLogic;
using ProudMonkey.Common.Controls;

namespace Benetton.Menu
{
    public partial class AssignRoles : System.Web.UI.Page
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
                FillgvUserRoles();
                btnSave.Attributes.Add("onclick", "return confirm('Confirm To Save');");
            }
        }

        private void FillgvUserRoles()
        {
            DataTable dt = new DataTable();
            dt = BL_UserRoles.GetUserRoles(1, 0, "");
            if (dt.Rows.Count > 0)
            {
                gvUsersRoles.DataSource = dt;
                gvUsersRoles.DataBind();
            }
            else
            {
                gvUsersRoles.DataSource = new string[] { };
                gvUsersRoles.DataBind();
            }
        }
        protected void gvUsersRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit1")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                // Retrieve the row that contains the button clicked 
                // by the user from the Rows collection.      
                GridViewRow row = gvUsersRoles.Rows[index];
                Label lblId = (Label)row.FindControl("lblId");
                Label lblRoleId = (Label)row.FindControl("lblRoleId");
                Label lblUserId = (Label)row.FindControl("lblUserId");
                ddlRoles.SelectedValue = lblRoleId.Text;
                ddlUsers.SelectedValue = lblUserId.Text;
                btnSave.CommandName = "Update";
                btnSave.Text = "Update";
                btnSave.CommandArgument = lblId.Text;
            }
            else if (e.CommandName == "Delete1")
            {
                InsUpdDelUserRoles('D', Convert.ToInt32(e.CommandArgument));
            }

        }

        private void InsUpdDelUserRoles(char EVENT, int ID)
        {
            BL_UserRoles obj = new BL_UserRoles();
            obj.EVENT = EVENT;
            obj.ID = ID;
            obj.ROLE_ID = Convert.ToInt32((string) ddlRoles.SelectedValue);
            obj.USER_ID = Convert.ToInt32((string) ddlUsers.SelectedValue);
            string msg = "";
            msg = obj.InsUpdDelUserRoles(out ID);
            if (msg == "Record Inserted Successfully" || msg == "Record Updated Successfully" || msg == "Record Deleted Successfully")
            {
                msgbox.ShowSuccess(msg);
                ddlUsers.SelectedValue = "0";
                ddlRoles.SelectedValue = "0";
                btnSave.CommandName = "Save";
                btnSave.Text = "Save";
                FillgvUserRoles();
            }
            else
            {
                msgbox.ShowWarning(msg);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (((Button)sender).CommandName == "Save")
            {
                InsUpdDelUserRoles('I', 0);
            }
            else
            {
                InsUpdDelUserRoles('U', Convert.ToInt32(((Button)sender).CommandArgument));
            }
        }

    }
}