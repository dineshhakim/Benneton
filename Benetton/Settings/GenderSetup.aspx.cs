using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Benetton.Classes;
using BusinessLogic;
using ProudMonkey.Common.Controls;
using Domain;

namespace Benetton.Settings
{
    public partial class GenderSetup : System.Web.UI.Page
    {
        private MessageBox _msgBox;

        protected void Page_Init(Object sender,EventArgs e)
        {
            _msgBox = new MessageBox()
            {
            };
            this.pnlMsgBox.Controls.Clear();
            this.pnlMsgBox.Controls.Add(_msgBox);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
            }
        }

        private void FillGridView()
        {
            gvGenderSetup.DataSource = BL_Gender.GetAllGender(1,0, "", "");
            gvGenderSetup.DataBind();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (txtGender.Text=="")
            {
                _msgBox.ShowWarning("Gender is mandatory");
            }
            if (btnsave.CommandName=="Update")
            {
                InsUpdDelGender('U',Convert.ToInt32((string)btnsave.CommandArgument));
                btnsave.Text = "Save";
                btnsave.CommandName = "Save";
            }
            else
            {
                InsUpdDelGender('I', 0);
                FillGridView();
                ClearAll();
            }
        }

        private void InsUpdDelGender(char Event, int id)
        {
            var msg = "";

            if (Event == 'I' || Event == 'U')
            {
                var objGender = new GenderClass(id, txtGender.Text);
                msg = BL_Gender.InsUpdDelGender(Event, objGender, out id);

            }
            else
            {
                var objGender = new GenderClass(id, "");
                msg = BL_Gender.InsUpdDelGender(Event, objGender, out id);
            }

            if (DatabaseMessage.ContainMessage(msg))
            {
                _msgBox.ShowSuccess(msg);

            }
            else
            {
                _msgBox.ShowWarning(msg);
            }
            FillGridView();
            ClearAll();
        }
        private void ClearAll()
        {

            txtGender.Text = "";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnsave.Text = "Save";
            btnsave.CommandName = "Save";
        }

        protected void gvGenderSetup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                InsUpdDelGender('D', Convert.ToInt32(e.CommandArgument));
                FillGridView();
            }

            else
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var row = gvGenderSetup.Rows[index];
                var lblGenderId = (Label)row.FindControl("lblGenderId");
                var lblGender = (Label)row.FindControl("lblGender");
                txtGender.Text = lblGender.Text;
                btnsave.Text = "Update";
                btnsave.CommandName = "Update";
                btnsave.CommandArgument = lblGenderId.Text;
            }
        }

        protected void gvGenderSetup_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

      
    }
}