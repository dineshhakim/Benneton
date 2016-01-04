using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DL_PUBLIC;
using Domain;
using System.Reflection;

namespace DataLogic
{
    public class DL_Users
    {
        public static string InsUpdDeleteUsers(char EVENT,
                                                int ID,
                                                int STAFF_ID,
                                                string EMAIL_ID,
                                                string ADDRESS,
                                                string CONTACT_NO,
                                                string USER_NAME,
                                                string PWD,
                                                int BranchId,
                                                int REGISTERED_BY,
                                                DateTime? REGISTERED_DATE,
                                                int ROLE_ID,
                                                bool USER_STATUS,
                                                out int ReturnId)
        {
            ReturnId = 0;
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_IUD_USERS";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@Event", EVENT);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@StaffId",STAFF_ID );
                cmd.Parameters.AddWithValue("@EMAIL_ID", EMAIL_ID);
                cmd.Parameters.AddWithValue("@Address", ADDRESS);
                cmd.Parameters.AddWithValue("@CONTACT_NO", CONTACT_NO);
                cmd.Parameters.AddWithValue("@USER_NAME", USER_NAME);
                cmd.Parameters.AddWithValue("@PWD", PWD);
                cmd.Parameters.AddWithValue("@REGISTERED_BY", REGISTERED_BY);
                cmd.Parameters.AddWithValue("@REGISTERED_DATE", REGISTERED_DATE);
                cmd.Parameters.AddWithValue("@BRANCH_ID", BranchId);
                cmd.Parameters.AddWithValue("@ROLE_ID", ROLE_ID);
                cmd.Parameters.AddWithValue("@USER_STATUS", USER_STATUS);
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

        public static DataTable GetUsers(int EVENT, int ID, string CODE)
        {
            var cmd = new SqlCommand();
            var dt = new DataTable();
            try
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_USERS";
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

        public static DataTable GetCompanyInfoFromCommonDB(int EVENT, string ID, string CODE, DateTime DATE)
        {
            var cmd = new SqlCommand();
            var dt = new DataTable();
            try
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_COMPANYINFO";
                cmd.Parameters.AddWithValue("@EVENT", EVENT);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@CODE", CODE);
                cmd.Parameters.AddWithValue("@DATE", DATE);
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

        public static IEnumerable<UsersDomain> GetUsers1234(int EVENT, int ID, string CODE)
        {
            var cmd = new SqlCommand();
            IEnumerable<UsersDomain> dt = new List<UsersDomain>();
            try
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_USERS";
                cmd.Parameters.AddWithValue("@EVENT", EVENT);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@CODE", CODE);
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                IDataReader dr = cmd.ExecuteReader();
                dt = DataReaderMapToList<UsersDomain>(dr);
                cmd.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            var list = new List<T>();
            var obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}
