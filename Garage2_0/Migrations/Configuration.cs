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
            context.Vehicle.AddOrUpdate(
            p => p.RegNum,
             new ParkedVehicle { Type = "Personbil", RegNum = "ASD453", Colour = "Red", CarMake = "Volvo", Model = "PV", NumOfWeels = 4, ParkedTime = DateTime.Now });
        }
    }
}
