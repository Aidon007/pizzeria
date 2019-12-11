using System;
using System.Collections.Generic;

namespace PizzaProject.Models
{
    public partial class PizzaComponent
    {
        public int ComponentsIdComponent { get; set; }
        public int PizzaIdPizza { get; set; }

        public virtual Components ComponentsIdComponentNavigation { get; set; }
        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
    }
}
