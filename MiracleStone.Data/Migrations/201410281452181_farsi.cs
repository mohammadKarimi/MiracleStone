namespace MiracleStone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class farsi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblCategories", "NameFa", c => c.String(nullable: false, maxLength: 35));
            AddColumn("dbo.TblCategories", "DescriptionFa", c => c.String(maxLength: 500));
            AddColumn("Company.TblCompanyInfo", "Lang", c => c.Int(nullable: false));
            AddColumn("dbo.TblProduct", "NameFa", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.TblProjects", "NameFa", c => c.String(nullable: false, maxLength: 60));
            AddColumn("dbo.TblProjects", "LocationFa", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TblProjects", "LocationFa");
            DropColumn("dbo.TblProjects", "NameFa");
            DropColumn("dbo.TblProduct", "NameFa");
            DropColumn("Company.TblCompanyInfo", "Lang");
            DropColumn("dbo.TblCategories", "DescriptionFa");
            DropColumn("dbo.TblCategories", "NameFa");
        }
    }
}
