using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class EthnicGroup
    {
        public int CatId { get; set; }
        public string CategoryName { get; set; }
        public int ParentId { get; set; }
        public string Code { get; set; }

        public EthnicGroup(int catId,string categoryName,int parentId,string code)
        {
            CatId = catId;
            CategoryName = categoryName;
            ParentId = parentId;
            Code = code;
        }
    }
}
