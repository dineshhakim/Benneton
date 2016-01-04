using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using ProudMonkey.Common.Controls;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace Benetton.Common
{
    public partial class AddOrganization : System.Web.UI.Page
    {
        const string DESKey = "AQWSEDRF";
        const string DESIV = "HGFEDCBA";
        ProudMonkey.Common.Controls.MessageBox msgbox;

        protected void Page_Init(object sender, EventArgs e)
        {
            msgbox = new MessageBox()
            {

            };
            this.pnlMsgBox.Controls.Clear();
            this.pnlMsgBox.Controls.Add(msgbox);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Code"] != null)
                {
                    GetCompanyInfo(Request.QueryString["Code"].ToString());

                }
            }

        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            if (btn_insert.CommandName == "Insert")
            {
                InsUpdDelCompanyInfo('I', "");
            }
            else if (btn_insert.CommandName == "Update")
            {
                InsUpdDelCompanyInfo('U', btn_insert.CommandArgument.ToString());
            }

        }

        private void InsUpdDelCompanyInfo(char Event, string Id)
        {
            try
            {
                BL_CompanyInfoDrose obj = new BL_CompanyInfoDrose();
                string CompanyName = txtCompanyName.Text;
                string CompanyName1 = CompanyName.Substring(0, 10);
                int cc = CompanyName.Length - 10;
                string CompanyName2 = CompanyName.Substring(10, cc);
                obj.EVENT = Event;
                obj.Co_ID = 0;
                if (Event == 'I' || Event == 'U')
                {
                    obj.CompanyName = txtCompanyName.Text;
                    obj.RegistrationNo = txtRegistrationNo.Text;
                    obj.PanNo = (txtPanNo.Text);
                    obj.Country = (txtCountry.Text);
                    obj.State = (txtState.Text);
                    obj.City = (txtCity.Text);
                    obj.Adress1 = (txtAddress1.Text);
                    obj.Adress2 = (txtAddress2.Text);
                    obj.TelephoneNo = (txtTelephoneNo.Text);
                    obj.EmailAdress = (txtEmailAddress.Text);
                    obj.WebAdress = (txtWebAddress.Text);
                    obj.C1 = (CompanyName1);
                    obj.C2 = (CompanyName2);
                    obj.MC = "";
                    obj.Created_Date = (ConvertNE.convertNepaliToEnglish(txtDate.Text).ToString());
                    obj.COMPANY_CODE = Id;
                    obj.ADMIN_USER_NAME = (txtUserName.Text);
                    obj.PWD = (txtPassword.Text);
                    obj.IMAGES_DRIVE = txtImagesDrive.Text;


                    obj.CONTACT_PERSON_NAME = txtContactAddress.Text;
                    obj.EMAIL_ADDRESS = txtEmailAdd.Text;
                    obj.MIRROR_AC_DROSE = txtMirrorDrose.Text;
                    obj.MIRROR_AC_NCB = txtMirrorNCB.Text;
                    obj.NOSTRO_AC_NCB = txtNostroAcNCB.Text;
                    obj.MOB_NO = txtMobNo.Text;
                    obj.C_ADDRESS = txtContactAddress.Text;
                    obj.C_TEL_NO = txtTelNo.Text;

                }
                string msg = obj.InsUpdDelCompanyInfo(out Id);
                if (msg == "Record Inserted Successfully" || msg == "Record Updated Successfully" || msg == "Record Deleted Successfully")
                {
                    string path = txtImagesDrive.Text + Id.ToString();
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string p = picUpload(FileUpload1, path);
                    if (p == "url")
                        p = "nophoto.gif";

                    //Check Info In Company Code
                    // BL_CompanyInfoDrose.
                    msgbox.ShowSuccess(msg);
                    Response.Redirect("~/Common/OrganizationList.aspx");
                    ExecuteQuery(Id);
                    Clear();
                }
                else
                {
                    msgbox.ShowWarning(msg);
                }
            }
            catch (Exception ex)
            {
                msgbox.ShowWarning(ex.Message);
            }


        }

        private void Clear()
        {
            txtCompanyName.Text = "";
            txtRegistrationNo.Text = "";
            txtRegistrationNo.Enabled = true;
            txtPanNo.Text = "";
            txtCountry.Text = "Nepal";
            txtState.Text = "";
            txtCity.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtTelephoneNo.Text = "";
            txtEmailAddress.Text = "";
            txtWebAddress.Text = "";
            txtDate.Text = "";
            txtUserName.Text = "";
            txtImagesDrive.Text = @"D:\";
            txtNostroAcNCB.Text = "";
            txtMirrorDrose.Text = "";
            txtMirrorNCB.Text = "";
            txtMobNo.Text = "";
            txtContactPersonName.Text = "";
            txtContactAddress.Text = "";
            txtEmailAdd.Text = "";
            txtTelNo.Text = "";
            btn_insert.CommandName = "Insert";
            btn_insert.Text = "Insert";

        }

        public void EmptyTextBoxes(Control parent)
        {
            // Loop through all the controls on the page
            foreach (Control c in parent.Controls)
            {
                // Check and see if it's a textbox
                if ((c.GetType() == typeof(TextBox)))
                {
                    // Since its a textbox clear out the text  
                    ((TextBox)(c)).Text = "";
                }
                // Now we need to call itself (recursive) because
                // all items (Panel, GroupBox, etc) is a container
                // so we need to check all containers for any
                // textboxes so we can clear them
                if (c.HasControls())
                {
                    EmptyTextBoxes(c);
                }
            }
        }

        #region FileUpload
        private bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
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

        public string picUpload(FileUpload pic, string path)
        {
            if (CheckFileType(pic.FileName))
            {
                // EnsureDirectoriesExist();
                string name = Path.GetFileName(pic.FileName);
                string extension = Path.GetExtension(name);
                //create GUID name
                string url = Guid.NewGuid().ToString() + Path.GetExtension(name);

                String filePath = path + "/" + url;
                pic.SaveAs(MapPath(filePath));
                return url;
            }
            else
                return "url";
        }
        #endregion

        //public static string (string stringToEncrypt)// Encrypt the content
        //{
        //    byte[] key;
        //    byte[] IV;

        //    byte[] inputByteArray;
        //    try
        //    {
        //        key = Convert2ByteArray(DESKey);
        //        IV = Convert2ByteArray(DESIV);
        //        inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
        //        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        //        MemoryStream ms = new MemoryStream(); CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
        //        cs.Write(inputByteArray, 0, inputByteArray.Length);
        //        cs.FlushFinalBlock();
        //        return Convert.ToBase64String(ms.ToArray());
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //static byte[] Convert2ByteArray(string strInput)
        //{
        //    int intCounter; char[] arrChar;
        //    arrChar = strInput.ToCharArray();
        //    byte[] arrByte = new byte[arrChar.Length];
        //    for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
        //        arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);
        //    return arrByte;
        //}



        private void GetCompanyInfo(string CompanyCode)
        {
            DataTable dt = BL_CompanyInfoDrose.GetCompanyInfo(1, "", CompanyCode, System.DateTime.Now);
            if (dt.Rows.Count > 0)
            {
                txtCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                txtRegistrationNo.Text = "";
                txtRegistrationNo.Enabled = false;
                txtPanNo.Text = (dt.Rows[0]["PanNo"].ToString());
                txtCountry.Text = (dt.Rows[0]["Country"].ToString());
                txtState.Text = (dt.Rows[0]["State"].ToString());
                txtCity.Text = (dt.Rows[0]["City"].ToString());
                txtAddress1.Text = (dt.Rows[0]["Adress1"].ToString());
                txtAddress2.Text = (dt.Rows[0]["Adress2"].ToString());
                txtTelephoneNo.Text = (dt.Rows[0]["TelephoneNo"].ToString());
                // (dt.Rows[0]["Logo"].ToString());
                txtEmailAddress.Text = (dt.Rows[0]["EmailAdress"].ToString());
                txtWebAddress.Text = (dt.Rows[0]["WebAdress"].ToString());
                //(dt.Rows[0]["C1"].ToString());
                //(dt.Rows[0]["C2"].ToString());
                //  (dt.Rows[0]["MC"].ToString());
                txtDate.Text = ConvertNE.ConvertEToNWithSlash(Convert.ToDateTime((dt.Rows[0]["Created_Date"].ToString())));
                btn_insert.CommandArgument = dt.Rows[0]["COMPANY_CODE"].ToString();
                // (dt.Rows[0]["DATABASE_NAME"].ToString());
                txtUserName.Text = (dt.Rows[0]["ADMIN_USER_NAME"].ToString());
                //(dt.Rows[0]["PWD"].ToString());
                txtImagesDrive.Text = dt.Rows[0]["IMAGES_DRIVE"].ToString();

                txtContactPersonName.Text = dt.Rows[0]["CONTACT_PERSON_NAME"].ToString();
                txtTelNo.Text = dt.Rows[0]["C_TEL_NO"].ToString();
                txtMobNo.Text = dt.Rows[0]["MOB_NO"].ToString();
                txtContactAddress.Text = dt.Rows[0]["C_ADDRESS"].ToString();
                txtEmailAdd.Text = dt.Rows[0]["EMAIL_ADDRESS"].ToString();
                txtNostroAcNCB.Text = dt.Rows[0]["NOSTRO_AC_NCB"].ToString();
                txtMirrorNCB.Text = dt.Rows[0]["MIRROR_AC_NCB"].ToString();
                txtMirrorNCB.Text = dt.Rows[0]["MIRROR_AC_DROSE"].ToString();


                btn_insert.Text = "Update";
                btn_insert.CommandName = "Update";

            }
        }

        //public static string (string stringToDecrypt)//Decrypt the content
        //{

        //    byte[] key;
        //    byte[] IV;

        //    byte[] inputByteArray;
        //    try
        //    {

        //        key = Convert2ByteArray(DESKey);
        //        IV = Convert2ByteArray(DESIV);
        //        int len = stringToDecrypt.Length;
        //        inputByteArray = Convert.FromBase64String(stringToDecrypt);
        //        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        //        MemoryStream ms = new MemoryStream();
        //        CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
        //        cs.Write(inputByteArray, 0, inputByteArray.Length);
        //        cs.FlushFinalBlock();
        //        Encoding encoding = Encoding.UTF8; return encoding.GetString(ms.ToArray());
        //    }

        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();

            //SqlConnection con1 = new SqlConnection();
            //string strdbname = "abc";
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
            //Server server = new Server(new ServerConnection(con1));
            // Server.ConnectionContext.ExecuteNonQuery(strupdatescript);
            // con1.Close();

        }

        private void ExecuteQuery(string code)
        {
            try
            {
                //   string backUpPath = @"D:\\" + "Skynix_01_10_2013.bak";
                //   string constr = @"Data Source=.;Initial Catalog=" + code + "; User ID=sa; Password=Test123;Integrated Security=True; ";
                //   SqlConnection con = new SqlConnection(constr);
                //   con.Open();
                //   string UseMaster = "USE master";
                //   SqlCommand UseMasterCommand = new SqlCommand(UseMaster, con);
                //   UseMasterCommand.ExecuteNonQuery();

                //   string Alter1 = @"ALTER DATABASE [" + code + "] SET Single_User WITH Rollback Immediate";
                //   SqlCommand Alter1Cmd = new SqlCommand(Alter1, con);
                //   Alter1Cmd.ExecuteNonQuery();

                //   string Restore = @" RESTORE DATABASE [" + code + "] FROM DISK = N'" + backUpPath + @"' WITH MOVE 'PrimaryFileName' TO 'C:\\Program Files\\Microsoft SQL Server\\MSSQL10_50.MSSQLSERVER\\MSSQL\\DATA\\" + code + ".mdf',MOVE 'PrimaryLogFileName' TO 'C:\\Program Files\\Microsoft SQL Server\\MSSQL10_50.MSSQLSERVER\\MSSQL\\DATA\\" + code + ".ldf',REPLACE";
                ////   string Restore = @"RESTORE DATABASE [" + code + "] FROM DISK = N'" + backUpPath + @"' WITH   REPLACE, FILE = 1,  NOUNLOAD,  STATS = 10";
                //   SqlCommand RestoreCmd = new SqlCommand(Restore, con);
                //   RestoreCmd.ExecuteNonQuery();

                //   string Alter2 = @"ALTER DATABASE [" + code + "] SET Multi_User";
                //   SqlCommand Alter2Cmd = new SqlCommand(Alter2, con);
                //   Alter2Cmd.ExecuteNonQuery();
                //   con.Close();
                string sqlConnectionString = @"Data Source=.;Initial Catalog=" + code + "; User ID=sa; Password=Test123;Integrated Security=True; ";
                //FileInfo file = new FileInfo("C:\\SQLQuery5.sql");//When Keep File In Local Drive
                FileInfo file = new FileInfo(Server.MapPath("~/script3.sql")); //When Keep File In Project Folder 
                string script = file.OpenText().ReadToEnd();
                SqlConnection conn = new SqlConnection(sqlConnectionString);
                Server server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(script);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }



    }
}