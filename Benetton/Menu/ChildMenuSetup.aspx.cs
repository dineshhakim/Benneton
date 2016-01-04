using System;
using System.Data;
using System.Web.UI.WebControls;
using Benetton.Classes;
using BusinessLogic;
using ProudMonkey.Common.Controls;

namespace Benetton.Menu
{
    public partial class ChildMenuSetup : System.Web.UI.Page
    {
        MessageBox msgBox;
        protected void Page_Init(object sender, EventArgs e)
        {
            msgBox = new MessageBox()
            {
            };

            this.pnlMsgBox.Controls.Clear();
            this.pnlMsgBox.Controls.Add(msgBox);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillddlMainMenu();
                this.FillGrid();
            }
        }
        #region Event
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.CommandName == "Save")
            {
                InsUpdDelChildMenu('I', 0);
            }
            else
            {
                InsUpdDelChildMenu('U', Convert.ToInt32((string) btnSubmit.CommandArgument));
            }

        }
        protected void gvChildMenu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (gvChildMenu.PageCount <= e.NewPageIndex)
                {
                    gvChildMenu.PageIndex = 0;
                }
                else
                {
                    gvChildMenu.PageIndex = e.NewPageIndex;
                }
                this.FillGrid();
            }
            catch (Exception ex)
            {
                msgBox.ShowError(ex.Message);
            }
        }
        #endregion
        #region Fill
        private void FillddlMainMenu()
        {
            ddlMainManu = BL_FillDropDown.FillddlMainMenu(ddlMainManu, 1, 0, "");
        }
        protected void FillGrid()
        {
            DataTable dt = new DataTable();
            dt = BL_ChildMenu.GetChildMenu(1, Convert.ToInt32((string) ddlMainManu.SelectedValue), "");
            if (dt.Rows.Count > 0)
            {
                gvChildMenu.DataSource = dt;
                gvChildMenu.DataBind();
            }
            else
            {
                gvChildMenu.DataSource = new string[] { };
                gvChildMenu.DataBind();
            }
        }
        #endregion

        #region cleartext
        protected void cleartext()
        {
            txtChildMenuName.Text = "";
            txtChildMenuUrl.Text = "";
            //   ddlMainManu.SelectedValue = "0";
            btnSubmit.Text = "Save";
            btnSubmit.CommandName = "Save";
        }
        #endregion





        //protected void gdvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName.Equals("Editone"))
        //        {
        //            int id = int.Parse(e.CommandArgument.ToString());
        //            int index = Convert.ToInt32(e.CommandArgument);
        //            GridViewRow row = gdvCategory.Rows[index];
        //            txtChildMenuUrl.Text = ((Label)row.FindControl("lblNavigate")).Text;
        //            Label lblMainMenu = (Label)row.FindControl("lblMainMenu");
        //            ddlMainManu.SelectedIndex = ddlMainManu.Items.IndexOf(ddlMainManu.Items.FindByText(lblMainMenu.Text));

        //            txtChildMenuName.Text = ((Label)row.FindControl("lblChildMenu")).Text;
        //            hdnMainID.Value = ((HiddenField)row.FindControl("hdnMainMenu")).Value;
        //            hdnChildID.Value = ((HiddenField)row.FindControl("hdnChildMenu")).Value;
        //            btnSubmit.Text = "Update";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msgBox.ShowError(ex.Message);
        //    }
        //}
        #region InsUpdDel
        private void InsUpdDelChildMenu(char Event, int Id)
        {
            BL_ChildMenu obj = new BL_ChildMenu();
            obj.EVENT = Event;
            if (txtOrder.Text != "")
            {
                obj.Odr = Convert.ToInt32((string) txtOrder.Text);
            }
            if (Event == 'I')
            {
                obj.ChildMenuID = Id;
                obj.MainMenuID = Convert.ToInt32((string) ddlMainManu.SelectedValue);
                obj.MenuName = txtChildMenuName.Text;
                obj.NavigationURL = txtChildMenuUrl.Text;

            }
            else if (Event == 'U')
            {
                obj.ChildMenuID = Id;
                obj.MainMenuID = Convert.ToInt32((string) ddlMainManu.SelectedValue);
                obj.MenuName = txtChildMenuName.Text;
                obj.NavigationURL = txtChildMenuUrl.Text;
            }
            else
            {
                obj.ChildMenuID = Id;
                obj.MainMenuID = Convert.ToInt32((string) ddlMainManu.SelectedValue);
                obj.MenuName = txtChildMenuName.Text;
                obj.NavigationURL = txtChildMenuUrl.Text;
            }
            string msg = obj.InsUpdDeleteMainMenu(out Id);
            if (msg != "")
            {
                msgBox.ShowSuccess(msg);
            }
            FillGrid();
            cleartext();

        }
        #endregion


        protected void gvChildMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Editone"))
            {
                int id = int.Parse(e.CommandArgument.ToString());
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvChildMenu.Rows[index];
                txtChildMenuUrl.Text = ((Label)row.FindControl("lblNavigate")).Text;
                Label lblMainMenu = (Label)row.FindControl("lblMainMenu");
                ddlMainManu.SelectedIndex = ddlMainManu.Items.IndexOf(ddlMainManu.Items.FindByText(lblMainMenu.Text));
                txtChildMenuName.Text = ((Label)row.FindControl("lblChildMenu")).Text;
                Label lblOrder = (Label)row.FindControl("lblOrder");
                txtOrder.Text = lblOrder.Text;
                hdnChildID.Value = ((HiddenField)row.FindControl("hdnChildMenu")).Value;
                btnSubmit.Text = "Update";
                btnSubmit.CommandName = "Update";
                btnSubmit.CommandArgument = hdnChildID.Value;
            }
            else if (e.CommandName == "Delete1")
            {
                InsUpdDelChildMenu('D', Convert.ToInt32(e.CommandArgument));
            }
        }
        protected void ddlMainManu_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}