namespace FL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableTarifs",
                c => new
                    {
                        AvailableTarifId = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DurationDays = c.Int(nullable: false),
                        TarifData_TarifId = c.Int(),
                    })
                .PrimaryKey(t => t.AvailableTarifId)
                .ForeignKey("dbo.TarifDatas", t => t.TarifData_TarifId)
                .Index(t => t.TarifData_TarifId);
            
            CreateTable(
                "dbo.TarifDatas",
                c => new
                    {
                        TarifId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Info = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TarifId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        FromAccountNumber = c.Int(nullable: false),
                        AmountOfMoney = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TarifSales",
                c => new
                    {
                        TarifSaleId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Buyer_Id = c.String(maxLength: 128),
                        Payment_PaymentId = c.Int(),
                        Tarif_AvailableTarifId = c.Int(),
                    })
                .PrimaryKey(t => t.TarifSaleId)
                .ForeignKey("dbo.AspNetUsers", t => t.Buyer_Id)
                .ForeignKey("dbo.Payments", t => t.Payment_PaymentId)
                .ForeignKey("dbo.AvailableTarifs", t => t.Tarif_AvailableTarifId)
                .Index(t => t.Buyer_Id)
                .Index(t => t.Payment_PaymentId)
                .Index(t => t.Tarif_AvailableTarifId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Address = c.String(),
                        IsBlocked = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Vacancies",
                c => new
                    {
                        VacancyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsClosed = c.Boolean(nullable: false),
                        Creator_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VacancyId)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .Index(t => t.Creator_Id);
            
            CreateTable(
                "dbo.VacancyApplies",
                c => new
                    {
                        VacancyAppliesId = c.Int(nullable: false, identity: true),
                        Selected = c.Boolean(nullable: false),
                        ApplyDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                        Vacancy_VacancyId = c.Int(),
                    })
                .PrimaryKey(t => t.VacancyAppliesId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Vacancies", t => t.Vacancy_VacancyId)
                .Index(t => t.User_Id)
                .Index(t => t.Vacancy_VacancyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VacancyApplies", "Vacancy_VacancyId", "dbo.Vacancies");
            DropForeignKey("dbo.VacancyApplies", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vacancies", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TarifSales", "Tarif_AvailableTarifId", "dbo.AvailableTarifs");
            DropForeignKey("dbo.TarifSales", "Payment_PaymentId", "dbo.Payments");
            DropForeignKey("dbo.TarifSales", "Buyer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AvailableTarifs", "TarifData_TarifId", "dbo.TarifDatas");
            DropIndex("dbo.VacancyApplies", new[] { "Vacancy_VacancyId" });
            DropIndex("dbo.VacancyApplies", new[] { "User_Id" });
            DropIndex("dbo.Vacancies", new[] { "Creator_Id" });
            DropIndex("dbo.TarifSales", new[] { "Tarif_AvailableTarifId" });
            DropIndex("dbo.TarifSales", new[] { "Payment_PaymentId" });
            DropIndex("dbo.TarifSales", new[] { "Buyer_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AvailableTarifs", new[] { "TarifData_TarifId" });
            DropTable("dbo.VacancyApplies");
            DropTable("dbo.Vacancies");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TarifSales");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Payments");
            DropTable("dbo.TarifDatas");
            DropTable("dbo.AvailableTarifs");
        }
    }
}
