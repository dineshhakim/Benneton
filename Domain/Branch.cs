using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Branch
    {


        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string TelNo { get; set; }
        public string ContactPersonName { get; set; }
        public DateTime OperationStartDate { get; set; }
        public bool IsMain { get; set; }


        public Branch(int branchId, string branchName, string branchCode, string address, string emailId, string telNo, string contactPersonName, DateTime operationStartDate, bool isMain)
        {
            BranchId = branchId;
            BranchName = branchName;
            BranchCode = branchCode;
            Address = address;
            EmailId = emailId;
            TelNo = telNo;
            ContactPersonName = contactPersonName;
            OperationStartDate = operationStartDate;
            IsMain = isMain;
        }

    }
}
