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
    public partial class MissingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillddlBranch();
                FillddlSeason();
                ddlBranch.SelectedValue = BK_Session.GetSession().BranchId.ToString();
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
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            const int eventFlag = 5;
            FillGridview(eventFlag);
        }
        private void FillGridview(int eventFlag)
        {
            gvMissingList.DataSource = BllImportExcel.GetImportList(eventFlag, int.Parse(ddlBranch.SelectedValue), ddlSeason.SelectedValue, "");
            gvMissingList.DataBind();
        }
    }
}