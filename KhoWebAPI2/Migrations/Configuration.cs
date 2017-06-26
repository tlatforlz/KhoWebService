namespace KhoWebAPI2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<KhoWebAPI2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
           // AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KhoWebAPI2.Models.ApplicationDbContext context)
        {
           
        }
    }
}
