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
    public partial class BankSetup : System.Web.UI.Page
    {
        ProudMonkey.Common.Controls.MessageBox msgbox;
        private int branchId;
        protected void Page_Init(object sender, EventArgs e)
        {
            msgbox = new MessageBox()
            {

            };
            this.pnlMsgBox.Controls.Clear();
            this.pnlMsgBox.Controls.Add(msgbox);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                branchId = BK_Session.GetSession().BranchId;
                txt_OpeningDate.Text = Convert.ToString(DateTime.Now.ToShortDateString());
                txtAmount.Text = "0";
                FillGrid();
                FillDdlBranch();
                BindIntCalMethod();
                BindAccumulationMethod();
                ddlBranch_SelectedIndexChanged(sender, e);
                //ddlaccounttype_SelectedIndexChanged(sender, e);
            }
        }
        public void FillDdlBranch()
        {
            BL_FillDropDown.FillddlBranch(ddlBranch, 1, 0, "", "");
            ddlBranch.Items.RemoveAt(0);
        }
        public void FillGrid()
        {
            try
            {
                var dt = BL_Bank_Desc.GetBankDetails(1, branchId, "");
                if (dt.Rows.Count > 0)
                {
                    gridview_mode.DataSource = dt;
                    gridview_mode.DataBind();
                }
                else
                {
                    gridview_mode.DataSource = null;
                    gridview_mode.DataBind();
                    gridview_mode.EmptyDataText = "<center>No Records Found.</center>";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {

            if (btn_submit.CommandName == "Update")
            {
                InsUpdDelBankDetail('U', Convert.ToInt32((string)btn_submit.CommandArgument));
                btn_submit.Text = "Save";
                btn_submit.CommandName = "Save";
            }
            else
            {

                InsUpdDelBankDetail('I', 0);
                //   FillGridview();

            }
            Clear();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            txtAmount.Text = "0";
            txtMaturityDate.Text = "";
            txtRate.Text = "0";
            txt_AccountNo.Text = "";
            txt_BankName.Text = "";
            txt_OpeningDate.Text = DateTime.Now.ToShortDateString();
            txtavailablebalance.Text = "0";
            txtinterestaccumulation.Text = "";
            ddlBranch.SelectedValue = Convert.ToString(BK_Session.GetSession().BranchId.ToString());
            ddl_acc.SelectedValue = "0";
            ddl_calMethod.SelectedValue = "0";
            ddl_class.SelectedValue = "0";
            ddlaccounttype.SelectedValue = "0";
            //    ddlmodeofpayment.SelectedValue = "1";

        }



        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            branchId = Convert.ToInt32((string)ddlBranch.SelectedValue);
            this.FillGrid();
            msgSuccess.Text = "";
            msgSuccess.Visible = false;
        }

        protected void ddlaccounttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlaccounttype.SelectedValue == "1")
            {
                pnlAccountType.Visible = false;
                pnlFD.Visible = false;
            }
            else if (ddlaccounttype.SelectedValue == "2")
            {
                pnlAccountType.Visible = true;
                pnlFD.Visible = false;
            }
            else
            {
                pnlAccountType.Visible = true;
                pnlFD.Visible = true;
            }
        }

        protected void ddlmodeofpayment_SelectedIndexchanged(object sender, EventArgs e)
        {

        }

        protected void ddlSelectBank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void InsUpdDelBankDetail(char Event, int id)
        {
            var msg = "";


            if (Event == 'I' || Event == 'U')
            {
                msgSuccess.Text = "";
                msgSuccess.Visible = false;
                int userid = Convert.ToInt16(BK_Session.GetSession().UserId.ToString());
                var accounttype = "";
                var cashbank = false;
                var bankid = 0;
                var maturitydate = new DateTime();
                if (ddlaccounttype.SelectedValue == "1")
                {
                    accounttype = "C";
                    txtRate.Text = "0";
                    txtAmount.Text = "0";
                    maturitydate = DateTime.Parse("01/01/1991");
                }
                else if (ddlaccounttype.SelectedValue == "2")
                {
                    accounttype = "S";
                    txtAmount.Text = "0";
                    maturitydate = DateTime.Parse("01/01/1991");
                }
                else
                {
                    txtAmount.Text = "0";
                    accounttype = "FD";
                    maturitydate =
                        DateTime.Parse(txtMaturityDate.Text);
                }


                if (ddlmodeofpayment.SelectedItem.Text == "Bank")
                {
                    cashbank = true;
                    bankid = int.Parse(ddlSelectBank.SelectedValue);
                }




                var objBank = new Bank(id, txt_BankName.Text + "-" + txt_AccountNo.Text, txt_AccountNo.Text,
                        float.Parse(txtAmount.Text), 0, Convert.ToDateTime(txt_OpeningDate.Text), BK_Session.GetSession().UserId,
                      Convert.ToDateTime(txt_OpeningDate.Text), 0, Convert.ToDateTime(txt_OpeningDate.Text), accounttype,
                       ddl_class.SelectedValue, int.Parse(ddlBranch.SelectedValue), decimal.Parse(txtRate.Text), int.Parse(ddl_calMethod.SelectedValue), int.Parse(ddl_acc.SelectedValue), maturitydate,
                       cashbank, bankid, txtinterestaccumulation.Text);
                msg = BL_Bank_Desc.InsUpdDelBankDetail(Event, objBank, out id);
                branchId = BK_Session.GetSession().BranchId;
                FillGrid();
            }
            else
            {

            }
            if (DatabaseMessage.ContainMessage(msg))
            {
                msgbox.ShowSuccess(msg);

            }
            else
            {
                msgbox.ShowWarning(msg);
            }
        }
        public void BindAccumulationMethod()
        {
            msgSuccess.Text = "";
            msgSuccess.Visible = false;
            ddl_acc = BL_FillDropDown.FillddlIntAccumulate(ddl_acc, 1, 0, "");
        }
        public void BindIntCalMethod()
        {
            msgSuccess.Text = "";
            msgSuccess.Visible = false;
            ddl_calMethod = BL_FillDropDown.FillddlIntCalMethod(ddl_calMethod, 1, 0, "");
        }

        protected void gridview_mode_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit1")
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var row = gridview_mode.Rows[index];
                var lblid = (Label)row.FindControl("lblid");
                var id = int.Parse(lblid.Text);
                var lblBankName = (Label)row.FindControl("lblBankName");
                var lblAccountNo = (Label)row.FindControl("lblAccountNo");
                var lblAccounttype = (Label)row.FindControl("lblAccounttype");
                var lblRate = (Label)row.FindControl("lblRate");
                var lblcalmethod = (Label)row.FindControl("lblcalmethod");
                var lblaccumulationmethod = (Label)row.FindControl("lblaccumulationmethod");
                var lblMaturityDate = (Label)row.FindControl("lblMaturityDate");
                var lblOpeningDate = (Label)row.FindControl("lblOpeningDate");
                var lblBankClass = (Label)row.FindControl("lblBankClass");
                var lblNomineeAc = (Label) row.FindControl("lblNomineeAc");
                //  ddlBranch.SelectedIndex=ddlBranch.Items.IndexOf(ddlBranch.Items.FindByText(lblBra))
                ddl_calMethod.SelectedIndex = ddl_calMethod.Items.IndexOf(ddl_calMethod.Items.FindByText(lblcalmethod.Text));
                ddl_acc.SelectedIndex = ddl_acc.Items.IndexOf(ddl_acc.Items.FindByText(lblaccumulationmethod.Text));
                txt_BankName.Text = lblBankName.Text;
                txt_AccountNo.Text = lblAccountNo.Text;
                txt_OpeningDate.Text = lblOpeningDate.Text;
                txtMaturityDate.Text = lblMaturityDate.Text;
                txtinterestaccumulation.Text = lblNomineeAc.Text;
                txtAmount.Text = BL_Bank_Desc.GetBankBal(int.Parse(lblid.Text)).ToString();
                //   txtinterestaccumulation.Text = DL_Bank.Nomineeacno(int.Parse(lblid.Text));
                txtAmount.Enabled = false;
                txtRate.Text = lblRate.Text;
                ddl_class.SelectedValue = lblBankClass.Text;
                if (lblAccounttype.Text == "S")
                {
                    ddlaccounttype.SelectedValue = "2";
                }
                else if (lblAccounttype.Text == "C")
                {
                    ddlaccounttype.SelectedValue = "1";
                }
                else
                {
                    ddlaccounttype.SelectedValue = "3";
                }
                if (ddlaccounttype.SelectedValue == "1")
                {
                    pnlAccountType.Visible = false;
                    pnlFD.Visible = false;
                }
                else if (ddlaccounttype.SelectedValue == "2")
                {
                    pnlAccountType.Visible = true;
                    pnlFD.Visible = false;
                }
                else
                {
                    pnlAccountType.Visible = true;
                    pnlFD.Visible = true;
                }
                btn_submit.Text = "Update";
                btn_submit.CommandName = "Update";
                btn_submit.CommandArgument = id.ToString();
                btnCancel.Visible = true;
                ddlaccounttype_SelectedIndexChanged(sender, e);
            }
        }

        protected void gridview_mode_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}