using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using System.Data;

namespace DataLogic
{
    public class DL_ChildMenu
    {
        
        public static string InsUpdDeleteMainMenu
            (char EVENT, int ChildMenuID, string MenuName, string NavigationURL, int MainMenuID,int Odr, out int ReturnId)
        {
            ReturnId = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_IUD_CHILDMENU";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@Event", EVENT);
                cmd.Parameters.AddWithValue("@ChildMenuID", ChildMenuID);
                cmd.Parameters.AddWithValue("@MenuName", MenuName);
                cmd.Parameters.AddWithValue("@NavigationURL", NavigationURL);
                cmd.Parameters.AddWithValue("@MainMenuID", MainMenuID);
                cmd.Parameters.AddWithValue("@Odr", Odr);
                SqlParameter outparameter = new SqlParameter("@MSG", SqlDbType.NVarChar, 200);
                outparameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outparameter);
                SqlParameter OutId = new SqlParameter("@RETURNOUTID", SqlDbType.NVarChar, 100);
                OutId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(OutId);
                cmd.ExecuteNonQuery();
                object msg = cmd.Parameters[outparameter.ParameterName].Value;
                ReturnId = Convert.ToInt32(cmd.Parameters[OutId.ParameterName].Value);
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

        public static DataTable GetChildMenu(int EVENT, int ID, string CODE)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_CHILDMENU";
                cmd.Parameters.AddWithValue("@EVENT", EVENT);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@CODE", CODE);
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                IDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
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