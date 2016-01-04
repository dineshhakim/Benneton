using System;
using System.Collections.Generic;
using System.Web;
using Domain;

namespace Benetton.Classes
{
    public class BK_Session
    {
        public static string SessionName = "RNDC.session";

        public int UserId { get; set; }

        private int _roleId;

        public int RoleId
        {
            get { return _roleId; }
            set { RoleId = value; }
        }

        public string RoleName { get; set; }

        public string UserName { get; set; }
        public int BranchId
        { get; set; }

        public string BranchName { get; set; }

        public int GroupId { get; set; }

        public int TellerId { get; set; }

        public string GroupName { get; set; }

        private DateTime _opDate = System.DateTime.Now;
        public DateTime OpDate
        {
            get { return _opDate; }
            set { _opDate = value; }
        }

        public bool IsMainBranch { get; set; }

        public string PhoneNo { get; set; }

        public string Name
        {
            get;
            set;
        }
        public static void SetSession(BK_Session session)
        {
            HttpContext.Current.Session[SessionName] = session;
        }

        public static BK_Session GetSession()
        {
            if (HttpContext.Current.Session[SessionName] != null)
                return (BK_Session)HttpContext.Current.Session[SessionName];
            return null;

        }

        private readonly Dictionary<int, MainMenu> _menus;

        public Dictionary<int, MainMenu> Menus
        {
            get { return _menus; }

        }

        public string MenuList { get; set; }

        public string GetBredCum(string childUrl)
        {
            const string bredcum = "";
            //Menus.Keys.Any(key => key. Contains(childUrl));
            foreach (var item in Menus.Keys)
            {
                MainMenu mm = Menus[item];
                foreach (var subKey in mm.SubMenus.Keys)
                {

                    ChildMenu sm = mm.SubMenus[subKey];
                    //if (sm.NavigationURL.ToLower() == childUrl.ToLower())
                    if (sm.NavigationUrl.ToLower().Contains(childUrl.ToLower()))
                        return mm.MenuName + " / " + sm.MenuName;
                }

            }
            return bredcum;
        }

        public BK_Session(int userId, int roleID, Dictionary<int, MainMenu> menus)
        {
            this.UserId = userId;
            this._roleId = roleID;
            this._menus = menus;
        }

        public object Id { get; set; }
    }
}