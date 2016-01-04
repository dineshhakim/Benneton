using System;
using System.Data;
using System.Data.SqlClient;

namespace Benetton.Classes
{
    public class VoucherDetails
    {
        public static string GetVoucherNoSystem(int id)
        {
            var cmd = new SqlCommand();
            var voucherNo = "";
            try
            {
                const string cmdstring = "SELECT  dbo.GetVoucherNoSystem(@GlType)";
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdstring;
                cmd.Parameters.AddWithValue("@GlType", id);
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    voucherNo = dr[0].ToString();
                }
                cmd.Dispose();
                return voucherNo;
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
        public static string GetJvVoucherNoSystem(int id)
        {
            var cmd = new SqlCommand();
            var voucherNo = "";
            try
            {
                const string cmdstring = "GetJVVoucherNo";
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = cmdstring;
                cmd.Parameters.AddWithValue("@branchId", id);
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    voucherNo = dr[0].ToString();
                }
                cmd.Dispose();
                return voucherNo;
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