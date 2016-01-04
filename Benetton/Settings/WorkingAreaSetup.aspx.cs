using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ProudMonkey.Common.Controls;

namespace Benetton.Settings
{
    public partial class WorkingAreaSetup : System.Web.UI.Page
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
                FillddlZone();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSCommonDB"].ToString());
            conn.Open();
            var cmd = new SqlCommand("Insert into tbl_WorkingArea(Zone,District, MPC, VDC) values('" + ddlPermanentZone.SelectedItem.Text + "','" + txtDistrict.Text + "','" + txtMPC.Text + "','" + txtVDC.Text + "')", conn);

            try
            {
                using (conn)
                    cmd.ExecuteNonQuery();
                msgbox.ShowSuccess("Successfully Inserted");
                gvWArea.DataBind();
                txtDistrict.Text = "";
            }
            catch (Exception)
            {
                msgbox.ShowSuccess("Enter Correct Information");
            }
        }
        protected void gvWArea_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvWArea.PageIndex = e.NewPageIndex;
            gvWArea.DataBind();

        }
        private void FillddlZone()
        {
            var dt = new DataTable();
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSCommonDB"].ToString());
            conn.Open();
            var cmd = new SqlCommand("select  distinct Zone from tbl_WorkingArea order by Zone", conn);
            cmd.CommandType = CommandType.Text;
            var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            ddlPermanentZone.Items.Clear();
            ddlPermanentZone.DataSource = dt;
            ddlPermanentZone.DataValueField = "Zone";
            ddlPermanentZone.DataTextField = "Zone";
            ddlPermanentZone.DataBind();
        }
    }
}