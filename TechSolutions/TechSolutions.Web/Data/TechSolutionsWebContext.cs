using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechSolutions.Model;

namespace TechSolutions.Web.Data
{
    public class TechSolutionsWebContext : DbContext
    {
        public TechSolutionsWebContext (DbContextOptions<TechSolutionsWebContext> options)
            : base(options)
        {
        }

        public DbSet<TechSolutions.Model.CustomerAddress> CustomerAddress { get; set; }
    }
}
