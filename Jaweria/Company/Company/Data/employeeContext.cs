using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Company.Models
{
    public class employeeContext : DbContext
    {
        public employeeContext (DbContextOptions<employeeContext> options)
            : base(options)
        {
        }

        public DbSet<Company.Models.emp> emp { get; set; }
    }
}
