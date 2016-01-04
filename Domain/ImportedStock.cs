using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace Domain
{
    public class ImportedStockClass
    {

        public DateTime Date { get; set; }
        public string DocNo { get; set; }
        public string CustomerName { get; set; }
        public int StockNo { get; set; }
        public string Gender { get; set; }
        public string Category { get; set; }
        public string ItemDescription { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Qty { get; set; }
        public float ItemRate { get; set; }
        public float MrpInr { get; set; }
        public float MrpNpr { get; set; }
        public ImportedStockClass(DateTime date, string docNo, string customerName, int stockNo, string gender, string category, string itemDescription, string style, string color,string size,int qty,float itemRate,float mrpInr,float mrpNpr)
        {
            Date = date;
            DocNo = docNo;
            CustomerName = customerName;
            StockNo = stockNo;
            Gender = gender;
            Category = category;
            ItemDescription = itemDescription;
            Style = style;
            Color = color;
            Size = size;
            Qty = qty;
            ItemRate = itemRate;
            MrpInr = mrpInr;
            MrpNpr = mrpNpr;
        }
    }
}
