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
    public partial class StoreSetup : System.Web.UI.Page
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
            gvStoreSetup.DataSource = BL_Store.GetStoreDetails(1, 0, "", "");
            gvStoreSetup.DataBind();
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (txtStoreNo.Text == "")
            {
                _msgbox.ShowWarning("Store No is Mandatory");
            }
            if (txtStoreName.Text == "")
            {
                _msgbox.ShowWarning("Store Name is Mandatory");
            }
            if (btnsave.CommandName == "Update")
            {
                InsUpdDelStore('U', Convert.ToInt32((string)btnsave.CommandArgument));
                btnsave.Text = "Save";
                btnsave.CommandName = "Save";
            }
            else
            {
                InsUpdDelStore('I', 0);
                FillGridview();
                ClearAll();
            }
        }
        private void InsUpdDelStore(char Event, int id)
        {
            var msg = "";

            if (Event == 'I' || Event == 'U')
            {
                var objColor = new Store(id, int.Parse(txtStoreNo.Text), txtStoreName.Text);
                msg = BL_Store.InsUpdDelStore(Event, objColor, out id);

            }
            else
            {
                var objColor = new Store(id, 0, "");
                msg = BL_Store.InsUpdDelStore(Event, objColor, out id);
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
            txtStoreNo.Text = "";
            txtStoreName.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnsave.Text = "Save";
            btnsave.CommandName = "Save";
        }

        protected void gvStoreSetup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                InsUpdDelStore('D', Convert.ToInt32(e.CommandArgument));
                FillGridview();
            }

            else
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var row = gvStoreSetup.Rows[index];
                var lblStoreId = (Label)row.FindControl("lblStoreId");
                var lblStoreNo = (Label)row.FindControl("lblStoreNo");
                var lblStoreName = (Label)row.FindControl("lblStoreName");
                txtStoreNo.Text = lblStoreNo.Text;
                txtStoreName.Text = lblStoreName.Text;
                btnsave.Text = "Update";
                btnsave.CommandName = "Update";
                btnsave.CommandArgument = lblStoreId.Text;
            }
        }

        protected void gvStoreSetup_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}