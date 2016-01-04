using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class MainMenu
    {
        private int _MainMenuID = 0; public int MainMenuID { get { return _MainMenuID; } set { _MainMenuID = value; } }
        private string _MenuName = string.Empty; public string MenuName { get { return _MenuName; } set { _MenuName = value; } }
        private Dictionary<int, ChildMenu> subMenus = new Dictionary<int, ChildMenu>();

        public Dictionary<int, ChildMenu> SubMenus
        {
            get { return subMenus; }
            // set { subMenus = value; }
        }

        public MainMenu(int code, string menuName)
        {
            this._MainMenuID = code;
            this._MenuName = menuName;
        }

        public void AddSubMenu(ChildMenu ChildMenu)
        {
            string breadCum = this._MenuName + " >> " + ChildMenu.MenuName;
            this.subMenus.Add(ChildMenu.ChildMenuID, ChildMenu);
        }
    }
}
