using System;
using System.Data;
using Domain;
using System.Data.SqlClient;

namespace DataLogic
{
    
    public class DlLa
    {
        public static string GetLa_CODE(int EVENT, int ID, string CODE)
        {
            var cmd = new SqlCommand();
            var la_code = "";
            try
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_LA";
                cmd.Parameters.AddWithValue("@EVENT", EVENT);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@CODE", CODE);
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    la_code = (dr[0].ToString());
                }
                cmd.Dispose();
                return la_code;
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

        public static DataTable GetLa(int EVENT, int id, string CODE)
        {
            var cmd = new SqlCommand();
            var dt = new DataTable();
            try
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_LA";
                cmd.Parameters.AddWithValue("@EVENT", EVENT);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@CODE", CODE);
                cmd.Parameters.AddWithValue("@CODE1", CODE);
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
            finally
            {
                DL_CCommon.ConnectionForCommonDb().Close();
            }
        }

        public static string InsUpdDelLA(PL_LA obj, out int ReturnId)
        {
            ReturnId = 0;
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_IUD_LA";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@Event", obj.EVENT);
                cmd.Parameters.AddWithValue("@LA_ID", obj.LA_ID);
                cmd.Parameters.AddWithValue("@LA_Code", obj.LA_Code);
                cmd.Parameters.AddWithValue("@LA", obj.LA);
                cmd.Parameters.AddWithValue("@LA_ParentID", obj.LA_ParentID);
                cmd.Parameters.AddWithValue("@LA_Primary", obj.LA_Primary);
                cmd.Parameters.AddWithValue("@LA_Child", obj.LA_Child);
                cmd.Parameters.AddWithValue("@IsNeeded", obj.IsNeeded);
                var outparameter = new SqlParameter("@MSG", SqlDbType.NVarChar, 200);
                outparameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outparameter);
                var OutId = new SqlParameter("@RETURNOUTID", SqlDbType.NVarChar, 100);
                OutId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(OutId);
                cmd.ExecuteNonQuery();
                var msg = cmd.Parameters[outparameter.ParameterName].Value;
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
    }
}