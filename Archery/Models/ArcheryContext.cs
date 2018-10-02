using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class ArcheryContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ArcheryContext() : base("name=ArcheryContext")
        {
        }

        public System.Data.Entity.DbSet<Archery.Models.BowType> BowTypes { get; set; }

        public System.Data.Entity.DbSet<Archery.Models.Tournament> Tournaments { get; set; }
    }
}
