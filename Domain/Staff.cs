using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Staff
    {
        public int StaffId { get; set; } 
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public string StaffName { get; set; }
        public int DesignationId { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int QualificationId { get; set; }
        public string Remarks { get; set; }
        public bool  Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public int GenderId { get; set; }
        public DateTime JobStartedDate { get; set; }
        public int TitleId { get; set; }
        public DateTime JobLastDate { get; set; }
        public DateTime BranchTransferDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CitizenNo { get; set; }
        public string PassportNo { get; set; }
        public int DepartmentId { get; set; }
        public int MarriedId { get; set; }
        public int ServiceId { get; set; }
        public int EthinicityId { get; set; }

        public Staff(int staffId, int userId, int branchId, string staffName, int designationId, string address,
            string contactNo, string email, int qualificationId, string remarks, bool active, DateTime createdDate,
            int genderId,
            DateTime jobStartedDate, int titleId, DateTime jobLastDate, DateTime branchTransferDate,
            DateTime dateOfBirth, string citizenNo,
            string passportNo, int departmentId, int marriedId, int serviceId, int ethinicityId)
        {
            StaffId = staffId;
            UserId = userId;
            BranchId = branchId;
            StaffName = staffName;
            DesignationId = designationId;
            Address = address;
            ContactNo = contactNo;
            Email = email;
            QualificationId = qualificationId;
            Remarks = remarks;
            Active = active;
            CreatedDate = createdDate;
            GenderId = genderId;
            JobStartedDate = jobStartedDate;
            TitleId = titleId;
            JobLastDate = jobLastDate;
            BranchTransferDate = branchTransferDate;
            DateOfBirth = dateOfBirth;
            CitizenNo = citizenNo;
            PassportNo = passportNo;
            DepartmentId = departmentId;
            MarriedId = marriedId;
            ServiceId = serviceId;
            EthinicityId = ethinicityId;
        }
    }
}
