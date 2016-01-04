using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public Department(int deptId, string deptName)
        {
            DeptId = deptId;
            DeptName = deptName;
        }
    }
}
