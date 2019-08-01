using System;
using System.Collections.Generic;

namespace EfDemo.DataAccess.Entities
{
    public partial class EmpDetails
    {
        public int Edid { get; set; }
        public int EmpId { get; set; }
        public decimal Salary { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual Employee Ed { get; set; }
    }
}
