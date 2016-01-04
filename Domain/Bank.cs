using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Bank
    {
        public int BankDescId { get; set; }
        public string BankDescName { get; set; }
        public string BankDescAccountNo { get; set; }
        public float TranDpstAmt { get; set; }
        public float TranWtdAmt { get; set; }
        public DateTime OpeningDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AccountType { get; set; }
        public string ClassType { get; set; }
        public int BranchId { get; set; }
        public decimal Rate { get; set; }
        public int CalMethod { get; set; }
        public int AccumulationType { get; set; }
        public DateTime MaturityDate { get; set; }
        public bool CashBank { get; set; }
        public int BankId { get; set; }
        public string InterestAccumulationAc { get; set; }

        public Bank(int bankDescId, string bankDescName, string bankDescAccountNo,
            float tranDpstAmt, float tranWtdAmt, DateTime openingDate, int createdBy,
            DateTime createdDate, int modifiedBy, DateTime modifiedDate, string accountType,
            string classType, int branchId, decimal rate, int calMethod, int accumulationType, DateTime maturityDate,
            bool cashBank, int bankId, string interestAccumulationAc)
        {
            BankDescId = bankDescId;
            BankDescName = bankDescName;
            BankDescAccountNo = bankDescAccountNo;
            TranDpstAmt = tranDpstAmt;
            TranWtdAmt = tranWtdAmt;
            OpeningDate = openingDate;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            ModifiedBy = modifiedBy;
            ModifiedDate = modifiedDate;
            AccountType = accountType;
            ClassType = classType;
            BranchId = branchId;
            Rate = rate;
            CalMethod = calMethod;
            AccumulationType = accumulationType;
            MaturityDate = maturityDate;
            CashBank = cashBank;
            BankId = bankId;
            InterestAccumulationAc = interestAccumulationAc;
        }

    }
}
