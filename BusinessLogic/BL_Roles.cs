using DataLogic;
using System.Data;

namespace BusinessLogic
{
    public class BL_Roles
    {
        private int _ROLE_ID = 0; public int ROLE_ID { get { return _ROLE_ID; } set { _ROLE_ID = value; } }
        private string _ROLE_NAME = string.Empty; public string ROLE_NAME { get { return _ROLE_NAME; } set { _ROLE_NAME = value; } }

        public char EVENT { get; set; }

        public string InsUpdDelRoles(out int Id)
        {
            Id = 0;
            return DlRoles.InsUpdDelRoles(EVENT, ROLE_ID, ROLE_NAME, out Id);
        }

        public static DataTable GetRoles(int EVENT, int ID, string CODE)
        {
            return DlRoles.GetRoles(EVENT, ID, CODE);
        }
    }
}
