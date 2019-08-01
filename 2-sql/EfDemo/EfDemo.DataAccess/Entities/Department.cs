using System;
using System.Collections.Generic;

namespace EfDemo.DataAccess.Entities
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public int DeptId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
