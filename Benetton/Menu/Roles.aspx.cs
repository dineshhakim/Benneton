using System;
using System.Data;
using System.Web.UI.WebControls;
using Benetton.Classes;
using BusinessLogic;
using ProudMonkey.Common.Controls;

namespace Benetton.Menu
{
    public partial class Roles : System.Web.UI.Page
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
                FillgvRoles();
                filldropdown();
            }

        }

        #region Roles
        
      
        protected void btnRole_Click(object sender, EventArgs e)
        {
            if (((Button)sender).CommandName == "Save")
            {
                InsUpdDelRoles('I', 0);
            }
            else
            {
                InsUpdDelRoles('U', Convert.ToInt32(((Button)sender).CommandArgument));
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
            }
            else if (e.CommandName == "Delete1")
            {
                InsUpdDelRoles('D', Convert.ToInt32(e.CommandArgument));
            }
        }

        private void InsUpdDelRoles(char Event, int Id)
        {
            BL_Roles obj = new BL_Roles();
            obj.EVENT = Event;
            obj.ROLE_ID = Id;
            obj.ROLE_NAME = txtRoleName.Text;
            string msg = "";
            msg = obj.InsUpdDelRoles(out Id);
            if (msg != "Record Inserted Successfully" || msg != "Record Updated Successfully" || msg != "Record Deleted Successfully")
            {
                msgbox.ShowSuccess(msg);
                FillgvRoles();
                filldropdown();
                txtRoleName.Text = "";
                btnRole.CommandName = "Save";
            }
            else
            {
                msgbox.ShowWarning(msg);
            }
        }
        private void FillgvRoles()
        {
            DataTable dt = new DataTable();
            dt = BL_Roles.GetRoles(1, 0, "");
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
        #endregion

        #region Menu Assign
       


        protected void filldropdown()
        {
            ddlMainMenu = BL_FillDropDown.FillddlMainMenu(ddlMainMenu, 1, 0, "");
            ddlRoleName = BL_FillDropDown.FillddlRoles(ddlRoleName, 1, 0, "");
        }
        protected void FillGrid()
        {
            DataTable dt = new DataTable();
            dt = BL_ChildMenu.GetChildMenu(2, Convert.ToInt32((string) ddlMainMenu.SelectedValue), ddlRoleName.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                gvAllMenu.DataSource = dt;
                gvAllMenu.DataBind();
            }
            else
            {
                gvAllMenu.DataSource = new string[] { };
                gvAllMenu.DataBind();
            }
            dt = BL_MenuAssign.GetMenuAssign(1, Convert.ToInt32((string) ddlMainMenu.SelectedValue), 0, ddlRoleName.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                gvAssignedMenu.DataSource = dt;
                gvAssignedMenu.DataBind();
            }
            else
            {
                gvAssignedMenu.DataSource = dt;
                gvAssignedMenu.DataBind();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int j = 0;
                foreach (GridViewRow gr in gvAllMenu.Rows)
                {
                    HiddenField hdChildMenuID = (HiddenField)gr.FindControl("hdChildMenuID");
                    CheckBox chkTransfer = (CheckBox)gr.FindControl("chkMenu");
                    BL_MenuAssign st = new BL_MenuAssign();
                    if (chkTransfer.Checked)
                    {
                        st.EVENT = 'I';
                        st.ChildMenuID = int.Parse(hdChildMenuID.Value.ToString());
                        st.RoleID = Convert.ToInt32((string) ddlRoleName.SelectedValue.ToString());
                        st.MainMenuID = Convert.ToInt32((string) ddlMainMenu.SelectedValue.ToString());
                        int Id = 0;
                        st.InsUpdDelMenuAssign(out Id);
                        j++;
                    }
                }
                if (j > 0)
                {
                    msgbox.ShowInfo("Menu granted", 10, 400);
                    FillGrid();
                    
                    //  Response.Redirect("~/Admin/MenuAssign.aspx");
                }
                else
                {
                    msgbox.ShowInfo("Please select child menu", 10, 400);
                }


            }
            catch (Exception ex)
            {
                msgbox.ShowError(ex.Message, 10, 400);
            }
        }

        protected void ddlRoleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
        protected void ddlMainMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
        protected void gvAssignedMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete1")
            {
                BL_MenuAssign obj = new BL_MenuAssign();
                obj.EVENT = 'D';
                obj.MainMenuID = 0;
                obj.ChildMenuID = 0;
                obj.ID = Convert.ToInt32(e.CommandArgument);
                int Id = 0;
                string msg = obj.InsUpdDelMenuAssign(out Id);
                if (msg != "")
                {
                    msgbox.ShowSuccess(msg);
                    FillGrid();
                }
            }
        }

        #endregion
    }
}