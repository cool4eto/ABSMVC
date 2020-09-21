using ABS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABS.Entities
{
    public class SeatSectionCreateViewModel
    {
        public int FlightId { get; set; }
        [Display(Name = "Rows: ")]
        [Range(1, 100, ErrorMessage = ExceptionHelper.RowOutOfBouund)]
        public int row { get; set; }
        [Display(Name = "Columns: ")]
        [Range(1, 10, ErrorMessage = ExceptionHelper.ColumnOutOfBound)]
        public int col { get; set; }
        [Display(Name = "Seat Class: ")]
        public IEnumerable<SelectListItem> SeatClass { get; set; }
        public int SeatClassId { get; set; }
    }
}