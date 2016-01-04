using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public class SizeClass
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public SizeClass(int id, string size)
        {
            Id = id;
            Size = size;
        }
    }
}
