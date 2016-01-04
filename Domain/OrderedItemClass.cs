using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class OrderedItemClass
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string DocNo { get; set; }
        public string CustomerName { get; set; }
        public string StockNo { get; set; }
        public int GenderId { get; set; }
        public int KnittingCategoryId { get; set; }
        public string ItemDescr { get; set; }
        public int StyleId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int Qty { get; set; }
        public float ItemRate { get; set; }
        public float MrpInr { get; set; }
        public float MrpNpr { get; set; }

        public OrderedItemClass(int id, DateTime date, string docNo, string customerName, string stockNo, int genderId,
            int knittingCategoryId, string itemDescr, int styleId, int colorId, int sizeId, int qty, float itemRate,
            float mrpInr, float mrpNpr)
        {
            Id = id;
            Date = date;
            DocNo = docNo;
            CustomerName = customerName;
            StockNo = stockNo;
            GenderId = genderId;
            KnittingCategoryId = knittingCategoryId;
            ItemDescr = itemDescr;
            StyleId = styleId;
            ColorId = colorId;
            SizeId = sizeId;
            Qty = qty;
            ItemRate = itemRate;
            MrpInr = mrpInr;
            MrpNpr = mrpNpr;

        }
    }
}
