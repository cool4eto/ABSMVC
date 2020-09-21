using ABS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABS.Entities
{
    public class AirlineViewModel
    {
        public int AirlineId { get; set; }
        [Required]
        [Display(Name = "Airline Name")]
        [StringLength(6)]
        [RegularExpression(@"^[A-Za-z][A-Za-z.]+$", ErrorMessage = ExceptionHelper.InvalidAirlineNameCharacters)]
        public string Name { get; set; }
    }
}