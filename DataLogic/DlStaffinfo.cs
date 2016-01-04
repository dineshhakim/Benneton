using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Domain;

namespace DataLogic
{
   public class DlStaffinfo
   {

       #region SELECT FOR DROOPDOWNLIST VALUES
       public static DataTable GetGender(int EVENT, int ID, string CODE)
       {
           SqlCommand cmd = new SqlCommand();
           DataTable dt = new DataTable();
           try
           {

               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_SELECT_GENDERSETUP";
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
       public static DataTable GetTitle(int EVENT, int ID, string CODE)
       {
           SqlCommand cmd = new SqlCommand();
           DataTable dt = new DataTable();
           try
           {

               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_SELECT_TITLE";
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
       public static DataTable GetDepartment(int EVENT, int ID, string CODE)
       {
           SqlCommand cmd = new SqlCommand();
           DataTable dt = new DataTable();
           try
           {

               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_SELECT_DEPARTMENT";
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
       public static DataTable GetDesignation(int EVENT, int ID, string CODE)
       {
           SqlCommand cmd = new SqlCommand();
           DataTable dt = new DataTable();
           try
           {

               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_SELECT_DESIGNATION";
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
       public static DataTable GetAcedamicQualification(int EVENT, int ID, string CODE)
       {
           SqlCommand cmd = new SqlCommand();
           DataTable dt = new DataTable();
           try
           {

               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_SELECT_ACEDAMIC_QUALIFICATION";
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
       public static DataTable GetEthnicGroup(int EVENT, int ID, string CODE)
       {
           SqlCommand cmd = new SqlCommand();
           DataTable dt = new DataTable();
           try
           {

               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_SELECT_ETHNIC_GROUP";
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
       public static DataTable GetMaritalStatus(int EVENT, int ID, string CODE)
       {
           SqlCommand cmd = new SqlCommand();
           DataTable dt = new DataTable();
           try
           {

               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_SELECT_MARITAL_STATUS";
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
       public static DataTable GetService(int EVENT, int ID, string CODE)
       {
           SqlCommand cmd = new SqlCommand();
           DataTable dt = new DataTable();
           try
           {

               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_SELECT_SERVICE_TYPE";
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
       #endregion
       #region INSERT INTO SETUP TABLES
       public static string InsUpdDelDesignation(char Event, Designation obj, out int returnId)
       {
           returnId = 0;
           try
           {
               var cmd = new SqlCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_IUD_tbl_Designation";
               cmd.Connection = DL_CCommon.ConnectionForCommonDb();
               cmd.Parameters.AddWithValue("@EVENT", Event);
               cmd.Parameters.AddWithValue("@Id", obj.DId);
               cmd.Parameters.AddWithValue("@DesignationName", obj.DesignationName);
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
       public static string InsUpdDelDepartment(char Event, Department obj, out int returnId)
       {
           returnId = 0;
           try
           {
               var cmd = new SqlCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_IUD_tbl_Department";
               cmd.Connection = DL_CCommon.ConnectionForCommonDb();
               cmd.Parameters.AddWithValue("@EVENT", Event);
               cmd.Parameters.AddWithValue("@Id", obj.DeptId);
               cmd.Parameters.AddWithValue("@DeptName", obj.DeptName);
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
       public static string InsUpdDelAcedamicQualification(char Event, AcedamicQualification obj, out int returnId)
       {
           returnId = 0;
           try
           {
               var cmd = new SqlCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_IUD_tbl_Acedamic_Qualification";
               cmd.Connection = DL_CCommon.ConnectionForCommonDb();
               cmd.Parameters.AddWithValue("@EVENT", Event);
               cmd.Parameters.AddWithValue("@Id", obj.Id);
               cmd.Parameters.AddWithValue("@Qualification", obj.Qualification);
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
       public static string InsUpdDelService(char Event, ServiceType obj, out int returnId)
       {
           returnId = 0;
           try
           {
               var cmd = new SqlCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_IUD_tbl_Service";
               cmd.Connection = DL_CCommon.ConnectionForCommonDb();
               cmd.Parameters.AddWithValue("@EVENT", Event);
               cmd.Parameters.AddWithValue("@Id", obj.Id);
               cmd.Parameters.AddWithValue("@ServiceName", obj.ServiceName);
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
       public static string InsUpdDelEthnicGroup(char Event, EthnicGroup obj, out int returnId)
       {
           returnId = 0;
           try
           {
               var cmd = new SqlCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_IUD_tbl_EthnicGroup";
               cmd.Connection = DL_CCommon.ConnectionForCommonDb();
               cmd.Parameters.AddWithValue("@EVENT", Event);
               cmd.Parameters.AddWithValue("@Id", obj.CatId);
               cmd.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
               cmd.Parameters.AddWithValue("@parentid", 0);
               cmd.Parameters.AddWithValue("@Code", "XX");
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
       public static string UpdStaffToInactive(char EVENT, Staff obj, out int returnId)
       {
           returnId = 0;
           try
           {
               var cmd = new SqlCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_UPD_STAFF_STATUS";
               cmd.Connection = DL_CCommon.ConnectionForCommonDb();
               cmd.Parameters.AddWithValue("@EVENT", EVENT);
               cmd.Parameters.AddWithValue("@Id", obj.StaffId);
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
       #endregion
       public static string InsUpdDelStaffInfo(char EVENT, Staff obj, out int returnId)
       {
           returnId = 0;
           try
           {
               var cmd = new SqlCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "USP_IUD_tbl_Staff_info";
               cmd.Connection = DL_CCommon.ConnectionForCommonDb();
               cmd.Parameters.AddWithValue("@EVENT", EVENT);
               cmd.Parameters.AddWithValue("@Id", obj.StaffId);
               cmd.Parameters.AddWithValue("@UserId", obj.UserId);
               cmd.Parameters.AddWithValue("@Branch_id", obj.BranchId);
               cmd.Parameters.AddWithValue("@Staff_Name", obj.StaffName);
               cmd.Parameters.AddWithValue("@DesignationId", obj.DesignationId);
               cmd.Parameters.AddWithValue("@Address", obj.Address);
               cmd.Parameters.AddWithValue("@ContactNo", obj.ContactNo);
               cmd.Parameters.AddWithValue("@Email", obj.Email);
               cmd.Parameters.AddWithValue("@QualificationId", obj.QualificationId);
               cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
               cmd.Parameters.AddWithValue("@CreatedDate", obj.CreatedDate);
               cmd.Parameters.AddWithValue("@GenderId", obj.GenderId);
               cmd.Parameters.AddWithValue("@JobStartDate", obj.JobStartedDate);
               cmd.Parameters.AddWithValue("@TitleId", obj.TitleId);
               cmd.Parameters.AddWithValue("@DOB", obj.DateOfBirth);
               cmd.Parameters.AddWithValue("@CitizenNo", obj.CitizenNo);
               cmd.Parameters.AddWithValue("@PassportNo", obj.PassportNo);
               cmd.Parameters.AddWithValue("@DepartmentId", obj.DepartmentId);
               cmd.Parameters.AddWithValue("@MarriedId", obj.MarriedId);
               cmd.Parameters.AddWithValue("@ServiceId", obj.ServiceId);
               cmd.Parameters.AddWithValue("@EthinicityId", obj.EthinicityId);
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
       public static DataTable GetStaffDetail(int Event, int id, string code, string code1)
        {
            var cmd = new SqlCommand();
            var dt = new DataTable();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_SELECT_STAFF_INFO";
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
