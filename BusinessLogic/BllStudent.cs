using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;
using System.Data;

namespace BusinessLogic
{
    public class BllStudent
    {
        public static string InsUpdDelStudent(char Event, StudentInfo obj, out int id)
        {
            id = 0;
            return DllStudentInfo.InsUpdDelStudent(Event, obj, out id);
        }
        public static DataTable GetPharmacistsDetails(int Event, int id, string code,string code1,string code2)
        {
            var dt = DllStudentInfo.GetPharmacistsDetails(Event, id, code, code1, code2);
            return dt;
        }
        public static DataSet GetPharmacistsDetailsByStudentId(int Event, int id, string code, string code1, string code2)
        {
            var dt = DllStudentInfo.GetPharmacistsDetailsByStudentId(Event, id, code, code1, code2);
            return dt;
        }
        public static DataTable GetPharmacistsDetailByDate(int Event, int id, string code,string code1, DateTime fromdate, DateTime todate)
        {
            var dt = DllStudentInfo.GetPharmacistsDetailByDate(Event, id, code,code1, fromdate, todate);
            return dt;
        }
        public static string GetBillNo(int Event, int id, string code, string voucherno)
        {
            return DllStudentInfo.GetBillNo(Event, id, code,voucherno);
        }
        public static decimal GetFeeAmount(int Event, int id, string code)
        {
            return DllStudentInfo.GetFeeAmount(Event, id, code);
        }
        public static string GetRegistrationNo(int Event, int id, string code)
        {
            return DllStudentInfo.GetRegistrationNo(Event, id, code);
        }
        public static string UpdatePharmacist(char Event, string xmlPharmacistList,string xmlSubjectCommittee, out int id)
        {
            id = 0;
            return DllStudentInfo.UpdatePharmacist(Event, xmlPharmacistList,xmlSubjectCommittee, out id);
        }
    }
}
