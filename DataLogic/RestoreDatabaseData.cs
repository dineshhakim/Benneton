using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DL_PUBLIC;

namespace DataLogic
{
    public class RestoreDatabaseData
    {
        public static DataTable RestoreDatabase(int Event, string fileName, string databaseName)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                //cmd = new SqlCommand("RestoreDatabase1", DL_CCommon.ConnectionForCommonDb());
                //cmd.Parameters.AddWithValue("@event", Event);
                //cmd.Parameters.AddWithValue("@Location", fileName);
                //cmd.Parameters.AddWithValue("@DatabaseName", databaseName);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RestoreDatabase1";
                cmd.Parameters.AddWithValue("@EVENT", Event);
                cmd.Parameters.AddWithValue("@Location", fileName);
                cmd.Parameters.AddWithValue("@DatabaseName", databaseName);
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
