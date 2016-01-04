using System;
using System.Data;
using Benetton.Classes;
using BusinessLogic;
using ProudMonkey.Common.Controls;

namespace Benetton
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        ProudMonkey.Common.Controls.MessageBox msgbox;

        protected void Page_Init(object sender, EventArgs e)
        {
            Page.Header.DataBind();
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
                btnSave.Enabled = false;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewPwd.Text == "")
            {
                txtNewPwd.Focus();
                return;
            }

            if (txtConfirmPwd.Text == txtNewPwd.Text)
            {
                BL_Users obj = new BL_Users();
                obj.USER_NAME = "";
                obj.ID = Convert.ToInt32(Session["UserId"]);
                obj.REGISTERED_DATE = System.DateTime.Now;
                obj.PWD = EncryptDecrypt.base64Encode(txtConfirmPwd.Text);
                obj.EVENT = 'C';
                int Id = 0;
                string msg = "";
                msg = obj.InsUpdDeleteUsers(out Id);
                if (msg == "Password Changed Successfully")
                {
                    msgbox.ShowSuccess(msg);
                    txtNewPwd.Text = "";
                    txtConfirmPwd.Text = "";
                    txtCurrentPwd.Text = "";
                }
                else
                {
                    msgbox.ShowWarning(msg);
                }
            }

        }
        protected void txtCurrentPwd_TextChanged(object sender, EventArgs e)
        {
            if (txtCurrentPwd.Text != "")
            {
                DataTable dt = BL_Users.GetUsers(3, 0, Session["UserId"].ToString());
                if (dt.Rows.Count > 0)
                {
                    if (EncryptDecrypt.base64Encode(txtCurrentPwd.Text) != dt.Rows[0]["PWD"].ToString())
                    {
                        msgbox.ShowWarning("Current Password didnot Match");
                        btnSave.Enabled = false;
                        txtNewPwd.Focus();
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        txtNewPwd.Focus();
                    }
                }
            }
        }
    }
}