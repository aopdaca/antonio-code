using System;
using System.Collections.Generic;

namespace EfDemo.DataAccess.Entities
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Ssn { get; set; }
        public int DeptId { get; set; }

        public virtual Department Dept { get; set; }
        public virtual EmpDetails EmpDetails { get; set; }
    }
}
