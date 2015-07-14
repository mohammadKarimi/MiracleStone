namespace MiracleStone.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MiracleStone.Data.Context.MiracleStoneDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MiracleStone.Data.Context.MiracleStoneDbContext context)
        {
        }
    }
}
