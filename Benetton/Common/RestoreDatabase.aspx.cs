using System;
using System.Data;
using BusinessLogic;

namespace Benetton.Common
{
    public partial class RestoreDatabase : System.Web.UI.Page
    {
        ProudMonkey.Common.Controls.MessageBox msgbox;
        protected void Page_Init(object sender, EventArgs e)
        {
            msgbox = new ProudMonkey.Common.Controls.MessageBox()
            {

            };
            this.pnlMsgBox.Controls.Clear();
            this.pnlMsgBox.Controls.Add(msgbox);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDatabase.Focus();
                // LoadDatabase();
            }
        }


        protected void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = RestoreDatabaseService.RestoreDatabase(2, txtFileName.Text, txtDatabase.Text);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Msg"].ToString() == "Database Restored Sucessfully To Database:")
                    {
                        msgbox.ShowSuccess("Database Restored Sucessfully To Database: " + fuDatabase.FileName);
                    }
                    else
                    {
                        msgbox.ShowWarning(dt.Rows[0]["Msg"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                msgbox.ShowWarning(ex.Message);
            }
        }

        //public void LoadDatabase()
        //{

        //}
    }
}