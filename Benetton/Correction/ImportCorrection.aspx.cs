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

namespace Benetton.Correction
{
    public partial class ImportCorrection : System.Web.UI.Page
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
                FillddlSeason();
                FillddlBranch();
                ddlBranch.SelectedValue = BK_Session.GetSession().BranchId.ToString();
                txtDate.Text = ConvertNE.ConvertEToN(BK_Session.GetSession().OpDate);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            FillGridView();
        }
        public void FillGridView()
        {
            gvOrderList.DataSource = BllImportExcel.GetImportListByDate(3, int.Parse(ddlBranch.SelectedValue), ddlSeason.SelectedValue, "", DateTime.Parse(ConvertNE.ConvertNToE(DateStringToInt.StringToInt(txtDate.Text))));
            gvOrderList.DataBind();
        }

        protected void gvOrderList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View1")
            {
                ViewDetails(e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Delete1")
            {
                DeleteImportList(e.CommandArgument.ToString());
            }
        }

        private void FillddlSeason()
        {
            ddlSeason = BL_FillDropDown.FillDdlSeason(ddlSeason);
        }
        private void FillddlBranch()
        {
            ddlBranch = BL_FillDropDown.FillddlBranch(ddlBranch, 1, 0, "", "");
        }

        private void ViewDetails(string invoiceNo)
        {
            mpeDetails.Show();
            lblInvoiceNo.Text = invoiceNo;
            gvOrderedDetails.DataSource = BllImportExcel.GetImportListByDate(4, int.Parse(ddlBranch.SelectedValue), ddlSeason.SelectedValue,invoiceNo, DateTime.Parse(ConvertNE.ConvertNToE(DateStringToInt.StringToInt(txtDate.Text))));
            gvOrderedDetails.DataBind();
        }

        private void DeleteImportList(string invoiceNo)
        {
            var obj = new ImportExcel();
            obj.ExcelData = "";
            obj.CreatedBy = BK_Session.GetSession().UserId;
            obj.BranchId = BK_Session.GetSession().BranchId;
            obj.ImportedDate = BK_Session.GetSession().OpDate;
            obj.InvoiceNo = invoiceNo;
            int id = 0;
            var msg = BllImportExcel.InsUpdDelExcelImport('D', obj, out id);
            if (msg == "Record Deleted Successfully")
            {
                FillGridView();
                _msgbox.ShowSuccess(msg);
            }
            else
            {
                _msgbox.ShowWarning(msg);
            }
        }
    }
}