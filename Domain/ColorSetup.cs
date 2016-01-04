using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
  public  class Color
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int StyleId { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public Color(int id, int categoryId, int styleId, string colorCode, string colorName)
        {
            Id = id;
            CategoryId = categoryId;
            StyleId = styleId;
            ColorCode = colorCode;
            ColorName = colorName;
            
        }
    }
}
