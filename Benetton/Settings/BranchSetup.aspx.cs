using System;
using System.Web.UI.WebControls;
using Benetton.Classes;
using BusinessLogic;
using Domain;
using ProudMonkey.Common.Controls;

namespace Benetton.Settings
{
    public partial class BranchSetup : System.Web.UI.Page
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
            gvBranchSetup.DataSource = BL_Branch.GetBranch(1, 0, "","");
            gvBranchSetup.DataBind();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

            if (txtbranchname.Text == "")
            {
                _msgbox.ShowWarning("Branch Name is Mandatory");
            }
            if (btnsave.CommandName == "Update")
            {
                InsUpdDelBranch('U', Convert.ToInt32((string) btnsave.CommandArgument));
                btnsave.Text = "Save";
                btnsave.CommandName = "Save";
            }
            else
            {
                InsUpdDelBranch('I', 0);
                FillGridview();
                ClearAll();
            }
        }


        private void InsUpdDelBranch(char Event, int id)
        {
            var msg = "";

            if (Event == 'I' || Event == 'U')
            {
                DateTime date = ConvertNE.convertNepaliToEnglish(txtoperationstartdate.Text);
                var objBranch = new Branch(id, txtbranchname.Text, txtbranchcode.Text, txtaddress.Text, txtemailid.Text,
                    txttelno.Text,  txtcontactpersonname.Text, date, chkismain.Checked);
                msg = BL_Branch.InsUpdDelBranch(Event, objBranch, out id);
               
            }
            else
            {
                var objBranch = new Branch(id, "", "", "", "", "", "", Convert.ToDateTime("01/01/1753"), true);
                msg = BL_Branch.InsUpdDelBranch(Event, objBranch, out id);
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
            txtbranchname.Text = "";
            txtbranchcode.Text = "";
            txtaddress.Text = "";
            txttelno.Text = "";
            txtemailid.Text = "";
            txtcontactpersonname.Text = "";
            txtoperationstartdate.Text = "";
            chkismain.Checked = Convert.ToBoolean("False");


        }

        protected void gvBranchSetup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete1")
            {
                InsUpdDelBranch('D', Convert.ToInt32(e.CommandArgument));
                FillGridview();
            }

            else
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var row = gvBranchSetup.Rows[index];
                var lblbranchid = (Label)row.FindControl("lblbranchid");
                var lblbranchname = (Label)row.FindControl("lblbranchname");
                var lblbranchcode = (Label)row.FindControl("lblbranchcode");
                var lbladdress = (Label)row.FindControl("lbladdress");
                var lblemailid = (Label)row.FindControl("lblemailid");
                var lbltelno = (Label)row.FindControl("lbltelno");
                var lblcontactpersonname = (Label)row.FindControl("lblcontactpersonname");
                var lblopertionstartdate = (Label)row.FindControl("lblopertionstartdate");
                var lblismain = (Label)row.FindControl("lblismain");
                txtbranchname.Text = lblbranchname.Text;
                txtbranchcode.Text = lblbranchcode.Text;
                txtaddress.Text = lbladdress.Text;
                txtemailid.Text = lblemailid.Text;
                txttelno.Text = lbltelno.Text;
                txtcontactpersonname.Text = lblcontactpersonname.Text;
                txtoperationstartdate.Text = lblopertionstartdate.Text;
                chkismain.Checked = Convert.ToBoolean(lblismain.Text);
                btnsave.Text = "Update";
                btnsave.CommandName = "Update";
                btnsave.CommandArgument = lblbranchid.Text;
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnsave.Text = "Save";
            btnsave.CommandName = "Save";
        }

        protected void gvBranchSetup_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var lblopertionstartdate = e.Row.FindControl("lblopertionstartdate") as Label;
                lblopertionstartdate.Text = ConvertNE.ConvertEToNWithSlash(DateTime.Parse(lblopertionstartdate.Text));
            }
        }
    }
}