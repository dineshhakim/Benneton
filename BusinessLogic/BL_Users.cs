using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using DataLogic;
using Domain;

namespace BusinessLogic
{
    public class BL_Users
    {
        private int _ID = 0; public int ID { get { return _ID; } set { _ID = value; } }
       // private string _NAME = string.Empty; public string NAME { get { return _NAME; } set { _NAME = value; } }
        private int _STAFF_ID = 0; public int STAFF_ID { get { return _STAFF_ID; } set { _STAFF_ID = value; } }
        private string _EMAIL_ID = string.Empty; public string EMAIL_ID { get { return _EMAIL_ID; } set { _EMAIL_ID = value; } }
        private string _ADDRESS = string.Empty; public string ADDRESS { get { return _ADDRESS; } set { _ADDRESS = value; } }
        private string _CONTACT_NO = string.Empty; public string CONTACT_NO { get { return _CONTACT_NO; } set { _CONTACT_NO = value; } }
        private string _USER_NAME = string.Empty; public string USER_NAME { get { return _USER_NAME; } set { _USER_NAME = value; } }
        private string _PWD = string.Empty; public string PWD { get { return _PWD; } set { _PWD = value; } }
        private int _BranchId = 0;public int BranchId{get { return _BranchId; }set { _BranchId = value; }}
        private int _REGISTERED_BY = 0; public int REGISTERED_BY { get { return _REGISTERED_BY; } set { _REGISTERED_BY = value; } }
        private DateTime? _REGISTERED_DATE = Convert.ToDateTime("01/01/1753"); public DateTime? REGISTERED_DATE { get { return _REGISTERED_DATE; } set { _REGISTERED_DATE = value; } }



        private bool _USER_STATUS = false; public bool USER_STATUS { get { return _USER_STATUS; } set { _USER_STATUS = value; } }

        private int _ROLE_ID = 0;

        public int ROLE_ID
        {
            get { return _ROLE_ID; }
            set { _ROLE_ID = value; }
        }
        public char EVENT { get; set; }

        public string InsUpdDeleteUsers(out int Id)
        {
            Id = 0;
            return DL_Users.InsUpdDeleteUsers(EVENT, ID, STAFF_ID, EMAIL_ID, ADDRESS, CONTACT_NO, USER_NAME, PWD, BranchId, REGISTERED_BY, REGISTERED_DATE, ROLE_ID, USER_STATUS, out Id);
        }

        public static DataTable GetUsers(int EVENT, int ID, string CODE)
        {
            return DL_Users.GetUsers(EVENT, ID, CODE);
        }

        public static DataTable GetCompanyInfoFromCommonDB(int EVENT, string ID, string CODE, DateTime DATE)
        {
            return DL_Users.GetCompanyInfoFromCommonDB(EVENT, ID, CODE, DATE);
        }
        public static IEnumerable<UsersDomain> GetUsers1234(int EVENT, int ID, string CODE)
        {
            return DL_Users.GetUsers1234(EVENT, ID, CODE);
        }


    }
}
