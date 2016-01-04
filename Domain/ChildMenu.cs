using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class ChildMenu
    {
        public int ChildMenuID { get; set; }
        public string MenuName { get; set; }
        public string NavigationUrl { get; set; }

        public string BreadCum { get; set; }

        public int MainMenuID { get; set; }

        public ChildMenu(int childCode, int mainMenu, string title, string navigationUrl)
        {
            BreadCum = string.Empty;
            this.ChildMenuID = childCode;
            this.MainMenuID = mainMenu;
            this.MenuName = title;
            this.NavigationUrl = navigationUrl;

        }
    }
}
