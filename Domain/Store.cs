using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Store
    {
        public int Id { get; set; }
        public int StoreNo { get; set; }
        public string StoreName { get; set; }
        public Store(int id, int storeNo, string storeName)
        {
            Id = id;
            StoreNo = storeNo;
            StoreName = storeName;
        }
    }
}
