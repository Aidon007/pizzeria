using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaProject.Models
{
    public partial class Components
    {
        public Components()
        {
            PizzaComponent = new HashSet<PizzaComponent>();
        }

        public int IdComponent { get; set; }
        [Required(ErrorMessage = "Nazwa komponentu jest wymagana")]
        [MaxLength(10, ErrorMessage = "Nazwa komponentu nie m")]
        public string NameComponent { get; set; }

        public virtual ICollection<PizzaComponent> PizzaComponent { get; set; }
    }
}
