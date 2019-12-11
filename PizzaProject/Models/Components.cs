using System;
using System.Collections.Generic;

namespace PizzaProject.Models
{
    public partial class Components
    {
        public Components()
        {
            PizzaComponent = new HashSet<PizzaComponent>();
        }

        public int IdComponent { get; set; }
        public string NameComponent { get; set; }

        public virtual ICollection<PizzaComponent> PizzaComponent { get; set; }
    }
}
