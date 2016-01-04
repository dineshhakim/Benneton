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
    public partial class SizeSetup : System.Web.UI.Page
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
            gvSizeSetup.DataSource = BL_Size.GetSize(1, 0, "", "");
            gvSizeSetup.DataBind();
        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (txtSize.Text == "")
            {
                _msgbox.ShowWarning("Size is Mandatory");
            }
           
            if (btnsave.CommandName == "Update")
            {
                InsUpdDelSize('U', Convert.ToInt32((string)btnsave.CommandArgument));
                btnsave.Text = "Save";
                btnsave.CommandName = "Save";
            }
            else
            {
                InsUpdDelSize('I', 0);
                FillGridview();
                ClearAll();
            }
        }
        private void InsUpdDelSize(char Event, int id)
        {
            var msg = "";

            if (Event == 'I' || Event == 'U')
            {
                var objSize = new SizeClass(id,  txtSize.Text);
                msg = BL_Size.InsUpdDelSize(Event, objSize, out id);

            }
            else
            {
                var objSize = new SizeClass(id, "");
                msg = BL_Size.InsUpdDelSize(Event, objSize, out id);
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
            
            txtSize.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnsave.Text = "Save";
            btnsave.CommandName = "Save";
        }

        protected void gvSizeSetup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                InsUpdDelSize('D', Convert.ToInt32(e.CommandArgument));
                FillGridview();
            }

            else
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var row = gvSizeSetup.Rows[index];
                var lblSizeId = (Label)row.FindControl("lblSizeId");
                var lblSize = (Label)row.FindControl("lblSize");
                txtSize.Text = lblSize.Text;
                btnsave.Text = "Update";
                btnsave.CommandName = "Update";
                btnsave.CommandArgument = lblSizeId.Text;
            }
        }

        protected void gvSizeSetup_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

   
    }
}