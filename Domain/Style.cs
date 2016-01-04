using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public class StyleClass
    {
        public int Id { get; set; }
        public string Style { get; set; }
        public string Description { get; set; }
        public StyleClass(int id, string style, string description)
        {
            Id = id;
            Style = style;
            Description = description;
        }
    }
}
