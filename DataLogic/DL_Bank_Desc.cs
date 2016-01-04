using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Domain;

namespace DataLogic
{
   public class DL_Bank_Desc
    {
    //     public DL_BankDesc()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}
    public static string InsUpdDelBankDesc(Char EVENT,Bank obj, out int ReturnId)
    {
        ReturnId = 0;
        try
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "USP_IUD_BankDesc";
            cmd.Connection = DL_CCommon.ConnectionForCommonDb();
            cmd.Parameters.AddWithValue("@Event", EVENT);
            cmd.Parameters.AddWithValue("@BDesc_ID", obj.BankDescId);
            cmd.Parameters.AddWithValue("@BDesc_Name",obj.BankDescName);
            cmd.Parameters.AddWithValue("@BDesc_AccNo", obj.BankDescAccountNo);
            cmd.Parameters.AddWithValue("@TDAmt", obj.TranDpstAmt);
            cmd.Parameters.AddWithValue("@TWAmt", obj.TranWtdAmt);
            cmd.Parameters.AddWithValue("@Opening_Date", obj.OpeningDate);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@CreatedDate", obj.CreatedDate);
            cmd.Parameters.AddWithValue("@ModifiedBy", obj.ModifiedBy);
            cmd.Parameters.AddWithValue("@ModifiedDate", obj.ModifiedDate);
            cmd.Parameters.AddWithValue("@AccountType", obj.AccountType);
            cmd.Parameters.AddWithValue("@class", obj.ClassType);
            cmd.Parameters.AddWithValue("@Branch_Id", obj.BranchId);
            cmd.Parameters.AddWithValue("@rate", obj.Rate);
            cmd.Parameters.AddWithValue("@calmethod", obj.CalMethod);
            cmd.Parameters.AddWithValue("@accumulationtype", obj.AccumulationType);
            cmd.Parameters.AddWithValue("@maturitydate", obj.MaturityDate);
            cmd.Parameters.AddWithValue("@cashbank", obj.CashBank);
            cmd.Parameters.AddWithValue("@bankid", obj.BankId);
            cmd.Parameters.AddWithValue("@InterestAccumulationAc", obj.InterestAccumulationAc);
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
    public static DataTable GetBankDetails(int EVENT, int ID, string CODE)
    {
        var cmd = new SqlCommand();
        var dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "USP_SELECT_BANKDESC";
            cmd.Parameters.AddWithValue("@EVENT", EVENT);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@CODE", CODE);
            cmd.Connection = DL_CCommon.ConnectionForCommonDb();
            var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cmd.Dispose();
            return dt;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    //public static DataTable GetBankTransaction(int Event, int id, string code, DateTime date)
    //{
    //    var cmd = new SqlCommand();
    //    var dt = new DataTable();
    //    try
    //    {

    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandText = "USP_SELECT_BANK_TRANSACTION";
    //        cmd.Parameters.AddWithValue("@EVENT", Event);
    //        cmd.Parameters.AddWithValue("@ID", id);
    //        cmd.Parameters.AddWithValue("@CODE", code);
    //        cmd.Parameters.AddWithValue("@DATE", date);
    //        cmd.Connection = DL_CCommon.Connection();
    //        var da = new SqlDataAdapter(cmd);
    //        da.Fill(dt);
    //        cmd.Dispose();
    //        return dt;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ArgumentException(ex.Message);
    //    }
    //}

    //public static string DeleteBankTransaction(string voucherno, int deletedby, string deletedRemarks)
    //{
    //    try
    //    {
    //        var cmd = new SqlCommand();
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandText = "USP_DELETE_BANK_TRANSACTION";
    //        cmd.Connection = DL_CCommon.Connection();

    //        cmd.Parameters.AddWithValue("@VOUCHER_NO", voucherno);
    //        cmd.Parameters.AddWithValue("@DELETED_BY", deletedby);
    //        cmd.Parameters.AddWithValue("@DELETED_REMARKS", deletedRemarks);
    //        var outparameter = new SqlParameter("@MSG", SqlDbType.NVarChar, 200);
    //        outparameter.Direction = ParameterDirection.Output;
    //        cmd.Parameters.Add(outparameter);
    //        cmd.ExecuteNonQuery();
    //        var msg = cmd.Parameters[outparameter.ParameterName].Value;
    //        return Convert.ToString(msg);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ArgumentException(ex.Message);
    //    }
    //    finally
    //    {
    //        DL_CCommon.Connection().Close();
    //    }
    //}

    public static DataTable GetIntAccumulate(int EVENT, int ID, string CODE)
    {
        var cmd = new SqlCommand();
        var dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "USP_SELECT_IntAccumulate";
            cmd.Parameters.AddWithValue("@EVENT", EVENT);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@CODE", CODE);
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
    public static DataTable GetIntCalMethod(int EVENT, int ID, string CODE)
    {
        var cmd = new SqlCommand();
        var dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "USP_SELECT_IntCalMethod";
            cmd.Parameters.AddWithValue("@EVENT", EVENT);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@CODE", CODE);
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
    public static decimal GetBankBal(int bankid)
    {
        decimal bankbal = 0;
        var cmd = new SqlCommand();
        var dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBankAmt";
            cmd.Parameters.AddWithValue("@bankId", bankid);
            cmd.Connection = DL_CCommon.ConnectionForCommonDb();
            var adr = cmd.ExecuteReader();
            while (adr.Read())
            {
                bankbal = decimal.Parse(adr[0].ToString());
            }
          //  dr.Fill(dt);
            cmd.Dispose();
            return bankbal;
        }
        catch (Exception ex)
        {

            throw new ArgumentException(ex.Message);
        }


       
    }
    }
}
