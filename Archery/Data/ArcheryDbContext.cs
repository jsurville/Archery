using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Archery.Models;

namespace Archery.Data
{
    public class ArcheryDbContext:DbContext
    {
        public ArcheryDbContext() : base("ArcheryContext")
        {

        }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Archer> Archers { get; set; }
        
    }
}