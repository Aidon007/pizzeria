using System;
using System.Collections.Generic;

namespace PizzaProject.Models
{
    public partial class UserCafe
    {
        public UserCafe()
        {
            Roles = new HashSet<Roles>();
            UserOpportunities = new HashSet<UserOpportunities>();
        }

        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int PizzaCafeIdPizzaCafe { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public virtual PizzaCafe PizzaCafeIdPizzaCafeNavigation { get; set; }
        public virtual ICollection<Roles> Roles { get; set; }
        public virtual ICollection<UserOpportunities> UserOpportunities { get; set; }
    }
}
