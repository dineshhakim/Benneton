using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class UsersDomain
    {
        private int _ID = 0;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _NAME = string.Empty;
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        private string _EMAIL_ID = string.Empty;
        public string EMAIL_ID
        {
            get { return _EMAIL_ID; }
            set { _EMAIL_ID = value; }
        }
        private string _CONTACT_NO = string.Empty;
        public string CONTACT_NO
        {
            get { return _CONTACT_NO; }
            set { _CONTACT_NO = value; }
        }
        private string _USER_NAME = string.Empty;
        public string USER_NAME
        {
            get { return _USER_NAME; }
            set { _USER_NAME = value; }
        }
        private string _PWD = string.Empty;
        public string PWD
        {
            get { return _PWD; }
            set { _PWD = value; }
        }
        private int _REGISTERED_BY = 0;
        public int REGISTERED_BY
        {
            get { return _REGISTERED_BY; }
            set { _REGISTERED_BY = value; }
        }
        private DateTime? _REGISTERED_DATE = Convert.ToDateTime("01/01/1991");
        public DateTime? REGISTERED_DATE
        {
            get { return _REGISTERED_DATE; }
            set { _REGISTERED_DATE = value; }
        }
    }
}
