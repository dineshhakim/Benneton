using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessLogic;
using ProudMonkey.Common.Controls;

namespace Benetton.Menu
{
    public partial class MainMenuSetup : System.Web.UI.Page
    {
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
                if (!IsPostBack)
                {
                    FillgvMenu();
                    btnMenu.Attributes.Add("onclick", "return confirm('Confirm To Save');");
                }
            }
        }
        private void FillgvMenu()
        {
            var dt = new DataTable();
            dt = BL_MainMenu.GetMainMenu(1, 0, "");
            if (dt.Rows.Count > 0)
            {
                gvMenu.DataSource = dt;
                gvMenu.DataBind();
            }
            else
            {
                gvMenu.DataSource = new string[] { };
                gvMenu.DataBind();
            }
        }
        private void InsupdDeleteMenu(char Event, int Id)
        {
            var obj = new BL_MainMenu();
            Session["UserId"] = 0;
            if (txtOrder.Text != "")
            {
                obj.Odr = Convert.ToInt32((string) txtOrder.Text);
            }
            if (Event == 'D')
            {
                obj.EVENT = Event;
                obj.MainMenuID = Id;

                var msg = "";
                msg = obj.InsUpdDeleteMainMenu(out Id);
                if (msg == "Record Deleted Successfully")
                {
                    msgbox.ShowSuccess(msg);

                }
                else
                {
                    msgbox.ShowWarning(msg);
                }
            }
            else if (CheckValidFile())
            {
                if (Event == 'I')
                {

                    obj.EVENT = Event;
                    obj.MainMenuID = 0;
                    obj.MenuName = txtMenuName.Text;
                    obj.ImageURL = fuImage.PostedFile.FileName;
                    if ((fuImage.PostedFile != null) && (fuImage.PostedFile.ContentLength > 0))
                    {
                        var fn = System.IO.Path.GetFileName(fuImage.PostedFile.FileName);
                        var SaveLocation = Server.MapPath("~/Images") + "\\" + fn;
                        obj.ImageURL = "~/Images/" + fn;
                        try
                        {
                            fuImage.PostedFile.SaveAs(SaveLocation);

                        }
                        catch (Exception ex)
                        {
                            msgbox.ShowWarning("Error: " + ex.Message);
                            //Note: Exception.Message returns a detailed message that describes the current exception. 
                            //For security reasons, we do not recommend that you return Exception.Message to end users in 
                            //production environments. It would be better to put a generic error message. 
                        }
                    }

                    Id = 0;
                    var msg = "";
                    msg = obj.InsUpdDeleteMainMenu(out Id);
                    if (msg == "Record Inserted Successfully")
                    {
                        msgbox.ShowSuccess(msg);
                    }
                    else
                    {
                        msgbox.ShowWarning(msg);
                    }

                }
                else if (Event == 'U')
                {
                    obj.EVENT = Event;
                    obj.MainMenuID = Id;
                    obj.MenuName = txtMenuName.Text;
                    if ((fuImage.PostedFile != null) && (fuImage.PostedFile.ContentLength > 0))
                    {
                        var fn = System.IO.Path.GetFileName(fuImage.PostedFile.FileName);
                        var SaveLocation = Server.MapPath("~/Images") + "\\" + fn;
                        obj.ImageURL = "~/Images/" + fn;
                        try
                        {
                            fuImage.PostedFile.SaveAs(SaveLocation);
                            Response.Write("The file has been uploaded.");
                        }
                        catch (Exception ex)
                        {
                            Response.Write("Error: " + ex.Message);
                            //Note: Exception.Message returns a detailed message that describes the current exception. 
                            //For security reasons, we do not recommend that you return Exception.Message to end users in 
                            //production environments. It would be better to put a generic error message. 
                        }
                    }



                    var msg = "";
                    msg = obj.InsUpdDeleteMainMenu(out Id);
                    if (msg == "Record Updated Successfully")
                    {
                        msgbox.ShowSuccess(msg);

                    }
                    else
                    {
                        msgbox.ShowWarning(msg);
                    }
                }


            }
            btnMenu.Text = "Save";
            btnMenu.CommandName = "Save";
            txtMenuName.Text = "";
            FillgvMenu();
        }

        private bool CheckValidFile()
        {
            if ((fuImage.PostedFile != null) && (fuImage.PostedFile.ContentLength > 0))
            {
                string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg" };
                var ext = System.IO.Path.GetExtension(fuImage.PostedFile.FileName);
                var isValidFile = false;
                for (var i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }
                if (!isValidFile)
                {
                    var msg = "Invalid File. Please upload a File with extension " + string.Join(",", validFileTypes);
                    msgbox.ShowError(msg);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            if (btnMenu.CommandName == "Save")
            {
                InsupdDeleteMenu('I', 0);
            }
            else
            {
                InsupdDeleteMenu('U', Convert.ToInt32((string) btnMenu.CommandArgument));
            }

            FillgvMenu();
        }
        protected void gvMenu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var btnLogo = (ImageButton)e.Row.FindControl("btnLogo");
                var lblImageUrl = (Label)e.Row.FindControl("lblImageUrl");
                if (lblImageUrl.Text != "")
                {
                    btnLogo.ImageUrl = ResolveUrl(lblImageUrl.Text);
                }

            }
        }
        protected void gvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit1")
            {
                var index = Convert.ToInt32(e.CommandArgument);
                // Retrieve the row that contains the button clicked 
                // by the user from the Rows collection.      
                var row = gvMenu.Rows[index];
                var lblId = (Label)row.FindControl("lblId");
                var lblMenuName = (Label)row.FindControl("lblMenuName");
                var lblImageUrl = (Label)row.FindControl("lblImageUrl");
                var lblOrder = (Label)row.FindControl("lblOrder");
                txtMenuName.Text = lblMenuName.Text;
                btnMenu.Text = "Update";
                btnMenu.CommandName = "Update";
                btnMenu.CommandArgument = lblId.Text;

            }
            else if (e.CommandName == "Delete1")
            {
                InsupdDeleteMenu('D', Convert.ToInt32(e.CommandArgument));
            }
        }
    }
}