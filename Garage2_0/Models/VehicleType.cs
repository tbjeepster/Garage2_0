using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Garage2_0.Models
{
    public class VehicleType
    {
        public int Id { get; set; }

        [DisplayName("Fordonstyp")]
        public string Type { get; set; }

        public virtual ICollection<ParkedVehicle> Parkings { get; set; }
    }
}
