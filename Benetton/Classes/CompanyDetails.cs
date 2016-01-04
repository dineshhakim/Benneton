using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Benetton.Classes
{
    public class CompanyDetails
    {
        const string DESKey = "AQWSEDRM";
        const string DESIV = "HGFEDCBM";

        public CompanyDetails()
        {

        }
     
        public static DataTable getdatatable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Companyname");
            dt.Columns.Add("Regno");
            dt.Columns.Add("Panno");
            dt.Columns.Add("add1");
            dt.Columns.Add("add2");
            dt.Columns.Add("tel");
            DataRow drs = dt.NewRow();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSCommonDB"].ToString());
            SqlCommand cmd = new SqlCommand("GetCompanyInfo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (conn)
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    drs["Companyname"] = DESDecrypt(dr[13].ToString()) + DESDecrypt(dr[14].ToString());
                    drs["Regno"] = DESDecrypt(dr[2].ToString());
                    drs["Panno"] = DESDecrypt(dr[3].ToString());
                    drs["add1"] = DESDecrypt(dr[7].ToString()) +","+ DESDecrypt(dr[6].ToString());
                    drs["add2"] = DESDecrypt(dr[4].ToString());
                    drs["tel"] = DESDecrypt(dr[9].ToString());
                    dt.Rows.Add(drs);
                }
            }
            conn.Close();
            
            return dt;
        }
        public static DataTable GetBranchInfo(int branch_id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("add1");
            dt.Columns.Add("add2");
            dt.Columns.Add("tel");
            DataRow drs = dt.NewRow();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSCommonDB"].ToString());
            SqlCommand cmd = new SqlCommand("GetBranchInfo", conn);
            cmd.Parameters.AddWithValue("@Branch_Id", branch_id);
            cmd.CommandType = CommandType.StoredProcedure;
            using (conn)
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    drs["add1"] = (dr[0].ToString());
                    drs["add2"] = (dr[1].ToString());
                    drs["tel"] = (dr[2].ToString());
                    dt.Rows.Add(drs);
                }
            }
            conn.Close();
            return dt;
        }
        static byte[] Convert2ByteArray(string strInput)
        {

            int intCounter; char[] arrChar;
            arrChar = strInput.ToCharArray();

            byte[] arrByte = new byte[arrChar.Length];

            for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
                arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);

            return arrByte;
        }

        public static string DESDecrypt(string stringToDecrypt)//Decrypt the content
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);

                IV = Convert2ByteArray(DESIV);

                int len = stringToDecrypt.Length; 

                inputByteArray = Convert.FromBase64String(stringToDecrypt);

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                MemoryStream ms = new MemoryStream();

                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);

                cs.FlushFinalBlock();
                //cs.Flush();
                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());

            }

            catch (System.Exception ex)
            {                
                throw ex;
            }
        }
      

        public static string DESEncrypt(string stringToEncrypt)// Encrypt the content
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);

                IV = Convert2ByteArray(DESIV);

                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                MemoryStream ms = new MemoryStream(); CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);

                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }

            catch (System.Exception ex)
            {

                throw ex;
            }

        }

    }
}