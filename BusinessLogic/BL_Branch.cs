using System;
using System.Collections.Generic;
using System.Data;
using DataLogic;
using Domain;

namespace BusinessLogic
{
    public class BL_Branch
    {
        public static string InsUpdDelBranch(char Event, Branch obj, out int id)
        {
            id = 0;
            return DlBranch.InsUpdDelBranch(Event, obj, out id);
        }

        public static List<Branch> GetBranch(int Event, int id, string code, string code1)
        {

            var lst = new List<Branch>();
            var dt = DlBranch.GetBranch(Event, id, code, code1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new Branch(Convert.ToInt32(dr["BranchId"]), dr["BranchName"].ToString(),
                        dr["BranchCode"].ToString(), dr["Address"].ToString(), dr["EmailId"].ToString(),
                        dr["TelNo"].ToString(), dr["ContactPersonName"].ToString(), Convert.ToDateTime(dr["OperationStartDate"].ToString()),
                        Convert.ToBoolean(dr["IsMain"].ToString()));
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static DataTable GetUsersByBranch(int Event, int id, string code, string code1)
        {
            var dt = DlBranch.GetBranch(Event, id, code, code1);
           return dt;
       }
    }
}
