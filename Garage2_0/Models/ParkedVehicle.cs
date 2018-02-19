using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage2_0.Models
{
    public class ParkedVehicle
    {
            public int Id       { get; set; }

            public int TypeId   { get; set; }

            [Required]
            [DisplayName("Medlemsnummer")]
            public int MemberId { get; set; }

            [RegularExpression("^([a-zA-Z0-9][a-zA-Z0-9]?[a-zA-Z0-9]?[a-zA-Z0-9]?[a-zA-Z0-9]?[a-zA-Z0-9]?[a-zA-Z0-9]?)$", ErrorMessage = "Ogiltig registrerings-sträng")]
            [DisplayName("RegNum")]
            public string RegNum { get; set; }

            [DisplayName("Färg")]
            public string Colour { get; set; }

            [DisplayName("Ankomsttid")]
            public DateTime ParkedTime { get; set; }

            [DisplayName("Hjulantal")]
            public int NumOfWeels { get; set; }

            [Required(ErrorMessage = "Fältet får inte vara tomt.")]
            [StringLength(20, MinimumLength = 1, ErrorMessage = "Längd måste tillhöra intervallet [1, 20]")]
            [DisplayName("Märke")]
            public string CarMake { get; set; }

            [Required(ErrorMessage = "Fältet får inte vara tomt.")]
            [StringLength(30, MinimumLength = 1, ErrorMessage = "Längd måste tillhöra intervallet [1, 30]")]
            [DisplayName("Modell")]
            public string Model { get; set; }

            public virtual ICollection<Member> Member { get; set; }
            public virtual ICollection<VehicleType> Type { get; set; }
    }
    //Indexview
    public class ParkedVehicleProjection01
    {
        public int                       Id         { get; set; }


        [DisplayName("RegNum")]
        public string                    RegNum     { get; set; }

        [DisplayName("Ankomsttid")]
        public DateTime                  ParkedTime { get; set; }

        [DisplayName("Märke")]
        public string                    CarMake    { get; set; }

        [DisplayName("Modell")]
        public string                    Model      { get; set; }
    }
}
