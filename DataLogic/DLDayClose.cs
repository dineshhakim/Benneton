using System;
using Domain;
using System.Data;
using System.Data.SqlClient;


namespace DataLogic
{
    public class DLDayClose
    {
        public static string InsUpdDelDayCloselog(char Event, DayClose obj, out int returnId)
        {
            returnId = 0;
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_IUD_tbl_DayCloseLog";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@EVENT", Event);
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@Date", obj.Date);
                cmd.Parameters.AddWithValue("@createdby", obj.Createdby);
                cmd.Parameters.AddWithValue("@createddate", obj.Createddate);
                cmd.Parameters.AddWithValue("@Branch_Id", obj.Branchid);
                cmd.Parameters.AddWithValue("@DayClose", obj.Dayclose);
                cmd.Parameters.AddWithValue("@HValue", obj.HValue);
                cmd.Parameters.AddWithValue("@Verified", obj.Verified);
                cmd.Parameters.AddWithValue("@status", obj.Status);
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
        public static void InsertDayOpen(int branchId, DateTime date, int createdBy)
        {
            try
            {

                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertDayOpenLog";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@createdby", createdBy);
                cmd.Parameters.AddWithValue("@DATE", date);
                cmd.Parameters.AddWithValue("@Branch_Id", branchId);
                cmd.ExecuteNonQuery();
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

        public static string GetOperationDate(int branchId)
        {
            string opdate = "";
            try
            {

                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetOperationDate";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@Branch_Id", branchId);
                SqlDataReader adr = cmd.ExecuteReader();
                while (adr.Read())
                {
                    opdate = adr[0].ToString();
                }
                DL_CCommon.ConnectionForCommonDb().Close();
                return opdate;
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

    }
}
