using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using Benetton.Classes;
using BusinessLogic;
using Domain;

namespace Benetton
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            if (BK_Session.GetSession() == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var nepdate = (ConvertNE.ConvertEToNWithSlash(DateTime.Today));
                    //lblnepdate.InnerText = nepdate;
                    //lblopdateeng.InnerText = DateTime.Today.Date.ToString("yyyy /MM/ dd") + "      ||";
                    flyout_menu1.InnerHtml = FillMenu();
                    //lblWelcome.Text = BK_Session.GetSession().UserName.ToString();
                    Page.Header.DataBind();
                    CheckMenuRights();
                }
            }
            catch
            {
                Response.Redirect("~/Login.aspx");
            }
            
        }


        private string FillMenu()
        {
            var menu = BK_Session.GetSession().MenuList;
            if (menu != null)
                return menu;

            var dt = BL_MenuAssign.GetMenuAssign(3, Convert.ToInt32(BK_Session.GetSession().RoleId), 0, "");
            var mainMenus = BK_Session.GetSession().Menus;
            var count = mainMenus.Count;
            var strMenu = new StringBuilder();
            if (count > 0)
            {
                strMenu.Append("<ul class=\"nav nav-pills nav-stacked\">");
                foreach (var item in mainMenus.Keys)
                {
                    var mm = mainMenus[item];
                    strMenu.Append("<li class=\"parent\">");
                    switch (mm.MenuName)
                    {
                        case "Import From Excel":
                            strMenu.Append("<a href=" + "#" + "><i class=\"fa fa-home\" ></i><span>" + mm.MenuName + "</span></a>");
                            break;
                        case "Reports":
                            strMenu.Append("<a href=" + "#" + "><i class=\"fa fa-file-text\" ></i><span>" + mm.MenuName + "</span></a>");
                            break;
                        case "Settings":
                            strMenu.Append("<a href=" + "#" + "><i class=\"fa fa-gears\" ></i><span>" + mm.MenuName + "</span></a>");
                            break;
                        case "correction":
                            strMenu.Append("<a href=" + "#" + "><i class=\"fa fa-suitcase\" ></i><span>" + mm.MenuName + "</span></a>");
                            break;
                        default:
                            strMenu.Append("<a href=" + "#" + "><i class=\"fa fa-suitcase\" ></i><span>" + mm.MenuName + "</span></a>");
                            break;
                    }
                    
                    strMenu.Append(GetChildMenu(mm));
                    strMenu.Append("</li>");
                }
                strMenu.Append("</ul>");
            }
            BK_Session.GetSession().MenuList = strMenu.ToString();
            return strMenu.ToString();
        }


        private string GetChildMenu(MainMenu mainMenu)
        {
            var strMenu = new StringBuilder();
            if (mainMenu.SubMenus.Count > 0)
            {

                //}
                strMenu.Append("<ul class=\"children\" > ");
                foreach (var item in mainMenu.SubMenus.Keys)
                {
                    var subMain = mainMenu.SubMenus[item];
                    strMenu.Append("<li class=\"\">");
                    strMenu.Append("<a href=" + ResolveUrl(subMain.NavigationUrl) + "><span>" + subMain.MenuName + "</span></a>");
                    strMenu.Append("</li>");
                }
                strMenu.Append("</ul>");
            }
            return strMenu.ToString();
        }
        private void CheckMenuRights()
        {
            var sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            var oInfo = new System.IO.FileInfo(sPath);
            if (oInfo.Directory != null)
            {
                var sRet = @"/" + oInfo.Directory.Name + @"/" + oInfo.Name;
                //if (sRet.Contains("/script.aspx") || sRet.Contains("/Branch.aspx"))
                //{
                //    if (BK_Session.GetSession().RoleId == 1)
                //    {
                //        lititle.Text = "Microfinance";
                //    }
                //    else
                //    {
                //        Response.Redirect("~/MiddleaPart.aspx");
                //    }
                //}
                if (sRet.Contains("/DashBoard.aspx")
                    )
                {
                    lblPageName.Text = "Dashboard";
                    //lblMainMenuName.Text = "Menu Setting";
                    lblChildMenuName.Text = "Dashboard";
                }
                else if (sRet.Contains("/Menu/ChildMenuSetup.aspx"))
                {
                    lblPageName.Text = "Child Menu Setup";
                    lblMainMenuName.Text = "Menu Setting";
                    lblChildMenuName.Text = "Child Menu Setup";
                }
                else if (sRet.Contains("/Menu/MainMenuSetup.aspx"))
                {
                    lblPageName.Text = "Main Menu Setup";
                    lblMainMenuName.Text = "Menu Setting";
                    lblChildMenuName.Text = "Main Menu Setup";
                }
                else if (sRet.Contains("/Menu/MenuAssign.aspx"))
                {
                    lblPageName.Text = "Menu Assign";
                    lblMainMenuName.Text = "Menu Setting";
                    lblChildMenuName.Text = "Menu Assign";
                }
                else if (sRet.Contains("/Menu/AddNewUser.aspx"))
                {
                    lblPageName.Text = "Add New User";
                    lblMainMenuName.Text = "User Settings";
                    lblChildMenuName.Text = "Add New User";
                }
                else
                {
                    string bredcum = BK_Session.GetSession().GetBredCum("~" + sRet);
                    string[] pageArray = bredcum.Split('/');
                    Array.Reverse(pageArray);
                    lblPageName.Text = pageArray[0].ToString();
                    lblMainMenuName.Text = pageArray[1].ToString();
                    lblChildMenuName.Text = pageArray[0].ToString();
                }
            }
            //    //lititle.Text = lblPageName.Text.Replace("<i>", "").Replace("</i>", "");
            //    //if (lblPageName.Text == "")
            //    //{
            //    //    // Response.Redirect("~/MiddleaPart.aspx");
            //    //}
            //}
        }


        protected void btnSearch_OnClick(object sender, ImageClickEventArgs e)
        {
            //if (txtCode.Text != "")
            //{
            //    Response.Redirect(string.Format("~/Student/PharmacistDetail.aspx?registrationno={0}", txtCode.Text), false);
            //}
            //else if (txtname.Text != "")
            //{
            //    Response.Redirect(string.Format("~/Student/PharmacistDetail.aspx?pharmacistname={0}", txtname.Text), false);
            //}
        }
        protected void lnkSignOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx", false);
        }
    }

}
