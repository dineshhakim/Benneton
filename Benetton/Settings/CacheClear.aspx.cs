using System;
using System.Collections;

namespace Benetton.Settings
{
    public partial class CacheClear : System.Web.UI.Page
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

            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCacheKey.Text == "All")
                {
                    foreach (DictionaryEntry item in Cache)
                    {
                        Cache.Remove(item.Key.ToString());
                    }
                }
                else
                {
                    Cache.Remove(txtCacheKey.Text);

                }
                msgbox.ShowSuccess(txtCacheKey.Text + " Cache Cleared");
            }
            catch (Exception ex)
            {
                msgbox.ShowWarning(ex.Message);
            }
        }
        protected void btnUserList_Click(object sender, EventArgs e)
        {

        }
    }
}