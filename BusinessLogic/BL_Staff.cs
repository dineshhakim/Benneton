using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
   public class BL_Staff
   {

       #region SELECT SETUP FOR STAFF
       public static DataTable GetGender(int EVENT, int ID, string CODE)
       {
           return DlStaffinfo.GetGender(EVENT, ID, CODE);
       }
       public static DataTable GetMaritalStatus(int EVENT, int ID, string CODE)
       {
           return DlStaffinfo.GetMaritalStatus(EVENT, ID, CODE);
       }
       public static DataTable GetDepartment(int EVENT, int ID, string CODE)
       {
           return DlStaffinfo.GetDepartment(EVENT, ID, CODE);
       }
       public static DataTable GetDesignation(int EVENT, int ID, string CODE)
       {
           return DlStaffinfo.GetDesignation(EVENT, ID, CODE);
       }
       public static DataTable GetAcedamicQualification(int EVENT, int ID, string CODE)
       {
           return DlStaffinfo.GetAcedamicQualification(EVENT, ID, CODE);
       }
       public static DataTable GetEthnicGroup(int EVENT, int ID, string CODE)
       {
           return DlStaffinfo.GetEthnicGroup(EVENT, ID, CODE);
       }
       public static DataTable GetTitle(int EVENT, int ID, string CODE)
       {
           return DlStaffinfo.GetTitle(EVENT, ID, CODE);
       }
       public static DataTable GetService(int EVENT, int ID, string CODE)
       {
           return DlStaffinfo.GetService(EVENT, ID, CODE);
       }
       #endregion

       #region INSERT SETUP FOR STAFF
       public static string InsUpdDelDepartment(char Event, Department obj, out int id)
       {
           id = 0;
           return DlStaffinfo.InsUpdDelDepartment(Event, obj, out id);
       }
       public static string InsUpdDelDesignation(char Event, Designation obj, out int id)
       {
           id = 0;
           return DlStaffinfo.InsUpdDelDesignation(Event, obj, out id);
       }
       public static string InsUpdDelAcedamicQualification(char Event, AcedamicQualification obj, out int id)
       {
           id = 0;
           return DlStaffinfo.InsUpdDelAcedamicQualification(Event, obj, out id);
       }
       public static string InsUpdDelEthnicGroup(char Event, EthnicGroup obj, out int id)
       {
           id = 0;
           return DlStaffinfo.InsUpdDelEthnicGroup(Event, obj, out id);
       }
       public static string InsUpdDelService(char Event, ServiceType obj, out int id)
       {
           id = 0;
           return DlStaffinfo.InsUpdDelService(Event, obj, out id);
       }
       public static string InsUpdDelStaffInfo(char Event, Staff obj, out int id)
       {
           id = 0;
           return DlStaffinfo.InsUpdDelStaffInfo(Event, obj, out id);
       }
       public static string UpdStaffToInactive(char Event, Staff obj, out int id)
       {
           id = 0;
           return DlStaffinfo.UpdStaffToInactive(Event, obj, out id);
       }
       #endregion
       public static DataTable GetStaffDetail(int Event, int id, string code, string code1)
       {
           var dt = DlStaffinfo.GetStaffDetail(Event, id, code, code1);
           return dt;
       }
   }

}
