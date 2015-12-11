using GoodServer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GoodServer.DbContexts
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base("BlogContext")
        {
        }
        
        public DbSet<BlogPost> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<BlogContext>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}