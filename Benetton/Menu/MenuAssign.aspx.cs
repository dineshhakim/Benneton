using System;
using System.Data;
using System.Web.UI.WebControls;
using Benetton.Classes;
using BusinessLogic;
using ProudMonkey.Common.Controls;

namespace Benetton.Menu
{
    public partial class MenuAssign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.filldropdown();              
                //this.FillGrid();
                if (ddlRoleName.SelectedValue == "0" && ddlMainMenu.SelectedValue == "0")
                {
                    gvAllMenu.DataSource = new string[] { };
                    gvAllMenu.DataBind();
                    gvAssignedMenu.DataSource = new string[] { };
                    gvAssignedMenu.DataBind();
                }
            }
        }
        MessageBox msgBox;
        protected void Page_Init(object sender, EventArgs e)
        {
            msgBox = new MessageBox()
            {

            };

            this.pnlMsgBox.Controls.Clear();
            this.pnlMsgBox.Controls.Add(msgBox);
        }
        protected void filldropdown()
        {
            ddlMainMenu = BL_FillDropDown.FillddlMainMenu(ddlMainMenu, 1, 0, "");
            ddlRoleName = BL_FillDropDown.FillddlRoles(ddlRoleName, 1, 0, "");
        }
        protected void FillGrid()
        {
            var dt = new DataTable();
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
                var j = 0;
                foreach (GridViewRow gr in gvAllMenu.Rows)
                {
                    var hdChildMenuID = (HiddenField)gr.FindControl("hdChildMenuID");
                    var chkTransfer = (CheckBox)gr.FindControl("chkMenu");
                    var st = new BL_MenuAssign();
                    if (chkTransfer.Checked)
                    {
                        st.EVENT = 'I';
                        st.ChildMenuID = int.Parse(hdChildMenuID.Value.ToString());
                        st.RoleID = Convert.ToInt32((string) ddlRoleName.SelectedValue.ToString());
                        st.MainMenuID = Convert.ToInt32((string) ddlMainMenu.SelectedValue.ToString());
                        var Id = 0;
                        st.InsUpdDelMenuAssign(out Id);
                        j++;
                    }
                }
                if (j > 0)
                {
                    msgBox.ShowSuccess("Menu granted");
                    FillGrid();
                    //  Response.Redirect("~/Admin/MenuAssign.aspx");
                }
                else
                {
                    msgBox.ShowInfo("Please select child menu", 10, 400);
                }


            }
            catch (Exception ex)
            {
                msgBox.ShowError(ex.Message, 10, 400);
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
                var obj = new BL_MenuAssign();
                obj.EVENT = 'D';
                obj.MainMenuID = 0;
                obj.ChildMenuID = 0;
                obj.ID = Convert.ToInt32(e.CommandArgument);
                var Id = 0;
                var msg = obj.InsUpdDelMenuAssign(out Id);
                if (msg != "")
                {
                    msgBox.ShowSuccess(msg);
                    FillGrid();
                }
            }
        }
    }
}