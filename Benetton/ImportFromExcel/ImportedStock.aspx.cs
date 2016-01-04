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
using System.Drawing;


namespace Benetton.ImportFromExcel
{
    public partial class ImportedStock : System.Web.UI.Page
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
            try
            {
                if (ddlSeason.SelectedValue == "0")
                {
                    _msgbox.ShowWarning("Please Select Season!!");
                    return;
                }
                var dtExcel = new DataTable("ImportExcel");
                dtExcel.Columns.Add("Date");
                dtExcel.Columns.Add("DocNo");
                dtExcel.Columns.Add("Customer_x0020_Name");
                dtExcel.Columns.Add("Stock_x0020_No");
                dtExcel.Columns.Add("Gender");
                dtExcel.Columns.Add("Category");
                dtExcel.Columns.Add("Item_x0020_Descr");
                dtExcel.Columns.Add("Style");
                dtExcel.Columns.Add("Color");
                dtExcel.Columns.Add("Size");
                dtExcel.Columns.Add("Qty");
                dtExcel.Columns.Add("Item_x0020_Rate");
                dtExcel.Columns.Add("MRP_x0020_INR");
                dtExcel.Columns.Add("MRP_x0020_NPR");
                dtExcel.Columns.Add("AccountMRP");
                dtExcel.Columns.Add("SalesMRP");
                var httpPostedFile = impImage.PostedFile;
                if (httpPostedFile != null && httpPostedFile.ContentLength > 0)
                {
                    var postedFile = impImage.PostedFile;
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
                                                        ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=0\"";
                            }
                            //Create Connection to Excel work book and add oledb namespace
                            var excelConnection = new OleDbConnection(excelConnectionString);
                            excelConnection.Open();
                            var dt = new DataTable();

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


                            var query = string.Format("Select * from [{0}]", excelSheets[0]);
                            //string.Format("Select [Date],DocNo,Customer Name as CustomerName,Stock No as StockNo,Gender,Category,Item Descr as ItemDescr,Style,Color,Size,Qty,Item Rate as ItemRate,MRP INR as MRPINR,MRP NPR as MRPNPR from [{0}]", excelSheets[0]);
                            using (var dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                            {
                                dataAdapter.Fill(dtExcel);
                            }
                        }
                    }
                    if (!ValidateExcel(dtExcel))
                    {
                        _msgbox.ShowWarning("Excel columns doesn't match required.Please browse valid excel sheet!!");
                        return;
                    }

                    if (dtExcel.Rows.Count > 0)
                    {
                        var sw = new StringWriter();
                        dtExcel.WriteXml(sw);
                        var obj = new ImportExcel();
                        obj.ExcelData = sw.ToString();
                        obj.CreatedBy = BK_Session.GetSession().UserId;
                        obj.BranchId = int.Parse(ddlBranch.SelectedValue);
                        obj.ImportedDate = BK_Session.GetSession().OpDate;
                        obj.InvoiceNo = txtInvoiceNo.Text;
                        obj.AirwayBillNo = txtAirwayBillNo.Text;
                        obj.Season = int.Parse(ddlSeason.SelectedValue);
                        var id = 0;
                        var msg = BllImportExcel.InsUpdDelExcelImport('I', obj, out id);
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
                else
                {
                    _msgbox.ShowWarning("Please browse data first!!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        public bool ValidateExcel(DataTable dtExcel)
        {
            var exists = false;
            var neededColumnNames = new string[22];
            neededColumnNames[0] = "Date";
            neededColumnNames[1] = "DocNo";
            neededColumnNames[2] = "Customer_x0020_Name";
            neededColumnNames[3] = "Stock_x0020_No";
            neededColumnNames[4] = "Gender";
            neededColumnNames[5] = "Category";
            neededColumnNames[6] = "Item_x0020_Descr";
            neededColumnNames[7] = "Style";
            neededColumnNames[8] = "Color";
            neededColumnNames[9] = "Size";
            neededColumnNames[10] = "Qty";
            neededColumnNames[11] = "Item_x0020_Rate";
            neededColumnNames[12] = "AccountMRP";
            neededColumnNames[13] = "SalesMRP";
            neededColumnNames[14] = "MRP_x0020_NPR";
            neededColumnNames[15] = "MRP_x0020_INR";
            neededColumnNames[16] = "Customer Name";
            neededColumnNames[17] = "Stock No";
            neededColumnNames[18] = "Item Descr";
            neededColumnNames[19] = "Item Rate";
            neededColumnNames[20] = "MRP INR";
            neededColumnNames[21] = "MRP NPR";

            //Comparing the Imported Excel Column With Database Table Column
            foreach (DataColumn column in dtExcel.Columns)
            {
                var clnameExcel = column.ColumnName;
                if (clnameExcel != "")
                {
                    for (int i = 0; i < neededColumnNames.Length; i++)
                    {
                        if (clnameExcel == neededColumnNames[i])
                        {
                            exists = true;
                            break;
                        }
                        else
                        {
                            exists = false;
                        }
                    }
                }
            }

            return exists;
        }



        protected void lnkDownload_OnClick(object sender, EventArgs e)
        {
            var file = new FileInfo(Server.MapPath("~/Download Files/Received invoice.xlsx"));
            if (file.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=" + "ImportFormat.xlsx");
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