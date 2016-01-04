using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using  Domain;

namespace DataLogic
{
    public class DlIncomeExp
    {
        public static DataTable GetIncomeExp(int EVENT, int ID, string CODE)
        {
            var cmd = new SqlCommand();
            var dt = new DataTable();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_INCOMEEXP";
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
            finally
            {
                DL_CCommon.ConnectionForCommonDb().Close();
            }
            
        }

        public static string InsUpdDelIncomeExp(PL_IncomeExp obj, out int ReturnId)
        {
            ReturnId = 0;
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_IUD_IncomeExp";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@Event", obj.EVENT);
                cmd.Parameters.AddWithValue("@IE_ID", obj.IE_ID);
                cmd.Parameters.AddWithValue("@IE_Code", obj.IE_Code);
                cmd.Parameters.AddWithValue("@IE", obj.IE);
                cmd.Parameters.AddWithValue("@IE_ParentID", obj.IE_ParentID);
                cmd.Parameters.AddWithValue("@IE_Primary", obj.IE_Primary);
                cmd.Parameters.AddWithValue("@Ie_Child", obj.Ie_Child);
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
        public static string GetIE_CODE(int EVENT, int ID, string CODE)
        {
            var cmd = new SqlCommand();
            var ie_code = "";
            try
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_IncomeExp";
                cmd.Parameters.AddWithValue("@EVENT", EVENT);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@CODE", CODE);
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ie_code = (dr[0].ToString());
                }
                cmd.Dispose();
                return ie_code;
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
        public static string GetIEForIeCode(string code, string type)
        {
            var cmd = new SqlCommand();
            var ie = "";
            try
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT top 1 ie FROM dbo.IncomeExp ie WHERE ie.IE_Code= @CODE AND dbo.GetIEParentId(ie.IE_ID)=@ID and isnull(isneeded,0)=1 and isnull(IE_primary,0)=0";
                cmd.Parameters.AddWithValue("@ID", type);
                cmd.Parameters.AddWithValue("@CODE", code);
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ie = (dr[0].ToString());
                }
                cmd.Dispose();
                return ie;
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
        public static string GetIECodeForIe(string code, string type)
        {
            var cmd = new SqlCommand();
            var ie = "";
            try
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT top 1 ie_code FROM dbo.IncomeExp ie WHERE ie.ie= @CODE AND dbo.GetIEParentId(ie.IE_ID)=@ID and isnull(isneeded,0)=1 and isnull(IE_primary,0)=0";
                cmd.Parameters.AddWithValue("@ID", type);
                cmd.Parameters.AddWithValue("@CODE", code);
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ie = (dr[0].ToString());
                }
                cmd.Dispose();
                return ie;
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
        public static string GetIeParent(string code, string type, string iecode)
        {
            var cmd = new SqlCommand();
            var ie = "";
            try
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT top 1 ie FROM dbo.IncomeExp ie WHERE ie.ie_id=(select top 1 ie_parentid from incomeexp where ie= @CODE and IE_CODE=@IE_CODE)";
                cmd.Parameters.AddWithValue("@ID", type);
                cmd.Parameters.AddWithValue("@CODE", code);
                cmd.Parameters.AddWithValue("@IE_CODE", iecode);
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ie = (dr[0].ToString());
                }
                cmd.Dispose();
                return ie;
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
