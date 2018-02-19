using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Garage2_0.Models
{
    public class Member
    {
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [DisplayName("Medlemsnummer")]
        public int    Id    { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Längd måste tillhöra intervallet [1, 50]")]
        [DisplayName("Namn")]
        public string Name        { get; set; }

        [StringLength(60, ErrorMessage = "Max 60 tecken.")]
        [DisplayName("Kontaktinformation")]
        public string ContactInfo { get; set; }

        public virtual ICollection<ParkedVehicle> Parkings { get; set; }
    }
}