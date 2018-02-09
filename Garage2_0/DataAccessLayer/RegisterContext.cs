using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Garage2_0.DataAccessLayer
{
    public class RegisterContext : DbContext
    {

        public RegisterContext() : base("DefaultConnection")
        {

        }

        //public DbSet<Models.ParkedVehicle> Vehicle { get; set; }
    }
}