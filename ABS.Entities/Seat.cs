using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ABS.Entity
{

    /// <summary>
    /// Class mentains information about seats.
    /// </summary>
     [Table("Seat")]
    public partial class Seat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatId { get; set; }
        public int Row { get; set; }
        [Required]
        [StringLength(1)]
        public string Col { get; set; }
        public bool Status { get; set; } = true;

        public int FlightId { get; set; }

        public int SectionId { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual Section Section { get; set; }

        public override string ToString()
        {
            return $"{Row} {Col} {Section.SeatClassName}";
        }
    }
}
