using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class MaritalStatus
    {
        public int MaritalId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public MaritalStatus(int maritalId, string code, string name)
        {
            MaritalId = maritalId;
            Code = code;
            Name = name;
        }
    }
}
