using System;
using System.Collections.Generic;

namespace PizzaProject.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Pizza = new HashSet<Pizza>();
            UserOpportunities = new HashSet<UserOpportunities>();
        }

        public int IdOrder { get; set; }
        public string NameOrder { get; set; }
        public string Lokalizacja { get; set; }
        public string Promocje { get; set; }
        public string StatusOrder { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
        public virtual ICollection<UserOpportunities> UserOpportunities { get; set; }
    }
}
