using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLogic
{
    public class DL_Roles
    {
        public static string InsUpdDelRoles(Char EVENT, int ROLE_ID, string ROLE_NAME, out int ReturnId)
        {
            ReturnId = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_IUD_ROLES";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@Event", EVENT);
                cmd.Parameters.AddWithValue("@ID", ROLE_ID);
                cmd.Parameters.AddWithValue("@ROLE_NAME", ROLE_NAME);
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

        public static DataTable GetRoles(int EVENT, int ID, string CODE)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_ROLES";
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
