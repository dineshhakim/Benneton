using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class AcedamicQualification
    {
        public int Id { get; set; }
        public string Qualification { get; set; }

        public AcedamicQualification(int id,string qualification)
        {
            Id = id;
            Qualification = qualification;
        }
    }
}
