using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Domain;

namespace DataLogic
{
   public class DlTheme
    {
        public static string InsUpdDelTheme(char Event, ThemeSetup obj, out int returnId)
        {
            returnId = 0;
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_IUD_Theme_Category";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@EVENT", Event);
                cmd.Parameters.AddWithValue("@ID", obj.Id);
                cmd.Parameters.AddWithValue("@Category", obj.Category);
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
        public static DataTable GetTheme(int Event, int id, string code, string code1)
        {
            var cmd = new SqlCommand();
            var dt = new DataTable();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_Theme_Category";
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
