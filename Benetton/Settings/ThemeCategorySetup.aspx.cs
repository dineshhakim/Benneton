using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Benetton.Classes;
using BusinessLogic;
using Domain;
using ProudMonkey.Common.Controls;

namespace Benetton.Settings
{
    public partial class ThemeCategorySetup : System.Web.UI.Page
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
            }
        }
        private void FillGridview()
        {
            gvThemeSetup.DataSource = BL_Theme.GetTheme(1, 0, "", "");
            gvThemeSetup.DataBind();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnsave.Text = "Save";
            btnsave.CommandName = "Save";
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text == "")
            {
                _msgbox.ShowWarning("Category Name is Mandatory");
            }
            if (btnsave.CommandName == "Update")
            {
                InsUpdDelTheme('U', Convert.ToInt32((string)btnsave.CommandArgument));
                btnsave.Text = "Save";
                btnsave.CommandName = "Save";
            }
            else
            {
                InsUpdDelTheme('I', 0);
                FillGridview();
                ClearAll();
            }
        }
        private void InsUpdDelTheme(char Event, int id)
        {
            var msg = "";

            if (Event == 'I' || Event == 'U')
            {
                var objTheme = new ThemeSetup(id, txtCategoryName.Text);
                msg = BL_Theme.InsUpdDelTheme(Event, objTheme, out id);

            }
            else
            {
                var objTheme = new ThemeSetup(id, "");
                msg = BL_Theme.InsUpdDelTheme(Event, objTheme, out id);
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
            txtCategoryName.Text = "";
        }

        protected void gvThemeSetup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                InsUpdDelTheme('D', Convert.ToInt32(e.CommandArgument));
                FillGridview();
            }

            else
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var row = gvThemeSetup.Rows[index];
                var lblCategoryId = (Label)row.FindControl("lblCategoryId");
                var lblCategory = (Label)row.FindControl("lblCategory");
                txtCategoryName.Text = lblCategory.Text;
                btnsave.Text = "Update";
                btnsave.CommandName = "Update";
                btnsave.CommandArgument = lblCategoryId.Text;
            }
        }

        protected void gvThemeSetup_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

    }
}