using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Benetton.Classes;
using BusinessLogic;

namespace Benetton.Reports
{
    public partial class OrderedList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillddlSeason();
                FillddlBranch();
                ddlBranch.SelectedValue = BK_Session.GetSession().BranchId.ToString();
            }
        }
        private void FillddlSeason()
        {
            ddlSeason = BL_FillDropDown.FillDdlSeason(ddlSeason);
        }
        private void FillddlBranch()
        {
            ddlBranch = BL_FillDropDown.FillddlBranch(ddlBranch, 1, 0, "","");
        }
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string code="" ;
            const int eventFlag = 1;
            code = ddlSeason.SelectedValue;
            FillGridview(eventFlag,code);
        }
        private void FillGridview(int eventFlag,string code)
        {
            gvOrderedList.DataSource = BL_OrderedExcel.GetOrderedList(eventFlag, int.Parse(ddlBranch.SelectedValue), code, "");
            gvOrderedList.DataBind();
        }
    }
}