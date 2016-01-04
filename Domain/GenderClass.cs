using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public class GenderClass
    {
       public int Id { get; set; }
       public string Gender { get; set; }

       public GenderClass(int id, string gender)
       {
           Id = id;
           Gender = gender;
       }
    }
}
