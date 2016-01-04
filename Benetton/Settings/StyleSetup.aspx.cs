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
    public partial class StyleSetup : System.Web.UI.Page
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
            gvStyleSetup.DataSource = BL_Style.GetStyleDetails(1, 0, "", "");
            gvStyleSetup.DataBind();
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (txtStyle.Text == "")
            {
                _msgbox.ShowWarning("Style is Mandatory");
            }
           
            if (btnsave.CommandName == "Update")
            {
                InsUpdDelStyle('U', Convert.ToInt32((string)btnsave.CommandArgument));
                btnsave.Text = "Save";
                btnsave.CommandName = "Save";
            }
            else
            {
                InsUpdDelStyle('I', 0);
                FillGridview();
                ClearAll();
            }
        }
        private void InsUpdDelStyle(char Event, int id)
        {
            var msg = "";

            if (Event == 'I' || Event == 'U')
            {
                var objStyle = new StyleClass(id, txtStyle.Text, txtDescription.Text);
                msg = BL_Style.InsUpdDelStyle(Event, objStyle, out id);

            }
            else
            {
                var objStyle = new StyleClass(id, "", "");
                msg = BL_Style.InsUpdDelStyle(Event, objStyle, out id);
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
            txtStyle.Text = "";
            txtDescription.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnsave.Text = "Save";
            btnsave.CommandName = "Save";
        }

        protected void gvStyleSetup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                InsUpdDelStyle('D', Convert.ToInt32(e.CommandArgument));
                FillGridview();
            }

            else
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var row = gvStyleSetup.Rows[index];
                var lblStyleId = (Label)row.FindControl("lblStyleId");
                var lblStyle = (Label)row.FindControl("lblStyle");
                var lblDescription = (Label)row.FindControl("lblDescription");
                txtStyle.Text = lblStyle.Text;
                txtDescription.Text = lblDescription.Text;
                btnsave.Text = "Update";
                btnsave.CommandName = "Update";
                btnsave.CommandArgument = lblStyleId.Text;
            }
        }

        protected void gvStyleSetup_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}