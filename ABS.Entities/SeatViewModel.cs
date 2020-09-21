using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABS.Entities
{
    public class SeatViewModel
    {
        public int SeatId { get; set; }
        public string Col { get; set; }
        public int Row { get; set; }
        public bool Status { get; set; }
        public string Section { get; set; }
        public int FlightId { get; set; }
    }
}