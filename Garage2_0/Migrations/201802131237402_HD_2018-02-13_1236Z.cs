namespace Garage2_0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HD_20180213_1236Z : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "CarMake", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ParkedVehicles", "Model", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "Model", c => c.String(maxLength: 30));
            AlterColumn("dbo.ParkedVehicles", "CarMake", c => c.String(maxLength: 20));
        }
    }
}
