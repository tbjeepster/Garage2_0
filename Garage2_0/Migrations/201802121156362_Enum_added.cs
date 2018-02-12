namespace Garage2_0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enum_added : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "Type", c => c.String());
        }
    }
}
