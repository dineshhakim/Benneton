using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class DayClose
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Createdby { get; set; }
        public DateTime Createddate { get; set; }
        public int Branchid { get; set; }
        public bool Dayclose { get; set; }
        public string HValue { get; set; }
        public bool Verified { get; set; }
        public bool Status { get; set; }

        public DayClose(int id, DateTime date, int createdby, DateTime createddate, int branchid, bool dayclose,
            string hvalue, bool verified, bool status)
        {
            ID = id;
            Date = date;
            Createdby = createdby;
            Createddate = createddate;
            Branchid = branchid;
            Dayclose = dayclose;
            HValue = hvalue;
            Verified = verified;
            Status = status;
        }
    }
}
