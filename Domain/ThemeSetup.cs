using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class ThemeSetup
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public ThemeSetup(int id, string category)
        {
            Id = id;
            Category = category;
        }

       
    }
}
