using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Benetton.Classes;
using BusinessLogic;
using Domain;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.OleDb;
using ProudMonkey.Common.Controls;
using DataTable = System.Data.DataTable;

namespace Benetton.ImportFromExcel
{
    public partial class OrderedItem : System.Web.UI.Page
    {

        private MessageBox _msgbox;

        protected void Page_Init(object sender, EventArgs e)
        {
            _msgbox = new MessageBox()
            {
            };

            this.pnlMsgBox.Controls.Clear();
            this.pnlMsgBox.Controls.Add(_msgbox);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDdlBranch();
                FillDdlSeason();
                ddlBranch.SelectedValue = BK_Session.GetSession().BranchId.ToString();
                ddlBranch.Enabled = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var dtExcel = new DataTable("OrderedExcel");
            dtExcel.Columns.Add("Store_x0020_No");
            var httpPostedFile = ordImage.PostedFile;
            if (httpPostedFile != null && httpPostedFile.ContentLength > 0)
            {
                var postedFile = ordImage.PostedFile;
               
                if (postedFile != null)
                {
                    var fileExtension =
                        System.IO.Path.GetExtension(postedFile.FileName);

                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        var fileLocation = Server.MapPath("~/Content/") + postedFile.FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {
                            System.IO.File.Delete(fileLocation);
                        }
                        postedFile.SaveAs(fileLocation);
                        var excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                                    fileLocation +
                                                    ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=0\"";
                        //connection String for xls file format.
                        if (fileExtension == ".xls")
                        {
                            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                                    fileLocation +
                                                    ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=0\"";
                        }
                        //connection String for xlsx file format.
                        else if (fileExtension == ".xlsx")
                        {
                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                                    fileLocation +
                                                    ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
                        }
                        //Create Connection to Excel work book and add oledb namespace
                        var excelConnection = new OleDbConnection(excelConnectionString);
                        excelConnection.Open();
                        var dt = new DataTable();
                        
                      //  var format=excelConnection.GetOleDbSchemaTable()
                       
                        dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                       
                        if (dt == null)
                        {
                            return;
                        }

                        var excelSheets = new String[dt.Rows.Count];
                        
                        var t = 0;
                        //excel data saves in temp file here.
                        foreach (DataRow row in dt.Rows)
                        {
                            excelSheets[t] = row["TABLE_NAME"].ToString();
                            t++;
                        }
                        var excelConnection1 = new OleDbConnection(excelConnectionString);
                       
                        //excelSheets[0]
                        var query = string.Format("Select * from [{0}]", excelSheets[0]);
                       
                       // excelSheets.Range["D5"].Text = sheet.Range["C5"].Formula;
                        //string.Format("Select [Date],DocNo,Customer Name as CustomerName,Stock No as StockNo,Gender,Category,Item Descr as ItemDescr,Style,Color,Size,Qty,Item Rate as ItemRate,MRP INR as MRPINR,MRP NPR as MRPNPR from [{0}]", excelSheets[0]);
                        using (var dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                        {
                            dataAdapter.Fill(dtExcel);
                        }
                    }
                }

                if (dtExcel.Rows.Count > 0)
                {
                    var sw = new StringWriter();
                    dtExcel.WriteXml(sw);
                    var obj = new ImportExcel();
                    obj.ExcelData = sw.ToString();
                    obj.CreatedBy = BK_Session.GetSession().UserId;
                    obj.BranchId = BK_Session.GetSession().BranchId;
                    obj.OrderedDate = BK_Session.GetSession().OpDate;
                    obj.Season = int.Parse(ddlSeason.SelectedValue);
                    int id = 0;
                    var msg = BL_OrderedExcel.InsUpdDelExcelOrder('I', obj, out id);
                    if (msg == "Data Imported Successfully")
                    {
                        _msgbox.ShowSuccess(msg);
                    }
                    else
                    {
                        _msgbox.ShowWarning(msg);
                    }
                }
                else
                {
                    _msgbox.ShowWarning("Please browse excel sheet having data!!");
                }
            }
        }

        public void FillDdlBranch()
        {
            BL_FillDropDown.FillddlBranch(ddlBranch, 1, 0, "", "");
        }
        public void FillDdlSeason()
        {
            BL_FillDropDown.FillDdlSeason(ddlSeason);
        }
        protected void lnkDownload_OnClick(object sender, EventArgs e)
        {
            var file = new FileInfo(Server.MapPath("~/Download Files/Pre-Order Sheet.xlsx"));
            if (file.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=" + "PreOrderFormat.xlsx");
                Response.ContentType = "application/vnd.xls";
                Response.TransmitFile(file.FullName);
                Response.End();
            }
            else
            {
                _msgbox.ShowWarning("File doesnot exist!!");
            }
            //Response.AppendHeader("Content-Disposition", "attachment; filename=Import Format.xlsx");
            //Response.AddHeader("Content-Type", "application/Excel");
            //Response.ContentType = "application/vnd.xls";
            //Response.TransmitFile(Server.MapPath("~/Download Files/Received invoice.xlsx"));
            //Response.End();
        }
    }
}