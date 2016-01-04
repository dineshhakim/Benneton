using System.Data;
using DataLogic;
 

/// <summary>
/// Summary description for BL_ChildMenu
/// </summary>

namespace BusinessLogic
{
    public class BL_ChildMenu
    {
      

        private int _ChildMenuID = 0; public int ChildMenuID { get { return _ChildMenuID; } set { _ChildMenuID = value; } }
        private string _MenuName = string.Empty; public string MenuName { get { return _MenuName; } set { _MenuName = value; } }
        private string _NavigationURL = string.Empty; public string NavigationURL { get { return _NavigationURL; } set { _NavigationURL = value; } }
        private int _MainMenuID = 0; public int MainMenuID { get { return _MainMenuID; } set { _MainMenuID = value; } }
        private int _Odr = 0;
        public int Odr { get { return _Odr; } set { _Odr = value; } }

        public char EVENT { get; set; }
        public string InsUpdDeleteMainMenu(out int Id)
        {
            Id = 0;
            return DlChildMenu.InsUpdDeleteMainMenu(this.EVENT, this.ChildMenuID, this.MenuName, this.NavigationURL, this.MainMenuID,Odr, out Id);
        }

        public static DataTable GetChildMenu(int EVENT, int ID, string CODE)
        {
            return DlChildMenu.GetChildMenu(EVENT, ID, CODE);
        }
    }
}
