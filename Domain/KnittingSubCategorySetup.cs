﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public class KnittingSubCategory
    {
       public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public KnittingSubCategory(int id, int categoryId, string category, string subCategory)
        {
            Id = id;
            CategoryId = categoryId;
            Category = category;
            SubCategory = subCategory;
        }
    }
}
