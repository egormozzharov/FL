namespace FL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeddateTimetoStr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AvailableTarifs", "StartDate", c => c.String());
            AlterColumn("dbo.AvailableTarifs", "EndDate", c => c.String());
            AlterColumn("dbo.TarifDatas", "CreateDate", c => c.String());
            AlterColumn("dbo.TarifDatas", "UpdateDate", c => c.String());
            AlterColumn("dbo.TarifSales", "StartDate", c => c.String());
            AlterColumn("dbo.TarifSales", "EndDate", c => c.String());
            AlterColumn("dbo.VacancyApplies", "ApplyDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VacancyApplies", "ApplyDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TarifSales", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TarifSales", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TarifDatas", "UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TarifDatas", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AvailableTarifs", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AvailableTarifs", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
