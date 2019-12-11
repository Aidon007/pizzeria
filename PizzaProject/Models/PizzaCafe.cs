using System;
using System.Collections.Generic;

namespace PizzaProject.Models
{
    public partial class PizzaCafe
    {
        public PizzaCafe()
        {
            UserCafe = new HashSet<UserCafe>();
            UserOpportunities = new HashSet<UserOpportunities>();
        }

        public int IdPizzaCafe { get; set; }
        public string NameCafe { get; set; }
        public string NumerKonta { get; set; }

        public virtual ICollection<UserCafe> UserCafe { get; set; }
        public virtual ICollection<UserOpportunities> UserOpportunities { get; set; }
    }
}
