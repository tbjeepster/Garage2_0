using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2_0.Models
{
    public class ParkedVehicle
    {

            public int Id { get; set; }
            public string Type { get; set; }
            public string RegNum { get; set; }
            public string Colour { get; set; }
            public DateTime ParkedTime { get; set; }
            public int NumOfWeels { get; set; }
            public string CarMake { get; set; }
            public string Model { get; set; }
    }
}