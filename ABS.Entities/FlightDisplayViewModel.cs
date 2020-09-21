using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABS.Entities
{
    public class FlightDisplayViewModel
    {
        public int FlightId { get; set; }
        [Display(Name = "Flight Name")]
        public string FlightName { get; set; }

        public string Airline { get; set; }
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }
        public bool HasSeats { get; set; }
    }
}