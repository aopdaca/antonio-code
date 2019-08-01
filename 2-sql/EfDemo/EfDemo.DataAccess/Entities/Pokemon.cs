using System;
using System.Collections.Generic;

namespace EfDemo.DataAccess.Entities
{
    public partial class Pokemon
    {
        public Pokemon()
        {
            InverseEvolution = new HashSet<Pokemon>();
        }

        public int PokemonId { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int Height { get; set; }
        public int? EvolutionId { get; set; }
        public DateTime DateModified { get; set; }
        public bool? Active { get; set; }

        public virtual Pokemon Evolution { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<Pokemon> InverseEvolution { get; set; }
    }
}
