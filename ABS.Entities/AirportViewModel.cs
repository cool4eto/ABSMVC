using ABS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABS.Entities
{
    public class AirportViewModel
    {
        public int AirportId { get; set; }
        [Required]
        [Display(Name = "Airport Name")]
        [StringLength(3,MinimumLength =3)]
        // Matches the passed string against regex to ensure that it is exactly three upper or lower case letters.
        [RegularExpression(@"^[A-Za-z][A-Za-z.]+$", ErrorMessage = ExceptionHelper.InvalidAirportNameCharacters)]
        public string Name { get; set; }
    }
}