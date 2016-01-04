using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
  public  class FiscalYear
    {

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrent { get; set; }

        public FiscalYear(int id, DateTime startdate, DateTime enddate, bool iscurrent)
        {
            Id = id;
            StartDate = startdate;
            EndDate = enddate;
            IsCurrent = IsCurrent;
        }
    }
}
