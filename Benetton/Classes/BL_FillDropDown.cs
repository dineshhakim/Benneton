using System.Web.UI.WebControls;
using BusinessLogic;

namespace Benetton.Classes
{
    public class BL_FillDropDown
    {
        public static DropDownList FillddlMainMenu(DropDownList ddl, int EVENT, int ID, string CODE)
        {
            ddl.Items.Clear();
            var dt = BL_MainMenu.GetMainMenu(EVENT, ID, CODE);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "MainMenuID";
                ddl.DataTextField = "MenuName";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddl;
        }

        public static DropDownList FillddlRoles(DropDownList ddl, int EVENT, int ID, string CODE)
        {
            ddl.Items.Clear();
            var dt = BL_Roles.GetRoles(EVENT, ID, CODE);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "ROLE_ID";
                ddl.DataTextField = "ROLE_NAME";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddl;
        }
        public static DropDownList FillddlGender(DropDownList ddl, int EVENT,int ID,string CODE)
        {
            ddl.Items.Clear();
            var dt = BL_Staff.GetGender(EVENT, ID, CODE);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "GenderId";
                ddl.DataTextField = "GenderType";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddl;
        }
        public static DropDownList FillddlTitle(DropDownList ddl, int EVENT,int ID,string CODE)
        {
            ddl.Items.Clear();
            var dt = BL_Staff.GetTitle(EVENT, ID, CODE);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "Title_Id";
                ddl.DataTextField = "TitleName";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddl;
        }
        public static DropDownList FillddlEthnicGroup(DropDownList ddl, int EVENT, int ID, string CODE)
        {
            ddl.Items.Clear();
            var dt = BL_Staff.GetEthnicGroup(EVENT, ID, CODE);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "Cat_Id";
                ddl.DataTextField = "CategoryName";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddl;
        }
        internal static DropDownList Fillddlbranch(DropDownList ddl)
        {
            var objList = BL_Branch.GetBranch(1, 0, "","");
            if (objList.Count <= 0) return ddl;
            ddl.DataSource = objList;
            ddl.DataValueField = "BranchId";
            ddl.DataTextField = "BranchName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "", true));
            
            return ddl;
        }
        public static DropDownList FillDdlSeason(DropDownList ddl)
        {
            var objList = BL_Season.GetSeason(1, 0, "", "");
            if (objList.Count <= 0) return ddl;
            ddl.DataSource = objList;
            ddl.DataValueField = "Id";
            ddl.DataTextField = "Season";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "", true));

            return ddl;
        }
        public static DropDownList fill_user_by_branch(DropDownList ddl, int Event, int branchId, string branchName)
        {
            ddl.Items.Clear();
            var dt = BL_Branch.GetUsersByBranch(Event, branchId, branchName, "");
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "ID";
                ddl.DataTextField = "Name";
                ddl.DataBind();

            }

            return ddl;
        }
        public static DropDownList FillddlBranch(DropDownList ddl, int Event, int ID, string Code, string Code1)
        {
            var objList = BL_Branch.GetBranch(Event, ID, Code, Code1);
            if (objList.Count <= 0) return ddl;
            ddl.DataSource = objList;
            ddl.DataValueField = "BranchId";
            ddl.DataTextField = "BranchName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "", true));
            return ddl;
        }
        public static DropDownList FillddlThemeCategory(DropDownList ddl, int EVENT, int ID, string CODE)
        {
            ddl.Items.Clear();
            var dt = BL_Theme.GetUsersByTheme(EVENT, ID, CODE,"");
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "Id";
                ddl.DataTextField = "Category";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddl;
        }
        public static DropDownList FillddlKnittingCategory(DropDownList ddl, int EVENT, int ID, string CODE)
        {
            ddl.Items.Clear();
            var dt = BL_Knitting_Category.GetAllKnittingCategory(EVENT, ID, CODE, "");
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "Id";
                ddl.DataTextField = "Category";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddl;
        }
        public static DropDownList FillddlSeason(DropDownList ddl, int EVENT, int ID, string CODE)
        {
            ddl.Items.Clear();
            var dt = BL_Season.GetAllSeason(EVENT, ID, CODE, "");
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "Id";
                ddl.DataTextField = "Season";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddl;
        }
        internal static DropDownList FillddlMaritalStatus(DropDownList ddl, int Event, int ID, string CODE)
        {
            ddl.Items.Clear();
            var dt = BL_Staff.GetMaritalStatus(Event, ID, CODE);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "Marital_Id";
                ddl.DataTextField = "Name";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddl;
        }
        internal static DropDownList FillddlServiceType(DropDownList ddl, int Event, int ID, string CODE)
        {
            ddl.Items.Clear();
            var dt = BL_Staff.GetService(Event, ID, CODE);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "Id";
                ddl.DataTextField = "ServiceName";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddl;
        }
        internal static DropDownList FillddlDesignation(DropDownList ddlDesignation, int Event, int ID, string CODE)
        {
            //ddlDesignation.Items.Clear();
            var dt = BL_Staff.GetDesignation(Event, ID, CODE);
            if (dt.Rows.Count > 0)
            {
                ddlDesignation.DataSource = dt;
                ddlDesignation.DataValueField = "DId";
                ddlDesignation.DataTextField = "DesignationName";
                ddlDesignation.DataBind();
                //ddlDesignation.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddlDesignation;
        }
        internal static DropDownList FillddlDepartment(DropDownList ddlDepartment, int Event, int ID, string CODE)
        {
            ddlDepartment.Items.Clear();
            var dt = BL_Staff.GetDepartment(Event, ID, CODE);
            if (dt.Rows.Count > 0)
            {
                ddlDepartment.DataSource = dt;
                ddlDepartment.DataValueField = "DeptId";
                ddlDepartment.DataTextField = "DeptName";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddlDepartment;
        }
        internal static DropDownList FillDdlAcedamicQualification(DropDownList ddlQualification, int Event, int ID, string CODE)
        {
            ddlQualification.Items.Clear();
            var dt = BL_Staff.GetAcedamicQualification(Event, ID, CODE);
            if (dt.Rows.Count > 0)
            {
                ddlQualification.DataSource = dt;
                ddlQualification.DataValueField = "Id";
                ddlQualification.DataTextField = "Qualification";
                ddlQualification.DataBind();
                ddlQualification.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddlQualification;
        }
        internal static DropDownList FillddlStyle(DropDownList ddlStyle, int EVENT, int ID, string CODE)
        {
            ddlStyle.Items.Clear();
            var dt = BL_Style.GetStyleDetails(EVENT, ID, CODE, "");
            if (dt.Rows.Count > 0)
            {
                ddlStyle.DataSource = dt;
                ddlStyle.DataValueField = "Id";
                ddlStyle.DataTextField = "Style";
                ddlStyle.DataBind();
                ddlStyle.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddlStyle;
        }
        internal static DropDownList FillddlStaffName(DropDownList ddlStaffName, int EVENT, int ID, string CODE)
        {
            ddlStaffName.Items.Clear();
            var dt = BL_Staff.GetStaffDetail(EVENT, ID, CODE, "");
            if (dt.Rows.Count > 0)
            {
                ddlStaffName.DataSource = dt;
                ddlStaffName.DataValueField = "staffId";
                ddlStaffName.DataTextField = "Name";
                ddlStaffName.DataBind();
                ddlStaffName.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddlStaffName;
        }
        internal static DropDownList FillddlSize(DropDownList ddlSize, int EVENT, int ID, string CODE)
        {
            var dt = BL_Size.GetUsersBySize(EVENT, ID, CODE, "");
            if (dt.Rows.Count > 0)
            {
                ddlSize.DataSource = dt;
                ddlSize.DataValueField = "Id";
                ddlSize.DataTextField = "Size";
                ddlSize.DataBind();
              
            }
            return ddlSize;
        }
        internal static DropDownList FillddlColor(DropDownList ddlColor, int EVENT, int ID, int ID1)
        {
            var dt = BL_Color.GetColorDetails(EVENT, ID, ID1, "");
            if (dt.Rows.Count > 0)
            {
                ddlColor.DataSource = dt;
                ddlColor.DataValueField = "Id";
                ddlColor.DataTextField = "Color_Code";
                ddlColor.DataBind();

            }
            return ddlColor;
        }
        internal static DropDownList FillddlGenderType(DropDownList ddlGender, int EVENT, int ID, string CODE)
        {
            var dt = BL_Gender.GetAllGender(EVENT, ID, CODE, "");
            if (dt.Rows.Count > 0)
            {
                ddlGender.DataSource = dt;
                ddlGender.DataValueField = "Id";
                ddlGender.DataTextField = "Gender";
                ddlGender.DataBind();

            }
            return ddlGender;
        }
        internal static DropDownList FillddlIntCalMethod(DropDownList ddl, int Event, int Id, string Code)//event 1 for ddl fill
        {
            ddl.Items.Clear();
            var dt = BL_Bank_Desc.GetIntCalMethod(Event, Id, Code);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "IntCalMethod_ID";
                ddl.DataTextField = "IntCalMethod_Desc";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddl;

        }
        internal static DropDownList FillddlIntAccumulate(DropDownList ddl, int Event, int Id, string Code)//event 1 for ddl fill
        {
            ddl.Items.Clear();
            var dt = BL_Bank_Desc.GetIntAccumulate(Event, Id, Code);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataValueField = "IntAcc_ID";
                ddl.DataTextField = "IntAcc_Desc";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0", true));
            }
            return ddl;

        }
    }
}