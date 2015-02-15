using MvcForbiddenIsland.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.DAL
{
    public class ForbiddenIslandContext : DbContext
    {

        public ForbiddenIslandContext() : base("ForbiddenIsland")
        {
        }

        public DbSet<IslandTile> IslandTile { get; set; }
        public DbSet<Player> Player { get; set; }
    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}