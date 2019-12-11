using System;
using System.Collections.Generic;

namespace PizzaProject.Models
{
    public partial class UserOpportunities
    {
        public int UserIdUser { get; set; }
        public int PizzaCafeIdPizzaCafe { get; set; }
        public int OrderIdOrder { get; set; }

        public virtual Orders OrderIdOrderNavigation { get; set; }
        public virtual PizzaCafe PizzaCafeIdPizzaCafeNavigation { get; set; }
        public virtual UserCafe UserIdUserNavigation { get; set; }
    }
}
