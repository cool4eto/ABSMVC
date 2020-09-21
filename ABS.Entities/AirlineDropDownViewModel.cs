using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABS.Entities
{
    public class AirlineDropDownViewModel
    {
        [Display(Name = "Airline")]
        public int SelectedAirlineId { get; set; }
        public IEnumerable<SelectListItem> Airlines { get; set; }
    }
}