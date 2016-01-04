using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DL_PUBLIC;
using Domain;

namespace DataLogic
{
   public class DlBranch
    {
        public static string InsUpdDelBranch(char Event, Branch obj, out int returnId)
        {
            returnId = 0;
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_IUD_BRANCH";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@EVENT", Event);
                cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                cmd.Parameters.AddWithValue("@BranchName", obj.BranchName);
                cmd.Parameters.AddWithValue("@BranchCode", obj.BranchCode);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@EmailId", obj.EmailId);
                cmd.Parameters.AddWithValue("@TelNo", obj.TelNo);
                cmd.Parameters.AddWithValue("@ContactPersonName", obj.ContactPersonName);
                cmd.Parameters.AddWithValue("@OperationStartDate", obj.OperationStartDate);
                cmd.Parameters.AddWithValue("@IsMain", obj.IsMain);
                var outparameter = new SqlParameter("@MSG", SqlDbType.NVarChar, 200);
                outparameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outparameter);
                var outId = new SqlParameter("@RETURNOUTID", SqlDbType.NVarChar, 100);
                outId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outId);
                cmd.ExecuteNonQuery();
                var msg = cmd.Parameters[outparameter.ParameterName].Value;
                returnId = Convert.ToInt32(cmd.Parameters[outId.ParameterName].Value);
                return Convert.ToString(msg);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                DL_CCommon.ConnectionForCommonDb().Close();
            }
        }
        public static DataTable GetBranch(int Event, int id, string code, string code1)
        {
            var cmd = new SqlCommand();
            var dt = new DataTable();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_Branch";
                cmd.Parameters.AddWithValue("@EVENT", Event);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@CODE", code);
                cmd.Parameters.AddWithValue("@CODE1", code1);
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                SqlDataAdapter dr = new SqlDataAdapter(cmd);
                dr.Fill(dt);
                cmd.Dispose();
                return dt;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }

        }
    }
}
