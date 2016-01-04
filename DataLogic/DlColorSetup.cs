using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Domain;

namespace DataLogic
{
   public class DlColorSetup
    {
        public static string InsUpdDelColor(char Event, Color obj, out int returnId)
        {
            returnId = 0;
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_IUD_tbl_Color_Setup";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@EVENT", Event);
                cmd.Parameters.AddWithValue("@ID", obj.Id);
                cmd.Parameters.AddWithValue("@CategoryId", obj.CategoryId);
                cmd.Parameters.AddWithValue("@StyleId", obj.StyleId);
                cmd.Parameters.AddWithValue("@Color_Code", obj.ColorCode);
                cmd.Parameters.AddWithValue("@Color_Name", obj.ColorName);
                var outparameter = new SqlParameter("@MSG", SqlDbType.NVarChar, 200)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outparameter);
                var outId = new SqlParameter("@RETURNOUTID", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
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
        public static DataTable GetColorDetail(int Event, int id, int id1, string code1)
        {
            var cmd = new SqlCommand();
            var dt = new DataTable();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_COLOR";
                cmd.Parameters.AddWithValue("@EVENT", Event);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@ID1", id1);
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
