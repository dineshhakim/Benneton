using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public class Designation
    {
       public int DId { get; set; }
       public string DesignationName { get; set; }

       public Designation(int dId, string designationName)
       {
           DId = dId;
           DesignationName = designationName;
       }
    }
}
