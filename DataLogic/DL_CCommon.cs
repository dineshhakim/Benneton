using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public class DL_CCommon
{
    static SqlConnection con = null;
    public static SqlConnection ConnectionForCommonDb()
    {
        if (con == null)
        {
            con = new SqlConnection();
        }
        try
        {
            con = new SqlConnection();
            try
            {
                con = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["CSCommonDB"].ConnectionString));
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                return con;
            }
            catch
            {

            }
            return con;
        }
        catch
        {

        }
        return con;
    }

    //public static SqlConnection Connection()
    //{
    //    throw new NotImplementedException();
    //}
}

