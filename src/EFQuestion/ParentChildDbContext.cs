using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFQuestion
{
    public class ParentChildDbContext : DbContext
    {
        public ParentChildDbContext(DbContextOptions<ParentChildDbContext> options) : base(options)
        {
        }


        public DbSet<Child> Child { get; set; }

        public DbSet<Parent> Parent { get; set; }
    }
}
