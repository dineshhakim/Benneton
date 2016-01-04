using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Benetton.Settings
{
    public partial class CompanySetup : System.Web.UI.Page
    {
        const string DESKey = "AQWSEDRM";
        const string DESIV = "HGFEDCBM";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtbox_companyName.Focus();
                DataTable dtCompanyInfo = GetCompanyInfo();
                if (dtCompanyInfo.Rows.Count > 0)
                {
                    txtbox_companyName.Text = dtCompanyInfo.Rows[0][1].ToString();
                               tb_cash.Text = "0";
                }

            }
        }
        bool CheckFileType(string fileName)
        {
            var ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                case ".swf":
                    return true;
                case ".bmp":
                    return true;
                default:
                    return false;
            }
        }



        protected void btn_insert_Click(object sender, EventArgs e)
        {
            if (tb_cash.Text == "")
                tb_cash.Text = "0";
            //Label1.Text = "";
            var url = "url";
          
            var companyName = txtbox_companyName.Text;
            var companyName1 = companyName.Substring(0, 10);
            var cc = companyName.Length - 10;
            var companyName2 = companyName.Substring(10, cc);

            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSCommonDB"].ToString());
            conn.Open();
            var com = new SqlCommand();
            com.CommandText = "Insert_Company";
            com.Connection = conn;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cName", txtbox_companyName.Text);
            com.Parameters.AddWithValue("@regNo", DESEncrypt(txtbox_registrationNo.Text));
            com.Parameters.AddWithValue("@panNo", DESEncrypt(txtbox_panNo.Text));
            com.Parameters.AddWithValue("@country", DESEncrypt(txtbox_country.Text));
            com.Parameters.AddWithValue("@state", DESEncrypt(txtbox_state.Text));
            com.Parameters.AddWithValue("@city", DESEncrypt(txtbox_city.Text));
            com.Parameters.AddWithValue("@add1", DESEncrypt(txtbox_add.Text));
            com.Parameters.AddWithValue("@add2", DESEncrypt(txtbox_add2.Text));
            com.Parameters.AddWithValue("@tel", DESEncrypt(txtbox_telephoneNo.Text));
            com.Parameters.AddWithValue("@logo", url);
            com.Parameters.AddWithValue("@email", DESEncrypt(txtbox_emailAddress.Text));
            com.Parameters.AddWithValue("@web", DESEncrypt(txtbox_webAddress.Text));
            com.Parameters.AddWithValue("@closingAmt", decimal.Parse(tb_cash.Text));
            com.Parameters.AddWithValue("@dates", DateTime.Parse(ConvertNE.ConvertNToE(DateStringToInt.StringToInt(tb_date.Text))));
            com.Parameters.AddWithValue("@C1", DESEncrypt(companyName1));
            com.Parameters.AddWithValue("@C2", DESEncrypt(companyName2));

            com.ExecuteNonQuery();
            //insert pic
            //FormView1.DataBind();
        }

        public static string DESEncrypt(string stringToEncrypt)// Encrypt the content
        {
            byte[] key;
            byte[] IV;

            try
            {
                key = Convert2ByteArray(DESKey);
                IV = Convert2ByteArray(DESIV);
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                var des = new DESCryptoServiceProvider();
                var ms = new MemoryStream(); var cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        static byte[] Convert2ByteArray(string strInput)
        {
            int intCounter; char[] arrChar;
            arrChar = strInput.ToCharArray();
            var arrByte = new byte[arrChar.Length];
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

                var len = stringToDecrypt.Length; inputByteArray = Convert.FromBase64String(stringToDecrypt);


                var des = new DESCryptoServiceProvider();

                var ms = new MemoryStream();

                var cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);

                cs.FlushFinalBlock();

                var encoding = Encoding.UTF8; return encoding.GetString(ms.ToArray());
            }

            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public DataTable GetCompanyInfo()
        {
            var dtCompanyInfo = new DataTable();
            var psql = "select *from CompanyInfo";
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSCommonDB"].ToString());
            conn.Open();
            var cmd = new SqlCommand(psql, conn);
            cmd.CommandType = CommandType.Text;
            var da = new SqlDataAdapter(cmd);
            da.Fill(dtCompanyInfo);
            conn.Close();
            return dtCompanyInfo;
        }
    }
}