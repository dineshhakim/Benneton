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
    public partial class SeasonSetup : System.Web.UI.Page
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
            gvSeasonSetup.DataSource = BL_Season.GetSeason(1, 0, "", "");
            gvSeasonSetup.DataBind();
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {

            if (txtSeason.Text == "")
            {
                _msgbox.ShowWarning("Season is Mandatory");
            }
            if (btnsave.CommandName == "Update")
            {
                InsUpdDelSeason('U', Convert.ToInt32((string)btnsave.CommandArgument));
                btnsave.Text = "Save";
                btnsave.CommandName = "Save";
            }
            else
            {
                InsUpdDelSeason('I', 0);
                FillGridview();
                ClearAll();
            }
        }
        private void InsUpdDelSeason(char Event, int id)
        {
            var msg = "";

            if (Event == 'I' || Event == 'U')
            {
                var objSeason = new SeasonClass(id,  txtSeason.Text);
                msg = BL_Season.InsUpdDelSeason(Event, objSeason, out id);

            }
            else
            {
                var objSeason = new SeasonClass(id, "");
                msg = BL_Season.InsUpdDelSeason(Event, objSeason, out id);
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
          
            txtSeason.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnsave.Text = "Save";
            btnsave.CommandName = "Save";
        }

        protected void gvSeasonSetup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                InsUpdDelSeason('D', Convert.ToInt32(e.CommandArgument));
                FillGridview();
            }

            else
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var row = gvSeasonSetup.Rows[index];
                var lblSeasonId = (Label)row.FindControl("lblSeasonId");
                var lblSeason = (Label)row.FindControl("lblSeason");
                txtSeason.Text = lblSeason.Text;
                btnsave.Text = "Update";
                btnsave.CommandName = "Update";
                btnsave.CommandArgument = lblSeasonId.Text;
            }
        }

        protected void gvSeasonSetup_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}