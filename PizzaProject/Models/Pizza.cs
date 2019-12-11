using System;
using System.Collections.Generic;

namespace PizzaProject.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaComponent = new HashSet<PizzaComponent>();
        }

        public int IdPizza { get; set; }
        public string NamePizza { get; set; }
        public int OrderIdOrder { get; set; }

        public virtual Orders OrderIdOrderNavigation { get; set; }
        public virtual ICollection<PizzaComponent> PizzaComponent { get; set; }
    }
}
