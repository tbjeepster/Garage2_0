using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2_0.Models
{
    public class ParkedVehicle
    {

            public int Id { get; set; }
            public VehicleType Type { get; set; }
            public string RegNum { get; set; }
            public string Colour { get; set; }
            public DateTime ParkedTime { get; set; }
            public int NumOfWeels { get; set; }
            public string CarMake { get; set; }
            public string Model { get; set; }

        public enum VehicleType
        {
            Personbil,
            SUV,
            Buss,
            MC,
            Husvagn
        }
    }
}