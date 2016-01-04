using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class ImportExcel
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
    }
}
