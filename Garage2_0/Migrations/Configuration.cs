namespace Garage2_0.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2_0.DataAccessLayer.RegisterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage2_0.DataAccessLayer.RegisterContext context)
        {

            context.Member.AddOrUpdate(
                p => p.Id,
                new Member { Name = "Nisse", ContactInfo = "harley42@gmail.com" },
                new Member { Name = "Allan", ContactInfo = null }
            );

            context.VehicleType.AddOrUpdate(
                p => p.Id,
                new VehicleType { Type = "SUV" },
                new VehicleType { Type = "MC" }
            );

            context.Vehicle.AddOrUpdate(
                p => p.RegNum,
                new ParkedVehicle { ParkedTime = DateTime.Now, MemberId = 1,  TypeId = 1, RegNum = "ASD453", Colour = "Röd", CarMake = "Volvo", Model = "Kaa", NumOfWeels = 4 },
                new ParkedVehicle { ParkedTime = DateTime.Now, MemberId = 2, TypeId = 2, RegNum = "ASD953", Colour = "Svart", CarMake = "Ford", Model = "F10", NumOfWeels = 4 }
            );
        }
    }
}
