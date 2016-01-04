using DataLogic;
using System.Data;

namespace BusinessLogic
{
    public class BL_UserRoles
    {
        private int _ID = 0; public int ID { get { return _ID; } set { _ID = value; } }
        private int _ROLE_ID = 0; public int ROLE_ID { get { return _ROLE_ID; } set { _ROLE_ID = value; } }
        private int _USER_ID = 0; public int USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }

        public char EVENT { get; set; }

        public string InsUpdDelUserRoles(out int Id)
        {
            Id = 0;
            return DL_UserRoles.InsUpdDelUserRoles(EVENT, ID, ROLE_ID, USER_ID, out Id);
        }
        public static DataTable GetUserRoles(int EVENT, int ID, string CODE)
        {
            return DL_UserRoles.GetUserRoles(EVENT, ID, CODE);
        }
    }
}
