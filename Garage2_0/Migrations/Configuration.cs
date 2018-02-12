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
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "ASD453", Colour = "Röd", CarMake = "Volvo", Model = "Kaa", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "SUV", RegNum = "ASD953", Colour = "Svart", CarMake = "Ford", Model = "F10", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "BSD451", Colour = "Vit", CarMake = "Ford", Model = "Mondeo", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "CSD452", Colour = "Silver", CarMake = "Opel", Model = "Kadett", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "DSD453", Colour = "Vit", CarMake = "Toyota", Model = "Avensis", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "XSD453", Colour = "Blå", CarMake = "Mazda", Model = "323", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "ZSD453", Colour = "Gul", CarMake = "Maserati", Model = "Mistral", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "SUV", RegNum = "XXX453", Colour = "Orange", CarMake = "Dodge", Model = "Ram", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "SUV", RegNum = "AJK453", Colour = "Svart", CarMake = "Jeep", Model = "CJ5", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "SUV", RegNum = "ATR453", Colour = "Svart", CarMake = "Jeep", Model = "Cherokee", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "BBD453", Colour = "Guld", CarMake = "Audi", Model = "A5", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "ASDR122", Colour = "Vit", CarMake = "Mercedes", Model = "PV", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "ASD477", Colour = "Vit", CarMake = "Mercedes", Model = "PV", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "AST433", Colour = "Grön", CarMake = "Saab", Model = "9000", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "ATY417", Colour = "Grå", CarMake = "Renault", Model = "Kangoo", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "ASU481", Colour = "Röd", CarMake = "Ford", Model = "Scorpio", NumOfWeels = 4 },
                   new ParkedVehicle {ParkedTime= DateTime.Now , Type = "Personbil", RegNum = "ASR408", Colour = "Orange", CarMake = "Alfa-Romeo", Model = "Montreal", NumOfWeels = 4 });
        }
    }
}
