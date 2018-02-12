using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Garage2_0.Models;


namespace Garage2_0.DataAccessLayer
{
    public class RegisterContext : DbContext
    {

        public RegisterContext() : base("vehicleConnection")
        {

        }

        public DbSet<ParkedVehicle> Vehicle { get; set; }
    }
}