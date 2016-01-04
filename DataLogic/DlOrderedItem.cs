using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Domain;

namespace DataLogic
{
  public class DlOrderedItem
    {
      public static string InsUpdDelOrderedItem(char Event, ImportExcel obj, out int returnId)
      {
          returnId = 0;
          try
          {
              var cmd = new SqlCommand();
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandTimeout = 500;
              cmd.CommandText = "USP_IUD_tbl_Ordered_List";
              cmd.Connection = DL_CCommon.ConnectionForCommonDb();
              cmd.Parameters.AddWithValue("@EVENT", Event);
              cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
              cmd.Parameters.AddWithValue("@OrderedDate", obj.OrderedDate);
              cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
              cmd.Parameters.AddWithValue("@ExcelData", obj.ExcelData);
              cmd.Parameters.AddWithValue("@ORDER_ID", obj.OrderId);
              cmd.Parameters.AddWithValue("@SEASON", obj.Season);
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
      public static DataTable GetOrderedList(int Event, int id, string code, string code1)
      {
          var cmd = new SqlCommand();
          var dt = new DataTable();
          try
          {
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = "USP_SELECT_ORDERED_LIST";
              cmd.Parameters.AddWithValue("@EVENT", Event);
              cmd.Parameters.AddWithValue("@ID", id);
              cmd.Parameters.AddWithValue("@CODE", code);
              cmd.Parameters.AddWithValue("@CODE1", code1);
              cmd.Parameters.AddWithValue("@Date", DateTime.Today);
              cmd.Connection = DL_CCommon.ConnectionForCommonDb();
              var dr = new SqlDataAdapter(cmd);
              dr.Fill(dt);
              cmd.Dispose();
              return dt;
          }
          catch (Exception ex)
          {

              throw new ArgumentException(ex.Message);
          }

      }
      public static DataTable GetOrderedListByDate(int Event, int id, string code, string code1,DateTime date)
      {
          var cmd = new SqlCommand();
          var dt = new DataTable();
          try
          {
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = "USP_SELECT_ORDERED_LIST";
              cmd.Parameters.AddWithValue("@EVENT", Event);
              cmd.Parameters.AddWithValue("@ID", id);
              cmd.Parameters.AddWithValue("@CODE", code);
              cmd.Parameters.AddWithValue("@CODE1", code1);
              cmd.Parameters.AddWithValue("@Date", date);
              cmd.Connection = DL_CCommon.ConnectionForCommonDb();
              var dr = new SqlDataAdapter(cmd);
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
