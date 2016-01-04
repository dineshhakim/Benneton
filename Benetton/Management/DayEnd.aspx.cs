using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Benetton.Classes;
using ProudMonkey.Common.Controls;

namespace Benetton.Management
{
    public partial class DayEnd : System.Web.UI.Page
    {
        public MessageBox Msgbox;

        protected void Page_Init(object sender, EventArgs e)
        {
            Msgbox = new MessageBox();
            pnlMsgBox.Controls.Clear();
            pnlMsgBox.Controls.Add(Msgbox);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dt = GetClosedDate();
                if (dt != DateTime.Parse("1/1/0001"))
                {
                    lbltextclosed.Text = "Day Closed Till";
                    lblclosedate.Text = ConvertNE.ConvertEToNWithSlash(dt);
                }
                else
                {
                    lbltextclosed.Text = "Day Not Closed Yet";
                    lblclosedate.Text = "";
                }
            }
        }

        protected void clrSession_Click(object sender, EventArgs e)
        {
            SessionHelper.ClearSessionOfOtherUserInBranch(BK_Session.GetSession().BranchId, BK_Session.GetSession().UserId);
            btnSubmit.Enabled = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertDayCloseLog();
            btnSubmit.Enabled = false;
            Response.Redirect("~/Login.aspx");
        }
        public DateTime GetClosedDate()
        {
            var dt = new DateTime();
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSCommonDB"].ToString());
            conn.Open();
            var cmd1 = new SqlCommand("Select top(1) Date from tbl_DayCloseLog where DayClose = 1 and branchId=" + BK_Session.GetSession().BranchId + " order by Date desc", conn);
            cmd1.CommandType = CommandType.Text;
            var adr = cmd1.ExecuteReader();
            while (adr.Read())
            {
                dt = DateTime.Parse(adr[0].ToString());
            }
            conn.Close();
            return dt;
        }
        public void InsertDayCloseLog()
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedBytes = null;
            var encoder = new UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(BK_Session.GetSession().OpDate.ToLongDateString()));
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSCommonDB"].ToString());
            try
            {
                conn.Open();
                var cmd1 = new SqlCommand("InsertDayCloseLog", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@CreatedBy", int.Parse(BK_Session.GetSession().UserId.ToString()));
                cmd1.Parameters.AddWithValue("@Hvalue", hashedBytes);
                cmd1.Parameters.AddWithValue("@flag", 1);
                cmd1.Parameters.AddWithValue("@Branch_Id", BK_Session.GetSession().BranchId);
                cmd1.Parameters.AddWithValue("@Date", BK_Session.GetSession().OpDate);
                cmd1.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}