using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DataLogic
{
    public class DL_CompanyInfoDrose
    {
        public static string InsUpdDelCompanyInfo(char EVENT, int Co_ID,
                                                    string CompanyName,
                                                    string RegistrationNo,
                                                    string PanNo,
                                                    string Country,
                                                    string State,
                                                    string City,
                                                    string Adress1,
                                                    string Adress2,
                                                    string TelephoneNo,
                                                    string Logo,
                                                    string EmailAdress,
                                                    string WebAdress,
                                                    string C1,
                                                    string C2,
                                                    string MC,
                                                    string Created_Date,
                                                    string COMPANY_CODE,
                                                    string DATABASE_NAME,
                                                    string ADMIN_USER_NAME,
                                                    string PWD,
                                                    string IMAGES_DRIVE,
                                                    string CONTACT_PERSON_NAME,
                                                    string C_TEL_NO,
                                                    string MOB_NO,
                                                    string C_ADDRESS,
                                                    string EMAIL_ADDRESS,
                                                    string NOSTRO_AC_NCB,
                                                    string MIRROR_AC_NCB,
                                                    string MIRROR_AC_DROSE, out string ReturnId)
        {
            ReturnId = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_IUD_CompanyInfo";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@EVENT", EVENT);
                cmd.Parameters.AddWithValue("@Co_ID", Co_ID);
                cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                cmd.Parameters.AddWithValue("@RegistrationNo", RegistrationNo);
                cmd.Parameters.AddWithValue("@PanNo", PanNo);
                cmd.Parameters.AddWithValue("@Country", Country);
                cmd.Parameters.AddWithValue("@State", State);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Adress1", Adress1);
                cmd.Parameters.AddWithValue("@Adress2", Adress2);
                cmd.Parameters.AddWithValue("@TelephoneNo", TelephoneNo);
                cmd.Parameters.AddWithValue("@Logo", Logo);
                cmd.Parameters.AddWithValue("@EmailAdress", EmailAdress);
                cmd.Parameters.AddWithValue("@WebAdress", WebAdress);
                cmd.Parameters.AddWithValue("@C1", C1);
                cmd.Parameters.AddWithValue("@C2", C2);
                cmd.Parameters.AddWithValue("@MC", MC);
                cmd.Parameters.AddWithValue("@Created_Date", Created_Date);
                cmd.Parameters.AddWithValue("@COMPANY_CODE", COMPANY_CODE);
                cmd.Parameters.AddWithValue("@DATABASE_NAME", DATABASE_NAME);
                cmd.Parameters.AddWithValue("@ADMIN_USER_NAME", ADMIN_USER_NAME);
                cmd.Parameters.AddWithValue("@PWD", PWD);
                cmd.Parameters.AddWithValue("@IMAGES_DRIVE", IMAGES_DRIVE);
                cmd.Parameters.AddWithValue("@CONTACT_PERSON_NAME", CONTACT_PERSON_NAME);
                cmd.Parameters.AddWithValue("@C_TEL_NO", C_TEL_NO);
                cmd.Parameters.AddWithValue("@MOB_NO", MOB_NO);
                cmd.Parameters.AddWithValue("@C_ADDRESS", C_ADDRESS);
                cmd.Parameters.AddWithValue("@EMAIL_ADDRESS", EMAIL_ADDRESS);
                cmd.Parameters.AddWithValue("@NOSTRO_AC_NCB", NOSTRO_AC_NCB);
                cmd.Parameters.AddWithValue("@MIRROR_AC_NCB", MIRROR_AC_NCB);
                cmd.Parameters.AddWithValue("@MIRROR_AC_DROSE", MIRROR_AC_DROSE);
                SqlParameter outparameter = new SqlParameter("@MSG", SqlDbType.NVarChar, 200);
                outparameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outparameter);
                SqlParameter OutId = new SqlParameter("@RETURNOUTID", SqlDbType.NVarChar, 100);
                OutId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(OutId);
                cmd.ExecuteNonQuery();
                object msg = cmd.Parameters[outparameter.ParameterName].Value;
                ReturnId = cmd.Parameters[OutId.ParameterName].Value.ToString();
                return Convert.ToString(msg);
             
                //string strCreatecmd = "create database " + strdbname + "";
                //SqlCommand cmd = new SqlCommand(strCreatecmd, con1);
                //con1.Open();
                //cmd.ExecuteNonQuery();
                //con1.Close();

                //  Code to execute sql script ie(create tables/storedprocedure/views on ms sqlserver)
                //generatescript.sql is sql script generated and placed under Add_data folder in my application
                //FileInfo file = new FileInfo(Server.MapPath("App_Data\\generatescript.sql"));
                //string strscript = file.OpenText().ReadToEnd();
                //string strupdatescript = strscript.Replace("[databaseOldnameWhileSriptgenerate]", strdbname);
               
                //Server.ConnectionContext.ExecuteNonQuery(strupdatescript);
                //con1.Close();
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

        public static DataTable GetCompanyInfo(int EVENT, string ID, string CODE,DateTime DATE)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
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

        public static string GenerateScript(string CompanyCode)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_IUD_CompanyInfo";
                cmd.Connection = DL_CCommon.ConnectionForCommonDb();
                cmd.Parameters.AddWithValue("@CompanyCode", CompanyCode);              
                SqlParameter outparameter = new SqlParameter("@MSG", SqlDbType.NVarChar, 200);
                outparameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outparameter);               
                cmd.ExecuteNonQuery();
                object msg = cmd.Parameters[outparameter.ParameterName].Value;             
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
