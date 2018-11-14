using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ScriptureApplication.Models
{
    public class ScriptureApplicationContext : DbContext
    {
        public ScriptureApplicationContext (DbContextOptions<ScriptureApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<ScriptureApplication.Models.Scripture> Scripture { get; set; }
    }
}
