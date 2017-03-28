using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFQuestion
{
    public class Child
    {
        [Key]
        public String Name { get; set; }
    }
}
