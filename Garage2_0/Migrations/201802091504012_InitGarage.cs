namespace Garage2_0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitGarage : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        RegNum = c.String(),
                        Colour = c.String(),
                        ParkedTime = c.DateTime(nullable: false),
                        NumOfWeels = c.Int(nullable: false),
                        CarMake = c.String(),
                        Model = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParkedVehicles");
        }
    }
}
