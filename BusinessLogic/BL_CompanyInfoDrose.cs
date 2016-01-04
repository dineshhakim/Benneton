using System;
using DataLogic;
using System.Data;

namespace BusinessLogic
{
    public class BL_CompanyInfoDrose
    {
        private int _Co_ID = 0; public int Co_ID { get { return _Co_ID; } set { _Co_ID = value; } }
        private string _CompanyName = string.Empty; public string CompanyName { get { return _CompanyName; } set { _CompanyName = value; } }
        private string _RegistrationNo = string.Empty; public string RegistrationNo { get { return _RegistrationNo; } set { _RegistrationNo = value; } }
        private string _PanNo = string.Empty; public string PanNo { get { return _PanNo; } set { _PanNo = value; } }
        private string _Country = string.Empty; public string Country { get { return _Country; } set { _Country = value; } }
        private string _State = string.Empty; public string State { get { return _State; } set { _State = value; } }
        private string _City = string.Empty; public string City { get { return _City; } set { _City = value; } }
        private string _Adress1 = string.Empty; public string Adress1 { get { return _Adress1; } set { _Adress1 = value; } }
        private string _Adress2 = string.Empty; public string Adress2 { get { return _Adress2; } set { _Adress2 = value; } }
        private string _TelephoneNo = string.Empty; public string TelephoneNo { get { return _TelephoneNo; } set { _TelephoneNo = value; } }
        private string _Logo = string.Empty; public string Logo { get { return _Logo; } set { _Logo = value; } }
        private string _EmailAdress = string.Empty; public string EmailAdress { get { return _EmailAdress; } set { _EmailAdress = value; } }
        private string _WebAdress = string.Empty; public string WebAdress { get { return _WebAdress; } set { _WebAdress = value; } }
        private string _C1 = string.Empty; public string C1 { get { return _C1; } set { _C1 = value; } }
        private string _C2 = string.Empty; public string C2 { get { return _C2; } set { _C2 = value; } }
        private string _MC = string.Empty; public string MC { get { return _MC; } set { _MC = value; } }
        private string _Created_Date = string.Empty; public string Created_Date { get { return _Created_Date; } set { _Created_Date = value; } }
        private string _COMPANY_CODE = string.Empty; public string COMPANY_CODE { get { return _COMPANY_CODE; } set { _COMPANY_CODE = value; } }
        private string _DATABASE_NAME = string.Empty; public string DATABASE_NAME { get { return _DATABASE_NAME; } set { _DATABASE_NAME = value; } }
        private string _ADMIN_USER_NAME = string.Empty; public string ADMIN_USER_NAME { get { return _ADMIN_USER_NAME; } set { _ADMIN_USER_NAME = value; } }
        private string _PWD = string.Empty; public string PWD { get { return _PWD; } set { _PWD = value; } }
        private string _IMAGES_DRIVE = string.Empty; public string IMAGES_DRIVE { get { return _IMAGES_DRIVE; } set { _IMAGES_DRIVE = value; } }
        private string _CONTACT_PERSON_NAME = string.Empty; public string CONTACT_PERSON_NAME { get { return _CONTACT_PERSON_NAME; } set { _CONTACT_PERSON_NAME = value; } }
        private string _C_TEL_NO = string.Empty; public string C_TEL_NO { get { return _C_TEL_NO; } set { _C_TEL_NO = value; } }
        private string _MOB_NO = string.Empty; public string MOB_NO { get { return _MOB_NO; } set { _MOB_NO = value; } }
        private string _C_ADDRESS = string.Empty; public string C_ADDRESS { get { return _C_ADDRESS; } set { _C_ADDRESS = value; } }
        private string _EMAIL_ADDRESS = string.Empty; public string EMAIL_ADDRESS { get { return _EMAIL_ADDRESS; } set { _EMAIL_ADDRESS = value; } }
        private string _NOSTRO_AC_NCB = string.Empty; public string NOSTRO_AC_NCB { get { return _NOSTRO_AC_NCB; } set { _NOSTRO_AC_NCB = value; } }
        private string _MIRROR_AC_NCB = string.Empty; public string MIRROR_AC_NCB { get { return _MIRROR_AC_NCB; } set { _MIRROR_AC_NCB = value; } }
        private string _MIRROR_AC_DROSE = string.Empty; public string MIRROR_AC_DROSE { get { return _MIRROR_AC_DROSE; } set { _MIRROR_AC_DROSE = value; } }



        public char EVENT;

        public string InsUpdDelCompanyInfo(out string Id)
        {
            Id = "";
            return DlCompanyInfoDrose.InsUpdDelCompanyInfo(this.EVENT, Co_ID,
CompanyName,
RegistrationNo,
PanNo,
Country,
State,
City,
Adress1,
Adress2,
TelephoneNo,
Logo,
EmailAdress,
WebAdress,
C1,
C2,
MC,
Created_Date,
COMPANY_CODE,
DATABASE_NAME,
ADMIN_USER_NAME,
PWD,
IMAGES_DRIVE,
CONTACT_PERSON_NAME,
C_TEL_NO,
MOB_NO,
C_ADDRESS,
EMAIL_ADDRESS,
NOSTRO_AC_NCB,
MIRROR_AC_NCB,
MIRROR_AC_DROSE, out Id);
        }

        public static DataTable GetCompanyInfo(int EVENT, string ID, string CODE, DateTime DATE)
        {
            return DlCompanyInfoDrose.GetCompanyInfo(EVENT, ID, CODE, DATE);
        }
        public static string GenerateScript(string CompanyCode)
        {
            return DlCompanyInfoDrose.GenerateScript(CompanyCode);
        }
    }
}
