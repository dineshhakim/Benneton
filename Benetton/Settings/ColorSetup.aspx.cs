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
    public partial class ColorSetup : System.Web.UI.Page
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
                FillCategory();
                FillStyle();
            }
        }

        private void FillStyle()
        {
            ddlStyle = BL_FillDropDown.FillddlStyle(ddlStyle, 1, 0, "");
        }

        private void FillCategory()
        {
            ddlCategory = BL_FillDropDown.FillddlKnittingCategory(ddlCategory, 1, 0, "");
        }
        private void FillGridview()
        {
            gvColorSetup.DataSource = BL_Color.GetColorDetails(1, 0, 0, "");
            gvColorSetup.DataBind();
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (txtColorCode.Text == "")
            {
                _msgbox.ShowWarning("Color Code is Mandatory");
            }
            if (txtColorName.Text=="")
            {
                _msgbox.ShowWarning("Color Name is Mandatory"); 
            }
            if (btnsave.CommandName == "Update")
            {
                InsUpdDelColor('U', Convert.ToInt32((string)btnsave.CommandArgument));
                btnsave.Text = "Save";
                btnsave.CommandName = "Save";
            }
            else
            {
                InsUpdDelColor('I', 0);
                FillGridview();
                ClearAll();
            }
        }
        private void InsUpdDelColor(char Event, int id)
        {
            var msg = "";

            if (Event == 'I' || Event == 'U')
            {
                var objColor = new Color(id,Convert.ToInt32((string)ddlCategory.SelectedValue),Convert.ToInt32((string)ddlStyle.SelectedValue),txtColorCode.Text,txtColorName.Text);
                msg = BL_Color.InsUpdDelColor(Event, objColor, out id);

            }
            else
            {
                var objColor = new Color(id, 0,0,"","");
                msg = BL_Color.InsUpdDelColor(Event, objColor, out id);
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
            ddlCategory.SelectedValue="0";
            ddlStyle.SelectedValue = "0";
            txtColorCode.Text = "";
            txtColorName.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnsave.Text = "Save";
            btnsave.CommandName = "Save";
        }

        protected void gvColorSetup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                InsUpdDelColor('D', Convert.ToInt32(e.CommandArgument));
                FillGridview();
            }

            else
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var row = gvColorSetup.Rows[index];
                var lblColorId = (Label)row.FindControl("lblColorId");
                var lblCategory = (Label)row.FindControl("lblCategory");
                var lblStyle = (Label)row.FindControl("lblStyle");
                var lblColorCode = (Label)row.FindControl("lblColorCode");
                var lblColorName = (Label)row.FindControl("lblColorName");
                txtColorCode.Text = lblColorCode.Text;
                txtColorName.Text = lblColorName.Text;
                ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByText(lblCategory.Text));
                ddlStyle.SelectedIndex = ddlStyle.Items.IndexOf(ddlStyle.Items.FindByText(lblStyle.Text));
                ddlStyle.SelectedItem.Text = lblStyle.Text;
                btnsave.Text = "Update";
                btnsave.CommandName = "Update";
                btnsave.CommandArgument = lblColorId.Text;
            }
        }

        protected void gvColorSetup_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}