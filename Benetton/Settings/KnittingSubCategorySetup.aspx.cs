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
    public partial class KnittingSubCategorySetup : System.Web.UI.Page
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
                FillddlCategory();
                FillGridview();
            }
        }
        private void FillddlCategory()
        {
            ddlCategory = BL_FillDropDown.FillddlKnittingCategory(ddlCategory, 1, 0, "");
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (txtSubCategoryName.Text == "")
            {
                _msgbox.ShowWarning("SubCategory Name is Mandatory");
            }
            if (btnsave.CommandName == "Update")
            {
                InsUpdDelKnittingSubCategory('U', Convert.ToInt32((string)btnsave.CommandArgument));
                btnsave.Text = "Save";
                btnsave.CommandName = "Save";
            }
            else
            {
                if (ddlCategory.SelectedItem.Text == "Select")
                {
                    _msgbox.ShowWarning("Select the category");
                    return;
                }
                InsUpdDelKnittingSubCategory('I', 0);
                FillGridview();
                ClearAll();
            }
        }
        private void InsUpdDelKnittingSubCategory(char Event, int id)
        {
            var msg = "";

            if (Event == 'I' || Event == 'U')
            {
                var objKnitting = new KnittingSubCategory(id, int.Parse(ddlCategory.SelectedValue), "", txtSubCategoryName.Text);
                msg = BL_Knitting_SubCategory.InsUpdDelKnittingSubCategory(Event, objKnitting, out id);

            }
            else
            {
                var objKnitting = new KnittingSubCategory(id, int.Parse(ddlCategory.SelectedValue), "", "");
                msg = BL_Knitting_SubCategory.InsUpdDelKnittingSubCategory(Event, objKnitting, out id);
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
            ddlCategory.SelectedValue = "0";
            txtSubCategoryName.Text = "";
        }
        private void FillGridview()
        {
            gvKnittingSubCategorySetup.DataSource = BL_Knitting_SubCategory.GetKnittingSubCategory(1, 0, "", "");
            gvKnittingSubCategorySetup.DataBind();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnsave.Text = "Save";
            btnsave.CommandName = "Save";
        }

        protected void gvKnittingSubCategorySetup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                InsUpdDelKnittingSubCategory('D', Convert.ToInt32(e.CommandArgument));
                FillGridview();
            }

            else
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var row = gvKnittingSubCategorySetup.Rows[index];
                var lblCategoryId = (Label)row.FindControl("lblCategoryId");
                var lblCategory = (Label)row.FindControl("lblCategory");
                var lblSubCategory = (Label)row.FindControl("lblSubCategory");
                txtSubCategoryName.Text = lblSubCategory.Text;
                ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByText(lblCategory.Text));
                btnsave.Text = "Update";
                btnsave.CommandName = "Update";
                btnsave.CommandArgument = lblCategoryId.Text;
            }
        }

        protected void gvKnittingSubCategorySetup_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}