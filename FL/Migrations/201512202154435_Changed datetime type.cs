namespace FL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeddatetimetype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "Date", c => c.DateTime(nullable: false));
        }
    }
}
