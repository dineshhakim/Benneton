using System.Data;
using DataLogic;
/// <summary>
/// Summary description for BL_MenuAssign
/// </summary>
namespace BusinessLogic
{
    public class BL_MenuAssign
    {
        public BL_MenuAssign()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private int _ID = 0; public int ID { get { return _ID; } set { _ID = value; } }
        private int _MainMenuID = 0; public int MainMenuID { get { return _MainMenuID; } set { _MainMenuID = value; } }
        private int _ChildMenuID = 0; public int ChildMenuID { get { return _ChildMenuID; } set { _ChildMenuID = value; } }
        private int _RoleID = 0; public int RoleID { get { return _RoleID; } set { _RoleID = value; } }

        public char EVENT { get; set; }
        public string InsUpdDelMenuAssign(out int Id)
        {
            Id = 0;
            return DlMenuAssign.InsUpdDelMenuAssign(EVENT, ID, MainMenuID, ChildMenuID, RoleID, out Id);
        }

        public static DataTable GetMenuAssign(int EVENT, int ID, int ID1, string CODE)
        {
            return DlMenuAssign.GetMenuAssign(EVENT, ID, ID1, CODE);
        }
    }
}