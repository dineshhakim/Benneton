using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace Benetton.Common
{
    public partial class OrganizationList : System.Web.UI.Page
    {
        const string DESKey = "AQWSEDRF";
        const string DESIV = "HGFEDCBA";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillgvCompany();
            }
        }
        private void FillgvCompany()
        {
            DataTable dt = BL_CompanyInfoDrose.GetCompanyInfo(2, "", "", System.DateTime.Now);
            gvCompany.DataSource = dt;
            gvCompany.DataBind();
        }
        protected void gvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = BL_CompanyInfoDrose.GetCompanyInfo(2, "", "", System.DateTime.Now);
            gvCompany.DataSource = dt;

            gvCompany.PageIndex = e.NewPageIndex;
            gvCompany.DataBind();


        }

        protected void gvCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit1")
            {
                Response.Redirect(string.Format("~/Common/AddOrganization.aspx?Code={0}", e.CommandArgument.ToString()), false);
                //GetCompanyInfo(e.CommandArgument.ToString());
            }
            else if (e.CommandName == "View1")
            {
                GetCompanyInfo(e.CommandArgument.ToString());
                mpeDetails.Show();
            }

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
                Encoding encoding = Encoding.UTF8; return encoding.GetString(ms.ToArray());
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
            byte[] arrByte = new byte[arrChar.Length];
            for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
                arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);
            return arrByte;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FillgvCompanySearch();
        }
        private void FillgvCompanySearch()
        {
            DataTable dt = BL_CompanyInfoDrose.GetCompanyInfo(3, txtCompanyName.Text, txtCompanyCode.Text, System.DateTime.Now);
            gvCompany.DataSource = dt;
            gvCompany.DataBind();
        }
        private void GetCompanyInfo(string CompanyCode)
        {
            DataTable dt = BL_CompanyInfoDrose.GetCompanyInfo(1, "", CompanyCode, System.DateTime.Now);
            if (dt.Rows.Count > 0)
            {
                lblCode.Text = CompanyCode;
                lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                //txtRegistrationNo.Text = "";
                //txtRegistrationNo.Enabled = false;
                txtPanNo.Text = DESDecrypt(dt.Rows[0]["PanNo"].ToString());
                txtCountry.Text = DESDecrypt(dt.Rows[0]["Country"].ToString());
                txtState.Text = DESDecrypt(dt.Rows[0]["State"].ToString());
                txtCity.Text = DESDecrypt(dt.Rows[0]["City"].ToString());
                txtAddress1.Text = DESDecrypt(dt.Rows[0]["Adress1"].ToString());
                txtAddress2.Text = DESDecrypt(dt.Rows[0]["Adress2"].ToString());
                txtTelephoneNo.Text = DESDecrypt(dt.Rows[0]["TelephoneNo"].ToString());
                // DESDecrypt(dt.Rows[0]["Logo"].ToString());
                txtEmailAddress.Text = DESDecrypt(dt.Rows[0]["EmailAdress"].ToString());
                txtWebAddress.Text = DESDecrypt(dt.Rows[0]["WebAdress"].ToString());
                //DESDecrypt(dt.Rows[0]["C1"].ToString());
                //DESDecrypt(dt.Rows[0]["C2"].ToString());
                //  DESDecrypt(dt.Rows[0]["MC"].ToString());
                txtDate.Text = ConvertNE.ConvertEToNWithSlash(Convert.ToDateTime(DESDecrypt(dt.Rows[0]["Created_Date"].ToString())));

                // DESDecrypt(dt.Rows[0]["DATABASE_NAME"].ToString());

                //DESDecrypt(dt.Rows[0]["PWD"].ToString());
                txtImagesDrive.Text = dt.Rows[0]["IMAGES_DRIVE"].ToString();

                txtContactPersonName.Text = dt.Rows[0]["CONTACT_PERSON_NAME"].ToString();
                txtTelNo.Text = dt.Rows[0]["C_TEL_NO"].ToString();
                txtMobNo.Text = dt.Rows[0]["MOB_NO"].ToString();
                txtContactAddress.Text = dt.Rows[0]["C_ADDRESS"].ToString();
                txtEmailAdd.Text = dt.Rows[0]["EMAIL_ADDRESS"].ToString();
                txtNostroAcNCB.Text = dt.Rows[0]["NOSTRO_AC_NCB"].ToString();
                txtMirrorNCB.Text = dt.Rows[0]["MIRROR_AC_NCB"].ToString();
                txtMirrorNCB.Text = dt.Rows[0]["MIRROR_AC_DROSE"].ToString();




            }
        }

        protected void gvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (this.gvCompany.Rows.Count > 0)
            {
                gvCompany.UseAccessibleHeader = true;
                if (gvCompany.HeaderRow != null)
                {
                    //This will tell ASP.NET to render the <thead> for the header row 
                    //using instead of the simple <tr>
                    gvCompany.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvCompany.HeaderRow.CssClass = "header";
                }
                //  gvAircraft.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

      

    }
}