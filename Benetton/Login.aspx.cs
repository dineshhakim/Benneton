using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;
using Benetton.Classes;
using BusinessLogic;
using Domain;

namespace Benetton
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUserName.Focus();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text != "" && txtPwd.Text != "")
            {
                var pwd = EncryptDecrypt.base64Encode(txtPwd.Text);
                var dt = new DataTable();
                dt = BL_Users.GetUsers(2, 0, txtUserName.Text);

                if (dt.Rows.Count > 0)
                {
                    var a = EncryptDecrypt.base64Decode(dt.Rows[0]["PWD"].ToString());
                    if (pwd == dt.Rows[0]["PWD"].ToString())
                    {
                        var userID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                        var roleId = Convert.ToInt32(dt.Rows[0]["ROLE_ID"].ToString());
                        var obj = new BK_Session(Convert.ToInt32(userID), roleId, this.PrepareMenu(roleId));
                        obj.UserName = dt.Rows[0]["USER_NAME"].ToString();
                        obj.RoleName = dt.Rows[0]["ROLE_NAME"].ToString();
                        obj.BranchId = Convert.ToInt32(dt.Rows[0]["BRANCH_ID"].ToString());
                        BK_Session.SetSession(obj);
                        var opdate = DateTime.Parse(GetOperationDate(BK_Session.GetSession().BranchId));
                        InsertDayOpen(BK_Session.GetSession().BranchId, opdate, BK_Session.GetSession().UserId);
                        obj.OpDate = opdate;
                        obj.Name = dt.Rows[0]["NAME"].ToString();
                        BK_Session.SetSession(obj);

                        Session["Username"] = dt.Rows[0]["USER_NAME"].ToString();
                        FormsAuthenticationTicket tkt;
                        string cookiestr;

                        tkt = new FormsAuthenticationTicket(1, txtUserName.Text, DateTime.Now, DateTime.Now.AddMinutes(30), false, "your custom data");
                        cookiestr = FormsAuthentication.Encrypt(tkt);

                        //   FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
                        string strRedirect;
                        strRedirect = Request["ReturnUrl"];
                        if (strRedirect == null)
                            strRedirect = "~/DashBoard.aspx";
                        Response.Redirect(strRedirect, true);
                    }
                    else
                    {
                        //lblError.Text = "Invalid Password For the Given User..!!";
                        txtPwd.Text = "";
                        txtPwd.Focus();
                    }
                }
                else
                {
                    //lblError.Text = "Invalid User Name..!!";
                    txtUserName.Text = "";
                    txtPwd.Text = "";
                    txtUserName.Focus();
                }
            }
        }

        private Dictionary<int, MainMenu> PrepareMenu(int roleId)
        {
            var dt = BL_MenuAssign.GetMenuAssign(3, Convert.ToInt32(roleId), 0, "");
            var mainMenus = new Dictionary<int, MainMenu>();
            var count = dt.Rows.Count;
            if (count > 0)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var m = new MainMenu(int.Parse(dt.Rows[i]["MainMenuID"].ToString()), dt.Rows[i]["MainMenuName"].ToString());
                    this.PrepareChildMenu(ref m, roleId);
                    mainMenus.Add(int.Parse(dt.Rows[i]["MainMenuID"].ToString()), m);

                }
            }
            return mainMenus;
        }
        private void PrepareChildMenu(ref MainMenu mainMenu, int roleId)
        {
            try
            {
                var dt = BL_MenuAssign.GetMenuAssign(2, Convert.ToInt32(roleId), Convert.ToInt32(mainMenu.MainMenuID), "");
                if (dt.Rows.Count > 0)
                {

                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        mainMenu.AddSubMenu(new ChildMenu(int.Parse(dt.Rows[i]["ChildMenuID"].ToString()), mainMenu.MainMenuID, dt.Rows[i]["ChildMenuName"].ToString(), dt.Rows[i]["NavigationURL"].ToString()));
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }
        public static void InsertDayOpen(int branchId, DateTime date, int createdBy)
        {
            BLDayclose.InsertDayOpen(branchId, date, createdBy);
        }
        public static string GetOperationDate(int branchId)
        {
            return BLDayclose.GetOperationDate(branchId);
        }
    }


}