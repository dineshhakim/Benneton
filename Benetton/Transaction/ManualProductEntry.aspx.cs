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

namespace Benetton.Product
{
    public partial class ManualProductEntry : System.Web.UI.Page
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
                //FillGridview();
                FillDdlBranch();
                FillDdlGender();
                FillDdlCategory();
                FillDdlStyle();
                FillDdlSize();
                FillddlSeason();
            }
        }

  

        #region FILL DROPDOWNLIST
        private void FillddlSeason()
        {
            BL_FillDropDown.FillddlSeason(ddlSeason, 1, 0, "");
        }
        private void FillDdlSize()
        {
            BL_FillDropDown.FillddlSize(ddlSize, 1, 0, "");
        }

        private void FillDdlColor()
        {
            BL_FillDropDown.FillddlColor(ddlColor, 2, Convert.ToInt32((string)ddlCategory.SelectedValue), Convert.ToInt32((string)ddlStyle.SelectedValue));
        }

        private void FillDdlStyle()
        {
            BL_FillDropDown.FillddlStyle(ddlStyle, 1, 0, "");
        }

        private void FillDdlCategory()
        {
            BL_FillDropDown.FillddlKnittingCategory(ddlCategory, 1, 0, "");
        }

        private void FillDdlGender()
        {
            BL_FillDropDown.FillddlGenderType(ddlGender, 1, 0, "");
        }
        public void FillDdlBranch()
        {
            BL_FillDropDown.FillddlBranch(ddl_branch, 1, 0, "", "");
        }

        #endregion
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (btn_Save.CommandName == "Update")
            {
                InsUpdDelStockIn('U', Convert.ToInt32((string)btn_Save.CommandArgument));
                btn_Save.Text = "Save";
                btn_Save.CommandName = "Save";
            }
            else
            {
                InsUpdDelStockIn('I', 0);
               //FillGridview();
               ClearAll();
            }
        }

        private void ClearAll()
        {
            txtDate.Text = "";
            txtDocumentNo.Text = "";
            txtInvoiceNo.Text = "";
            txtMrp.Text = "";
            txtQty.Text = "";
            txtRate.Text = "";
            txtStockNo.Text = "";
            ddlCategory.SelectedValue = "0";
            ddlSeason.SelectedValue = "0";
         //   ddlColor.SelectedValue = "-1";
            ddlGender.SelectedValue = "-1";
            ddlSize.SelectedValue = "-1";
            ddlStyle.SelectedValue = "0";
            ddl_branch.SelectedValue = "";

        }

        private void InsUpdDelStockIn(char Event, int id)
        {
            var msg = "";

            if (Event == 'I' || Event == 'U')
            {

                // var session=new BK_Session(int userId,)
                var objOrder = new OrderedItemClass(id,  Convert.ToDateTime(txtDate.Text),  txtDocumentNo.Text,  " ",  txtStockNo.Text,  Convert.ToInt32((string)ddlGender.SelectedValue),
                 Convert.ToInt32((string)ddlCategory.SelectedValue),  " ",  Convert.ToInt32((string)ddlStyle.SelectedValue),  Convert.ToInt32((string)ddlColor.SelectedValue),  Convert.ToInt32((string)ddlSize.SelectedValue),  Convert.ToInt32(txtQty.Text),  float.Parse(txtRate.Text),
                 0,  float.Parse(txtMrp.Text));
                var objImport = new ProductStockIn(BK_Session.GetSession().BranchId, BK_Session.GetSession().UserId, Convert.ToDateTime("1/1/1900"), " ", txtInvoiceNo.Text,
             txtAirwayBillNo.Text, Convert.ToInt32((string)ddlSeason.SelectedValue), Convert.ToDateTime("1/1/1900"), 0);
                msg = BL_Stock_In.InsUpdDelStockIn(Event, objOrder,objImport, out id);

            }
            else
            {
                var objOrder = new OrderedItemClass(id, Convert.ToDateTime("1/1/1900")," ", " ", " ", 0,
                     0, " ",0,0, 0,0,0,
                     0, 0);
                var objImport = new ProductStockIn(0, 0, Convert.ToDateTime("1/1/1900"), " ", " ",
             " ", 0, Convert.ToDateTime("1/1/1900"), 0);
                msg = BL_Stock_In.InsUpdDelStockIn(Event, objOrder, objImport, out id);
            }
            if (msg=="Data Imported Successfully")
            {
                _msgbox.ShowSuccess(msg);

            }
            else
            {
                _msgbox.ShowWarning(msg);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
           
        }

        protected void ddlStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlColor();
        }

        //protected void gvProductEntry_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //if (e.CommandName == "delete1")
        //    //{
        //    //    InsUpdDelStockIn('D', Convert.ToInt32(e.CommandArgument));
        //    //    FillGridview();
        //    //}

        //    //else
        //    //{
        //    //    var index = Convert.ToInt32(e.CommandArgument);
        //    //    var row = gvProductEntry.Rows[index];
        //    //    var lblProductId = (Label)row.FindControl("lblProductId");
        //    //    var lblStockNo = (Label)row.FindControl("lblStockNo");
        //    //    var lblDocNo = (Label)row.FindControl("lblDocNo");
        //    //    var lblSeason = (Label)row.FindControl("lblSeason");
        //    //    var lblBranch = (Label)row.FindControl("lblBranch");
        //    //    var lblDate = (Label)row.FindControl("lblDate");
        //    //    var lblGender = (Label)row.FindControl("lblGender");
        //    //    var lblStyle = (Label)row.FindControl("lblStyle");
        //    //    var lblColor = (Label)row.FindControl("lblColor");
        //    //    var lblCategory = (Label)row.FindControl("lblCategory");
        //    //    var lblMrp = (Label)row.FindControl("lblMrp");
        //    //    var lblRate = (Label)row.FindControl("lblRate");
        //    //    var lblInvoiceNo = (Label)row.FindControl("lblInvoiceNo");
        //    //    var lblSize = (Label)row.FindControl("lblSize");
        //    //    var lblQty = (Label)row.FindControl("lblQty");



        //    //    ddl_branch.SelectedIndex = ddl_branch.Items.IndexOf(ddl_branch.Items.FindByText(lblBranch.Text));
        //    //    ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByText(lblCategory.Text));
        //    //    txtStockNo.Text = lblStockNo.Text;
        //    //    ddlGender.SelectedIndex = ddlGender.Items.IndexOf(ddlGender.Items.FindByText(lblGender.Text));
        //    //    ddlStyle.SelectedIndex = ddlStyle.Items.IndexOf(ddlStyle.Items.FindByText(lblStyle.Text));
        //    //    ddlColor.SelectedIndex = ddlColor.Items.IndexOf(ddlColor.Items.FindByText(lblColor.Text));
        //    //    ddlSeason.SelectedIndex = ddlSeason.Items.IndexOf(ddlSeason.Items.FindByText(lblSeason.Text));
        //    //    txtDocumentNo.Text = lblDocNo.Text;
        //    //    txtDate.Text = lblDate.Text;
        //    //    txtInvoiceNo.Text = lblInvoiceNo.Text;
        //    //    txtMrp.Text = lblMrp.Text;
        //    //    txtQty.Text = lblQty.Text;
        //    //    txtRate.Text = lblRate.Text;
        //    //    ddlSize.SelectedIndex = ddlSize.Items.IndexOf(ddlSize.Items.FindByText(lblSize.Text));
        //    //    btn_Save.Text = "Update";
        //    //    btn_Save.CommandName = "Update";
        //    //    btn_Save.CommandArgument = lblProductId.Text;
        //    //    btnCancel.Visible = true;
              
        //    //}
        //}

        //protected void gvProductEntry_RowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //}
        //private void FillGridview()
        //{
        //    gvProductEntry.DataSource = BL_Stock_In.GetStockInDetail(1,1, "", "");
        //    gvProductEntry.DataBind();
        //}
       
    }
}