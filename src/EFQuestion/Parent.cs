using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFQuestion
{
    public class Parent
    {
        [Key]
        public String Name { get; set; }

        public bool Active { get; set; }

        public ICollection<Child> Children { get; set; }
    }
}
