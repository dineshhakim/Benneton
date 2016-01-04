using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class ProductStockIn
    {
         public int BranchId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ImportedDate { get; set; }
        public string ExcelData { get; set; }
        public string InvoiceNo { get; set; }
        public string AirwayBillNo { get; set; }
        public int Season { get; set; }
        public DateTime OrderedDate { get; set; }
        public int OrderId { get; set; }

        public ProductStockIn(int branchId, int createdBy, DateTime importedDate, string excelData, string invoiceNo,
            string airwayBillNo, int season, DateTime orderedDate, int orderedId)
        {
            BranchId = branchId;
            CreatedBy = createdBy;
            ImportedDate = importedDate;
            ExcelData = excelData;
            InvoiceNo = invoiceNo;
            AirwayBillNo = airwayBillNo;
            Season = season;
            OrderedDate = orderedDate;
            OrderId = orderedId;
        }
    }
}
