using System;
using System.Collections.Generic;

namespace EfDemo.DataAccess.Entities
{
    public partial class Type
    {
        public Type()
        {
            Pokemon = new HashSet<Pokemon>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Inital { get; set; }

        public virtual ICollection<Pokemon> Pokemon { get; set; }
    }
}
