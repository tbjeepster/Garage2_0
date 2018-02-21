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
            var members = new[]
            {

                new Member { Name = "Nisse", ContactInfo = "harley42@gmail.com" },
                new Member { Name = "Allan", ContactInfo = "11!" }

            };

            context.Member.AddOrUpdate(
                p => p.ContactInfo,members
            );

            var types = new[]
            {

                new VehicleType { Type = "SUV" },
                new VehicleType { Type = "MC" }
            };

            context.VehicleType.AddOrUpdate(
                p => p.Type, types
            );

            context.SaveChanges();

            context.Vehicle.AddOrUpdate(
                p => p.RegNum,
                new ParkedVehicle { ParkedTime = DateTime.Now, MemberId = members[0].Id,  TypeId = types[0].Id, RegNum = "ASD453", Colour = "Röd", CarMake = "Volvo", Model = "Kaa", NumOfWeels = 4 },
                new ParkedVehicle { ParkedTime = DateTime.Now, MemberId = members[1].Id, TypeId = types[1].Id, RegNum = "ASD953", Colour = "Svart", CarMake = "Ford", Model = "F10", NumOfWeels = 4 }
            );

            context.SaveChanges();
        }
    }
}
