using System;
using System.Collections.Generic;

namespace PizzaProject.Models
{
    public partial class Roles
    {
        public int IdRole { get; set; }
        public string NameRole { get; set; }
        public int UserIdUser { get; set; }

        public virtual UserCafe UserIdUserNavigation { get; set; }
    }
}
