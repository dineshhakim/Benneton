using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public class ServiceType
    {
       public int Id { get; set; }
       public string ServiceName { get; set; }

       public ServiceType(int id, string serviceName)
       {
           Id = id;
           ServiceName = serviceName;
       }
    }
}
