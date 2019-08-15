using CrudEntity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CrudEntity.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Crud")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext,
            //CrudEntity.Migrations.Configuration>("Crud"));
        }
        public DbSet<BannerTemplate> BannerTemplates { get; set; } //userbannertemplate
        public DbSet<TemplateBanners> TemplateBanners { get; set; }//templatebanner

        public DbSet<Image> Images { get; set; }//ImageTable 
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {        
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
       
      
    }
}