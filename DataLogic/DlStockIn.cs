using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Domain;

namespace DataLogic
{
    public class DlStockIn
    {
        public static string InsUpdDelStockIn(char Event, OrderedItemClass obj,ProductStockIn obj1, out int returnId)
        {
            returnId = 0;
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_IUD_TBL_STOCK_IN";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@EVENT ", Event);
                cmd.Parameters.AddWithValue("@STOCKNO ", obj.StockNo);
                cmd.Parameters.AddWithValue("@DOCNO ", obj.DocNo);
                cmd.Parameters.AddWithValue("@GENDERID ", obj.GenderId);
                cmd.Parameters.AddWithValue("@CATEGORYID ", obj.KnittingCategoryId);
                cmd.Parameters.AddWithValue("@STYLEID ", obj.StyleId);
                cmd.Parameters.AddWithValue("@COLORID ", obj.ColorId);
                cmd.Parameters.AddWithValue("@SIZEID ", obj.SizeId);
                cmd.Parameters.AddWithValue("@QUANTITY  ", obj.Qty);
                cmd.Parameters.AddWithValue("@RATE  ", obj.ItemRate);
                cmd.Parameters.AddWithValue("@MRP  ", obj.MrpNpr);
                cmd.Parameters.AddWithValue("@INDATE  ", obj.Date);
                cmd.Parameters.AddWithValue("@InvoiceNo  ", obj1.InvoiceNo);
                cmd.Parameters.AddWithValue("@Season  ", obj1.Season);
                cmd.Parameters.AddWithValue("@BranchId   ", obj1.BranchId);
                cmd.Parameters.AddWithValue("@CreatedBy   ", obj1.CreatedBy);
                cmd.Parameters.AddWithValue("@AirwayBillNo   ", obj1.AirwayBillNo);
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
        public static DataTable GetStockInDetail(int Event, int id, string code, string code1)
        {
            var cmd = new SqlCommand();
            var dt = new DataTable();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_STOCK_IN";
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
