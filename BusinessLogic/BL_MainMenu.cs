using System.Data;
using DataLogic;
/// <summary>
/// Summary description for BL_MainMenu
/// </summary>
namespace BusinessLogic
{
    public class BL_MainMenu
    {
        public BL_MainMenu()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private int _MainMenuID = 0; public int MainMenuID { get { return _MainMenuID; } set { _MainMenuID = value; } }
        private string _MenuName = string.Empty; public string MenuName { get { return _MenuName; } set { _MenuName = value; } }
        private string _ImageURL = string.Empty; public string ImageURL { get { return _ImageURL; } set { _ImageURL = value; } }
        private int _Odr = 0; public int Odr { get { return _Odr; } set { _Odr = value; } }

        public char EVENT { get; set; }

        public string InsUpdDeleteMainMenu(out int Id)
        {
            Id = 0;
            return DlMainMenu.InsUpdDeleteMainMenu(EVENT, MainMenuID, MenuName, ImageURL, Odr, out Id);
        }

        public static DataTable GetMainMenu(int EVENT, int ID, string CODE)
        {
            return DlMainMenu.GetMainMenu(EVENT, ID, CODE);
        }
    }
}