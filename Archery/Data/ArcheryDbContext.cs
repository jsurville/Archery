using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Archery.Models;

namespace Archery.Data
{
    public class ArcheryDbContext:DbContext
    {
        public ArcheryDbContext() : base("ArcheryContext")
        {
            this.Database.Log = s => Debug.Write(s);
        }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Archer> Archers { get; set; }
        public DbSet<Shooter> Shooters { get; set; }
        public DbSet<BowType> BowTypes { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
    }
}