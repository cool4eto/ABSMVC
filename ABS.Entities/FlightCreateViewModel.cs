using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABS.Entities
{
    public class FlightCreateViewModel
    {
        public int FlightId { get; set; }
        [Display(Name = "Flight Name")]
        [Required]
        public string FlightName { get; set; }
        [Display(Name = "Airline")]
        public IEnumerable<SelectListItem> Airlines { get; set; }
        public int AirlineId { get; set; }

        [Display(Name = "Origin: ")]
        public IEnumerable<SelectListItem> OriginAirports { get; set; }
        public int OrgAirportId { get; set; }

        [Display(Name = "Destination")]
        public IEnumerable<SelectListItem> DestinationAirports { get; set; }
        public int DestAirportId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}